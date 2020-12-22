using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Day7_CodeFirst_Project.Models
{
    [Table("EmployeeDetails")]
    public class Employee
    {
        public int Id { get; set; }


        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public virtual Department Department { get; set; }
    }
}