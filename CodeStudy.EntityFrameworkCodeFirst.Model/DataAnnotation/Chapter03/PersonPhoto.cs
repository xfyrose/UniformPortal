using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeStudy.EntityFrameworkCodeFirst.Model.DataAnnotation.Chapter03
{
    public class PersonPhoto
    {
        [Key, ForeignKey("PhotoOf")]
        public int PersonId { get; set; }

        public byte[] Photo { get; set; }
        public string Caption { get; set; }

        public Person PhotoOf { get; set; }
    }
}