using System;
using System.Collections.Generic;

namespace DomainEvent.Fx.IoC
{
    /// <summary>
    ///     IDependencyResolver
    /// </summary>
    public interface IDependencyResolver : IDependency, IDisposable
    {
        /// <summary>
        ///     Register
        /// </summary>
        /// <param name="instance"></param>
        /// <typeparam name="T"></typeparam>
        void Register<T>(T instance);

        /// <summary>
        ///     Inject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="existing"></param>
        void Inject<T>(T existing);

        /// <summary>
        ///     Resolve
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        T Resolve<T>(Type type);

        /// <summary>
        ///     Resolve
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        T Resolve<T>(Type type, string name);

        /// <summary>
        ///     Resolve
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Resolve<T>();

        /// <summary>
        ///     Resolve
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        T Resolve<T>(string name);

        /// <summary>
        ///     ResolveAll
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> ResolveAll<T>();
    }
}