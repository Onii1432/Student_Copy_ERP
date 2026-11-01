using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Web.Mvc;
using Newtonsoft.Json;
using StandardMetals.MODEL;
using StandardMetals.BAL;

namespace StandardMetals.WebApp.Controllers
{
    public class PurchaseIndentApril2026Controller : Controller
    {
        PurchaseIndentApril2026BAL bal = new PurchaseIndentApril2026BAL();

        // GET: PurchaseIndentApril2026
        public ActionResult IndentMasterListApril2026()
        {
            PurchaseIndentApril2026Model model = new PurchaseIndentApril2026Model();

            ViewBag.lst = GetIndentNoAutoGenApril2026();
            ViewBag.lst1 = GetIndentTypeApril2026();
            ViewBag.lst2 = GetItemnameTypeApril2026();
            ViewBag.lst3 = GetItemTypeApril2026();
            ViewBag.lst4 = GetDepartmentApril2026();
            ViewBag.lst5 = GetUnitApril2026();

            model.PreparedByCode = Session["EmpCode"] == null ? "" : Session["EmpCode"].ToString();
            model.PreparedByName = Session["Username"] == null ? "" : Session["Username"].ToString();

            return View(model);
        }

        // Get existing indent numbers
        public List<PurchaseIndentApril2026Model> GetIndentNoAutoGenApril2026()
        {
            DataTable dt = bal.GetIndentNoAutoGenApril2026();
            List<PurchaseIndentApril2026Model> list = new List<PurchaseIndentApril2026Model>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new PurchaseIndentApril2026Model
                {
                    IndentId = Convert.ToInt32(row["IndentId"]),
                    IndentNoAutoGen = row["IndentNoAutoGen"].ToString(),
                    IndentTypeId = row["IndentTypeId"] == DBNull.Value ? 0 : Convert.ToInt32(row["IndentTypeId"]),
                    IndentType = row["IndentType"] == DBNull.Value ? "" : row["IndentType"].ToString(),
                    IndentDate = row["IndentDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["IndentDate"]),
                    IndentTime = row["IndentTime"] == DBNull.Value ? "" : row["IndentTime"].ToString()
                });
            }

            return list;
        }

        // Get indent types
        public List<PurchaseIndentApril2026Model> GetIndentTypeApril2026()
        {
            DataTable dt = bal.GetIndentTypeApril2026();
            List<PurchaseIndentApril2026Model> list = new List<PurchaseIndentApril2026Model>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new PurchaseIndentApril2026Model
                {
                    IndentTypeId = Convert.ToInt32(row["IndentTypeId"]),
                    IndentType = row["IndentType"].ToString()
                });
            }

            return list;
        }

        // Get item names
        public List<PurchaseIndentApril2026Model> GetItemnameTypeApril2026()
        {
            DataTable dt = bal.GetItemnameTypeApril2026();
            List<PurchaseIndentApril2026Model> list = new List<PurchaseIndentApril2026Model>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new PurchaseIndentApril2026Model
                {
                    ItemName = row["ItemName"].ToString()
                });
            }

            return list;
        }

        // Get item codes and names
        public List<PurchaseIndentApril2026Model> GetItemTypeApril2026()
        {
            DataTable dt = bal.GetItemTypeApril2026();
            List<PurchaseIndentApril2026Model> list = new List<PurchaseIndentApril2026Model>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new PurchaseIndentApril2026Model
                {
                    ItemCode = row["ItemCode"].ToString(),
                    ItemName = row["ItemName"].ToString()
                });
            }

            return list;
        }

        // Get departments
        public List<PurchaseIndentApril2026Model> GetDepartmentApril2026()
        {
            DataTable dt = bal.GetDepartmentApril2026();
            List<PurchaseIndentApril2026Model> list = new List<PurchaseIndentApril2026Model>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new PurchaseIndentApril2026Model
                {
                    DepartmentId = Convert.ToInt32(row["did"]),
                    DepartmentName = row["dname"].ToString()
                });
            }

            return list;
        }

        // Get units
        public List<PurchaseIndentApril2026Model> GetUnitApril2026()
        {
            DataTable dt = bal.GetUnitApril2026();
            List<PurchaseIndentApril2026Model> list = new List<PurchaseIndentApril2026Model>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new PurchaseIndentApril2026Model
                {
                    UnitId = Convert.ToInt32(row["UnitId"]),
                    UnitName = row["UnitName"].ToString()
                });
            }

            return list;
        }

        // Get item details by item name
        [HttpGet]
        public JsonResult GetItemDetailsApril2026(string itemName)
        {
            DataTable dt = bal.GetItemDetailsApril2026(itemName);

            if (dt == null || dt.Rows.Count == 0)
            {
                return Json(new { success = false, message = "Item not found." }, JsonRequestBehavior.AllowGet);
            }

            DataRow row = dt.Rows[0];

            var item = new
            {
                success = true,
                ItemCode = row["ItemCode"].ToString(),
                Specification = row["Specification"] == DBNull.Value ? "" : row["Specification"].ToString(),
                DrawingNo = row["DrawingNo"] == DBNull.Value ? "" : row["DrawingNo"].ToString(),
                UnitId = row["UnitId"] == DBNull.Value ? 0 : Convert.ToInt32(row["UnitId"])
            };

            return Json(item, JsonRequestBehavior.AllowGet);
        }

        // Get saved indent header and item details
        [HttpGet]
        public JsonResult GetIndentDetailsApril2026(int indentId)
        {
            if (indentId <= 0)
            {
                return Json(new { success = false, message = "Invalid Indent ID." }, JsonRequestBehavior.AllowGet);
            }

            DataSet ds = bal.GetIndentDetailsApril2026(indentId);

            if (ds == null || ds.Tables.Count < 2 || ds.Tables[0].Rows.Count == 0)
            {
                return Json(new { success = false, message = "Indent details not found." }, JsonRequestBehavior.AllowGet);
            }

            DataRow header = ds.Tables[0].Rows[0];
            DataTable detailTable = ds.Tables[1];
            List<object> items = new List<object>();

            foreach (DataRow row in detailTable.Rows)
            {
                items.Add(new
                {
                    IndentDetailId = row["IndentDetailId"] == DBNull.Value ? 0 : Convert.ToInt32(row["IndentDetailId"]),
                    ItemCode = row["ItemCode"] == DBNull.Value ? "" : row["ItemCode"].ToString(),
                    ItemName = row["ItemName"] == DBNull.Value ? "" : row["ItemName"].ToString(),
                    Specification = row["Specification"] == DBNull.Value ? "" : row["Specification"].ToString(),
                    DrawingNo = row["DrawingNo"] == DBNull.Value ? "" : row["DrawingNo"].ToString(),
                    DepartmentId = row["DepartmentId"] == DBNull.Value ? 0 : Convert.ToInt32(row["DepartmentId"]),
                    Purpose = row["Purpose"] == DBNull.Value ? "" : row["Purpose"].ToString(),
                    CurrentStock = row["CurrentStock"] == DBNull.Value ? 0 : Convert.ToDecimal(row["CurrentStock"]),
                    RequiredDate = row["RequiredDate"] == DBNull.Value ? "" : Convert.ToDateTime(row["RequiredDate"]).ToString("yyyy-MM-dd"),
                    ToOrderQuantity = row["ToOrderQuantity"] == DBNull.Value ? 0 : Convert.ToDecimal(row["ToOrderQuantity"]),
                    ToOrderUnit = row["ToOrderUnit"] == DBNull.Value ? "" : row["ToOrderUnit"].ToString(),
                    IsApproved = row["IsApproved"] == DBNull.Value ? false : Convert.ToBoolean(row["IsApproved"]),
                    ApprovedQuantity = row["ApprovedQuantity"] == DBNull.Value ? 0 : Convert.ToDecimal(row["ApprovedQuantity"]),
                    RejectedQty = row["RejectedQty"] == DBNull.Value ? 0 : Convert.ToDecimal(row["RejectedQty"])
                });
            }

            return Json(new
            {
                success = true,
                header = new
                {
                    IndentId = Convert.ToInt32(header["IndentId"]),
                    IndentNoAutoGen = header["IndentNoAutoGen"].ToString(),
                    IndentTypeId = header["IndentTypeId"] == DBNull.Value ? 0 : Convert.ToInt32(header["IndentTypeId"]),
                    IndentDate = header["IndentDate"] == DBNull.Value ? "" : Convert.ToDateTime(header["IndentDate"]).ToString("yyyy-MM-dd"),
                    IndentTime = header["IndentTime"] == DBNull.Value ? "" : header["IndentTime"].ToString(),
                    Remark = header["Remark"] == DBNull.Value ? "" : header["Remark"].ToString(),
                    PreparedByCode = header["CreatedBy"] == DBNull.Value ? "" : header["CreatedBy"].ToString(),
                    PreparedByName = header["UserName"] == DBNull.Value ? "" : header["UserName"].ToString()
                },
                items = items
            }, JsonRequestBehavior.AllowGet);
        }

        // Save new indent with multiple item details
        [HttpPost]
        public JsonResult SaveIndentApril2026(int indentTypeId, string indentDate, string indentTime, string remark, string itemsJson)
        {
            DateTime parsedDate;

            if (indentTypeId <= 0)
            {
                return Json(new { success = false, message = "Please select Indent Type." });
            }

            if (!DateTime.TryParseExact(indentDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                return Json(new { success = false, message = "Please select a valid Indent Date." });
            }

            if (string.IsNullOrWhiteSpace(itemsJson))
            {
                return Json(new { success = false, message = "Please add at least one item." });
            }

            PurchaseIndentApril2026Model model = new PurchaseIndentApril2026Model();
            model.IndentTypeId = indentTypeId;
            model.IndentDate = parsedDate;
            model.IndentTime = indentTime;
            model.Remark = remark;
            model.PreparedByCode = Session["EmpCode"] == null ? "" : Session["EmpCode"].ToString();
            model.PreparedByName = Session["Username"] == null ? "" : Session["Username"].ToString();

            try
            {
                model.ItemDetails = JsonConvert.DeserializeObject<List<PurchaseIndentApril2026Model>>(itemsJson);
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Invalid item details. Please check the items and try again." });
            }

            if (model.ItemDetails == null || model.ItemDetails.Count == 0)
            {
                return Json(new { success = false, message = "Please add at least one item." });
            }

            DataTable dt = bal.SaveIndentApril2026(model);

            if (dt != null && dt.Rows.Count > 0 && dt.Columns.Contains("SaveStatus"))
            {
                string saveStatus = dt.Rows[0]["SaveStatus"].ToString();

                if (saveStatus == "SUCCESS")
                {
                    return Json(new
                    {
                        success = true,
                        indentId = dt.Rows[0]["IndentId"],
                        indentNo = dt.Rows[0]["IndentNoAutoGen"],
                        message = "Indent saved successfully."
                    });
                }

                string errorMessage = dt.Columns.Contains("ErrorMessage") ? dt.Rows[0]["ErrorMessage"].ToString() : "Unable to save indent.";
                return Json(new { success = false, message = errorMessage });
            }

            return Json(new { success = false, message = "The save procedure did not return a valid result." });
        }


        // Update existing indent with multiple item details
        [HttpPost]
        public JsonResult UpdateIndentApril2026(int indentId, int indentTypeId, string indentDate, string indentTime, string remark, string itemsJson)
        {
            DateTime parsedDate;

            if (indentId <= 0)
            {
                return Json(new { success = false, message = "Invalid Indent ID." });
            }

            if (indentTypeId <= 0)
            {
                return Json(new { success = false, message = "Please select Indent Type." });
            }

            if (!DateTime.TryParseExact(indentDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                return Json(new { success = false, message = "Please select a valid Indent Date." });
            }

            if (string.IsNullOrWhiteSpace(itemsJson))
            {
                return Json(new { success = false, message = "Please add at least one item." });
            }

            PurchaseIndentApril2026Model model = new PurchaseIndentApril2026Model();
            model.IndentId = indentId;
            model.IndentTypeId = indentTypeId;
            model.IndentDate = parsedDate;
            model.IndentTime = indentTime;
            model.Remark = remark;

            try
            {
                model.ItemDetails = JsonConvert.DeserializeObject<List<PurchaseIndentApril2026Model>>(itemsJson);
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Invalid item details. Please check the items and try again." });
            }

            if (model.ItemDetails == null || model.ItemDetails.Count == 0)
            {
                return Json(new { success = false, message = "Please add at least one item." });
            }

            DataTable dt = bal.UpdateIndentApril2026(model);

            if (dt != null && dt.Rows.Count > 0 && dt.Columns.Contains("SaveStatus"))
            {
                string saveStatus = dt.Rows[0]["SaveStatus"].ToString();

                if (saveStatus == "SUCCESS")
                {
                    return Json(new
                    {
                        success = true,
                        indentId = indentId,
                        indentNo = dt.Rows[0]["IndentNoAutoGen"].ToString(),
                        message = "Indent updated successfully."
                    });
                }

                string errorMessage = dt.Columns.Contains("ErrorMessage") ? dt.Rows[0]["ErrorMessage"].ToString() : "Unable to update indent.";
                return Json(new { success = false, message = errorMessage });
            }

            return Json(new { success = false, message = "The update procedure did not return a valid result." });
        }

    }
}