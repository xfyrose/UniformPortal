using System.Collections.Generic;

namespace CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter03
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public List<Trip> Trips { get; set; }
    }
}