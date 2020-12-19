using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstWebMVCProject.Models;

namespace FirstWebMVCProject.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> employees = new List<Employee>();
        // GET: Employee
        public ActionResult Index()
        {
            return View(employees);
        }
        public ActionResult Edit(int id)
        {
            Employee employee = employees.Find(e => e.Id == id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(int id,FormCollection formCollection)
        {
            Employee employee = employees.Find(e => e.Id == id);
            employee.Name = formCollection["Name"].ToString();
            employee.Age = Convert.ToInt32(formCollection["Age"].ToString());
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Employee employee = employees.Find(e => e.Id == id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            employees.Remove(employees.Find(e => e.Id == id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]//ActionVerb
        public ActionResult Create(FormCollection formCollection)
        {
            Employee employee = new Employee();
            employee.Id = Convert.ToInt32(formCollection["Id"].ToString());
            employee.Name = formCollection["Name"].ToString();
            employee.Age = Convert.ToInt32(formCollection["Age"].ToString());
            employees.Add(employee);
            return RedirectToAction("Index");
        }
    }
}