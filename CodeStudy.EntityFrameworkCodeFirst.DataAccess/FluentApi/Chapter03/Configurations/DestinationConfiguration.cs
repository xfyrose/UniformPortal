using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter03;

namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess.FluentApi.Chapter03.Configurations
{
    public class DestinationConfiguration : EntityTypeConfiguration<Destination>
    {
        public DestinationConfiguration()
        {
            //HasMany(d => d.Lodgings)
            //    .WithRequired(l => l.Destination);
            HasMany(d => d.Lodgings)
                .WithRequired()
                .HasForeignKey(l => l.LocationId);
        }
    }
}
