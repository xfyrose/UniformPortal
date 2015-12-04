using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Threading;
using Util.Core.DataAnnotationsTemplates;

namespace Util.Core.Tests.DataAnnotationsTemplates
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
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

        #endregion Additional test attributes

        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Add test logic here
            //

            PropertyInfo[] properties = typeof(Person).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                DescriptionLocalizedAttribute attrDescription = property.GetCustomAttribute<DescriptionLocalizedAttribute>();
                Console.WriteLine("{0}:{1}", property.Name, attrDescription?.Description ?? "string.Empty");
            }

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            foreach (PropertyInfo property in properties)
            {
                DescriptionLocalizedAttribute attrDescription = property.GetCustomAttribute<DescriptionLocalizedAttribute>();
                Console.WriteLine("{0}:{1}", property.Name, attrDescription?.Description ?? "string.Empty");
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assembly asm = this.GetType().Assembly;

            // Enumerate the assembly's manifest resources
            foreach (string resourceName in asm.GetManifestResourceNames())
            {
                Console.WriteLine(resourceName);
            }
        }
    }
}