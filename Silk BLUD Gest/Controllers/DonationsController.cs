
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Silk_BLUD_Gest.Models;

namespace Silk_BLUD_Gest.Controllers
{
    public class DonationsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Donations
        public ActionResult Index()
        {
            var donations = db.Donations.Include(d => d.Donors);
            return View(donations.ToList());
        }

        // GET: Donations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donations donations = db.Donations.Find(id);
            if (donations == null)
            {
                return HttpNotFound();
            }
            return View(donations);
        }

        // GET: Donations/Create

        public ActionResult Create(string id)
        {
            if (id == null )
            {
                return RedirectToAction("Index","Donors");
            }


            ViewBag.DonorID = id;
            return View();
        }

        // POST: Donations/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonationID,DonorID,FreezingDate,Quantity,BottleNum")] Donations donation)
        {
            if (ModelState.IsValid)
            {
                db.Donations.Add(donation);
                db.SaveChanges();

                Stock.UpdateDonorStock(donation, db);

                return RedirectToAction("Index","Donors");
            }

            ViewBag.DonorID = new SelectList(db.Donors, "DonorID", "Name", donation.DonorID);
            return View(donation);
        }

        // GET: Donations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donations donations = db.Donations.Find(id);
            if (donations == null)
            {
                return HttpNotFound();
            }
            ViewBag.DonorID = new SelectList(db.Donors, "DonorID", "Name", donations.DonorID);
            return View(donations);
        }

        // POST: Donations/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonationID,DonorID,FreezingDate,Quantity,BottleNum")] Donations donations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DonorID = new SelectList(db.Donors, "DonorID", "Name", donations.DonorID);
            return View(donations);
        }

        // GET: Donations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donations donations = db.Donations.Find(id);
            if (donations == null)
            {
                return HttpNotFound();
            }
            return View(donations);
        }

        // POST: Donations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donations donations = db.Donations.Find(id);
            db.Donations.Remove(donations);
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
