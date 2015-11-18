using DomainEvent.Fx;
using System;
using System.Collections.Generic;
using System.Web;

namespace DomainEvent.Unity
{
    /// <summary>
    ///     Unity PreWebRequest 生命周期模块
    /// </summary>
    public class UnityPerWebRequestLifetimeModule : DisposableResource, IHttpModule
    {
        private static readonly object Key = new object();

        private HttpContextBase _httpContext;

        /// <summary>
        ///     构造 Unity PreWebRequest 生命周期模块
        /// </summary>
        /// <param name="httpContext"></param>
        public UnityPerWebRequestLifetimeModule(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }

        /// <summary>
        ///     构造 Unity PreWebRequest 生命周期模块
        /// </summary>
        public UnityPerWebRequestLifetimeModule()
        {
        }

        internal IDictionary<UnityPerWebRequestLifetimeManager, object> Instances
        {
            get
            {
                _httpContext = (HttpContext.Current != null)
                    ? new HttpContextWrapper(HttpContext.Current)
                    : _httpContext;

                return (_httpContext == null) ? null : GetInstances(_httpContext);
            }
        }

        /// <summary>
        ///     初始化 Unity
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            context.EndRequest += (sender, e) => RemoveAllInstances();
        }

        internal static IDictionary<UnityPerWebRequestLifetimeManager, object> GetInstances(HttpContextBase httpContext)
        {
            IDictionary<UnityPerWebRequestLifetimeManager, object> instances;

            if (httpContext.Items.Contains(Key))
            {
                instances = (IDictionary<UnityPerWebRequestLifetimeManager, object>)httpContext.Items[Key];
            }
            else
            {
                lock (httpContext.Items)
                {
                    if (httpContext.Items.Contains(Key))
                    {
                        instances = (IDictionary<UnityPerWebRequestLifetimeManager, object>)httpContext.Items[Key];
                    }
                    else
                    {
                        instances = new Dictionary<UnityPerWebRequestLifetimeManager, object>();
                        httpContext.Items.Add(Key, instances);
                    }
                }
            }

            return instances;
        }

        internal void RemoveAllInstances()
        {
            var instances = Instances;

            if (!instances.IsNullOrEmpty())
            {
                foreach (var entry in instances)
                {
                    var disposable = entry.Value as IDisposable;

                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }
                }

                instances.Clear();
            }
        }
    }
}