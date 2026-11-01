using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace StandardMetals.DAL
{

    public class dbProductionNote :ConncetionClass
    {
        public DateTime ProductionDate { get; set; }
        public string ItemCode { get; set; }
        public string UoM { get; set; }
        public decimal Qty { get; set; }
        public string Username { get; set; }
        public string Branch { get; set; }

        DataTable dt;
        public string[,] ArrayList { get; set; }
        public string Cmp_Code { get; set; }
        public int FinancialYearID { get; set; }


        public int SaveProductionNote(dbProductionNote _dbProdNote)
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
                    cmdUniversal = new SqlCommand("SaveProductionNote", cnUniversal, trans);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);
                    
                    cmdUniversal.Parameters["@ProductionDate"].Value = _dbProdNote.ProductionDate;
                    cmdUniversal.Parameters["@ItemCode"].Value = _dbProdNote.ItemCode;
                    cmdUniversal.Parameters["@UoM"].Value = _dbProdNote.UoM;
                    cmdUniversal.Parameters["@Qty"].Value = _dbProdNote.Qty;
                    cmdUniversal.Parameters["@Branch"].Value = _dbProdNote.Branch;
                    cmdUniversal.Parameters["@Username"].Value = _dbProdNote.Username;


                    cmdUniversal.ExecuteNonQuery();

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
