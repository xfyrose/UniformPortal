using System;

namespace CodeStudy.EntityFrameworkCodeFirst.Model.DataAnnotation.Chapter01
{
    public class Visit
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ReasonForVisit { get; set; }
        public string OutCome { get; set; }
        public decimal Weight { get; set; }
        public int PatientId { get; set; }
    }
}