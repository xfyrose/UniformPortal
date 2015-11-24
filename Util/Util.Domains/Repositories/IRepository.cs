using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Util.Core;
using Util.Core.Datas;

namespace Util.Domains.Repositories
{
    public interface IRepository<TEntity, in TKey> : IDependency
        where TEntity : class, IAggregateRoot<TKey>
    {
        void Add(TEntity entity);
        void Add(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Update(TEntity newEntity, TEntity oldEntity);
        void Remove(TKey id);
        void Remove(IEnumerable<TKey> ids);
        void Remove(TEntity entity);
        void Remove(IEnumerable<TEntity> entities);
        void Remove(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> FindAll();
        TEntity Single(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Find();
        IQueryable<TEntity> Find(ICriteria criteria);
        IQueryable<TEntity> Find(ICriteria<TEntity> cirteria);
        TEntity Find(params object[] id);
        List<TEntity> Find(IEnumerable<TKey> ids);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> FindList(Expression<Func<TEntity, bool>> predicate);
        bool Exists(Expression<Func<TEntity, bool>> predicate);
        TEntity this[TKey id] { get; }
        IQueryable<TEntity> Query(IQueryBase<TEntity> query);
        PagerList<TEntity> PagerQuery(IQueryBase<TEntity> query);
        void Save();
        int Count(Expression<Func<TEntity, bool>> predicate = null);
        void Clear();
        void ClearCache();
        IUnitOfWork GetUnitOfWork();
    }
}