using DomainEvent;
using DomainEvent.Core;
using System;

namespace DomainEventB
{
    /// <summary>
    /// 异步
    /// </summary>
    [HandlesAsynchronously]
    public class ProductSnapCreatedEventHandlerB : ProductSnapCreatedEventHandlerAppointment
    {
        /// <summary>
        ///     Constructed Funtion
        /// </summary>
        public ProductSnapCreatedEventHandlerB()
        {
            Console.WriteLine("调用了 ProductSnapCreatedEventHandlerB");
        }

        /// <summary>
        ///     Internal Handle
        /// </summary>
        /// <param name="e"></param>
        protected override void InternalHandle(ProductSnapCreatedEvent e)
        {
            Console.WriteLine("异步执行了 ProductSnapCreatedEventHandlerB 领域事件，ProductHash = " + e.ProductHash);
        }

        /// <summary>
        ///     Internal IsValid
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override bool InternalIsValid(ProductSnapCreatedEvent e)
        {
            return e.IsValid();
        }
    }
}