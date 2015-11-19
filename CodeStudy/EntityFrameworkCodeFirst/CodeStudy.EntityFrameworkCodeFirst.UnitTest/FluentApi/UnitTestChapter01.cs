using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CodeStudy.EntityFrameworkCodeFirst.DataAccess.FluentApi.Chapter01;
using CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter01;

namespace CodeStudy.EntityFrameworkCodeFirst.UnitTest.FluentApi
{
    [TestClass]
    public class UnitTestChapter01
    {
        [TestMethod]
        public void TestMethod1()
        {
            AnimalType dog = new AnimalType { TypeName = "Dog" };

            Patient patient = new Patient
            {
                Name = "Sampson",
                BirthDate = new DateTime(2008, 1, 28),
                AnimalType = dog,
                FirstVisit = new DateTime(2008, 1, 29),
                Visits = new List<Visit>
                {
                    new Visit
                    {
                        Date = new DateTime(2011, 9, 1)
                    }
                }
            };

            Console.WriteLine("Start...");
            using (VetContext context = new VetContext())
            {
                context.Patients.Add(patient);
                context.SaveChanges();
            }
            Console.WriteLine("Stop...");
        }
    }
}
