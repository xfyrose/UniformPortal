using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeStudy.UI.ProMvc5.Models;

namespace CodeStudy.UI.ProMvc5.Controllers
{
    public class StoreManagerController : Controller
    {
        private MusicStoreDB db = new MusicStoreDB();

        // GET: StoreManager
        public ActionResult Index()
        {
            return View(db.Albums.ToList());
        }

        // GET: StoreManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: StoreManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(album);
        }

        // GET: StoreManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }

            AlbumEditViewModel editAlbum = new AlbumEditViewModel
            {
                AlbumToEdit = album,
                Genres = new SelectList(db.Genres, "Id", "Name", album.GenreId),
                Artists = new SelectList(db.Artists, "Id", "Name", album.ArtistId)
            };

            //ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Name", album.ArtistId);
            //ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", album.GenreId);

            return View(editAlbum);
        }

        // POST: StoreManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Price,GenreId,ArtistId")] Album album)
        {
            ModelState.AddModelError("Title", "What a terrible name!");

            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();

                //return View("Index");
                return RedirectToAction("Index");
            }

            AlbumEditViewModel editAlbum = new AlbumEditViewModel
            {
                AlbumToEdit = album,
                Genres = new SelectList(db.Genres, "Id", "Name", album.GenreId),
                Artists = new SelectList(db.Artists, "Id", "Name", album.ArtistId)
            };

            return View(editAlbum);
        }

        // GET: StoreManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Search()
        {
            IEnumerable<Album> albums = db.Albums
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .Take(10);

            //return RedirectToAction("Index");

            return View(albums);
        }

        [HttpGet]
        public ActionResult Search(string q)
        {
            IEnumerable<Album> albums = db.Albums
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .Where(a => a.Title.Contains(q))
                .Take(10);

            //return RedirectToAction("Index");

            return View(albums);
        }

        public ActionResult DailyDeal()
        {
            Album album = db.Albums
                .OrderBy(a => a.Id)
                .First();

            album.Price *= 0.5m;

            return PartialView(album);
        }

        public ActionResult ArtistSearch(string q)
        {
            List<Artist> artists = db.Artists
                .Where(a => a.Name.Contains(q))
                .ToList();

            return PartialView(artists);
        }
    }
}
