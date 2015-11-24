using System;
using System.Linq.Expressions;
using Util.Domains;
using Util.Domains.Repositories;

namespace Util.Datas.Queries.Criterias
{
    public abstract class CriteriaBase<TEntity> : ICriteria<TEntity>
        where TEntity : class, IAggregateRoot
    {
        protected Expression<Func<TEntity, bool>> Predicate { get; set; }

        public virtual Expression<Func<TEntity, bool>> GetPridicate()
        {
            return Predicate;
        }
    }
}