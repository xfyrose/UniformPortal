using DomainEvent.Fx;
using System.Linq;
using System.Xml;

namespace DomainEvent.Core.Configuration
{
    /// <summary>
    ///     Domain Event Configuration
    /// </summary>
    public abstract class DomainEventConfiguration
    {
        #region Public Field Define

        /// <summary>
        ///     领域事件配置
        /// </summary>
        public EventBusRootNode DomainEventBusConfiguration { get; protected set; }

        #endregion Public Field Define

        #region 加载配置

        /// <summary>
        ///     加载配置
        /// </summary>
        public abstract void LoadConfiguration();

        /// <summary>
        ///     加载配置
        /// </summary>
        /// <param name="appSettigName"></param>
        public abstract void LoadConfiguration(string appSettigName);

        /// <summary>
        ///     加载配置
        /// </summary>
        /// <param name="xmlDoc"></param>
        public abstract void LoadConfiguration(XmlDocument xmlDoc);

        #endregion 加载配置

        #region Get Sections

        /// <summary>
        ///     领域事件聚合集合
        /// </summary>
        public EventAggregatorNodeCollection GetEventAggregatorCollection()
        {
            if (DomainEventBusConfiguration == null)
                return null;

            return DomainEventBusConfiguration.EventAggregatorCollection;
        }

        /// <summary>
        ///     领域事件聚合
        /// </summary>
        /// <param name="eventAggregatorName"></param>
        /// <returns></returns>
        public EventAggregatorNode GetEventAggregator(string eventAggregatorName)
        {
            eventAggregatorName.CheckNull("eventAggregatorName");

            var aggregatorCollection = GetEventAggregatorCollection();

            if (aggregatorCollection == null || !aggregatorCollection.Any())
                return null;

            return aggregatorCollection[eventAggregatorName];
        }

        /// <summary>
        ///     领域事件处理器集合
        /// </summary>
        /// <param name="eventAggregatorName"></param>
        /// <returns></returns>
        public EventHandlerNodeCollection GetEventHandlerCollection(string eventAggregatorName)
        {
            eventAggregatorName.CheckNull("eventAggregatorName");

            var aggregator = GetEventAggregator(eventAggregatorName);

            if (aggregator == null)
                return null;

            return aggregator.EventHandlerCollection;
        }

        /// <summary>
        ///     领域事件处理器
        /// </summary>
        /// <param name="eventAggregatorName"></param>
        /// <param name="eventHandlerName"></param>
        /// <returns></returns>
        public EventHandlerNode GetEventHandler(string eventAggregatorName, string eventHandlerName)
        {
            eventAggregatorName.CheckNull("eventAggregatorName");
            eventHandlerName.CheckNull("eventHandlerName");

            var handlerCollection = GetEventHandlerCollection(eventAggregatorName);
            if (handlerCollection.IsNullOrEmpty())
                return null;

            return handlerCollection[eventHandlerName];
        }

        /// <summary>
        ///     获得别名集合
        /// </summary>
        /// <returns></returns>
        public AliasNodeCollection GetAliases()
        {
            return DomainEventBusConfiguration.AliasCollection;
        }

        /// <summary>
        ///     获得别名
        /// </summary>
        /// <param name="aliasName"></param>
        /// <returns></returns>
        public AliasNode GetAlias(string aliasName)
        {
            var aliasesCollection = GetAliases();
            if (aliasesCollection.IsNullOrEmpty())
                return null;

            return aliasesCollection[aliasName];
        }

        /// <summary>
        ///     是否存在别名
        /// </summary>
        /// <param name="aliasName"></param>
        /// <returns></returns>
        public bool ContainsAlias(string aliasName)
        {
            var aliasesCollection = GetAliases();
            if (aliasesCollection.IsNullOrEmpty())
                return false;

            return aliasesCollection.ContainsKey(aliasName);
        }

        #endregion Get Sections
    }
}