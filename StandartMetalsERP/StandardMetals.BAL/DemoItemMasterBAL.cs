using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using Modal;


namespace StandardMetals.BAL
{
   public  class DemoItemMasterBAL
    {

       DemoItemMasterDAL dal = new DemoItemMasterDAL();


       public DataTable FillItemMaster()
       {
           return dal.FillItemMaster();
       }

       public DataTable BindItemMasterByCode(string ItemCode)
       {
           return dal.BindItemMasterByCode(ItemCode);
       }

       public int SaveItemMaster(DemoItemMasterModel model)
       {
           return dal.SaveItemMaster(model);
       }
       public int UpdateItemMaster(DemoItemMasterModel model)
       {
           return dal.UpdateItemMaster(model);
       }
    }
}
