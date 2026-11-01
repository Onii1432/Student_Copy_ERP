using System.Collections.Generic;
using StandardMetals.DAL;
using StandardMetals.MODEL;
using StandardMetals.CommonLibrary;

namespace StandardMetals.BAL
{
    public class ItemMaster17Dec_BAL
    {
        ItemList17Dec_Dal ItemList17Dec_Dal = ItemList17Dec_Dal.GetInstance();

        // Get All Item Master Data

        public List<ItemMaster_Modal_AprBtch> GetAllItemMaster()
        {
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-GetAllItemMaster - Start");

            List<ItemMaster_Modal_AprBtch> result = ItemList17Dec_Dal.GetAllItemMasterDAL();

            LogInfo.LogDetailToFile("GetAllItemMaster - Item List Loaded");
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-GetAllItemMaster - Start-End");

            return result;
        }

        // Get Item Details By ID

        public ItemMaster_Modal_AprBtch GetItemDetailsById(int id)
        {
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-GetItemDetailsById - Start");
            LogInfo.LogDetailToFile("GetItemDetailsById - Item Id : " + id);

            ItemMaster_Modal_AprBtch result = ItemList17Dec_Dal.GetItemDetailsByID(id);

            LogInfo.LogDetailToFile("GetItemDetailsById - Item Details Loaded");
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-GetItemDetailsById - Start-End");

            return result;
        }

        // Get Existing Supplier Details By ItemId

        public List<SupplierMasterMVCApril2026Model> GetSupplierDetailsByItemId(int itemId)
        {
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-GetSupplierDetailsByItemId - Start");
            LogInfo.LogDetailToFile("GetSupplierDetailsByItemId - Item Id : " + itemId);

            List<SupplierMasterMVCApril2026Model> result = ItemList17Dec_Dal.GetSupplierDetailsByItemId(itemId);

            LogInfo.LogDetailToFile("GetSupplierDetailsByItemId - Supplier Details Loaded");
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-GetSupplierDetailsByItemId - Start-End");

            return result;
        }

        // Get Existing Customer Details By ItemId

        public List<CustomerMasterMVCApril2026Model> GetCustomerDetailsByItemId(int itemId)
        {
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-GetCustomerDetailsByItemId - Start");
            LogInfo.LogDetailToFile("GetCustomerDetailsByItemId - Item Id : " + itemId);

            List<CustomerMasterMVCApril2026Model> result = ItemList17Dec_Dal.GetCustomerDetailsByItemId(itemId);

            LogInfo.LogDetailToFile("GetCustomerDetailsByItemId - Customer Details Loaded");
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-GetCustomerDetailsByItemId - Start-End");

            return result;
        }

        // Save Item Master + Item-Supplier + Item-Customer Mapping

        public string SaveNewItem(ItemMaster_Modal_AprBtch model)
        {
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-SaveNewItem - Start");

            string result = ItemList17Dec_Dal.SaveNewItemDetails(model);

            LogInfo.LogDetailToFile("SaveNewItem - Item Save Completed : " + result);
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-SaveNewItem - Start-End");

            return result;
        }


        // Save Item Master for JQuery Item Master form

        public string SaveItemJW(ItemMaster_Modal_AprBtch model)
        {
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-SaveItemJW - Start");

            string result = ItemList17Dec_Dal.SaveItemJW(model);

            LogInfo.LogDetailToFile("SaveItemJW - Item Save Completed : " + result);
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-SaveItemJW - Start-End");

            return result;
        }

        // Update Existing Item + Item-Supplier + Item-Customer Mapping

        public int UpdateExistingItem(int id, ItemMaster_Modal_AprBtch model)
        {
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-UpdateExistingItem - Start");
            LogInfo.LogDetailToFile("UpdateExistingItem - Item Id : " + id);

            int result = ItemList17Dec_Dal.UpdateItemDetails(id, model);

            LogInfo.LogDetailToFile("UpdateExistingItem - Update Result : " + result);
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-UpdateExistingItem - Start-End");

            return result;
        }


        // Update Item for JQuery Item Master form

        public string UpdateItemJW(int id, ItemMaster_Modal_AprBtch model)
        {
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-UpdateItemJW - Start");
            LogInfo.LogDetailToFile("UpdateItemJW - Item Id : " + id);

            string result = ItemList17Dec_Dal.UpdateItemJW(id, model);

            LogInfo.LogDetailToFile("UpdateItemJW - Update Result : " + result);
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-UpdateItemJW - Start-End");

            return result;
        }


        // Getting Data for DropDown List

        public List<ItemMaster_Modal_AprBtch> GetAllColours()
        {
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-GetAllColours - Start");

            List<ItemMaster_Modal_AprBtch> result = ItemList17Dec_Dal.GetColours();

            LogInfo.LogDetailToFile("GetAllColours - Colour Data Loaded");
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-GetAllColours - Start-End");

            return result;
        }

        public List<ItemMaster_Modal_AprBtch> GetManufacturerDetails()
        {
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-GetManufacturerDetails - Start");

            List<ItemMaster_Modal_AprBtch> result = ItemList17Dec_Dal.GetManufacturer();

            LogInfo.LogDetailToFile("GetManufacturerDetails - Manufacturer Data Loaded");
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-GetManufacturerDetails - Start-End");

            return result;
        }

        public List<ItemMaster_Modal_AprBtch> GetCategoriesDetails()
        {
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-GetCategoriesDetails - Start");

            List<ItemMaster_Modal_AprBtch> result = ItemList17Dec_Dal.GetCategories();

            LogInfo.LogDetailToFile("GetCategoriesDetails - Category Data Loaded");
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-GetCategoriesDetails - Start-End");

            return result;
        }

        public List<ItemMaster_Modal_AprBtch> GetSubCategoriesDetails(int id)
        {
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-GetSubCategoriesDetails - Start");
            LogInfo.LogDetailToFile("GetSubCategoriesDetails - Category Id : " + id);

            List<ItemMaster_Modal_AprBtch> result = ItemList17Dec_Dal.GetSubCategories(id);

            LogInfo.LogDetailToFile("GetSubCategoriesDetails - Sub Category Data Loaded");
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-GetSubCategoriesDetails - Start-End");

            return result;
        }

        public List<ItemMaster_Modal_AprBtch> GetUnitDetails()
        {
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-GetUnitDetails - Start");

            List<ItemMaster_Modal_AprBtch> result = ItemList17Dec_Dal.GetUnit();

            LogInfo.LogDetailToFile("GetUnitDetails - Unit Data Loaded");
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-GetUnitDetails - Start-End");

            return result;
        }

        // For JQuery Project - Get Item Codes

        public List<ItemMaster_Modal_AprBtch> GetItemCodes()
        {
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-GetItemCodes - Start");

            List<ItemMaster_Modal_AprBtch> result = ItemList17Dec_Dal.getItemCodes();

            LogInfo.LogDetailToFile("GetItemCodes - Item Codes Loaded");
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-GetItemCodes - Start-End");

            return result;
        }

        // For JQuery Project - Get Item Names

        public List<ItemMaster_Modal_AprBtch> GetItemNames()
        {
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-GetItemNames - Start");

            List<ItemMaster_Modal_AprBtch> result = ItemList17Dec_Dal.getItemNames();

            LogInfo.LogDetailToFile("GetItemNames - Item Names Loaded");
            LogInfo.LogDetailToFile("ItemMaster17DecBAL-GetItemNames - Start-End");

            return result;
        }

    }
}