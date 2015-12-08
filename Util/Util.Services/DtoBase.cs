using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Util.Services
{
    [DataContract]
    public class DtoBase : IDto
    {
        [DataMember]
        public string Id { get; set; }

        [StringLength(Util.Resources.Consts.UserIdLengthMax, ErrorMessageResourceType = typeof(Util.Resources.EntityBase), ErrorMessageResourceName = nameof(Util.Resources.EntityBase.ValidateInsertedUserIdStringLengthMax))]
        [Display(ResourceType = typeof(Util.Resources.EntityBase), Name = nameof(Util.Resources.EntityBase.InsertedUserId))]
        [DataMember]
        public string InsertedUserId { get; set; }

        [StringLength(Util.Resources.Consts.UserNameLengthMax, ErrorMessageResourceType = typeof(Util.Resources.EntityBase), ErrorMessageResourceName = nameof(Util.Resources.EntityBase.ValidateInsertedUserNameStringLengthMax))]
        [Display(ResourceType = typeof(Util.Resources.EntityBase), Name = nameof(Util.Resources.EntityBase.InsertedUserName))]
        [DataMember]
        public string InsertedUserName { get; set; }

        [Display(ResourceType = typeof(Util.Resources.EntityBase), Name = nameof(Util.Resources.EntityBase.InsertedDateTime))]
        [DataMember]
        public DateTime? InsertedDateTime { get; set; }

        [StringLength(Util.Resources.Consts.UserIdLengthMax, ErrorMessageResourceType = typeof(Util.Resources.EntityBase), ErrorMessageResourceName = nameof(Util.Resources.EntityBase.ValidateUpdatedUserIdStringLengthMax))]
        [Display(ResourceType = typeof(Util.Resources.EntityBase), Name = nameof(Util.Resources.EntityBase.UpdatedUserId))]
        [DataMember]
        public string UpdatedUserId { get; set; }

        [StringLength(Util.Resources.Consts.UserNameLengthMax, ErrorMessageResourceType = typeof(Util.Resources.EntityBase), ErrorMessageResourceName = nameof(Util.Resources.EntityBase.ValidateUpdatedUserNameStringLengthMax))]
        [Display(ResourceType = typeof(Util.Resources.EntityBase), Name = nameof(Util.Resources.EntityBase.UpdatedUserName))]
        [DataMember]
        public string UpdatedUserName { get; set; }

        [Display(ResourceType = typeof(Util.Resources.EntityBase), Name = nameof(Util.Resources.EntityBase.UpdatedDateTime))]
        [DataMember]
        public DateTime? UpdatedDateTime { get; set; }

        [Display(ResourceType = typeof(Util.Resources.EntityBase), Name = nameof(Util.Resources.EntityBase.IsEnabled))]
        [DataMember]
        public bool IsEnabled { get; set; }

        [Display(ResourceType = typeof(Util.Resources.EntityBase), Name = nameof(Util.Resources.EntityBase.IsDeleted))]
        [DataMember]
        public bool IsDeleted { get; set; }
    }
}