using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestASP.Models;

namespace TestASP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (FilmsContextcs db  = new FilmsContextcs())
            {
                return View(db.Films.ToList());
            }
           
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
}