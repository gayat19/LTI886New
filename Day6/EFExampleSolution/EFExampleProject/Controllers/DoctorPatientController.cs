using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFExampleProject.Models;

namespace EFExampleProject.Controllers
{
    public class DoctorPatientController : Controller
    {
        // GET: DoctorPatient
        dbTrainingEntities entities = new dbTrainingEntities();
        public ActionResult Index()
        {
            List<DoctorPatient> dpList = new List<DoctorPatient>();
            foreach (tbl_Doctor doctor in entities.tbl_Doctor)
            {
                dpList.Add(new DoctorPatient(doctor.id));
            }
            for (int i = 0; i < dpList.Count; i++)
            {
                int id = dpList[i].Doctor_Id;
                var patiens = entities.tbl_appointment.Where(app => app.docid == id);
                dpList[i].Patients = new List<tbl_Patient>();
                foreach (var p in patiens)
                {
                    dpList[i].Patients.Add(p.tbl_Patient);
                }
            }

            return View(dpList);
        }
    }
}