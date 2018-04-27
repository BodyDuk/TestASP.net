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

namespace FilmWebPortal.Controllers
{
    public class DirectorsController : Controller
    {
        //private FilmsContextcs db = new FilmsContextcs();
       
        // GET: Directors
        public async Task<ActionResult> Index()
        {
            using (FilmsContextcs db = new FilmsContextcs())
            {
                return View(await db.Directors.ToListAsync());

            }
        }

        // GET: Directors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            using (FilmsContextcs db = new FilmsContextcs())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Director director = await db.Directors.FindAsync(id);
                if (director == null)
                {
                    return HttpNotFound();
                }
                return View(director);
            }
        }

        // GET: Directors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Directors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Director director)
        {
            using (FilmsContextcs db = new FilmsContextcs())
            {
                if (ModelState.IsValid)
                {
                    db.Directors.Add(director);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                return View(director);

            }
           
        }

        // GET: Directors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            using (FilmsContextcs db = new FilmsContextcs())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Director director = await db.Directors.FindAsync(id);
                if (director == null)
                {
                    return HttpNotFound();
                }
                return View(director);

            }
           
        }

        // POST: Directors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Director director)
        {
            using (FilmsContextcs db = new FilmsContextcs())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(director).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(director);

            }
            
        }

        // GET: Directors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            using (FilmsContextcs db = new FilmsContextcs())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Director director = await db.Directors.FindAsync(id);
                if (director == null)
                {
                    return HttpNotFound();
                }
                return View(director);

            }
            
        }

        // POST: Directors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (FilmsContextcs db = new FilmsContextcs())
            {
                Director director = await db.Directors.FindAsync(id);
                db.Directors.Remove(director);
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
