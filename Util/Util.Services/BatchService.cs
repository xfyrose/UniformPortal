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
        protected List<TEntity> _addList = new List<TEntity>();
        protected List<TEntity> _updateList = new List<TEntity>();
        protected List<TEntity> _deleteList = new List<TEntity>();

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

            _addList = addList.Select(ToEntity).Distinct().ToList();
            _updateList = updateList.Select(ToEntity).Distinct().ToList();
            _deleteList = deleteList.Select(ToEntity).Distinct().ToList();
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
            if ((_addList == null) || (_addList.Count == 0))
            {
                return;
            }

            Log.Content.AddLine($"{Util.Resources.Log.AddEntity}:");

            _addList.ForEach(Add);
        }

        private void UpdateList()
        {
            if ((_updateList == null) || (_updateList.Count == 0))
            {
                return;
            }

            Log.Content.Add($"{Util.Resources.Log.UpdateEntity}:");

            _updateList.ForEach(Update);
        }

        private void DeleteList()
        {
            if ((_deleteList == null) || (_deleteList.Count == 0))
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