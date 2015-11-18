using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter03;

namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess.FluentApi.Chapter03.Configurations
{
    public class LodgingConfiguration : EntityTypeConfiguration<Lodging>
    {
        public LodgingConfiguration()
        {
            HasOptional(l => l.PrimaryContact)
                .WithMany(p => p.PrimaryContactFor);
            HasOptional(l => l.SecondaryContact)
                .WithMany(p => p.SecondaryContactFor);

            //HasRequired(l => l.Destination)
            //    .WithMany(d => d.Lodgings)
            //    .WillCascadeOnDelete(false);
        }
    }
}
