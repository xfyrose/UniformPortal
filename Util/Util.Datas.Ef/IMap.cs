using System.Data.Entity.ModelConfiguration.Configuration;

namespace Util.Datas.Ef
{
    public interface IMap
    {
        void AddTo(ConfigurationRegistrar registrar);
    }
}