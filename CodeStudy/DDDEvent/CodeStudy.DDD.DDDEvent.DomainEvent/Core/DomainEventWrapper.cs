using DomainEvent.Core.Configuration;
using DomainEvent.Fx;
using DomainEvent.Fx.IoC;
using System;
using System.Linq;
using System.Reflection;

namespace DomainEvent.Core
{
    /// <summary>
    ///     Domain Event Wrapper include event aggregator with several domain event
    ///     handles with domain event.
    ///     <para>Alex.Daniel.Lewis</para>
    ///     <para>2015.03.11</para>
    /// </summary>
    public sealed class DomainEventWrapper : DomainEventAggregator
    {
        #region ResolverAll

        /// <summary>
        ///     解析领域事件处理器
        /// </summary>
        public void ResolverAll()
        {
            if (_internalEventAggregatorConfiguration == null)
                return;

            //获取 EventHandler 接口配置集合，并对其去重整理
            //获得 InterfaceTypeName, HandlerType with AssemblyInfo, DomainEventType with AssemblyInfo and ResolverName
            var allEventHandlers =
                _internalEventAggregatorConfiguration.EventHandlerCollection.DistinctBy(x => x.Name)
                    .Select(
                        x =>
                            new
                            {
                                InterfaceTypeName = x.Name,
                                HandlerType = x.EventHandlerType,
                                x.EventType,
                                x.ResolverName
                            });

            foreach (var eventHandle in allEventHandlers)
            {
                //修正别名
                var handlerTypeName = eventHandle.HandlerType;
                var eventTypeName = eventHandle.EventType;
                if (_internalAliases != null)
                {
                    handlerTypeName = _internalAliases.ContainsKey(handlerTypeName)
                        ? _internalAliases[handlerTypeName].AliasType
                        : handlerTypeName;

                    eventTypeName = _internalAliases.ContainsKey(eventTypeName)
                        ? _internalAliases[eventTypeName].AliasType
                        : eventTypeName;
                }

                //获取约定处理器类型实例
                var handlerType = Type.GetType(handlerTypeName) ??
                                  Assembly.GetCallingAssembly().GetType(handlerTypeName);

                //获取约定事件类型实例
                var eventType = Type.GetType(eventTypeName) ??
                                Assembly.GetCallingAssembly().GetType(eventTypeName);

                //使用 IoC 实例化领域事件处理器
                //var handleInstance = ReflectionWrapper.CreateInstance(eventHandle.InterfaceType);
                var handleInstance =
                    InversionOfControl.Resolve<IDomainEventHandler>(eventHandle.ResolverName);

                //检查实例化的领域事件处理器类型 是否与约定的类型一致
                if (handlerType != handleInstance.GetType())
                    continue;

                //更新订阅
                Subscribe(handleInstance, eventType);
            }
        }

        #endregion ResolverAll

        #region Public Defined

        /// <summary>
        ///     领域事件聚合名称
        /// </summary>
        public string EventAggregatorName { get; private set; }

        /// <summary>
        ///     领域事件聚合缓存过期时间类型
        /// </summary>
        public int ExpireType { get; set; }

        /// <summary>
        ///     领域事件聚合缓存过期秒数
        /// </summary>
        public int ExpireSeconds { get; private set; }

        /// <summary>
        ///     领域事件聚合创建时间
        /// </summary>
        private DateTime CreateTime { get; set; }

        /// <summary>
        ///     领域事件聚合过期时间
        /// </summary>
        public DateTime ExpireTime
        {
            get { return CreateTime.AddSeconds(ExpireSeconds); }
        }

        /// <summary>
        ///     标记领域事件聚合是否已过期
        /// </summary>
        public bool IsExpired
        {
            get { return ExpireTime < DateTime.Now; }
        }

        /// <summary>
        ///     标记领域事件聚合是否解析成功
        /// </summary>
        public bool IsResolveSuccess { get; set; }

        /// <summary>
        ///     领域事件聚合配置
        /// </summary>
        // ReSharper disable once InconsistentNaming
        private EventAggregatorNode _internalEventAggregatorConfiguration { get; set; }

        /// <summary>
        ///     领域事件别名配置
        /// </summary>
        // ReSharper disable once InconsistentNaming
        private AliasNodeCollection _internalAliases { get; set; }

        #endregion Public Defined

        #region Construction

        /// <summary>
        ///     Create a new domain event wrapper
        /// </summary>
        /// <param name="eventAggregatorName"> Doamin event aggregator name </param>
        public DomainEventWrapper(string eventAggregatorName)
        {
            eventAggregatorName.CheckNull("eventAggregatorName");

            EventAggregatorName = eventAggregatorName;

            InitializeWith(eventAggregatorName);
        }

        /// <summary>
        ///     Create a new domain event wrapper
        /// </summary>
        /// <param name="eventAggregatorName"> Doamin event aggregator name </param>
        /// <param name="expireSeconds">       Expire seconds </param>
        public DomainEventWrapper(string eventAggregatorName, int expireSeconds)
            : this(eventAggregatorName)
        {
            RefreshExpireTime(expireSeconds);
        }

        #endregion Construction

        #region InitializeWith

        /// <summary>
        ///     初始化领域事件聚合
        /// </summary>
        public void InitializeWith()
        {
            InitializeWith(EventAggregatorName);
        }

        /// <summary>
        ///     初始化领域事件聚合
        /// </summary>
        /// <param name="eventAggregatorName"> 领域事件聚合名称 </param>
        public void InitializeWith(string eventAggregatorName)
        {
            LoadEventBusConfig(eventAggregatorName);

            ResolverAll();

            IsResolveSuccess = true;
        }

        #endregion InitializeWith

        #region LoadEventBusConfig

        /// <summary>
        ///     加载领域事件聚合封装体的配置
        /// </summary>
        public void LoadEventBusConfig()
        {
            LoadEventBusConfig(EventAggregatorName);
        }

        /// <summary>
        ///     加载领域事件聚合封装体的配置
        /// </summary>
        /// <param name="eventAggregatorName"> 领域事件聚合名称 </param>
        public void LoadEventBusConfig(string eventAggregatorName)
        {
            var config = DomainEventConfigurationManager.Configuration;

            config.CheckNull("Domain Event Configuration");

            LoadEventAggregatorConfig(config.GetEventAggregator(eventAggregatorName));
            LoadAliasesConfig(config.GetAliases());
        }

        /// <summary>
        ///     加载领域事件聚合封装体的配置
        /// </summary>
        /// <param name="eventAggregatorNode"> 指定的领域事件总线配置节点 </param>
        private void LoadEventAggregatorConfig(EventAggregatorNode eventAggregatorNode)
        {
            eventAggregatorNode.CheckNull("eventAggregatorNode");

            EventAggregatorName = eventAggregatorNode.EventAggregatorName;
            ExpireType = eventAggregatorNode.ExpireType;
            ExpireSeconds = eventAggregatorNode.ExpireTime;
            CreateTime = DateTime.Now;

            _internalEventAggregatorConfiguration = eventAggregatorNode;
        }

        /// <summary>
        ///     加载领域事件别名配置
        /// </summary>
        /// <param name="aliasesCollection">领域事件别名配置</param>
        private void LoadAliasesConfig(AliasNodeCollection aliasesCollection)
        {
            _internalAliases = aliasesCollection;
        }

        #endregion LoadEventBusConfig

        #region Refresh Expire Time

        /// <summary>
        ///     刷新过期时间
        /// </summary>
        public void RefreshExpireTime()
        {
            //不设置缓存，每次绝对刷新配置
            if (ExpireType == 0 || ExpireSeconds == 0)
            {
                ExpireType = 0;
                ExpireSeconds = 0;
                return;
            }

            //一般缓存，未到过期不刷新配置，不自刷过期时间
            if (ExpireType == 1 && !IsExpired)
            {
                return;
            }

            var expireSeconds = ExpireSeconds;

            RefreshExpireTime(expireSeconds);
        }

        /// <summary>
        ///     刷新过期时间
        /// </summary>
        /// <param name="expireSeconds"></param>
        public void RefreshExpireTime(int expireSeconds)
        {
            CreateTime = DateTime.Now;
            ExpireSeconds = expireSeconds;
        }

        #endregion Refresh Expire Time
    }
}