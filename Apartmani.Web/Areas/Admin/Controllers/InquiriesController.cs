using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Apartmani.Web.Areas.Admin.Models;
using Apartmani.Web.Models;

namespace Apartmani.Web.Areas.Admin.Controllers
{
    public class InquiriesController : Controller
    {
        private VisitorsManagerDbContext db = new VisitorsManagerDbContext();

        // GET: Inquiries
        public ActionResult Index()
        {
            var inquiries = db.Inquiries.Include(i => i.Apartment);
            return View(inquiries.ToList());
        }

        public ActionResult Count()
        {
            int? number = db.Inquiries.Count();
            return PartialView(number);
        }

        public ActionResult Accept(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Inquiry inquiry = db.Inquiries.Find(id);

            if (inquiry == null)
            {
                return HttpNotFound();
            }

            var newVisitorGroup = new VisitorGroup
            {
                ApartmentID = inquiry.ApartmentID,
                BrojMobitela = inquiry.Phone,
                BrojOsoba = inquiry.Persons,
                DateFrom = inquiry.DateFrom,
                DateTo = inquiry.DateTo,
                Email = inquiry.Email,
                Name = inquiry.LastName,
                Message = inquiry.Message
            };

            db.VisitorGroups.Add(newVisitorGroup);

            db.Inquiries.Remove(inquiry);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Decline(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Inquiry inquiry = db.Inquiries.Find(id);

            if (inquiry == null)
            {
                return HttpNotFound();
            }

            db.Inquiries.Remove(inquiry);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Inquiries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inquiry inquiry = db.Inquiries.Find(id);
            if (inquiry == null)
            {
                return HttpNotFound();
            }
            return View(inquiry);
        }

        // GET: Inquiries/Create
        public ActionResult Create(int ApartmentID)
        {
            ViewBag.ApartmentID = ApartmentID;
            return View();
        }

        // POST: Inquiries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateFrom,DateTo,ApartmentID,Persons,FirstName,LastName,Email,Phone,Message,Approved,Declined")] Inquiry inquiry)
        {
            ViewBag.ApartmentID = inquiry.ApartmentID;

            if (ModelState.IsValid)
            {
                inquiry.SetAvailabilitiy();
                db.Inquiries.Add(inquiry);
                db.SaveChanges();
                return RedirectToAction("Index", new { area = "", controller = "Home" });
            }

            return View(inquiry);
        }

        // GET: Inquiries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inquiry inquiry = db.Inquiries.Find(id);
            if (inquiry == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApartmentID = new SelectList(db.Apartments, "Id", "Name", inquiry.ApartmentID);
            return View(inquiry);
        }

        // POST: Inquiries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateFrom,DateTo,ApartmentID,Persons,FirstName,LastName,Email,Phone,Message,Approved,Declined")] Inquiry inquiry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inquiry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApartmentID = new SelectList(db.Apartments, "Id", "Name", inquiry.ApartmentID);
            return View(inquiry);
        }

        // GET: Inquiries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inquiry inquiry = db.Inquiries.Find(id);
            if (inquiry == null)
            {
                return HttpNotFound();
            }
            return View(inquiry);
        }

        // POST: Inquiries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inquiry inquiry = db.Inquiries.Find(id);
            db.Inquiries.Remove(inquiry);
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
    }
}
