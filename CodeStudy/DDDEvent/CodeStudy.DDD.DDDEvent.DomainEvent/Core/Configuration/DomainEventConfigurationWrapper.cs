using DomainEvent.Fx.Configuration;
using DomainEvent.Fx.Helper;
using System;
using System.IO;
using System.Text;
using System.Xml;

namespace DomainEvent.Core.Configuration
{
    /// <summary>
    ///     领域模型配置封装
    /// </summary>
    public sealed class DomainEventConfigurationWrapper : DomainEventConfiguration
    {
        #region Construction

        /// <summary>
        ///     构建一个 DomainEventConfiguration 封装实例
        /// </summary>
        public DomainEventConfigurationWrapper()
        {
            LoadConfiguration();
        }

        /// <summary>
        ///     构建一个 DomainEventConfiguration 封装实例
        /// </summary>
        /// <param name="appSettigName"></param>
        public DomainEventConfigurationWrapper(string appSettigName)
        {
            LoadConfiguration(appSettigName);
        }

        #endregion Construction

        #region LoadConfiguration

        /// <summary>
        ///     加载配置
        /// </summary>
        public override void LoadConfiguration()
        {
            LoadConfiguration("EntryEventBus-ConfigSource");
        }

        /// <summary>
        ///     加载配置
        /// </summary>
        /// <param name="appSettigName"></param>
        public override void LoadConfiguration(string appSettigName)
        {
            var rightConfigPath = new ConfigurationManagerWrapper().AppSettings[appSettigName];
            var baseConfigPath = AppDomain.CurrentDomain.BaseDirectory;
            var fullConfigPath = MergePathHelper.MergeFilePath(baseConfigPath, rightConfigPath);

            if (string.IsNullOrWhiteSpace(rightConfigPath) || string.IsNullOrWhiteSpace(baseConfigPath) ||
                string.IsNullOrWhiteSpace(fullConfigPath))
                return;

            var xmlDoc = XmlHelper.ReadFull(fullConfigPath);

            if (xmlDoc == null)
                return;

            LoadConfiguration(xmlDoc);
        }

        /// <summary>
        ///     加载配置
        /// </summary>
        /// <param name="xmlDoc"></param>
        public override void LoadConfiguration(XmlDocument xmlDoc)
        {
            using (var stream = new MemoryStream())
            {
                using (var writer = new XmlTextWriter(stream, null))
                {
                    writer.Formatting = Formatting.Indented;
                    xmlDoc.Save(writer);
                    using (var sr = new StreamReader(stream, Encoding.UTF8))
                    {
                        stream.Position = 0;
                        var xmlString = sr.ReadToEnd();
                        DomainEventBusConfiguration = Serializer.XmlDeserialize<EventBusRootNode>(xmlString,
                            Encoding.UTF8);
                    }
                }
            }
        }

        #endregion LoadConfiguration
    }
}