using DomainEvent.Fx;
using DomainEvent.Fx.Helper;

namespace DomainEvent.Core
{
    /// <summary>
    /// 领域事件基类
    /// </summary>
    public abstract class DomainEventBase : IDomainEvent
    {
        /// <summary>
        /// 领域事件名称
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// 领域事件自校验方法
        /// </summary>
        /// <returns></returns>
        public virtual bool IsValid()
        {
            return EventName.IsNotNullNorWhiteSpace();
        }

        #region GetHashCode

        /// <summary>
        /// GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return CommonHelper.GetHashCode(EventName);
        }

        #endregion GetHashCode
    }
}