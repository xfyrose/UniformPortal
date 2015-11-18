using DomainEvent.Fx;
using DomainEvent.Fx.MetaInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainEvent.Core
{
    /// <summary>
    /// 领域事件总线
    /// </summary>
    public class DomainEventBus : IDomainEventBus
    {
        #region Private Defined

        /// <summary>
        /// 缓存于消息总线内的领域事件聚合封装体集合
        /// </summary>
        private static Dictionary<string, DomainEventWrapper> _eventWrappers =
            new Dictionary<string, DomainEventWrapper>();

        /// <summary>
        /// 锁止器
        /// </summary>
        private static readonly object LockObj = new object();

        #endregion Private Defined

        #region Register

        /// <summary>
        /// 注册领域事件聚合封装体
        /// </summary>
        /// <param name="eventAggregatorName"></param>
        /// <returns></returns>
        public static DomainEventWrapper Register(string eventAggregatorName)
        {
            eventAggregatorName.CheckNull("eventAggregatorName");

            if (_eventWrappers.ContainsKey(eventAggregatorName))
            {
                // ReSharper disable once InconsistentNaming
                var _eventWrapper = _eventWrappers[eventAggregatorName];

                if (!_eventWrapper.IsExpired)
                {
                    //刷新领域事件的过期时间（1 不进行刷新，2 进行刷新）
                    _eventWrapper.RefreshExpireTime();
                    return _eventWrapper;
                }

                //领域事件（1、2）已过期，则清理领域事件聚合，以便重新加载
                _eventWrappers.Remove(eventAggregatorName);
            }

            var eventWrapper = new DomainEventWrapper(eventAggregatorName);

            // ReSharper disable once InvertIf
            if (eventWrapper.IsResolveSuccess)
            {
                _eventWrappers.Add(eventAggregatorName, eventWrapper);
                return eventWrapper;
            }

            return null;
        }

        /// <summary>
        /// 注册领域事件聚合封装体
        /// <para>如果不存在该聚合封装体，则使用给定的领域事件聚合封装体进行注册</para>
        /// </summary>
        /// <param name="eventAggregatorName"></param>
        /// <param name="domainEventWrapper"></param>
        /// <returns></returns>
        public static DomainEventWrapper Register(string eventAggregatorName,
            DomainEventWrapper domainEventWrapper)
        {
            eventAggregatorName.CheckNull("eventAggregatorName");
            domainEventWrapper.CheckNull("domainEventWrapper");

            if (_eventWrappers.ContainsKey(eventAggregatorName))
            {
                var eventWrapper = _eventWrappers[eventAggregatorName];

                if (!eventWrapper.IsExpired)
                {
                    eventWrapper.RefreshExpireTime();

                    return eventWrapper;
                }

                if (domainEventWrapper.IsExpired)
                    domainEventWrapper.LoadEventBusConfig();

                _eventWrappers[eventAggregatorName] = domainEventWrapper;

                return domainEventWrapper;
            }

            domainEventWrapper.RefreshExpireTime();

            _eventWrappers.Add(eventAggregatorName, domainEventWrapper);

            return domainEventWrapper;
        }

        /// <summary>
        /// 注册领域事件聚合封装体
        /// <para>如果不存在该聚合封装体，则使用给定的领域事件聚合封装体进行注册</para>
        /// </summary>
        /// <param name="eventAggregatorName"></param>
        /// <param name="domainEventAggregator"></param>
        /// <returns></returns>
        public static DomainEventWrapper Register(string eventAggregatorName,
            DomainEventAggregator domainEventAggregator)
        {
            return Register(eventAggregatorName, domainEventAggregator as DomainEventWrapper);
        }

        #endregion Register

        #region Publish

        /// <summary>
        /// 发布领域事件
        /// </summary>
        /// <typeparam name="TDomainEvent"></typeparam>
        /// <param name="eventAggregatorName"></param>
        /// <param name="concreteEvent"></param>
        public static void Publish<TDomainEvent>(string eventAggregatorName, TDomainEvent concreteEvent)
            where TDomainEvent : DomainEventBase, IMetaDomainEvent
        {
            eventAggregatorName.CheckNull("eventAggregatorName");
            concreteEvent.CheckNull("concreteEvent");
            _eventWrappers.CheckNull("_eventWrappers");
            if (!_eventWrappers.ContainsKey(eventAggregatorName))
                throw new ArgumentNullException(string.Format("_eventWrappers 内不包含 {0}", eventAggregatorName));

            var eventWpapper = _eventWrappers[eventAggregatorName];

            eventWpapper.Publish(concreteEvent);
        }

        #endregion Publish

        #region Reset

        /// <summary>
        /// 重置所有领域事件
        /// </summary>
        public static void ResetAll()
        {
            var eventAggregatorNames = _eventWrappers.Keys;

            eventAggregatorNames.Do(Reset);
        }

        /// <summary>
        /// 重置领域事件
        /// </summary>
        /// <param name="eventAggregatorName"></param>
        public static void Reset(string eventAggregatorName)
        {
            eventAggregatorName.CheckNull("eventAggregatorName");

            // ReSharper disable once InvertIf
            if (_eventWrappers.ContainsKey("eventAggregatorName"))
            {
                var eventWrapper = _eventWrappers[eventAggregatorName];

                eventWrapper.LoadEventBusConfig();
            }
        }

        #endregion Reset

        #region Remove

        /// <summary>
        /// 移除指定的领域事件聚合封装体
        /// </summary>
        /// <param name="eventAggregatorName"></param>
        public static void Remove(string eventAggregatorName)
        {
            if (string.IsNullOrWhiteSpace(eventAggregatorName) || !_eventWrappers.ContainsKey(eventAggregatorName))
                return;

            _eventWrappers.Remove(eventAggregatorName);
        }

        /// <summary>
        /// 移除所有领域事件聚合封装体
        /// </summary>
        public static void RemoveAll()
        {
            _eventWrappers.Clear();
            _eventWrappers = new Dictionary<string, DomainEventWrapper>();
        }

        /// <summary>
        /// 如果指定的领域事件聚合封装体已过期，则将其移除
        /// </summary>
        /// <param name="eventAggregatorName"></param>
        public static void RemoveIfExpired(string eventAggregatorName)
        {
            if (string.IsNullOrWhiteSpace(eventAggregatorName))
                return;

            lock (LockObj)
            {
                var eventWrapper = _eventWrappers[eventAggregatorName];

                if (eventWrapper.IsExpired)
                    Remove(eventAggregatorName);
            }
        }

        /// <summary>
        /// 移除所有过期的领域事件聚合封装体
        /// </summary>
        public static void RemoveAllIfExpired()
        {
            lock (LockObj)
            {
                var eventAggregatorNames =
                    _eventWrappers.Where(@event => @event.Value.IsExpired).Select(@event => @event.Key);

                eventAggregatorNames.Do(Remove);
            }
        }

        /// <summary>
        /// 移除所有过期的和过期时间早于指定时间的领域事件聚合封装体
        /// </summary>
        /// <param name="datetime"></param>
        public static void RemoveBefore(DateTime datetime)
        {
            lock (LockObj)
            {
                var eventAggregatorNames =
                    _eventWrappers.Where(@event => @event.Value.IsExpired || @event.Value.ExpireTime < datetime)
                        .Select(@event => @event.Key);

                eventAggregatorNames.Do(Remove);
            }
        }

        #endregion Remove
    }
}