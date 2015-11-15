using System.Collections.Specialized;
using System.Configuration;

namespace DomainEvent.Fx.Configuration
{
    /// <summary>
    ///     ConfigurationManager 封装
    /// </summary>
    public class ConfigurationManagerWrapper : IConfigurationManager
    {
        /// <summary>
        ///     AppSettings
        /// </summary>
        public NameValueCollection AppSettings
        {
            get { return ConfigurationManager.AppSettings; }
        }

        /// <summary>
        ///     Get App Settings
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetAppSetting(string key)
        {
            return AppSettings[key];
        }

        /// <summary>
        ///     Get Connection String
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        /// <summary>
        ///     Get Provider Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetProviderName(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ProviderName;
        }

        /// <summary>
        ///     Get Section by section name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public T GetSection<T>(string sectionName)
        {
            return (T)ConfigurationManager.GetSection(sectionName);
        }
    }
}