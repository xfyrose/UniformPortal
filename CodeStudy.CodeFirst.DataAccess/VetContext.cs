using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStudy.EntityFrameworkCodeFirst.Model;
using CodeStudy.EntityFrameworkCodeFirst.DataAccess.Migrations;

namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess
{
    public class VetContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visit> Visits { get; set; }

        public VetContext()
            : base("VetContent")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<VetContext, VetConfiguration>());

            modelBuilder.Entity<AnimalType>().ToTable("Species");
            modelBuilder.Entity<AnimalType>().Property(p => p.TypeName).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
