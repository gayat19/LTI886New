using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFExampleProject.Models
{
    public class DoctorPatient
    {
        public int Doctor_Id { get; set; }
        public List<tbl_Patient> Patients { get; set; }
       
        public DoctorPatient(int id)
        {
            Doctor_Id = id;
        }
    }
}