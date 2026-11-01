using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace StandardMetals.DAL
{
    public class dbEstimate : ConncetionClass
    {
        DataTable dt;
        public string[,] ArrayList { get; set; }
        public string Cmp_Code { get; set; }
        public int FinancialYearID { get; set; }
        public string EstimateN { get; set; }
        public DateTime InwardDate { get; set; }
        public string InvoiceNO { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string CustomerCode { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNo { get; set; }
        public string PONO { get; set; }
        public DateTime PODate { get; set; }
        public decimal vat { get; set; }
        public decimal Total { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal VatAmount { get; set; }
        public decimal ExiceAmount { get; set; }
        public string Remark { get; set; }
        public string UserName { get; set; }
        public string Passward { get; set; }
        public string IPAddress { get; set; }
        public string ShiptoCustcode { get; set; }
        public string TransportMode { get; set; }
        public DateTime dateofSupply { get; set; }
        public string placeofsupply { get; set; }
        public string VehicleNo { get; set; }
        public double LoadingCharges { get; set; }
        public double TransportCharges { get; set; }
        public string FrightUnit { get; set; }
        public double FrightRate { get; set; }
        public double FrightAmount { get; set; }
        public string PackingUnit { get; set; }
        public double PackingRate { get; set; }
        public double PackingAmount { get; set; }
        public double MAXCGSTRATE { get; set; }
        public double MAXSGSTRATE { get; set; }
        public double MAXIGSTRATE { get; set; }
        public double MAXCGSTAMT { get; set; }
        public double MAXSGSTAMT { get; set; }
        public double MAXIGSTAMT { get; set; }
        public string GSTReverseChargeYesORNO { get; set; }
        public string GSTReverseCharge { get; set; }
        public string bankaccount { get; set; }
        public string bankIFSC { get; set; }
        public string POTYPE { get; set; }
        public string RawMaterial { get; set; }
        public string Branch { get; set; }
        public DataTable FillEstimate_No()
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "FillEstimateno";

                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable GetMaxEstimateN()
        {
            this.Initialize();
            int nRecAffected = 0;
            dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetMaxEstimateN";

                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }
        public DataTable RetriveEstimate(string EstNo)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "RetriveEstimateDetails";
                cmdUniversal.Parameters.Add("@EstNo", SqlDbType.VarChar).Value = EstNo;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }
        public int SaveEstmate(dbEstimate _dbEstimate)
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
                    cmdUniversal = new SqlCommand("InsertEstimate", cnUniversal, trans);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);
                    cmdUniversal.Parameters["@EstNo"].Value = _dbEstimate.EstimateN;
                    cmdUniversal.Parameters["@EstNoDate"].Value = _dbEstimate.InwardDate;
                    cmdUniversal.Parameters["@CustomerName"].Value = _dbEstimate.CustomerCode;
                    cmdUniversal.Parameters["@Address"].Value = _dbEstimate.Address;
                    cmdUniversal.Parameters["@ContactPerson"].Value = _dbEstimate.ContactPerson;
                    cmdUniversal.Parameters["@State"].Value = _dbEstimate.State;
                    cmdUniversal.Parameters["@ContactNo"].Value = _dbEstimate.ContactNo;
                    cmdUniversal.Parameters["@UserName"].Value = _dbEstimate.UserName;
                    cmdUniversal.Parameters["@Branch"].Value = _dbEstimate.Branch;                
                    cmdUniversal.Parameters["@SystemEntryDate"].Value = System.DateTime.Now;
                    cmdUniversal.ExecuteNonQuery();
                    for (int i = 0; i < _dbEstimate.ArrayList.GetLength(0); i++)
                    {
                        cmdUniversal = new SqlCommand("InsertEstimateDetails", cnUniversal, trans);
                        cmdUniversal.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(cmdUniversal);
                        cmdUniversal.Parameters["@EstNo"].Value = _dbEstimate.EstimateN;
                        cmdUniversal.Parameters["@ItemCode"].Value = _dbEstimate.ArrayList[i, 0];
                        //cmdUniversal.Parameters["@ItemName"].Value = _dbEstimate.ArrayList[i, 1];
                        cmdUniversal.Parameters["@UOM"].Value = Convert.ToString(_dbEstimate.ArrayList[i, 2]);
                        cmdUniversal.Parameters["@Quantity"].Value = Convert.ToDecimal(_dbEstimate.ArrayList[i, 3]);
                        cmdUniversal.Parameters["@Rate"].Value = Convert.ToDecimal(_dbEstimate.ArrayList[i, 4]);
                        cmdUniversal.Parameters["@Amount"].Value = Convert.ToDecimal(_dbEstimate.ArrayList[i, 5]);
                        //cmdUniversal.Parameters["@Discount"].Value = Convert.ToDecimal(_dbEstimate.ArrayList[i, 6]);
                        //cmdUniversal.Parameters["@TAXABLEVALUE"].Value = Convert.ToDecimal(_dbEstimate.ArrayList[i, 7]);
                        cmdUniversal.Parameters["@CGST"].Value = Convert.ToDecimal(_dbEstimate.ArrayList[i, 8]);
                        cmdUniversal.Parameters["@CGSTValue"].Value = Convert.ToDecimal(_dbEstimate.ArrayList[i, 9]);
                        cmdUniversal.Parameters["@SGST"].Value = Convert.ToDecimal(_dbEstimate.ArrayList[i, 10]);
                        cmdUniversal.Parameters["@SGSTValue"].Value = Convert.ToDecimal(_dbEstimate.ArrayList[i, 11]);
                        cmdUniversal.Parameters["@IGST"].Value = Convert.ToDecimal(_dbEstimate.ArrayList[i, 12]);
                        cmdUniversal.Parameters["@IGSTValue"].Value = Convert.ToDecimal(_dbEstimate.ArrayList[i, 13]);
                        cmdUniversal.Parameters["@HSNNo"].Value = Convert.ToString(_dbEstimate.ArrayList[i, 14]);
                        cmdUniversal.Parameters["@TotalGST"].Value = Convert.ToDecimal(_dbEstimate.ArrayList[i, 15]);
                       // cmdUniversal.Parameters["@HSNNo"].Value = Convert.ToDecimal(_dbEstimate.ArrayList[i, 16]);
                        cmdUniversal.Parameters["@TotalAmount"].Value = Convert.ToDecimal(_dbEstimate.ArrayList[i, 16]);
                        cmdUniversal.ExecuteNonQuery();
                        cmdUniversal = new SqlCommand("SaveStockMaster", cnUniversal, trans);
                        cmdUniversal.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(cmdUniversal);

                        cmdUniversal.Parameters["@ItemCode"].Value = _dbEstimate.ArrayList[i, 0];
                        cmdUniversal.Parameters["@Branch"].Value = _dbEstimate.Branch;
                        cmdUniversal.Parameters["@InQty"].Value = Convert.ToDecimal(0);
                        cmdUniversal.Parameters["@OutQty"].Value = Convert.ToDecimal(_dbEstimate.ArrayList[i, 3]);
                        cmdUniversal.Parameters["@TransactionDate"].Value = Convert.ToDateTime(_dbEstimate.InvoiceDate);
                        cmdUniversal.Parameters["@Username"].Value = Convert.ToString(_dbEstimate.UserName);
                        cmdUniversal.Parameters["@InvoiceNo"].Value = _dbEstimate.EstimateN;

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

        public int UpdateEstimateMaster(dbEstimate _dbEstmate)
        {
            //SqlTransaction trans;
            //this.Initialize();
            //int result = 0;
            //using (cnUniversal)
            //{
            //    cnUniversal.Open();
            //    trans = cnUniversal.BeginTransaction();
            //    try
            //    {
            //        cmdUniversal = new SqlCommand("UpdateEstimateMsters", cnUniversal, trans);
            //        cmdUniversal.CommandType = CommandType.StoredProcedure;
            //        SqlCommandBuilder.DeriveParameters(cmdUniversal);

            //        cmdUniversal.Parameters["@EstNo"].Value = _dbEstmate.EstimateN;
            //        cmdUniversal.Parameters["@EstNoDate"].Value = _dbEstmate.InwardDate;

            //        cmdUniversal.Parameters["@CustomerName"].Value = _dbEstmate.CustomerCode;
            //        cmdUniversal.Parameters["@Address"].Value = _dbEstmate.Address;
            //        cmdUniversal.Parameters["@ContactPerson"].Value = _dbEstmate.ContactPerson;
            //        cmdUniversal.Parameters["@State"].Value = _dbEstmate.State;
            //        cmdUniversal.Parameters["@ContactNo"].Value = _dbEstmate.ContactNo;
            //        cmdUniversal.Parameters["@UserName"].Value = _dbEstmate.UserName;
            //        cmdUniversal.Parameters["@Branch"].Value = _dbEstmate.Branch;
            //        cmdUniversal.Parameters["@SystemEntryDate"].Value = System.DateTime.Now;
            //        cmdUniversal.ExecuteNonQuery();


            //        cmdUniversal = new SqlCommand("DeleteMaterialInwardInvoice", cnUniversal, trans);
            //        cmdUniversal.CommandType = CommandType.StoredProcedure;
            //        SqlCommandBuilder.DeriveParameters(cmdUniversal);
            //        cmdUniversal.Parameters["@EstNo"].Value = _dbEstmate.EstimateN;
            //        cmdUniversal.ExecuteNonQuery();

            //        for (int i = 0; i < _dbEstmate.ArrayList.GetLength(0); i++)
            //        {
            //            cmdUniversal.Parameters["@EstNo"].Value = _dbEstmate.EstimateN;

            //            cmdUniversal.Parameters["@ItemCode"].Value = _dbEstmate.ArrayList[i, 0];
            //            //cmdUniversal.Parameters["@ItemName"].Value = _dbEstimate.ArrayList[i, 1];
            //            cmdUniversal.Parameters["@UOM"].Value = Convert.ToString(_dbEstmate.ArrayList[i, 2]);
            //            cmdUniversal.Parameters["@Quantity"].Value = Convert.ToInt32(_dbEstmate.ArrayList[i, 3]);
            //            cmdUniversal.Parameters["@Rate"].Value = Convert.ToDecimal(_dbEstmate.ArrayList[i, 4]);
            //            cmdUniversal.Parameters["@Amount"].Value = Convert.ToDecimal(_dbEstmate.ArrayList[i, 5]);

            //            cmdUniversal.Parameters["@Discount"].Value = Convert.ToDecimal(_dbEstmate.ArrayList[i, 6]);
            //            cmdUniversal.Parameters["@TAXABLEVALUE"].Value = Convert.ToDecimal(_dbEstmate.ArrayList[i, 7]);
            //            cmdUniversal.Parameters["@CGST"].Value = Convert.ToDecimal(_dbEstmate.ArrayList[i, 8]);
            //            cmdUniversal.Parameters["@CGSTValue"].Value = Convert.ToDecimal(_dbEstmate.ArrayList[i, 9]);
            //            cmdUniversal.Parameters["@SGST"].Value = Convert.ToDecimal(_dbEstmate.ArrayList[i, 10]);
            //            cmdUniversal.Parameters["@SGSTValue"].Value = Convert.ToDecimal(_dbEstmate.ArrayList[i, 11]);
            //            cmdUniversal.Parameters["@IGST"].Value = Convert.ToDecimal(_dbEstmate.ArrayList[i, 12]);
            //            cmdUniversal.Parameters["@IGSTValue"].Value = Convert.ToDecimal(_dbEstmate.ArrayList[i, 13]);

            //            cmdUniversal.Parameters["@HSNCODE"].Value = Convert.ToString(_dbEstmate.ArrayList[i, 14]);
            //            cmdUniversal.Parameters["@TotalGSTTax"].Value = Convert.ToDecimal(_dbEstmate.ArrayList[i, 15]);
            //            cmdUniversal.Parameters["@TotalGSTAMOUNT"].Value = Convert.ToDecimal(_dbEstmate.ArrayList[i, 16]);
            //            cmdUniversal.Parameters["@RawMaterial"].Value = Convert.ToDecimal(_dbEstmate.ArrayList[i, 17]);

            //            cmdUniversal.ExecuteNonQuery();

            //            cmdUniversal = new SqlCommand("SaveStockMaster", cnUniversal, trans);
            //            cmdUniversal.CommandType = CommandType.StoredProcedure;
            //            SqlCommandBuilder.DeriveParameters(cmdUniversal);

            //            cmdUniversal.Parameters["@ItemCode"].Value = _dbEstmate.ArrayList[i, 0];
            //            cmdUniversal.Parameters["@Branch"].Value = _dbEstmate.Branch;
            //            cmdUniversal.Parameters["@InQty"].Value = Convert.ToDecimal(0);
            //            cmdUniversal.Parameters["@OutQty"].Value = Convert.ToDecimal(_dbEstmate.ArrayList[i, 3]);
            //            cmdUniversal.Parameters["@TransactionDate"].Value = Convert.ToDateTime(_dbEstmate.InvoiceDate);
            //            cmdUniversal.Parameters["@Username"].Value = Convert.ToString(_dbEstmate.UserName);
            //            cmdUniversal.Parameters["@InvoiceNo"].Value = _dbEstmate.EstimateN;

            //            cmdUniversal.ExecuteNonQuery();

            //        }
            //        trans.Commit();
            //        cnUniversal.Close();
            //        return 1;

            //    }
            //    catch (Exception)
            //    {
            //        trans.Rollback();
            //        cnUniversal.Close();
            //        return 0;
            //    }
            //}
            return 0;
        }

    }
}
