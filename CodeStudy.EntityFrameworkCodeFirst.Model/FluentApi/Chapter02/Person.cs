namespace CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter02
{
    public class Person
    {
        public Person()
        {
            Address = new Address();
        }

        public int PersonId { get; set; }

        public int SocialSecurityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Address Address { get; set; }

        //public byte[] RowVersion { get; set; }
    }
}