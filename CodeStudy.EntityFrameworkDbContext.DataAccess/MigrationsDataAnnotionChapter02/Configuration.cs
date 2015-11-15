using System.Collections.Generic;
using CodeStudy.EntityFrameworkDbContext.Model.DataAnnotation;

namespace CodeStudy.EntityFrameworkDbContext.DataAccess.MigrationsDataAnnotionChapter02
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeStudy.EntityFrameworkDbContext.DataAccess.DataAnnotation.Chapter02.BreakAwayContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            MigrationsDirectory = @"MigrationsDataAnnotionChapter02";
        }

        protected override void Seed(CodeStudy.EntityFrameworkDbContext.DataAccess.DataAnnotation.Chapter02.BreakAwayContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            context.Destinations.AddOrUpdate(
                p => p.Name,
                new Destination
                {
                    Name = "Hawaii",
                    Country = "USA",
                    Description = "Sunshine, beaches and fun."
                });

            context.Destinations.AddOrUpdate(
                p => p.Name,
                new Destination
                {
                    Name = "Wine Glass Bay",
                    Country = "Australia",
                    Description = "Picturesque sandy beaches."
                });

            context.Destinations.AddOrUpdate(
                p => p.Name,
                new Destination
                {
                    Name = "Great Barrier Reef",
                    Description = "Beautiful coral reef.",
                    Country = "Australia"
                });

            context.Destinations.AddOrUpdate(
                p => p.Name,
                new Destination
                {
                    Name = "Grand Canyon",
                    Country = "USA",
                    Description = "One huge canyon.",
                    Lodgings = new List<Lodging>
                    {
                      new Lodging
                      {
                        Name = "Grand Hotel",
                        MilesFromNearestAirport = 2.5M
                      },
                      new Lodging
                      {
                        Name = "Dave's Dump" ,
                        MilesFromNearestAirport = 32.65M,
                        PrimaryContact = new Person
                        {
                          FirstName = "Dave",
                          LastName = "Citizen",
                          Photo = new PersonPhoto()
                        }
                      }
                    }
                });

            context.Reservations.AddOrUpdate(
                p => p.DateTimeMade,
                new Reservation
                {
                    DateTimeMade = new DateTime(2011, 11, 11, 11, 11, 11),
                    Trip = new Trip
                    {
                        StartDate = new DateTime(2012, 1, 1),
                        EndDate = new DateTime(2012, 1, 14),
                        Description = ("Trip from the database"),
                        Destination = context.Destinations.Local.First(),
                        CostUsd = 1000M
                    },
                    Traveler = new Person
                    {
                        FirstName = "Julie",
                        LastName = "Lerman",
                        Photo = new PersonPhoto()
                    },
                    Payments = new List<Payment>()
                    {
                      new Payment { Amount = 150 }
                    }
                });

        }
    }
}
