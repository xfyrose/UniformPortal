using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using CodeStudy.EntityFrameworkDbContext.DataAccess.DataAnnotation.Chapter02;
using CodeStudy.EntityFrameworkDbContext.Model.DataAnnotation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeStudy.EntityFrameworkDbContext.UnitTest.DataAnnotation
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
        }

        [TestMethod]
        public void TestMethod_AddMachuPicchu()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                Destination machuPicchu = new Destination
                {
                    Name = "Machu Picchu",
                    Country = "Peru"
                };

                context.Destinations.Add(machuPicchu);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_ChangeGrandCanyon()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                var canyon = (from d in context.Destinations
                    where d.Name == "Grand Canyon"
                    select d).Single();

                canyon.Description = "227 mile long canyon";

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_DeleteWineGlassBay()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                var canyon = (from d in context.Destinations
                              where d.Name == "Wine Glass Bay"
                              select d).Single();

                context.Destinations.Remove(canyon);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_DeleteWineGlassBay2()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                Destination toDelete = new Destination {DestinationId = 1};

                context.Destinations.Attach(toDelete);
                context.Destinations.Remove(toDelete);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_DeleteWineGlassBay3()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                Destination toDelete = new Destination { DestinationId = 2 };
                context.Destinations.Attach(toDelete);
                context.Destinations.Attach(toDelete);

                context.Destinations.Remove(toDelete);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_DeleteTrip()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                var trip = (from t in context.Trips
                    where t.Description == "Trip from the database"
                    select t).Single();

                var res = (from r in context.Reservations
                    where r.Trip.Description == "Trip from the database"
                    select r).Single();

                context.Trips.Remove(trip);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_DeleteGrandCanyon()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                var canyon = (from d in context.Destinations
                    where d.Name == "Grand Canyon"
                    select d).Single();

                context.Entry(canyon)
                    .Collection(d => d.Lodgings)
                    .Load();

                context.Destinations.Remove(canyon);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_MakeMultipleChanges()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                Destination niagaraFalls = new Destination
                {
                    Name = "Niafara Falls",
                    Country = "USA"
                };

                context.Destinations.Add(niagaraFalls);

                Destination wineGlassBay = (from d in context.Destinations
                    where d.Name == "Wine Glass Bay"
                    select d).Single();

                wineGlassBay.Description = "Picturesque bay with beaches";

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_FindOrAddPerson()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                var ssn = 12345679;

                Person person = context.People.Find(ssn)
                             ?? context.People.Add(new Person
                             {
                                 SocialSecurityNumber = ssn,
                                 FirstName = "<enter first name>",
                                 LastName = "<enter last name>"
                             });

                Console.WriteLine(person.FirstName);

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_NewGrandCanyonResort()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                Resort resort = new Resort
                {
                    Name = "Pete's Luxury Resort"
                };


                var canyon = (from d in context.Destinations
                    where d.Name == "Grand Canyon"
                    select d).Single();

                //canyon.Lodgings.Add(resort);
                //resort.Destination = canyon;
                //resort.DestinationId = canyon.DestinationId;
                context.Lodgings.Add(resort);

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_ChangeLodgingDestination()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                Lodging hotel = (from l in context.Lodgings
                    where l.Name == "Grand Hotel"
                    select l).Single();

                Destination reef = (from d in context.Destinations
                    where d.Name == "Great Barrier Reef"
                    select d).Single();

                //hotel.Destination = reef;

                reef.Lodgings.Add(hotel);


                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_RemovePrimaryContact()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                var davesDump = (from l in context.Lodgings
                    where l.Name == "Dave's Dump"
                    select l).Single();

                //context.Entry(davesDump)
                //    .Reference(l => l.PrimaryContact)
                //    .Load();

                davesDump.PrimaryContact = null;
                //davesDump.PrimaryContactId = null;

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_ManualDetectChanges()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;

                var reef = (from d in context.Destinations
                    where d.Name == "Great Barrier Reef"
                    select d).Single();

                reef.Description = "The world's largest reef.";

                Console.WriteLine("Before DetectChanges: {0}", context.Entry(reef).State);

                context.ChangeTracker.DetectChanges();
                //context.SaveChanges();

                Console.WriteLine("After DetectChanges: {0}", context.Entry(reef).State);
            }
        }

        [TestMethod]
        public void TestMethod_AddMultipleDestinations()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;

                context.Destinations.Add(new Destination
                {
                    Name = "Paris",
                    Country = "France"
                });

                context.Destinations.Add(new Destination
                {
                    Name = "Grindelwald",
                    Country = "Switzerland"
                });

                context.Destinations.Add(new Destination
                {
                    Name = "Crete",
                    Country = "Greece"
                });


                //context.ChangeTracker.DetectChanges();
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethdo_DetectRelationShipChanges()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;

                var hawaii = (from d in context.Destinations
                    where d.Name == "Hawaii"
                    select d).Single();

                var davesDump = (from l in context.Lodgings
                    where l.Name == "Dave's Dump"
                    select l).Single();

                context.Entry(davesDump)
                    .Reference(l => l.Destination)
                    .Load();

                hawaii.Lodgings.Add(davesDump);

                Console.WriteLine("Before DetectChanges: {0}", davesDump.Destination.Name);

                context.ChangeTracker.DetectChanges();
                context.SaveChanges();

                Console.WriteLine("After DetectChanges: {0}", davesDump.Destination.Name);
            }
        }

        [TestMethod]
        public void TestMethod_ChangeTrackingProxy()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                //context.Configuration.AutoDetectChangesEnabled = false;

                var destinationCreate = context.Destinations.Create();
                var lodgingCreate = context.Lodgings.Create();

                var isProxyDestinationCreate = destinationCreate is IEntityWithChangeTracker;
                var isProxyLodgingCreate = lodgingCreate is IEntityWithChangeTracker;

                Console.WriteLine("Destination is proxy: {0}", isProxyDestinationCreate);
                Console.WriteLine("Lodging is proxy: {0}", isProxyLodgingCreate);

                var destinationFirst = context.Destinations.First();
                var lodgingFirst = context.Lodgings.First();

                var isProxyDestinationFirst = destinationFirst is IEntityWithChangeTracker;
                var isProxyLodgingFirst = lodgingFirst is IEntityWithChangeTracker;

                Console.WriteLine("Destination is proxy: {0}", isProxyDestinationFirst);
                Console.WriteLine("Lodging is proxy: {0}", isProxyLodgingFirst);
            }
        }

        [TestMethod]
        public void TestMethod_CreatingNewProxies()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;

                var nonProxy = new Destination
                {
                    Name = "Non-Proxy Destination",
                    Lodgings = new List<Lodging>()
                };

                var proxy = context.Destinations.Create();
                proxy.Name = "Proxy Destination";

                Console.WriteLine("nonProxy is IEntityWithChangeTracker: {0}", nonProxy is IEntityWithChangeTracker);
                Console.WriteLine("proxy is IEntityWithChangeTracker: {0}", proxy is IEntityWithChangeTracker);

                context.Destinations.Add(nonProxy);
                context.Destinations.Add(proxy);

                var davesDump = (from l in context.Lodgings
                    where l.Name == "Dave's Dump"
                    select l).Single();

                context.Entry(davesDump)
                    .Reference(l => l.Destination)
                    .Load();

                //context.ChangeTracker.DetectChanges();

                Console.WriteLine("Before Changes: {0}", davesDump.Destination.Name);

                nonProxy.Lodgings.Add(davesDump);

                Console.WriteLine("Added to non-proxy Changes: {0}", davesDump.Destination.Name);

                proxy.Lodgings.Add(davesDump);

                Console.WriteLine("Added to proxy Changes: {0}", davesDump.Destination.Name);
            }
        }
    }
}
