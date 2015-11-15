using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.EntityFrameworkCodeFirst.Model
{
    public class Visit
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ReasonForVisit { get; set; }
        public string Outcome { get; set; }
        public Decimal Weight { get; set; }
        public int PatientId { get; set; }
    }
}
