using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.EntityFrameworkDbContext.Model.FluentApi.Chapter02
{
    public class Payment
    {
        public Payment()
        {
        }

        public int PaymentId { get; set; }
        public int ReservationId { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
    }
}
