using System;
using System.Xml.Serialization;

namespace DomainEvent.Core.Configuration
{
    /// <summary>
    ///     领域事件总线
    /// </summary>
    [Serializable]
    [XmlRoot("EventBus")]
    public class EventBusRootNode
    {
        /// <summary>
        ///     别名集合
        /// </summary>
        [XmlArray("Aliases")]
        [XmlArrayItem("Alias", typeof(AliasNode))]
        public AliasNodeCollection AliasCollection { get; set; }

        /// <summary>
        ///     领域事件聚合集合
        /// </summary>
        [XmlArray("EventAggregators")]
        [XmlArrayItem("EventAggregator", typeof(EventAggregatorNode))]
        public EventAggregatorNodeCollection EventAggregatorCollection { get; set; }
    }
}