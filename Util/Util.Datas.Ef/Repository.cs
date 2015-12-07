using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Util.Core.Datas;
using Util.Datas.Extensions;
using Util.Domains;
using Util.Domains.Repositories;

namespace Util.Datas.Ef
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IAggregateRoot<TKey>
    {
        protected EfUnitOfWork UnitOfWork { get; }

        protected Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = (EfUnitOfWork)unitOfWork;
        }

        protected IDbConnection Connection => UnitOfWork.Database.Connection;


        public void Add(TEntity entity)
        {
            UnitOfWork.Set<TEntity>().Add(entity);
            UnitOfWork.CommitByStart();
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                return;
            }

            UnitOfWork.Set<TEntity>().AddRange(entities);
            UnitOfWork.CommitByStart();
        }

        public void Update(TEntity entity)
        {
            UnitOfWork.Entry(entity).State = EntityState.Modified;
            UnitOfWork.CommitByStart();
        }

        public void Update(TEntity newEntity, TEntity oldEntity)
        {
            UnitOfWork.Entry(oldEntity).CurrentValues.SetValues(newEntity);
            UnitOfWork.CommitByStart();
        }

        public void Remove(TKey id)
        {
            TEntity entity = Find(id);
            Remove(entity);
        }

        public void Remove(IEnumerable<TKey> ids)
        {
            if (ids == null)
            {
                return;
            }

            Remove(Find(ids.ToArray()));
        }

        public void Remove(TEntity entity)
        {
            UnitOfWork.Set<TEntity>().Remove(entity);
            //UnitOfWork.Entry(entity).State = EntityState.Deleted;
            UnitOfWork.CommitByStart();
        }

        public void Remove(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                return;
            }

            List<TEntity> list = entities.ToList();
            if (!list.Any())
            {
                return;
            }

            UnitOfWork.Set<TEntity>().RemoveRange(list);
            UnitOfWork.CommitByStart();
        }

        public void Remove(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> entites = UnitOfWork.Set<TEntity>().Where(predicate);
            Remove(entites);
        }

        public List<TEntity> FindAll()
        {
            return Find().ToList();
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return Find().FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> Find()
        {
            return UnitOfWork.Set<TEntity>();
        }

        public IQueryable<TEntity> Find(ICriteria criteria)
        {
            return Find().Filter(criteria);
        }

        public IQueryable<TEntity> Find(ICriteria<TEntity> criteria)
        {
            return Find().Filter(criteria);
        }

        public TEntity Find(params object[] id)
        {
            return UnitOfWork.Set<TEntity>().Find(id);
        }

        public List<TEntity> Find(IEnumerable<TKey> ids)
        {
            if (ids == null)
            {
                return null;
            }

            return Find().Where(t => ids.Contains(t.Id)).ToList();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Find().Where(predicate);
        }

        public List<TEntity> FindList(Expression<Func<TEntity, bool>> predicate)
        {
            return Find(predicate).ToList();
        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return Find().Any(predicate);
        }

        public TEntity this[TKey id] => Find(id);

        public IQueryable<TEntity> Query(IQueryBase<TEntity> query)
        {
            return FilterBy(Find(), query);
        }

        protected IQueryable<TEntity> FilterBy(IQueryable<TEntity> queryable, IQueryBase<TEntity> query)
        {
            Expression<Func<TEntity, bool>> predicate = query.GetPredicate();
            if (predicate == null)
            {
                return queryable;
            }

            return queryable.Where(predicate);
        }

        public PagerList<TEntity> PagerQuery(IQueryBase<TEntity> query)
        {
            return Query(query).PagerResult(query);
        }

        public void Save()
        {
            UnitOfWork.Commit();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return UnitOfWork.Set<TEntity>().Count();
            }

            return UnitOfWork.Set<TEntity>().Count(predicate);
        }

        public void Clear()
        {
            foreach (TEntity entity in UnitOfWork.Set<TEntity>())
            {
                UnitOfWork.Set<TEntity>().Remove(entity);
            }

            UnitOfWork.CommitByStart();
        }

        public void ClearCache()
        {
            UnitOfWork.ChangeTracker.Entries().ToList().ForEach(entry => entry.State = EntityState.Detached);
        }

        public IUnitOfWork GetUnitOfWork()
        {
            return UnitOfWork;
        }
    }
}