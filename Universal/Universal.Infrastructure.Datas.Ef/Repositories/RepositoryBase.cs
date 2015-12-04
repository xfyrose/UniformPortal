using System;
using Universal.Infrastructure.Core;
using Util.Datas.Ef;
using Util.Domains;

namespace Universal.Infrastructure.Datas.Ef.Repositories
{
    public abstract class RepositoryBase<TEntity> : Repository<TEntity, Guid>
        where TEntity : class, IAggregateRoot<Guid>
    {
        protected RepositoryBase(IUniversalUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }
    }
}