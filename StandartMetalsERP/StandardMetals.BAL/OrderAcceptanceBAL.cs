using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modal;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace StandardMetals.BAL
{
    public class OrderAcceptanceBAL
    {
        OrderAcceptanceDAL oad = new OrderAcceptanceDAL();


        public DataTable BindCustomerName()
        {
            return oad.BindCustomerName();

        }



        public DataTable BindOrderAcceptanceNumber()
        {
            return oad.BindOrderAcceptanceNumber();

        }



        public DataTable BindSalesExecutive()
        {
            return oad.BindSalesExecutive();

        }



        public DataTable BindPaymentTpye()
        {
            return oad.BindPaymentTpye();

        }



        public DataTable BindDatatoGrid()
        {
            return oad.BindDatatoGrid();

        }



        public DataTable BindCustName_CustPONO()
        {
            return oad.BindCustName_CustPONO();

        }



        public DataTable FillOrderAcceptanceData(string OrderAcceptanceNO)
        {
            return oad.FillOrderAcceptanceData(OrderAcceptanceNO);

        }



        public DataTable GetAllDataVsCustPONO(string CustomerPONo)
        {
            return oad.GetAllDataVsCustPONO(CustomerPONo);

        }






        public int InsertCustomerPO(OrderAcceptanceMODEL oam)
        {
            return oad.InsertCustomerPO(oam);

        }



        public int UpdateOrderAcceptanceMaster(OrderAcceptanceMODEL oam)
        {
            return oad.UpdateOrderAcceptanceMaster(oam);

        }



    }
}
