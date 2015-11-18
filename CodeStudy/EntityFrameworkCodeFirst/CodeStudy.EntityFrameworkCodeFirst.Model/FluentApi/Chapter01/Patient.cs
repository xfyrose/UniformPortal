using System;
using System.Collections.Generic;

namespace CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter01
{
    public class Patient
    {
        public Patient()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public AnimalType AnimalType { get; set; }
        public DateTime FirstVisit { get; set; }

        public List<Visit> Visits { get; set; }
    }
}