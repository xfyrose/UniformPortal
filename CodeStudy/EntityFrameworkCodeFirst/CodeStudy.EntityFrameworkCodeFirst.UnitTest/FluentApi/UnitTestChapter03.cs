using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CodeStudy.EntityFrameworkCodeFirst.DataAccess.FluentApi.Chapter03;
using CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter03;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeStudy.EntityFrameworkCodeFirst.UnitTest.FluentApi
{
    /// <summary>
    /// Summary description for UnitTestChapter03
    /// </summary>
    [TestClass]
    public class UnitTestChapter03
    {
        public UnitTestChapter03()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

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

            using (BreakAwayContext context = new BreakAwayContext())
            {
                Destination destination = context.Destinations.FirstOrDefault();
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                Person person = context.People.FirstOrDefault();
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod3()
        {
            //int destinationId;
            //using (BreakAwayContext context = new BreakAwayContext())
            //{
            //    Destination destination = new Destination
            //    {
            //        Name = "Sample Destination",
            //        Lodgings = new List<Lodging>
            //        {
            //            new Lodging {Name = "Lodging One"},
            //            new Lodging {Name = "Lodging Two"}
            //        }
            //    };

            //    context.Destinations.Add(destination);
            //    context.SaveChanges();
            //    destinationId = destination.DestinationId;
            //}

            //using (BreakAwayContext context = new BreakAwayContext())
            //{
            //    var destination = context.Destinations
            //        .Include("Lodgings")
            //        .Single(d => d.DestinationId == destinationId);

            //    Lodging aLodging = destination.Lodgings.FirstOrDefault();
            //    context.Destinations.Remove(destination);

            //    Console.WriteLine("State of one Lodging: {0}", context.Entry(aLodging).State.ToString());
            //    context.SaveChanges();
            //}
        }

        [TestMethod]
        public void TestMethod4()
        {
            //int destinationId;
            using (BreakAwayContext context = new BreakAwayContext())
            {
                //Destination destination = new Destination
                //{
                //    Name = "Sample Destination",
                //    Lodgings = new List<Lodging>
                //    {
                //        new Lodging {Name = "Lodging One"},
                //        new Lodging {Name = "Lodging Two"}
                //    }
                //};

                //context.Destinations.Add(destination);
                //context.SaveChanges();
                //destinationId = destination.DestinationId;
            }

            using (BreakAwayContext context = new BreakAwayContext())
            {
                //var destination = context.Destinations.Single(d => d.DestinationId == destinationId);

                //context.Destinations.Remove(destination);
                //context.SaveChanges();
            }

            using (BreakAwayContext context = new BreakAwayContext())
            {
                //List<Lodging> lodgings = context.Lodgings.Where(l => l.DestinationId == destinationId).ToList();

                //Console.WriteLine("Lodgings: {0}", lodgings.Count);
            }
        }


        [TestMethod]
        public void TestMethod5()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                Activity activity = context.Activities.FirstOrDefault();
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod6()
        {
            //
            // TODO: Add test logic here
            //

            using (BreakAwayContext context = new BreakAwayContext())
            {
                Person person = new Person
                {
                    FirstName = "Rowan",
                    LastName = "Miller",
                    SocialSecurityNumber = 12345678,
                    //Photo = new PersonPhoto { Photo = new byte[] { 0 } }
                };

                context.People.Add(person);
                context.SaveChanges();
            }
        }

    }
}
