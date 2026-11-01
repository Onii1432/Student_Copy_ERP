// 27/08/2026

using StandardMetals.CommonLibrary;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace StandardMetals.MODEL
{
    public class SupplierMasterMVCApril2026Model
    {
        public int Id { get; set; }

        public string SuppCode { get; set; }

        [Required(ErrorMessage = "Please Enter Supplier Name")]
        [CustomSupplierValidationClass(ErrorMessage = "Duplicate Supplier Name is not allowed")]
        public string SuppName { get; set; }

        [Required(ErrorMessage = "Please Enter Contact Person")]
        public string ContactPerson { get; set; }

        public string Branch { get; set; }

        [Required(ErrorMessage = "Please Select Branch")]
        public int? BranchId { get; set; }

        [Required(ErrorMessage = "Please Enter Address 1")]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public bool IsRawMaterial { get; set; }

        [Required(ErrorMessage = "Please Enter Pin Code")]
        public string PinCode { get; set; }

        [Required(ErrorMessage = "Please Select Country")]
        public int? CountryId { get; set; }

        [Required(ErrorMessage = "Please Select State")]
        public int? StateId { get; set; }

        [Required(ErrorMessage = "Please Select City")]
        public int? CityId { get; set; }

        public string EmailID { get; set; }

        public string Telephone { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile Number")]
        public string Mobile { get; set; }

        public string Fax { get; set; }

        public string Website { get; set; }

        public string GSTIN { get; set; }

        public string Remarks { get; set; }
    }

    public class CustomSupplierValidationClass : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            LogInfo.LogDetailToFile("SupplierMasterMVCApril2026Model CustomSupplierValidationClass - Start");

            if (value != null)
            {
                string ValueName = value.ToString();

                SupplierMasterMVCApril2026Model model =
                    validationContext.ObjectInstance as SupplierMasterMVCApril2026Model;

                int supplierId = 0;

                if (model != null)
                {
                    supplierId = model.Id;

                    LogInfo.LogDetailToFile("Current Supplier Id : " + supplierId);
                }

                string str = @"Data Source=LAPTOP-C9OTCO0G\SQLEXPRESS;Initial Catalog=aaliml4n_MVC_ERP;Integrated Security=True";

                SqlConnection con = new SqlConnection(str);

                SqlCommand cmd = new SqlCommand("CheckDuplicateSupplierName", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SuppName", ValueName);
                cmd.Parameters.AddWithValue("@SupplierId", supplierId);

                con.Open();

                LogInfo.LogDetailToFile("Executing CheckDuplicateSupplierName SP for Supplier Name : " + ValueName);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();

                LogInfo.LogDetailToFile("Duplicate Supplier Count : " + count);

                if (count == 0)
                {
                    LogInfo.LogDetailToFile("SupplierMasterMVCApril2026Model CustomSupplierValidationClass - Start-End");

                    return ValidationResult.Success;
                }
                else
                {
                    LogInfo.LogDetailToFile("Duplicate Supplier Found : " + ValueName);

                    LogInfo.LogDetailToFile("SupplierMasterMVCApril2026Model CustomSupplierValidationClass - Start-End");

                    return new ValidationResult("Duplicate Supplier Name is not allowed");
                }
            }

            LogInfo.LogDetailToFile("Supplier Name Value is Null");

            LogInfo.LogDetailToFile("SupplierMasterMVCApril2026Model CustomSupplierValidationClass - Start-End");

            return new ValidationResult("Supplier Name is Required");
        }
    }
}