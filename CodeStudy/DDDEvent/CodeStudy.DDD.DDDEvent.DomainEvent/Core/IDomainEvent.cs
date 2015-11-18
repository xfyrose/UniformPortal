using DomainEvent.Fx.MetaInterface;

namespace DomainEvent.Core
{
    /// <summary>
    /// 领域事件接口
    /// <para>用于向上层屏蔽核心层的元接口</para>
    /// </summary>
    public interface IDomainEvent : IMetaDomainEvent
    {
    }
}