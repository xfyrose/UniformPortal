using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter01;

namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess.FluentApi.Chapter01
{
    public class RolePermissionContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasMany(r => r.Permissions)
                .WithRequired(p => p.Role)
                .HasForeignKey(p => p.RoleId);

            modelBuilder.Entity<Permission>()
                .HasKey(k => new { k.Id, k.RoleId });

            modelBuilder.Entity<Permission>()
                .HasRequired(p => p.Role)
                .WithMany(r => r.Permissions)
                .HasForeignKey(p => p.RoleId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
