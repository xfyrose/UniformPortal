using DomainEvent.Fx;
using System;
using System.Xml.Serialization;

namespace DomainEvent.Core.Configuration
{
    /// <summary>
    ///     别名集合
    /// </summary>
    [Serializable]
    public class AliasNodeCollection : CollectionWrapper<AliasNode>
    {
        /// <summary>
        ///     索引器
        /// </summary>
        /// <param name="aliasName"></param>
        /// <returns></returns>
        [XmlIgnore]
        public AliasNode this[string aliasName]
        {
            get { return GetAlias(aliasName); }
        }

        /// <summary>
        ///     获得指定的别名节点
        /// </summary>
        /// <param name="aliasName"></param>
        /// <returns></returns>
        public AliasNode GetAlias(string aliasName)
        {
            aliasName.CheckNull("aliasName");
            return FirstOrDefault(x => x.AliasName == aliasName);
        }

        /// <summary>
        ///     是否包含指定的别名
        /// </summary>
        /// <param name="aliasName"></param>
        /// <returns></returns>
        public bool ContainsKey(string aliasName)
        {
            if (string.IsNullOrWhiteSpace(aliasName))
                return false;

            if (GetAlias(aliasName) == null)
                return false;

            return true;
        }
    }
}