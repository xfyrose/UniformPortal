using System.Collections.Generic;
using System.Linq;
using Util.Core;
using Util.Core.Extensions;
using Util.Core.Datas;
using Util.Core.Exceptions;
using Util.Core.Logs;
using Util.Datas.Extensions;
using Util.Domains;
using Util.Domains.Repositories;
using Util.Security;

namespace Util.Services
{
    public abstract class ServiceBase<TEntity, TDto, TQuery, TKey> : IServiceBase<TDto, TQuery>
        where TEntity : class, IAggregateRoot<TKey>
        where TDto : IDto, new()
        where TQuery : IPager
    {
        protected IUnitOfWork UnitOfWork { get; set; }
        protected IRepository<TEntity, TKey> Repository;
        protected ILog Log { get; set; }

        protected ServiceBase(IUnitOfWork unitofWork, IRepository<TEntity, TKey> repository)
        {
            Repository = repository;
            UnitOfWork = unitofWork;
            Log = Logs.Log4.Log.GetContextLog(this);
        }

        protected string SelfId => SecurityContext.Identity.UserId;

        protected abstract TDto ToDto(TEntity entity);
        protected abstract TEntity ToEntity(TDto dto);

        private void LogBefore(TEntity entity)
        {
            Log.Content.AddLine($"{Util.Resources.Log.BeforeUpdate}:");
            Log.Content.AddLine(entity.ToString());
            Log.Content.AddLine($"{Util.Resources.Log.AfterUpdate}:");
        }

        protected void AddLog(TEntity entity)
        {
            if (!Log.BusinessId.IsEmpty())
            {
                Log.BusinessId += ",";
            }

            Log.BusinessId += entity.Id.ToString();
            Log.Content.Add(entity.ToString());

        }

        protected void WriteLog(string caption, TEntity entity)
        {
            Log.Caption.Add(caption);
            AddLog(entity);
            Log.Info();
        }

        protected void WriteLog(string caption)
        {
            Log.Caption.Add(caption);
            Log.Info();
        }

        protected void WriteLog(string caption, IList<TEntity> entities)
        {
            Log.Caption.Add(caption);
            Log.BusinessId = entities.Select(t => t.Id).Splice();
            entities.ToList().ForEach(entity =>
            {
                Log.Content.Add(entity.ToString());
            });
            Log.Info();
        }

        protected void WriteLog(IPager query, string sql = "")
        {
            Log.SqlParams.AddLine(query.ToString());
            Log.Sql.Add(sql);
            Log.Debug();
        }

        public virtual TDto Create()
        {
            return new TDto();
        }

        public TDto Get(object id)
        {
            TKey key = Conv.To<TKey>(id);
            if (key.Equals(default(TKey)))
            {
                return Create();
            }

            return ToDto(Repository.Find(key));
        }

        public List<TDto> GetByIds(string ids)
        {
            return GetEntitiesByIds(ids).Select(ToDto).ToList();
        }

        protected List<TEntity> GetEntitiesByIds(string ids)
        {
            List<TKey> idList = Conv.ToList<TKey>(ids);
            idList.RemoveAll(t => t.Equals(default(TKey)));

            return Repository.Find(idList);
        }

        public virtual List<TDto> GetAll()
        {
            return Repository.FindAll().Select(ToDto).ToList();
        }

        public virtual PagerList<TDto> Query(TQuery param)
        {
            IQueryBase<TEntity> query = GetQuery(param);
            IQueryable<TEntity> queryable = Repository.Query(query).OrderBy(query.GetOrderBy()).Pager(query);
            WriteLog(param, queryable.ToString());

            return queryable.ToPagerList(query).Convert(ToDto);
        }

        public abstract IQueryBase<TEntity> GetQuery(TQuery param);

        public virtual void Save(TDto dto)
        {
            UnitOfWork.Start();
            TEntity entity = ToEntity(dto);
            if (IsNew(dto, entity))
            {
                Add(entity);
            }
            else
            {
                Update(entity);
            }
            UnitOfWork.Commit();
            WriteLog(Util.Resources.Log.SaveSuccess);
        }

        protected virtual bool IsNew(TDto dto, TEntity entity)
        {
            if (dto.Id.IsEmpty())
            {
                return true;
            }
            if (entity.Id.Equals(default(TKey)))
            {
                return true;
            }

            return false;
        }

        protected virtual void Add(TEntity entity)
        {
            entity.CheckNull(nameof(entity));
            AddBefore(entity);
            entity.Init();
            entity.Validate();
            Repository.Add(entity);
            AddAfter(entity);
        }

        protected virtual void AddBefore(TEntity entity)
        {
            
        }

        protected virtual void AddAfter(TEntity entity)
        {
            AddLog(entity);
        }

        protected virtual void Update(TEntity entity)
        {
            entity.CheckNull(nameof(entity));
            TEntity oldEntity = Repository.Find(entity.Id);
            oldEntity.CheckNull(nameof(entity));
            UpdateBefore(entity, oldEntity);
            entity.Validate();
            Update(entity, oldEntity);
            UpdateAfter(entity);
        }

        protected virtual void UpdateBefore(TEntity newEntity, TEntity oldEntity)
        {
            ValidateVersion(newEntity, oldEntity);
            LogBefore(oldEntity);
        }

        private void ValidateVersion(TEntity newEntity, TEntity oldEntity)
        {
            if (newEntity.Version == null)
            {
                throw new ConcurrencyException();
            }

            if (oldEntity.Version.Where((t, i) => newEntity.Version[i] != t).Any())
            {
                throw new ConcurrencyException();
            }
        }

        protected virtual void Update(TEntity newEntity, TEntity oldEntity)
        {
            Repository.Update(newEntity, oldEntity);
        }

        protected virtual void UpdateAfter(TEntity entity)
        {
            AddLog(entity);
        }

        public virtual void Delete(string ids)
        {
            List<TEntity> entities = GetEntitiesByIds(ids);
            DeleteBefore(entities);
            Repository.Remove(entities);
            WriteLog(Util.Resources.Log.DeleteSuccess, entities);
        }

        protected virtual void DeleteBefore(List<TEntity> entities)
        {
            
        }
    }
}