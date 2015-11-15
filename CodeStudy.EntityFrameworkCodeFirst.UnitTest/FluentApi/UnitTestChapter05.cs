using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CodeStudy.EntityFrameworkCodeFirst.DataAccess.FluentApi.Chapter05;
using CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter05;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeStudy.EntityFrameworkCodeFirst.UnitTest.FluentApi
{
    /// <summary>
    /// Summary description for UnitTestChapter05
    /// </summary>
    [TestClass]
    public class UnitTestChapter05
    {
        public UnitTestChapter05()
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
                Person person = new Person
                {
                    FirstName = "One",
                    Photo = new PersonPhoto { Photo = new byte[] {0}}
                };
                context.People.Add(person);
                context.SaveChanges();

                Person person2 = context.People.FirstOrDefault();
                PersonPhoto personPhoto = context.PersonPhotoes.FirstOrDefault();
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
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

            using (BreakAwayContext context = new BreakAwayContext())
            {
                List<Destination> destinations = context.Destinations.ToList();
                Destination destination2 = destinations.FirstOrDefault();
                destination2.Description = "Trust us, you'll love it!";
                context.SaveChanges();
                context.Destinations.Remove(destination2);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod3()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                Destination destination = context.Destinations.FirstOrDefault();
                context.SaveChanges();
            }
        }

        #if false
        [TestMethod]
        public void TestMethod_InsertLodging()
        {
            Lodging lodging = new Lodging
            {
                Name = "Rainy Day Motel",
                Destination = new Destination
                {
                    Name = "Seattle, Washington",
                    Country = "USA"
                }
            };

            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Lodgings.Add(lodging);
                context.SaveChanges();
            }
        }
        #endif

        [TestMethod]
        public void TestMethod_InsertResort()
        {
            Resort resort = new Resort
            {
                Name = "Top Notch Resort and Spa",
                Activities = "Spa, Hiking, Skiing, Ballooning",
                Destination = new Destination
                {
                    Name = "Stoew, Vermont",
                    Country = "USA"
                }
            };

            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Lodgings.Add(resort);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_InsertAbstractBaseClass()
        {
            Resort resort = new Resort
            {
                Name = "Top Notch Resort and Spa",
                Activities = "Spa, Hiking, Skiing, Ballooning",
                Destination = new Destination
                {
                    Name = "Stowe, Vermont",
                    Country = "USA"
                }
            };

            Hostel hostel = new Hostel
            {
                Name = "AAA Budget Youth Hostel",
                PrivateRoomsAvailable = false,
                Destination = new Destination
                {
                    Name = "Hanksville, Vermont",
                    Country = "USA"
                }
            };

            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Lodgings.Add(resort);
                context.Lodgings.Add(hostel);
                context.SaveChanges();

                List<Lodging> lodgings = context.Lodgings.ToList();
                foreach (Lodging lodging in lodgings)
                {
                    Console.WriteLine("Name:{0} Type:{1}", lodging.Name, lodging.GetType());
                }
            }
        }
    }
}
