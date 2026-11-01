// 20/08/2026

using StandardMetals.DAL;
using StandardMetals.MODEL;
using StandardMetals.CommonLibrary;
using System.Collections.Generic;
using System.Data;

namespace StandardMetals.BAL
{
    public class CustomerMasterMVCApril2026BAL
    {
        CustomerMasterMVCApril2026DAL dal = CustomerMasterMVCApril2026DAL.GetInstance();

        // Customer List

        public List<CustomerMasterMVCApril2026Model> GetAllCustomerMaster()
        {
            LogInfo.LogDetailToFile("CustomerMasterApril2026BAL-GetAllCustomerMaster - Start");

            List<CustomerMasterMVCApril2026Model> result = dal.GetAllCustomerMaster();

            LogInfo.LogDetailToFile("GetAllCustomerMaster - Customer List Loaded");
            LogInfo.LogDetailToFile("CustomerMasterApril2026BAL-GetAllCustomerMaster - Start-End");

            return result;
        }

        // Customer By Id

        public CustomerMasterMVCApril2026Model GetCustomerMasterById(int id)
        {
            LogInfo.LogDetailToFile("CustomerMasterApril2026BAL-GetCustomerMasterById - Start");
            LogInfo.LogDetailToFile("GetCustomerMasterById - Customer Id : " + id);

            CustomerMasterMVCApril2026Model result = dal.GetCustomerMasterById(id);

            LogInfo.LogDetailToFile("GetCustomerMasterById - Customer Details Loaded");
            LogInfo.LogDetailToFile("CustomerMasterApril2026BAL-GetCustomerMasterById - Start-End");

            return result;
        }

        // Get Customer Details By Id for Item-Customer Mapping
        // Reusing existing Customer By Id DAL method

        public CustomerMasterMVCApril2026Model GetCustomerDetailsById(int customerId)
        {
            LogInfo.LogDetailToFile("CustomerMasterApril2026BAL-GetCustomerDetailsById - Start");
            LogInfo.LogDetailToFile("GetCustomerDetailsById - Customer Id : " + customerId);

            CustomerMasterMVCApril2026Model result = dal.GetCustomerMasterById(customerId);

            LogInfo.LogDetailToFile("GetCustomerDetailsById - Customer Details Loaded");
            LogInfo.LogDetailToFile("CustomerMasterApril2026BAL-GetCustomerDetailsById - Start-End");

            return result;
        }

        // Get Customer Details By Code for Item-Customer Mapping

        public CustomerMasterMVCApril2026Model GetCustomerDetailsByCode(string custCode)
        {
            LogInfo.LogDetailToFile("CustomerMasterApril2026BAL-GetCustomerDetailsByCode - Start");
            LogInfo.LogDetailToFile("GetCustomerDetailsByCode - Customer Code : " + custCode);

            CustomerMasterMVCApril2026Model result = dal.GetCustomerDetailsByCode(custCode);

            LogInfo.LogDetailToFile("GetCustomerDetailsByCode - Customer Details Loaded");
            LogInfo.LogDetailToFile("CustomerMasterApril2026BAL-GetCustomerDetailsByCode - Start-End");

            return result;
        }


        // Save Customer

        public string SaveCustomerMaster(CustomerMasterMVCApril2026Model model)
        {
            LogInfo.LogDetailToFile("CustomerMasterApril2026BAL-SaveCustomerMaster - Start");

            string result = dal.SaveCustomerMaster(model);

            LogInfo.LogDetailToFile("SaveCustomerMaster - Customer Save Completed : " + result);
            LogInfo.LogDetailToFile("CustomerMasterApril2026BAL-SaveCustomerMaster - Start-End");

            return result;
        }


        // Update Customer

        public int UpdateCustomerMaster(CustomerMasterMVCApril2026Model model)
        {
            LogInfo.LogDetailToFile("CustomerMasterApril2026BAL-UpdateCustomerMaster - Start");

            int result = dal.UpdateCustomerMaster(model);

            LogInfo.LogDetailToFile("UpdateCustomerMaster - Update Result : " + result);
            LogInfo.LogDetailToFile("CustomerMasterApril2026BAL-UpdateCustomerMaster - Start-End");

            return result;
        }

        // Delete Customer

        public int DeleteCustomerMasterById(int id)
        {
            LogInfo.LogDetailToFile("CustomerMasterApril2026BAL-DeleteCustomerMasterById - Start");
            LogInfo.LogDetailToFile("DeleteCustomerMasterById - Customer Id : " + id);

            int result = dal.DeleteCustomerMasterById(id);

            LogInfo.LogDetailToFile("DeleteCustomerMasterById - Delete Result : " + result);
            LogInfo.LogDetailToFile("CustomerMasterApril2026BAL-DeleteCustomerMasterById - Start-End");

            return result;
        }

        // Bind Customer

        public DataTable BindCustomer()
        {
            LogInfo.LogDetailToFile("CustomerMasterApril2026BAL-BindCustomer - Start");

            DataTable result = dal.BindCustomer();

            LogInfo.LogDetailToFile("BindCustomer - Customer Data Loaded");
            LogInfo.LogDetailToFile("CustomerMasterApril2026BAL-BindCustomer - Start-End");

            return result;
        }

        // Bind Branch

        public DataTable BindBranch()
        {
            LogInfo.LogDetailToFile("CustomerMasterApril2026BAL-BindBranch - Start");

            DataTable result = dal.BindBranch();

            LogInfo.LogDetailToFile("BindBranch - Branch Data Loaded");
            LogInfo.LogDetailToFile("CustomerMasterApril2026BAL-BindBranch - Start-End");

            return result;
        }

        // Bind Country

        public DataTable BindCountry()
        {
            LogInfo.LogDetailToFile("CustomerMasterApril2026BAL-BindCountry - Start");

            DataTable result = dal.BindCountry();

            LogInfo.LogDetailToFile("BindCountry - Country Data Loaded");
            LogInfo.LogDetailToFile("CustomerMasterApril2026BAL-BindCountry - Start-End");

            return result;
        }

        // Bind State

        public DataTable BindState(int countryId)
        {
            LogInfo.LogDetailToFile("CustomerMasterApril2026BAL-BindState - Start");
            LogInfo.LogDetailToFile("BindState - Country Id : " + countryId);

            DataTable result = dal.BindState(countryId);

            LogInfo.LogDetailToFile("BindState - State Data Loaded");
            LogInfo.LogDetailToFile("CustomerMasterApril2026BAL-BindState - Start-End");

            return result;
        }

        // Bind City

        public DataTable BindCity(int stateId)
        {
            LogInfo.LogDetailToFile("CustomerMasterApril2026BAL-BindCity - Start");
            LogInfo.LogDetailToFile("BindCity - State Id : " + stateId);

            DataTable result = dal.BindCity(stateId);

            LogInfo.LogDetailToFile("BindCity - City Data Loaded");
            LogInfo.LogDetailToFile("CustomerMasterApril2026BAL-BindCity - Start-End");

            return result;
        }
    }
}