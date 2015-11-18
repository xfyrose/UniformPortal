using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.EntityFrameworkDbContext.Model.DataAnnotation
{
    [Table("People")]
    public class PersonPhoto
    {
        [Key]
        [ForeignKey("PhotoOf")]
        public int PersonId { get; set; }
        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }
        public string Caption { get; set; }

        public Person PhotoOf { get; set; }
    }
}
