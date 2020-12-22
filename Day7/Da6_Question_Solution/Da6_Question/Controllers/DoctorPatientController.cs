using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Da6_Question.Models;

namespace Da6_Question.Controllers
{
    public class DoctorPatientController : Controller
    {
        // GET: DoctorPatient
        dbTrainingEntities entities = new dbTrainingEntities();
        public ActionResult Index()
        {
            List<proc_GetDoctorWisePatienst_Result> dpList = entities.proc_GetDoctorWisePatienst().ToList();
            return View(dpList);
        }
    }
}