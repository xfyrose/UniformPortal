using DomainEvent.Fx.MetaInterface;

namespace DomainEvent.Fx.IoC
{
    /// <summary>
    /// 依赖注入接口，表示该接口的实现类将自动注册到 IoC 容器中
    /// </summary>
    public interface IDependency : IMetaInfrastructure
    {
    }
}