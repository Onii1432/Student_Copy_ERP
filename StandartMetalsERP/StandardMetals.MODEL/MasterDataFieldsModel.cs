using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StandardMetals.MODEL
{
    public   class MasterDataFieldsModel
    {

      public int loginUserId { get; set; }
      public int branchId { get; set; }
      public bool isActive { get; set; }
      public DateTime systemEntryDate { get; set; }

    }
}
