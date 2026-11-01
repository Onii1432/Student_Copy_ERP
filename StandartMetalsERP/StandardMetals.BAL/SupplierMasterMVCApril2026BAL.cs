// 27/08/2026

using StandardMetals.DAL;
using StandardMetals.MODEL;
using StandardMetals.CommonLibrary;
using System.Collections.Generic;
using System.Data;

namespace StandardMetals.BAL
{
    public class SupplierMasterMVCApril2026BAL
    {
        SupplierMasterMVCApril2026DAL dal = SupplierMasterMVCApril2026DAL.GetInstance();

        // Get All Supplier Master
        public List<SupplierMasterMVCApril2026Model> GetAllSupplierMaster()
        {
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-GetAllSupplierMaster - Start");

            List<SupplierMasterMVCApril2026Model> result = dal.GetAllSupplierMaster();

            LogInfo.LogDetailToFile("GetAllSupplierMaster - Supplier List Loaded");
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-GetAllSupplierMaster - Start-End");

            return result;
        }

        // Bind Supplier Code
        public DataTable BindSupplierCode()
        {
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-BindSupplierCode - Start");

            DataTable result = dal.BindSupplierCode();

            LogInfo.LogDetailToFile("BindSupplierCode - Supplier Code Data Loaded");
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-BindSupplierCode - Start-End");

            return result;
        }

        // Bind Supplier Name
        public DataTable BindSupplierName()
        {
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-BindSupplierName - Start");

            DataTable result = dal.BindSupplierName();

            LogInfo.LogDetailToFile("BindSupplierName - Supplier Name Data Loaded");
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-BindSupplierName - Start-End");

            return result;
        }

        // Get Supplier Master By Id
        public SupplierMasterMVCApril2026Model GetSupplierMasterById(int id)
        {
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-GetSupplierMasterById - Start");
            LogInfo.LogDetailToFile("GetSupplierMasterById - Supplier Id : " + id);

            SupplierMasterMVCApril2026Model result = dal.GetSupplierMasterById(id);

            LogInfo.LogDetailToFile("GetSupplierMasterById - Supplier Details Loaded");
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-GetSupplierMasterById - Start-End");

            return result;
        }

        // Get Supplier Details By Id For Item Supplier Mapping
        public SupplierMasterMVCApril2026Model GetSupplierDetailsById(int supplierId)
        {
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-GetSupplierDetailsById - Start");
            LogInfo.LogDetailToFile("GetSupplierDetailsById - Supplier Id : " + supplierId);

            SupplierMasterMVCApril2026Model result = dal.GetSupplierDetailsById(supplierId);

            LogInfo.LogDetailToFile("GetSupplierDetailsById - Supplier Details Loaded");
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-GetSupplierDetailsById - Start-End");

            return result;
        }

        // Get Supplier Details By Code
        public SupplierMasterMVCApril2026Model GetSupplierDetailsByCode(string suppCode)
        {
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-GetSupplierDetailsByCode - Start");
            LogInfo.LogDetailToFile("GetSupplierDetailsByCode - Supplier Code : " + suppCode);

            SupplierMasterMVCApril2026Model result = dal.GetSupplierDetailsByCode(suppCode);

            LogInfo.LogDetailToFile("GetSupplierDetailsByCode - Supplier Details Loaded");
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-GetSupplierDetailsByCode - Start-End");

            return result;
        }

        // Save Supplier Master
        public string SaveSupplierMaster(SupplierMasterMVCApril2026Model model)
        {
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-SaveSupplierMaster - Start");

            string result = dal.SaveSupplierMaster(model);

            LogInfo.LogDetailToFile("SaveSupplierMaster - Supplier Save Completed : " + result);
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-SaveSupplierMaster - Start-End");

            return result;
        }

        // Update Supplier Master
        public int UpdateSupplierMaster(SupplierMasterMVCApril2026Model model)
        {
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-UpdateSupplierMaster - Start");

            int result = dal.UpdateSupplierMaster(model);

            LogInfo.LogDetailToFile("UpdateSupplierMaster - Update Result : " + result);
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-UpdateSupplierMaster - Start-End");

            return result;
        }

        // Delete Supplier Master
        public int DeleteSupplierMaster(int id)
        {
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-DeleteSupplierMaster - Start");
            LogInfo.LogDetailToFile("DeleteSupplierMaster - Supplier Id : " + id);

            int result = dal.DeleteSupplierMasterById(id);

            LogInfo.LogDetailToFile("DeleteSupplierMaster - Delete Result : " + result);
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-DeleteSupplierMaster - Start-End");

            return result;
        }

        // Delete Supplier Master By Id
        public int DeleteSupplierMasterById(int id)
        {
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-DeleteSupplierMasterById - Start");
            LogInfo.LogDetailToFile("DeleteSupplierMasterById - Supplier Id : " + id);

            int result = dal.DeleteSupplierMasterById(id);

            LogInfo.LogDetailToFile("DeleteSupplierMasterById - Delete Result : " + result);
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-DeleteSupplierMasterById - Start-End");

            return result;
        }

        // Bind Branch
        public DataTable BindBranch()
        {
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-BindBranch - Start");

            DataTable result = dal.BindBranch();

            LogInfo.LogDetailToFile("BindBranch - Branch Data Loaded");
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-BindBranch - Start-End");

            return result;
        }

        // Bind Country
        public DataTable BindCountry()
        {
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-BindCountry - Start");

            DataTable result = dal.BindCountry();

            LogInfo.LogDetailToFile("BindCountry - Country Data Loaded");
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-BindCountry - Start-End");

            return result;
        }

        // Bind State By Country
        public DataTable BindState(int countryId)
        {
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-BindState - Start");
            LogInfo.LogDetailToFile("BindState - Country Id : " + countryId);

            DataTable result = dal.BindState(countryId);

            LogInfo.LogDetailToFile("BindState - State Data Loaded");
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-BindState - Start-End");

            return result;
        }

        // Bind City By State
        public DataTable BindCity(int stateId)
        {
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-BindCity - Start");
            LogInfo.LogDetailToFile("BindCity - State Id : " + stateId);

            DataTable result = dal.BindCity(stateId);

            LogInfo.LogDetailToFile("BindCity - City Data Loaded");
            LogInfo.LogDetailToFile("SupplierMasterApril2026BAL-BindCity - Start-End");

            return result;
        }
    }
}