namespace DomainEvent.Core
{
    /// <summary>
    /// 领域事件处理器接口
    /// </summary>
    /// <typeparam name="TEvent">事件类型</typeparam>
    public interface IDomainEventHandler<in TEvent> : IDomainEventHandler
        where TEvent : DomainEventBase, IDomainEvent
    {
    }
}