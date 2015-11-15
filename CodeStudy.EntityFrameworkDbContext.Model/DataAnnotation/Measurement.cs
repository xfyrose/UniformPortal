using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.EntityFrameworkDbContext.Model.DataAnnotation
{
    public class Measurement
    {
        public decimal Reading { get; set; }
        public string Units { get; set; }
    }
}
