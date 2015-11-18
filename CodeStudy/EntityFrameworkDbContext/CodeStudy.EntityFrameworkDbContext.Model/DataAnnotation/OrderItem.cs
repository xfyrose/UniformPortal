using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.EntityFrameworkDbContext.Model.DataAnnotation
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public string OrderItemName { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
