using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using CodeStudy.EntityFrameworkDbContext.DataAccess.DataAnnotation.Chapter02;
using CodeStudy.EntityFrameworkDbContext.Model.DataAnnotation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeStudy.EntityFrameworkDbContext.UnitTest.DataAnnotation
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
        public void TestMethod_PrintState()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                Destination canyon = (from d in context.Destinations
                    where d.Name == "Grand Canyon"
                    select d).Single();

                DbEntityEntry<Destination> entry = context.Entry(canyon);

                Console.WriteLine("Before Edit: {0}", entry.State);
                canyon.TravelWarnings = "Take lots of water";
                //context.ChangeTracker.DetectChanges();
                Console.WriteLine("After Edit: {0}", entry.State);
            }
        }

        //private static void PrintPropertyValues(DbPropertyValues values)
        //{
        //    values.PropertyNames.ToList().ForEach(v => Console.WriteLine(" - {0}:{1}", v, values[v]));
        //}

        private static void PrintChangeTrackingInfo(BreakAwayContext context, object entity)
        {
            DbEntityEntry entry = context.Entry(entity);

            Console.WriteLine();
            Console.WriteLine(entry.Entity.GetType());

            Console.WriteLine("State: {0}", entry.State);

            if (entry.State != System.Data.Entity.EntityState.Deleted)
            {
                Console.WriteLine("\nCurrent Values:");
                PrintPropertyValues(entry.CurrentValues);
            }

            if (entry.State != System.Data.Entity.EntityState.Added)
            {
                Console.WriteLine("\nOriginal Values:");
                PrintPropertyValues(entry.OriginalValues);

                Console.WriteLine("\nDatabase Values:");
                PrintPropertyValues(entry.GetDatabaseValues());
            }
        }

        [TestMethod]
        public void TestMethod_PrintLodgingInfo()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                var hotel = (from l in context.Lodgings
                    where l.Name == "Grand Hotel"
                    select l).Single();

                hotel.Name = "Super Grand Hotel";

                context.Database.ExecuteSqlCommand(@"UPDATE Lodging SET Name='Not-So-Grand-Hotel' WHERE Name='Grand Hotel'");

                PrintChangeTrackingInfo(context, hotel);
            }
        }

        [TestMethod]
        public void TestMethod_PrintLodgingInfo2()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                var hotel = (from l in context.Lodgings
                             where l.Name == "Grand Hotel"
                             select l).Single();

                PrintChangeTrackingInfo(context, hotel);

                var davesDump = (from d in context.Lodgings
                    where d.Name == "Dave's Dump"
                    select d).Single();
                context.Lodgings.Remove(davesDump);
                PrintChangeTrackingInfo(context, davesDump);

                var newMotel = new Lodging {Name = "New Motel"};
                context.Lodgings.Add(newMotel);
                PrintChangeTrackingInfo(context, newMotel);
            }
        }

        [TestMethod]
        public void TestMethod_PrintOriginalName()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                var hotel = (from l in context.Lodgings
                             where l.Name == "Grand Hotel"
                             select l).Single();

                hotel.Name = "Super Grand Hotel";

                string originalName = context.Entry(hotel)
                    .OriginalValues
                    .GetValue<string>("Name");

                Console.WriteLine("Current Name: {0}", hotel.Name);
                Console.WriteLine("Original Name: {0}", originalName);
            }
        }

        private static void PrintPropertyValues(DbPropertyValues values, int indent = 1)
        {
            values.PropertyNames.ToList().ForEach(propertyName =>
            {
                var value = values[propertyName];
                if (value is DbPropertyValues)
                {
                    Console.WriteLine("{0}- Complex Property: {1}", string.Empty.PadLeft(indent), propertyName);
                    PrintPropertyValues((DbPropertyValues) value, indent + 1);
                }
                else
                {
                    Console.WriteLine("{0}- {1}: {2}", string.Empty.PadLeft(indent), propertyName, values[propertyName]);
                }
            });
        }

        [TestMethod]
        public void TestMethod_PrintPersonInfo()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                Person person = new Person
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Address = new Address {State = "VT"}
                };

                context.People.Add(person);

                PrintChangeTrackingInfo(context, person);
            }
        }

        private static void PrintDestination(Destination destination)
        {
            Console.WriteLine("-- {0}, {1} --", destination.Name, destination.Country);
            Console.WriteLine(destination.Description);

            if (destination.TravelWarnings != null)
            {
                Console.WriteLine("WARNING!: {0}", destination.TravelWarnings);
            }
        }

        [TestMethod]
        public void TestMethod_PrintDestination()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                Destination reef = (from d in context.Destinations
                    where d.Name == "Great Barrier Reef"
                    select d).Single();

                reef.TravelWarnings = "Watch out for sharks";

                Console.WriteLine("Current Values");
                PrintDestination(reef);

                Console.WriteLine("\nDatabase Values");
                DbPropertyValues dbValues = context.Entry(reef).GetDatabaseValues();
                PrintDestination((Destination)dbValues.ToObject());
            }
        }

        [TestMethod]
        public void TestMethod_ChangeCurrentValue()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;

                Lodging hotel = (from d in context.Lodgings
                    where d.Name == "Grand Hotel"
                    select d).Single();

                context.Entry(hotel).CurrentValues["Name"] = "Hotel Presentations";

                Console.WriteLine("Property Value: {0}", hotel.Name);
                Console.WriteLine("State: {0}", context.Entry(hotel).State);
            }
        }

        [TestMethod]
        public void TestMethod_CloneCurrentValue()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                Lodging hotel = (from d in context.Lodgings
                    where d.Name == "Grand Hotel"
                    select d).Single();

                DbPropertyValues values = context.Entry(hotel).CurrentValues.Clone();
                values["Name"] = "Simple Hotel";

                Console.WriteLine("Property Value: {0}", hotel.Name);
                Console.WriteLine("State: {0}", context.Entry(hotel).State);
            }
        }

        [TestMethod]
        public void TestMethod_UndoEdits()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                Destination canyon = (from d in context.Destinations
                    where d.Name == "Grand Canyon"
                    select d).Single();

                canyon.Name = "Bigger & Better Canyon";

                DbEntityEntry entry = context.Entry(canyon);
                entry.CurrentValues.SetValues(entry.OriginalValues);
                entry.State = System.Data.Entity.EntityState.Unchanged;

                Console.WriteLine("Name: {0}", canyon.Name);
            }
        }

        [TestMethod]
        public void TestMethod_CreateDavesCampsite()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                Lodging davesDump = (from l in context.Lodgings
                    where l.Name == "Dave's Dump"
                    select l).Single();

                Lodging clone = new Lodging();
                context.Lodgings.Add(clone);
                context.Entry(clone).CurrentValues.SetValues(davesDump);

                clone.Name = "Dave's Camp";
                Console.WriteLine("Before Id: {0} Name: {1}", clone.LodgingId, clone.Name);
                context.SaveChanges();

                Console.WriteLine("After Id: {0} Name: {1}", clone.LodgingId, clone.Name);
                Console.WriteLine("Miles: {0}", clone.MilesFromNearestAirport);
                Console.WriteLine("Contact Id: {0}", clone.PrimaryContactId);
            }
        }

        [TestMethod]
        public void TestMethod_WorkingWithPropertyMethod()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                Lodging davesDump = (from l in context.Lodgings
                    where l.Name == "Dave's Dump"
                    select l).Single();

                DbEntityEntry<Lodging> entry = context.Entry(davesDump);

                entry.Property(l => l.Name).CurrentValue = "Dave's Bargain Bungalows";
                Console.WriteLine("Current Value: {0}", entry.Property(l => l.Name).CurrentValue);
                Console.WriteLine("Original Value: {0}", entry.Property(l => l.Name).OriginalValue);
                Console.WriteLine("Modified?: {0}", entry.Property(l => l.Name).IsModified);

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_FindModifiedProperties()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                Destination canyon = (from d in context.Destinations
                    where d.Name == "Grand Canyon"
                    select d).Single();

                canyon.Name = "Super-size Canyon";
                canyon.TravelWarnings = "Bigger than your brain can handle!!!";

                DbEntityEntry<Destination> entry = context.Entry(canyon);
                IEnumerable<string> propertyNames = entry.CurrentValues.PropertyNames;

                IEnumerable<string> modifiedProperties = from name in propertyNames
                                                         where entry.Property(name).IsModified
                                                         select name;
                modifiedProperties.ToList().ForEach(Console.WriteLine);

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_WorkingWithComplexMethod()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                Person julie = (from p in context.People
                    where p.FirstName == "Julie"
                    select p).Single();

                DbEntityEntry<Person> entry = context.Entry(julie);

                entry.ComplexProperty(p => p.Address)
                    .Property(a => a.State)
                    .CurrentValue = "VT";

                Console.WriteLine("Address.State Modified?: {0}", entry.ComplexProperty(p => p.Address).Property(a => a.State).IsModified);
                Console.WriteLine("Address Modified?: {0}", entry.ComplexProperty(p => p.Address).IsModified);
                Console.WriteLine("Info.Height.Units Modified?: {0}", entry.ComplexProperty(p => p.Info).ComplexProperty(i => i.Height).Property(h => h.Units).IsModified);
            }
        }

        [TestMethod]
        public void TestMethod_WorkingWithReferenceMethod()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;
                context.Configuration.LazyLoadingEnabled = false;

                Lodging davesDump = (from l in context.Lodgings
                    where l.Name == "Dave's Dump"
                    select l).Single();

                DbEntityEntry<Lodging> entry = context.Entry(davesDump);
                entry.Reference(l => l.Destination).Load();

                Destination canyon = davesDump.Destination;

                Console.WriteLine("Current Value After Load: {0}", entry.Reference(d => d.Destination).CurrentValue.Name);

                Destination reef = (from d in context.Destinations
                    where d.Name == "Great Barrier Reef"
                    select d).Single();

                entry.Reference(d => d.Destination).CurrentValue = reef;

                Console.WriteLine("Current Value After Change: {0}", davesDump.Destination.Name);
                Console.WriteLine("Current Value After Change: {0}", entry.Reference(d => d.Destination).CurrentValue.Name);

                Console.WriteLine("\nState: {0}", entry.State);
                Console.WriteLine("Reference From Current Destination: {0}", reef.Lodgings.Contains(davesDump));
                Console.WriteLine("Reference From Former Destination: {0}", canyon.Lodgings.Contains(davesDump));

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_WorkingWithCollectionMethod()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;

                Reservation res = (from r in context.Reservations
                    where r.Trip.Description == "Trip from the database"
                    select r).Single();

                DbEntityEntry<Reservation> entry = context.Entry(res);

                entry.Collection(r => r.Payments).Load();

                Console.WriteLine("Payments Before Add: {0}", entry.Collection(r => r.Payments).CurrentValue.Count);

                Payment payment = new Payment {Amount = 245};
                //context.Payments.Add(payment);

                entry.Collection(r => r.Payments).CurrentValue.Add(payment);
                Console.WriteLine("Payments After Add: {0}", entry.Collection(r => r.Payments).CurrentValue.Count);

                Console.WriteLine("Foreign Key Before DetectChanges: {0}", payment.ReservationId);
                //context.ChangeTracker.DetectChanges();
                Console.WriteLine("Foreign Key After DetectChanges: {0}", payment.ReservationId);
                Console.WriteLine("Reservation Key: {0}", res.ReservationId);

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_ReloadLodging()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                Lodging hotel = (from l in context.Lodgings
                    where l.Name == "Grand Hotel"
                    select l).Single();

                context.Database.ExecuteSqlCommand(@"UPDATE dbo.Lodging SET Name='Le Grand Hotel' WHERE Name='Grand Hotel'");

                hotel.Name = "A New Name";
                Console.WriteLine("Name Before Reload: {0}", hotel.Name);
                Console.WriteLine("State Before Reload: {0}", context.Entry(hotel).State);

                context.Entry(hotel).Reload();

                Console.WriteLine("Name After Reload: {0}", hotel.Name);
                Console.WriteLine("State After Reload: {0}", context.Entry(hotel).State);
            }
        }

        [TestMethod]
        public void TestMethod_PrintChangeTrackerEntries()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                Reservation res = (from r in context.Reservations
                    where r.Trip.Description == "Trip from the database"
                    select r).Single();

                context.Entry(res).Collection(r => r.Payments).Load();

                res.Payments.Add(new Payment {Amount = 245});

                IEnumerable<DbEntityEntry> entries = context.ChangeTracker.Entries();
                entries.ToList().ForEach(entityEntry =>
                {
                    Console.WriteLine("Entity Type: {0}", entityEntry.Entity.GetType());
                    Console.WriteLine(" - State: {0}", entityEntry.State);
                });

                entries = from e in context.ChangeTracker.Entries()
                          where e.State == EntityState.Unchanged
                          select e;
                Console.WriteLine("\n\n");
                entries.ToList().ForEach(entityEntry =>
                {
                    Console.WriteLine("Entity Type: {0}", entityEntry.Entity.GetType());
                    Console.WriteLine(" - State: {0}", entityEntry.State);
                });

                Console.WriteLine("\n\n");
                IEnumerable<DbEntityEntry<Payment>> entries2 = context.ChangeTracker.Entries<Payment>();
                entries2.ToList().ForEach(entityEntry =>
                {
                    Console.WriteLine("Amount: {0}", entityEntry.Entity.Amount);
                    Console.WriteLine(" - State: {0}", entityEntry.State);
                });
            }
        }

        private static void SaveWithConcurrencyResolution(BreakAwayContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ResolveConcurrencyConflicts(ex);
                SaveWithConcurrencyResolution(context);
            }
        }

        private static void ResolveConcurrencyConflicts(DbUpdateConcurrencyException ex)
        {
            ex.Entries.ToList().ForEach(entry =>
            {
                Console.WriteLine("Concurrency conflict found for {0}", entry.Entity.GetType());

                Console.WriteLine("\nYou are trying to save the following values:");
                PrintPropertyValues(entry.CurrentValues);

                Console.WriteLine("\nThe value before you started editing were:");
                PrintPropertyValues(entry.OriginalValues);

                DbPropertyValues databaseValues = entry.GetDatabaseValues();
                Console.WriteLine("\nAnother user has saved the following values:");
                PrintPropertyValues(databaseValues);

                string action = "S";
                switch (action)
                {
                    case "S":
                        entry.OriginalValues.SetValues(databaseValues);
                        break;
                    case "D":
                        entry.Reload();
                        break;
                    case "M":
                        var mergedValues = MergedValues(entry.OriginalValues, entry.CurrentValues, databaseValues);

                        entry.OriginalValues.SetValues(databaseValues);
                        entry.CurrentValues.SetValues(mergedValues);
                        break;

                    default:
                        throw new ArgumentException("Invalid option");

                }
            });
        }

        private static DbPropertyValues MergedValues(DbPropertyValues original, DbPropertyValues current, DbPropertyValues database)
        {
            DbPropertyValues result = original.Clone();

            original.PropertyNames.ToList().ForEach(propertyName =>
            {
                if (original[propertyName] is DbPropertyValues)
                {
                    var mergedComplexValues = MergedValues((DbPropertyValues)original[propertyName], (DbPropertyValues)current[propertyName], (DbPropertyValues)database[propertyName]);
                    ((DbPropertyValues) result[propertyName]).SetValues(mergedComplexValues);
                }
                else
                {
                    if (!object.Equals(original[propertyName], current[propertyName]))
                    {
                        result[propertyName] = current[propertyName];
                    }
                    else if (!object.Equals(original[propertyName], database[propertyName]))
                    {
                        result[propertyName] = database[propertyName];
                    }
                }
            });

            return result;
        }

        [TestMethod]
        public void TestMethod_ConcurrencyDemo()
        {
            using (BreakAwayContext context = new BreakAwayContext())
            {
                Trip trip = (from t in context.Trips.Include(t => t.Destination)
                    where t.Description == "Trip from the database"
                    select t).Single();

                trip.Description = "Getaway in Vermont";

                context.Database.ExecuteSqlCommand(@"UPDATE dbo.Trip SET CostUsd = 400 WHERE Description='Trip from the database'");

                SaveWithConcurrencyResolution(context);
            }
        }
    }
}
