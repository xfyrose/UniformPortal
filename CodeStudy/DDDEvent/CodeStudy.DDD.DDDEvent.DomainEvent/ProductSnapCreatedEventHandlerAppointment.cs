using DomainEvent.Core;

namespace DomainEvent
{
    /// <summary>
    ///     Product Snap 创建事件处理器结构约定
    /// </summary>
    public abstract class ProductSnapCreatedEventHandlerAppointment
        : DomainEventHandlerAppointment<ProductSnapCreatedEvent>
    {
        /// <summary>
        ///     Internal Handle
        /// </summary>
        /// <param name="e"></param>
        protected abstract override void InternalHandle(ProductSnapCreatedEvent e);

        /// <summary>
        ///     Internal IsValid
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        protected abstract override bool InternalIsValid(ProductSnapCreatedEvent e);
    }
}