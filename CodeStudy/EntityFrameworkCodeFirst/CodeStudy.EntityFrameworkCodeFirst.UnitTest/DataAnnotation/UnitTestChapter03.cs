using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CodeStudy.EntityFrameworkCodeFirst.DataAccess.DataAnnotation.Chapter03;
using CodeStudy.EntityFrameworkCodeFirst.Model.DataAnnotation.Chapter03;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable All

namespace CodeStudy.EntityFrameworkCodeFirst.UnitTest.DataAnnotation
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
                Person person = new Person
                {
                    FirstName = "Rowan",
                    LastName = "Miller",
                    SocialSecurityNumber = 12345678,
                    Photo = new PersonPhoto { Photo = new byte[] { 0 } }
                };

                context.People.Add(person);
                context.SaveChanges();
            }
        }
    }
}
