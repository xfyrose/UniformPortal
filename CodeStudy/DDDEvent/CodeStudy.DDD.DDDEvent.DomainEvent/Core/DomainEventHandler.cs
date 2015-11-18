namespace DomainEvent.Core
{
    /// <summary>
    /// Domain Event Handler Base
    /// </summary>
    /// <typeparam name="TEvent"></typeparam>
    public abstract class DomainEventHandler<TEvent> : IDomainEventHandler<TEvent>
          where TEvent : DomainEventBase, IDomainEvent
    {
        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="e"></param>
        public abstract void Handle(DomainEventBase e);

        /// <summary>
        /// IsValid
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public abstract bool IsValid(DomainEventBase e);
    }
}