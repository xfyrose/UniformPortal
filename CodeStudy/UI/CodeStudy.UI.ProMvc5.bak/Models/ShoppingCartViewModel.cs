using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.UI.ProMvc5.Models
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public decimal CartTotal { get; set; }
        public string Message { get; set; }
    }
}
