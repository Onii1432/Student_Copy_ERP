// 16/08/2026

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StandardMetals.BAL;
using StandardMetals.MODEL;
using StandardMetals.CommonLibrary;
using StandardMetals.WebAPI.AuthFilter;

namespace StandardMetals.WebAPI.Controllers
{

    [BasicAuthentication]
    public class ItemMaster17DecApiController : ApiController
    {
        ItemMaster17Dec_BAL itemBAL = new ItemMaster17Dec_BAL();


        // GET http://localhost:62335/ItemMaster17DecApi/GetAllItemMaster

        [HttpGet]
        public List<ItemMaster_Modal_AprBtch> GetAllItemMaster()
        {
            LogInfo.LogDetailToFile("ItemMaster17DecApiController-GetAllItemMaster Action(httpget)- Start");

            List<ItemMaster_Modal_AprBtch> result = itemBAL.GetAllItemMaster();

            LogInfo.LogDetailToFile("GetAllItemMaster - Item List Loaded");
            LogInfo.LogDetailToFile("ItemMaster17DecApiController-GetAllItemMaster Action(httpget)- Start-End");

            return result;
        }


        // GET http://localhost:62335/ItemMaster17DecApi/GetItemById/30645

        [HttpGet]
        public ItemMaster_Modal_AprBtch GetItemById(int id)
        {
            LogInfo.LogDetailToFile("ItemMaster17DecApiController-GetItemById Action(httpget)- Start");

            LogInfo.LogDetailToFile("GetItemById - Item Id : " + id);

            ItemMaster_Modal_AprBtch result = itemBAL.GetItemDetailsById(id);

            LogInfo.LogDetailToFile("GetItemById - Item Details Loaded");
            LogInfo.LogDetailToFile("ItemMaster17DecApiController-GetItemById Action(httpget)- Start-End");

            return result;
        }


        // POST http://localhost:62335/ItemMaster17DecApi/CreateItem

        [HttpPost]
        public string CreateItem(ItemMaster_Modal_AprBtch model)
        {
            LogInfo.LogDetailToFile("ItemMaster17DecApiController-CreateItem Action(httppost)- Start");

            string result = itemBAL.SaveNewItem(model);

            LogInfo.LogDetailToFile("CreateItem - Item Save Completed : " + result);
            LogInfo.LogDetailToFile("ItemMaster17DecApiController-CreateItem Action(httppost)- Start-End");

            return result;
        }


        // PUT http://localhost:62335/ItemMaster17DecApi/UpdateItem/30645

        [HttpPut]
        public int UpdateItem(int id, ItemMaster_Modal_AprBtch model)
        {
            LogInfo.LogDetailToFile("ItemMaster17DecApiController-UpdateItem Action(httpput)- Start");

            LogInfo.LogDetailToFile("UpdateItem - Item Id : " + id);

            int result = itemBAL.UpdateExistingItem(id, model);

            LogInfo.LogDetailToFile("UpdateItem - Update Result : " + result);
            LogInfo.LogDetailToFile("ItemMaster17DecApiController-UpdateItem Action(httpput)- Start-End");

            return result;
        }


        // Getting Data for DropDown List

        // GET http://localhost:62335/ItemMaster17DecApi/GetAllColours

        [HttpGet]
        public List<ItemMaster_Modal_AprBtch> GetAllColours()
        {
            LogInfo.LogDetailToFile("ItemMaster17DecApiController-GetAllColours Action");

            return itemBAL.GetAllColours();
        }


        // GET http://localhost:62335/ItemMaster17DecApi/GetManufacturerDetails

        [HttpGet]
        public List<ItemMaster_Modal_AprBtch> GetManufacturerDetails()
        {
            LogInfo.LogDetailToFile("ItemMaster17DecApiController-GetManufacturerDetails Action");

            return itemBAL.GetManufacturerDetails();
        }


        // GET http://localhost:62335/ItemMaster17DecApi/GetCategoriesDetails

        [HttpGet]
        public List<ItemMaster_Modal_AprBtch> GetCategoriesDetails()
        {
            LogInfo.LogDetailToFile("ItemMaster17DecApiController-GetCategoriesDetails Action");

            return itemBAL.GetCategoriesDetails();
        }


        // GET http://localhost:62335/ItemMaster17DecApi/GetSubCategoriesDetails/1

        [HttpGet]
        public List<ItemMaster_Modal_AprBtch> GetSubCategoriesDetails(int id)
        {
            LogInfo.LogDetailToFile("ItemMaster17DecApiController-GetSubCategoriesDetails Action");

            LogInfo.LogDetailToFile("GetSubCategoriesDetails - Category Id : " + id);

            return itemBAL.GetSubCategoriesDetails(id);
        }


        // GET http://localhost:62335/ItemMaster17DecApi/GetUnitDetails

        [HttpGet]
        public List<ItemMaster_Modal_AprBtch> GetUnitDetails()
        {
            LogInfo.LogDetailToFile("ItemMaster17DecApiController-GetUnitDetails Action");

            return itemBAL.GetUnitDetails();
        }


        // For JQuery Project
        // GET http://localhost:62335/ItemMaster17DecApi/GetItemCodes

        [HttpGet]
        public List<ItemMaster_Modal_AprBtch> GetItemCodes()
        {
            LogInfo.LogDetailToFile("ItemMaster17DecApiController-GetItemCodes Action");

            return itemBAL.GetItemCodes();
        }


        // For JQuery Project
        // GET http://localhost:62335/ItemMaster17DecApi/GetItemNames

        [HttpGet]
        public List<ItemMaster_Modal_AprBtch> GetItemNames()
        {
            LogInfo.LogDetailToFile("ItemMaster17DecApiController-GetItemNames Action");

            return itemBAL.GetItemNames();
        }

    }
}