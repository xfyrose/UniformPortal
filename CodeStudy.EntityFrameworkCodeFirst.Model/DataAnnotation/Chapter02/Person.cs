using System.ComponentModel.DataAnnotations;

namespace CodeStudy.EntityFrameworkCodeFirst.Model.DataAnnotation.Chapter02
{
    public class Person
    {
        public Person()
        {
            Address = new Address();
            Info = new PersonalInfo
            {
                Weight = new Measurement(),
                Height = new Measurement()
            };
        }

        public int PersonId { get; set; }

        [ConcurrencyCheck]
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SocialSecurityNumber { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Address Address { get; set; }
        public PersonalInfo Info { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}