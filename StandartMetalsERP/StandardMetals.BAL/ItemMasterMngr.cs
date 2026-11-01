using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using StandardMetals.MODEL;
using StandardMetals.DAL;

namespace StandardMetals.BAL
{
   public class ItemMasterMngr
    {
       dbItemMaster _dbItem = new dbItemMaster();


        //public DataTable BindSubCategory()
        //{
        //    return _dbItem.BindSubCategory();
        //}
        public DataTable BindCategory(int CategoryId)
        {
            return _dbItem.BindCategory(CategoryId);
        }
        public DataTable BindUom()
        {
            return _dbItem.BindUom();
        }

        public DataTable BindColor()
        {
            return _dbItem.BindColor();
        }
        public DataTable BindManfacturer()
        {
            return _dbItem.BindManfacturer();
        }
        public DataTable ItemMasterFill()
        {
            return _dbItem.ItemMasterFill();
        }

        public int UpdateDataGridView(ItemMasterModel UpdateGridViewData)
        {
            return _dbItem.UpdateDataGridView(UpdateGridViewData);
        }
        public int SaveGridViewData(ItemMasterModel SaveGridViewData)
        {
            return _dbItem.SaveGridViewData(SaveGridViewData);
        }
        public int SaveITemMaster(ItemMasterModel dbItemMaster)
       {
           return _dbItem.SaveItemMaster(dbItemMaster);
       }

        public int Update_ItemMaster(ItemMasterModel ItemMaster)
        {
            return _dbItem.Update_ItemMaster(ItemMaster);
        }

        public DataTable FillItem(string CmpCode, string ItemName,string ItemType,string ItemSubType)
       {
           return _dbItem.FillItem(CmpCode, ItemName, ItemType, ItemSubType);
       }


       public DataTable FillCategory(int CategoryId)
       {
           return _dbItem.FillCategory(CategoryId);
       }

       public int CheckDupItem(string ItemName, String ItemCode)
       {
           return _dbItem.CheckDupItem(ItemName, ItemCode);
       }


       public DataTable FillItemMasterdetail(string CmpCode, string ItemName, string ItemType, string ItemSubType,int flag)
       {
           return _dbItem.FillItemMasterdetail(CmpCode, ItemName, ItemType, ItemSubType, flag);
       }

        public DataTable RetrieveDataByItemCode(int ID)
        {
            return _dbItem.RetrieveDataByItemCode(ID);
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
