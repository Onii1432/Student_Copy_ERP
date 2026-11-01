using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StandardMetals.MODEL;
using StandardMetals.DAL;
using StandardMetals.BAL;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http.Cors;

namespace StandardMetals.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CompanyMasterController : ApiController
    {
        CompanyMasterModel companyModel = new CompanyMasterModel();
        CompMnger bal = new CompMnger();

        [HttpGet]
        public CompanyMasterModel FillCompanyMaster()
        {
            DataTable dt = new DataTable();
            dt = bal.FillCompanyMaster(companyModel);

            if(dt.Rows.Count > 0)
            {
                companyModel.CmpName = dt.Rows[0]["CompanyName"].ToString();
                companyModel.Address1 = dt.Rows[0]["Address1"].ToString();
                companyModel.Address2 = dt.Rows[0]["Address2"].ToString();
                companyModel.City = dt.Rows[0]["City"].ToString();
                companyModel.PinCode = dt.Rows[0]["PinCode"].ToString();
                companyModel.EmailID = dt.Rows[0]["EmailID"].ToString();
                companyModel.Website = dt.Rows[0]["Website"].ToString();
                companyModel.State = dt.Rows[0]["State"].ToString();
                companyModel.Country = dt.Rows[0]["Country"].ToString();
                companyModel.Mobile = dt.Rows[0]["Mobile"].ToString();
                companyModel.Telephone = dt.Rows[0]["Telephone"].ToString();
                companyModel.ContactPerson = dt.Rows[0]["ContactPerson"].ToString();
                companyModel.GSTIN = dt.Rows[0]["GSTIN"].ToString();

            }

            return companyModel;
        }

        [HttpGet]
        public List<CompanyMasterModel> FillCompanyMasterByList()
        {
            List<CompanyMasterModel> modelList = new List<CompanyMasterModel>();
            DataTable dt = new DataTable();
            modelList = bal.FillCompanyMasterByList();
            return modelList;
        }

        [HttpGet]
        public DataTable BindCountry()
        {
            DataTable dt = new DataTable();
            dt = bal.BindCountry(0);

            return dt;
        }

        [HttpPost]
        public DataTable BindState(int countryId)
        {
            DataTable dt = new DataTable();
            dt = bal.BindCountry(countryId);

            return dt;
        }

        [HttpPost]
        public DataTable BindCity(int stateID)
        {
            DataTable dt = new DataTable();
            dt = bal.BindCity(stateID);

            return dt;
        }

        [HttpPost]
        public int  UpdateCompanyInfo(CompanyMasterModel companyModel)
        {
            string status = " ";
            int result = bal.UpdateCompanyInfo(companyModel);
            if(result == 1)
            {
                status = "Data is saved";
            }
            else
            {
                status = "Data is not saved";

            }
            return 1;

        }


    }
}
