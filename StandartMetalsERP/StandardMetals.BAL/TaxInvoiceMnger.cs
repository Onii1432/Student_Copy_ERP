using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StandardMetals.MODEL;
using StandardMetals.DAL;

namespace StandardMetals.BAL
{
    public class TaxInvoiceMnger 
    {
        dbTaxInvoice _dbTaxInvoice = new dbTaxInvoice();

        //public DataTable GetTaxInvoiceDetails(string InvoiceNO)
        //{
        //    return _dbTaxInvoice.GetTaxInvoiceDetails(InvoiceNO);
        //}

        public string CreateTaxInvoiceNo()
        {

            DataTable dt = new DataTable();

            string Years = Convert.ToString(DateTime.Now.Year) ;
            

            dt = GetMaxTaxInvoiceNo();           
            string Pono = "";
            int cnt = 0;
            if (dt.Rows.Count > 0 && dt.Rows[0].IsNull("InvoiceNO") == false)
            {
                Pono = Convert.ToString(dt.Rows[0][0]);
                Pono = Pono.Substring(9, 5).ToString();
                Pono = (Convert.ToDecimal(Pono) + 1).ToString();
                Pono = Pono.PadLeft(5, '0');

                Pono = "INV/"+  Years + "/" + Pono;
            }
            else
            {
                Pono = "INV/"  + Years + "/" + "00001";
            }
            return Pono;
        }

        public DataTable GetMaxTaxInvoiceNo()
        {
            return _dbTaxInvoice.GetMaxTaxInvoiceNo();
        }

        public int SaveTaxInvoiceMaster(dbTaxInvoice _dbTaxInvoice)
        {
            return _dbTaxInvoice.SaveTaxInvoiceMaster(_dbTaxInvoice);
        }

        public int UpdateTaxInvoiceMaster(dbTaxInvoice _dbTaxInvoice)
        {
            return _dbTaxInvoice.UpdateTaxInvoiceMaster(_dbTaxInvoice);
        }
        public List<ItemMasterModel> GetAllItemMasterData()
        {
            return _dbTaxInvoice.GetAllItemMasterData();

        }


        public List<ItemMasterModel> FillItemMaster()
        {
            return _dbTaxInvoice.FillItemMaster();
        }

        public DataTable GetItemStock(string cmpcode,string ItemCode,string branch,int flag)
        {
            return _dbTaxInvoice.GetItemStock(cmpcode,ItemCode,branch,flag);
        }
        public int InvoiceCancle(dbTaxInvoice _dbTaxInvoice)
        {
            return _dbTaxInvoice.UpdateInnvoiceCancle(_dbTaxInvoice);
        }

    }
}
