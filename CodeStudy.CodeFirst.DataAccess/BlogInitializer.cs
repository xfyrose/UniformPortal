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
    public class BlogInitializer : IDatabaseInitializer<BlogContext>
    {
        public void InitializeDatabase(BlogContext context)
        {
            //if (context.Database.Exists())
            //{
            //    if (!context.Database.CompatibleWithModel(true))
            //    {
            //        context.Database.Delete();
            //    }
            //}

            context.Database.Delete();
            context.Database.Create();
        }
    }
}
