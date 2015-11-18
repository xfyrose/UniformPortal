using System;

namespace CodeStudy.EntityFrameworkCodeFirst.Model.DataAnnotation.Chapter05
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime DateTimeMade { get; set; }
        public Person Traveler { get; set; }
        public Trip Trip { get; set; }
        public DateTime PaidInFull { get; set; }
    }
}