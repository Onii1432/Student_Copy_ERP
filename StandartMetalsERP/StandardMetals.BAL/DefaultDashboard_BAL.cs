using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StandardMetals.DAL;
using StandardMetals.MODEL;
using StandardMetals.CommonLibrary;

namespace StandardMetals.BAL
{
    public class DefaultDashboard_BAL
    {
        DefaultDashboard_DAL dashboardDAL = new DefaultDashboard_DAL();

        public DefaultDashboardModel GetSupplierWiseItemDashboard()
        {
            LogInfo.LogDetailToFile("DefaultDashboardBAL-GetSupplierWiseItemDashboard - Start");

            DefaultDashboardModel result = dashboardDAL.GetSupplierWiseItemDashboard();

            LogInfo.LogDetailToFile("GetSupplierWiseItemDashboard - Dashboard Data Loaded");
            LogInfo.LogDetailToFile("DefaultDashboardBAL-GetSupplierWiseItemDashboard - Start-End");

            return result;
        }
    }
}