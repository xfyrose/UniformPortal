using System;
using System.ComponentModel.DataAnnotations;
using Util.Core;
using Util.Core.Extensions;

namespace Util.Domains.Repositories
{
    public class EntityBaseQuery<TKey> : Pager
    {
        [Display(ResourceType = typeof(Util.Resources.EntityBase), Name = nameof(Util.Resources.EntityBase.InsertedUserId))]
        public TKey InsertedUserId { get; set; }
        [Display(ResourceType = typeof(Util.Resources.EntityBase), Name = nameof(Util.Resources.EntityBase.InsertedUserName))]
        public string InsertedUserName { get; set; }

        [Display(ResourceType = typeof(Util.Resources.EntityBase), Name = nameof(Util.Resources.EntityBase.InsertedDateTimeMin))]
        public DateTime? InsertedDateTimeMin { get; set; }
        [Display(ResourceType = typeof(Util.Resources.EntityBase), Name = nameof(Util.Resources.EntityBase.InsertedDateTimeMax))]
        public DateTime? InsertedDateTimeMax { get; set; }

        [Display(ResourceType = typeof(Util.Resources.EntityBase), Name = nameof(Util.Resources.EntityBase.UpdatedUserId))]
        public TKey UpdatedUserId { get; set; }
        [Display(ResourceType = typeof(Util.Resources.EntityBase), Name = nameof(Util.Resources.EntityBase.UpdatedUserName))]
        public string UpdatedUserName { get; set; }

        [Display(ResourceType = typeof(Util.Resources.EntityBase), Name = nameof(Util.Resources.EntityBase.UpdatedDateTimeMin))]
        public DateTime? UpdatedDateTimeMin { get; set; }
        [Display(ResourceType = typeof(Util.Resources.EntityBase), Name = nameof(Util.Resources.EntityBase.UpdatedDateTimeMax))]
        public DateTime? UpdatedDateTimeMax { get; set; }

        [Display(ResourceType = typeof(Util.Resources.EntityBase), Name = nameof(Util.Resources.EntityBase.IsEnabled))]
        public bool? IsEnabled { get; set; }
        [Display(ResourceType = typeof(Util.Resources.EntityBase), Name = nameof(Util.Resources.EntityBase.IsDeleted))]
        public bool? IsDeleted { get; set; }

        protected override void AddDescriptions()
        {
            base.AddDescriptions();

            AddDescription(nameof(InsertedUserId), InsertedUserId);
            AddDescription(nameof(InsertedUserName), InsertedUserName);

            AddDescription(nameof(InsertedDateTimeMin), InsertedDateTimeMin?.ToMillisecondString() ?? string.Empty);
            AddDescription(nameof(InsertedDateTimeMax), InsertedDateTimeMax?.ToMillisecondString() ?? string.Empty);

            AddDescription(nameof(UpdatedUserId), UpdatedUserId);
            AddDescription(nameof(UpdatedUserName), UpdatedUserName);

            AddDescription(nameof(UpdatedDateTimeMin), UpdatedDateTimeMin?.ToMillisecondString() ?? string.Empty);
            AddDescription(nameof(UpdatedDateTimeMax), UpdatedDateTimeMax?.ToMillisecondString() ?? string.Empty);

            AddDescription(nameof(IsEnabled), IsEnabled);
            AddDescription(nameof(IsDeleted), IsDeleted);
        }
    }

    public class EntityBaseQuery : EntityBaseQuery<Guid>
    {
        
    }
}