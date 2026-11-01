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
   
    public class ItemMasterMVCModal
    {
        public int ID { get; set; }
        [Display(Name = "Item Code")]
        public string ItemCode { get; set; }
        [Required(ErrorMessage = "Please Enter Item Name")]
        [Display(Name = "Name")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "Please Enter Material")]
        public string Material { get; set; }
        [Display(Name = "HSN-Code")]
        public string HSNCODE { get; set; }
        [Display(Name = "GST Rate")]
        public double GSTRate { get; set; }
        [Display(Name = "Purchase Cost")]
        public double PurchaseCost { get; set; }
        [Display(Name = "Selling Price")]
        public double SellingPrice { get; set; }
        [Required(ErrorMessage = "Please Select Manufacturer")]
        public int ManufacturerId { get; set; }
        [Display(Name = "Manufacturer")]
        public string ManufacturerName { get; set; }
        [Required(ErrorMessage = "Please Select Colour")]
        public int ColourId { get; set; }
        [Display(Name = "Colour")]
        public string ColourName { get; set; }
        public int UnitId { get; set; }
        [Display(Name = "Unit")]
        public string UnitName { get; set; }
        [Required(ErrorMessage = "Please Select Category")]
        public int CategoryId { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Please Select Sub-Category")]
        public int SubCategoryId { get; set; }
        [Display(Name = "Sub-Category")]
        public string SubCategoryName { get; set; }
    }



    //public class CustomValidationClass : ValidationAttribute
    //{
    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        if (value != null)
    //        {
    //            string ValueName = value.ToString();
    //            string str = @"Data Source = 208.91.198.174; Initial Catalog = aaliml4n_MVC_ERP; Integrated Security = False; uid = erpmvcuser; password = Mvcerp@123";
    //            SqlConnection con = new SqlConnection(str);
    //            SqlCommand cmd = new SqlCommand("SpCustomVal", con);
    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cmd.Parameters.AddWithValue("@ValName", ValueName);
    //            SqlDataAdapter da = new SqlDataAdapter(cmd);
    //            DataSet ds = new DataSet();
    //            DataTable dt = new DataTable();
    //            da.Fill(ds);
    //            dt = ds.Tables[0];
    //            if (dt.Rows.Count == 0)
    //            {
    //                return ValidationResult.Success;
    //            }
    //            else
    //            {
    //                return new ValidationResult("Duplicate Name is not Allowed");

    //            }
    //        }
    //        return new ValidationResult("ItemName is Required");
    //    }
    //}

}
