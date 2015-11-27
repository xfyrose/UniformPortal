using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Util.Core;
using Util.Domains;
using Util.Domains.Repositories;

namespace Util.Datas.Queries
{
    public interface IQuery<TEntity, TKey> : IQueryBase<TEntity>
        where TEntity : class, IAggregateRoot<TKey>
    {
        IQuery<TEntity, TKey> Filter(Expression<Func<TEntity, bool>> predicate, bool isOr = false);
        IQuery<TEntity, TKey> Filter(string propertyName, object value, Operator @operator = Operator.Equal);
        IQuery<TEntity, TKey> Filter(ICriteria<TEntity> criteria);

        IQuery<TEntity, TKey> FilterInt<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression, int? min, int? max);
        IQuery<TEntity, TKey> FilterDouble<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression, double? min, double? max);
        IQuery<TEntity, TKey> FilterDecimal<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression, DateTime? min, DateTime? max);
        IQuery<TEntity, TKey> FilterDate<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression, DateTime? min, DateTime? max);
        IQuery<TEntity, TKey> FilterDateTime<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression, DateTime? min, DateTime? max);

        IQuery<TEntity, TKey> And(IQuery<TEntity, TKey> query);
        IQuery<TEntity, TKey> And(Expression<Func<TEntity, bool>> predicate);
        IQuery<TEntity, TKey> Or(IQuery<TEntity, TKey> query);
        IQuery<TEntity, TKey> Or(Expression<Func<TEntity, bool>> predicate);

        IQuery<TEntity, TKey> OrderBy<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression, bool desc = false);
        IQuery<TEntity, TKey> OrderBy(string propertyName, bool desc = false);

        List<TEntity> GetList(IQueryable<TEntity> queryable);
        PagerList<TEntity> GetPagerList(IQueryable<TEntity> queryable);
    }

    public interface IQuery<TEntity> : IQuery<TEntity, Guid>
        where TEntity : class, IAggregateRoot<Guid>
    {
    }
}