using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStudy.EntityFrameworkCodeFirst.DataAccess.FluentApi.Chapter03.Configurations;
using CodeStudy.EntityFrameworkCodeFirst.DataAccess.MigrationsFluentApiChapter03;
using CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter03;

namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess.FluentApi.Chapter03
{
    public class BreakAwayContext : DbContext
    {
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Lodging> Lodgings { get; set; }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<BreakAwayContext>(new MigrateDatabaseToLatestVersion<BreakAwayContext, Configuration>());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Destination>()
            //    .HasMany(d => d.Lodgings)
            //    .WithOptional(l => l.Destination);
            modelBuilder.Configurations.Add(new DestinationConfiguration());
            //modelBuilder.Configurations.Add(new InternetSpecialConfiguration());
            modelBuilder.Configurations.Add(new Configurations.LodgingConfiguration());
            modelBuilder.Configurations.Add(new Configurations.PersonPhotoConfiguration());

            //modelBuilder.Entity<Person>().Property(p => p.LastName).IsRequired();
            //modelBuilder.Entity<Person>().Property(p => p.Photo).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
