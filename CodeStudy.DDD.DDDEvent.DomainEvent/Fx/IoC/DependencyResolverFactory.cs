using DomainEvent.Fx.Configuration;
using System;

namespace DomainEvent.Fx.IoC
{
    /// <summary>
    /// 依赖解析器工厂方法
    /// </summary>
    public class DependencyResolverFactory : IDependencyResolverFactory
    {
        private readonly Type _resolverType;

        /// <summary>
        /// 依赖解析器工厂方法
        /// </summary>
        /// <param name="resolverTypeName"></param>
        public DependencyResolverFactory(string resolverTypeName)
        {
            resolverTypeName.CheckNull("resolverTypeName");

            _resolverType = Type.GetType(resolverTypeName, true, true);
        }

        /// <summary>
        /// 依赖解析器工厂方法
        /// </summary>
        public DependencyResolverFactory()
            : this(new ConfigurationManagerWrapper().AppSettings["StartupResolver"])
        {
        }

        /// <summary>
        /// 创建一个依赖解析器工厂方法的实例
        /// </summary>
        /// <returns></returns>
        public IDependencyResolver CreateInstance()
        {
            return Activator.CreateInstance(_resolverType) as IDependencyResolver;
        }
    }
}