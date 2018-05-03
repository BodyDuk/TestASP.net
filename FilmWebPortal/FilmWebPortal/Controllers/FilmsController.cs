using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FilmWebPortal.Models;
using System.Collections;
using FilmWebPortal.ViewModels;

namespace FilmWebPortal.Controllers
{
    public class FilmsController : Controller
    {

        // GET: Films
        public async Task<ActionResult> Index()
        {
            //using (FilmsContextcs db = new FilmsContextcs())
            //{ якщо зробити через using то на вюшку не передастся обєкт і ми отримаємо помилку
            FilmsContextcs db = new FilmsContextcs();
            return View(await db.Films.ToListAsync());
            //}

        }

        // GET: Films/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            using (FilmsContextcs db = new FilmsContextcs())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Film film = await db.Films.FindAsync(id);
                if (film == null)
                {
                    return HttpNotFound();
                }
                return View(film);
            }

        }

        // GET: Films/Create
        public ActionResult Create()
        {
            using (FilmsContextcs db = new FilmsContextcs())
            {
                FilmViewModel film = new FilmViewModel();
                film.ActorsAll = db.Actors.ToList();
                return View(model: film);
            }

        }

        //POST: Films/Create
        public async Task<JsonResult> SaveFilm(/*string Name, string Description, List<int> SelectedActors*/FilmViewModel model)
        {
            using (FilmsContextcs db = new FilmsContextcs())
            {
                var film = (Film)model; 
                foreach (var item in model.SelectedActors)
                {
                    var actors = db.Actors.Find(item);
                    film.Actors.Add(actors);
                }
                db.Films.Add(film);
                await db.SaveChangesAsync();
            }
                return Json(JsonRequestBehavior.AllowGet);
        }
        // POST: Films/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,ReleaseDay,Actors")] Film film)
        //{
        //    using (FilmsContextcs db = new FilmsContextcs())
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Films.Add(film);
        //            await db.SaveChangesAsync();
        //            return RedirectToAction("Index");
        //        }

        //        return View(film);
        //    }

        //}

        // GET: Films/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            using (FilmsContextcs db = new FilmsContextcs())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Film film = await db.Films.FindAsync(id);
                if (film == null)
                {
                    return HttpNotFound();
                }
                return View(film);
            }

        }

        // POST: Films/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,ReleaseDay")] Film film)
        {
            using (FilmsContextcs db = new FilmsContextcs())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(film).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(film);
            }

        }

        // GET: Films/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            using (FilmsContextcs db = new FilmsContextcs())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Film film = await db.Films.FindAsync(id);
                if (film == null)
                {
                    return HttpNotFound();
                }
                return View(film);
            }

        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (FilmsContextcs db = new FilmsContextcs())
            {
                Film film = await db.Films.FindAsync(id);
                db.Films.Remove(film);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

        }

        protected override void Dispose(bool disposing)
        {
            using (FilmsContextcs db = new FilmsContextcs())
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }

        }
    }
}
