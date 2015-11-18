using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeStudy.EntityFrameworkCodeFirst.Model.DataAnnotation.Chapter03
{
    public class Person
    {
        public int PersonId { get; set; }

        [ConcurrencyCheck]
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SocialSecurityNumber { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Lodging> PrimaryContactFor { get; set; }
        public List<Lodging> SecondaryContactFor { get; set; }

        [Required]
        public PersonPhoto Photo { get; set; }
    }
}