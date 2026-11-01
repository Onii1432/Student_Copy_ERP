using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using Modal;


namespace StandardMetals.BAL
{
    public class DefaultBussiness
    {
        DefaultData DD = new DefaultData();

        public DataTable BindChartCust(DefaultModal DM)
        {
            return DD.BindChartCust(DM);
        }

        public DataTable BindChartSupp(DefaultModal DM)
        {
            return DD.BindChartSupp(DM);
        }

        //BindChartItem
        public DataTable BindChartItem(DefaultModal DM)
        {
            return DD.BindChartItem(DM);
        }






    }
}
