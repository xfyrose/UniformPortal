using System;
using System.ComponentModel.DataAnnotations;
using Util.Core;
using Util.Core.Logs;
using Util.Core.Validations;
using Util.Logs.Log4;

namespace Util.Domains
{
    public abstract class EntityBase<TKey> : DomainBase, IEntity<TKey>
    {
        protected EntityBase(TKey id)
        {
            Id = id;
            //Log = Util.Logs.Log4.Log.GetContextLog(this);
        }

        public virtual TKey Id { get; set; }
        public virtual TKey InsertedUserId { get; set; }
        public virtual string InsertedUserName { get; set; }
        public virtual DateTime? InsertedDateTime { get; set; }
        public virtual TKey UpdatedUserId { get; set; }
        public virtual string UpdatedUserName { get; set; }
        public virtual DateTime? UpdatedDateTime { get; set; }

        public virtual bool IsEnabled { get; set; }
        public virtual bool IsDeleted { get; set; }

        protected virtual ILog Log { get; set; } = Util.Logs.Log4.Log.GetContextLog(typeof(EntityBase<TKey>));

        public override bool Equals(object entity)
        {
            if (!(entity is EntityBase<TKey>))
            {
                return false;
            }

            return this == (EntityBase<TKey>) entity;
        }

        public override int GetHashCode()
        {
            return ReferenceEquals(Id, null) ? 0 : Id.GetHashCode();
        }

        public static bool operator ==(EntityBase<TKey> entity1, EntityBase<TKey> entity2)
        {
            if (((object)entity1 == null) && ((object)entity2 == null))
            {
                return true;
            }

            if ((object)entity1 == null || ((object)entity2 == null))
            {
                return false;
            }

            if (entity1.Id.Equals(default(TKey)))
            {
                return false;
            }


            return entity1.Id.Equals(entity2.Id);
        }

        public static bool operator !=(EntityBase<TKey> entity1, EntityBase<TKey> entity2)
        {
            return !(entity1 == entity2);
        }

        public virtual void Init()
        {
            if (Id.Equals(default(TKey)))
            {
                Id = CreateId();
            }
        }

        public virtual TKey CreateId()
        {
            return Conv.To<TKey>(Guid.NewGuid());
        }

        protected override void Validate(ValidationResultCollection results)
        {
            if (Equals(Id, default(TKey)))
            {
                results.Add(new ValidationResult("Id不能为空"));
            }

            base.Validate();
        }

        protected override void AddDescriptions()
        {
            base.AddDescriptions();

            AddDescription(nameof(Id), Id);
            AddDescription(nameof(InsertedUserId), InsertedUserId);
            AddDescription(nameof(InsertedUserName), InsertedUserName);
            AddDescription(nameof(InsertedDateTime), InsertedDateTime?.ToMillisecondString());
            AddDescription(nameof(UpdatedUserId), UpdatedUserId);
            AddDescription(nameof(UpdatedUserName), UpdatedUserName);
            AddDescription(nameof(UpdatedDateTime), UpdatedDateTime?.ToMillisecondString());
            AddDescription(nameof(IsEnabled), IsEnabled);
            AddDescription(nameof(IsDeleted), IsDeleted);
        }
    }

    public abstract class EntityBase : EntityBase<Guid>
    {
        protected EntityBase(Guid id)
            : base(id)
        {
        }
    }
}