using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstWebMVCProject.Models;

namespace FirstWebMVCProject.Controllers
{
    public class CustomerController : Controller
    {
        List<Customer> customers = new List<Customer>() { 
            new Customer(101,"Ramu","9876543210"),
            new Customer(102,"Somu","1234567890"),
            new Customer(103,"Bimu","6789012345"),
            new Customer(104,"Komu","5432109876"),
        };
        public ActionResult DisplayCustomers()
        {
            return View(customers);
        }
        public ActionResult DisplayCustomerAnother()
        {
            Customer customer = new Customer(102, "Somu", "9876543210");
            return View(customer);
        }
        public ActionResult ShowCustomer()
        {
            Customer customer = new Customer(101, "Ramu", "1234567890");
           // ViewBag.customer = customer;
            return View(customer);
        }

        // GET: Customer
        public String MyCustomer()
        {
            return "Hello World!!!!";
        }
       
        [ActionName("AboutUs")]
        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult WelcomePage()
        {
            string myName = "Ramu";
            ViewData["customername"] = myName;
            int age = 21;
            ViewBag.customerage = age;
            int[] numArr = { 10, 23, 45, 67, 89 };
            ViewData["nums"] = numArr;
            ViewBag.myNums = numArr;
            return View();
        }
    }
}