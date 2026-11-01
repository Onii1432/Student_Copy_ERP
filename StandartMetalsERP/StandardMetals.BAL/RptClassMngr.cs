using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
namespace StandardMetals.BAL
{
   public class RptClassMngr
    {
       dbRptClass dbRptClass = new dbRptClass();
       public DataTable CustDetails()
       {
           return dbRptClass.CustDetails();
       }
       public DataTable SupplierDetails()
       {
           return dbRptClass.SupplierDetails();
       }

       public DataTable ItemDetails()
       {
           return dbRptClass.ItemDetails();
       }
       public DataTable TaxInvoiceDetails(string TaxInvoiceNo)
       {
           return dbRptClass.TaxInvoiceDetails(TaxInvoiceNo);
       }
       public DataTable CompanyDetails()
       {
           return dbRptClass.CompanyDetails();
       }
       public DataTable SalesDetails(string fromdate,string todate)
       {
           return dbRptClass.SalesDetails(fromdate,todate);
       }
       public DataTable ItemDetails(string fromdate, string todate)
       {
           return dbRptClass.ItemDetails(fromdate, todate);
       }
       public DataTable CustDetails(string fromdate, string todate)
       {
           return dbRptClass.CustDetails(fromdate, todate);
       }
       public DataTable StockDetails()
       {
           return dbRptClass.StockDetails();
       }
       public DataTable StockTransferDetails(string fromdate, string todate)
       {
           return dbRptClass.StockTransferDetails(fromdate, todate);
       }
       public DataTable RawmaterialStockDetails(string fromdate, string todate)
       {
           return dbRptClass.RawmaterialStockDetails(fromdate, todate);
       }

       public DataTable ProductionDetails(string fromdate, string todate)
       {
           return dbRptClass.ProductionDetails(fromdate, todate);
       }
       public DataTable MaterialInwardDetails(string fromdate, string todate)
       {
           return dbRptClass.MaterialInwardDetails(fromdate, todate);
       }
       public DataTable RawMaterialInwardDetails(string fromdate, string todate)
       {
           return dbRptClass.RawMaterialInwardDetails(fromdate, todate);
       }


       public DataTable QuotationDetails(string Quotation)
       {
           return dbRptClass.QuotationDetails(Quotation);
       }
       public DataTable EstDetails(string EstNo)
       {
           return dbRptClass.EstDetails(EstNo);
       }
    }

}
