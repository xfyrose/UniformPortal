using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CodeStudy.EntityFrameworkCodeFirst.DataAccess.DataAnnotation.Chapter02;
using CodeStudy.EntityFrameworkCodeFirst.Model.DataAnnotation.Chapter02;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeStudy.EntityFrameworkCodeFirst.UnitTest.DataAnnotation
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTestChapter02
    {
        public UnitTestChapter02()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Add test logic here
            //

            Destination destination = new Destination
            {
                Country = "Indonesia",
                Description = "EcoTourism at its best in exquisite Bali",
                Name = "Bali"
            };

            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Destinations.Add(destination);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            Trip trip = new Trip
            {
                CostUsd = 800,
                StartDate = new DateTime(2011, 9, 1),
                EndDate = new DateTime(2011, 9, 14)
            };

            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Trips.Add(trip);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod3()
        {
            Person person = new Person
            {
                FirstName = "Rowan",
                LastName = "Miller",
                SocialSecurityNumber = 12345678
            };

            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.People.Add(person);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod4()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                Trip trip = context.Trips.FirstOrDefault();
                trip.CostUsd = 750;
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod5()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                Person person = context.People.FirstOrDefault();
                person.FirstName = "Rowena";
                context.SaveChanges();
            }
        }
    }
}
