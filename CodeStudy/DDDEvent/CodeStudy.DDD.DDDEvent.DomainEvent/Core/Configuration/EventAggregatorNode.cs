using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace DomainEvent.Core.Configuration
{
    /// <summary>
    ///     领域事件聚合
    /// </summary>
    [Serializable]
    public class EventAggregatorNode
    {
        /// <summary>
        ///     聚合名称
        /// </summary>
        [XmlAttribute("name")]
        public string EventAggregatorName { get; set; }

        /// <summary>
        ///     过期时间
        /// </summary>
        [DefaultValue(0)]
        [XmlAttribute("expireTime")]
        public int ExpireTime { get; set; }

        /// <summary>
        ///     过期类型
        /// </summary>
        [DefaultValue(0)]
        [XmlAttribute("expireType")]
        public int ExpireType { get; set; }

        /// <summary>
        ///     领域事件处理器集合
        /// </summary>
        //[XmlArrayAttribute("EventHandlers")]
        [XmlArray("EventHandlers")]
        [XmlArrayItem("EventHandler", typeof(EventHandlerNode))]
        // ReSharper disable once InconsistentNaming
        public EventHandlerNodeCollection EventHandlerCollection { get; set; }
    }
}