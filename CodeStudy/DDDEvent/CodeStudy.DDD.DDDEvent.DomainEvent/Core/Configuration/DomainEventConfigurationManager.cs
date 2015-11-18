namespace DomainEvent.Core.Configuration
{
    /// <summary>
    ///     领域模型配置管理器
    /// </summary>
    public static class DomainEventConfigurationManager
    {
        private static DomainEventConfiguration _configuration;

        static DomainEventConfigurationManager()
        {
            if (_configuration == null)
                _configuration = new DomainEventConfigurationWrapper();
        }

        /// <summary>
        ///     Get Domain Event Configration
        /// </summary>
        public static DomainEventConfigurationWrapper Configuration
        {
            get { return GetConfiguration(); }
        }

        /// <summary>
        ///     Load Domain Event Configuration
        /// </summary>
        public static void LoadDefaultConfiguration()
        {
            if (_configuration == null)
                _configuration = new DomainEventConfigurationWrapper();
        }

        /// <summary>
        ///     Load Domain Event Configuration
        /// </summary>
        /// <param name="appsettingName"></param>
        public static void LoadNewConfiguration(string appsettingName)
        {
            if (_configuration == null)
                _configuration = new DomainEventConfigurationWrapper(appsettingName);
            else
                _configuration.LoadConfiguration(appsettingName);
        }

        /// <summary>
        ///     Get Domain Event Configuration
        /// </summary>
        /// <returns></returns>
        public static DomainEventConfigurationWrapper GetConfiguration()
        {
            if (_configuration == null)
                LoadDefaultConfiguration();

            return _configuration as DomainEventConfigurationWrapper;
        }
    }
}