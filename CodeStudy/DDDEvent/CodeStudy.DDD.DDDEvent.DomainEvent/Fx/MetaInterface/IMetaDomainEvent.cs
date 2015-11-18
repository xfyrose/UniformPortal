namespace DomainEvent.Fx.MetaInterface
{
    /// <summary>
    ///     领域事件元接口
    /// </summary>
    public interface IMetaDomainEvent : IMetaHandler
    {
        /// <summary>
        ///     领域事件名称
        /// </summary>
        string EventName { get; set; }

        /// <summary>
        ///     领域事件自校验方法
        /// </summary>
        bool IsValid();
    }
}