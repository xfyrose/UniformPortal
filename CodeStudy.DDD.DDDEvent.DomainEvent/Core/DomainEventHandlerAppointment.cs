namespace DomainEvent.Core
{
    /// <summary>
    /// Domain Event Handler Appointment
    /// </summary>
    public abstract class DomainEventHandlerAppointment<TEvent> : DomainEventHandler<TEvent>
        where TEvent : DomainEventBase, IDomainEvent
    {
        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="e"></param>
        public override void Handle(DomainEventBase e)
        {
            if (e.GetType() != typeof(TEvent))
                return;

            InternalHandle((TEvent)e);
        }

        /// <summary>
        /// Internal Handle
        /// </summary>
        /// <param name="e"></param>
        protected abstract void InternalHandle(TEvent e);

        /// <summary>
        /// IsValid
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override bool IsValid(DomainEventBase e)
        {
            if (e.GetType() != typeof(TEvent))
                return false;

            return InternalIsValid((TEvent)e);
        }

        /// <summary>
        /// Internal IsValid
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        protected abstract bool InternalIsValid(TEvent e);
    }
}