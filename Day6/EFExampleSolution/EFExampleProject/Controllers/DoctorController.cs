using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFExampleProject.Models;

namespace EFExampleProject.Controllers
{
    public class DoctorController : Controller
    {
        dbTrainingEntities entities = new dbTrainingEntities();
        // GET: Doctor
        public ActionResult Index()
        {

            return View(entities.tbl_Doctor.ToList());
        }
        public ActionResult Create()
        {
            tbl_Doctor doc = new tbl_Doctor();
            return View(doc);
        }
        [HttpPost]
        public ActionResult Create(tbl_Doctor doc)
        {
            entities.proc_Insert_Doctor(doc.name, doc.years_of_exp);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            tbl_Doctor doc = entities.tbl_Doctor.Find(id);
            return View(doc);
        }
        [HttpPost]
        public ActionResult Edit(int id,tbl_Doctor doc)
        {
            entities.Entry(doc).State = System.Data.Entity.EntityState.Modified;
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}