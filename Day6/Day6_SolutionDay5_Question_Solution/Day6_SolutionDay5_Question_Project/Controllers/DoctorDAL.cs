using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Day6_SolutionDay5_Question_Project.Models;
using System.Configuration;

namespace Day6_SolutionDay5_Question_Project.Controllers
{
    public class DoctorDAL
    {
        SqlConnection conn;
        SqlDataAdapter daDoctor;
        public DoctorDAL()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conDoc"].ConnectionString);
        }
        public List<Doctor> GetAllDoctorsFromDatabase()
        {
            List<Doctor> doctors = new List<Doctor>();
            daDoctor = new SqlDataAdapter("Select * from tbl_doctor", conn);
            DataSet dsDoctors = new DataSet();
            daDoctor.Fill(dsDoctors);
            Doctor doctor;
            foreach (DataRow item in dsDoctors.Tables[0].Rows)
            {
                doctor = new Doctor();
                doctor.Id = Convert.ToInt32(item[0]);
                doctor.Name = item["name"].ToString();
                doctor.Exp = float.Parse(item[2].ToString());
                doctors.Add(doctor);
            }
            return doctors;
        }
        public void InsertDoctorToTable(Doctor doctor)
        {
            SqlCommand cmdInsertDoctor = new SqlCommand("proc_Insert_Doctor", conn);
            cmdInsertDoctor.CommandType = CommandType.StoredProcedure;
            cmdInsertDoctor.Parameters.AddWithValue("@dname", doctor.Name);
            cmdInsertDoctor.Parameters.AddWithValue("@exp", doctor.Exp);
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                cmdInsertDoctor.ExecuteNonQuery();
            }
            catch (Exception)
            {   

            }
            finally
            {
                conn.Close();
            }
        }
        public void UpdateDoctorDetailsInTable(Doctor doctor)
        {
            SqlCommand cmdUpdatetDoctor = new SqlCommand("proc_Update_Doctor_Exp", conn);
            cmdUpdatetDoctor.CommandType = CommandType.StoredProcedure;
            cmdUpdatetDoctor.Parameters.AddWithValue("@did", doctor.Id);
            cmdUpdatetDoctor.Parameters.AddWithValue("@exp", doctor.Exp);
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                cmdUpdatetDoctor.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
        }
    }
}