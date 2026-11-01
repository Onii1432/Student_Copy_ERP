using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using StandardMetals.BAL;
using StandardMetals.DAL;
using StandardMetals.MODEL;
using StandardMetals.WebAPI.AuthFilter;

namespace StandardMetals.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    //[BasicAuthentication]
    public class ItemMasterController : ApiController
    {

        ItemMasterMngr itemBAL = new ItemMasterMngr();
        TaxInvoiceMnger _TaxInvoiceManager = new TaxInvoiceMnger();

        [HttpGet]
        public List<ItemMasterModel> GetAllItemMasterData()
        {
            TaxInvoiceMnger _TaxInvoiceManager1 = new TaxInvoiceMnger();
            DataTable dt = new DataTable();
            List<ItemMasterModel> lst = null;
            lst = _TaxInvoiceManager1.GetAllItemMasterData();
            return lst;
        }



        [HttpGet]
        public List<ItemMasterModel> FillItemMaster()
        {
            // List<NameCode> ItemDtl = new List<NameCode>();
            TaxInvoiceMnger _TaxInvoiceManager1 = new TaxInvoiceMnger();
            DataTable dt = new DataTable();
            List<ItemMasterModel> lst = null;
            lst = _TaxInvoiceManager1.FillItemMaster();
            return lst;
        }


        [HttpGet]
        public DataTable BindManfacturer()
        {
            DataTable dt = new DataTable();
            dt = itemBAL.BindManfacturer();
            return dt;
        }


        [HttpGet]
        public DataTable BindColor()
        {
            DataTable dt = new DataTable();
            dt = itemBAL.BindColor();
            return dt;
        }

        [HttpGet]
        public DataTable BindUom()
        {
            DataTable dt = new DataTable();
            dt = itemBAL.BindUom();
            return dt;
        }
        [HttpGet]
        public DataTable BindCategory()
        {
            DataTable dt = new DataTable();
            dt = itemBAL.BindCategory(0);
            return dt;
        }


        [HttpPost]
        public DataTable BindSubCategory(int CategoryId)
        {
            DataTable dt = new DataTable();
            dt = itemBAL.BindCategory(CategoryId);
            return dt;
        }

        [HttpGet]
        public DataTable BindSubCategory1(int CategoryId)
        {
            DataTable dt = new DataTable();
            dt = itemBAL.BindCategory(CategoryId);
            return dt;
        }


        [HttpGet]
        public ItemMasterModel SearchItemMaster(string ItemCode)
        {
            ItemMasterModel ItemModel = new ItemMasterModel();
            DataTable dt = new DataTable();
            ItemMasterMngr ItemBal = new ItemMasterMngr();
            dt = ItemBal.RetriveItem(ItemCode);
            if (dt.Rows.Count > 0)
            {
                ItemModel.ItemCode = dt.Rows[0]["ItemCode"].ToString();
                ItemModel.ItemName = dt.Rows[0]["ItemName"].ToString();
                ItemModel.ManufacturerId = Convert.ToInt32(dt.Rows[0]["ManufacturerId"]);
                ItemModel.Material = dt.Rows[0]["Material"].ToString();
                ItemModel.ItemCategoryId = Convert.ToInt32(dt.Rows[0]["CategoryId"]);
                ItemModel.ItemSubCategoryId = Convert.ToInt32(dt.Rows[0]["SubCategoryId"]);
                ItemModel.ColourId = Convert.ToInt32(dt.Rows[0]["ColourId"]);
                ItemModel.UnitId = Convert.ToInt32(dt.Rows[0]["UnitId"]);
                ItemModel.HSNCODE = dt.Rows[0]["HSNCODE"].ToString();
                ItemModel.GSTRate = Convert.ToDecimal(dt.Rows[0]["GSTRate"].ToString());
                ItemModel.PurchaseCost = Convert.ToDecimal(dt.Rows[0]["PurchaseCost"].ToString());
                ItemModel.SellingPrice = Convert.ToDecimal(dt.Rows[0]["SellingPrice"].ToString());
            }

            return ItemModel;
        }

        [HttpPost]
        public string SaveData(ItemMasterModel SaveData)
        {
            string datastatus = "";
            ItemMasterMngr ItemBal = new ItemMasterMngr();
            int res = ItemBal.SaveITemMaster(SaveData);

            if (res == 1)
            {
                datastatus = "Data Saved !";
            }
            else
            {
                datastatus = "Data not Saved !";
            }
            return datastatus;
        }


        [HttpPost]
        public string UpdateData(ItemMasterModel UpdateData)
        {
            string datastatus = "";
            ItemMasterMngr ItemBal = new ItemMasterMngr();
            int res = ItemBal.Update_ItemMaster(UpdateData);

            if (res == 1)
            {
                datastatus = "Data Updated !";
            }
            else
            {
                datastatus = "Data not Updated !";
            }
            return datastatus;
        }

        [HttpPost]
        public string SaveDataGridView(ItemMasterModel SaveGridViewData)
        {
            string datastatus = "";
            ItemMasterMngr ItemBal = new ItemMasterMngr();
            int res = ItemBal.SaveGridViewData(SaveGridViewData);

            if (res == 1)
            {
                datastatus = "Data Saved !";
            }
            else
            {
                datastatus = "Data not Saved !";
            }
            return datastatus;
        }

        public string UpdateDataGridView(ItemMasterModel UpdateGridViewData)
        {
            string datastatus = "";
            ItemMasterMngr ItemBal = new ItemMasterMngr();
            int res = ItemBal.UpdateDataGridView(UpdateGridViewData);

            if (res == 1)
            {
                datastatus = "Data Saved !";
            }
            else
            {
                datastatus = "Data not Saved !";
            }
            return datastatus;
        }

        [HttpGet]
        public ItemMasterModel GetItemDataById(int ID)
        {
            ItemMasterModel ItemModel = new ItemMasterModel();
            DataTable dt = new DataTable();
            ItemMasterMngr ItemBal = new ItemMasterMngr();
            dt = ItemBal.RetrieveDataByItemCode(ID);
            if (dt.Rows.Count > 0)
            {
                ItemModel.ItemCode = dt.Rows[0]["ItemCode"].ToString();
                ItemModel.ItemName = dt.Rows[0]["ItemName"].ToString();
                ItemModel.ManufacturerId = Convert.ToInt32(dt.Rows[0]["ManufacturerId"]);
                ItemModel.Material = dt.Rows[0]["Material"].ToString();
                ItemModel.ItemCategoryId = Convert.ToInt32(dt.Rows[0]["CategoryId"]);
                ItemModel.ItemSubCategoryId = Convert.ToInt32 (dt.Rows[0]["SubCategoryId"]);
                ItemModel.ColourId = Convert.ToInt32 (dt.Rows[0]["ColourId"]);
                ItemModel.UnitId = Convert.ToInt32 (dt.Rows[0]["UnitId"]);
                ItemModel.HSNCODE = dt.Rows[0]["HSNCODE"].ToString();
                ItemModel.GSTRate = Convert.ToDecimal(dt.Rows[0]["GSTRate"]);
                ItemModel.PurchaseCost = Convert.ToDecimal(dt.Rows[0]["PurchaseCost"]);
                ItemModel.SellingPrice = Convert.ToDecimal(dt.Rows[0]["SellingPrice"]);
            }

            return ItemModel;
        }




    }


}
