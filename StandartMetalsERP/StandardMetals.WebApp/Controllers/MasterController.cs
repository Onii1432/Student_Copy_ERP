using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using StandardMetals.BAL;
using StandardMetals.MODEL;
using StandardMetals.WebApp.UserAccessDtl;
using StandardMetals.CommonLibrary;
using StandardMetals.WebApp.Filters;
using System.IO;
using System.Text;
using ExcelDataReader;


namespace StandardMetals.WebApp.Controllers
{
    [LoginSessionFilter]
    public class MasterController : Controller
    {


        //// Exception Logging
        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    Exception ex = filterContext.Exception;

        //    LogInfo.LogDetailToFile("Unhandled Exception occurred in MasterController.", ex);

        //}

        DefaultDashboard_BAL dashboardBAL = new DefaultDashboard_BAL();

        // GET: Master
        public ActionResult DefaultDashboard()
        {
            LogInfo.LogDetailToFile("MasterCtrl-DefaultDashboard Action(httpget)- Start");

            DefaultDashboardModel model = dashboardBAL.GetSupplierWiseItemDashboard();

            LogInfo.LogDetailToFile("DefaultDashboard - Dashboard Data Loaded");
            LogInfo.LogDetailToFile("MasterCtrl-DefaultDashboard Action(httpget)- Start-End");

            return View(model);
        }


        [HttpGet]
        public ActionResult ItemMaster()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ItemMaster(ItemMaster_MODEL_27March model)
        {

            return View();
        }


        public ActionResult ItemMasterDemo()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ItemMasterScaffolding()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ItemMasterScaffolding(ItemMaster_MODEL_27March model)
        {

            return View();
        }

        public ActionResult BindDropDownThrouHtmlSTronglyConrol()
        {
            return View();
        }
        //Company Information
        public ActionResult CompanyMaster()
        {
            return View();
        }

        // Item Master Crud from Web Api
        public async Task<ActionResult> ItemMasterFromWebApi()
        {
            // variables are used to create URI
            //string FillItemMaster = "http://localhost:62335/ItemMaster/FillItemMaster";
            string BindManufacturer = "http://localhost:62335/ItemMaster/BindManfacturer";
            string BindItemCategory = "http://localhost:62335/ItemMaster/BindCategory";
            string BindColorMaster = "http://localhost:62335/ItemMaster/BindColor";
            string BindUnitMaster = "http://localhost:62335/ItemMaster/BindUom";

            //string FillItemMaster = ConfigurationManager.AppSettings[""].ToString();

            // Code to bind FillItemMaster dropdown
            //List<ItemMasterModel> listFillItemMaster = new List<ItemMasterModel>();
            //using (HttpClient client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(FillItemMaster);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //    HttpResponseMessage response = await client.GetAsync(FillItemMaster);
            //    if (response.IsSuccessStatusCode)
            //    {

            //        var data = await response.Content.ReadAsStringAsync();
            //        //table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
            //        //list = Newtonsoft.Json.JsonConvert.DeserializeObject<ItemMasterModel>(data);
            //        listFillItemMaster = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ItemMasterModel>>(data);

            //    }
            //}

            //var fillItemMasterList = listFillItemMaster.ToList();
            //ViewBag.ItemCodeList = new SelectList(fillItemMasterList, "ItemCode", "ItemCode");
            //ViewBag.ItemNameList = new SelectList(fillItemMasterList, "ItemCode", "ItemName");

            //code to bind Manufacturre dropdown
            DataTable dt = new DataTable();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BindManufacturer);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(BindManufacturer);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    //table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    //list = Newtonsoft.Json.JsonConvert.DeserializeObject<ItemMasterModel>(data);
                    dt = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(data);

                }
            }
            List<ItemMasterModel> ManuFactList = new List<ItemMasterModel>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ManuFactList.Add(new ItemMasterModel()
                    {
                        ManufacturerId = Convert.ToInt32(dt.Rows[i]["ManufacturerId"]),
                        ManufacturerName = dt.Rows[i]["ManufacturerName"].ToString()
                    });

                }
            }
            var ManufacturereList = ManuFactList;
            ViewBag.ManuList = new SelectList(ManufacturereList, "ManufacturerId", "ManufacturerName");
            // End Of the Manufacturere Binding Code dropdown

            //Code to bind Item Category dropdown
            DataTable tableIC = new DataTable();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BindItemCategory);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(BindItemCategory);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    //table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    //list = Newtonsoft.Json.JsonConvert.DeserializeObject<ItemMasterModel>(data);
                    tableIC = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(data);

                }
            }
            List<ItemMasterModel> ItemCategoryList = new List<ItemMasterModel>();
            if (tableIC.Rows.Count > 0)
            {
                for (int i = 0; i < tableIC.Rows.Count; i++)
                {
                    ItemCategoryList.Add(new ItemMasterModel()
                    {
                        //ItemCategoryId = Convert.ToInt32(tableIC.Rows[i]["CategoryId"]),
                        CategoryId = Convert.ToInt32(tableIC.Rows[i]["CategoryId"]),
                        CategoryName = tableIC.Rows[i]["CategoryName"].ToString()
                    });

                }
            }
            var CategoryList = ItemCategoryList;
            ViewBag.CList = new SelectList(CategoryList, "CategoryId", "CategoryName");

            // End Of the Item Category Code dropdown


            //Code to Bind  Color Master dropdown

            DataTable TableColor = new DataTable();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BindColorMaster);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(BindColorMaster);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    //table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    //list = Newtonsoft.Json.JsonConvert.DeserializeObject<ItemMasterModel>(data);
                    TableColor = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(data);

                }
            }
            List<ItemMasterModel> ColorList = new List<ItemMasterModel>();
            if (TableColor.Rows.Count > 0)
            {
                for (int i = 0; i < TableColor.Rows.Count; i++)
                {
                    ColorList.Add(new ItemMasterModel()
                    {
                        ColourId = Convert.ToInt32(TableColor.Rows[i]["ColourId"]),
                        ColourName = TableColor.Rows[i]["ColourName"].ToString()
                    });

                }
            }
            var ColorName = ColorList;
            ViewBag.ColorList = new SelectList(ColorName, "ColourId", "ColourName");

            // End Of the color Bind Master 

            //Code to Bind  Unit Master dropdown

            DataTable TableUnitMaster = new DataTable();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BindUnitMaster);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(BindUnitMaster);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    //table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    //list = Newtonsoft.Json.JsonConvert.DeserializeObject<ItemMasterModel>(data);
                    TableUnitMaster = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(data);

                }
            }
            List<ItemMasterModel> UnitList = new List<ItemMasterModel>();
            if (TableUnitMaster.Rows.Count > 0)
            {
                for (int i = 0; i < TableUnitMaster.Rows.Count; i++)
                {
                    UnitList.Add(new ItemMasterModel()
                    {
                        UnitId = Convert.ToInt32(TableUnitMaster.Rows[i]["UnitId"]),
                        UnitName = TableUnitMaster.Rows[i]["UnitName"].ToString()
                    });

                }
            }
            var UnitMasterName = UnitList;
            ViewBag.UnitMater = new SelectList(UnitMasterName, "UnitId", "UnitName");

            // End Of the Unit Master 



            return View();

        }

        [HttpPost]
        public async Task<ActionResult> GetItemSubCategory(int? CategoryId)
        {
            string BindSubCategory = "http://localhost:62335/ItemMaster/BindSubCategory1?CategoryId=" + CategoryId;

            DataTable TableSubCatgeory = new DataTable();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BindSubCategory);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(BindSubCategory);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    //table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    //list = Newtonsoft.Json.JsonConvert.DeserializeObject<ItemMasterModel>(data);
                    TableSubCatgeory = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(data);

                }
            }
            List<ItemMasterModel> SubCategory = new List<ItemMasterModel>();
            if (TableSubCatgeory.Rows.Count > 0)
            {
                for (int i = 0; i < TableSubCatgeory.Rows.Count; i++)
                {
                    SubCategory.Add(new ItemMasterModel()
                    {
                        SubCategoryId = Convert.ToInt32(TableSubCatgeory.Rows[i]["SubCategoryId"]),
                        SubCategoryName = TableSubCatgeory.Rows[i]["SubCategoryName"].ToString()
                    });

                }
            }
            return Json(SubCategory, JsonRequestBehavior.AllowGet);

        }

        //Code to bind Item Name Code Against Item Code

        [HttpPost]
        public async Task<ActionResult> FillItemMaster()
        {
            string FillItemMaster = "http://localhost:62335/ItemMaster/FillItemMaster";

            // Code to bind FillItemMaster dropdown
            List<ItemMasterModel> listFillItemMaster = new List<ItemMasterModel>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(FillItemMaster);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(FillItemMaster);
                if (response.IsSuccessStatusCode)
                {

                    var data = await response.Content.ReadAsStringAsync();
                    //table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    //list = Newtonsoft.Json.JsonConvert.DeserializeObject<ItemMasterModel>(data);
                    listFillItemMaster = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ItemMasterModel>>(data);

                }
            }

            var fillItemMasterList = listFillItemMaster.ToList();
            //ViewBag.ItemCodeList = new SelectList(fillItemMasterList, "ItemCode", "ItemCode");
            //ViewBag.ItemNameList = new SelectList(fillItemMasterList, "ItemCode", "ItemName");


            return Json(fillItemMasterList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> SearchItemMaster(string ItemCode)
        {
            string SearchIM = "http://localhost:62335/ItemMaster/SearchItemMaster?ItemCode=" + ItemCode;
            ItemMasterModel itemMasterModel = new ItemMasterModel();
            DataTable dt = new DataTable();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(SearchIM);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(SearchIM);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    //table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    //list = Newtonsoft.Json.JsonConvert.DeserializeObject<ItemMasterModel>(data);
                    itemMasterModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ItemMasterModel>(data);

                }
            }
            //List<ItemMasterModel> SearchItemMaster = new List<ItemMasterModel>();
            //if (dt.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        SearchItemMaster.Add(new ItemMasterModel()
            //        {
            //            ItemCode = dt.Rows[i]["ItemCode"].ToString(),
            //            ItemName = dt.Rows[i]["ItemCode"].ToString(),
            //            ManufacturerId = Convert.ToInt32(dt.Rows[i]["ManufacturerId"]),
            //            Material = dt.Rows[i]["Material"].ToString(),
            //            CategoryId = Convert.ToInt32(dt.Rows[i]["CategoryId"]),
            //            SubCategoryId = Convert.ToInt32(dt.Rows[i]["SubCategoryId"]),
            //            ColourId = Convert.ToInt32(dt.Rows[i]["ColourId"]),
            //            UnitId = Convert.ToInt32(dt.Rows[i]["UnitId"]),
            //            HSNCODE = dt.Rows[i]["HSNCODE"].ToString(),
            //            GSTRate = Convert.ToDecimal(dt.Rows[i]["GSTRate"]),
            //            PurchaseCost = Convert.ToDecimal(dt.Rows[i]["PurchaseCost"]),
            //            SellingPrice = Convert.ToDecimal(dt.Rows[i]["SellingPrice"]),

            //        });

            //    }
            //}
            var SearchIMaster = itemMasterModel;
            return Json(SearchIMaster, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public async Task<ActionResult> ItemMasterFromWebApi(ItemMasterModel model)
        {

            if (ModelState.IsValid)
            {
                string SaveItemMasterModel = "http://localhost:62335/ItemMaster/SaveData";

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(SaveItemMasterModel);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(SaveItemMasterModel);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        //table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                        //list = Newtonsoft.Json.JsonConvert.DeserializeObject<ItemMasterModel>(data);
                        model = Newtonsoft.Json.JsonConvert.DeserializeObject<ItemMasterModel>(data);

                    }
                }
                if (model != null)
                {
                    return RedirectToAction("DefaultDashboard", "Master");
                }
                else
                {
                    ViewBag.Alert = "Error Occured While Saving data";
                }

            }


            return View();
        }


        public ActionResult ItemMasterGridView()
        {
            return View();
        }











        ////////////////////////////////////////ItemMasterMVC////////////////////////////////






        ItemMasterMVCBAL bal = new ItemMasterMVCBAL();
        //ItemMasterBAL_Oct2025 bal = new ItemMasterBAL_Oct2025();
        ItemMaster17Dec_BAL bal17 = new ItemMaster17Dec_BAL();


        [HttpGet]
        public ActionResult ItemList()
        {

            return View(bal.GetAllItemMaster());
        }


        [HttpGet]
        public JsonResult GetSubCategoryName(int categoryID)
        {
            return Json(bal.GetSubCategoriesDetails(categoryID), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddNewItem()
        {

            ViewBag.Manufacturers = bal.GetManufacturerDetails();
            ViewBag.Categories = bal.GetCategoriesDetails();
            ViewBag.SubCategories = new List<ItemMasterMVCModal>();
            ViewBag.ColourList = bal.GetAllColours();
            ViewBag.UnitList = bal.GetUnitDetails();

            return View();
        }

        [HttpPost]
        public ActionResult AddNewItem(ItemMasterMVCModal model)
        {
            if (ModelState.IsValid)
            {
                bal.SaveNewItem(model);
                return RedirectToAction("ItemList");
            }
            ViewBag.Manufacturers = bal.GetManufacturerDetails();
            ViewBag.Categories = bal.GetCategoriesDetails();
            ViewBag.ColourList = bal.GetAllColours();
            ViewBag.UnitList = bal.GetUnitDetails();
            ViewBag.SubCategories = bal.GetSubCategoriesDetails(model.CategoryId);

            return View(model);
        }

        [HttpGet]
        public ActionResult EditItemDetails(int id)
        {
            ItemMasterMVCModal model = bal.GetItemDetailsByID(id);

            ViewBag.Manufacturers = bal.GetManufacturerDetails();
            ViewBag.Categories = bal.GetCategoriesDetails();
            ViewBag.SubCategories = bal.GetSubCategoriesDetails(model.CategoryId);
            ViewBag.ColourList = bal.GetAllColours();
            ViewBag.UnitList = bal.GetUnitDetails();

            return PartialView(bal.GetItemDetailsByID(id));
        }

        [HttpPost]
        public ActionResult EditItemDetails(int id, ItemMasterMVCModal model)
        {
            if (ModelState.IsValid)
            {
                bal.UpdateExistingItem(id, model);
                return RedirectToAction("ItemList");
            }
            ViewBag.Manufacturers = bal.GetManufacturerDetails();
            ViewBag.Categories = bal.GetCategoriesDetails();
            ViewBag.ColourList = bal.GetAllColours();
            ViewBag.UnitList = bal.GetUnitDetails();
            ViewBag.SubCategories = bal.GetSubCategoriesDetails(model.CategoryId);


            return PartialView(model);
        }














        //////////////////////////////////ItemMaster17Dec ///////////////////////////////////////////////////////////////////////////       


        //[HttpGet]
        //public ActionResult ItemList17Dec()
        //{
        //    var list = bal17.GetAllItemMaster();
        //    return View(list);

        //    // return Content("Total Records = " + list.Count);
        //}

        //[HttpGet]
        //public ActionResult AddNewItem17Dec()
        //{
        //    ViewBag.Manufacturers = bal17.GetManufacturerDetails();

        //    ViewBag.Categories = bal17.GetCategoriesDetails();

        //    ViewBag.SubCategories = new List<ItemMaster17DecMVCModal>();

        //    ViewBag.ColourList = bal17.GetAllColours();

        //    ViewBag.UnitList = bal17.GetUnitDetails();

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AddNewItem17Dec(ItemMaster17DecMVCModal model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        bal17.SaveNewItem(model);

        //        return Json(new
        //        {
        //            success = true,
        //            message = "Record Saved Successfully.",
        //            itemCode = model.ItemCode
        //        });
        //    }

        //    ViewBag.Manufacturers = bal17.GetManufacturerDetails();
        //    ViewBag.Categories = bal17.GetCategoriesDetails();
        //    ViewBag.ColourList = bal17.GetAllColours();
        //    ViewBag.UnitList = bal17.GetUnitDetails();
        //    ViewBag.SubCategories = bal17.GetSubCategoriesDetails(model.CategoryId);

        //    return Json(new
        //    {
        //        success = false,
        //        message = "Please fill all required fields."
        //    });
        //}


        //[HttpGet]
        //public ActionResult EditItemDetails17Dec(int id)
        //{
        //    ItemMaster17DecMVCModal model = bal17.GetItemDetailsByID(id);

        //    ViewBag.Manufacturers = bal17.GetManufacturerDetails();

        //    ViewBag.Categories = bal17.GetCategoriesDetails();

        //    ViewBag.SubCategories = bal17.GetSubCategoriesDetails(model.CategoryId);

        //    ViewBag.ColourList = bal17.GetAllColours();

        //    ViewBag.UnitList = bal17.GetUnitDetails();

        //    return PartialView(model);
        //}


        //[HttpPost]
        //public ActionResult EditItemDetails17Dec(int id, ItemMaster17DecMVCModal model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        bal17.UpdateExistingItem(id, model);

        //        return RedirectToAction("ItemList17Dec");
        //    }

        //    ViewBag.Manufacturers = bal17.GetManufacturerDetails();

        //    ViewBag.Categories = bal17.GetCategoriesDetails();

        //    ViewBag.ColourList = bal17.GetAllColours();

        //    ViewBag.UnitList = bal17.GetUnitDetails();

        //    ViewBag.SubCategories = bal17.GetSubCategoriesDetails(model.CategoryId);

        //    return PartialView(model);
        //}



        //// Generate Item Code

        //[HttpGet]
        //public JsonResult GetNextItemCode(int categoryId, int subCategoryId)
        //{
        //    string itemCode = bal17.GetNextItemCode(categoryId, subCategoryId);

        //    return Json(itemCode, JsonRequestBehavior.AllowGet);
        //}










        /// <summary>
        /// //////////////////// Item Master 17 Dec Updated ///////////////////////////////////////////////////////////////
        /// </summary>


        // Item + Supplier + Customer Mapping

        ItemMaster17Dec_BAL itemBAL = new ItemMaster17Dec_BAL();


        // Item Master List

        [HttpGet]
        public ActionResult ItemList17Dec()
        {
            LogInfo.LogDetailToFile("MasterCtrl-ItemList17Dec Action(httpget)- Start");

            var list = itemBAL.GetAllItemMaster();

            LogInfo.LogDetailToFile("MasterCtrl-ItemList17Dec Action(httpget)- Start-End");

            return View(list);
        }


        // Get SubCategory

        [HttpGet]
        public JsonResult GetSubCategoryN(int id)
        {
            LogInfo.LogDetailToFile("MasterCtrl-GetSubCategoryN Action(httpget)- Start");

            LogInfo.LogDetailToFile("GetSubCategoryN - Category Id : " + id);

            var result = itemBAL.GetSubCategoriesDetails(id);

            LogInfo.LogDetailToFile("MasterCtrl-GetSubCategoryN Action(httpget)- Start-End");

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // Add New Item - GET

        [HttpGet]
        public ActionResult AddNewItemApril2026()
        {
            LogInfo.LogDetailToFile("MasterCtrl-AddNewItemApril2026 Action(httpget)- Start");

            LoadDropDowns();

            LogInfo.LogDetailToFile("AddNewItemApril2026 - DropDowns Loaded");

            ViewBag.SubCategories = new List<ItemMaster_Modal_AprBtch>();

            LogInfo.LogDetailToFile("AddNewItemApril2026 - SubCategories Loaded");

            LogInfo.LogDetailToFile("MasterCtrl-AddNewItemApril2026 Action(httpget)- Start-End");

            return PartialView("_AddNewItemApril2026", new ItemMaster_Modal_AprBtch());
        }


        // Get Supplier Codes

        [HttpGet]
        public JsonResult GetSupplierCodes()
        {
            LogInfo.LogDetailToFile("MasterCtrl-GetSupplierCodes Action(httpget)- Start");

            DataTable dt = supplierBal.BindSupplierCode();

            LogInfo.LogDetailToFile("GetSupplierCodes - Supplier Data Loaded");

            List<object> list = new List<object>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new
                {
                    Id = row["Id"].ToString(),
                    SuppCode = row["SuppCode"].ToString()
                });
            }

            LogInfo.LogDetailToFile("GetSupplierCodes - Supplier Codes Prepared");

            LogInfo.LogDetailToFile("MasterCtrl-GetSupplierCodes Action(httpget)- Start-End");

            return Json(list, JsonRequestBehavior.AllowGet);
        }


        // Get Supplier Names

        [HttpGet]
        public JsonResult GetSupplierNames()
        {
            LogInfo.LogDetailToFile("MasterCtrl-GetSupplierNames Action(httpget)- Start");

            DataTable dt = supplierBal.BindSupplierName();

            LogInfo.LogDetailToFile("GetSupplierNames - Supplier Data Loaded");

            List<object> list = new List<object>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new
                {
                    Id = row["Id"].ToString(),
                    SuppName = row["SuppName"].ToString()
                });
            }

            LogInfo.LogDetailToFile("GetSupplierNames - Supplier Names Prepared");

            LogInfo.LogDetailToFile("MasterCtrl-GetSupplierNames Action(httpget)- Start-End");

            return Json(list, JsonRequestBehavior.AllowGet);
        }


        // Get Supplier Details By Code

        [HttpGet]
        public JsonResult GetItemSupplierDetailsByCode(string suppCode)
        {
            LogInfo.LogDetailToFile("MasterCtrl-GetItemSupplierDetailsByCode Action(httpget)- Start");

            LogInfo.LogDetailToFile("GetItemSupplierDetailsByCode - Supplier Code : " + suppCode);

            SupplierMasterMVCApril2026Model supplier = supplierBal.GetSupplierDetailsByCode(suppCode);

            LogInfo.LogDetailToFile("GetItemSupplierDetailsByCode - Supplier Details Loaded");

            LogInfo.LogDetailToFile("MasterCtrl-GetItemSupplierDetailsByCode Action(httpget)- Start-End");

            return Json(new
            {
                success = true,
                data = supplier
            }, JsonRequestBehavior.AllowGet);
        }


        // Get Supplier Details By Id

        [HttpGet]
        public JsonResult GetItemSupplierDetailsById(int supplierId)
        {
            LogInfo.LogDetailToFile("MasterCtrl-GetItemSupplierDetailsById Action(httpget)- Start");

            LogInfo.LogDetailToFile("GetItemSupplierDetailsById - Supplier Id : " + supplierId);

            SupplierMasterMVCApril2026Model supplier = supplierBal.GetSupplierDetailsById(supplierId);

            LogInfo.LogDetailToFile("GetItemSupplierDetailsById - Supplier Details Loaded");

            LogInfo.LogDetailToFile("MasterCtrl-GetItemSupplierDetailsById Action(httpget)- Start-End");

            return Json(new
            {
                success = true,
                data = supplier
            }, JsonRequestBehavior.AllowGet);
        }


        // Get Customer Codes

        [HttpGet]
        public JsonResult GetCustomerCodes()
        {
            LogInfo.LogDetailToFile("MasterCtrl-GetCustomerCodes Action(httpget)- Start");

            DataTable dt = customerBal.BindCustomer();

            LogInfo.LogDetailToFile("GetCustomerCodes - Customer Data Loaded");

            List<object> list = new List<object>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new
                {
                    Id = row["Id"].ToString(),
                    CustCode = row["CustCode"].ToString()
                });
            }

            LogInfo.LogDetailToFile("GetCustomerCodes - Customer Codes Prepared");

            LogInfo.LogDetailToFile("MasterCtrl-GetCustomerCodes Action(httpget)- Start-End");

            return Json(list, JsonRequestBehavior.AllowGet);
        }


        // Get Customer Names

        [HttpGet]
        public JsonResult GetCustomerNames()
        {
            LogInfo.LogDetailToFile("MasterCtrl-GetCustomerNames Action(httpget)- Start");

            DataTable dt = customerBal.BindCustomer();

            LogInfo.LogDetailToFile("GetCustomerNames - Customer Data Loaded");

            List<object> list = new List<object>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new
                {
                    Id = row["Id"].ToString(),
                    CustName = row["CustName"].ToString()
                });
            }

            LogInfo.LogDetailToFile("GetCustomerNames - Customer Names Prepared");

            LogInfo.LogDetailToFile("MasterCtrl-GetCustomerNames Action(httpget)- Start-End");

            return Json(list, JsonRequestBehavior.AllowGet);
        }


        // Get Customer Details By Code

        [HttpGet]
        public JsonResult GetItemCustomerDetailsByCode(string custCode)
        {
            LogInfo.LogDetailToFile("MasterCtrl-GetItemCustomerDetailsByCode Action(httpget)- Start");

            LogInfo.LogDetailToFile("GetItemCustomerDetailsByCode - Customer Code : " + custCode);

            CustomerMasterMVCApril2026Model customer = customerBal.GetCustomerDetailsByCode(custCode);

            LogInfo.LogDetailToFile("GetItemCustomerDetailsByCode - Customer Details Loaded");

            LogInfo.LogDetailToFile("MasterCtrl-GetItemCustomerDetailsByCode Action(httpget)- Start-End");

            return Json(new
            {
                success = true,
                data = customer
            }, JsonRequestBehavior.AllowGet);
        }


        // Get Customer Details By Id

        [HttpGet]
        public JsonResult GetItemCustomerDetailsById(int customerId)
        {
            LogInfo.LogDetailToFile("MasterCtrl-GetItemCustomerDetailsById Action(httpget)- Start");

            LogInfo.LogDetailToFile("GetItemCustomerDetailsById - Customer Id : " + customerId);

            CustomerMasterMVCApril2026Model customer = customerBal.GetCustomerDetailsById(customerId);

            LogInfo.LogDetailToFile("GetItemCustomerDetailsById - Customer Details Loaded");

            LogInfo.LogDetailToFile("MasterCtrl-GetItemCustomerDetailsById Action(httpget)- Start-End");

            return Json(new
            {
                success = true,
                data = customer
            }, JsonRequestBehavior.AllowGet);
        }


        // Add New Item - POST

        [HttpPost]
        public ActionResult AddNewItemApril2026(ItemMaster_Modal_AprBtch model)
        {
            LogInfo.LogDetailToFile("MasterCtrl-AddNewItemApril2026 Action(httppost)- Start");

            try
            {
                if (!ModelState.IsValid)
                {
                    LogInfo.LogDetailToFile("AddNewItemApril2026 - ModelState IsValid False");

                    string message = "Please enter all required fields.";

                    if (ModelState["ItemName"] != null &&
                        ModelState["ItemName"].Errors.Count > 0)
                    {
                        message = ModelState["ItemName"].Errors[0].ErrorMessage;

                        LogInfo.LogDetailToFile("AddNewItemApril2026 - ItemName Validation Error : " + message);
                    }

                    LogInfo.LogDetailToFile("MasterCtrl-AddNewItemApril2026 Action(httppost)- Start-End");

                    return Json(new
                    {
                        success = false,
                        message = message
                    });
                }

                LogInfo.LogDetailToFile("AddNewItemApril2026 - ModelState IsValid");

                string itemCode = itemBAL.SaveNewItem(model);

                LogInfo.LogDetailToFile("AddNewItemApril2026 - Item Save Completed : " + itemCode);

                if (itemCode == "DUPLICATE_ITEM")
                {
                    LogInfo.LogDetailToFile("AddNewItemApril2026 - Duplicate Item Found");

                    LogInfo.LogDetailToFile("MasterCtrl-AddNewItemApril2026 Action(httppost)- Start-End");

                    return Json(new
                    {
                        success = false,
                        message = "Item Name already exists. Please edit the existing item to add another supplier."
                    });
                }

                LogInfo.LogDetailToFile("AddNewItemApril2026 - Item Saved Successfully");

                LogInfo.LogDetailToFile("MasterCtrl-AddNewItemApril2026 Action(httppost)- Start-End");

                return Json(new
                {
                    success = true,
                    code = itemCode,
                    message = "Item Saved Successfully"
                });
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("AddNewItemApril2026 - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("MasterCtrl-AddNewItemApril2026 Action(httppost)- Start-End");

                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }


        // Edit Item - GET

        [HttpGet]
        public ActionResult EditItemApril2026(int id)
        {
            LogInfo.LogDetailToFile("MasterCtrl-EditItemApril2026 Action(httpget)- Start");

            LogInfo.LogDetailToFile("EditItemApril2026 - Item Id : " + id);

            ItemMaster_Modal_AprBtch model = itemBAL.GetItemDetailsById(id);

            LogInfo.LogDetailToFile("EditItemApril2026 - Item Details Loaded");

            model.SupplierList = itemBAL.GetSupplierDetailsByItemId(id);

            LogInfo.LogDetailToFile("EditItemApril2026 - Supplier Details Loaded");

            model.CustomerList = itemBAL.GetCustomerDetailsByItemId(id);

            LogInfo.LogDetailToFile("EditItemApril2026 - Customer Details Loaded");

            LoadDropDowns();

            LogInfo.LogDetailToFile("EditItemApril2026 - DropDowns Loaded");

            ViewBag.SubCategories = itemBAL.GetSubCategoriesDetails(model.CategoryId ?? 0);

            LogInfo.LogDetailToFile("EditItemApril2026 - SubCategories Loaded");

            LogInfo.LogDetailToFile("MasterCtrl-EditItemApril2026 Action(httpget)- Start-End");

            return PartialView("_EditItemApril2026", model);
        }


        // Edit Item - POST

        [HttpPost]
        public ActionResult EditItemApril2026(int id, ItemMaster_Modal_AprBtch model)
        {
            LogInfo.LogDetailToFile("MasterCtrl-EditItemApril2026 Action(httppost)- Start");

            try
            {
                model.Id = id;

                LogInfo.LogDetailToFile("EditItemApril2026 - Item Id : " + id);

                if (!ModelState.IsValid)
                {
                    LogInfo.LogDetailToFile("EditItemApril2026 - ModelState IsValid False");

                    string message = "Please enter all required fields.";

                    if (ModelState["ItemName"] != null &&
                        ModelState["ItemName"].Errors.Count > 0)
                    {
                        message = ModelState["ItemName"].Errors[0].ErrorMessage;

                        LogInfo.LogDetailToFile("EditItemApril2026 - ItemName Validation Error : " + message);
                    }

                    LogInfo.LogDetailToFile("MasterCtrl-EditItemApril2026 Action(httppost)- Start-End");

                    return Json(new
                    {
                        success = false,
                        message = message
                    });
                }

                LogInfo.LogDetailToFile("EditItemApril2026 - ModelState IsValid");

                itemBAL.UpdateExistingItem(id, model);

                LogInfo.LogDetailToFile("EditItemApril2026 - Item Update Completed");

                LogInfo.LogDetailToFile("MasterCtrl-EditItemApril2026 Action(httppost)- Start-End");

                return Json(new
                {
                    success = true,
                    message = "Item Updated Successfully"
                });
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("EditItemApril2026 - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("MasterCtrl-EditItemApril2026 Action(httppost)- Start-End");

                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }


        // Existing Item Master DropDowns

        private void LoadDropDowns()
        {
            LogInfo.LogDetailToFile("MasterCtrl-Item-LoadDropDowns Action- Start");

            ViewBag.Manufacturers = itemBAL.GetManufacturerDetails();

            LogInfo.LogDetailToFile("LoadDropDowns - Manufacturers Loaded");

            ViewBag.Categories = itemBAL.GetCategoriesDetails();

            LogInfo.LogDetailToFile("LoadDropDowns - Categories Loaded");

            ViewBag.ColourList = itemBAL.GetAllColours();

            LogInfo.LogDetailToFile("LoadDropDowns - Colours Loaded");

            ViewBag.UnitList = itemBAL.GetUnitDetails();

            LogInfo.LogDetailToFile("LoadDropDowns - Units Loaded");

            LogInfo.LogDetailToFile("MasterCtrl-Item-LoadDropDowns Action- Start-End");
        }


        //////////////////////////////////////////////// ITEM MASTER BULK UPLOAD ////////////////////////////////////////////////////////////////////////



        // ITEM MASTER BULK UPLOAD - GET

        ItemMasterBulkUploadBAL bulkUploadBAL = new ItemMasterBulkUploadBAL();

        [HttpGet]
        public ActionResult UploadItemMasterExcelApr26()
        {
            LogInfo.LogDetailToFile("MasterCtrl-UploadItemMasterExcelApr26 GET - Start");


            ViewBag.SuccessCount = 0;
            ViewBag.FailCount = 0;

            LogInfo.LogDetailToFile("MasterCtrl-UploadItemMasterExcelApr26 GET - End");


            return View();
        }


        // Post 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadItemMasterExcelApr26(string MasterType, HttpPostedFileBase ExcelFile)
        {
            ViewBag.SuccessCount = 0;
            ViewBag.FailCount = 0;

            try
            {
                if (MasterType != "ItemMaster")
                {
                    ViewBag.Message = "Please select Item Master.";
                    return View();
                }

                if (ExcelFile == null || ExcelFile.ContentLength == 0)
                {
                    ViewBag.Message = "Please attach Excel file.";
                    return View();
                }

                string extension = Path.GetExtension(ExcelFile.FileName);

                if (extension == null || (extension.ToLower() != ".xls" && extension.ToLower() != ".xlsx"))
                {
                    ViewBag.Message = "Please upload a valid Excel file.";
                    return View();
                }

                DataTable dt;

                using (var reader = ExcelReaderFactory.CreateReader(ExcelFile.InputStream))
                {
                    dt = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration { UseHeaderRow = true }
                    }).Tables[0];
                }

                int uploadId = bulkUploadBAL.InsertUploadMaster(Path.GetFileName(ExcelFile.FileName));
                if (uploadId <= 0)
                {
                    ViewBag.Message = "Unable to create upload record.";
                    return View();
                }

                bulkUploadBAL.BulkInsertItemMaster(dt, uploadId);

                DataTable result = bulkUploadBAL.ValidateItemMasterUpload(uploadId);

                if (result.Rows.Count > 0)
                {
                    ViewBag.SuccessCount = Convert.ToInt32(result.Rows[0]["SuccessCount"]);
                    ViewBag.FailCount = Convert.ToInt32(result.Rows[0]["FailCount"]);
                }

                Session["UploadId"] = uploadId;
                Session["MasterType"] = MasterType;
                ViewBag.Message = "Excel upload processing completed.";
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("UploadItemMasterExcelApr26 Exception: " + ex.ToString());
                ViewBag.Message = "Upload failed. Check the application log for details.";
            }

            return View();
        }


        // DOWNLOAD FAILED ITEM MASTER RECORDS

        [HttpGet]
        public ActionResult DownloadFailItemMasterExcelApr26()
        {
            try
            {
                if (Session["UploadId"] == null)
                {
                    return Content("Upload ID not found. Please upload the Excel file again.");
                }

                int uploadId = Convert.ToInt32(Session["UploadId"]);

                DataTable dt = bulkUploadBAL.GetFailedItemMasterRecords(uploadId);

                if (dt == null || dt.Rows.Count == 0)
                {
                    return Content("No failed records found for this upload.");
                }

                StringBuilder sb = new StringBuilder();

                sb.Append("<html><head><meta charset='utf-8'></head><body>");
                sb.Append("<table border='1'><thead><tr>");

                foreach (DataColumn column in dt.Columns)
                {
                    sb.Append("<th>");
                    sb.Append(System.Web.HttpUtility.HtmlEncode(column.ColumnName));
                    sb.Append("</th>");
                }

                sb.Append("</tr></thead><tbody>");

                foreach (DataRow row in dt.Rows)
                {
                    sb.Append("<tr>");

                    foreach (DataColumn column in dt.Columns)
                    {
                        sb.Append("<td>");
                        sb.Append(System.Web.HttpUtility.HtmlEncode(
                            Convert.ToString(row[column])));
                        sb.Append("</td>");
                    }

                    sb.Append("</tr>");
                }

                sb.Append("</tbody></table></body></html>");

                return File(
                    Encoding.UTF8.GetBytes(sb.ToString()),
                    "application/vnd.ms-excel",
                    "Failed_ItemMaster.xls"
                );
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile(
                    "DownloadFailItemMasterExcelApr26 Exception: " + ex.Message);

                return Content("Failed-record download failed. Please check the application log.");
            }
        }















        ///////////////////////////////////////////////// Customer Master April2026 ////////////////////////////////////////



        // 20/08/2026

        CustomerMasterMVCApril2026BAL customerBal = new CustomerMasterMVCApril2026BAL();


        // Customer List
        public ActionResult CustomerListApril2026()
        {
            LogInfo.LogDetailToFile("MasterCtrl-CustomerListApril2026 Action- Start");

            DataTable dtCustomer = customerBal.BindCustomer();

            LogInfo.LogDetailToFile("CustomerListApril2026 - Customer Data Loaded");

            List<SelectListItem> customer = new List<SelectListItem>();
            customer.Add(new SelectListItem() { Text = "--Select Customer--", Value = "" });

            foreach (DataRow dr in dtCustomer.Rows)
            {
                customer.Add(new SelectListItem()
                {
                    Text = dr["CustName"].ToString(),
                    Value = dr["Id"].ToString()
                });
            }

            ViewBag.SearchCustomerId = customer;

            LogInfo.LogDetailToFile("CustomerListApril2026 - Customer Dropdown Loaded");

            DataTable dtBranch = customerBal.BindBranch();

            LogInfo.LogDetailToFile("CustomerListApril2026 - Branch Data Loaded");

            List<SelectListItem> branch = new List<SelectListItem>();
            branch.Add(new SelectListItem() { Text = "--Select Branch--", Value = "" });

            foreach (DataRow dr in dtBranch.Rows)
            {
                branch.Add(new SelectListItem()
                {
                    Text = dr["BranchName"].ToString(),
                    Value = dr["BranchId"].ToString()
                });
            }

            ViewBag.BranchId = branch;

            LogInfo.LogDetailToFile("CustomerListApril2026 - Branch Dropdown Loaded");

            DataTable dtCountry = customerBal.BindCountry();

            LogInfo.LogDetailToFile("CustomerListApril2026 - Country Data Loaded");

            List<SelectListItem> country = new List<SelectListItem>();
            country.Add(new SelectListItem() { Text = "--Select Country--", Value = "" });

            foreach (DataRow dr in dtCountry.Rows)
            {
                country.Add(new SelectListItem()
                {
                    Text = dr["Country"].ToString(),
                    Value = dr["CountryId"].ToString()
                });
            }

            ViewBag.CountryId = country;

            LogInfo.LogDetailToFile("CustomerListApril2026 - Country Dropdown Loaded");

            List<SelectListItem> state = new List<SelectListItem>();
            state.Add(new SelectListItem() { Text = "--Select State--", Value = "" });
            ViewBag.StateId = state;

            List<SelectListItem> city = new List<SelectListItem>();
            city.Add(new SelectListItem() { Text = "--Select City--", Value = "" });
            ViewBag.CityId = city;

            LogInfo.LogDetailToFile("CustomerListApril2026 - State And City Dropdown Initialized");

            List<CustomerMasterMVCApril2026Model> model = customerBal.GetAllCustomerMaster();

            LogInfo.LogDetailToFile("CustomerListApril2026 - Customer List Loaded");

            LogInfo.LogDetailToFile("MasterCtrl-CustomerListApril2026 Action- Start-End");

            return View("CustomerListApril2026", model);
        }


        // Add New Customer - GET
        [HttpGet]
        public ActionResult AddNewCustomerApril2026()
        {
            LogInfo.LogDetailToFile("MasterCtrl-AddNewCustomerApril2026 Action(httpget)- Start");

            // Branch Dropdown
            DataTable dtBranch = customerBal.BindBranch();

            LogInfo.LogDetailToFile("AddNewCustomerApril2026 - Branch Data Loaded");

            List<SelectListItem> branch = new List<SelectListItem>();
            branch.Add(new SelectListItem() { Text = "--Select Branch--", Value = "" });

            foreach (DataRow dr in dtBranch.Rows)
            {
                branch.Add(new SelectListItem()
                {
                    Text = dr["BranchName"].ToString(),
                    Value = dr["BranchId"].ToString()
                });
            }

            ViewBag.BranchId = branch;

            LogInfo.LogDetailToFile("AddNewCustomerApril2026 - Branch Dropdown Loaded");

            // Country Dropdown
            DataTable dtCountry = customerBal.BindCountry();

            LogInfo.LogDetailToFile("AddNewCustomerApril2026 - Country Data Loaded");

            List<SelectListItem> country = new List<SelectListItem>();
            country.Add(new SelectListItem() { Text = "--Select Country--", Value = "" });

            foreach (DataRow dr in dtCountry.Rows)
            {
                country.Add(new SelectListItem()
                {
                    Text = dr["Country"].ToString(),
                    Value = dr["CountryId"].ToString()
                });
            }

            ViewBag.CountryId = country;

            LogInfo.LogDetailToFile("AddNewCustomerApril2026 - Country Dropdown Loaded");

            // State Dropdown
            List<SelectListItem> state = new List<SelectListItem>();
            state.Add(new SelectListItem() { Text = "--Select State--", Value = "" });
            ViewBag.StateId = state;

            LogInfo.LogDetailToFile("AddNewCustomerApril2026 - State Dropdown Initialized");

            // City Dropdown
            List<SelectListItem> city = new List<SelectListItem>();
            city.Add(new SelectListItem() { Text = "--Select City--", Value = "" });
            ViewBag.CityId = city;

            LogInfo.LogDetailToFile("AddNewCustomerApril2026 - City Dropdown Initialized");

            LogInfo.LogDetailToFile("MasterCtrl-AddNewCustomerApril2026 Action(httpget)- Start-End");

            return PartialView("_AddNewCustomerApril2026", new CustomerMasterMVCApril2026Model());
        }


        // Get State By Country
        [HttpGet]
        public JsonResult GetStateByCountry(int countryId)
        {
            LogInfo.LogDetailToFile("MasterCtrl-GetStateByCountry Action(httpget)- Start");

            LogInfo.LogDetailToFile("GetStateByCountry - Country Id : " + countryId);

            try
            {
                DataTable dtState = customerBal.BindState(countryId);

                LogInfo.LogDetailToFile("GetStateByCountry - State Data Loaded");

                List<SelectListItem> state = new List<SelectListItem>();
                state.Add(new SelectListItem() { Text = "--Select State--", Value = "" });

                foreach (DataRow dr in dtState.Rows)
                {
                    state.Add(new SelectListItem()
                    {
                        Text = dr["State"].ToString(),
                        Value = dr["StateId"].ToString()
                    });
                }

                LogInfo.LogDetailToFile("GetStateByCountry - State Dropdown Prepared");
                LogInfo.LogDetailToFile("MasterCtrl-GetStateByCountry Action(httpget)- Start-End");

                return Json(state, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("GetStateByCountry - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("MasterCtrl-GetStateByCountry Action(httpget)- Start-End");

                return Json(new
                {
                    Status = false,
                    Message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }


        // Get City By State
        [HttpGet]
        public JsonResult GetCityByState(int stateId)
        {
            LogInfo.LogDetailToFile("MasterCtrl-GetCityByState Action(httpget)- Start");

            LogInfo.LogDetailToFile("GetCityByState - State Id : " + stateId);

            try
            {
                DataTable dtCity = customerBal.BindCity(stateId);

                LogInfo.LogDetailToFile("GetCityByState - City Data Loaded");

                List<SelectListItem> city = new List<SelectListItem>();
                city.Add(new SelectListItem() { Text = "--Select City--", Value = "" });

                foreach (DataRow dr in dtCity.Rows)
                {
                    city.Add(new SelectListItem()
                    {
                        Text = dr["City"].ToString(),
                        Value = dr["CityId"].ToString()
                    });
                }

                LogInfo.LogDetailToFile("GetCityByState - City Dropdown Prepared");
                LogInfo.LogDetailToFile("MasterCtrl-GetCityByState Action(httpget)- Start-End");

                return Json(city, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("GetCityByState - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("MasterCtrl-GetCityByState Action(httpget)- Start-End");

                return Json(new
                {
                    Status = false,
                    Message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }


        // Search Customer
        [HttpGet]
        public JsonResult SearchCustomer(int id)
        {
            LogInfo.LogDetailToFile("MasterCtrl-SearchCustomer Action(httpget)- Start");

            LogInfo.LogDetailToFile("SearchCustomer - Customer Id : " + id);

            try
            {
                CustomerMasterMVCApril2026Model obj = customerBal.GetCustomerMasterById(id);

                LogInfo.LogDetailToFile("SearchCustomer - Customer Details Loaded");
                LogInfo.LogDetailToFile("MasterCtrl-SearchCustomer Action(httpget)- Start-End");

                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("SearchCustomer - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("MasterCtrl-SearchCustomer Action(httpget)- Start-End");

                return Json(new
                {
                    Status = false,
                    Message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }


        // Add New Customer - POST
        [HttpPost]
        public JsonResult AddNewCustomerApril2026(CustomerMasterMVCApril2026Model obj)
        {
            LogInfo.LogDetailToFile("MasterCtrl-AddNewCustomerApril2026 Action(httppost)- Start");

            try
            {
                if (!ModelState.IsValid)
                {
                    LogInfo.LogDetailToFile("AddNewCustomerApril2026 - ModelState IsValid False");

                    string message = "Please enter all required fields.";

                    if (ModelState["CustName"] != null &&
                        ModelState["CustName"].Errors.Count > 0)
                    {
                        message = ModelState["CustName"].Errors[0].ErrorMessage;

                        LogInfo.LogDetailToFile("AddNewCustomerApril2026 - CustName Validation Error : " + message);
                    }

                    LogInfo.LogDetailToFile("MasterCtrl-AddNewCustomerApril2026 Action(httppost)- Start-End");

                    return Json(new
                    {
                        success = false,
                        message = message
                    });
                }

                LogInfo.LogDetailToFile("AddNewCustomerApril2026 - ModelState IsValid");

                string custCode = customerBal.SaveCustomerMaster(obj);

                LogInfo.LogDetailToFile("AddNewCustomerApril2026 - Customer Save Completed : " + custCode);

                if (!string.IsNullOrEmpty(custCode))
                {
                    LogInfo.LogDetailToFile("AddNewCustomerApril2026 - Customer Saved Successfully");
                    LogInfo.LogDetailToFile("MasterCtrl-AddNewCustomerApril2026 Action(httppost)- Start-End");

                    return Json(new
                    {
                        success = true,
                        code = custCode,
                        message = "Customer Saved Successfully."
                    });
                }

                LogInfo.LogDetailToFile("AddNewCustomerApril2026 - Unable To Save Customer");
                LogInfo.LogDetailToFile("MasterCtrl-AddNewCustomerApril2026 Action(httppost)- Start-End");

                return Json(new
                {
                    success = false,
                    message = "Unable To Save Customer."
                });
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("AddNewCustomerApril2026 - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("MasterCtrl-AddNewCustomerApril2026 Action(httppost)- Start-End");

                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }


        // Edit Customer - GET
        [HttpGet]
        public ActionResult EditCustomerApril2026(int id)
        {
            LogInfo.LogDetailToFile("MasterCtrl-EditCustomerApril2026 Action(httpget)- Start");

            LogInfo.LogDetailToFile("EditCustomerApril2026 - Customer Id : " + id);

            CustomerMasterMVCApril2026Model model = customerBal.GetCustomerMasterById(id);

            LogInfo.LogDetailToFile("EditCustomerApril2026 - Customer Details Loaded");

            if (model == null)
            {
                LogInfo.LogDetailToFile("EditCustomerApril2026 - Customer Not Found");
                LogInfo.LogDetailToFile("MasterCtrl-EditCustomerApril2026 Action(httpget)- Start-End");

                return HttpNotFound();
            }

            // Branch Dropdown
            DataTable dtBranch = customerBal.BindBranch();

            LogInfo.LogDetailToFile("EditCustomerApril2026 - Branch Data Loaded");

            List<SelectListItem> branch = new List<SelectListItem>();
            branch.Add(new SelectListItem() { Text = "--Select Branch--", Value = "" });

            foreach (DataRow dr in dtBranch.Rows)
            {
                branch.Add(new SelectListItem()
                {
                    Text = dr["BranchName"].ToString(),
                    Value = dr["BranchId"].ToString(),
                    Selected = model.BranchId.HasValue &&
                               model.BranchId.Value.ToString() == dr["BranchId"].ToString()
                });
            }

            ViewBag.BranchId = branch;

            LogInfo.LogDetailToFile("EditCustomerApril2026 - Branch Dropdown Loaded");

            // Country Dropdown
            DataTable dtCountry = customerBal.BindCountry();

            LogInfo.LogDetailToFile("EditCustomerApril2026 - Country Data Loaded");

            List<SelectListItem> country = new List<SelectListItem>();
            country.Add(new SelectListItem() { Text = "--Select Country--", Value = "" });

            foreach (DataRow dr in dtCountry.Rows)
            {
                country.Add(new SelectListItem()
                {
                    Text = dr["Country"].ToString(),
                    Value = dr["CountryId"].ToString(),
                    Selected = model.CountryId.HasValue &&
                               model.CountryId.Value.ToString() == dr["CountryId"].ToString()
                });
            }

            ViewBag.CountryId = country;

            LogInfo.LogDetailToFile("EditCustomerApril2026 - Country Dropdown Loaded");

            // State Dropdown
            List<SelectListItem> state = new List<SelectListItem>();
            state.Add(new SelectListItem() { Text = "--Select State--", Value = "" });

            if (model.CountryId.HasValue)
            {
                DataTable dtState = customerBal.BindState(model.CountryId.Value);

                LogInfo.LogDetailToFile("EditCustomerApril2026 - State Data Loaded");

                foreach (DataRow dr in dtState.Rows)
                {
                    state.Add(new SelectListItem()
                    {
                        Text = dr["State"].ToString(),
                        Value = dr["StateId"].ToString(),
                        Selected = model.StateId.HasValue &&
                                   model.StateId.Value.ToString() == dr["StateId"].ToString()
                    });
                }
            }

            ViewBag.StateId = state;

            LogInfo.LogDetailToFile("EditCustomerApril2026 - State Dropdown Loaded");

            // City Dropdown
            List<SelectListItem> city = new List<SelectListItem>();
            city.Add(new SelectListItem() { Text = "--Select City--", Value = "" });

            if (model.StateId.HasValue)
            {
                DataTable dtCity = customerBal.BindCity(model.StateId.Value);

                LogInfo.LogDetailToFile("EditCustomerApril2026 - City Data Loaded");

                foreach (DataRow dr in dtCity.Rows)
                {
                    city.Add(new SelectListItem()
                    {
                        Text = dr["City"].ToString(),
                        Value = dr["CityId"].ToString(),
                        Selected = model.CityId.HasValue &&
                                   model.CityId.Value.ToString() == dr["CityId"].ToString()
                    });
                }
            }

            ViewBag.CityId = city;

            LogInfo.LogDetailToFile("EditCustomerApril2026 - City Dropdown Loaded");
            LogInfo.LogDetailToFile("MasterCtrl-EditCustomerApril2026 Action(httpget)- Start-End");

            return PartialView("_EditCustomerApril2026", model);
        }


        // Update Customer
        [HttpPost]
        public JsonResult UpdateCustomerApril2026(CustomerMasterMVCApril2026Model obj)
        {
            LogInfo.LogDetailToFile("MasterCtrl-UpdateCustomerApril2026 Action(httppost)- Start");

            try
            {
                LogInfo.LogDetailToFile("UpdateCustomerApril2026 - Customer Id : " + obj.Id);

                if (!ModelState.IsValid)
                {
                    LogInfo.LogDetailToFile("UpdateCustomerApril2026 - ModelState IsValid False");

                    string message = "Please enter all required fields.";

                    if (ModelState["CustName"] != null &&
                        ModelState["CustName"].Errors.Count > 0)
                    {
                        message = ModelState["CustName"].Errors[0].ErrorMessage;

                        LogInfo.LogDetailToFile("UpdateCustomerApril2026 - CustName Validation Error : " + message);
                    }

                    LogInfo.LogDetailToFile("MasterCtrl-UpdateCustomerApril2026 Action(httppost)- Start-End");

                    return Json(new
                    {
                        Status = false,
                        Message = message
                    });
                }

                LogInfo.LogDetailToFile("UpdateCustomerApril2026 - ModelState IsValid");

                int result = customerBal.UpdateCustomerMaster(obj);

                LogInfo.LogDetailToFile("UpdateCustomerApril2026 - Update Result : " + result);

                if (result > 0)
                {
                    LogInfo.LogDetailToFile("UpdateCustomerApril2026 - Customer Updated Successfully");
                    LogInfo.LogDetailToFile("MasterCtrl-UpdateCustomerApril2026 Action(httppost)- Start-End");

                    return Json(new
                    {
                        Status = true,
                        Message = "Customer Updated Successfully."
                    });
                }

                LogInfo.LogDetailToFile("UpdateCustomerApril2026 - Unable To Update Customer");
                LogInfo.LogDetailToFile("MasterCtrl-UpdateCustomerApril2026 Action(httppost)- Start-End");

                return Json(new
                {
                    Status = false,
                    Message = "Unable To Update Customer."
                });
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("UpdateCustomerApril2026 - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("MasterCtrl-UpdateCustomerApril2026 Action(httppost)- Start-End");

                return Json(new
                {
                    Status = false,
                    Message = ex.Message
                });
            }
        }


        // Delete Customer
        [HttpPost]
        public JsonResult DeleteCustomerMasterById(int id)
        {
            LogInfo.LogDetailToFile("MasterCtrl-DeleteCustomerMasterById Action(httppost)- Start");

            LogInfo.LogDetailToFile("DeleteCustomerMasterById - Customer Id : " + id);

            try
            {
                int result = customerBal.DeleteCustomerMasterById(id);

                LogInfo.LogDetailToFile("DeleteCustomerMasterById - Delete Result : " + result);

                if (result > 0)
                {
                    LogInfo.LogDetailToFile("DeleteCustomerMasterById - Customer Deleted Successfully");
                    LogInfo.LogDetailToFile("MasterCtrl-DeleteCustomerMasterById Action(httppost)- Start-End");

                    return Json(new
                    {
                        Status = true,
                        Message = "Customer Deleted Successfully."
                    });
                }

                LogInfo.LogDetailToFile("DeleteCustomerMasterById - Unable To Delete Customer");
                LogInfo.LogDetailToFile("MasterCtrl-DeleteCustomerMasterById Action(httppost)- Start-End");

                return Json(new
                {
                    Status = false,
                    Message = "Unable To Delete Customer."
                });
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("DeleteCustomerMasterById - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("MasterCtrl-DeleteCustomerMasterById Action(httppost)- Start-End");

                return Json(new
                {
                    Status = false,
                    Message = ex.Message
                });
            }
        }







        //////////////////////////////////// Supplier Master April2026 ///////////////////////////////////////////////////




        // 27/08/2026

        // Supplier Master
        SupplierMasterMVCApril2026BAL supplierBal = new SupplierMasterMVCApril2026BAL();


        // Supplier Master Page
        [HttpGet]
        public ActionResult SupplierMasterApril2026()
        {
            LogInfo.LogDetailToFile("MasterCtrl-SupplierMasterApril2026 Action(httpget)- Start");

            List<SupplierMasterMVCApril2026Model> supplierList = supplierBal.GetAllSupplierMaster();

            LogInfo.LogDetailToFile("SupplierMasterApril2026 - Supplier List Loaded");
            LogInfo.LogDetailToFile("MasterCtrl-SupplierMasterApril2026 Action(httpget)- Start-End");

            return View(supplierList);
        }


        // Get Supplier Codes
        [HttpGet]
        public JsonResult GetSupplierMasterCodes()
        {
            LogInfo.LogDetailToFile("MasterCtrl-GetSupplierMasterCodes Action(httpget)- Start");

            DataTable dt = supplierBal.BindSupplierCode();

            LogInfo.LogDetailToFile("GetSupplierMasterCodes - Supplier Code Data Loaded");

            List<SelectListItem> supplierCodeList = new List<SelectListItem>();

            foreach (DataRow dr in dt.Rows)
            {
                supplierCodeList.Add(new SelectListItem
                {
                    Text = dr["SuppCode"].ToString(),
                    Value = dr["Id"].ToString()
                });
            }

            LogInfo.LogDetailToFile("GetSupplierMasterCodes - Supplier Codes Prepared");
            LogInfo.LogDetailToFile("MasterCtrl-GetSupplierMasterCodes Action(httpget)- Start-End");

            return Json(supplierCodeList, JsonRequestBehavior.AllowGet);
        }


        // Get Supplier Names
        [HttpGet]
        public JsonResult GetSupplierMasterNames()
        {
            LogInfo.LogDetailToFile("MasterCtrl-GetSupplierMasterNames Action(httpget)- Start");

            DataTable dt = supplierBal.BindSupplierName();

            LogInfo.LogDetailToFile("GetSupplierMasterNames - Supplier Name Data Loaded");

            List<SelectListItem> supplierNameList = new List<SelectListItem>();

            foreach (DataRow dr in dt.Rows)
            {
                supplierNameList.Add(new SelectListItem
                {
                    Text = dr["SuppName"].ToString(),
                    Value = dr["Id"].ToString()
                });
            }

            LogInfo.LogDetailToFile("GetSupplierMasterNames - Supplier Names Prepared");
            LogInfo.LogDetailToFile("MasterCtrl-GetSupplierMasterNames Action(httpget)- Start-End");

            return Json(supplierNameList, JsonRequestBehavior.AllowGet);
        }


        // Get Supplier Details By Code
        [HttpGet]
        public JsonResult GetSupplierDetailsByCode(string suppCode)
        {
            LogInfo.LogDetailToFile("MasterCtrl-GetSupplierDetailsByCode Action(httpget)- Start");

            LogInfo.LogDetailToFile("GetSupplierDetailsByCode - Supplier Code : " + suppCode);

            SupplierMasterMVCApril2026Model model = supplierBal.GetSupplierDetailsByCode(suppCode);

            LogInfo.LogDetailToFile("GetSupplierDetailsByCode - Supplier Details Loaded");
            LogInfo.LogDetailToFile("MasterCtrl-GetSupplierDetailsByCode Action(httpget)- Start-End");

            return Json(model, JsonRequestBehavior.AllowGet);
        }


        // Get Supplier Details By Id
        [HttpGet]
        public JsonResult GetSupplierDetailsById(int id)
        {
            LogInfo.LogDetailToFile("MasterCtrl-GetSupplierDetailsById Action(httpget)- Start");

            LogInfo.LogDetailToFile("GetSupplierDetailsById - Supplier Id : " + id);

            SupplierMasterMVCApril2026Model model = supplierBal.GetSupplierMasterById(id);

            LogInfo.LogDetailToFile("GetSupplierDetailsById - Supplier Details Loaded");
            LogInfo.LogDetailToFile("MasterCtrl-GetSupplierDetailsById Action(httpget)- Start-End");

            return Json(model, JsonRequestBehavior.AllowGet);
        }


        // Add New Supplier
        [HttpGet]
        public ActionResult AddNewSupplierApril2026()
        {
            LogInfo.LogDetailToFile("MasterCtrl-AddNewSupplierApril2026 Action(httpget)- Start");

            BindSupplierLocationDropdowns();

            LogInfo.LogDetailToFile("AddNewSupplierApril2026 - Location Dropdowns Loaded");
            LogInfo.LogDetailToFile("MasterCtrl-AddNewSupplierApril2026 Action(httpget)- Start-End");

            return PartialView("_AddNewSupplierApril2026", new SupplierMasterMVCApril2026Model());
        }


        // Save Supplier
        [HttpPost]
        public JsonResult AddNewSupplierApril2026(SupplierMasterMVCApril2026Model model)
        {
            LogInfo.LogDetailToFile("MasterCtrl-AddNewSupplierApril2026 Action(httppost)- Start");

            try
            {
                if (!ModelState.IsValid)
                {
                    LogInfo.LogDetailToFile("AddNewSupplierApril2026 - ModelState IsValid False");

                    string message = "Please enter all required fields.";

                    if (ModelState["SuppName"] != null &&
                        ModelState["SuppName"].Errors.Count > 0)
                    {
                        message = ModelState["SuppName"].Errors[0].ErrorMessage;

                        LogInfo.LogDetailToFile("AddNewSupplierApril2026 - SuppName Validation Error : " + message);
                    }

                    LogInfo.LogDetailToFile("MasterCtrl-AddNewSupplierApril2026 Action(httppost)- Start-End");

                    return Json(new
                    {
                        success = false,
                        message = message
                    });
                }

                LogInfo.LogDetailToFile("AddNewSupplierApril2026 - ModelState IsValid");

                string suppCode = supplierBal.SaveSupplierMaster(model);

                LogInfo.LogDetailToFile("AddNewSupplierApril2026 - Supplier Save Completed : " + suppCode);

                if (!string.IsNullOrEmpty(suppCode))
                {
                    LogInfo.LogDetailToFile("AddNewSupplierApril2026 - Supplier Saved Successfully");
                    LogInfo.LogDetailToFile("MasterCtrl-AddNewSupplierApril2026 Action(httppost)- Start-End");

                    return Json(new
                    {
                        success = true,
                        code = suppCode,
                        message = "Supplier Saved Successfully."
                    });
                }

                LogInfo.LogDetailToFile("AddNewSupplierApril2026 - Unable To Save Supplier");
                LogInfo.LogDetailToFile("MasterCtrl-AddNewSupplierApril2026 Action(httppost)- Start-End");

                return Json(new
                {
                    success = false,
                    message = "Unable To Save Supplier."
                });
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("AddNewSupplierApril2026 - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("MasterCtrl-AddNewSupplierApril2026 Action(httppost)- Start-End");

                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }


        // Edit Supplier
        [HttpGet]
        public ActionResult EditSupplierApril2026(int id)
        {
            LogInfo.LogDetailToFile("MasterCtrl-EditSupplierApril2026 Action(httpget)- Start");

            LogInfo.LogDetailToFile("EditSupplierApril2026 - Supplier Id : " + id);

            SupplierMasterMVCApril2026Model model = supplierBal.GetSupplierMasterById(id);

            LogInfo.LogDetailToFile("EditSupplierApril2026 - Supplier Details Loaded");

            if (model == null)
            {
                LogInfo.LogDetailToFile("EditSupplierApril2026 - Supplier Not Found");
                LogInfo.LogDetailToFile("MasterCtrl-EditSupplierApril2026 Action(httpget)- Start-End");

                return HttpNotFound();
            }

            BindSupplierLocationDropdowns(model);

            LogInfo.LogDetailToFile("EditSupplierApril2026 - Location Dropdowns Loaded");
            LogInfo.LogDetailToFile("MasterCtrl-EditSupplierApril2026 Action(httpget)- Start-End");

            return PartialView("_EditSupplierApril2026", model);
        }


        // Update Supplier
        [HttpPost]
        public JsonResult UpdateSupplierApril2026(SupplierMasterMVCApril2026Model model)
        {
            LogInfo.LogDetailToFile("MasterCtrl-UpdateSupplierApril2026 Action(httppost)- Start");

            try
            {
                LogInfo.LogDetailToFile("UpdateSupplierApril2026 - Supplier Id : " + model.Id);

                if (!ModelState.IsValid)
                {
                    LogInfo.LogDetailToFile("UpdateSupplierApril2026 - ModelState IsValid False");

                    string message = "Please enter all required fields.";

                    if (ModelState["SuppName"] != null &&
                        ModelState["SuppName"].Errors.Count > 0)
                    {
                        message = ModelState["SuppName"].Errors[0].ErrorMessage;

                        LogInfo.LogDetailToFile("UpdateSupplierApril2026 - SuppName Validation Error : " + message);
                    }

                    LogInfo.LogDetailToFile("MasterCtrl-UpdateSupplierApril2026 Action(httppost)- Start-End");

                    return Json(new
                    {
                        Status = false,
                        Message = message
                    });
                }

                LogInfo.LogDetailToFile("UpdateSupplierApril2026 - ModelState IsValid");

                int result = supplierBal.UpdateSupplierMaster(model);

                LogInfo.LogDetailToFile("UpdateSupplierApril2026 - Update Result : " + result);

                if (result > 0)
                {
                    LogInfo.LogDetailToFile("UpdateSupplierApril2026 - Supplier Updated Successfully");
                    LogInfo.LogDetailToFile("MasterCtrl-UpdateSupplierApril2026 Action(httppost)- Start-End");

                    return Json(new
                    {
                        Status = true,
                        Message = "Supplier Updated Successfully."
                    });
                }

                LogInfo.LogDetailToFile("UpdateSupplierApril2026 - Unable To Update Supplier");
                LogInfo.LogDetailToFile("MasterCtrl-UpdateSupplierApril2026 Action(httppost)- Start-End");

                return Json(new
                {
                    Status = false,
                    Message = "Unable To Update Supplier."
                });
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("UpdateSupplierApril2026 - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("MasterCtrl-UpdateSupplierApril2026 Action(httppost)- Start-End");

                return Json(new
                {
                    Status = false,
                    Message = ex.Message
                });
            }
        }


        // Delete Supplier
        [HttpPost]
        public JsonResult DeleteSupplierApril2026(int id)
        {
            LogInfo.LogDetailToFile("MasterCtrl-DeleteSupplierApril2026 Action(httppost)- Start");

            LogInfo.LogDetailToFile("DeleteSupplierApril2026 - Supplier Id : " + id);

            try
            {
                int result = supplierBal.DeleteSupplierMasterById(id);

                LogInfo.LogDetailToFile("DeleteSupplierApril2026 - Delete Result : " + result);

                if (result > 0)
                {
                    LogInfo.LogDetailToFile("DeleteSupplierApril2026 - Supplier Deleted Successfully");
                    LogInfo.LogDetailToFile("MasterCtrl-DeleteSupplierApril2026 Action(httppost)- Start-End");

                    return Json(new
                    {
                        success = true,
                        message = "Supplier Deleted Successfully."
                    });
                }

                LogInfo.LogDetailToFile("DeleteSupplierApril2026 - Unable To Delete Supplier");
                LogInfo.LogDetailToFile("MasterCtrl-DeleteSupplierApril2026 Action(httppost)- Start-End");

                return Json(new
                {
                    success = false,
                    message = "Unable To Delete Supplier."
                });
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("DeleteSupplierApril2026 - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("MasterCtrl-DeleteSupplierApril2026 Action(httppost)- Start-End");

                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }


        // Get Branches
        [HttpGet]
        public JsonResult GetBranches()
        {
            LogInfo.LogDetailToFile("MasterCtrl-GetBranches Action(httpget)- Start");

            DataTable dt = supplierBal.BindBranch();

            LogInfo.LogDetailToFile("GetBranches - Branch Data Loaded");

            List<SelectListItem> branchList = new List<SelectListItem>();

            foreach (DataRow dr in dt.Rows)
            {
                branchList.Add(new SelectListItem
                {
                    Text = dr["BranchName"].ToString(),
                    Value = dr["BranchId"].ToString()
                });
            }

            LogInfo.LogDetailToFile("GetBranches - Branch List Prepared");
            LogInfo.LogDetailToFile("MasterCtrl-GetBranches Action(httpget)- Start-End");

            return Json(branchList, JsonRequestBehavior.AllowGet);
        }


        // Get Countries
        [HttpGet]
        public JsonResult GetCountries()
        {
            LogInfo.LogDetailToFile("MasterCtrl-GetCountries Action(httpget)- Start");

            DataTable dt = supplierBal.BindCountry();

            LogInfo.LogDetailToFile("GetCountries - Country Data Loaded");

            List<SelectListItem> countryList = new List<SelectListItem>();

            foreach (DataRow dr in dt.Rows)
            {
                countryList.Add(new SelectListItem
                {
                    Text = dr["CountryName"].ToString(),
                    Value = dr["CountryId"].ToString()
                });
            }

            LogInfo.LogDetailToFile("GetCountries - Country List Prepared");
            LogInfo.LogDetailToFile("MasterCtrl-GetCountries Action(httpget)- Start-End");

            return Json(countryList, JsonRequestBehavior.AllowGet);
        }


        // Get States
        [HttpGet]
        public JsonResult GetStates(int countryId)
        {
            LogInfo.LogDetailToFile("MasterCtrl-GetStates Action(httpget)- Start");

            LogInfo.LogDetailToFile("GetStates - Country Id : " + countryId);

            DataTable dt = supplierBal.BindState(countryId);

            LogInfo.LogDetailToFile("GetStates - State Data Loaded");

            List<SelectListItem> stateList = new List<SelectListItem>();

            foreach (DataRow dr in dt.Rows)
            {
                stateList.Add(new SelectListItem
                {
                    Text = dr["StateName"].ToString(),
                    Value = dr["StateId"].ToString()
                });
            }

            LogInfo.LogDetailToFile("GetStates - State List Prepared");
            LogInfo.LogDetailToFile("MasterCtrl-GetStates Action(httpget)- Start-End");

            return Json(stateList, JsonRequestBehavior.AllowGet);
        }


        // Get Cities
        [HttpGet]
        public JsonResult GetCities(int stateId)
        {
            LogInfo.LogDetailToFile("MasterCtrl-GetCities Action(httpget)- Start");

            LogInfo.LogDetailToFile("GetCities - State Id : " + stateId);

            DataTable dt = supplierBal.BindCity(stateId);

            LogInfo.LogDetailToFile("GetCities - City Data Loaded");

            List<SelectListItem> cityList = new List<SelectListItem>();

            foreach (DataRow dr in dt.Rows)
            {
                cityList.Add(new SelectListItem
                {
                    Text = dr["CityName"].ToString(),
                    Value = dr["CityId"].ToString()
                });
            }

            LogInfo.LogDetailToFile("GetCities - City List Prepared");
            LogInfo.LogDetailToFile("MasterCtrl-GetCities Action(httpget)- Start-End");

            return Json(cityList, JsonRequestBehavior.AllowGet);
        }


        // Bind Supplier Location Dropdowns
        private void BindSupplierLocationDropdowns(SupplierMasterMVCApril2026Model model = null)
        {
            LogInfo.LogDetailToFile("MasterCtrl-BindSupplierLocationDropdowns Action- Start");

            DataTable dtBranch = supplierBal.BindBranch();

            LogInfo.LogDetailToFile("BindSupplierLocationDropdowns - Branch Data Loaded");

            List<SelectListItem> branchList = new List<SelectListItem>();

            foreach (DataRow dr in dtBranch.Rows)
            {
                branchList.Add(new SelectListItem
                {
                    Text = dr["BranchName"].ToString(),
                    Value = dr["BranchId"].ToString(),
                    Selected = model != null &&
                               model.BranchId.HasValue &&
                               model.BranchId.Value.ToString() == dr["BranchId"].ToString()
                });
            }

            ViewBag.BranchList = branchList;

            LogInfo.LogDetailToFile("BindSupplierLocationDropdowns - Branch Dropdown Loaded");

            DataTable dtCountry = supplierBal.BindCountry();

            LogInfo.LogDetailToFile("BindSupplierLocationDropdowns - Country Data Loaded");

            List<SelectListItem> countryList = new List<SelectListItem>();

            foreach (DataRow dr in dtCountry.Rows)
            {
                countryList.Add(new SelectListItem
                {
                    Text = dr["CountryName"].ToString(),
                    Value = dr["CountryId"].ToString(),
                    Selected = model != null &&
                               model.CountryId.HasValue &&
                               model.CountryId.Value.ToString() == dr["CountryId"].ToString()
                });
            }

            ViewBag.CountryList = countryList;

            LogInfo.LogDetailToFile("BindSupplierLocationDropdowns - Country Dropdown Loaded");

            ViewBag.StateList = new List<SelectListItem>();
            ViewBag.CityList = new List<SelectListItem>();

            if (model != null && model.CountryId.HasValue)
            {
                DataTable dtState = supplierBal.BindState(model.CountryId.Value);

                LogInfo.LogDetailToFile("BindSupplierLocationDropdowns - State Data Loaded");

                List<SelectListItem> stateList = new List<SelectListItem>();

                foreach (DataRow dr in dtState.Rows)
                {
                    stateList.Add(new SelectListItem
                    {
                        Text = dr["StateName"].ToString(),
                        Value = dr["StateId"].ToString(),
                        Selected = model.StateId.HasValue &&
                                   model.StateId.Value.ToString() == dr["StateId"].ToString()
                    });
                }

                ViewBag.StateList = stateList;

                LogInfo.LogDetailToFile("BindSupplierLocationDropdowns - State Dropdown Loaded");
            }

            if (model != null && model.StateId.HasValue)
            {
                DataTable dtCity = supplierBal.BindCity(model.StateId.Value);

                LogInfo.LogDetailToFile("BindSupplierLocationDropdowns - City Data Loaded");

                List<SelectListItem> cityList = new List<SelectListItem>();

                foreach (DataRow dr in dtCity.Rows)
                {
                    cityList.Add(new SelectListItem
                    {
                        Text = dr["CityName"].ToString(),
                        Value = dr["CityId"].ToString(),
                        Selected = model.CityId.HasValue &&
                                   model.CityId.Value.ToString() == dr["CityId"].ToString()
                    });
                }

                ViewBag.CityList = cityList;

                LogInfo.LogDetailToFile("BindSupplierLocationDropdowns - City Dropdown Loaded");
            }

            LogInfo.LogDetailToFile("MasterCtrl-BindSupplierLocationDropdowns Action- Start-End");
        }
    }
}








