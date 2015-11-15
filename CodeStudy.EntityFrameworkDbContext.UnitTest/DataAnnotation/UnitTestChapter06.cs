using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using CodeStudy.EntityFrameworkDbContext.DataAccess.DataAnnotation.Chapter02;
using CodeStudy.EntityFrameworkDbContext.Model.DataAnnotation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeStudy.EntityFrameworkDbContext.UnitTest.DataAnnotation
{
    /// <summary>
    /// Summary description for UnitTestChapter06
    /// </summary>
    [TestClass]
    public class UnitTestChapter06
    {
        public UnitTestChapter06()
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
        }

        [TestMethod]
        public void TestMethod_ValidateNewPerson()
        {
            Person person = new Person
            {
                FirstName = "Julie",
                LastName = "Lerman000000000000",
                Photo = new PersonPhoto {Photo = new byte[] {0}}
            };

            using (BreakAwayContext context = new BreakAwayContext())
            {
                if (context.Entry(person).GetValidationResult().IsValid)
                {
                    Console.WriteLine("Person is Valid");
                }
                else
                {
                    Console.WriteLine("Person is Invalid");
                }
            }
        }

        [TestMethod]
        public void TestMethod_ValidateNewPerson2()
        {
            Person person = new Person
            {
                FirstName = "Julie",
                LastName = "Lerman000000000000",
                Photo = new PersonPhoto { Photo = new byte[] { 0 } }
            };

            using (BreakAwayContext context = new BreakAwayContext())
            {
                DbEntityValidationResult result = context.Entry(person).GetValidationResult();
                if (!result.IsValid)
                {
                    result.ValidationErrors.ToList().ForEach(error => Console.WriteLine(error.ErrorMessage));
                }
            }
        }

        [TestMethod]
        public void TestMethod_ValidatePropertyOnDemand()
        {
            Trip trip = new Trip
            {
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                CostUsd = 500.00M,
                Description = "Hope you won't be freezing"
            };

            using (BreakAwayContext context = new BreakAwayContext())
            {
                ICollection<DbValidationError> errors = context.Entry(trip).Property(t => t.Description).GetValidationErrors();
                errors.ToList().ForEach(error => Console.WriteLine(error.ErrorMessage));
            }
        }

        [TestMethod]
        public void TestMethod_ValidateTrip()
        {
            Trip trip = new Trip
            {
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                CostUsd = 500.00M,
                Description = "Hope you won't be freezing"
            };

            using (BreakAwayContext context = new BreakAwayContext())
            {
                DbEntityValidationResult result = context.Entry(trip).GetValidationResult();
                if (!result.IsValid)
                {
                    result.ValidationErrors.ToList().ForEach(error => Console.WriteLine(error.ErrorMessage));
                }
            }
        }
    }
}
