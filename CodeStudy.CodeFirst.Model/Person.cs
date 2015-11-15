using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CodeStudy.EntityFrameworkCodeFirst.Model
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [ConcurrencyCheck]
        public int SocialSecurityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [Required]
        public PersonPhoto Photo { get; set; }

        public Address Address { get; set; }
        public PersonalInfo Info { get; set; }

        public List<Lodging> PrimaryContactFor { get; set; }
        public List<Lodging> SecondaryContactFor { get; set; }
        //public List<Reservation> Reservations { get; set; } 

        public Person()
        {
            Address = new Address();
            Info = new PersonalInfo()
            {
                Weight = new Measurement(),
                Height = new Measurement()
            };
        }
    }
}
