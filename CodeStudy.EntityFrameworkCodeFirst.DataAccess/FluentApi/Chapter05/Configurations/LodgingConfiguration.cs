using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter05;

namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess.FluentApi.Chapter05.Configurations
{
    public class LodgingConfiguration : EntityTypeConfiguration<Lodging>
    {
        public LodgingConfiguration()
        {
            Property(l => l.Name).IsRequired().HasColumnName("LodgeName").HasMaxLength(200);
            Property(l => l.LodgingId).HasColumnName("LId");

            HasRequired(l => l.Destination)
                .WithMany(d => d.Lodgings)
                .Map(c => c.MapKey("dest_id"));

            //Property(l => l.DestinationId).HasColumnName("destination_id");

            //Map(m =>
            //{
            //    m.ToTable("Lodgings");
            //})
            //.Map<Resort>(m =>
            //{
            //    m.ToTable("Resorts");
            //    m.MapInheritedProperties();
            //});
            //.Map<Hostel>(m =>
            //{
            //    m.ToTable("Hostels");
            //    m.MapInheritedProperties();
            //});
        }
    }
}
