using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.EntityFrameworkDbContext.Model.FluentApi.Chapter02
{
    public class Lodging
    {
        public int LodgingId { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public decimal MilesFromNearestAirport { get; set; }

        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
        public List<InternetSpecial> InternetSpecials { get; set; } = new List<InternetSpecial>();
        public int? PrimaryContactId { get; set; }
        public Person PrimaryContact { get; set; }
        public int? SecondaryContactId { get; set; }
        public Person SecondaryContact { get; set; }
    }
}
