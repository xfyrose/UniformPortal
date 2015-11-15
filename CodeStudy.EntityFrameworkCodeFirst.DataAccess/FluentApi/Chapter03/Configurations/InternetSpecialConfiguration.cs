using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter03;

namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess.FluentApi.Chapter03.Configurations
{
    public class InternetSpecialConfiguration : EntityTypeConfiguration<InternetSpecial>
    {
        public InternetSpecialConfiguration()
        {
            HasRequired(i => i.Accommodation)
                .WithMany(l => l.InternetSpecials)
                .HasForeignKey(i => i.AccommodationId);
        }
    }
}
