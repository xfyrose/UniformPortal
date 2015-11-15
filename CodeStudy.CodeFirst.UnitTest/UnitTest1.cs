using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CodeStudy.EntityFrameworkCodeFirst.Model;
using CodeStudy.EntityFrameworkCodeFirst.DataAccess;
using CodeStudy.EntityFrameworkCodeFirst.DataAccess.Migrations;

namespace CodeStudy.EntityFrameworkCodeFirst.UnitTestBreakAway
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_BreakAway()
        {
            using (var context = new BreakAwayContext())
            {
                var destination2 = context.Destinations;
                Console.WriteLine();
            } 
            
            Console.WriteLine("Success");
        }

        [TestMethod]
        public void TestMethod_Patient()
        {
            //AnimalType dog = new AnimalType() { TypeName = "Dog" };

            //Patient patient = new Patient
            //{
            //    Name = "Sampson",
            //    BirthDate = new DateTime(2008, 1, 28),
            //    AnimalType = dog,
            //    Visits = new List<Visit>()
            //    {
            //        new Visit()
            //        {
            //            Date = new DateTime(2011, 9, 1)
            //        },
            //        new Visit()
            //        {
            //            Date = new DateTime(2011, 9, 2)
            //        }
            //    },
            //    FirstVisit = new DateTime(2008, 1, 29)
            //};

            //using (VetContext context = new VetContext())
            //{
            //    context.Patients.Add(patient);
            //    context.SaveChanges();
            //}

            Console.WriteLine("Start...");

            using (VetContext context = new VetContext())
            {
                var patient = context.Patients.Include(p => p.Visits).FirstOrDefault();
                if (patient != null)
                {
                    Console.WriteLine("patient id:" + patient.Id);
                    Console.WriteLine("Visits count:" + patient.Visits.Count.ToString());

                    var visis = context.Visits.Count(v => v.PatientId == patient.Id);
                    Console.WriteLine("Visits count2:" + patient.Visits.Count.ToString());
                }
            }

            Console.WriteLine("Success");


        }

        [TestMethod]
        public void TestMethod_Blog()
        {
            using (var db = new BlogContext())
            {
                db.Blogs.Add(new Blog { Name = "Another Blog " });
                db.SaveChanges();

                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine(blog.Name);
                }
            }

            Console.WriteLine("Press any key to exit...");             
        }
    }
}
