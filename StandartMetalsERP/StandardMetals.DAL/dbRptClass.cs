using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace StandardMetals.DAL
{
   public class dbRptClass:ConncetionClass
   {
       DataTable dt;
       public DataTable CustDetails()
       {
           this.Initialize();
           int nRecAffected = 0;
           dt = new DataTable();
           using (cnUniversal)
           {
               cmdUniversal.CommandText = "RptCustomerDetails";
              
               this.daUniversal.SelectCommand = cmdUniversal;
               this.cnUniversal.Open();
               nRecAffected = this.daUniversal.Fill(dt);
               this.Close();
               return dt;
           }
       }

       public DataTable SupplierDetails()
       {
           this.Initialize();
           int nRecAffected = 0;
           dt = new DataTable();
           using (cnUniversal)
           {
               cmdUniversal.CommandText = "RptSupplierList";
              
               this.daUniversal.SelectCommand = cmdUniversal;
               this.cnUniversal.Open();
               nRecAffected = this.daUniversal.Fill(dt);
               this.Close();
               return dt;
           }
       }

       public DataTable ItemDetails()
       {
           this.Initialize();
           int nRecAffected = 0;
           dt = new DataTable();
           using (cnUniversal)
           {
               cmdUniversal.CommandText = "RptItemDetails";

               this.daUniversal.SelectCommand = cmdUniversal;
               this.cnUniversal.Open();
               nRecAffected = this.daUniversal.Fill(dt);
               this.Close();
               return dt;
           }
       }
       public DataTable TaxInvoiceDetails(string TaxInvoiceNo)
       {
           this.Initialize();
           int nRecAffected = 0;
           dt = new DataTable();
           using (cnUniversal)
           {
               cmdUniversal.CommandText = "rptInvoiceDetails";
               cmdUniversal.Parameters.Add("@TaxinvoiceNo", SqlDbType.VarChar).Value = TaxInvoiceNo;
               this.daUniversal.SelectCommand = cmdUniversal;
               this.cnUniversal.Open();
               nRecAffected = this.daUniversal.Fill(dt);
               this.Close();
               return dt;
           }
       }

       public DataTable SalesDetails(string fromdate, string todate)
       {
           this.Initialize();
           int nRecAffected = 0;
           dt = new DataTable();
           using (cnUniversal)
           {
               cmdUniversal.CommandText = "RptTotalSale";
               cmdUniversal.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromdate;
               cmdUniversal.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = todate;
               this.daUniversal.SelectCommand = cmdUniversal;
               this.cnUniversal.Open();
               nRecAffected = this.daUniversal.Fill(dt);
               this.Close();
               return dt;
           }
       }


       public DataTable ItemDetails(string fromdate, string todate)
       {
           this.Initialize();
           int nRecAffected = 0;
           dt = new DataTable();
           using (cnUniversal)
           {
               cmdUniversal.CommandText = "RptItemWise";
               cmdUniversal.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromdate;
               cmdUniversal.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = todate;
               this.daUniversal.SelectCommand = cmdUniversal;
               this.cnUniversal.Open();
               nRecAffected = this.daUniversal.Fill(dt);
               this.Close();
               return dt;
           }
       }

       public DataTable CustDetails(string fromdate, string todate)
       {
           this.Initialize();
           int nRecAffected = 0;
           dt = new DataTable();
           using (cnUniversal)
           {
               cmdUniversal.CommandText = "RptCustomerWise";
               cmdUniversal.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromdate;
               cmdUniversal.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = todate;
               this.daUniversal.SelectCommand = cmdUniversal;
               this.cnUniversal.Open();
               nRecAffected = this.daUniversal.Fill(dt);
               this.Close();
               return dt;
           }
       }

       public DataTable StockTransferDetails(string fromdate, string todate)
       {
           this.Initialize();
           int nRecAffected = 0;
           dt = new DataTable();
           using (cnUniversal)
           {
               cmdUniversal.CommandText = "RptStockTransfer";
               cmdUniversal.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromdate;
               cmdUniversal.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = todate;
               this.daUniversal.SelectCommand = cmdUniversal;
               this.cnUniversal.Open();
               nRecAffected = this.daUniversal.Fill(dt);
               this.Close();
               return dt;
           }
       }

       public DataTable RawmaterialStockDetails(string fromdate, string todate)
       {
           this.Initialize();
           int nRecAffected = 0;
           dt = new DataTable();
           using (cnUniversal)
           {
               cmdUniversal.CommandText = "RptRawMaterialStock";
               cmdUniversal.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromdate;
               cmdUniversal.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = todate;
               this.daUniversal.SelectCommand = cmdUniversal;
               this.cnUniversal.Open();
               nRecAffected = this.daUniversal.Fill(dt);
               this.Close();
               return dt;
           }
       }

       public DataTable ProductionDetails(string fromdate, string todate)
       {
           this.Initialize();
           int nRecAffected = 0;
           dt = new DataTable();
           using (cnUniversal)
           {
               cmdUniversal.CommandText = "RptProductionNote";
               cmdUniversal.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromdate;
               cmdUniversal.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = todate;
               this.daUniversal.SelectCommand = cmdUniversal;
               this.cnUniversal.Open();
               nRecAffected = this.daUniversal.Fill(dt);
               this.Close();
               return dt;
           }
       }

       public DataTable MaterialInwardDetails(string fromdate, string todate)
       {
           this.Initialize();
           int nRecAffected = 0;
           dt = new DataTable();
           using (cnUniversal)
           {
               cmdUniversal.CommandText = "RptMaterialInwardDetailsAndRptMaterialInwardStock";
               cmdUniversal.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromdate;
               cmdUniversal.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = todate;
               cmdUniversal.Parameters.Add("@Action", SqlDbType.Int).Value = 1;
               this.daUniversal.SelectCommand = cmdUniversal;
               this.cnUniversal.Open();
               nRecAffected = this.daUniversal.Fill(dt);
               this.Close();
               return dt;
           }
       }

       public DataTable RawMaterialInwardDetails(string fromdate, string todate)
       {
           this.Initialize();
           int nRecAffected = 0;
           dt = new DataTable();
           using (cnUniversal)
           {
               cmdUniversal.CommandText = "RptMaterialInwardDetailsAndRptMaterialInwardStock";
               cmdUniversal.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromdate;
               cmdUniversal.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = todate;
               cmdUniversal.Parameters.Add("@Action", SqlDbType.Int).Value = 2;
               this.daUniversal.SelectCommand = cmdUniversal;
               this.cnUniversal.Open();
               nRecAffected = this.daUniversal.Fill(dt);
               this.Close();
               return dt;
           }
       }
       public DataTable StockDetails()
       {
           this.Initialize();
           int nRecAffected = 0;
           dt = new DataTable();
           using (cnUniversal)
           {
               cmdUniversal.CommandText = "RptStock";
               //cmdUniversal.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromdate;
               //cmdUniversal.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = todate;
               this.daUniversal.SelectCommand = cmdUniversal;
               this.cnUniversal.Open();
               nRecAffected = this.daUniversal.Fill(dt);
               this.Close();
               return dt;
           }
       }
       public DataTable QuotationDetails(string QuotationNo)
       {
           this.Initialize();
           int nRecAffected = 0;
           dt = new DataTable();
           using (cnUniversal)
           {
               cmdUniversal.CommandText = "RptQuotation";
               cmdUniversal.Parameters.Add("@QuotationNo", SqlDbType.VarChar).Value = QuotationNo;
               //cmdUniversal.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = todate;
               this.daUniversal.SelectCommand = cmdUniversal;
               this.cnUniversal.Open();
               nRecAffected = this.daUniversal.Fill(dt);
               this.Close();
               return dt;
           }
       }

       public DataTable EstDetails(string EstNo)
       {
           this.Initialize();
           int nRecAffected = 0;
           dt = new DataTable();
           using (cnUniversal)
           {
               cmdUniversal.CommandText = "RptEstimate";
               cmdUniversal.Parameters.Add("@estno", SqlDbType.VarChar).Value = EstNo;
               //cmdUniversal.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = todate;
               this.daUniversal.SelectCommand = cmdUniversal;
               this.cnUniversal.Open();
               nRecAffected = this.daUniversal.Fill(dt);
               this.Close();
               return dt;
           }
       }
       public DataTable CompanyDetails()
       {
           this.Initialize();
           int nRecAffected = 0;
           dt = new DataTable();
           using (cnUniversal)
           {
               cmdUniversal.CommandText = "RptCompanyDetails";
               this.daUniversal.SelectCommand = cmdUniversal;
               this.cnUniversal.Open();
               nRecAffected = this.daUniversal.Fill(dt);
               this.Close();
               return dt;
           }
       }
    }
}
