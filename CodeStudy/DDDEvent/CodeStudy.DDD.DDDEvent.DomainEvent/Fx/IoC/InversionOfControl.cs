using System;
using System.Collections.Generic;

namespace DomainEvent.Fx.IoC
{
    /// <summary>
    /// InversionOfControl
    /// </summary>
    public static class InversionOfControl
    {
        private static IDependencyResolver _resolver;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="factory"></param>

        public static void InitializeWith(IDependencyResolverFactory factory)
        {
            factory.CheckNull("factory");

            _resolver = factory.CreateInstance();
        }

        /// <summary>
        /// 注册实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>

        public static void Register<T>(T instance)
        {
            instance.CheckNull("instance");

            _resolver.Register(instance);
        }

        /// <summary>
        /// Inject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="existing"></param>

        public static void Inject<T>(T existing)
        {
            existing.CheckNull("existing");

            _resolver.Inject(existing);
        }

        /// <summary>
        /// Resolve
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>

        public static T Resolve<T>(Type type)
        {
            type.CheckNull("type");

            return _resolver.Resolve<T>(type);
        }

        /// <summary>
        /// Resolve
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>

        public static T Resolve<T>(Type type, string name)
        {
            type.CheckNull("type");
            name.CheckBlank("name");

            return _resolver.Resolve<T>(type, name);
        }

        /// <summary>
        /// Resolve
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>

        public static T Resolve<T>()
        {
            return _resolver.Resolve<T>();
        }

        /// <summary>
        /// Resolve
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>

        public static T Resolve<T>(string name)
        {
            name.CheckBlank("name");

            return _resolver.Resolve<T>(name);
        }

        /// <summary>
        /// ResolveAll
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>

        public static IEnumerable<T> ResolveAll<T>()
        {
            return _resolver.ResolveAll<T>();
        }

        /// <summary>
        /// Reset
        /// </summary>

        public static void Reset()
        {
            if (_resolver != null)
            {
                _resolver.Dispose();
            }
        }
    }
}