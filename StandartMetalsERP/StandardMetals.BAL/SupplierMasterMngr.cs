using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace StandardMetals.BAL
{
   
   public class SupplierMasterMngr
    {
       dbSupplierMaster objdbSupplierMaster = new dbSupplierMaster();

       public int InsertSupplierMaster(dbSupplierMaster objdbSupplierMaster)
       {
           return objdbSupplierMaster.SaveSupplierMaster(objdbSupplierMaster);
       }
       public int UpdateSupplierMaster(dbSupplierMaster objdbSupplierMaster)
       {
           return objdbSupplierMaster.UpdateSupplierMaster(objdbSupplierMaster);
       }

       public DataTable FillSupplier(dbSupplierMaster objdbSupplierMaster)
       {
           return objdbSupplierMaster.FillSupplier(objdbSupplierMaster);
       }
       public DataTable RetriveSuppDetails(string SupCode)
       {
           return objdbSupplierMaster.ReteiveSupplierData(SupCode);
       }
       public DataTable GetMaxSuppNumber()
       {
           return objdbSupplierMaster.GetMAXSuppNumber();
       }
    }
}
