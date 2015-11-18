using System;

namespace DomainEvent.Core
{
    /// <summary>
    /// 表示代理给定的领域事件处理委托的领域事件处理器。
    /// </summary>
    /// <typeparam name="TDomainEvent"></typeparam>
    internal sealed class ActionDelegatedEventHandler<TDomainEvent> : IDomainEventHandler<TDomainEvent>
        where TDomainEvent : DomainEventBase, IDomainEvent
    {
        #region Private Fields

        private readonly Action<TDomainEvent> _eventHandlerDelegate;
        private readonly Type _internalType;

        #endregion Private Fields

        #region 构造方法

        /// <summary>
        /// 初始化一个新的<c>ActionDelegatedDomainEventHandler{TEvent}</c>实例。
        /// </summary>
        /// <param name="eventHandlerDelegate">用于当前领域事件处理器所代理的事件处理委托。</param>
        public ActionDelegatedEventHandler(Action<TDomainEvent> eventHandlerDelegate)
        {
            _eventHandlerDelegate = eventHandlerDelegate;
            _internalType = typeof(TDomainEvent);
        }

        #endregion 构造方法

        #region IEventHandler<TEvent> Members

        /// <summary>
        /// 处理给定的事件。
        /// </summary>
        /// <param name="evnt">需要处理的事件。</param>
        public void Handle(DomainEventBase evnt)
        {
            Type type = evnt.GetType();
            if (type != _internalType)
                return;

            _eventHandlerDelegate((TDomainEvent)evnt);
        }

        /// <summary>
        /// 委托领域事件处理器自校验方法
        /// </summary>
        /// <param name="evnt"></param>
        /// <returns></returns>
        public bool IsValid(DomainEventBase evnt)
        {
            Type type = evnt.GetType();
            if (type != _internalType)
                return false;

            return evnt.IsValid();
        }

        #endregion IEventHandler<TEvent> Members

        #region Equals

        /// <summary>
        /// 获取一个<see cref="Boolean"/>值，该值表示当前对象是否与给定的类型相同的另一对象相等。
        /// </summary>
        /// <param name="other">需要比较的与当前对象类型相同的另一对象。</param>
        /// <returns>如果两者相等，则返回true，否则返回false。</returns>
        public override bool Equals(object other)
        {
            if (ReferenceEquals(this, other))
                return true;
            // ReSharper disable once UseNullPropagation
            if (other == null)
                return false;
            ActionDelegatedEventHandler<TDomainEvent> otherDelegate = other as ActionDelegatedEventHandler<TDomainEvent>;
            if (otherDelegate == null)
                return false;
            // 使用Delegate.Equals方法判定两个委托是否是代理的同一方法。
            return Delegate.Equals(_eventHandlerDelegate, otherDelegate._eventHandlerDelegate);
        }

        #endregion Equals

        #region GetHashCode

        public override int GetHashCode()
        {
            return _eventHandlerDelegate.GetHashCode();
        }

        #endregion GetHashCode
    }
}