using System;
using System.Linq.Expressions;
using Util.Domains;
using Util.Core;

namespace Util.Datas.Queries.Criterias
{
    public class AndCriteria<TEntity> : CriteriaBase<TEntity>
        where TEntity : class, IAggregateRoot
    {
        public AndCriteria(Expression<Func<TEntity, bool>> first, Expression<Func<TEntity, bool>> second)
        {
            Predicate = first.And(second);
        }
    }
}