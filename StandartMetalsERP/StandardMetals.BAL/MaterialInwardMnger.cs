using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace StandardMetals.BAL
{
    public class MaterialInwardMnger
    {
        dbMaterialInward _dbMaterialInward = new dbMaterialInward();

        public DataTable FillItemMaster()
        {
            return _dbMaterialInward.FillItemMaster();
        }

        public DataTable FillRawMaterial(string cmpCode, string itemcode, int flag)
        {
            return _dbMaterialInward.FillRawMaterial(cmpCode,itemcode,flag);
        }

        public DataTable FillUIN_No()
        {
            return _dbMaterialInward.FillUIN_No();
        }
      
        public DataTable RetriveSuppDetails(string SuppCode,int flag)
        {
            return _dbMaterialInward.RetriveSuppDetails(SuppCode, flag);
        }

        public string CreateMaterialInvoiceNo()
        {

            DataTable dt = new DataTable();

            string Years = Convert.ToString(DateTime.Now.Year);            
            dt = GetMaxMatInvoiceNo();
            string Pono = "";
            int cnt = 0;
            if (dt.Rows.Count > 0 && dt.Rows[0].IsNull("InvoiceNO") == false)
            {
                Pono = Convert.ToString(dt.Rows[0][0]);
                Pono = Pono.Substring(9, 5).ToString();
                Pono = (Convert.ToDecimal(Pono) + 1).ToString();
                Pono = Pono.PadLeft(5, '0');

                Pono = "MIN/" + Years + "/" + Pono;
            }
            else
            {
                Pono = "MIN/" + Years + "/" + "00001";
            }
            return Pono;
        }

        public string CreateUIN()
        {

            DataTable dt = new DataTable();

            string Years = Convert.ToString(DateTime.Now.Year);
            dt = GetMaxUIN();
            string Pono = "";
            //int cnt = 0;
            if (dt.Rows.Count > 0 && dt.Rows[0].IsNull("InvoiceNO") == false)
            {
                Pono = Convert.ToString(dt.Rows[0][0]);
                Pono = Pono.Substring(9, 5).ToString();
                Pono = (Convert.ToDecimal(Pono) + 1).ToString();
                Pono = Pono.PadLeft(5, '0');

                Pono = "UIN/" + Years + "/" + Pono;
            }
            else
            {
                Pono = "UIN/" + Years + "/" + "00001";
            }
            return Pono;
        }
        public string CreateEstimateNo()
        {

            DataTable dt = new DataTable();

            string Years = Convert.ToString(DateTime.Now.Year);
            dt = GetMaxEN();
            string Pono = "";
            int cnt = 0;
            if (dt.Rows.Count > 0 && dt.Rows[0].IsNull("InvoiceNO") == false)
            {
                Pono = Convert.ToString(dt.Rows[0][0]);
                Pono = Pono.Substring(8, 5).ToString();
                Pono = (Convert.ToDecimal(Pono) + 1).ToString();
                Pono = Pono.PadLeft(5, '0');

                Pono = "EN/" + Years + "/" + Pono;
            }
            else
            {
                Pono = "EN/" + Years + "/" + "00001";
            }
            return Pono;
        }
        public DataTable GetMaxEN()
        {
            return _dbMaterialInward.GetMaxUIN();
        }
        public DataTable GetMaxMatInvoiceNo()
        {
            return _dbMaterialInward.GetMaxMatInvoiceNo();
        }
        public DataTable GetMaxUIN()
        {
            return _dbMaterialInward.GetMaxUIN();
        }
        public int SaveMaterialInvoiceMaster(dbMaterialInward _MaterialInward)
        {
            return _dbMaterialInward.SaveTaxInvoiceMaster(_MaterialInward);
        }

        public int UpdateMaterialInvoiceMaster(dbMaterialInward _MaterialInward)
        {            
            return _dbMaterialInward.UpdateMaterialInvoiceMaster(_MaterialInward);
        }
        public DataTable RetriveData(string MaterialInvoiceNo)
        {
            return _dbMaterialInward.RetriveData(MaterialInvoiceNo);
        }

        public DataTable RetriveMAterialInwardDetails(string MaterialInvoiceNo)
        {
            return _dbMaterialInward.RetriveMAterialInwardDetails(MaterialInvoiceNo);
        }


    }
}
