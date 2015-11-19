using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.EntityFrameworkDbContext.Model.FluentApi.Chapter02
{
    public class Person
    {
        public Person()
        {
        }

        public int PersonId { get; set; }
        public int SocialSecurityNumber { get; set; }
        public string FirstName { get; set; }
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
        public PersonPhoto Photo { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
