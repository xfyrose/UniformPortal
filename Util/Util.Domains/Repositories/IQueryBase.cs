using System;
using System.Linq.Expressions;

namespace Util.Domains.Repositories
{
    public interface IQueryBase<TEntity> : IPager
        where TEntity : class, IAggregateRoot
    {
        Expression<Func<TEntity, bool>> GetPredicate();

        string GetOrderBy();
    }
}