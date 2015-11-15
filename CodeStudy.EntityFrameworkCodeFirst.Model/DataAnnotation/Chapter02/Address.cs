using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeStudy.EntityFrameworkCodeFirst.Model.DataAnnotation.Chapter02
{
    [ComplexType]
    public class Address
    {
        public int AddressId { get; set; }

        [MaxLength(500)]
        public string StreetAddress { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}