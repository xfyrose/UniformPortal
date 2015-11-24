using System.Collections.Generic;
using Util.Core.Datas;
using Util.Domains;
using Util.Domains.Repositories;

namespace Util.Services
{
    public abstract class ServiceBase<TEntity, TDto, TQuery, TKey> : IServiceBase<TDto, TQuery>
        where TEntity : class, IAggregateRoot<TKey>
        where TDto : IDto, new()
        where TQuery : IPager
    {
        protected ServiceBase(IUnitOfWork unitofWork, IRepository<TEntity, TKey> repository)
        {
            
        }


        public TDto Create()
        {
            throw new System.NotImplementedException();
        }

        public TDto Get(object id)
        {
            throw new System.NotImplementedException();
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