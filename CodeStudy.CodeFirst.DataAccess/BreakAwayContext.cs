using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;
using CodeStudy.EntityFrameworkCodeFirst.Model;
using CodeStudy.EntityFrameworkCodeFirst.DataAccess.Migrations;

namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess
{
    public class BreakAwayContext : DbContext
    {
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Lodging> Lodgings { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<Person> Persons { get; set; }
        //public DbSet<PersonPhoto> PersonPhotos { get; set; }

        //public BreakAwayContext()
        //    : base("BreakAway")
        //{ }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Destination>().ToTable("a_table_name");
            //modelBuilder.Entity<Destination>().Property(m => m.Name).IsRequired();
            //modelBuilder.Entity<Destination>().Property(m => m.Description).HasMaxLength(512);
            //modelBuilder.Entity<Destination>().Property(m => m.Photo).HasColumnType("image");

            //modelBuilder.Entity<Lodging>().ToTable("Lodging");
            //modelBuilder.Entity<Lodging>().Property(m => m.Name).IsRequired().HasMaxLength(300);

            //modelBuilder.Entity<PersonPhoto>()
            //    .HasRequired(p => p.PhotoOf)
            //    .WithOptional(p => p.Photo);

            modelBuilder.Entity<InternetSpecial>()
                .HasRequired(s => s.Accommodation)
                .WithMany(l => l.InternetSpecials);
                //.HasForeignKey(s => s.AccommodationId);

            modelBuilder.Entity<Lodging>()
                .HasOptional(l => l.PrimaryContact)
                .WithMany(p => p.PrimaryContactFor);

            modelBuilder.Entity<Lodging>()
                .HasOptional(l => l.SecondaryContact)
                .WithMany(p => p.SecondaryContactFor);

            modelBuilder.Configurations.Add(new DestinationConfiguration());
            modelBuilder.Configurations.Add(new LodgingConfiguration());
            modelBuilder.Configurations.Add(new TripConfiguration());
            modelBuilder.Configurations.Add(new ReservationConfiguration());

            //modelBuilder.Entity<Trip>().HasKey(m => m.Identifier);

            Database.SetInitializer<BreakAwayContext>(new MigrateDatabaseToLatestVersion<BreakAwayContext, BreakAwayConfiguration>());
            base.OnModelCreating(modelBuilder);
        }
    }
}
