using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeStudy.Misc.ValidationContexts
{
    /// <summary>
    /// Summary description for UnitTestValidationContext
    /// </summary>
    [TestClass]
    public class UnitTestValidationContext
    {
        public UnitTestValidationContext()
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
        [TestInitialize()]
        public void MyTestInitialize()
        {
            TypeDescriptor.AddProviderTransparent(
                new AssociatedMetadataTypeTypeDescriptionProvider(typeof(ValidateMeDto), typeof(ValidateMeMetaData)),
                typeof(ValidateMeDto));
        }
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

            ValidateMe toValidate1 = new ValidateMe
            {
                Enable = true,
                Prop1 = 1,
                Prop2 = 6,
                MeName = "01234567890123456789"
            };

            //true，属性验证false将阻止 IValidatableObject.Validate验证
            //false + 非 IValidatableObject，不验证
            //false + IValidatableObject，则有的属性 + IValidatableObject.Validate被验证。
            bool validateAllProperties = true; 

            List<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                toValidate1,
                new ValidationContext(toValidate1, null, null),
                results,
                validateAllProperties);
            Console.WriteLine("TryValidateObject toValidate1: {0}", isValid);
            results.ForEach(result =>
            {
                foreach (string name in result.MemberNames)
                {
                    Console.WriteLine("    {0}", name);
                }
                Console.WriteLine("ErrorMessage: {0}", result.ErrorMessage);
            });

            Console.WriteLine();

            results.Clear();
            isValid = Validator.TryValidateProperty(toValidate1.MeName,
                new ValidationContext(toValidate1, null, null) {MemberName = "MeName"},
                results);
            Console.WriteLine("TryValidateProperty toValidate1: {0}", isValid);
            results.ForEach(result =>
            {
                foreach (string name in result.MemberNames)
                {
                    Console.WriteLine("    {0}", name);
                }
                Console.WriteLine("ErrorMessage: {0}", result.ErrorMessage);
            });

            Console.WriteLine();

            results.Clear();
            isValid = Validator.TryValidateProperty(typeof(ValidateMe).GetProperty("Prop1").GetValue(toValidate1, null),
                new ValidationContext(toValidate1, null, null) { MemberName = "Prop1" },
                results);
            Console.WriteLine("TryValidateProperty toValidate1: {0}", isValid);
            results.ForEach(result =>
            {
                foreach (string name in result.MemberNames)
                {
                    Console.WriteLine("    {0}", name);
                }
                Console.WriteLine("ErrorMessage: {0}", result.ErrorMessage);
            });

            //Tuple
            //results.Clear();
            //isValid = Validator.TryValidateValue(toValidate1.MeName,
            //    new ValidationContext(toValidate1, null, null) { MemberName = "MeName" },
            //    results);
            //Console.WriteLine("toValidate1: {0}", isValid);
            //results.ForEach(result =>
            //{
            //    foreach (string name in result.MemberNames)
            //    {
            //        Console.WriteLine("    {0}", name);
            //    }
            //    Console.WriteLine("ErrorMessage: {0}", result.ErrorMessage);
            //});
        }

        [TestMethod]
        public void TestMethod2()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");

            bool validateAllProperties = true;
            List<ValidationResult> results = new List<ValidationResult>();

            ValidateMeDto toValidateDto1 = new ValidateMeDto
            {
                Prop1 = 0,
                //Prop2 = "100",
                MeName = "01234567890123456789",
                AnotherProp1 = 6
            };

            bool isValid = Validator.TryValidateObject(
                toValidateDto1,
                new ValidationContext(toValidateDto1, null, null),
                results,
                validateAllProperties);
            Console.WriteLine();
            Console.WriteLine("TryValidateObject toValidateDto1: {0}", isValid);
            results.ForEach(result =>
            {
                foreach (string name in result.MemberNames)
                {
                    Console.WriteLine("    {0}", name);
                }
                Console.WriteLine("ErrorMessage: {0}", result.ErrorMessage);
            });
        }
    }
}
