using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Day9_Project.Models
{
    [MetadataType(typeof(tblUserMetaData))]
    public partial class tblUser
    {

    }
    public class tblUserMetaData
    {
        [Required(ErrorMessage ="Username is mandit")]
        public string username { get; set; }
        [Required(ErrorMessage = "Password is mandit")]
        public string password { get; set; }
        [Required(ErrorMessage = "Role is mandit")]
        public string role { get; set; }
    }
}