using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace CodeStudy.EntityFrameworkCodeFirst.Model
{
    public class TripConfiguration : EntityTypeConfiguration<Trip>
    {
        public TripConfiguration()
        {
            HasKey(m => m.Identifier);
            Property(m => m.Identifier).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.RowVersion).IsRowVersion();
        }
    }
}
