using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Da6_Question.Models;

namespace Da6_Question.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        dbTrainingEntities entities = new dbTrainingEntities();
        public ActionResult UserLogin()
        {
            tbl_user user = new tbl_user();
            return View(user);
        }
        [HttpPost]
        public ActionResult UserLogin(tbl_user user)
        {
            //int userCount = entities.tbl_user.Where(u => u.username == user.username && u.password == user.password).Count();
            int userCount = 
                entities.tbl_user.SqlQuery("Select * from tbl_user where username='" + user.username + "' and password = '" + user.password + "'").Count();
            if (userCount == 1)
            {
                TempData["user"] = user.username;
                return RedirectToAction("UserHome");
            }
            return View();
        }
        public ActionResult UserHome()
        {
            //ViewBag.user = TempData.Peek("user");
            ViewBag.user = TempData["user"];
            TempData.Keep();//1
            return View();
        }
        public ActionResult UserDetails()
        {
            return View();
        }
    }
}