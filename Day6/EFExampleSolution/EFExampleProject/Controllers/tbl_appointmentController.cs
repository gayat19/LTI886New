using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFExampleProject.Models;

namespace EFExampleProject.Controllers
{
    public class tbl_appointmentController : Controller
    {
        private dbTrainingEntities db = new dbTrainingEntities();

        // GET: tbl_appointment
        public ActionResult Index()
        {
            var tbl_appointment = db.tbl_appointment.Include(t => t.tbl_Doctor).Include(t => t.tbl_Patient);
            return View(tbl_appointment.ToList());
        }

        // GET: tbl_appointment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_appointment tbl_appointment = db.tbl_appointment.Find(id);
            if (tbl_appointment == null)
            {
                return HttpNotFound();
            }
            return View(tbl_appointment);
        }

        // GET: tbl_appointment/Create
        public ActionResult Create()
        {
            ViewBag.docid = new SelectList(db.tbl_Doctor, "id", "name");
            ViewBag.patient_id = new SelectList(db.tbl_Patient, "id", "name");
            //SelectList(collection,value,display
            return View();
        }

        // POST: tbl_appointment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "app_id,docid,patient_id,app_date,app_time")] tbl_appointment tbl_appointment)
        {
            if (ModelState.IsValid)
            {
                db.tbl_appointment.Add(tbl_appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.docid = new SelectList(db.tbl_Doctor, "id", "name", tbl_appointment.docid);
            ViewBag.patient_id = new SelectList(db.tbl_Patient, "id", "name", tbl_appointment.patient_id);
            return View(tbl_appointment);
        }

        // GET: tbl_appointment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_appointment tbl_appointment = db.tbl_appointment.Find(id);
            if (tbl_appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.docid = new SelectList(db.tbl_Doctor, "id", "name", tbl_appointment.docid);
            ViewBag.patient_id = new SelectList(db.tbl_Patient, "id", "name", tbl_appointment.patient_id);
            return View(tbl_appointment);
        }

        // POST: tbl_appointment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "app_id,docid,patient_id,app_date,app_time")] tbl_appointment tbl_appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.docid = new SelectList(db.tbl_Doctor, "id", "name", tbl_appointment.docid);
            ViewBag.patient_id = new SelectList(db.tbl_Patient, "id", "name", tbl_appointment.patient_id);
            return View(tbl_appointment);
        }

        // GET: tbl_appointment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_appointment tbl_appointment = db.tbl_appointment.Find(id);
            if (tbl_appointment == null)
            {
                return HttpNotFound();
            }
            return View(tbl_appointment);
        }

        // POST: tbl_appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_appointment tbl_appointment = db.tbl_appointment.Find(id);
            db.tbl_appointment.Remove(tbl_appointment);
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
