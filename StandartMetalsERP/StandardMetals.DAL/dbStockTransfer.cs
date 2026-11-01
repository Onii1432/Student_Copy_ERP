using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace StandardMetals.DAL
{
    public class dbStockTransfer : ConncetionClass
    {
        public DateTime TransferDate { get; set; }
        public string FromBranch { get; set; }
        public string ToBranch { get; set; }
        public string ItemCode { get; set; }
        public string UoM { get; set; }
        public decimal Qty { get; set; }
        public string Username { get; set; }
        public string LoginBranch { get; set; }

        DataTable dt;
        public string[,] ArrayList { get; set; }
        public string Cmp_Code { get; set; }
        public int FinancialYearID { get; set; }


        public int SaveStockTransfer(dbStockTransfer _dbStockTrans)
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
                    cmdUniversal = new SqlCommand("SaveStockTransfer", cnUniversal, trans);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);

                    cmdUniversal.Parameters["@TransactionDate"].Value = _dbStockTrans.TransferDate;
                    cmdUniversal.Parameters["@FromBranch"].Value = _dbStockTrans.FromBranch;
                    cmdUniversal.Parameters["@ToBranch"].Value = _dbStockTrans.ToBranch;
                    cmdUniversal.Parameters["@ItemCode"].Value = _dbStockTrans.ItemCode;
                    cmdUniversal.Parameters["@UoM"].Value = _dbStockTrans.UoM;
                    cmdUniversal.Parameters["@Qty"].Value = _dbStockTrans.Qty;
                    cmdUniversal.Parameters["@LoginBranch"].Value = _dbStockTrans.LoginBranch;
                    cmdUniversal.Parameters["@Username"].Value = _dbStockTrans.Username;


                    cmdUniversal.ExecuteNonQuery();

                    //(@ItemCode ,@Branch,@InQty,@OutQty,@TransactionDate,@Username)
                    //cmdUniversal = new SqlCommand("SaveStockMaster", cnUniversal, trans);
                    //cmdUniversal.CommandType = CommandType.StoredProcedure;
                    //SqlCommandBuilder.DeriveParameters(cmdUniversal);

                    //cmdUniversal.Parameters["@TransactionDate"].Value = _dbStockTrans.TransferDate;
                    //cmdUniversal.Parameters["@ItemCode"].Value = _dbStockTrans.FromBranch;
                    //cmdUniversal.Parameters["@ToBranch"].Value = _dbStockTrans.ToBranch;
                    //cmdUniversal.Parameters["@ItemCode"].Value = _dbStockTrans.ItemCode;
                    //cmdUniversal.Parameters["@UoM"].Value = _dbStockTrans.UoM;
                    //cmdUniversal.Parameters["@Qty"].Value = _dbStockTrans.Qty;
                    //cmdUniversal.Parameters["@LoginBranch"].Value = _dbStockTrans.LoginBranch;
                    //cmdUniversal.Parameters["@Username"].Value = _dbStockTrans.Username;


                    //cmdUniversal.ExecuteNonQuery();



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
