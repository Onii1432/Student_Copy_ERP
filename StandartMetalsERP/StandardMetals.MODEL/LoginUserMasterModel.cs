using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace StandardMetals.MODEL
{
    
    public class LoginUserMasterModel
    {

        public int LoginUserId { get; set; }
        [Display(Name ="Login User Name")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        public string  ConfirmPassword { get; set; }
        public string RoleName { get; set; }
        [Display (Name ="Search Role")]
        public int RoleId { get; set; }
        [Display(Name ="IsActive")]
        public bool IsActive  { get; set; }
        [Display(Name = "Employeee Name")]

        public int EmployeeId { get; set; }
        public int BranchId { get; set; }
        public DateTime SystemEntryDate { get; set; }



    }


}
