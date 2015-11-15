using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStudy.EntityFrameworkDbContext.Model.DataAnnotation;

namespace CodeStudy.EntityFrameworkDbContext.DataAccess.DataAnnotation.Chapter02
{
    public class BreakAwayContext : DbContext
    {
        public BreakAwayContext()
        {
            ((IObjectContextAdapter) this).ObjectContext.ObjectMaterialized += (sender, args) =>
            {
                IObjectWithState entity = args.Entity as IObjectWithState;
                if (entity != null)
                {
                    entity.State = State.Unchanged;
                }
            };
        }

        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Lodging> Lodgings { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<BreakAwayContext>(new MigrateDatabaseToLatestVersion<BreakAwayContext, MigrationsDataAnnotionChapter02.Configuration>());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            return base.ValidateEntity(entityEntry, items);
        }
    }
}
