using DomainEvent.Fx;
using DomainEvent.Fx.IoC;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;

namespace DomainEvent.Unity
{
    /// <summary>
    ///     Unity 依赖解析器
    /// </summary>
    public class UnityDependencyResolver : DisposableResource, IDependencyResolver
    {
        private readonly IUnityContainer _container;

        /// <summary>
        ///     构造依赖解析器
        /// </summary>
        public UnityDependencyResolver()
            : this(new UnityContainer())
        {
            var configuration =
                (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            configuration.Configure(_container);
        }

        /// <summary>
        ///     构造依赖解析器
        /// </summary>
        /// <param name="container"></param>
        [DebuggerStepThrough]
        public UnityDependencyResolver(IUnityContainer container)
        {
            container.CheckNull("container");

            _container = container;
        }

        /// <summary>
        ///     注册
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        [DebuggerStepThrough]
        public void Register<T>(T instance)
        {
            instance.CheckNull("instance");

            _container.RegisterInstance(instance);
        }

        /// <summary>
        ///     依赖注入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="existing"></param>
        [DebuggerStepThrough]
        public void Inject<T>(T existing)
        {
            existing.CheckNull("existing");

            _container.BuildUp(existing);
        }

        /// <summary>
        ///     解析
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public T Resolve<T>(Type type)
        {
            type.CheckNull("type");

            return (T)_container.Resolve(type);
        }

        /// <summary>
        ///     解析
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public T Resolve<T>(Type type, string name)
        {
            type.CheckNull("type");
            name.CheckNull("name");

            return (T)_container.Resolve(type, name);
        }

        /// <summary>
        ///     解析
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [DebuggerStepThrough]
        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        /// <summary>
        ///     解析
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public T Resolve<T>(string name)
        {
            name.CheckBlank("name");

            return _container.Resolve<T>(name);
        }

        /// <summary>
        ///     解析所有
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [DebuggerStepThrough]
        public IEnumerable<T> ResolveAll<T>()
        {
            var namedInstances = _container.ResolveAll<T>();
            var unnamedInstance = default(T);

            try
            {
                unnamedInstance = _container.Resolve<T>();
            }
            catch (ResolutionFailedException)
            {
                //When default instance is missing
            }

            if (Equals(unnamedInstance, default(T)))
            {
                return namedInstances;
            }

            return new ReadOnlyCollection<T>(new List<T>(namedInstances) { unnamedInstance });
        }

        /// <summary>
        ///     释放
        /// </summary>
        /// <param name="disposing"></param>
        [DebuggerStepThrough]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _container.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}