using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter05;

namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess.FluentApi.Chapter05.Configurations
{
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            ToTable("People");
            Property(p => p.SocialSecurityNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
