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
    public class DonorsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Donors
        public ActionResult Index()
        {
            return View(db.Donors.ToList());
        }

        public ActionResult IndexActive()
        {
            return View(db.Donors.Where(d => d.Active));
        }

        //public JsonResult GetDonor()
        //{

        //}

       

        // GET: Donors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donors donors = db.Donors.Find(id);
            if (donors == null)
            {
                return HttpNotFound();
            }
            return View(donors);
        }

        // GET: Donors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donors/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Donors donors)
        {
            if (ModelState.IsValid)
            {
                db.Donors.Add(donors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donors);
        }

        // GET: Donors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donors donors = db.Donors.Find(id);
            if (donors == null)
            {
                return HttpNotFound();
            }
            return View(donors);
        }

        // POST: Donors/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonorID,Name,Lastname,Address,Contact,Active,DeliveryDate,GestationWeek,DonorSince,DonorTo,ClinicalNotes,BreastPumpProvided,BreastPumpTaken,TotalDonated")] Donors donors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donors);
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
