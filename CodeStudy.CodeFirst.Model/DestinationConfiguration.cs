using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace CodeStudy.EntityFrameworkCodeFirst.Model
{
    public class DestinationConfiguration : EntityTypeConfiguration<Destination>
    {
        public DestinationConfiguration()
        {
            Property(d => d.Name).IsRequired().HasColumnName("LocationName");
            Property(d => d.DestinationId).HasColumnName("LocationId");
            Property(d => d.Description).HasMaxLength(555);
            Property(d => d.Photo).HasColumnType("image");

            Map(m =>
            {
                m.Properties(d => new {d.Name, d.Country, d.Description});
                m.ToTable("Locations");
            });
            Map(m =>
            {
                m.Properties(d => new {d.Photo});
                m.ToTable("LocationPhotos");
            });
        }
    }
}
