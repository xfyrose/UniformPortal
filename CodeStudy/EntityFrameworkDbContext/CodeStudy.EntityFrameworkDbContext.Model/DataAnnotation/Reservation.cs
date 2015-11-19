using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.EntityFrameworkDbContext.Model.DataAnnotation
{
    public class Reservation
    {
        public Reservation()
        {
        }

        public int ReservationId { get; set; }
        public virtual DateTime DateTimeMade { get; set; }
        public Person Traveler { get; set; }
        public virtual Trip Trip { get; set; }
        public virtual DateTime? PaidInFull { get; set; }

        public List<Payment> Payments { get; set; } = new List<Payment>();
    }
}
