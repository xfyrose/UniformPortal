namespace CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter05
{
    public class Person
    {
        public int PersonId { get; set; }

        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SocialSecurityNumber { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        //[Required]
        public PersonPhoto Photo { get; set; }
    }
}