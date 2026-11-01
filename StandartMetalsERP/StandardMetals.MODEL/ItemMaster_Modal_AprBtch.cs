using StandardMetals.CommonLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardMetals.MODEL
{
    public class ItemMaster_Modal_AprBtch
    {
        public int Id { get; set; }

        [Display(Name = "Item Code")]
        public string ItemCode { get; set; }

        [Required(ErrorMessage = "Please Enter Item Name")]
        [CustomValidationClass(ErrorMessage = "Duplicate Item Name is not allowed")]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Please Enter Material")]
        public string Material { get; set; }

        [Required(ErrorMessage = "Please Enter HSN-Code")]
        [Display(Name = "HSN-Code")]
        public string HSNCODE { get; set; }

        [Display(Name = "GST Rate")]
        public double GSTRate { get; set; }

        [Display(Name = "Purchase Cost")]
        public double? PurchaseCost { get; set; }

        [Display(Name = "Selling Price")]
        public double? SellingPrice { get; set; }

        // Manufacturer

        [Required(ErrorMessage = "Please Select Manufacturer")]
        public int? ManufactureId { get; set; }

        [Display(Name = "Manufacture")]
        public string ManufactureName { get; set; }

        // Colour

        [Required(ErrorMessage = "Please Select Colour")]
        public int? ColourId { get; set; }

        [Display(Name = "Colour")]
        public string ColourName { get; set; }

        // Unit

        [Required(ErrorMessage = "Please Select Unit")]
        public int? UnitId { get; set; }

        [Display(Name = "Unit")]
        public string UnitName { get; set; }

        // Category

        [Required(ErrorMessage = "Please Select Category")]
        public int? CategoryId { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        // Sub Category

        [Required(ErrorMessage = "Please Select Sub-Category")]
        public int? SubCategoryId { get; set; }

        [Display(Name = "Sub Category")]
        public string SubCategoryName { get; set; }

        // Supplier Information

        public string SupplierCode { get; set; }

        public string SupplierName { get; set; }

        public int SupplierID { get; set; }

        // Supplier Mapping Details For Display

        public List<SupplierMasterMVCApril2026Model> SupplierList { get; set; } = new List<SupplierMasterMVCApril2026Model>();

        // Customer Mapping Details For Display

        public List<CustomerMasterMVCApril2026Model> CustomerList { get; set; } = new List<CustomerMasterMVCApril2026Model>();

        // Supplier Mapping IDs For Save And Update

        public List<int> SupplierIds { get; set; } = new List<int>();

        // Customer Mapping IDs For Save And Update

        public List<int> CustomerIds { get; set; } = new List<int>();
    }


    // Custom Validation Class

    public class CustomValidationClass : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            LogInfo.LogDetailToFile("ItemMaster_Modal_AprBtch CustomValidationClass - Start");

            if (value != null)
            {
                string ValueName = value.ToString();

                ItemMaster_Modal_AprBtch model = validationContext.ObjectInstance as ItemMaster_Modal_AprBtch;

                int itemId = 0;

                if (model != null)
                {
                    itemId = model.Id;
                    LogInfo.LogDetailToFile("Current Item Id : " + itemId);
                }

                string str = @"Data Source=LAPTOP-C9OTCO0G\SQLEXPRESS;Initial Catalog=aaliml4n_MVC_ERP;Integrated Security=True";

                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand("CheckDuplicateItemName", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ItemName", ValueName);
                cmd.Parameters.AddWithValue("@ItemId", itemId);

                con.Open();

                LogInfo.LogDetailToFile("Executing CheckDuplicateItemName SP for ItemName : " + ValueName);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();

                LogInfo.LogDetailToFile("Duplicate Item Count : " + count);

                if (count == 0)
                {
                    LogInfo.LogDetailToFile("ItemMaster_Modal_AprBtch CustomValidationClass - Start-End");
                    return ValidationResult.Success;
                }
                else
                {
                    LogInfo.LogDetailToFile("Duplicate Record Found : " + ValueName);
                    LogInfo.LogDetailToFile("ItemMaster_Modal_AprBtch CustomValidationClass - Start-End");
                    return new ValidationResult("Duplicate Item Name is not allowed");
                }
            }

            LogInfo.LogDetailToFile("ItemName Value is Null");
            LogInfo.LogDetailToFile("ItemMaster_Modal_AprBtch CustomValidationClass - Start-End");

            return new ValidationResult("ItemName is Required");
        }
    }
}