using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Registration.Models;

namespace Registration.Controllers
{
    public class BirthRegistrationsController : Controller
    {
        private BRRegistrationEntities db = new BRRegistrationEntities();

        // GET: BirthRegistrations
        public ActionResult Index()
        {
            return View(db.BirthRegistration.ToList());
        }

        // GET: BirthRegistrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BirthRegistration birthRegistration = db.BirthRegistration.Find(id);
            if (birthRegistration == null)
            {
                return HttpNotFound();
            }
            return View(birthRegistration);
        }

        // GET: BirthRegistrations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BirthRegistrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegNo,Name,BirthDate,FatherName,MotherName,Address")] BirthRegistration birthRegistration)
        {
            if (ModelState.IsValid)
            {
                db.BirthRegistration.Add(birthRegistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(birthRegistration);
        }

        // GET: BirthRegistrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BirthRegistration birthRegistration = db.BirthRegistration.Find(id);
            if (birthRegistration == null)
            {
                return HttpNotFound();
            }
            return View(birthRegistration);
        }

        // POST: BirthRegistrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegNo,Name,BirthDate,FatherName,MotherName,Address")] BirthRegistration birthRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(birthRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(birthRegistration);
        }

        // GET: BirthRegistrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BirthRegistration birthRegistration = db.BirthRegistration.Find(id);
            if (birthRegistration == null)
            {
                return HttpNotFound();
            }
            return View(birthRegistration);
        }

        // POST: BirthRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BirthRegistration birthRegistration = db.BirthRegistration.Find(id);
            db.BirthRegistration.Remove(birthRegistration);
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
