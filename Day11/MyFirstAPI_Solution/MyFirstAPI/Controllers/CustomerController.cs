using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyFirstAPI.Models;
using System.Web.Http.Cors;

namespace MyFirstAPI.Controllers
{
    [EnableCors(origins:"http://localhost:4200",headers:"*",methods:"*")]
    public class CustomerController : ApiController
    {
        dbWebAPIEntities entities = new dbWebAPIEntities();

        public IEnumerable<Customer> Get()
        {
            return entities.Customers.ToList();
        }
        public Customer Get(int id)
        {
            Customer customer = entities.Customers.Where(c => c.id == id).FirstOrDefault();
            return customer;
        }

        public void Post(Customer customer)
        {
            entities.Customers.Add(customer);
            entities.SaveChanges();
        }

        public void Put(int id,Customer customer)//id from the url and object from the body
        {
            Customer UpdateCustomer = entities.Customers.Find(id);
            UpdateCustomer.name = customer.name;
            UpdateCustomer.age = customer.age;
            entities.SaveChanges();
        }

    }
}
