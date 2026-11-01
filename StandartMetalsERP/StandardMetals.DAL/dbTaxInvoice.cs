using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StandardMetals.MODEL;

namespace StandardMetals.DAL
{
    public class dbTaxInvoice : ConncetionClass
    {
        DataTable dt;
        public string[,] ArrayList { get; set; }
        public string Cmp_Code { get; set; }
        public int FinancialYearID { get; set; }
        public string InvoiceNO { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
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
        public string PaymentTerm { get; set; }
        public string POClose { get; set; }
        public string Branch { get; set; }

        public string InvoiceCancle { get; set; }
        public DataTable GetMaxTaxInvoiceNo()
        {
            this.Initialize();
            int nRecAffected = 0;
            dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetMaxTaxInvoiceNo";
                
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        //public DataTable FillItemMaster()
        //{
        //    this.Initialize();
        //    int nRecAffected = 0;
        //    dt = new DataTable();
        //    using (cnUniversal)
        //    {
        //        cmdUniversal.CommandText = "FillItemMaster";

        //        this.daUniversal.SelectCommand = cmdUniversal;
        //        this.cnUniversal.Open();
        //        nRecAffected = this.daUniversal.Fill(dt);
        //        this.Close();
        //        return dt;
        //    }
        //}
        public List<ItemMasterModel> GetAllItemMasterData()
        {
            this.Initialize();
            int nRecAffected = 0;
            dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "Get_All_ItemMasterData";

                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                List<ItemMasterModel> lst = new List<ItemMasterModel>();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        lst.Add(new ItemMasterModel()
                        {
                            ID = Convert.ToInt32(dt.Rows[i]["ID"]),
                            ItemCode = dt.Rows[i]["ItemCode"].ToString(),
                            ItemName = dt.Rows[i]["ItemName"].ToString(),
                            //ManufacturerId = Convert.ToInt32(dt.Rows[i]["ManufacturerId"]),
                            ManufacturerName = dt.Rows[i]["ManufacturerName"].ToString(),
                            Material = dt.Rows[i]["Material"].ToString(),
                            //ItemCategoryId = Convert.ToInt32(dt.Rows[i]["CategoryId"]),
                            CategoryName = dt.Rows[i]["CategoryName"].ToString(),
                            SubCategoryName = dt.Rows[i]["SubCategoryName"].ToString(),
                            ColourName = dt.Rows[i]["ColourName"].ToString(),
                            UnitName = dt.Rows[i]["UnitName"].ToString(),
                            //ItemSubCategoryId = Convert.ToInt32(dt.Rows[i]["SubCategoryId"]),
                            //ColourId = Convert.ToInt32(dt.Rows[i]["ColourId"]),
                            //UnitId = Convert.ToInt32(dt.Rows[i]["UnitId"]),
                            HSNCODE = dt.Rows[i]["HSNCODE"].ToString(),
                            GSTRate = Convert.ToDecimal(dt.Rows[i]["GSTRate"]),
                            PurchaseCost =Convert.ToDecimal(dt.Rows[i]["PurchaseCost"]),
                            SellingPrice = Convert.ToDecimal(dt.Rows[i]["SellingPrice"])
                            
                        });

                    }
                }
                return lst;
            }
        }

        public List<ItemMasterModel> FillItemMaster()
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
                List<ItemMasterModel> lst = new List<ItemMasterModel>();
                if (dt.Rows.Count > 0)
                {
                    for(int i = 0 ; i<dt.Rows.Count; i++)
                    {
                    
                    lst.Add(new ItemMasterModel() { 
                    ItemCode= dt.Rows[i]["ItemCode"].ToString(),
                    ItemName= dt.Rows[i]["ItemName"].ToString()
                    });

                    }
                }
                return lst;
            }
        }

        public int SaveTaxInvoiceMaster(dbTaxInvoice _dbTaxInvoice)
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
                    cmdUniversal = new SqlCommand("SaveTaxInvoiceMaster", cnUniversal, trans);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);
                    
                    cmdUniversal.Parameters["@InvoiceNO"].Value = _dbTaxInvoice.InvoiceNO;
                    cmdUniversal.Parameters["@InvoiceDate"].Value = _dbTaxInvoice.InvoiceDate;
                    cmdUniversal.Parameters["@CustomerCode"].Value = _dbTaxInvoice.CustomerCode;
                    cmdUniversal.Parameters["@ShiptoCustcode"].Value = _dbTaxInvoice.ShiptoCustcode;

                    //cmdUniversal.Parameters["@CustomerName"].Value = _dbTaxInvoice.CustomerName;
                    //cmdUniversal.Parameters["@Address"].Value = _dbTaxInvoice.Address;
                    //cmdUniversal.Parameters["@ContactPerson"].Value = _dbTaxInvoice.ContactPerson;
                    //cmdUniversal.Parameters["@ContactNo"].Value = _dbTaxInvoice.ContactNo;
                    cmdUniversal.Parameters["@POType"].Value = _dbTaxInvoice.POTYPE;
                    cmdUniversal.Parameters["@PONO"].Value = _dbTaxInvoice.PONO;
                    cmdUniversal.Parameters["@PODate"].Value = _dbTaxInvoice.PODate;
                    cmdUniversal.Parameters["@TotalinvoiceRs"].Value = _dbTaxInvoice.Total;
                    
                    cmdUniversal.Parameters["@GrandTotal"].Value = _dbTaxInvoice.GrandTotal;
                    cmdUniversal.Parameters["@Remark"].Value = _dbTaxInvoice.Remark;
                    cmdUniversal.Parameters["@UserName"].Value = _dbTaxInvoice.UserName;
                                        
                    cmdUniversal.Parameters["@TransportMode"].Value = _dbTaxInvoice.TransportMode;

                    cmdUniversal.Parameters["@dateofSupply"].Value = _dbTaxInvoice.dateofSupply;
                    
                    cmdUniversal.Parameters["@placeofsupply"].Value = _dbTaxInvoice.placeofsupply;
                    cmdUniversal.Parameters["@LoadingCharges"].Value = _dbTaxInvoice.LoadingCharges;
                    cmdUniversal.Parameters["@TransportCharges"].Value = _dbTaxInvoice.TransportCharges;

                    cmdUniversal.Parameters["@FrightRate"].Value = _dbTaxInvoice.FrightRate;
                    cmdUniversal.Parameters["@FrightUnit"].Value = _dbTaxInvoice.FrightUnit;
                    cmdUniversal.Parameters["@FrightAmount"].Value = _dbTaxInvoice.FrightAmount;
                    cmdUniversal.Parameters["@PackingRate"].Value = _dbTaxInvoice.PackingRate;
                    cmdUniversal.Parameters["@PackingUnit"].Value = _dbTaxInvoice.PackingUnit;
                    cmdUniversal.Parameters["@PackingAmount"].Value = _dbTaxInvoice.PackingAmount;

                    cmdUniversal.Parameters["@MASCGSTRATE"].Value = _dbTaxInvoice.MAXCGSTRATE;
                    cmdUniversal.Parameters["@MASSGSTRATE"].Value = _dbTaxInvoice.MAXSGSTRATE;
                    cmdUniversal.Parameters["@MASIGSTRATE"].Value = _dbTaxInvoice.MAXIGSTRATE;
                    cmdUniversal.Parameters["@MASCGSTAMT"].Value = _dbTaxInvoice.MAXCGSTAMT;
                    cmdUniversal.Parameters["@MASSGSTAMT"].Value = _dbTaxInvoice.MAXSGSTAMT;
                    cmdUniversal.Parameters["@MASIGSTAMT"].Value = _dbTaxInvoice.MAXIGSTAMT;

                    cmdUniversal.Parameters["@VehicleNo"].Value = _dbTaxInvoice.VehicleNo;
                    cmdUniversal.Parameters["@GSTReverseChargeYesORNO"].Value = _dbTaxInvoice.GSTReverseChargeYesORNO;
                    cmdUniversal.Parameters["@GSTReverseCharge"].Value = _dbTaxInvoice.GSTReverseCharge;
                    cmdUniversal.Parameters["@bankaccount"].Value = _dbTaxInvoice.bankaccount;
                    cmdUniversal.Parameters["@bankIFSC"].Value = _dbTaxInvoice.bankIFSC;
                    cmdUniversal.Parameters["@PaymentTerm"].Value = _dbTaxInvoice.PaymentTerm;
                    cmdUniversal.Parameters["@POClose"].Value = _dbTaxInvoice.POClose;

                    cmdUniversal.ExecuteNonQuery();

                    for (int i = 0; i < _dbTaxInvoice.ArrayList.GetLength(0); i++)
                    {
                        cmdUniversal = new SqlCommand("SaveTaxInvoiceDetails", cnUniversal, trans);
                        cmdUniversal.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(cmdUniversal);

                        cmdUniversal.Parameters["@InvoiceNO"].Value = _dbTaxInvoice.InvoiceNO;
                        cmdUniversal.Parameters["@InvoiceDate"].Value = _dbTaxInvoice.InvoiceDate;
                        
                        cmdUniversal.Parameters["@ItemCode"].Value = _dbTaxInvoice.ArrayList[i, 0];
                        cmdUniversal.Parameters["@ItemName"].Value = _dbTaxInvoice.ArrayList[i, 1];
                        cmdUniversal.Parameters["@UOM"].Value = Convert.ToString(_dbTaxInvoice.ArrayList[i, 2]);
                        cmdUniversal.Parameters["@TotalQty"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 3]);
                        cmdUniversal.Parameters["@Rate"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 4]);
                        cmdUniversal.Parameters["@Amount"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 5]);
                        
                        cmdUniversal.Parameters["@Discount"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 6]);
                        cmdUniversal.Parameters["@TAXABLEVALUE"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 7]);
                        cmdUniversal.Parameters["@CGST"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 8]);
                        cmdUniversal.Parameters["@CGSTValue"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 9]);
                        cmdUniversal.Parameters["@SGST"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 10]);
                        cmdUniversal.Parameters["@SGSTValue"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 11]);
                        cmdUniversal.Parameters["@IGST"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 12]);
                        cmdUniversal.Parameters["@IGSTValue"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 13]);
                        
                        cmdUniversal.Parameters["@HSNCODE"].Value = Convert.ToString(_dbTaxInvoice.ArrayList[i, 14]);
                        cmdUniversal.Parameters["@TotalGSTTax"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 15]);
                        cmdUniversal.Parameters["@TotalGSTAMOUNT"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 16]);
                        

                        cmdUniversal.ExecuteNonQuery();

                        cmdUniversal = new SqlCommand("SaveStockMaster", cnUniversal, trans);
                        cmdUniversal.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(cmdUniversal);

                        cmdUniversal.Parameters["@ItemCode"].Value = _dbTaxInvoice.ArrayList[i, 0];
                        cmdUniversal.Parameters["@Branch"].Value = _dbTaxInvoice.Branch;
                        cmdUniversal.Parameters["@InQty"].Value = Convert.ToDecimal(0);
                        cmdUniversal.Parameters["@OutQty"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 3]);
                        cmdUniversal.Parameters["@TransactionDate"].Value = Convert.ToDateTime(_dbTaxInvoice.InvoiceDate);
                        cmdUniversal.Parameters["@Username"].Value = Convert.ToString(_dbTaxInvoice.UserName);
                        cmdUniversal.Parameters["@InvoiceNo"].Value = _dbTaxInvoice.InvoiceNO;

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

        public int UpdateTaxInvoiceMaster(dbTaxInvoice _dbTaxInvoice)
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
                    cmdUniversal = new SqlCommand("UpdateTaxInvoiceMaster", cnUniversal, trans);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);


                    cmdUniversal.Parameters["@InvoiceNO"].Value = _dbTaxInvoice.InvoiceNO;
                    cmdUniversal.Parameters["@InvoiceDate"].Value = _dbTaxInvoice.InvoiceDate;
                    cmdUniversal.Parameters["@CustomerCode"].Value = _dbTaxInvoice.CustomerCode;
                    cmdUniversal.Parameters["@ShiptoCustcode"].Value = _dbTaxInvoice.ShiptoCustcode;

                    //cmdUniversal.Parameters["@CustomerName"].Value = _dbTaxInvoice.CustomerName;
                    //cmdUniversal.Parameters["@Address"].Value = _dbTaxInvoice.Address;
                    //cmdUniversal.Parameters["@ContactPerson"].Value = _dbTaxInvoice.ContactPerson;
                    //cmdUniversal.Parameters["@ContactNo"].Value = _dbTaxInvoice.ContactNo;
                    cmdUniversal.Parameters["@POType"].Value = _dbTaxInvoice.POTYPE;
                    cmdUniversal.Parameters["@PONO"].Value = _dbTaxInvoice.PONO;
                    cmdUniversal.Parameters["@PODate"].Value = _dbTaxInvoice.PODate;
                    cmdUniversal.Parameters["@TotalinvoiceRs"].Value = _dbTaxInvoice.Total;

                    cmdUniversal.Parameters["@GrandTotal"].Value = _dbTaxInvoice.GrandTotal;
                    cmdUniversal.Parameters["@Remark"].Value = _dbTaxInvoice.Remark;
                    cmdUniversal.Parameters["@UserName"].Value = _dbTaxInvoice.UserName;

                    cmdUniversal.Parameters["@TransportMode"].Value = _dbTaxInvoice.TransportMode;

                    cmdUniversal.Parameters["@dateofSupply"].Value = _dbTaxInvoice.dateofSupply;

                    cmdUniversal.Parameters["@placeofsupply"].Value = _dbTaxInvoice.placeofsupply;
                    cmdUniversal.Parameters["@LoadingCharges"].Value = _dbTaxInvoice.LoadingCharges;
                    cmdUniversal.Parameters["@TransportCharges"].Value = _dbTaxInvoice.TransportCharges;

                    cmdUniversal.Parameters["@FrightRate"].Value = _dbTaxInvoice.FrightRate;
                    cmdUniversal.Parameters["@FrightUnit"].Value = _dbTaxInvoice.FrightUnit;
                    cmdUniversal.Parameters["@FrightAmount"].Value = _dbTaxInvoice.FrightAmount;
                    cmdUniversal.Parameters["@PackingRate"].Value = _dbTaxInvoice.PackingRate;
                    cmdUniversal.Parameters["@PackingUnit"].Value = _dbTaxInvoice.PackingUnit;
                    cmdUniversal.Parameters["@PackingAmount"].Value = _dbTaxInvoice.PackingAmount;

                    cmdUniversal.Parameters["@MAXCGSTRATE"].Value = _dbTaxInvoice.MAXCGSTRATE;
                    cmdUniversal.Parameters["@MAXSGSTRATE"].Value = _dbTaxInvoice.MAXSGSTRATE;
                    cmdUniversal.Parameters["@MAXIGSTRATE"].Value = _dbTaxInvoice.MAXIGSTRATE;
                    cmdUniversal.Parameters["@MAXCGSTAMT"].Value = _dbTaxInvoice.MAXCGSTAMT;
                    cmdUniversal.Parameters["@MAXSGSTAMT"].Value = _dbTaxInvoice.MAXSGSTAMT;
                    cmdUniversal.Parameters["@MAXIGSTAMT"].Value = _dbTaxInvoice.MAXIGSTAMT;

                    cmdUniversal.Parameters["@VehicleNo"].Value = _dbTaxInvoice.VehicleNo;
                    cmdUniversal.Parameters["@GSTReverseChargeYesORNO"].Value = _dbTaxInvoice.GSTReverseChargeYesORNO;
                    cmdUniversal.Parameters["@GSTReverseCharge"].Value = _dbTaxInvoice.GSTReverseCharge;
                    cmdUniversal.Parameters["@bankaccount"].Value = _dbTaxInvoice.bankaccount;
                    cmdUniversal.Parameters["@bankIFSC"].Value = _dbTaxInvoice.bankIFSC;
                    cmdUniversal.Parameters["@PaymentTerm"].Value = _dbTaxInvoice.PaymentTerm;
                    cmdUniversal.Parameters["@POClose"].Value = _dbTaxInvoice.POClose;

                    cmdUniversal.ExecuteNonQuery();

                    //cmdUniversal = new SqlCommand("DeleteTaxInvoiceDetails", cnUniversal, trans);
                    //cmdUniversal.CommandType = CommandType.StoredProcedure;
                    //SqlCommandBuilder.DeriveParameters(cmdUniversal);
                    //cmdUniversal.Parameters["@InvoiceNO"].Value = _dbTaxInvoice.InvoiceNO;
                    //cmdUniversal.ExecuteNonQuery();

                    //for (int i = 0; i < _dbTaxInvoice.ArrayList.GetLength(0); i++)
                    //{
                    //    //cmdUniversal = new SqlCommand("SaveTaxInvoiceDetails", cnUniversal, trans);
                    //    //cmdUniversal.CommandType = CommandType.StoredProcedure;
                    //    //SqlCommandBuilder.DeriveParameters(cmdUniversal);

                    //    //cmdUniversal.Parameters["@InvoiceNO"].Value = _dbTaxInvoice.InvoiceNO;
                    //    //cmdUniversal.Parameters["@InvoiceDate"].Value = _dbTaxInvoice.InvoiceDate;

                    //    //cmdUniversal.Parameters["@ItemCode"].Value = _dbTaxInvoice.ArrayList[i, 0];
                    //    //cmdUniversal.Parameters["@ItemName"].Value = _dbTaxInvoice.ArrayList[i, 1];
                    //    //cmdUniversal.Parameters["@UOM"].Value = Convert.ToString(_dbTaxInvoice.ArrayList[i, 2]);
                    //    //cmdUniversal.Parameters["@TotalQty"].Value = Convert.ToInt32(_dbTaxInvoice.ArrayList[i, 3]);
                    //    //cmdUniversal.Parameters["@Rate"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 4]);
                    //    //cmdUniversal.Parameters["@Amount"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 5]);

                    //    //cmdUniversal.Parameters["@Discount"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 6]);
                    //    //cmdUniversal.Parameters["@TAXABLEVALUE"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 7]);
                    //    //cmdUniversal.Parameters["@CGST"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 8]);
                    //    //cmdUniversal.Parameters["@CGSTValue"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 9]);
                    //    //cmdUniversal.Parameters["@SGST"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 10]);
                    //    //cmdUniversal.Parameters["@SGSTValue"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 11]);
                    //    //cmdUniversal.Parameters["@IGST"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 12]);
                    //    //cmdUniversal.Parameters["@IGSTValue"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 13]);

                    //    //cmdUniversal.Parameters["@HSNCODE"].Value = Convert.ToString(_dbTaxInvoice.ArrayList[i, 14]);
                    //    //cmdUniversal.Parameters["@TotalGSTTax"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 15]);
                    //    //cmdUniversal.Parameters["@TotalGSTAMOUNT"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 16]);

                    //    //cmdUniversal.ExecuteNonQuery();


                    //    cmdUniversal = new SqlCommand("SaveStockMaster", cnUniversal, trans);
                    //    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    //    SqlCommandBuilder.DeriveParameters(cmdUniversal);

                    //    cmdUniversal.Parameters["@ItemCode"].Value = _dbTaxInvoice.ArrayList[i, 0];
                    //    cmdUniversal.Parameters["@Branch"].Value = _dbTaxInvoice.Branch;
                    //    cmdUniversal.Parameters["@InQty"].Value = Convert.ToDecimal(0);
                    //    cmdUniversal.Parameters["@OutQty"].Value = Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 3]);
                    //    cmdUniversal.Parameters["@TransactionDate"].Value = Convert.ToDateTime(_dbTaxInvoice.InvoiceDate);
                    //    cmdUniversal.Parameters["@Username"].Value = Convert.ToString(_dbTaxInvoice.UserName);
                    //    cmdUniversal.Parameters["@InvoiceNo"].Value = _dbTaxInvoice.InvoiceNO;


                    //    cmdUniversal.ExecuteNonQuery();

                    //}

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
        public int UpdateInnvoiceCancle(dbTaxInvoice _dbTaxInvoice)
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
                    cmdUniversal = new SqlCommand("UpdateTaxInvoiceMaster", cnUniversal, trans);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);


                    cmdUniversal.Parameters["@InvoiceNO"].Value = _dbTaxInvoice.InvoiceNO;
                    cmdUniversal.Parameters["@InvoiceDate"].Value = _dbTaxInvoice.InvoiceDate;
                    cmdUniversal.Parameters["@CustomerCode"].Value = _dbTaxInvoice.CustomerCode;
                    cmdUniversal.Parameters["@ShiptoCustcode"].Value = _dbTaxInvoice.ShiptoCustcode;

                    //cmdUniversal.Parameters["@CustomerName"].Value = _dbTaxInvoice.CustomerName;
                    //cmdUniversal.Parameters["@Address"].Value = _dbTaxInvoice.Address;
                    //cmdUniversal.Parameters["@ContactPerson"].Value = _dbTaxInvoice.ContactPerson;
                    //cmdUniversal.Parameters["@ContactNo"].Value = _dbTaxInvoice.ContactNo;
                    cmdUniversal.Parameters["@POType"].Value = _dbTaxInvoice.POTYPE;
                    cmdUniversal.Parameters["@PONO"].Value = _dbTaxInvoice.PONO;
                    cmdUniversal.Parameters["@PODate"].Value = _dbTaxInvoice.PODate;
                    cmdUniversal.Parameters["@TotalinvoiceRs"].Value = _dbTaxInvoice.Total;

                    cmdUniversal.Parameters["@GrandTotal"].Value = _dbTaxInvoice.GrandTotal;
                    cmdUniversal.Parameters["@Remark"].Value = _dbTaxInvoice.Remark;
                    cmdUniversal.Parameters["@UserName"].Value = _dbTaxInvoice.UserName;

                    cmdUniversal.Parameters["@TransportMode"].Value = _dbTaxInvoice.TransportMode;

                    cmdUniversal.Parameters["@dateofSupply"].Value = _dbTaxInvoice.dateofSupply;

                    cmdUniversal.Parameters["@placeofsupply"].Value = _dbTaxInvoice.placeofsupply;
                    cmdUniversal.Parameters["@LoadingCharges"].Value = _dbTaxInvoice.LoadingCharges;
                    cmdUniversal.Parameters["@TransportCharges"].Value = _dbTaxInvoice.TransportCharges;

                    cmdUniversal.Parameters["@FrightRate"].Value = _dbTaxInvoice.FrightRate;
                    cmdUniversal.Parameters["@FrightUnit"].Value = _dbTaxInvoice.FrightUnit;
                    cmdUniversal.Parameters["@FrightAmount"].Value = _dbTaxInvoice.FrightAmount;
                    cmdUniversal.Parameters["@PackingRate"].Value = _dbTaxInvoice.PackingRate;
                    cmdUniversal.Parameters["@PackingUnit"].Value = _dbTaxInvoice.PackingUnit;
                    cmdUniversal.Parameters["@PackingAmount"].Value = _dbTaxInvoice.PackingAmount;

                    cmdUniversal.Parameters["@MAXCGSTRATE"].Value = _dbTaxInvoice.MAXCGSTRATE;
                    cmdUniversal.Parameters["@MAXSGSTRATE"].Value = _dbTaxInvoice.MAXSGSTRATE;
                    cmdUniversal.Parameters["@MAXIGSTRATE"].Value = _dbTaxInvoice.MAXIGSTRATE;
                    cmdUniversal.Parameters["@MAXCGSTAMT"].Value = _dbTaxInvoice.MAXCGSTAMT;
                    cmdUniversal.Parameters["@MAXSGSTAMT"].Value = _dbTaxInvoice.MAXSGSTAMT;
                    cmdUniversal.Parameters["@MAXIGSTAMT"].Value = _dbTaxInvoice.MAXIGSTAMT;

                    cmdUniversal.Parameters["@VehicleNo"].Value = _dbTaxInvoice.VehicleNo;
                    cmdUniversal.Parameters["@GSTReverseChargeYesORNO"].Value = _dbTaxInvoice.GSTReverseChargeYesORNO;
                    cmdUniversal.Parameters["@GSTReverseCharge"].Value = _dbTaxInvoice.GSTReverseCharge;
                    cmdUniversal.Parameters["@bankaccount"].Value = _dbTaxInvoice.bankaccount;
                    cmdUniversal.Parameters["@bankIFSC"].Value = _dbTaxInvoice.bankIFSC;
                    cmdUniversal.Parameters["@PaymentTerm"].Value = _dbTaxInvoice.PaymentTerm;
                    cmdUniversal.Parameters["@POClose"].Value = "2";

                    cmdUniversal.ExecuteNonQuery();                 
                    for (int i = 0; i < _dbTaxInvoice.ArrayList.GetLength(0); i++)
                    {
                        cmdUniversal = new SqlCommand("SaveStockMaster", cnUniversal, trans);
                        cmdUniversal.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(cmdUniversal);
                        cmdUniversal.Parameters["@ItemCode"].Value = _dbTaxInvoice.ArrayList[i, 0];
                        cmdUniversal.Parameters["@Branch"].Value = _dbTaxInvoice.Branch;
                        cmdUniversal.Parameters["@InQty"].Value =  Convert.ToDecimal(_dbTaxInvoice.ArrayList[i, 3]);
                        cmdUniversal.Parameters["@OutQty"].Value = Convert.ToDecimal(0);
                        cmdUniversal.Parameters["@TransactionDate"].Value = Convert.ToDateTime(_dbTaxInvoice.InvoiceDate);
                        cmdUniversal.Parameters["@Username"].Value = Convert.ToString(_dbTaxInvoice.UserName);
                        cmdUniversal.Parameters["@InvoiceNo"].Value = _dbTaxInvoice.InvoiceNO;
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

        public DataTable GetItemStock(string CmpCode, string ItemName, string Branch, int flag)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetItemStock";
                cmdUniversal.Parameters.Add("@CmpCode", SqlDbType.VarChar).Value = CmpCode;
                cmdUniversal.Parameters.Add("@ItemName", SqlDbType.VarChar).Value = ItemName;
                cmdUniversal.Parameters.Add("@Branch", SqlDbType.VarChar).Value = Branch;
                cmdUniversal.Parameters.Add("@Flag", SqlDbType.VarChar).Value = flag;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }
    }
}
