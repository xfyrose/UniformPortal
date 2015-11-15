using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CodeStudy.EntityFrameworkCodeFirst.Model
{
    public class Trip
    {
        public Guid Identifier { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal CostUsd { get; set; }
        //[Timestamp]
        public byte[] RowVersion { get; set; }

        public List<Activity> Activities { get; set; } 
    }
}
