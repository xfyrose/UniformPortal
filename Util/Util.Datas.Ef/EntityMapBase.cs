using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Util.Domains;

namespace Util.Datas.Ef
{
    public abstract class EntityMapBase<TEntity> : EntityTypeConfiguration<TEntity>, IMap
        where TEntity : class, IEntity
    {
        protected EntityMapBase()
        {
            MapTable();
            MapId();
            MapVersion();
            MapProperties();
            MapAssociations();
        }

        protected abstract void MapTable();
        protected abstract void MapId();

        protected virtual void MapVersion()
        {
            
        }

        protected virtual void MapProperties()
        {
            
        }

        protected virtual void MapAssociations()
        {
            
        }

        public void AddTo(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}