using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Day13_Project.Models;

namespace Day13_Project.Controllers
{
    [RoutePrefix("Gayathri")]
    public class CustomerUserController : ApiController
    {
        dbWebAPIEntities entities = new dbWebAPIEntities();
        public HttpResponseMessage CustomerUserPost(CustomerUser customerUser)
        {
            DbContextTransaction transaction = entities.Database.BeginTransaction();
            try
            {
                Customer customer = new Customer();
                customer.name = customerUser.Name;
                customer.age = customerUser.Age;
                entities.Customers.Add(customer);
                entities.SaveChanges();

                tblUser user = new tblUser();
                user.userid = customerUser.Name;
                user.password = customerUser.Password;
                user.role = customerUser.Role;
                entities.tblUsers.Add(user);
                entities.SaveChanges();

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Could not Insert into the table");
            }
            return Request.CreateResponse(HttpStatusCode.Created, customerUser);
        }
        [HttpGet]
        public HttpResponseMessage MethodCheck()
        {
            List<CustomerUser> customerUsers = new List<CustomerUser>();
            CustomerUser customerUser = null;
            foreach (var item in entities.tblUsers)
            {
                customerUser = new CustomerUser();
                customerUser.Name = item.userid;
                customerUser.Role = item.role;
                customerUser.Password = item.password;
                Customer customer = entities.Customers.ToList().Find(cust => cust.name == item.userid);
                customerUser.Age = (int)customer.age;
                customerUser.Id = customer.id;
                customerUsers.Add(customerUser);
            }
            return Request.CreateResponse(HttpStatusCode.OK,customerUsers);
        }
        public HttpResponseMessage Put([FromUri] string uname,CustomerUser customerUser)
        {
            DbContextTransaction transaction = entities.Database.BeginTransaction();
            try
            {
                Customer customer = entities.Customers.Where(u => u.name == uname).FirstOrDefault();
                customer.age = customerUser.Age;
                entities.SaveChanges();

                tblUser user = entities.tblUsers.Where(u=>u.userid==uname).FirstOrDefault();
                user.password = customerUser.Password;
                user.role = customerUser.Role;
                entities.SaveChanges();

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not update the table");
            }
            return Request.CreateResponse(HttpStatusCode.Accepted, customerUser);
        }

        
        public HttpResponseMessage Get(int something,[FromBody]int anything)
        {
            CustomerUser user = new CustomerUser();
            user.Id = something;
            user.Age = anything;
            return Request.CreateResponse<CustomerUser>(HttpStatusCode.OK, user) ;
        }
        [Route("GetAllCustomerUser")]
        public string Get()
        {
            return "Routing in attribute";
        }
        [Route("RemoveCust")]
        [HttpDelete]
        public HttpResponseMessage DelCustAndUser(string uname)
        {
            DbContextTransaction transaction = entities.Database.BeginTransaction();
            try
            {
                Customer customer = entities.Customers.Where(u => u.name == uname).FirstOrDefault();
                entities.Customers.Remove(customer);
                entities.SaveChanges();

                tblUser user = entities.tblUsers.Where(u => u.userid == uname).FirstOrDefault();
                entities.tblUsers.Remove(user);
                entities.SaveChanges();

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Unable o delete data");
            }
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }
    }
}
