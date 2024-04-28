using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Inventory_Management_system.Models.ValidationClasses
{
    [MetadataType(typeof(ManagerRegiValid))]
    public partial class tblManager
    {
       
    }

    public class ManagerRegiValid
    {
        [Key]
        [DisplayName("Manager Id")]
        public int ManId { get; set; }

        [Required]
        [DisplayName("Name")]
        public string ManName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Mobile Number")]
        public string ManMobile { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email Address")]
        public string ManEmail { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("DOB")]
        public System.DateTime ManDOB { get; set; }

        [Required]
        [DisplayName("Gender")]
        public string ManGender { get; set; }

        [DisplayName("Salary")]
        public Nullable<int> ManSalary { get; set; }

        [Required]
        public int QualificationId { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> ManJoiningDate { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string ManPassword { get; set; }

        [DisplayName("Active Status")]
        public bool ManDeleted { get; set; }

        public int RoleId { get; set; }

        public string Degree {  get; set; }

        public string RoleName { get; set; }


        public virtual tblQualification tblQualification { get; set; }
        public virtual tblRole tblRole { get; set; }
    }
}