using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFirstAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        static List<string> names = new List<String>() { "Ramu", "Somu", "Bimu", "Komu" };
        public IEnumerable<string> Get()
        {
            return names;
        }

        public void Post(string name)
        {
            names.Add(name);
        }

        public void Put(int id,string name)
        {
            names[id] = name;
        }

        public void Delete(int id)
        {
            names.RemoveAt(id);
        }
    }
}
