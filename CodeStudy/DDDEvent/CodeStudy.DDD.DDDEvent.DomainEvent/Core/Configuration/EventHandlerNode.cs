using System;
using System.Xml.Serialization;

namespace DomainEvent.Core.Configuration
{
    /// <summary>
    ///     领域事件处理器
    /// </summary>
    [Serializable]
    public class EventHandlerNode
    {
        /// <summary>
        ///     领域事件接口名
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        ///     领域事件处理器类型
        /// </summary>
        [XmlAttribute("handlerType")]
        public string EventHandlerType { get; set; }

        /// <summary>
        ///     领域事件类型
        /// </summary>
        [XmlAttribute("eventType")]
        public string EventType { get; set; }

        /// <summary>
        ///     领域事件接口 IoC 解析名
        /// </summary>
        [XmlAttribute("resolverName")]
        public string ResolverName { get; set; }
    }
}