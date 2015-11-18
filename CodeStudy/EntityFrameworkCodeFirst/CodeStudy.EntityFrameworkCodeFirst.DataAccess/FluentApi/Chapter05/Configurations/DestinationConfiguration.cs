using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter05;

namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess.FluentApi.Chapter05.Configurations
{
    public class DestinationConfiguration : EntityTypeConfiguration<Destination>
    {
        public DestinationConfiguration()
        {
            Property(d => d.DestinationId).HasColumnName("DesId");
            Property(d => d.Name).IsRequired().HasColumnName("DesName");
            Property(d => d.Description).HasMaxLength(200);
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
