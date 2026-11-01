using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StandardMetals.MODEL;
using StandardMetals.BAL;
using StandardMetals.DAL;

namespace StandardMetals.WebApp.Controllers
{
    public class PurchaseController : Controller
    {
        indentBAL bal = new indentBAL();
        // GET: Purchase
        public ActionResult IndentMaster()
        {

            ConncetionClass db = new ConncetionClass();

            // Execute the stored procedure to get the new indent details
            DataSet ds = db.ExecuteStoredProcedure("usp_GetNewIndentNumber");

            // Extract the new indent number, date, and time
            DataTable dt = ds.Tables[0];
            string newIndentNumber = dt.Rows[0]["NewIndentNumber"].ToString();

            // Handle date and time conversion
            DateTime indentDate = DateTime.MinValue;
            DateTime requiredate = DateTime.MinValue;
            if (DateTime.TryParse(dt.Rows[0]["IndentDate"].ToString(), out indentDate))
            {
                indentDate = Convert.ToDateTime(dt.Rows[0]["IndentDate"]);
                
            }

            if (DateTime.TryParse(dt.Rows[0]["RequiredDate"].ToString(), out requiredate))
            {
                
                requiredate = Convert.ToDateTime(dt.Rows[0]["RequiredDate"]);
            }

            string indentTime = dt.Rows[0]["IndentTime"].ToString();
           


            // Create your model instance
            IndentMasterModel indent = new IndentMasterModel
            {
                IndentNoAutoGen = newIndentNumber,
                IndentDate = indentDate,
                IndentTime = indentTime,
                RequiredDate = requiredate
            };

            

            ViewBag.lst = GetIndentNoAutoGen();
            ViewBag.lst1 = GetIndentType();
            ViewBag.lst2 = GetItemnameType();
            ViewBag.lst3 = GetItemType();
            ViewBag.lst4 = GetDepartment();
            ViewBag.lst5 = GetUnit();
            return View(indent);
        }

        [HttpPost]
        public ActionResult SaveIndent()
        {
            return View("IndentMaster");
        }


        public List<IndentMasterModel> GetIndentNoAutoGen()
        {
            DataTable dt = new DataTable();
            dt = bal.GetIndentNoAutoGen();
            List<IndentMasterModel> lst = new List<IndentMasterModel>();
            foreach (DataRow item in dt.Rows)
            {
                lst.Add(new IndentMasterModel()
                {
                    IndentId = Convert.ToInt32(item["IndentId"]),
                    IndentNoAutoGen = item["IndentNoAutoGen"].ToString()
                });
            }
            return lst;
        }

        public List<IndentMasterModel> GetIndentType()
        {
            DataTable dt = new DataTable();
            dt = bal.GetIndentType();
            List<IndentMasterModel> lst1 = new List<IndentMasterModel>();
            foreach (DataRow item in dt.Rows)
            {
                lst1.Add(new IndentMasterModel()
                {
                    IndentTypeId = Convert.ToInt32(item["IndentTypeId"]),
                    IndentType = item["IndentType"].ToString()
                });
            }
            return lst1;
        }

        public List<IndentMasterModel> GetItemnameType()
        {
            DataTable dt = new DataTable();
            dt = bal.GetItemnameType();
            List<IndentMasterModel> lst2 = new List<IndentMasterModel>();
            foreach (DataRow item in dt.Rows)
            {
                lst2.Add(new IndentMasterModel()
                {
                    ItemName = item["ItemName"].ToString(),
                    //ItemCode = item["ItemCode"].ToString()
                });
            }
            return lst2;
        }

        public List<IndentMasterModel> GetItemType()
        {
            DataTable dt = new DataTable();
            dt = bal.GetItemType();
            List<IndentMasterModel> lst3 = new List<IndentMasterModel>();
            foreach (DataRow item in dt.Rows)
            {
                lst3.Add(new IndentMasterModel()
                {
                    ItemCode = item["ItemCode"].ToString(),
                    ItemName = item["ItemName"].ToString()
                });
            }
            return lst3;
        }

        public List<IndentMasterModel> GetDepartment()
        {
            DataTable dt = new DataTable();
            dt = bal.GetDepartment();
            List<IndentMasterModel> lst4 = new List<IndentMasterModel>();
            foreach (DataRow item in dt.Rows)
            {
                lst4.Add(new IndentMasterModel()
                {
                    DepartmentId = Convert.ToInt32(item["did"]),
                    DepartmentName = item["dname"].ToString()
                });
            }
            return lst4;
        }

        public List<IndentMasterModel> GetUnit()
        {
            DataTable dt = new DataTable();
            dt = bal.GetUnit();
            List<IndentMasterModel> lst5 = new List<IndentMasterModel>();
            foreach (DataRow item in dt.Rows)
            {
                lst5.Add(new IndentMasterModel()
                {
                    UnitId = Convert.ToInt32(item["UnitId"]),
                    UnitName = item["UnitName"].ToString()
                });
            }
            return lst5;
        }

        [HttpGet]
        public JsonResult GetItemDetails(string itemname)
        {
            // Replace with your method to fetch item details
            DataTable dt = bal.GetItemDetails(itemname);
            var itemDetailsList = new List<IndentMasterModel>();

            IndentMasterModel mod = new IndentMasterModel();
            mod.ItemCode = dt.Rows[0]["ItemCode"].ToString();
            mod.Specification = dt.Rows[0]["Specification"].ToString();
            mod.DrawingNo = dt.Rows[0]["DrawingNo"].ToString();
            mod.UnitId = Convert.ToInt32(dt.Rows[0]["UnitId"]);
            //foreach (DataRow row in dt.Rows)
            //{
            //    itemDetailsList.Add(new IndentMasterModel
            //    {
            //       // ItemCode = row["ItemCode"].ToString(),
            //        Specification = row["Specification"].ToString(),
            //        DrawingNo = row["DrawingNo"].ToString(),
            //        UnitId = Convert.ToInt32(row["UnitId"])
            //    });
            //}

            return Json(mod, JsonRequestBehavior.AllowGet);
        }



    }
}