﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Da6_Question.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class dbTrainingEntities : DbContext
    {
        public dbTrainingEntities()
            : base("name=dbTrainingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_user> tbl_user { get; set; }
        public virtual DbSet<tbl_appointment> tbl_appointment { get; set; }
        public virtual DbSet<tbl_Doctor> tbl_Doctor { get; set; }
        public virtual DbSet<tbl_Patient> tbl_Patient { get; set; }
    
        public virtual ObjectResult<proc_GetDoctorWisePatienst_Result> proc_GetDoctorWisePatienst()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_GetDoctorWisePatienst_Result>("proc_GetDoctorWisePatienst");
        }
    }
}
