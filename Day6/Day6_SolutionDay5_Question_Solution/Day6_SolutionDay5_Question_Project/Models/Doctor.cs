using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day6_SolutionDay5_Question_Project.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Exp { get; set; }
        public Doctor() { }

        public Doctor(int id, string name, float exp)
        {
            Id = id;
            Name = name;
            Exp = exp;
        }
    }
}