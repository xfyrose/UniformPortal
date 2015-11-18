using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using CodeStudy.EntityFrameworkDbContext.DataAccess.DataAnnotation.Chapter02;
using CodeStudy.EntityFrameworkDbContext.Model.DataAnnotation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeStudy.EntityFrameworkDbContext.UnitTest.DataAnnotation
{
    /// <summary>
    /// Summary description for UnitTestOrder
    /// </summary>
    [TestClass]
    public class UnitTestOrder
    {
        public UnitTestOrder()
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
        }

        [TestMethod]
        public void TestMethod_InitialData()
        {
            using (OrderContext context = new OrderContext())
            {
                context.Orders.Add(new Model.DataAnnotation.Order
                {
                    OrderName = "order1",
                    OrderItems = new List<Model.DataAnnotation.OrderItem>
                    {
                        new Model.DataAnnotation.OrderItem { OrderItemId = 1, OrderItemName = "orderitemname_1_01" },
                        new Model.DataAnnotation.OrderItem { OrderItemId = 2, OrderItemName = "orderitemname_1_02" },
                        new Model.DataAnnotation.OrderItem { OrderItemId = 3, OrderItemName = "orderitemname_1_03" }
                    }
                });

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethdo_DeleteChildEntity()
        {
            using (OrderContext context = new OrderContext())
            {
                Order order = context.Orders.FirstOrDefault(o => o.OrderName == "order1");

                context.Entry(order).Collection(o => o.OrderItems).Load();

                OrderItem deleteOrderItem = order.OrderItems.FirstOrDefault(oi => oi.OrderItemName == "orderitemname_1_02");

                order.OrderItems.Remove(deleteOrderItem);

                Console.WriteLine(((IObjectContextAdapter) context).ObjectContext.Connection.State.ToString());
                context.SaveChanges();
                Console.WriteLine(((IObjectContextAdapter)context).ObjectContext.Connection.State.ToString());

                List<Order> orders = context.Orders.ToList();
                Console.WriteLine(((IObjectContextAdapter)context).ObjectContext.Connection.State.ToString());
            }
        }
    }
}
