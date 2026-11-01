using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace StandardMetals.BAL
{
  public  class SupplierMasterBAL05Oct
    {
      SupplierMasterDAL05Oct _dbSupplier = new SupplierMasterDAL05Oct();

      public DataTable FillSupplier(string SuppCode)
      {
          return _dbSupplier.FillSupplier(SuppCode);
      }


      public int SaveSupplierMaster(SupplierMasterDAL05Oct suppliermst)
      {
          return _dbSupplier.SaveSupplierMaster(suppliermst);
      }

     
  }
}
