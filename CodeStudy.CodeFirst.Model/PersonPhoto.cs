using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace CodeStudy.EntityFrameworkCodeFirst.Model
{
    [Table("Person")]
    public class PersonPhoto
    {
        [Key, ForeignKey("PhotoOf")]
        public int PersonId { get; set; }
        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }
        public string Caption { get; set; }

        [Required]
        public Person PhotoOf { get; set; }
    }
}
