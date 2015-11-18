using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeStudy.UI.ProMvc5.Models;

namespace CodeStudy.UI.ProMvc5.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            List<Product> products = new List<Product>();

            for (int i = 0; i < 10; i++)
            {
                products.Add(new Product { Title = "Product " + i, Price = 1.13M * i });
            }

            ShoppingCartViewModel model = new ShoppingCartViewModel
            {
                Products = products,
                CartTotal = products.Sum(p => p.Price),
                Message = "Thanks for your business!"
            };

            ViewBag.UserName = "userName01";
            //ViewBag.UserName = "\x3cscript\x3e%20alert(\x27pwnd\x27)%20\x3c/script\x3e";

            return View(model);
        }

        public ActionResult Message()
        {
            ViewBag.Message = "this is a partial view";

            return PartialView();
        }
    }
}