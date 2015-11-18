using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter02;

namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess.FluentApi.Chapter02.Configurations
{
    public class LodgingConfiguration : EntityTypeConfiguration<Lodging>
    {
        public LodgingConfiguration()
        {
            Property(l => l.Name).IsRequired().HasMaxLength(200);
            Property(l => l.MilesFromNearestAirport).HasPrecision(8, 1);
        }
    }
}
