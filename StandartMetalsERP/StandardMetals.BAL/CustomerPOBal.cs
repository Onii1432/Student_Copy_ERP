using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using DAL;
//using Modal;
using System.Data;


namespace StandardMetals.BAL
{
    public class CustomerPOBal
    {
        CustomerPODal CustPoDal = new CustomerPODal();

        public int InsertCustomerPO(CustomerPOModel custPoModel)
        {
            return CustPoDal.InsertCustomerPO(custPoModel);
        }

        public int UpdateCustomerPO(CustomerPOModel custPoModel)
        {
            return CustPoDal.UpdateCustomerPO(custPoModel);
        }

        public DataTable BindCustomerPO(CustomerPOModel model)
        {
            return CustPoDal.BindCustomerPO(model);
        }

        public DataTable FillCustomerPO(int CustomerPOID)
        {
            return CustPoDal.FillCustomerPO(CustomerPOID);
        }

        //public DataTable BIndCustomerDetails(string CustomerCode)
        //{
        //    return CustPoDal.BIndCustomerDetails(CustomerCode);
        //}

        public DataTable BindItemInfo(string ItemCode)
        {
            return CustPoDal.BindItemInfo(ItemCode);
        }

        public DataTable BindShimentAccount(CustomerPOModel model)
        {
            return CustPoDal.BindShimentAccount(model);
        }

        public DataTable BindQuotattionNum(CustomerPOModel model)
        {
            return CustPoDal.BindQuotattionNum(model);
        }

        public DataTable BindConsigneeName(CustomerPOModel model)
        {
            return CustPoDal.BindConsigneeName(model);
        }

        public DataTable BindModeOfTrasport(CustomerPOModel model)
        {
            return CustPoDal.BindModeOfTrasport(model);
        }

        //Bind All data to Grid
        public List<CustomerPOModel> GetAllData(CustomerPOModel model)
        {
            return CustPoDal.GetAllData(model);
        }
    }
}
