using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StandardMetals.WebApp.CustomValidation
{
    public class CustomValidationClass : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string ValueName = value.ToString();
                string str = @"Data Source =ONKAR\SQLEXPRESS16; Initial Catalog = aaliml4n_MVC_ERPNEW1; Integrated Security = False; uid = erpmvcuser; password = Mvcerp@123";
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand("SpCustomVal", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ValName", ValueName);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds);
                dt = ds.Tables[0];
                if (dt.Rows.Count == 0)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Duplicate Name is not Allowed");

                }
            }
            return new ValidationResult("ItemName is Required");
        }
    }
}