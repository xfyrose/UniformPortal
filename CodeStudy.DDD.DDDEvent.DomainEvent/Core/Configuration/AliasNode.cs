using System;
using System.Xml.Serialization;

namespace DomainEvent.Core.Configuration
{
    /// <summary>
    ///     领域事件配置别名
    /// </summary>
    [Serializable]
    public class AliasNode
    {
        /// <summary>
        ///     别名名称
        /// </summary>
        [XmlAttribute("alias")]
        public string AliasName { get; set; }

        /// <summary>
        ///     别名类型
        /// </summary>
        [XmlAttribute("type")]
        public string AliasType { get; set; }
    }
}