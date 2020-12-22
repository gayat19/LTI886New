using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Day7_CodeFirst_Project.Models
{
    public class CompanyContext : DbContext
    {
        public CompanyContext() : base("name=empConn")
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}