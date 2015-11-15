using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeStudy.EntityFrameworkCodeFirst.Model.DataAnnotation.Chapter05
{
    [Table("People")]
    public class Person
    {
        public int PersonId { get; set; }

        [ConcurrencyCheck]
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SocialSecurityNumber { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        public PersonPhoto Photo { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}