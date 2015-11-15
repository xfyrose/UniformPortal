using DomainEvent.Fx;
using DomainEvent.Fx.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainEvent.Core
{
    /// <summary>
    ///     领域事件聚合
    /// </summary>
    public abstract class DomainEventAggregator : DisposableResource, IDomainEventAggregator
    {
        #region Equals

        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private Func<object, object, bool> _eventHandlerEquals = (o1, o2) =>
        {
            var o1Type = o1.GetType();
            var o2Type = o2.GetType();
            if (o1Type.IsGenericType &&
                o1Type.GetGenericTypeDefinition() == typeof(ActionDelegatedEventHandler<>) &&
                o2Type.IsGenericType &&
                o2Type.GetGenericTypeDefinition() == typeof(ActionDelegatedEventHandler<>))
            {
                return o1.Equals(o2);
            }

            return o1Type == o2Type;
        };

        #endregion Equals

        #region GetHashCode

        /// <summary>
        ///     GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            // ReSharper disable once NonReadonlyMemberInGetHashCode
            var handlers = _eventHandlers.Values;
            return CommonHelper.GetHashCode(handlers);
        }

        #endregion GetHashCode

        #region Private Defined

        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private Dictionary<Type, List<object>> _eventHandlers = new Dictionary<Type, List<object>>();

        /// <summary>
        ///     锁止器
        /// </summary>
        private readonly object _lockObj = new object();

        #endregion Private Defined

        #region Subscribe

        /// <summary>
        ///     订阅领域事件
        /// </summary>
        /// <param name="concreteEventHandler"></param>
        /// <param name="domainEventType"></param>
        public void Subscribe(IDomainEventHandler concreteEventHandler, Type domainEventType)
        {
            if (concreteEventHandler == null)
                return;

            lock (_lockObj)
            {
                if (_eventHandlers.ContainsKey(domainEventType))
                {
                    var handlers = _eventHandlers[domainEventType];
                    if (handlers != null)
                    {
                        if (!handlers.Exists(handler => _eventHandlerEquals(handler, concreteEventHandler)))
                            handlers.Add(concreteEventHandler);
                    }
                    else
                    {
                        // ReSharper disable once UseObjectOrCollectionInitializer
                        handlers = new List<object>();
                        handlers.Add(concreteEventHandler);
                    }
                }
                else
                {
                    _eventHandlers.Add(domainEventType, new List<object> { concreteEventHandler });
                }
            }
        }

        /// <summary>
        ///     订阅领域事件
        /// </summary>
        /// <param name="concreteEventHandlers"></param>
        /// <param name="domainEventType"></param>
        public void Subscribe(IEnumerable<IDomainEventHandler> concreteEventHandlers, Type domainEventType)
        {
            foreach (var concreteEventHandler in concreteEventHandlers)
                Subscribe(concreteEventHandler, domainEventType);
        }

        /// <summary>
        ///     订阅领域事件
        /// </summary>
        /// <typeparam name="TDomainEvent"></typeparam>
        /// <param name="concreteEventHandler"></param>
        public void Subscribe<TDomainEvent>(IDomainEventHandler<TDomainEvent> concreteEventHandler)
            where TDomainEvent : DomainEventBase, IDomainEvent
        {
            if (concreteEventHandler == null)
                return;

            var domainEventType = typeof(TDomainEvent);
            Subscribe(concreteEventHandler, domainEventType);
        }

        /// <summary>
        ///     订阅领域事件
        /// </summary>
        /// <typeparam name="TDomainEvent"></typeparam>
        /// <param name="concreteEventHandlers"></param>
        public void Subscribe<TDomainEvent>(IEnumerable<IDomainEventHandler<TDomainEvent>> concreteEventHandlers)
            where TDomainEvent : DomainEventBase, IDomainEvent
        {
            foreach (var concreteEventHandler in concreteEventHandlers)
                Subscribe(concreteEventHandler);
        }

        /// <summary>
        ///     订阅领域事件
        /// </summary>
        /// <typeparam name="TDomainEvent"></typeparam>
        /// <param name="eventHandlerFunc"></param>
        public void Subscribe<TDomainEvent>(Action<TDomainEvent> eventHandlerFunc)
            where TDomainEvent : DomainEventBase, IDomainEvent
        {
            Subscribe(new ActionDelegatedEventHandler<TDomainEvent>(eventHandlerFunc));
        }

        #endregion Subscribe

        #region Unsubscribe

        /// <summary>
        ///     取消订阅领域事件
        /// </summary>
        /// <param name="concreteEventHandler"></param>
        /// <param name="domainEventType"></param>
        public void Unsubscribe(IDomainEventHandler concreteEventHandler, Type domainEventType)
        {
            concreteEventHandler.CheckNull("concreteEventHandler");
            domainEventType.CheckNull("domainEventType");

            lock (_lockObj)
            {
                if (_eventHandlers.ContainsKey(domainEventType))
                {
                    var handlers = _eventHandlers[domainEventType];
                    if (handlers != null &&
                        handlers.Exists(handler => _eventHandlerEquals(handler, concreteEventHandler)))
                    {
                        var handlerToRemove =
                            handlers.First(handler => _eventHandlerEquals(handler, concreteEventHandler));
                        handlers.Remove(handlerToRemove);
                    }
                }
            }
        }

        /// <summary>
        ///     取消订阅领域事件
        /// </summary>
        /// <param name="concreteEventHandlers"></param>
        /// <param name="domainEventType"></param>
        public void Unsubscribe(IEnumerable<IDomainEventHandler> concreteEventHandlers, Type domainEventType)
        {
            foreach (var concreteEventHandler in concreteEventHandlers)
                Unsubscribe(concreteEventHandler, domainEventType);
        }

        /// <summary>
        ///     取消订阅领域事件
        /// </summary>
        /// <typeparam name="TDomainEvent"></typeparam>
        /// <param name="concreteEventHandler"></param>
        public void Unsubscribe<TDomainEvent>(IDomainEventHandler<TDomainEvent> concreteEventHandler)
            where TDomainEvent : DomainEventBase, IDomainEvent
        {
            concreteEventHandler.CheckNull("concreteEventHandler");
            var domainEventType = typeof(TDomainEvent);
            Unsubscribe(concreteEventHandler, domainEventType);
        }

        /// <summary>
        ///     取消订阅领域事件
        /// </summary>
        /// <typeparam name="TDomainEvent"></typeparam>
        /// <param name="concreteEventHandlers"></param>
        public void Unsubscribe<TDomainEvent>(IEnumerable<IDomainEventHandler<TDomainEvent>> concreteEventHandlers)
            where TDomainEvent : DomainEventBase, IDomainEvent
        {
            foreach (var eventHandler in concreteEventHandlers)
                Unsubscribe(eventHandler);
        }

        /// <summary>
        ///     取消订阅领域事件
        /// </summary>
        /// <typeparam name="TDomainEvent"></typeparam>
        /// <param name="eventHandlerFunc"></param>
        public void Unsubscribe<TDomainEvent>(Action<TDomainEvent> eventHandlerFunc)
            where TDomainEvent : DomainEventBase, IDomainEvent
        {
            Unsubscribe(new ActionDelegatedEventHandler<TDomainEvent>(eventHandlerFunc));
        }

        /// <summary>
        ///     取消订阅所有领域事件
        /// </summary>
        public void UnsubscribeAll()
        {
            Clear();
        }

        #endregion Unsubscribe

        #region GetSubscriptions

        /// <summary>
        ///     获得指定类型的领域事件
        /// </summary>
        /// <param name="domainEventType"></param>
        /// <returns></returns>
        public IEnumerable<IDomainEventHandler> GetSubscriptions(Type domainEventType)
        {
            if (_eventHandlers.ContainsKey(domainEventType))
            {
                var handlers = _eventHandlers[domainEventType];
                if (handlers != null)
                    return handlers.Select(handler => handler as IDomainEventHandler).ToList();
            }

            return null;
        }

        /// <summary>
        ///     获得指定类型的领域事件
        /// </summary>
        /// <typeparam name="TDomainEvent"></typeparam>
        /// <returns></returns>
        public IEnumerable<IDomainEventHandler<TDomainEvent>> GetSubscriptions<TDomainEvent>()
            where TDomainEvent : DomainEventBase, IDomainEvent
        {
            var eventType = typeof(TDomainEvent);
            if (_eventHandlers.ContainsKey(eventType))
            {
                var handlers = _eventHandlers[eventType];
                if (handlers != null)
                    return handlers.Select(handler => handler as IDomainEventHandler<TDomainEvent>).ToList();
            }

            return null;
        }

        #endregion GetSubscriptions

        #region Publish

        /// <summary>
        ///     发布领域事件
        /// </summary>
        /// <param name="concreteEvent"></param>
        /// <param name="domainEventType"></param>
        public void Publish(DomainEventBase concreteEvent, Type domainEventType)
        {
            concreteEvent.CheckNull("concreteEvent");
            domainEventType.CheckNull("domainEventType");
            if (concreteEvent.GetType() != domainEventType || !concreteEvent.IsValid())
                return;

            if (_eventHandlers.ContainsKey(domainEventType) && _eventHandlers[domainEventType] != null &&
                _eventHandlers[domainEventType].Count > 0)
            {
                var handlers = _eventHandlers[domainEventType];
                // ReSharper disable once LoopCanBePartlyConvertedToQuery
                foreach (var handler in handlers)
                {
                    var eventHandler = handler as IDomainEventHandler;
                    // ReSharper disable once PossibleNullReferenceException
                    if (!eventHandler.IsValid(concreteEvent))
                        continue;

                    if (eventHandler.GetType().IsDefined(typeof(HandlesAsynchronouslyAttribute), false))
                    {
                        Task.Factory.StartNew(o => eventHandler.Handle((DomainEventBase)o), concreteEvent);
                    }
                    else
                    {
                        eventHandler.Handle(concreteEvent);
                    }
                }
            }
        }

        /// <summary>
        ///     发布领域事件
        /// </summary>
        /// <typeparam name="TDomainEvent">领域事件类型</typeparam>
        /// <param name="concreteEvent">领域事件</param>
        public void Publish<TDomainEvent>(TDomainEvent concreteEvent)
            where TDomainEvent : DomainEventBase, IDomainEvent
        {
            concreteEvent.CheckNull("concreteEvent");

            if (!concreteEvent.IsValid())
                return;

            var domainEventType = concreteEvent.GetType();

            // ReSharper disable once InconsistentlySynchronizedField
            // ReSharper disable once InvertIf
            if (_eventHandlers.ContainsKey(domainEventType) && _eventHandlers[domainEventType] != null &&
                _eventHandlers[domainEventType].Count > 0)
            {
                var handlers = _eventHandlers[domainEventType];

                //Sync Event Handler List
                IList<IDomainEventHandler<TDomainEvent>> syncDomainEventHandlers =
                    new List<IDomainEventHandler<TDomainEvent>>();

                // ReSharper disable once LoopCanBePartlyConvertedToQuery
                foreach (var handler in handlers)
                {
                    var eventHandler = handler as IDomainEventHandler<TDomainEvent>;
                    // ReSharper disable once PossibleNullReferenceException
                    if (!eventHandler.IsValid(concreteEvent))
                        continue;

                    if (eventHandler.GetType().IsDefined(typeof(HandlesAsynchronouslyAttribute), false))
                    {
                        Task.Factory.StartNew(o => eventHandler.Handle((TDomainEvent)o), concreteEvent);
                    }
                    else
                    {
                        syncDomainEventHandlers.Add(eventHandler);
                        //eventHandler.Handle(concreteEvent);
                    }
                }

                //Do Sync Event Handler
                if (!syncDomainEventHandlers.IsNullOrEmpty())
                    foreach (var syncDomainEventHandler in syncDomainEventHandlers)
                        syncDomainEventHandler.Handle(concreteEvent);
            }
        }

        /// <summary>
        ///     发布领域事件
        /// </summary>
        /// <typeparam name="TDomainEvent"></typeparam>
        /// <param name="concreteEvent"></param>
        /// <param name="callback"></param>
        /// <param name="timeout"></param>
        public void Publish<TDomainEvent>(TDomainEvent concreteEvent,
            Action<TDomainEvent, bool, Exception> callback, TimeSpan? timeout = null)
            where TDomainEvent : DomainEventBase, IDomainEvent
        {
            concreteEvent.CheckNull("concreteEvent");

            if (!concreteEvent.IsValid())
                return;

            var domainEventType = concreteEvent.GetType();

            // ReSharper disable once InconsistentlySynchronizedField
            if (_eventHandlers.ContainsKey(domainEventType) && _eventHandlers[domainEventType] != null &&
                _eventHandlers[domainEventType].Count > 0)
            {
                var handlers = _eventHandlers[domainEventType];
                var tasks = new List<Task>();
                try
                {
                    foreach (var handler in handlers)
                    {
                        var eventHandler = handler as IDomainEventHandler<TDomainEvent>;
                        // ReSharper disable once PossibleNullReferenceException
                        if (!eventHandler.IsValid(concreteEvent))
                            continue;

                        if (eventHandler.GetType().IsDefined(typeof(HandlesAsynchronouslyAttribute), false))
                        {
                            tasks.Add(Task.Factory.StartNew(o => eventHandler.Handle((TDomainEvent)o),
                                concreteEvent));
                        }
                        else
                        {
                            eventHandler.Handle(concreteEvent);
                        }
                    }

                    if (tasks.Count > 0)
                    {
                        if (timeout == null)
                            Task.WaitAll(tasks.ToArray());
                        else
                            Task.WaitAll(tasks.ToArray(), timeout.SafeValue());
                    }
                }
                catch (Exception ex)
                {
                    callback(concreteEvent, false, ex);
                }
            }
        }

        #endregion Publish

        #region Clear

        /// <summary>
        ///     清理指定类型的领域事件
        /// </summary>
        /// <typeparam name="TDomainEvent"></typeparam>
        /// <returns></returns>
        public int Clear<TDomainEvent>()
            where TDomainEvent : DomainEventBase, IDomainEvent
        {
            return Clear(typeof(TDomainEvent));
        }

        /// <summary>
        ///     清理指定类型的领域事件
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int Clear(Type type)
        {
            var result = 0;

            lock (_lockObj)
            {
                if (_eventHandlers.ContainsKey(type))
                    result = _eventHandlers.Remove(type) ? 1 : 0;
            }

            return result;
        }

        /// <summary>
        ///     清理所有类型的领域事件
        /// </summary>
        /// <returns></returns>
        public int Clear()
        {
            if (_eventHandlers == null || !_eventHandlers.Any())
                return 0;

            // ReSharper disable once InconsistentlySynchronizedField
            var result = _eventHandlers.Count();
            lock (_lockObj)
            {
                _eventHandlers.Clear();
            }

            return result;
        }

        #endregion Clear
    }
}