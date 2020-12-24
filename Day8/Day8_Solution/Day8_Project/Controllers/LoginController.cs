using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day8_Project.Models;

namespace Day8_Project.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
       
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(tblUser user)
        {
            dbHospitalEntities entities = new dbHospitalEntities();
            proc_LoginCheck_Result res = entities.proc_LoginCheck(user.username, user.password).FirstOrDefault();
            if(res!=null)
            {
                ViewBag.Error = "";
                TempData["username"] = user.username;
                if(res.role=="patient")
                {
                    if(res.status == "active")
                    {
                        return RedirectToAction("Index", "Patient");
                    }
                    else
                    {
                        TempData["username"] = "";
                        ViewBag.Error = "User is not active";
                    }
                }
                else
                    return RedirectToAction("Index", "Doctor");
            }
            else
            {
                ViewBag.Error = "Invalid username or password";
            }
            return View();
        }
    }
}