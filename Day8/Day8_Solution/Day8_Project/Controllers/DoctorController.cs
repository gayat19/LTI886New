using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day8_Project.Models;

namespace Day8_Project.Controllers
{
    public class DoctorController : Controller
    {
        dbHospitalEntities entities = new dbHospitalEntities();
        // GET: Doctor
        public ActionResult Index()
        {
            ViewBag.user = TempData.Peek("username");
            return View(entities.tblDoctors.ToList()) ;
        }
        public ActionResult Details()
        {
            string un = TempData.Peek("username").ToString();
            tblDoctor doctor = entities.tblDoctors.Where(d => d.username == un).FirstOrDefault();
            return View(doctor);
        }
    }
}