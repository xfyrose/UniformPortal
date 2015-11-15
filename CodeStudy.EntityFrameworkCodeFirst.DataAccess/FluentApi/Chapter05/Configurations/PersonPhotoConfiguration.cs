using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter05;

namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess.FluentApi.Chapter05.Configurations
{
    public class PersonPhotoConfiguration : EntityTypeConfiguration<PersonPhoto>
    {
        public PersonPhotoConfiguration()
        {
            ToTable("People");
            HasKey(p => p.PersonId)
                .HasRequired(p => p.PhotoOf)
                .WithRequiredDependent(p => p.Photo);
        }
    }
}
