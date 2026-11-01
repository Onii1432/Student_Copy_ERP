// 20/08/2026
using StandardMetals.CommonLibrary;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace StandardMetals.MODEL
{
    public class CustomerMasterMVCApril2026Model
    {
        public int Id { get; set; }

        [Display(Name = "Customer Code")]
        public string CustCode { get; set; }

        [Required(ErrorMessage = "Please Enter Customer Name")]
        [CustomCustomerValidationClass(ErrorMessage = "Duplicate Customer Name is not allowed")]
        [Display(Name = "Customer Name")]
        public string CustName { get; set; }

        [Required(ErrorMessage = "Please Enter Contact Person")]
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }

        [Required(ErrorMessage = "Please Select Branch")]
        [Display(Name = "Branch")]
        public int? BranchId { get; set; }

        public string Branch { get; set; }

        [Required(ErrorMessage = "Please Enter Address 1")]
        [Display(Name = "Address 1")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Please Select Country")]
        [Display(Name = "Country")]
        public int? CountryId { get; set; }

        public string Country { get; set; }

        [Required(ErrorMessage = "Please Select State")]
        [Display(Name = "State")]
        public int? StateId { get; set; }

        public string State { get; set; }

        [Required(ErrorMessage = "Please Select City")]
        [Display(Name = "City")]
        public int? CityId { get; set; }

        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter Pin Code")]
        [Display(Name = "Pin Code")]
        public string PinCode { get; set; }

        [Display(Name = "Email ID")]
        [EmailAddress(ErrorMessage = "Please Enter a Valid Email Address")]
        public string EmailID { get; set; }

        [Display(Name = "Telephone")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile Number")]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Display(Name = "Fax")]
        public string Fax { get; set; }

        [Display(Name = "Website")]
        public string Website { get; set; }

        [Display(Name = "GSTIN")]
        public string GSTIN { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        public string Username { get; set; }
        public string LoginBranch { get; set; }
        public DateTime SystemEntryDate { get; set; }
    }

    public class CustomCustomerValidationClass : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            LogInfo.LogDetailToFile("CustomerMasterMVCApril2026Model CustomCustomerValidationClass - Start");

            if (value != null)
            {
                string ValueName = value.ToString();

                CustomerMasterMVCApril2026Model model = validationContext.ObjectInstance as CustomerMasterMVCApril2026Model;


                int customerId = 0;

                if (model != null)
                {
                    customerId = model.Id;
                    LogInfo.LogDetailToFile("Current Customer Id : " + customerId);
                }

                string str = @"Data Source=LAPTOP-C9OTCO0G\SQLEXPRESS;Initial Catalog=aaliml4n_MVC_ERP;Integrated Security=True";

                SqlConnection con = new SqlConnection(str);

                SqlCommand cmd = new SqlCommand("CheckDuplicateCustomerName", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustName", ValueName);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);

                con.Open();

                LogInfo.LogDetailToFile("Executing CheckDuplicateCustomerName SP for Customer Name : " + ValueName);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();

                LogInfo.LogDetailToFile("Duplicate Customer Count : " + count);

                if (count == 0)
                {
                    LogInfo.LogDetailToFile("CustomerMasterMVCApril2026Model CustomCustomerValidationClass - Start-End");

                    return ValidationResult.Success;
                }
                else
                {
                    LogInfo.LogDetailToFile("Duplicate Customer Found : " + ValueName);

                    LogInfo.LogDetailToFile("CustomerMasterMVCApril2026Model CustomCustomerValidationClass - Start-End");

                    return new ValidationResult("Duplicate Customer Name is not allowed");
                }
            }

            LogInfo.LogDetailToFile("Customer Name Value is Null");

            LogInfo.LogDetailToFile("CustomerMasterMVCApril2026Model CustomCustomerValidationClass - Start-End");

            return new ValidationResult("Customer Name is Required");
        }
    }
}