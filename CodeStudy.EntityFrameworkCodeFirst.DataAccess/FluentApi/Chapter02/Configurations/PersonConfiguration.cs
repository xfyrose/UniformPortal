using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter02;

namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess.FluentApi.Chapter02.Configurations
{
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            //HasKey(p => p.SocialSecurityNumber)
            //    .Property(p => p.SocialSecurityNumber).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //Property(p => p.RowVersion).IsRowVersion();
            Property(p => p.SocialSecurityNumber).IsConcurrencyToken();
        }
    }
}
