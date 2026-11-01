using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace StandardMetals.MODEL
{
  public  class RoleMasterModel
    {
        [Display(Name ="Search Role")]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public int RoleAccessDetailId { get; set; }
        public int MasterMenuId { get; set; }
        public int SubMasterMenuId { get; set; }
        public bool AddAccess { get; set; }
        public bool UpdateAccess { get; set; }
        public bool DeleteAccess { get; set; }
        public bool SearchAccess { get; set; }
        public List<RoleMasterModel> getAccessDtl { get; set; }
        
    }
}
