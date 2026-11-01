using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace StandardMetals.MODEL
{
   public  class MenuMasterModel
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        [Display(Name ="IsActive")]
        public bool IsActive { get; set; }
        public string BranchName { get; set; }

    }
}
