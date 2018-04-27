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
    public class ActorsController : Controller
    {
        private FilmsContextcs db = new FilmsContextcs();

        public ActionResult ViewJS(Actor actor) => View(db.Actors.ToList());

        [HttpPost]
        public ActionResult createJS(Actor actor)
        {
            db.Actors.Add(actor);
            db.SaveChanges();
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
        public JsonResult getActorJS(string id)
        {
            List<Actor> actor = new List<Actor>();
            actor = db.Actors.ToList();            
            return Json(actor, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Сrutch() => View();
       
        [HttpPost]
        public ActionResult Сrutch2(string URL)
        {
            string pas = AppDomain.CurrentDomain.BaseDirectory + "test.jpg";
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(URL, pas);
            }
            //WebClient wc = new WebClient();
            //TODO DownloadFile
            //wc.DownloadFile(URL, @"logo.gif");
            return View();
        }
        [HttpGet]
        public ActionResult Сrutch2() => View();
       
        // GET: Actors
        public async Task<ActionResult> Index()
        {
            return View(await db.Actors.ToListAsync());
        }

        // GET: Actors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = await db.Actors.FindAsync(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // GET: Actors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Age")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Actors.Add(actor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(actor);
        }

        // GET: Actors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = await db.Actors.FindAsync(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,Age")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(actor);
        }

        // GET: Actors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = await db.Actors.FindAsync(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Actor actor = await db.Actors.FindAsync(id);
            db.Actors.Remove(actor);
            await db.SaveChangesAsync();
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
    }
}
