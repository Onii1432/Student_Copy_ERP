using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace StandardMetals.DAL
{
   public  class dbQuotationDetails:ConncetionClass
    {
       DataTable dt;
       public string QutationNo { get; set; }
       public string QuotationDate { get; set; }
       public string ValidTillDate { get; set; }
       public string CustCode { get; set; }
       public string UserName { get; set; }
       public string Branch { get; set; }
       public string[,] ArrayList { get; set; }
       public DataTable GetMaxQuotationNo()
       {
           this.Initialize();
           int nRecAffected = 0;
           dt = new DataTable();
           using (cnUniversal)
           {
               cmdUniversal.CommandText = "GetMaxQuotationNo";

               this.daUniversal.SelectCommand = cmdUniversal;
               this.cnUniversal.Open();
               nRecAffected = this.daUniversal.Fill(dt);
               this.Close();
               return dt;
           }
       }

       public DataTable FillCustName()
       {
           this.Initialize();
           int nRecAffected = 0;
           dt = new DataTable();
           using (cnUniversal)
           {
               cmdUniversal.CommandText = "GetCustomerMaster";
               cmdUniversal.Parameters.Add("@custcode", SqlDbType.VarChar).Value = string.Empty;
               cmdUniversal.Parameters.Add("@Flag", SqlDbType.Int).Value = 1;
               this.daUniversal.SelectCommand = cmdUniversal;
               this.cnUniversal.Open();
               nRecAffected = this.daUniversal.Fill(dt);
               this.Close();
               return dt;
           }
       }
       public DataTable FillQuotationNo()
       {
           this.Initialize();
           int nRecAffected = 0;
           dt = new DataTable();
           using (cnUniversal)
           {
               cmdUniversal.CommandText = "GetQuotationNo";
               this.daUniversal.SelectCommand = cmdUniversal;
               this.cnUniversal.Open();
               nRecAffected = this.daUniversal.Fill(dt);
               this.Close();
               return dt;
           }
       }

       public int SaveQuotationMaster(dbQuotationDetails objdbQuotationDetails)
        {
            SqlTransaction trans;
            this.Initialize();
            int result = 0;
            using (cnUniversal)
            {
                cnUniversal.Open();
                trans = cnUniversal.BeginTransaction();
                try
                {
                    cmdUniversal = new SqlCommand("InsertQuotationMaster", cnUniversal, trans);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);

                    cmdUniversal.Parameters["@QutationNo"].Value = objdbQuotationDetails.QutationNo;
                    cmdUniversal.Parameters["@QuotationDate"].Value = Convert.ToDateTime(objdbQuotationDetails.QuotationDate);
                    cmdUniversal.Parameters["@ValidTillDate"].Value = Convert.ToDateTime(objdbQuotationDetails.ValidTillDate);
                    cmdUniversal.Parameters["@CustCode"].Value = objdbQuotationDetails.CustCode;
                    cmdUniversal.Parameters["@UserName"].Value = objdbQuotationDetails.UserName;
                    cmdUniversal.Parameters["@Branch"].Value = objdbQuotationDetails.Branch;
                    cmdUniversal.Parameters["@SysytemEntryDate"].Value = System.DateTime.Now;
                    cmdUniversal.ExecuteNonQuery();

                    for (int i = 0; i < objdbQuotationDetails.ArrayList.GetLength(0); i++)
                    {
                        cmdUniversal = new SqlCommand("InsertQuotationDetails", cnUniversal, trans);
                        cmdUniversal.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(cmdUniversal);

                        cmdUniversal.Parameters["@QuotationNo"].Value = Convert.ToString(objdbQuotationDetails.QutationNo);
                        cmdUniversal.Parameters["@ItemCode"].Value = objdbQuotationDetails.ArrayList[i, 0];
                        cmdUniversal.Parameters["@ItemName"].Value = objdbQuotationDetails.ArrayList[i, 1];
                        cmdUniversal.Parameters["@UOM"].Value = Convert.ToString(objdbQuotationDetails.ArrayList[i, 2]);
                        cmdUniversal.Parameters["@Qty"].Value = Convert.ToInt32(objdbQuotationDetails.ArrayList[i, 3]);
                        cmdUniversal.Parameters["@Rate"].Value = Convert.ToDecimal(objdbQuotationDetails.ArrayList[i, 4]);
                        cmdUniversal.Parameters["@Amount"].Value = Convert.ToDecimal(objdbQuotationDetails.ArrayList[i, 5]);
                        cmdUniversal.ExecuteNonQuery();
                    }
                    trans.Commit();
                    cnUniversal.Close();
                    return 1;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    cnUniversal.Close();
                    return 0;
                }
            }
        }

    }
}
