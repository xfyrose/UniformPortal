using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CodeStudy.EntityFrameworkDbContext.DataAccess.DataAnnotation.Chapter02;
using CodeStudy.EntityFrameworkDbContext.Model.DataAnnotation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeStudy.EntityFrameworkDbContext.UnitTest.DataAnnotation
{
    /// <summary>
    /// Summary description for UnitTestChapter02
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
        public void TestMethod_PrintAllDestinations()
        {
            //
            // TODO: Add test logic here
            //
            using (BreakAwayContext context = new BreakAwayContext())
            {
                foreach (Destination destination in context.Destinations)
                {
                    Console.WriteLine(destination.Name);
                }

                Console.WriteLine("Twice");
                foreach (Destination destination in context.Destinations)
                {
                    Console.WriteLine(destination.Name);
                }
            }
        }

        [TestMethod]
        public void TestMethod_PrintAllDestinationsTwice()
        {
            //
            // TODO: Add test logic here
            //
            using (BreakAwayContext context = new BreakAwayContext())
            {
                List<Destination> allDestinations = context.Destinations.ToList();

                foreach (Destination destination in allDestinations)
                {
                    Console.WriteLine(destination.Name);
                }

                Console.WriteLine("Twice");

                foreach (Destination destination in allDestinations)
                {
                    Console.WriteLine(destination.Name);
                }
            }
        }

        [TestMethod]
        public void TestMethod_PrintAllDestinationsSorted()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                IQueryable<Destination> query = from d in context.Destinations
                                                 orderby d.Name
                                                 select d;
                Console.WriteLine(query.ToString());
                query = context.Destinations.OrderBy(d => d.Name);

                foreach (Destination destination in query)
                {
                    Console.WriteLine(destination.Name);
                }

            }
        }

        [TestMethod]
        public void TestMethod_PrintAustralianDestinations()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                IQueryable<Destination> query = from d in context.Destinations
                                                where d.Country == "Australia"
                                                orderby d.Name
                                                select d;

                foreach (Destination destination in query)
                {
                    Console.WriteLine(destination.Name);
                }

            }
        }

        [TestMethod]
        public void TestMethod_PrintDestinationsNameOnly()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                IQueryable<string> query = from d in context.Destinations
                                                where d.Country == "Australia"
                                                orderby d.Name
                                                select d.Name;

                foreach (string name in query)
                {
                    Console.WriteLine(name);
                }

            }
        }

        [TestMethod]
        public void TestMethod_FindDestination()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                var destination = context.Destinations.Find(10);
                Console.WriteLine(destination == null ? "Not Found" : destination.Name);
            }
        }

        [TestMethod]
        public void TestMethod_FindGreatBarrierReef()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                IEnumerable<Destination> query = from d in context.Destinations
                                                 where d.Name == "Great Barrier Reef"
                                                 select d;

                Destination reef = query.Single();

                Console.WriteLine(reef == null ? "Not Find" : reef.Description);
            }

            using (BreakAwayContext context = new BreakAwayContext())
            {
                IQueryable<Destination> query = from d in context.Destinations
                                                 where d.Name == "Great Barrier Reef"
                                                 select d;

                Destination reef = query.Single();

                Console.WriteLine(reef == null ? "Not Find" : reef.Description);
            }
        }

        [TestMethod]
        public void TestMethod_GetLocalDestinationCount()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                var count = context.Destinations.Local.Count;
                Console.WriteLine("Destination in memory: {0}", count);

                var destination = context.Destinations.ToList();
                count = context.Destinations.Local.Count;
                Console.WriteLine("Destination in memory: {0}", count);
            }
        }

        [TestMethod]
        public void TestMethod_GetLocalDestinationCountWithLoad()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Destinations.Load();

                var count = context.Destinations.Local.Count;
                Console.WriteLine("Destination in memory: {0}", count);
            }
        }

        [TestMethod]
        public void TestMethod_LoadAustralianDestinations()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                var query = from d in context.Destinations
                            where d.Country == "Australia"
                            select d;

                query.Load();

                query = from d in context.Destinations
                            where d.Country == "USA"
                        select d;

                query.Load();

                var count = context.Destinations.Local.Count;
                Console.WriteLine("Destination in memory: {0}", count);
            }
        }

        [TestMethod]
        public void TestMethod_LocalLinqQueries()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Destinations.Load();

                var sortedDestinations = from d in context.Destinations.Local
                                         orderby d.Name
                                         select d;
                Console.WriteLine("All Destinations:");
                sortedDestinations.ToList().ForEach(d => Console.WriteLine(d.Name));

                var aussieDestinations = from d in context.Destinations.Local
                                         where d.Country == "Australia"
                                         select d;
                Console.WriteLine("Austrlian Destinations:");
                aussieDestinations.ToList().ForEach(d => Console.WriteLine(d.Name));
            }
        }

        [TestMethod]
        public void TestMethod_ListenLocalChanges()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Destinations.Local.CollectionChanged += (sender, args) =>
                {
                    if (args.NewItems != null)
                    {
                        foreach (Destination item in args.NewItems)
                        {
                            Console.WriteLine("Added: " + item.Name);
                        }
                    }

                    if (args.OldItems != null)
                    {
                        foreach (Destination item in args.OldItems)
                        {
                            Console.WriteLine("Removed: " + item.Name);
                        }
                    }
                };

                context.Destinations.Load();
            }
        }

        [TestMethod]
        public void TestMethod_TestLazyLoading()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                //context.Configuration.LazyLoadingEnabled = false;

                var query = from d in context.Destinations
                            where d.Name == "Grand Canyon"
                            select d;

                var canyon = query.SingleOrDefault();
                Console.WriteLine("Grand Canyon Lodging: ");
                if (canyon.Lodgings != null)
                {
                    foreach (Lodging lodging in canyon.Lodgings)
                    {
                        Console.WriteLine(lodging.Name);
                    }
                }
            }
        }

        [TestMethod]
        public void TestMethod_TestEagerLoading()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                var allDestinations = context
                    .Destinations
                    .Include(d => d.Lodgings);

                allDestinations.ToList().ForEach(d =>
                {
                    Console.WriteLine(d.Name);
                    d.Lodgings.ToList().ForEach(l => Console.WriteLine("-" + l.Name));
                });

            }
        }

        [TestMethod]
        public void TestMethod_TestEagerLoadingProblem()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                var query1 = context.Lodgings.Include(l => l.PrimaryContact.Photo);
                query1.Load();

                var query2 = context.Destinations.Include(d => d.Lodgings.Select(l => l.PrimaryContact));
                query2.Load();
            }
        }

        [TestMethod]
        public void TestMethod_TestExplicitLoading()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var query = from d in context.Destinations
                            where d.Name == "Grand Canyon"
                            select d;

                var canyon = query.Single();

                if (canyon.Lodgings == null)
                {
                    Console.WriteLine("Lodgings null");
                }

                context.Entry(canyon)
                    .Collection(d => d.Lodgings)
                    .Load();

                Console.WriteLine("Grand Canyon Lodging: ");
                canyon.Lodgings.ToList().ForEach(l => Console.WriteLine(l.Name));
            }
        }

        [TestMethod]
        public void TestMethod_TestIsLoaded()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                var query = from d in context.Destinations
                            where d.Name == "Grand Canyon"
                            select d;

                var canyon = query.Single();

                var entry = context.Entry(canyon);

                Console.WriteLine("Before Load: {0}", entry.Collection(d => d.Lodgings).IsLoaded);

                entry.Collection(d => d.Lodgings).Load();

                Console.WriteLine("After Load: {0}", entry.Collection(d => d.Lodgings).IsLoaded);
            }
        }

        [TestMethod]
        public void TestMethod_QueryLodgingDistance()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                var canyonQuery = from d in context.Destinations
                                  where d.Name == "Grand Canyon"
                                  select d;

                var canyon = canyonQuery.Single();

                var distanceQuery = from l in canyon.Lodgings
                                    where l.MilesFromNearestAirport <= 10
                                    select l;

                distanceQuery.ToList().ForEach(l => Console.WriteLine(l.Name));
            }
        }

        [TestMethod]
        public void TestMethod_QueryLodgingDistance2()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                var canyonQuery = from d in context.Destinations
                                  where d.Name == "Grand Canyon"
                                  select d;

                var canyon = canyonQuery.Single();

                var lodgingQuery = context.Entry(canyon)
                    .Collection(d => d.Lodgings)
                    .Query();

                var distanceQuery = from l in lodgingQuery
                                    where l.MilesFromNearestAirport <= 10
                                    select l;

                distanceQuery.ToList().ForEach(l => Console.WriteLine(l.Name));
            }
        }

        [TestMethod]
        public void TestMethod_QueryLodgingCount()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                var canyonQuery = from d in context.Destinations
                                  where d.Name == "Grand Canyon"
                                  select d;

                var canyon = canyonQuery.Single();

                var lodgingQuery = context.Entry(canyon)
                    .Collection(d => d.Lodgings)
                    .Query();

                var lodgingCount = lodgingQuery.Count();

                Console.WriteLine("Lodging at Gand Canyon: {0}", lodgingCount);
            }
        }

        [TestMethod]
        public void TestMethod_QueryLoad()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                var canyonQuery = from d in context.Destinations
                                  where d.Name == "Grand Canyon"
                                  select d;

                var canyon = canyonQuery.Single();

                context.Entry(canyon)
                    .Collection(d => d.Lodgings)
                    .Query()
                    .Where(l => l.Name.Contains("Hotel"))
                    .Load();

            }
        }
    }
}
