using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day6_SolutionDay5_Question_Project.Models;


namespace Day6_SolutionDay5_Question_Project.Controllers
{
    public class DoctorController : Controller
    {
        DoctorDAL dal = new DoctorDAL();
        // GET: Doctor
        public ActionResult Index()
        {
            List<Doctor> doctors = dal.GetAllDoctorsFromDatabase();
            return View(doctors);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Doctor doctor)
        {
            dal.InsertDoctorToTable(doctor);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            List<Doctor> doctors = dal.GetAllDoctorsFromDatabase();
            Doctor doctor = doctors.Find(doc => doc.Id == id);
            return View(doctor);
        }
        [HttpPost]
        public ActionResult Edit(int id,Doctor doctor)
        {
            dal.UpdateDoctorDetailsInTable(doctor);
            return RedirectToAction("Index");
        }
    }
}