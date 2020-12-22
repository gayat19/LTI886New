using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day7_CodeFirst_Project.Models;

namespace Day7_CodeFirst_Project.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        CompanyContext company = new CompanyContext();
        public ActionResult Index()
        {
            return View(company.Employees.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            company.Employees.Add(employee);
            company.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}