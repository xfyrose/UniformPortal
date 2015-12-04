using System;
using System.ComponentModel.DataAnnotations.Schema;
using Util.Domains;

namespace Util.Datas.Ef
{
    public abstract class AggregateMapBase<TEntity, TKey> : EntityMapBase<TEntity>
        where TEntity : AggregateRoot<TKey>
    {
        protected override void MapId()
        {
            HasKey(t => t.Id);
        }

        protected override void MapVersion()
        {
            if (IsSupportRowVersion)
            {
                MapRowVersion();
                return;
            }

            MapConcurrencyToken();
        }

        protected virtual bool IsSupportRowVersion => true;

        private void MapRowVersion()
        {
            Property(t => t.Version)
                .HasColumnName("Version")
                .IsRowVersion()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
                .IsOptional();
        }

        private void MapConcurrencyToken()
        {
            Property(t => t.Version)
                .HasColumnName("Version")
                .IsConcurrencyToken()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsOptional();
        }
    }

    public abstract class AggregateMapBase<TEntity> : AggregateMapBase<TEntity, Guid>
        where TEntity : AggregateRoot<Guid>
    {
        
    }
}