using System;
using System.Linq.Expressions;
using Util.Domains;
using Util.Core;
using Util.Core.Extensions;

namespace Util.Datas.Queries.Criterias
{
    public class OrCriteria<TEntity> : CriteriaBase<TEntity>
        where TEntity : class, IAggregateRoot
    {
        public OrCriteria(Expression<Func<TEntity, bool>> first, Expression<Func<TEntity, bool>> second)
        {
            Predicate = first.OrElse(second);
        }
    }
}