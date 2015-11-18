using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.EntityFrameworkDbContext.Model.DataAnnotation
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
