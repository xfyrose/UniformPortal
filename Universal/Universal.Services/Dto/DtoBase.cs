using System.Runtime.Serialization;

namespace Universal.Services.Dto
{
    [DataContract]
    public class DtoBase : IDto
    {
        [DataMember]
        public string Id { get; set; }
    }
}