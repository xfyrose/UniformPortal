using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter03
{
    public class Trip
    {
        [Key]
        public Guid Identifier { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal CostUsd { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public List<Activity> Activities { get; set; }
    }
}