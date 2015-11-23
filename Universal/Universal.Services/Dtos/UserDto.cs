using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Services;

namespace Universal.Services.Dtos
{
    [DataContract]
    public class UserDto : DtoBase
    {
        [StringLength(Util.Resources.Consts.UserNameLengthMax, ErrorMessageResourceType = typeof(Universal.Resources.User), ErrorMessageResourceName = nameof(Universal.Resources.User.ValidateNameLengthMax))]
        [Display(ResourceType = typeof(Universal.Resources.User), Name = nameof(Universal.Resources.User.Name))]
        [DataMember]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Util.Resources.EntityBase), Name = nameof(Util.Resources.EntityBase.Version))]
        [DataMember]
        public byte[] Version { get; set; }


    }
}