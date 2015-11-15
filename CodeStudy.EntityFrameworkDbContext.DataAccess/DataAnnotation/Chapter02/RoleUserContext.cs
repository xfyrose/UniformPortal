using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStudy.EntityFrameworkDbContext.Model.DataAnnotation;

namespace CodeStudy.EntityFrameworkDbContext.DataAccess.DataAnnotation.Chapter02
{
    public class RoleUserContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<BreakAwayContext>(new MigrateDatabaseToLatestVersion<BreakAwayContext, MigrationsDataAnnotionChapter02.Configuration>());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
