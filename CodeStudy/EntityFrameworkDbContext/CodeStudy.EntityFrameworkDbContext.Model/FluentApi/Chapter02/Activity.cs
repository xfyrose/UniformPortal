using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.EntityFrameworkDbContext.Model.FluentApi.Chapter02
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public List<Trip> Trips { get; set; } = new List<Trip>();
    }
}
