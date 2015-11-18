using System;

namespace CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter03
{
    public class InternetSpecial
    {
        public int InternetSpecialId { get; set; }
        public int Nights { get; set; }
        public decimal CostUsd { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime EndDate { get; set; }

        //[ForeignKey("Accommodation")]
        public int AccommodationId { get; set; }

        public Lodging Accommodation { get; set; }
    }
}