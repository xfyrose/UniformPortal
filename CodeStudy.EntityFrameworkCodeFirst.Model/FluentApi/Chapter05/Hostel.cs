namespace CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter05
{
    public class Hostel : Lodging
    {
        public int MaxPersonsPerRoom { get; set; }
        public bool PrivateRoomsAvailable { get; set; }
    }
}