using Apartmani.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apartmani.Web.Controllers
{
    public class HomeController : Controller
    {
        private VisitorsManagerDbContext db = new VisitorsManagerDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var apartment = db.Apartments.First(p => p.Id == id);

            return PartialView("_Details", apartment);
        }

        public ActionResult Details2(int id)
        {
            var apartment = db.Apartments.First(p => p.Id == id);

            return PartialView("_Details2", apartment);
        }

        public ActionResult Gallery1()
        {
            return PartialView("_Gallery1");
        }

        public ActionResult Gallery2()
        {
            return PartialView("_Gallery2");
        }
    }
}