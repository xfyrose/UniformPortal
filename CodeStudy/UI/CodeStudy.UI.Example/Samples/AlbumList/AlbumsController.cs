using System.Collections.Generic;
using System.Web.Mvc;
using CodeStudy.UI.Example.Models;

namespace CodeStudy.UI.Example.Controllers
{
    public class AlbumsController : Controller
    {
        public ActionResult ListWeaklyTyped()
        {
            var albums = new List<Album>();
            for (int i = 0; i < 10; i++)
            {
                albums.Add(new Album { Title = "Album " + i });
            }
            ViewBag.Albums = albums;
            return View();
        }
        
        public ActionResult ListStronglyTyped()
        {
            var albums = new List<Album>();
            for (int i = 0; i < 10; i++) 
            {
                albums.Add(new Album { Title = "Album " + i });
            }
            return View(albums);
        }
    }
}
