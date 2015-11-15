using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace CodeStudy.EntityFrameworkCodeFirst.Model
{
    public class LodgingConfiguration : EntityTypeConfiguration<Lodging>
    {
        public LodgingConfiguration()
        {
            Property(d => d.Name).IsRequired().HasMaxLength(256);
            Property(m => m.MilesFromNearestSAirport).HasPrecision(18, 3);

            //HasRequired(l => l.Destination)
            //    .WithMany(d => d.Lodgings)
            //    .WillCascadeOnDelete(false);
        }
    }
}
