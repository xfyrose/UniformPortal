using DomainEvent.Fx;
using System;
using System.Xml.Serialization;

namespace DomainEvent.Core.Configuration
{
    /// <summary>
    ///     领域事件聚合集合
    /// </summary>
    [Serializable]
    public class EventAggregatorNodeCollection : CollectionWrapper<EventAggregatorNode>
    {
        /// <summary>
        ///     索引器
        /// </summary>
        /// <param name="eventAggregatorName"></param>
        /// <returns></returns>
        [XmlIgnore]
        public EventAggregatorNode this[string eventAggregatorName]
        {
            get { return GetEventAggregator(eventAggregatorName); }
        }

        /// <summary>
        ///     获得指定的领域事件聚合
        /// </summary>
        /// <param name="eventAggregatorName"></param>
        /// <returns></returns>
        public EventAggregatorNode GetEventAggregator(string eventAggregatorName)
        {
            eventAggregatorName.CheckNull("eventAggregatorName");
            return FirstOrDefault(x => x.EventAggregatorName == eventAggregatorName);
        }
    }
}