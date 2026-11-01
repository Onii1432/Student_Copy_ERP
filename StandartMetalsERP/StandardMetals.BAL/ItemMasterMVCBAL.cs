using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StandardMetals.DAL;
using StandardMetals.MODEL;

namespace StandardMetals.BAL
{
   public class ItemMasterMVCBAL
    {
        ItemmasterMVCDAL dal = new ItemmasterMVCDAL();

        public List<ItemMasterMVCModal> GetAllItemMaster()
        {
            return dal.GetAllItemMasterDAL();
        }

        public ItemMasterMVCModal GetItemDetailsByID(int id)
        {
            return dal.GetItemDetailsByID(id);
        }


        public int SaveNewItem(ItemMasterMVCModal model)
        {
            return dal.SaveNewItemDetails(model);
        }

        public int UpdateExistingItem(int itemId, ItemMasterMVCModal model)
        {
            return dal.UpdateItemDetails(itemId, model);
        }

        // Getting Data for drop down list

        public List<ItemMasterMVCModal> GetAllColours()
        {
            return dal.GetColours();
        }

        public List<ItemMasterMVCModal> GetManufacturerDetails()
        {
            return dal.GetManufacturer();
        }

        public List<ItemMasterMVCModal> GetCategoriesDetails()
        {
            return dal.GetCategories();
        }

        public List<ItemMasterMVCModal> GetSubCategoriesDetails(int categoryId)
        {
            return dal.GetSubCategories(categoryId);
        }

        public List<ItemMasterMVCModal> GetUnitDetails()
        {
            return dal.GetUnit();
        }


        ///// For JQUERY Projects
        ///

        // Getting all the available ItemCodes
        public List<ItemMasterMVCModal> getItemCodes()
        {
            return dal.getItemCodes();
        }

        // Getting all the available ItemNames
        public List<ItemMasterMVCModal> getItemNames()
        {
            return dal.getItemNames();
        }
    }
}
