using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;
namespace StandardMetals.BAL
{
   public  class QuotationDetailsMngr
    {
       dbQuotationDetails objdbQuotationDetails = new dbQuotationDetails();
       public string GenerateQuotationNo()
       {
           
           DataTable dt = new DataTable();

           string Years = Convert.ToString(DateTime.Now.Year);
           dt = GetMaxQuotationNo();
           string Pono = "";
           int cnt = 0;
           if (dt.Rows.Count > 0 && dt.Rows[0].IsNull("QuotationNo") == false)
           {
               Pono = Convert.ToString(dt.Rows[0][0]);
               Pono = Pono.Substring(8, 5).ToString();
               Pono = (Convert.ToDecimal(Pono) + 1).ToString();
               Pono = Pono.PadLeft(5, '0');

               Pono = "QN/" + Years + "/" + Pono;
           }
           else
           {
               Pono = "QN/" + Years + "/" + "00001";
           }
           return Pono;
       }

       public DataTable GetMaxQuotationNo()
       {
           return objdbQuotationDetails.GetMaxQuotationNo();
       }
       public DataTable FillCustName()
       {
           return objdbQuotationDetails.FillCustName();
       }
       public DataTable FillQuotationNo()
       {
           return objdbQuotationDetails.FillQuotationNo();
       }
       public int SaveQuotationMaster(dbQuotationDetails objdbQuotationDetails)
       {
           return objdbQuotationDetails.SaveQuotationMaster(objdbQuotationDetails);
       }
    }
   
}
