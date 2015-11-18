using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter05;

namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess.FluentApi.Chapter05.Configurations
{
    public class ReservationConfiguration : EntityTypeConfiguration<Reservation>
    {
        public ReservationConfiguration()
        {
            
        }
}
}
