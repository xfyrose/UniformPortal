using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CodeStudy.EntityFrameworkCodeFirst.DataAccess.DataAnnotation.Chapter05;
using CodeStudy.EntityFrameworkCodeFirst.Model.DataAnnotation.Chapter05;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeStudy.EntityFrameworkCodeFirst.UnitTest.DataAnnotation
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
                Destination destination = context.Destinations.FirstOrDefault();
                context.SaveChanges();

            }
        }

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
    }
}
