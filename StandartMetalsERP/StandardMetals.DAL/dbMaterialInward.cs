using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace StandardMetals.DAL
{
    public class dbMaterialInward : ConncetionClass
    {
        DataTable dt;
        public string[,] ArrayList { get; set; }
        public string Cmp_Code { get; set; }
        public int FinancialYearID { get; set; }
        public string UIN { get; set; }
        public DateTime InwardDate { get; set; }
        public string InvoiceNO { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string SupplierCode { get; set; }
        
        public string SupplierName { get; set; }
        public string Address { get; set; }
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

        public DataTable FillItemMaster()
        {
            this.Initialize();
            int nRecAffected = 0;
            dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "FillItemMaster";

                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable FillRawMaterial(string cmpCode,string itemcode,int flag)
        {
            this.Initialize();
            int nRecAffected = 0;
            dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "FillRawMaterial";
                cmdUniversal.Parameters.Add("@Cmp_code", SqlDbType.VarChar).Value = cmpCode;
                cmdUniversal.Parameters.Add("@ItemCode", SqlDbType.VarChar).Value = itemcode;
                cmdUniversal.Parameters.Add("@Flag", SqlDbType.Int).Value = flag;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable FillUIN_No()
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetMaterialInwardNo";

                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }


        
        public DataTable RetriveSuppDetails(string Suppcode, int flag)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetSupplierMaster";

                cmdUniversal.Parameters.Add("@Suppcode", SqlDbType.VarChar).Value = Suppcode;
                cmdUniversal.Parameters.Add("@Flag", SqlDbType.Int).Value = flag;

                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable GetMaxMatInvoiceNo()
        {
            this.Initialize();
            int nRecAffected = 0;
            dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetMatInvoiceNo";

                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable GetMaxUIN()
        {
            this.Initialize();
            int nRecAffected = 0;
            dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetMaxUIN";

                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public int SaveTaxInvoiceMaster(dbMaterialInward _dbMaterialInward)
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
                    cmdUniversal = new SqlCommand("SaveMaterialInvoiceMaster", cnUniversal, trans);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);

                    cmdUniversal.Parameters["@UIN"].Value = _dbMaterialInward.UIN;
                    cmdUniversal.Parameters["@InwardDate"].Value = Convert.ToDateTime(_dbMaterialInward.InwardDate);
                    cmdUniversal.Parameters["@InvoiceNO"].Value = _dbMaterialInward.InvoiceNO;
                    cmdUniversal.Parameters["@InvoiceDate"].Value = _dbMaterialInward.InvoiceDate;
                    cmdUniversal.Parameters["@SupplierCode"].Value = _dbMaterialInward.SupplierCode;
                    cmdUniversal.Parameters["@InwordBranch"].Value = "Katraj";
                    cmdUniversal.Parameters["@SubTotal"].Value = _dbMaterialInward.Total;
                    cmdUniversal.Parameters["@GrandTotal"].Value = _dbMaterialInward.GrandTotal;
                    cmdUniversal.Parameters["@Remark"].Value = _dbMaterialInward.Remark;
                    cmdUniversal.Parameters["@UserName"].Value = _dbMaterialInward.UserName;
                    cmdUniversal.Parameters["@TransportMode"].Value = _dbMaterialInward.TransportMode;
                    cmdUniversal.Parameters["@dateofSupply"].Value = _dbMaterialInward.dateofSupply;
                    cmdUniversal.Parameters["@placeofsupply"].Value = _dbMaterialInward.placeofsupply;
                    cmdUniversal.Parameters["@LoadingCharges"].Value = _dbMaterialInward.LoadingCharges;
                    cmdUniversal.Parameters["@TransportChages"].Value = _dbMaterialInward.TransportCharges;

                    cmdUniversal.Parameters["@FreightAmount"].Value = _dbMaterialInward.FrightAmount;

                    cmdUniversal.Parameters["@PackingAmount"].Value = _dbMaterialInward.PackingAmount;

                    cmdUniversal.Parameters["@VehicleNo"].Value = _dbMaterialInward.VehicleNo;
                    cmdUniversal.Parameters["@GSTReverseChargeYesORNO"].Value = _dbMaterialInward.GSTReverseChargeYesORNO;
                    cmdUniversal.Parameters["@GSTReverseCharge"].Value = _dbMaterialInward.GSTReverseCharge;
                    cmdUniversal.Parameters["@SystemEntryDate"].Value = System.DateTime.Now;
                    

                    cmdUniversal.ExecuteNonQuery();

                    for (int i = 0; i < _dbMaterialInward.ArrayList.GetLength(0); i++)
                    {
                        cmdUniversal = new SqlCommand("SaveMaterialInvoiceDetails", cnUniversal, trans);
                        cmdUniversal.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(cmdUniversal);

                        cmdUniversal.Parameters["@UIN"].Value = _dbMaterialInward.UIN;
                        cmdUniversal.Parameters["@InwardDate"].Value = Convert.ToDateTime(_dbMaterialInward.InwardDate);

                        cmdUniversal.Parameters["@InvoiceNO"].Value = _dbMaterialInward.InvoiceNO;
                        cmdUniversal.Parameters["@InvoiceDate"].Value = Convert.ToDateTime(_dbMaterialInward.InvoiceDate);


                        cmdUniversal.Parameters["@ItemCode"].Value = _dbMaterialInward.ArrayList[i, 0];
                        cmdUniversal.Parameters["@ItemName"].Value = _dbMaterialInward.ArrayList[i, 1];
                        cmdUniversal.Parameters["@UOM"].Value = Convert.ToString(_dbMaterialInward.ArrayList[i, 2]);
                        cmdUniversal.Parameters["@TotalQty"].Value = Convert.ToInt32(_dbMaterialInward.ArrayList[i, 3]);
                        cmdUniversal.Parameters["@Rate"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 4]);
                        cmdUniversal.Parameters["@Amount"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 5]);

                        cmdUniversal.Parameters["@Discount"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 6]);
                        cmdUniversal.Parameters["@TAXABLEVALUE"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 7]);
                        cmdUniversal.Parameters["@CGST"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 8]);
                        cmdUniversal.Parameters["@CGSTValue"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 9]);
                        cmdUniversal.Parameters["@SGST"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 10]);
                        cmdUniversal.Parameters["@SGSTValue"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 11]);
                        cmdUniversal.Parameters["@IGST"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 12]);
                        cmdUniversal.Parameters["@IGSTValue"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 13]);

                        cmdUniversal.Parameters["@HSNCODE"].Value = Convert.ToString(_dbMaterialInward.ArrayList[i, 14]);
                        cmdUniversal.Parameters["@TotalGSTTax"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 15]);
                        cmdUniversal.Parameters["@TotalGSTAMOUNT"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 16]);
                        cmdUniversal.Parameters["@RawMaterial"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 17]);

                        cmdUniversal.ExecuteNonQuery();


                        cmdUniversal = new SqlCommand("SaveStockMaster", cnUniversal, trans);
                        cmdUniversal.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(cmdUniversal);

                        cmdUniversal.Parameters["@ItemCode"].Value = _dbMaterialInward.ArrayList[i, 0];
                        cmdUniversal.Parameters["@Branch"].Value = _dbMaterialInward.Branch;
                        cmdUniversal.Parameters["@InQty"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 3]);
                        cmdUniversal.Parameters["@OutQty"].Value = Convert.ToDecimal(0);
                        cmdUniversal.Parameters["@TransactionDate"].Value = Convert.ToDateTime(_dbMaterialInward.InvoiceDate);
                        cmdUniversal.Parameters["@Username"].Value = Convert.ToString(_dbMaterialInward.UserName);
                        cmdUniversal.Parameters["@InvoiceNo"].Value = _dbMaterialInward.UIN;

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

        public int UpdateMaterialInvoiceMaster(dbMaterialInward _dbMaterialInward)
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
                    cmdUniversal = new SqlCommand("UpdateMaterialInvoiceMaster", cnUniversal, trans);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);


                    cmdUniversal.Parameters["@UIN"].Value = _dbMaterialInward.UIN;
                    cmdUniversal.Parameters["@InwardDate"].Value = _dbMaterialInward.InwardDate;
                    cmdUniversal.Parameters["@InvoiceNO"].Value = _dbMaterialInward.InvoiceNO;
                    cmdUniversal.Parameters["@InvoiceDate"].Value = _dbMaterialInward.InvoiceDate;
                    cmdUniversal.Parameters["@SupplierCode"].Value = _dbMaterialInward.SupplierCode;
                    cmdUniversal.Parameters["@InwordBranch"].Value = "Katraj";
                    cmdUniversal.Parameters["@SubTotal"].Value = _dbMaterialInward.Total;
                    cmdUniversal.Parameters["@GrandTotal"].Value = _dbMaterialInward.GrandTotal;
                    cmdUniversal.Parameters["@Remark"].Value = _dbMaterialInward.Remark;
                    cmdUniversal.Parameters["@UserName"].Value = _dbMaterialInward.UserName;
                    cmdUniversal.Parameters["@TransportMode"].Value = _dbMaterialInward.TransportMode;
                    cmdUniversal.Parameters["@dateofSupply"].Value = _dbMaterialInward.dateofSupply;
                    cmdUniversal.Parameters["@placeofsupply"].Value = _dbMaterialInward.placeofsupply;
                    cmdUniversal.Parameters["@LoadingCharges"].Value = _dbMaterialInward.LoadingCharges;
                    cmdUniversal.Parameters["@TransportChages"].Value = _dbMaterialInward.TransportCharges;

                    cmdUniversal.Parameters["@FreightAmount"].Value = _dbMaterialInward.FrightAmount;

                    cmdUniversal.Parameters["@PackingAmount"].Value = _dbMaterialInward.PackingAmount;

                    cmdUniversal.Parameters["@VehicleNo"].Value = _dbMaterialInward.VehicleNo;
                    cmdUniversal.Parameters["@GSTReverseChargeYesORNO"].Value = _dbMaterialInward.GSTReverseChargeYesORNO;
                    cmdUniversal.Parameters["@GSTReverseCharge"].Value = _dbMaterialInward.GSTReverseCharge;
                    cmdUniversal.Parameters["@SystemEntryDate"].Value = System.DateTime.Now;
                    

                    cmdUniversal.ExecuteNonQuery();


                    cmdUniversal = new SqlCommand("DeleteMaterialInwardInvoice", cnUniversal, trans);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);
                    cmdUniversal.Parameters["@UIN"].Value = _dbMaterialInward.UIN;
                    cmdUniversal.ExecuteNonQuery();

                    for (int i = 0; i < _dbMaterialInward.ArrayList.GetLength(0); i++)
                    {
                        cmdUniversal = new SqlCommand("SaveMaterialInvoiceDetails", cnUniversal, trans);
                        cmdUniversal.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(cmdUniversal);

                        cmdUniversal.Parameters["@UIN"].Value = _dbMaterialInward.UIN;
                        cmdUniversal.Parameters["@InwardDate"].Value = Convert.ToDateTime(_dbMaterialInward.InwardDate);

                        cmdUniversal.Parameters["@InvoiceNO"].Value = _dbMaterialInward.InvoiceNO;
                        cmdUniversal.Parameters["@InvoiceDate"].Value = Convert.ToDateTime(_dbMaterialInward.InvoiceDate);


                        cmdUniversal.Parameters["@ItemCode"].Value = _dbMaterialInward.ArrayList[i, 0];
                        cmdUniversal.Parameters["@ItemName"].Value = _dbMaterialInward.ArrayList[i, 1];
                        cmdUniversal.Parameters["@UOM"].Value = Convert.ToString(_dbMaterialInward.ArrayList[i, 2]);
                        cmdUniversal.Parameters["@TotalQty"].Value = Convert.ToInt32(_dbMaterialInward.ArrayList[i, 3]);
                        cmdUniversal.Parameters["@Rate"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 4]);
                        cmdUniversal.Parameters["@Amount"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 5]);

                        cmdUniversal.Parameters["@Discount"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 6]);
                        cmdUniversal.Parameters["@TAXABLEVALUE"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 7]);
                        cmdUniversal.Parameters["@CGST"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 8]);
                        cmdUniversal.Parameters["@CGSTValue"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 9]);
                        cmdUniversal.Parameters["@SGST"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 10]);
                        cmdUniversal.Parameters["@SGSTValue"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 11]);
                        cmdUniversal.Parameters["@IGST"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 12]);
                        cmdUniversal.Parameters["@IGSTValue"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 13]);

                        cmdUniversal.Parameters["@HSNCODE"].Value = Convert.ToString(_dbMaterialInward.ArrayList[i, 14]);
                        cmdUniversal.Parameters["@TotalGSTTax"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 15]);
                        cmdUniversal.Parameters["@TotalGSTAMOUNT"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 16]);

                        cmdUniversal.Parameters["@RawMaterial"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 17]);


                        cmdUniversal.ExecuteNonQuery();
                        
                        cmdUniversal = new SqlCommand("SaveStockMaster", cnUniversal, trans);
                        cmdUniversal.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(cmdUniversal);

                        cmdUniversal.Parameters["@ItemCode"].Value = _dbMaterialInward.ArrayList[i, 0];
                        cmdUniversal.Parameters["@Branch"].Value = _dbMaterialInward.Branch;
                        cmdUniversal.Parameters["@InQty"].Value = Convert.ToDecimal(_dbMaterialInward.ArrayList[i, 3]);
                        cmdUniversal.Parameters["@OutQty"].Value = Convert.ToDecimal(0);
                        cmdUniversal.Parameters["@TransactionDate"].Value = Convert.ToDateTime(_dbMaterialInward.InvoiceDate);
                        cmdUniversal.Parameters["@Username"].Value = Convert.ToString(_dbMaterialInward.UserName);
                        cmdUniversal.Parameters["@InvoiceNo"].Value = _dbMaterialInward.UIN;

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

        public DataTable RetriveData(string MaterialInvoiceNo)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "RetriveMaterialInwardData";
                cmdUniversal.Parameters.Add("@UIN", SqlDbType.VarChar).Value = MaterialInvoiceNo;

                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable RetriveMAterialInwardDetails(string MaterialInvoiceNo)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "RetriveMaterialInwardDetail";
                cmdUniversal.Parameters.Add("@UIN", SqlDbType.VarChar).Value = MaterialInvoiceNo;

                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }


    }
}
