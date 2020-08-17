using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Apartmani.Web.Areas.Admin.Models;
using Apartmani.Web.Models;

namespace Apartmani.Web.Areas.Admin.Controllers
{
    

    public class VisitorGroupsController : Controller
    {
        private VisitorsManagerDbContext db = new VisitorsManagerDbContext();

        
        public ActionResult Index()
        {
            var visitorGroups = db.VisitorGroups.Include(p => p.Apartment).OrderByDescending(p => p.TimeOfCreation);

            var model = visitorGroups.ToList();

            return View(model);
        }
        
        [HttpPost]
        public ActionResult Index(VisitorGroupFilter filterModel)
        {
            var visitorGroups = db.VisitorGroups.Include(p => p.Apartment);

            if (!string.IsNullOrWhiteSpace(filterModel.Name))
                visitorGroups = visitorGroups.Where(p => p.Name.Contains(filterModel.Name));

            if (!string.IsNullOrWhiteSpace(filterModel.Apartment))
                visitorGroups = visitorGroups.Where(p => p.Apartment.Name.Contains(filterModel.Apartment));

            if ((filterModel.DateFrom.HasValue) && (filterModel.DateTo.HasValue))
            { 
                if (filterModel.DateFrom > filterModel.DateTo)
                {
                    ModelState.AddModelError(nameof(VisitorGroupFilter.DateFrom), "Krivi vremenski period");
                }
            }

            if (ModelState.IsValid)
            {
                if (filterModel.DateFrom.HasValue)
                {
                    visitorGroups = visitorGroups.Where(p => p.DateTo > filterModel.DateFrom);
                }

                if (filterModel.DateTo.HasValue)
                {
                    visitorGroups = visitorGroups.Where(p => p.DateFrom < filterModel.DateTo);
                }
            }


            var data = visitorGroups.OrderByDescending(p => p.TimeOfCreation).ToList();

            return PartialView("_IndexTable", data);
        }

        public ActionResult FilterForm()
        {
            return PartialView("_VisitorGroupFilter", new VisitorGroupFilter());
        }

        public ActionResult Status()
        {
            var visitorGroups = db.VisitorGroups.Include(p => p.Apartment);
            var prices = db.Prices.Where(p => p.Year == DateTime.Now.Year);

            VisitorGroup group;

            Prices price = prices.First(p => p.ApartmentID == 1);


            price.Months[0] = price.January;
            price.Months[1] = price.Fabruary;
            price.Months[2] = price.March;
            price.Months[3] = price.April;
            price.Months[4] = price.May;
            price.Months[5] = price.June;
            price.Months[6] = price.July;
            price.Months[7] = price.August;
            price.Months[8] = price.Septembar;
            price.Months[9] = price.Octobar;
            price.Months[10] = price.Novembar;
            price.Months[11] = price.Decembar;

            List<Status> statusList = new List<Status>();
            DateTime now = DateTime.Now.Date;
            DateTime now2 = DateTime.Now.Date.AddDays(1);


            try
            {
                group = visitorGroups.Where(p => p.ApartmentID == 1).First(p => (p.DateFrom < now) && (p.DateTo > now));
                statusList.Add(new Status(group) { Price = price.Months[DateTime.Now.Month - 1] });
            }
            catch (Exception)
            {
                try
                {
                    group = visitorGroups.First(p => (p.ApartmentID == 1) && (p.DateFrom == now));
                    statusList.Add(new Status(group) { Arrival = true, Price = price.Months[DateTime.Now.Month - 1] });
                }
                catch (Exception)
                {

                }

                try
                {
                    group = visitorGroups.First(p => (p.ApartmentID == 1) && (p.DateTo == now));
                    statusList.Add(new Status(group) { Departure = true });
                }
                catch (Exception)
                {

                }
            }

            price = prices.First(p => p.ApartmentID == 2);

            price.Months[0] = price.January;
            price.Months[1] = price.Fabruary;
            price.Months[2] = price.March;
            price.Months[3] = price.April;
            price.Months[4] = price.May;
            price.Months[5] = price.June;
            price.Months[6] = price.July;
            price.Months[7] = price.August;
            price.Months[8] = price.Septembar;
            price.Months[9] = price.Octobar;
            price.Months[10] = price.Novembar;
            price.Months[11] = price.Decembar;


            try
            {
                group = visitorGroups.First(p => (p.ApartmentID == 2) && (p.DateFrom < now) && (p.DateTo > now));
                statusList.Add(new Status(group) { Price = price.Months[DateTime.Now.Month - 1] });
            }
            catch (Exception)
            {
                try
                {
                    group = visitorGroups.First(p => (p.ApartmentID == 2) && (p.DateFrom == now));
                    statusList.Add(new Status(group) { Arrival = true, Price = price.Months[DateTime.Now.Month - 1] });
                }
                catch (Exception)
                {

                }

                try
                {
                    group = visitorGroups.First(p => (p.ApartmentID == 2) && (p.DateTo == now));
                    statusList.Add(new Status(group) { Departure = true });
                }
                catch (Exception)
                {

                }
            }



            try
            {
                group = visitorGroups.OrderBy(p => p.DateFrom).First(p => (p.ApartmentID == 1) && (p.DateFrom > now2));
                statusList.Add(new Status(group) { Future = true });
            }
            catch (Exception)
            {

            }

            try
            {
                group = visitorGroups.OrderBy(p => p.DateFrom).First(p => (p.ApartmentID == 2) && (p.DateFrom > now2));
                statusList.Add(new Status(group) { Future = true });
            }
            catch (Exception)
            {

            }

            return View(statusList);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitorGroup visitorGroup = db.VisitorGroups.Find(id);
            if (visitorGroup == null)
            {
                return HttpNotFound();
            }
            return View(visitorGroup);
        }


        public ActionResult Create()
        {
            FillDropdownValues();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VisitorGroup visitorGroup)
        {
            
            if (db.VisitorGroups.Where(p => p.ApartmentID == visitorGroup.ApartmentID).Any(p => (p.DateTo > visitorGroup.DateFrom) && (p.DateFrom < visitorGroup.DateFrom)))
            {
                ModelState.AddModelError(nameof(VisitorGroup.DateFrom), "Datum je zauzet");
            }

            if (db.VisitorGroups.Where(p => p.ApartmentID == visitorGroup.ApartmentID).Any(p => (p.DateFrom < visitorGroup.DateTo) && (p.DateTo > visitorGroup.DateTo)))
            {
                ModelState.AddModelError(nameof(VisitorGroup.DateTo), "Datum je zauzet");
            }

            if (db.VisitorGroups.Where(p => p.ApartmentID == visitorGroup.ApartmentID).Any(p => (p.DateFrom > visitorGroup.DateFrom) && (p.DateTo < visitorGroup.DateTo)))
            {
                ModelState.AddModelError(nameof(VisitorGroup.DateFrom), "Datum je zauzet");
                ModelState.AddModelError(nameof(VisitorGroup.DateTo), "Datum je zauzet");
            }

            if (ModelState.IsValid)
            {
                db.VisitorGroups.Add(visitorGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            FillDropdownValues();

            return View(visitorGroup);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitorGroup visitorGroup = db.VisitorGroups.Find(id);
            if (visitorGroup == null)
            {
                return HttpNotFound();
            }

            FillDropdownValues();

            return View(visitorGroup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VisitorGroup visitorGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visitorGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            FillDropdownValues();

            return View(visitorGroup);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitorGroup visitorGroup = db.VisitorGroups.Find(id);
            if (visitorGroup == null)
            {
                return HttpNotFound();
            }
            return View(visitorGroup);
        }
        
        // POST: Admin/VisitorGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VisitorGroup visitorGroup = db.VisitorGroups.Find(id);
            db.VisitorGroups.Remove(visitorGroup);

            var visitors = db.Visitors.Where(p => p.VisitorGroupID == id).ToList();

            foreach(var visitor in visitors)
            {
                db.Visitors.Remove(visitor);
            }

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

        private void FillDropdownValues()
        {
            var selectItems = new List<System.Web.Mvc.SelectListItem>();

            var listItem = new SelectListItem
            {
                Text = "- odaberite -",
                Value = ""
            };
            selectItems.Add(listItem);

            foreach (var apartment in db.Apartments)
            {
                listItem = new SelectListItem
                {
                    Text = apartment.Name,
                    Value = apartment.Id.ToString()
                };
                selectItems.Add(listItem);
            }

            ViewBag.PossibleApartments = selectItems;
        }
    }
}
