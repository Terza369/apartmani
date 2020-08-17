using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Apartmani.Web.Areas.Admin.Models;
using Apartmani.Web.Models;

namespace Apartmani.Web.Areas.Admin.Controllers
{
    public class VisitorsController : Controller
    {
        private VisitorsManagerDbContext db = new VisitorsManagerDbContext();

        // GET: Admin/Visitors
        public ActionResult Index()
        {
            var visitors = db.Visitors.Include(v => v.VisitorGroup);
            return View(visitors.ToList());
        }

        // GET: Admin/Visitors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visitor visitor = db.Visitors.Find(id);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            return View(visitor);
        }

        // GET: Admin/Visitors/Create
        public ActionResult Create(int id)
        {
            FillDropdownValues();

            var model = new Visitor() { VisitorGroupID = id };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                db.Visitors.Add(visitor);
                db.SaveChanges();
                return RedirectToAction("Details", new RouteValueDictionary( new { controller = "VisitorGroups", action = "Details", id = visitor.VisitorGroupID} ));
            }

            return View(visitor);
        }

        // GET: Admin/Visitors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visitor visitor = db.Visitors.Find(id);
            if (visitor == null)
            {
                return HttpNotFound();
            }

            FillDropdownValues();

            return View(visitor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visitor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "VisitorGroups", new { id = visitor.VisitorGroupID });
            }

            return View(visitor);
        }

        // GET: Admin/Visitors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visitor visitor = db.Visitors.Find(id);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            return View(visitor);
        }

        // POST: Admin/Visitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visitor visitor = db.Visitors.Find(id);
            db.Visitors.Remove(visitor);
            db.SaveChanges();
            return RedirectToAction("Details", "VisitorGroups", new { id = visitor.VisitorGroupID });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        
        private void FillDropdownValues()
        {
            FillDropdownValuesCities();
            FillDropdownValuesCountries();
        }

        private void FillDropdownValuesCities()
        {
            var selectItems = new List<System.Web.Mvc.SelectListItem>();

            var listItem = new SelectListItem
            {
                Text = "- Odaberite grad-",
                Value = ""
            };
            selectItems.Add(listItem);

            foreach (var item in db.Cities)
            {
                listItem = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                };
                selectItems.Add(listItem);
            }

            ViewBag.PossibleCities = selectItems;
        }

        private void FillDropdownValuesCountries()
        {
            var selectItems = new List<System.Web.Mvc.SelectListItem>();

            var listItem = new SelectListItem
            {
                Text = "- Odaberite državu-",
                Value = ""
            };
            selectItems.Add(listItem);

            foreach (var item in db.Countries)
            {
                listItem = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                };
                selectItems.Add(listItem);
            }

            ViewBag.PossibleCountries = selectItems;
        }
    }
}
