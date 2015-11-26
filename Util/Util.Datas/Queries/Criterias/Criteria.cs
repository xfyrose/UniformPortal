using System;
using System.Linq.Expressions;
using Util.Domains;

namespace Util.Datas.Queries.Criterias
{
    internal class Criteria<TEntity> : CriteriaBase<TEntity>
        where TEntity : class, IAggregateRoot
    {
        public Criteria(Expression<Func<TEntity, bool>> predicate)
        {
            Predicate = predicate;
        }
    }
}