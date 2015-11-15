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
    public class Person
    {
        public Person()
        {
        }

        public int PersonId { get; set; }

        [ConcurrencyCheck]
        public int SocialSecurityNumber { get; set; }
        public string FirstName { get; set; }
        [MaxLength(10, ErrorMessage ="最大长度不可超过{1}")]
        public string LastName { get; set; }
        public Address Address { get; set; } = new Address();

        public PersonalInfo Info { get; set; } = new PersonalInfo
        {
            Weight = new Measurement(),
            Height = new Measurement()
        };

        public string FullName => FirstName + " " + LastName;

        public List<Lodging> PrimaryContactFor { get; set; } = new List<Lodging>();
        public List<Lodging> SecondaryContactFor { get; set; } = new List<Lodging>();
        [Required]
        public PersonPhoto Photo { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
