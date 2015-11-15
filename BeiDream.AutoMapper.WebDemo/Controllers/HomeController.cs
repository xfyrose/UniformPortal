using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeiDream.AutoMapper;
using BeiDream.AutoMapper.Reflection;

namespace BeiDream.WebDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AutoMapperBootstrapper autoMapperBootstrapper = new AutoMapperBootstrapper(WebAssemblyFinder.Instance);
            autoMapperBootstrapper.Initialize();

            User user = new User() { Id = 1, Name = "AA" };
            var target = user.MapTo<UserDto>();
            var cc=target.Name;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    [AutoMapFrom(typeof(User))]
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}