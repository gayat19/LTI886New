using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day13_Project.Models
{
    public class CustomerUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}