using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter03;
using Destination = CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter02.Destination;
using Lodging = CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter02.Lodging;
using Person = CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter02.Person;
using Trip = CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter02.Trip;

namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess.FluentApi.Chapter02
{
    public class BreakAwayContext : DbContext
    {
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Lodging> Lodgings { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<BreakAwayContext>(new MigrateDatabaseToLatestVersion<BreakAwayContext, MigrationsFluentApiChapter02.Configuration>());

            //modelBuilder.Entity<Destination>().Property(d => d.Name).IsRequired();
            //modelBuilder.Entity<Destination>().Property(d => d.Description).HasMaxLength(500);
            //modelBuilder.Entity<Destination>().Property(d => d.Photo).HasColumnType("image");
            //modelBuilder.Entity<Lodging>().Property(l => l.Name).IsRequired().HasMaxLength(200);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new Configurations.DestinationConfiguration());
            modelBuilder.Configurations.Add(new Configurations.LodgingConfiguration());
            modelBuilder.Configurations.Add(new Configurations.TripConfiguration());
            modelBuilder.Configurations.Add(new Configurations.PersonConfiguration());
            modelBuilder.Configurations.Add(new Configurations.AddressConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}