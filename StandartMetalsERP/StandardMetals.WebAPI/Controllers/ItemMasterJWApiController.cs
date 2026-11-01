using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using StandardMetals.BAL;
using StandardMetals.MODEL;
using StandardMetals.CommonLibrary;

namespace StandardMetals.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ItemMasterJWApiController : ApiController
    {
        ItemMaster17Dec_BAL itemBAL = new ItemMaster17Dec_BAL();


        // GET: http://localhost:62335/ItemMasterJWApi/GetItemCodes
        [HttpGet]
        public List<ItemMaster_Modal_AprBtch> GetItemCodes()
        {
            LogInfo.LogDetailToFile("ItemMasterJWApiController-GetItemCodes Action(httpget)- Start");

            List<ItemMaster_Modal_AprBtch> result = itemBAL.GetItemCodes();

            LogInfo.LogDetailToFile("GetItemCodes - Item Codes Loaded");
            LogInfo.LogDetailToFile("ItemMasterJWApiController-GetItemCodes Action(httpget)- Start-End");

            return result;
        }


        // GET: http://localhost:62335/ItemMasterJWApi/GetItemNames
        [HttpGet]
        public List<ItemMaster_Modal_AprBtch> GetItemNames()
        {
            LogInfo.LogDetailToFile("ItemMasterJWApiController-GetItemNames Action(httpget)- Start");

            List<ItemMaster_Modal_AprBtch> result = itemBAL.GetItemNames();

            LogInfo.LogDetailToFile("GetItemNames - Item Names Loaded");
            LogInfo.LogDetailToFile("ItemMasterJWApiController-GetItemNames Action(httpget)- Start-End");

            return result;
        }


        // GET: http://localhost:62335/ItemMasterJWApi/GetManufacturers
        [HttpGet]
        public List<ItemMaster_Modal_AprBtch> GetManufacturers()
        {
            LogInfo.LogDetailToFile("ItemMasterJWApiController-GetManufacturers Action(httpget)- Start");

            List<ItemMaster_Modal_AprBtch> result = itemBAL.GetManufacturerDetails();

            LogInfo.LogDetailToFile("GetManufacturers - Manufacturer Data Loaded");
            LogInfo.LogDetailToFile("ItemMasterJWApiController-GetManufacturers Action(httpget)- Start-End");

            return result;
        }


        // GET: http://localhost:62335/ItemMasterJWApi/GetCategories
        [HttpGet]
        public List<ItemMaster_Modal_AprBtch> GetCategories()
        {
            LogInfo.LogDetailToFile("ItemMasterJWApiController-GetCategories Action(httpget)- Start");

            List<ItemMaster_Modal_AprBtch> result = itemBAL.GetCategoriesDetails();

            LogInfo.LogDetailToFile("GetCategories - Category Data Loaded");
            LogInfo.LogDetailToFile("ItemMasterJWApiController-GetCategories Action(httpget)- Start-End");

            return result;
        }


        // GET: http://localhost:62335/ItemMasterJWApi/GetSubCategories?id=1
        [HttpGet]
        public List<ItemMaster_Modal_AprBtch> GetSubCategories(int id)
        {
            LogInfo.LogDetailToFile("ItemMasterJWApiController-GetSubCategories Action(httpget)- Start");
            LogInfo.LogDetailToFile("GetSubCategories - Category Id : " + id);

            List<ItemMaster_Modal_AprBtch> result = itemBAL.GetSubCategoriesDetails(id);

            LogInfo.LogDetailToFile("GetSubCategories - Sub Category Data Loaded");
            LogInfo.LogDetailToFile("ItemMasterJWApiController-GetSubCategories Action(httpget)- Start-End");

            return result;
        }


        // GET: http://localhost:62335/ItemMasterJWApi/GetColours
        [HttpGet]
        public List<ItemMaster_Modal_AprBtch> GetColours()
        {
            LogInfo.LogDetailToFile("ItemMasterJWApiController-GetColours Action(httpget)- Start");

            List<ItemMaster_Modal_AprBtch> result = itemBAL.GetAllColours();

            LogInfo.LogDetailToFile("GetColours - Colour Data Loaded");
            LogInfo.LogDetailToFile("ItemMasterJWApiController-GetColours Action(httpget)- Start-End");

            return result;
        }


        // GET: http://localhost:62335/ItemMasterJWApi/GetUnits
        [HttpGet]
        public List<ItemMaster_Modal_AprBtch> GetUnits()
        {
            LogInfo.LogDetailToFile("ItemMasterJWApiController-GetUnits Action(httpget)- Start");

            List<ItemMaster_Modal_AprBtch> result = itemBAL.GetUnitDetails();

            LogInfo.LogDetailToFile("GetUnits - Unit Data Loaded");
            LogInfo.LogDetailToFile("ItemMasterJWApiController-GetUnits Action(httpget)- Start-End");

            return result;
        }


        // GET: http://localhost:62335/ItemMasterJWApi/GetItemById?id=1
        [HttpGet]
        public ItemMaster_Modal_AprBtch GetItemById(int id)
        {
            LogInfo.LogDetailToFile("ItemMasterJWApiController-GetItemById Action(httpget)- Start");
            LogInfo.LogDetailToFile("GetItemById - Item Id : " + id);

            ItemMaster_Modal_AprBtch result = itemBAL.GetItemDetailsById(id);

            LogInfo.LogDetailToFile("GetItemById - Item Details Loaded");
            LogInfo.LogDetailToFile("ItemMasterJWApiController-GetItemById Action(httpget)- Start-End");

            return result;
        }


        // POST: http://localhost:62335/ItemMasterJWApi/CreateItem
        [HttpPost]
        public string CreateItem(ItemMaster_Modal_AprBtch model)
        {
            LogInfo.LogDetailToFile("ItemMasterJWApiController-CreateItem Action(httppost)- Start");

            string result = itemBAL.SaveItemJW(model);

            LogInfo.LogDetailToFile("CreateItem - Item Save Completed : " + result);
            LogInfo.LogDetailToFile("ItemMasterJWApiController-CreateItem Action(httppost)- Start-End");

            return result;
        }


        // PUT: http://localhost:62335/ItemMasterJWApi/UpdateItem?id=1
        [HttpPut]
        public string UpdateItem(int id, ItemMaster_Modal_AprBtch model)
        {
            LogInfo.LogDetailToFile("ItemMasterJWApiController-UpdateItem Action(httpput)- Start");
            LogInfo.LogDetailToFile("UpdateItem - Item Id : " + id);

            string result = itemBAL.UpdateItemJW(id, model);

            LogInfo.LogDetailToFile("UpdateItem - Update Result : " + result);
            LogInfo.LogDetailToFile("ItemMasterJWApiController-UpdateItem Action(httpput)- Start-End");

            return result;
        }
    }
}


