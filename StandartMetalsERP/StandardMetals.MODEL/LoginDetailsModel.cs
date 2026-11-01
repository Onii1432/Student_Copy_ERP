using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace StandardMetals.MODEL
{

    public class LoginMaster
    { 
        [Required(ErrorMessage ="Please Enter User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
        public string BranchName { get; set; }
        public int BranchId { get; set; }
        public string EmpCode { get; set; }
        public int LoginUserId { get; set; }
        public string LoginStatus { get; set; }

    }


    public class LoginDetailsModel
    {
        public int MasterMenuId { get; set; }
        public string MenuName { get; set; }

        public bool IsMaster { get; set; }
        public int SubMasterMenuId { get; set; }
        public string SubMenuName { get; set; }
        public string MenuLink { get; set; }

        public bool AddAccess { get; set; }
        public bool UpdateAccess { get; set; }
        public bool DeleteAccess { get; set; }
        public bool SearchAccess { get; set; }
    }
}
