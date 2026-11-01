using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Modal;
using System.Data;

namespace StandardMetals.BAL
{
    public class EnquiryMasterBal
    {
        EnquiryMasterDal enqDal = new EnquiryMasterDal();

        public DataTable BindProductCategory()
        {
            return enqDal.BindProductCategory();
        }

        public DataTable BindDeliveryType()
        {
            return enqDal.BindDeliveryType();
        }

        public DataTable BindMedOfEnq()
        {
            return enqDal.BindMedOfEnq();
        }

        public int InsertEnquiryMaster(EnquiryMasterModel model, out string EnquiryNumber)
        {
            return enqDal.InsertEnquiryMaster(model, out EnquiryNumber);
        }

        public int UpdateEnquiryMaster(EnquiryMasterModel model)
        {
            return enqDal.UpdateEnquiryMaster(model);
        }

        public DataTable FillEnquiryMaster(int EnquiryId)
        {
            return enqDal.FillEnquiryMaster(EnquiryId);
        }

        public DataTable BindCustomer()
        {
            return enqDal.BindCustomer();
        }

        public DataTable BindEnquiryNumber(EnquiryMasterModel model)
        {
            return enqDal.BindEnquiryNumber(model);
        }

        public DataTable BindCustDtls(string CustCode)
        {
            return enqDal.BindCustDtls(CustCode);
        }

        //public DataTable BindCustItemData()
        //{
        //    return enqDal.BindCustItemData();
        //}

        public DataTable BindItemsDataDtls(string ItemCode)
        {
            return enqDal.BindItemsDataDtls(ItemCode);
        }
        public DataTable GetAutoGenEnqNumber(EnquiryMasterModel model)
        {
            return enqDal.GetAutoGenEnqNumber(model);
        }
        public List<EnquiryMasterModel> GetAllEnquiryData()
        {
            return enqDal.GetAllEnquiryData();
        }
    }
}
