using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CodeStudy.UI.ProMvc5.Models;

namespace CodeStudy.UI.ProMvc5.Controllers
{
    public class AlbumController : Controller
    {
        // GET: Album
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListWeaklyTyped()
        {
            List<Album> albums = new List<Album>();
            for (int i = 0; i < 10; i++)
            {
                albums.Add(new Album { Title = "Product" + i.ToString() });
            }

            ViewBag.Albums = albums;
            ViewData["CurrentTime"] = DateTime.Now;

            return View();
        }

        public ActionResult ListStronglyTyped()
        {
            List<Album> albums = new List<Album>();
            for (int i = 0; i < 10; i++)
            {
                albums.Add(new Album { Title = "Product" + i.ToString() });
            }

            return View(albums);
        }

        public ActionResult Edit(int id = 0)
        {

            return View();
        }
    }
}