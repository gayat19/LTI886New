using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day8_Project.Models;

namespace Day8_Project.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        dbHospitalEntities entities = new dbHospitalEntities();
        public ActionResult Index()
        {
            ViewBag.user = TempData.Peek("username");
            return View(entities.tblPatients.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}