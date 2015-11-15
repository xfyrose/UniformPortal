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
    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<BlogContext>(new MigrateDatabaseToLatestVersion<BlogContext, BlogConfiguration>());
            //Database.SetInitializer(new BlogInitializer());
            //Database.SetInitializer<BlogContext>(null);

            base.OnModelCreating(modelBuilder);
        }
    }
}
