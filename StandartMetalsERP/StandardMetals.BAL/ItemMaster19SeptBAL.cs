using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using StandardMetals.MODEL;
using StandardMetals.DAL;

namespace StandardMetals.BAL
{
    public class ItemMaster19SeptBAL
    {
        ItemMaster19SeptDAL _dbItem = new ItemMaster19SeptDAL();

       public int SaveITemMaster(ItemMaster19SeptDAL itemmst)
       {
           return _dbItem.SaveItemMaster(itemmst);
       }

       public DataTable FillItem(string CmpCode, string ItemName,string ItemType,string ItemSubType)
       {
           return _dbItem.FillItem(CmpCode, ItemName, ItemType, ItemSubType);
       }


       public DataTable FillCategory(int CategoryId)
       {
           return _dbItem.FillCategory(CategoryId);
       }

       public DataTable FillManufacturer()
       {
           return _dbItem.FillManufacturer();
       }

       public DataTable FillColour()
       {
           return _dbItem.FillColour();
       }

       public DataTable FillUOM()
       {
           return _dbItem.FillUOM();
       }

       public DataTable FillItemMasterdetail(string CmpCode, string ItemName, string ItemType, string ItemSubType,int flag)
       {
           return _dbItem.FillItemMasterdetail(CmpCode, ItemName, ItemType, ItemSubType, flag);
       }
       public DataTable RetriveItem(string ItemCode)
       {
           return _dbItem.RetriveItem(ItemCode);
       }

       public DataTable GetMaxItemNumber(string RawMaterial)
       {
           return _dbItem.GetMAXItemNumber(RawMaterial);
       }  
    }
    }

