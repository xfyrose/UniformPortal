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
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<OrderItem>().HasKey(k => new { k.OrderItemId, k.OrderId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
