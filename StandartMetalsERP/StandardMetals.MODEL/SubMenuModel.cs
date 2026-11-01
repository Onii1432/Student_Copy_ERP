using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace StandardMetals.MODEL
{
    public class SubMenuModel
    {
         
        public int SubMenuId { get; set; }
        public string SubMenuName { get; set; }
        public string SubMenuLink { get; set; }
        public string Action { get; set; }
        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }
        public string BranchName { get; set; }
        public int MasterMenuId { get; set; }

    }
}
