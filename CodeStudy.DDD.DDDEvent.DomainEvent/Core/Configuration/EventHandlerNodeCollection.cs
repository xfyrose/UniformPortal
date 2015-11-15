using DomainEvent.Fx;
using System;
using System.Xml.Serialization;

namespace DomainEvent.Core.Configuration
{
    /// <summary>
    ///     领域事件处理器集合
    /// </summary>
    [Serializable]
    public class EventHandlerNodeCollection : CollectionWrapper<EventHandlerNode>
    {
        /// <summary>
        ///     索引器
        /// </summary>
        /// <param name="eventHandlerName"></param>
        /// <returns></returns>
        [XmlIgnore]
        public EventHandlerNode this[string eventHandlerName]
        {
            get { return GetEventHandler(eventHandlerName); }
        }

        /// <summary>
        ///     获得指定的领域事件处理器
        /// </summary>
        /// <param name="eventHandlerName"></param>
        /// <returns></returns>
        public EventHandlerNode GetEventHandler(string eventHandlerName)
        {
            return FirstOrDefault(x => x.Name == eventHandlerName);
        }
    }
}