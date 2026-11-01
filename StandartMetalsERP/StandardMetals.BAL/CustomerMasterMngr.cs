using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using Modal;


namespace StandardMetals.BAL
{
   
    public class CustomerMasterMngr
    {
        dbcustomermaster objdbcustomermaster = new dbcustomermaster();
        dbcustomermaster CustData = new dbcustomermaster();
        //BindCustomer
        public DataTable BindCustomer(CustomerMasterModel CustModel)
        {

            return CustData.BindCustomer(CustModel);
        }

        public DataTable FillCustomer(CustomerMasterModel CustModel)
        {

            return CustData.FillCustomer(CustModel);
        }

        public int InsertCustomerMaster(CustomerMasterModel CustModel)
        {
            return CustData.InsertCustomerMaster(CustModel);
        }

        //UpdateCustomer
        public int UpdateCustomer(CustomerMasterModel CustModel)
        {
            return CustData.UpdateCustomer(CustModel);
        }
    }
}
