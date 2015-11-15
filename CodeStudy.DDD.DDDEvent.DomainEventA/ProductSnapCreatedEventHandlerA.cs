using DomainEvent;
using System;

namespace DomainEventA
{
    public class ProductSnapCreatedEventHandlerA : ProductSnapCreatedEventHandlerAppointment
    {
        /// <summary>
        ///     Constructed Funtion
        /// </summary>
        public ProductSnapCreatedEventHandlerA()
        {
            Console.WriteLine("调用了 ProductSnapCreatedEventHandlerA");
        }

        /// <summary>
        ///     Internal Handle
        /// </summary>
        /// <param name="e"></param>
        protected override void InternalHandle(ProductSnapCreatedEvent e)
        {
            Console.WriteLine("同步执行了 ProductSnapCreatedEventHandlerA 领域事件，ProductHash = " + e.ProductHash);
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