using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.Linq;
using CodeStudy.EntityFrameworkDbContext.DataAccess.DataAnnotation.Chapter02;
using CodeStudy.EntityFrameworkDbContext.Model.DataAnnotation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeStudy.EntityFrameworkDbContext.UnitTest.DataAnnotation
{
    /// <summary>
    /// Summary description for UnitTestChapter04
    /// </summary>
    [TestClass]
    public class UnitTestChapter04
    {
        public UnitTestChapter04()
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
        }

        [TestMethod]
        public void TestMethod_AddSimpleGraph()
        {
            Destination essex = new Destination
            {
                Name = "Essex, Vermont",
                Lodgings = new List<Lodging>
                {
                    new Lodging {Name = "Big Essex Hotel"},
                    new Lodging {Name = "Essex Junction B&B"}
                }
            };

            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;

                context.Destinations.Add(essex);

                Console.WriteLine("Essex Destination: {0}", context.Entry(essex).State);

                foreach (Lodging lodging in essex.Lodgings)
                {
                    Console.WriteLine("{0}: {1}", lodging.Name, context.Entry(lodging).State);
                }

                context.SaveChanges();
            }
        }

        private static void AddDestination1(Destination destination)
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Destinations.Add(destination);
                context.SaveChanges();
            }
        }

        private static void AddDestination2(Destination destination)
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Entry(destination).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_AddDestination()
        {
            Destination destination = new Destination
            {
                Name = "Jackson Hole, Wyoming",
                Description = "Get you skis on."
            };

            AddDestination1(destination);
            AddDestination2(destination);
        }

        private static void AttachDestination1(Destination destination)
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Destinations.Attach(destination);
                context.SaveChanges();
            }
        }

        private static void AttachDestination2(Destination destination)
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Entry(destination).State = EntityState.Unchanged;
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_AttachDestination()
        {
            Destination canyon;
            using (BreakAwayContext context = new BreakAwayContext())
            {
                canyon = (from d in context.Destinations
                    where d.Name == "Grand Canyon"
                    select d).Single();
            }

            AttachDestination1(canyon);
            AttachDestination2(canyon);
        }

        private static void UpdateDestination(Destination destination)
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Entry(destination).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_UpateDestination()
        {
            Destination canyon;
            using (BreakAwayContext context = new BreakAwayContext())
            {
                canyon = (from d in context.Destinations
                    where d.Name == "Grand Canyon"
                    select d).Single();
            }

            canyon.TravelWarnings = "Don't fall in!";
            UpdateDestination(canyon);
        }

        private static void DeleteDestination1(Destination destination)
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Destinations.Attach(destination);
                context.Destinations.Remove(destination);
                context.SaveChanges();
            }
        }

        private static void DeleteDestination2(int destinationId)
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                Destination destination = new Destination
                {
                    DestinationId = destinationId
                };

                context.Entry(destination).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_DeleteDestination()
        {
            Destination canyon;
            using (BreakAwayContext context = new BreakAwayContext())
            {
                canyon = (from d in context.Destinations
                    where d.Name == "Grand Canyon"
                    select d).Single();
            }

            //DeleteDestination1(canyon);
            DeleteDestination2(canyon.DestinationId);
        }

        [TestMethod]
        public void TestMethod_UpdateLodging()
        {
            Destination reef;
            Lodging davesDump;

            using (BreakAwayContext context = new BreakAwayContext())
            {
                reef = (from d in context.Destinations
                    where d.Name == "Great Barrier Reef"
                    select d).ToList().Single();

                davesDump = (from l in context.Lodgings.Include(l => l.Destination)
                    where l.Name == "Dave's Dump"
                    select l).ToList().Single();
            }

            Console.WriteLine("reef is IEntityWithChangeTacker: {0}", reef is IEntityWithChangeTracker);
            Console.WriteLine("davesDump is IEntityWithChangeTacker: {0}", davesDump is IEntityWithChangeTracker);

            //davesDump.DestinationId = reef.DestinationId;
            //UpdateLoging1(davesDump);

            //Destination previousDestination = davesDump.Destination;
            //davesDump.Destination = reef;
            //UpdateLodging2(davesDump, previousDestination);

            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Entry(reef).State = EntityState.Unchanged;
                context.Entry(davesDump).State = EntityState.Unchanged;
                davesDump.Destination = reef;

                reef.Description = "aaaaaaaaaaaa";

                context.SaveChanges();
            }

            //davesDump.Destination = reef;
            //using (BreakAwayContext context = new BreakAwayContext())
            //{
            //    context.Entry(davesDump).State = EntityState.Modified;
            //    context.SaveChanges();
            //}
        }

        private static void UpdateLoging1(Lodging lodging)
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Entry(lodging).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        private static void UpdateLodging2(Lodging lodging, Destination previousDestination)
        {
            BreakAwayContext context = new BreakAwayContext();
            //using ()
            {
                context.Configuration.AutoDetectChangesEnabled = true;

                context.Entry(lodging).State = EntityState.Modified;
                context.Entry(lodging.Destination).State = EntityState.Unchanged;

                if (lodging.Destination.DestinationId != previousDestination.DestinationId)
                {
                    context.Entry(previousDestination).State = EntityState.Unchanged;

                    ((IObjectContextAdapter)context).ObjectContext.ObjectStateManager.ChangeRelationshipState(
                        lodging,
                        lodging.Destination,
                        l => l.Destination,
                        EntityState.Added);

                    ((IObjectContextAdapter) context).ObjectContext.ObjectStateManager.ChangeRelationshipState(
                        lodging,
                        previousDestination,
                        l => l.Destination,
                        EntityState.Deleted);
                }

                context.SaveChanges();
            }
        }

        private static void SaveDestinationAndLodgings(Destination destination, List<Lodging> deletedLodgings)
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Destinations.Add(destination);

                if (destination.DestinationId > 0)
                {
                    context.Entry(destination).State = EntityState.Modified;
                }

                foreach (Lodging lodging in destination.Lodgings)
                {
                    if (lodging.LodgingId > 0)
                    {
                        context.Entry(lodging).State = EntityState.Modified;
                        Console.WriteLine("lodging id xxx: {0}", lodging.LodgingId);
                    }
                }

                foreach (Lodging lodging in deletedLodgings)
                {
                    context.Entry(lodging).State = EntityState.Deleted;
                }

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_SaveDestinationAndLodgings()
        {
            Destination canyon;
            using (BreakAwayContext context = new BreakAwayContext())
            {
                canyon = (from d in context.Destinations
                    where d.Name == "Grand Canyon"
                    select d).Single();

                context.Entry(canyon).Collection(d => d.Lodgings).Load();
            }

            canyon.TravelWarnings = "Carry enough water";

            canyon.Lodgings.Add(new Lodging
            {
                Name = "Big Canyon Lodge"
            });

            Lodging firstLodging = canyon.Lodgings.ElementAt(0);
            Console.WriteLine("firstLodging id: {0} destid:{1}", firstLodging.LodgingId, firstLodging.DestinationId); //无此属性则upate ... wnere ... and [destination_destinationid is null]
            firstLodging.Name = "New Name Holiday Park";

            Lodging secondLodging = canyon.Lodgings.ElementAt(1);
            List<Lodging> deletedLodgins = new List<Lodging>();
            canyon.Lodgings.Remove(secondLodging);
            deletedLodgins.Add(secondLodging);

            SaveDestinationAndLodgings(canyon, deletedLodgins);
        }

        private static void SaveDestinationGraph(Destination destination)
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Destinations.Add(destination);

                foreach (DbEntityEntry<IObjectWithState> entry in context.ChangeTracker.Entries<IObjectWithState>())
                {
                    IObjectWithState stateinfo = entry.Entity;
                    entry.State = ConvertState(stateinfo.State);
                }

                context.SaveChanges();
            }
        }

        private static EntityState ConvertState(State state)
        {
            switch (state)
            {
                case State.Added:
                    return EntityState.Added;

                case State.Modified:
                    return EntityState.Modified;

                case State.Deleted:
                    return EntityState.Deleted;

                default:
                    return EntityState.Unchanged;
            }
        }

        [TestMethod]
        public void TestMethod_SaveDestinationGraph()
        {
            Destination canyon;

            using (BreakAwayContext context = new BreakAwayContext())
            {
                canyon = (from d in context.Destinations.Include(d => d.Lodgings)
                    where d.Name == "Grand Canyon"
                    select d).Single();

            }

            canyon.TravelWarnings = "Carry enough water!";
            canyon.State = State.Modified;

            Lodging firstLodging = canyon.Lodgings.First();
            firstLodging.Name = "New Name Holiday Park";
            firstLodging.State = State.Modified;

            Lodging secondLodging = canyon.Lodgings.Last();
            secondLodging.State = State.Deleted;

            canyon.Lodgings.Add(new Lodging
            {
                Name = "Big Canyon Lodge",
                State = State.Added
            });

            SaveDestinationGraph(canyon);
        }

        private static void CheckForEntitiesWithoutStateInterface(BreakAwayContext context)
        {
            var entitiesWithoutState = (from e in context.ChangeTracker.Entries()
                where !(e.Entity is IObjectWithState)
                select e);

            if (entitiesWithoutState.Any())
            {
                throw new NotSupportedException("All entities must implement IObjectWithoutState");
            }
        }

        private static void ApplyChanges<TEntity>(TEntity root)
            where TEntity : class, IObjectWithState
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Set<TEntity>().Add(root);

                CheckForEntitiesWithoutStateInterface(context);

                foreach (DbEntityEntry<IObjectWithState> entry in context.ChangeTracker.Entries<IObjectWithState>())
                {
                    IObjectWithState stateInfo = entry.Entity;
                    if (stateInfo.State == State.Modified)
                    {
                        entry.State = EntityState.Unchanged;
                        foreach (string property in stateInfo.ModifiedProperties)
                        {
                            entry.Property(property).IsModified = true;
                        }
                    }
                    else
                    {
                        entry.State = ConvertState(stateInfo.State);
                    }
                }

                context.SaveChanges();
            }
        }


        [TestMethod]
        public void TestMethod_SaveDestinationGraph2()
        {
            Destination canyon;

            using (BreakAwayContext context = new BreakAwayContext())
            {
                canyon = (from d in context.Destinations.Include(d => d.Lodgings)
                          where d.Name == "Grand Canyon"
                          select d).Single();

            }

            canyon.TravelWarnings = "Carry enough water!";
            canyon.State = State.Modified;
            canyon.ModifiedProperties = new List<string> {"TravelWarnings"};

            Lodging firstLodging = canyon.Lodgings.First();
            firstLodging.Name = "New Name Holiday Park";
            firstLodging.State = State.Modified;
            firstLodging.ModifiedProperties = new List<string> {"Name"};

            Lodging secondLodging = canyon.Lodgings.Last();
            secondLodging.State = State.Deleted;

            canyon.Lodgings.Add(new Lodging
            {
                Name = "Big Canyon Lodge",
                State = State.Added
            });

            ApplyChanges(canyon);
        }
    }
}
