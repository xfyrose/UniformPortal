namespace DomainEvent.Core
{
    /// <summary>
    /// 领域事件处理器接口
    /// </summary>
    public interface IDomainEventHandler
    {
        /// <summary>
        /// 领域事件处理方法
        /// </summary>
        /// <param name="e"></param>
        void Handle(DomainEventBase e);

        /// <summary>
        /// 领域事件处理器自校验方法
        /// </summary>
        /// <returns></returns>
        bool IsValid(DomainEventBase e);
    }
}