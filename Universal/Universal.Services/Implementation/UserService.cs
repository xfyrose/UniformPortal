using System;
using System.Collections.Generic;
using System.Linq;
using Universal.Domains;
using Universal.Domains.Models;
using Universal.Domains.Queries;
using Universal.Infrastructure.Datas.Core;
using Universal.Services.Contracts;
using Universal.Services.Dtos;
using Util.Core.Datas;
using Util.Core.Exceptions;
using Util.Core.Exports;
using Util.Datas;
using Util.Domains.Repositories;
using Util.Services;

namespace Universal.Services.Implementation
{
    public class UserService : BatchService<User, UserDto, UserQuery, string>, IUserService
    {
        
        protected IExportFactory ExportFactory { get; set; }


        public UserService(IUniversalUnitOfWork unitOfWork, IUserRepository repository, IExportFactory exportFactory)
            : base(unitOfWork, repository)
        {
            Repository = repository;
            ExportFactory = exportFactory;
        }

        protected override UserDto ToDto(User entity)
        {
            return entity.ToDto();
        }

        protected override User ToEntity(UserDto dto)
        {
            return dto.ToEntity();
        }

        protected override void SaveBefore(List<UserDto> addList, List<UserDto> updateList, List<UserDto> deleteList)
        {
            base.SaveBefore(addList, updateList, deleteList);
            Validate(addList);
            Validate(updateList);
        }

        private void Validate(IEnumerable<UserDto> list)
        {
            list.GroupBy(t => t.Name).ToList().ForEach(g =>
            {
                if (g.Count() > 1)
                {
                    ThrowRepeatException(g.Key);
                }
            });
        }

        private void ThrowRepeatException(string name)
        {
            throw new Warning($"{Universal.Resources.User.ValidateNameRepeat}: {name}");
        }

        protected override void AddBefore(User entity)
        {
            base.AddBefore(entity);

            if (Repository.Exists(t => t.Name == entity.Name))
            {
                ThrowRepeatException(entity.Name);
            }
        }

        protected override void UpdateBefore(User newEntity, User oldEntity)
        {
            base.UpdateBefore(newEntity, oldEntity);

            if (Repository.Exists(u => u.Id != newEntity.Id && u.Name == newEntity.Name))
            {
                ThrowRepeatException(newEntity.Name);
            }
        }

        public override UserDto Create()
        {
            return new UserDto
            {
                IsEnabled = true,
                InsertedDateTime = DateTime.Now,
                InsertedUserId = SelfId
            };
        }

        public override IQueryBase<User> GetQuery(UserQuery param)
        {
            return new Query<User, string>(param)
                .Filter(u => u.Id.Contains(param.Id))
                .Filter(u => u.Name.Contains(param.Name))
                .FilterDateTime(u => u.InsertedDateTime, param.InsertedDateTimeMin, param.InsertedDateTimeMax);
        }

        public void Export()
        {
            throw new System.NotImplementedException();
        }

        public void Enable(List<string> ids)
        {
            Enable(ids, true);
        }

        private void Enable(IEnumerable<string> ids, bool isEnabled)
        {
            UnitOfWork.Start();
            List<User> entities = Repository.Find(ids);
            entities.ForEach(entity => entity.IsEnabled = isEnabled);
            UnitOfWork.Commit();
            WriteLog(GetCaption(isEnabled), entities);
        }

        private string GetCaption(bool isEnabled)
        {
            return $"{(isEnabled ? Util.Resources.EntityBase.IsEnabledTrue : Util.Resources.EntityBase.IsEnabledFalse)} {Universal.Resources.Module.User}";
        }

        public void Disable(List<string> ids)
        {
            Enable(ids, false);
        }
    }
}