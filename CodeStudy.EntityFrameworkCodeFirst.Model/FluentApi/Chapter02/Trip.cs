using System;
using System.ComponentModel.DataAnnotations;

namespace CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter02
{
    public class Trip
    {
        public Guid Identifier { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal CostUsd { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}