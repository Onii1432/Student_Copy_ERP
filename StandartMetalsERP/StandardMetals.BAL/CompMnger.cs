using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using StandardMetals.DAL;
using StandardMetals.MODEL;
namespace StandardMetals.BAL
{
    public class CompMnger 
    {
        dbCompanyMaster CompData = new dbCompanyMaster();


        

        public DataTable BindCountry(int countryId)
        {
           return CompData.BindCountry(countryId);
        }
        public DataTable BindCity(int stateID)
        {
            return CompData.BindCity(stateID);
        }

        public List<CompanyMasterModel> FillCompanyMasterByList()
        {
            return CompData.FillCompanyMasterByList();
        }

        public DataTable FillCompanyMaster(CompanyMasterModel companyModel)
        {
            return CompData.FillCompanyMaster(companyModel);
        }

        //UpdateCompany
        public int UpdateCompanyInfo(CompanyMasterModel CompModel)
        {
            return CompData.UpdateCompany(CompModel);
        }
        //FillCustomer
        public int FillCustomer(CompanyMasterModel CompModel)
        {

            return CompData.FillCustomer(CompModel);
        }




    }
}
