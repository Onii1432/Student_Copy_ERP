using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StandardMetals.MODEL;
using System.Data.SqlClient;
using System.Data;


namespace StandardMetals.DAL
{
    public class IndentApprovalDal : ConncetionClass
    {
        public DataTable GetNonApprovedIndent(IndentApprovalModal IndentAppModal)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "Purchase_GetNonApprovedIndentDetails";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
               // cmdUniversal.Parameters.Add("@FromDate", SqlDbType.Date).Value = Convert.ToDateTime(IndentAppModal.FromDate);
               // cmdUniversal.Parameters.Add("@ToDate", SqlDbType.Date).Value =  Convert.ToDateTime(IndentAppModal.ToDate);
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }


        public int GetLoginDetails(string UserName)
        {
            int UserId = 0;
            this.Initialize();
            using (cnUniversal)
            {
                cnUniversal.Open();
                cmdUniversal.CommandText = "Purchase_GetUserDetails";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Add("@UserName", SqlDbType.Char, 500).Value = UserName;
                cmdUniversal.Parameters.Add("@UserID", SqlDbType.Int);
                cmdUniversal.Parameters["@UserID"].Direction = ParameterDirection.Output;
                cmdUniversal.ExecuteNonQuery();
                UserId = Convert.ToInt32(cmdUniversal.Parameters["@UserID"].Value);
                cnUniversal.Close();
                return UserId;
            }
        }

        public int UpdateIndentDetailMaster(IndentApprovalModal IndentAppModal)
        {
            DataTable dt = new DataTable();
            int result = 0;
            this.Initialize();
            using (cnUniversal)
            {
                cnUniversal.Open();
                cmdUniversal.CommandText = "Purchase_UpdateApprovedIndentDetails";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cmdUniversal);
               
                foreach (var IndentDetails in IndentAppModal.AllData)
                {
                    cmdUniversal.Parameters["@IsApproved"].Value = IndentDetails.IsApproved;
                    cmdUniversal.Parameters["@IndentNoAutoGen"].Value = IndentDetails.IndentNoAutoGen;
                    
                    cmdUniversal.Parameters["@ApprovedQuantity"].Value = Convert.ToDecimal(IndentDetails.ApprovedQuantity);
                    cmdUniversal.Parameters["@RejectedQuantity"].Value = Convert.ToDecimal(IndentDetails.RejectedQuantity);
                    cmdUniversal.Parameters["@Remark"].Value = IndentDetails.Remark;
                    cmdUniversal.Parameters["@IndentApprovedByCode"].Value = IndentDetails.IndentApprovedByCode;
                    cmdUniversal.Parameters["@CurrentDate"].Value = IndentDetails.CurrentDate;
                    cmdUniversal.Parameters["@CurrentTime"].Value = IndentDetails.CurrentTime;
                     cmdUniversal.ExecuteNonQuery();
                    this.Close();

                }
                return result=1;
            }

        }
    }
}

