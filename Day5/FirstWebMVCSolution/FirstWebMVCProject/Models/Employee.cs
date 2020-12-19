using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstWebMVCProject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Employee() { }

        public Employee(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
    }
}