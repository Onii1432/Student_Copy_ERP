using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;


namespace StandardMetals.BAL
{
    public class EstimateMnger
    {
        dbEstimate objEst = new dbEstimate();

        public DataTable FillEstimate_No()
        {
            return objEst.FillEstimate_No();
        }

        

        public string CreateUIN()
        {

            DataTable dt = new DataTable();

            string Years = Convert.ToString(DateTime.Now.Year);
            dt = GetMaxEstimateN();
            string Pono = "";
            int cnt = 0;
            if (dt.Rows.Count > 0 && dt.Rows[0].IsNull("ESTNo") == false)
            {
                Pono = Convert.ToString(dt.Rows[0][0]);
                Pono = Pono.Substring(9, 5).ToString();
                Pono = (Convert.ToDecimal(Pono) + 1).ToString();
                Pono = Pono.PadLeft(5, '0');

                Pono = "ESN/" + Years + "/" + Pono;
            }
            else
            {
                Pono = "ESN/" + Years + "/" + "00001";
            }
            return Pono;
        }

        //public DataTable GetMaxMatInvoiceNo()
        //{
        //    return objEst.GetMaxMatInvoiceNo();
        //}
        public DataTable GetMaxEstimateN()
        {
            return objEst.GetMaxEstimateN();
        }

        public DataTable RetriveEstimate(string EstNo)
        {
            return objEst.RetriveEstimate(EstNo);
        }
        public int SaveEstmate(dbEstimate objestimate)
        {
            return objEst.SaveEstmate(objestimate);
        }

        public int UpdateEstimate(dbEstimate objestimate)
        {
            return objEst.UpdateEstimateMaster(objestimate);
        }
        //public DataTable RetriveData(string MaterialInvoiceNo)
        //{
        //    return objEst.RetriveData(MaterialInvoiceNo);
        //}

        //public DataTable RetriveMAterialInwardDetails(string EstimateNo)
        //{
        //    return objEst.RetriveMAterialInwardDetails(EstimateNo);
        //}
    }
}
