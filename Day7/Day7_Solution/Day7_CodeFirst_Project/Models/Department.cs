using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day7_CodeFirst_Project.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Column("DepName")]
        public string Name { get; set; }
    }
}