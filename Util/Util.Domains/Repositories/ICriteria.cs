using System;
using System.Linq.Expressions;

namespace Util.Domains.Repositories
{
    public interface ICriteria
    {
        string GetPredicate();

        object[] GetValues();
    }

    public interface ICriteria<TEntity>
        where TEntity : class, IAggregateRoot
    {
        Expression<Func<TEntity, bool>> GetPridicate();
    }
}