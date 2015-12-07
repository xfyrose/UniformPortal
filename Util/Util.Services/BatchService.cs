using System;
using System.Collections.Generic;
using System.Linq;
using Util.Core.Datas;
using Util.Domains;
using Util.Domains.Repositories;

namespace Util.Services
{
    public abstract class BatchService<TEntity, TDto, TQuery, TKey> : ServiceBase<TEntity, TDto, TQuery, TKey>,
        IBatchService<TDto, TQuery>
        where TEntity : class, IAggregateRoot<TKey>, new()
        where TDto : IDto, new()
        where TQuery : IPager
    {
        protected List<TEntity> ListAdd = new List<TEntity>();
        protected List<TEntity> ListUpdate = new List<TEntity>();
        protected List<TEntity> ListDelete = new List<TEntity>();

        protected BatchService(IUnitOfWork unitOfWork, IRepository<TEntity, TKey> repository)
            : base(unitOfWork, repository)
        {

        }

        public List<TDto> Save(List<TDto> addList, List<TDto> updateList, List<TDto> deleteList)
        {
            UnitOfWork.Start();
            SaveBefore(addList, updateList, deleteList);
            AddList();
            UpdateList();
            DeleteList();
            Save();
            SaveAfter();
            WriteLog(Util.Resources.Log.SaveSuccess);

            return GetResult();
        }

        protected virtual void SaveBefore(List<TDto> addList, List<TDto> updateList, List<TDto> deleteList)
        {
            FilterList(addList, deleteList);
            FilterList(updateList, deleteList);

            ListAdd = addList.Select(ToEntity).Distinct().ToList();
            ListUpdate = updateList.Select(ToEntity).Distinct().ToList();
            ListDelete = deleteList.Select(ToEntity).Distinct().ToList();
        }

        private void FilterList(List<TDto> list, IEnumerable<TDto> deleteList)
        {
            list.Select(t => t.Id).ToList().ForEach(id =>
            {
                if (deleteList.Any(d => d.Id == id))
                {
                    list.Remove(list.Find(t => t.Id == id));
                }
            });
        }

        private void AddList()
        {
            if ((ListAdd == null) || (ListAdd.Count == 0))
            {
                return;
            }

            Log.Content.AddLine($"{Util.Resources.Log.AddEntity}:");

            ListAdd.ForEach(Add);
        }

        private void UpdateList()
        {
            if ((ListUpdate == null) || (ListUpdate.Count == 0))
            {
                return;
            }

            Log.Content.Add($"{Util.Resources.Log.UpdateEntity}:");

            ListUpdate.ForEach(Update);
        }

        private void DeleteList()
        {
            if ((ListDelete == null) || (ListDelete.Count == 0))
            {
                return;
            }

            Log.Content.Add($"{Util.Resources.Log.DeleteEntity}:");
        }

        protected virtual void DeleteEntities(TEntity entity)
        {
            DeleteEntity(entity);
        }

        protected void DeleteEntity(TEntity entity)
        {
            Repository.Remove(entity.Id);

            AddLog(entity);
        }

        protected virtual void Save()
        {
            UnitOfWork.Commit();
        }

        protected virtual void SaveAfter()
        {
            
        }

        protected virtual List<TDto> GetResult()
        {
            return new List<TDto>();
        }
    }

    public abstract class BatchService<TEntity, TDto, TQuery> : BatchService<TEntity, TDto, TQuery, Guid>
        where TEntity : class, IAggregateRoot<Guid>, new()
        where TDto : IDto, new()
        where TQuery : IPager
    {
        protected BatchService(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
            : base(unitOfWork, repository)
        {
            
        }
    }
}