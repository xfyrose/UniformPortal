using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;

namespace DomainEvent.Unity
{
    /// <summary>
    ///     Unity PreWebRequest 生命周期管理器
    /// </summary>
    public class UnityPerWebRequestLifetimeManager : LifetimeManager
    {
        private HttpContextBase _httpContext;

        /// <summary>
        ///     构造 Unity PreWebRequest 生命周期管理器
        /// </summary>
        public UnityPerWebRequestLifetimeManager()
            : this(new HttpContextWrapper(HttpContext.Current))
        {
        }

        /// <summary>
        ///     构造 Unity PreWebRequest 生命周期管理器
        /// </summary>
        /// <param name="httpContext"></param>
        public UnityPerWebRequestLifetimeManager(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }

        private IDictionary<UnityPerWebRequestLifetimeManager, object> BackingStore
        {
            get
            {
                _httpContext = (HttpContext.Current != null)
                    ? new HttpContextWrapper(HttpContext.Current)
                    : _httpContext;

                return UnityPerWebRequestLifetimeModule.GetInstances(_httpContext);
            }
        }

        private object Value
        {
            [DebuggerStepThrough]
            get
            {
                var backingStore = BackingStore;

                return backingStore.ContainsKey(this) ? backingStore[this] : null;
            }

            [DebuggerStepThrough]
            set
            {
                var backingStore = BackingStore;

                if (backingStore.ContainsKey(this))
                {
                    var oldValue = backingStore[this];

                    if (!ReferenceEquals(value, oldValue))
                    {
                        var disposable = oldValue as IDisposable;

                        if (disposable != null)
                        {
                            disposable.Dispose();
                        }

                        if (value == null)
                        {
                            backingStore.Remove(this);
                        }
                        else
                        {
                            backingStore[this] = value;
                        }
                    }
                }
                else
                {
                    if (value != null)
                    {
                        backingStore.Add(this, value);
                    }
                }
            }
        }

        /// <summary>
        ///     获取值
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        public override object GetValue()
        {
            return Value;
        }

        /// <summary>
        ///     设置值
        /// </summary>
        /// <param name="newValue"></param>
        [DebuggerStepThrough]
        public override void SetValue(object newValue)
        {
            Value = newValue;
        }

        /// <summary>
        ///     移除值
        /// </summary>
        [DebuggerStepThrough]
        public override void RemoveValue()
        {
            Value = null;
        }
    }
}