using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.EntityFrameworkDbContext.Model.FluentApi.Chapter02
{
    public class Trip
    {
        public Guid Identifier { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public decimal CostUsd { get; set; }
        public byte[] RowVersion { get; set; }

        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
        public List<Activity> Activities { get; set; } = new List<Activity>();
    }
}
