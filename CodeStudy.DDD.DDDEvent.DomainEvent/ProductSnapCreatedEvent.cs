using DomainEvent.Core;
using DomainEvent.Fx;

namespace DomainEvent
{
    /// <summary>
    ///     Product Snap 创建事件
    /// </summary>
    public class ProductSnapCreatedEvent : DomainEventBase
    {
        /// <summary>
        ///     Constructed Funtion
        /// </summary>
        public ProductSnapCreatedEvent()
            : this("ProductSnapLogging")
        {
        }

        /// <summary>
        ///     Constructed Funtion
        /// </summary>
        /// <param name="eventName"></param>
        public ProductSnapCreatedEvent(string eventName)
        {
            EventName = eventName;
        }

        /// <summary>
        ///     Product Hash
        /// </summary>
        public string ProductHash { get; set; }

        /// <summary>
        ///     IsValid
        /// </summary>
        /// <returns></returns>
        public override bool IsValid()
        {
            return ProductHash.IsNotNullNorWhiteSpace() && EventName.IsNotNullNorWhiteSpace();
        }
    }
}