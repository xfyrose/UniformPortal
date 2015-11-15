using System.Collections.Specialized;

namespace DomainEvent.Fx.Configuration
{
    /// <summary>
    ///     配置管理器接口
    /// </summary>
    public interface IConfigurationManager
    {
        /// <summary>
        ///     AppSettings 配置
        /// </summary>
        NameValueCollection AppSettings { get; }

        /// <summary>
        ///     获取appSettings
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetAppSetting(string key);

        /// <summary>
        ///     获取连接字符串
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string GetConnectionString(string name);

        /// <summary>
        ///     获取 DataProvider 名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string GetProviderName(string name);

        /// <summary>
        ///     获得指定节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        T GetSection<T>(string sectionName);
    }
}