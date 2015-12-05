using System.Collections.Generic;
using System.Linq;
using Util.Core;
using Util.Core.Extensions;
using Util.Core.Datas;
using Util.Core.Logs;
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
        protected readonly IRepository<TEntity, TKey> Repository;
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

        public TDto Create()
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
            throw new System.NotImplementedException();
        }

        public List<TDto> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public PagerList<TDto> Query(TQuery query)
        {
            throw new System.NotImplementedException();
        }

        public void Save(TDto dto)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string ids)
        {
            throw new System.NotImplementedException();
        }
    }
}