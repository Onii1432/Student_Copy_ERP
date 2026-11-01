using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using StandardMetals.MODEL;

namespace StandardMetals.DAL
{
    public   class dbCompanyMaster : ConncetionClass
    {
        CompanyMasterModel CompModel = new CompanyMasterModel();


        public DataTable BindCountry(int countryId)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindCountryMaster";
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                cmdUniversal.Parameters.Add("@CountryId", SqlDbType.VarChar).Value = countryId;
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        
        public DataTable BindCity(int stateID)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindStateMaster";
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                cmdUniversal.Parameters.Add("@StateId", SqlDbType.VarChar).Value = stateID;
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }
 



        public List<CompanyMasterModel> FillCompanyMasterByList()
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetCompanyMaster";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                //cmdUniversal.Parameters.Add("@Cmp_code", SqlDbType.VarChar).Value = CompModel.CmpCode;
                cmdUniversal.Parameters.Add("@Cmp_code", SqlDbType.VarChar).Value = 1;
                // cmdUniversal.Parameters.Add("@Flag", SqlDbType.Int).Value = flag;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                List<CompanyMasterModel> modelList = new List<CompanyMasterModel>();
                if (dt.Rows.Count > 0)
                {
                    for(int i = 0; i < dt.Rows.Count;i++ )
                    {
                        modelList.Add(new CompanyMasterModel(){
                            CmpCode = dt.Rows[i]["Id"].ToString(),

                        });
                    }
                }

                this.Close();
                return modelList;
            }
        }

        public DataTable FillCompanyMaster(CompanyMasterModel  companyModel)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetCompanyMaster";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Add("@Cmp_code", SqlDbType.VarChar).Value = 1;
                //cmdUniversal.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;
                // cmdUniversal.Parameters.Add("@Flag", SqlDbType.Int).Value = flag;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }


        public int UpdateCompany(CompanyMasterModel CompModel)
        {

            SqlTransaction trans;
            this.Initialize();
            int nRecAffected = 0;
            using (cnUniversal)
            {
                cnUniversal.Open();
                trans = cnUniversal.BeginTransaction();
                try
                {
                    cmdUniversal = new SqlCommand("UpdateCompany", cnUniversal, trans);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);
                    cmdUniversal.Parameters["@CompanyName"].Value = CompModel.CmpName;
                    cmdUniversal.Parameters["@Address1"].Value = CompModel.Address1;
                    cmdUniversal.Parameters["@Address2"].Value = CompModel.Address2;
                    cmdUniversal.Parameters["@City"].Value = CompModel.City;
                    cmdUniversal.Parameters["@State"].Value = CompModel.State;
                    cmdUniversal.Parameters["@PinCode"].Value = CompModel.PinCode;
                    cmdUniversal.Parameters["@Country"].Value = CompModel.Country;
                    cmdUniversal.Parameters["@EmailID"].Value = CompModel.EmailID;
                    cmdUniversal.Parameters["@Telephone"].Value = CompModel.Telephone;
                    cmdUniversal.Parameters["@Mobile"].Value = CompModel.Mobile;
                    cmdUniversal.Parameters["@ContactPerson"].Value = CompModel.ContactPerson;
                    cmdUniversal.Parameters["@Website"].Value = CompModel.Website;
                    cmdUniversal.Parameters["@GSTIN"].Value = CompModel.GSTIN;
                    cmdUniversal.Parameters["@SystemDate"].Value = DateTime.Now;

                    cmdUniversal.ExecuteNonQuery();
                    trans.Commit();
                    this.Close();
                    return nRecAffected = 1;

                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    cnUniversal.Close();
                    return nRecAffected = 0;
                }

            }
        }

        //FillCustomer
        public int FillCustomer(CompanyMasterModel CompModel)
        {

            SqlTransaction trans;
            this.Initialize();
            int nRecAffected = 0;
            using (cnUniversal)
            {
                cnUniversal.Open();
                trans = cnUniversal.BeginTransaction();
                try
                {
                    cmdUniversal = new SqlCommand("GetCustomerMaster", cnUniversal, trans);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);
                    cmdUniversal.Parameters["@CompanyName"].Value = CompModel.CmpName;
                    cmdUniversal.Parameters["@Address1"].Value = CompModel.Address1;
                    cmdUniversal.Parameters["@Address2"].Value = CompModel.Address2;
                    cmdUniversal.Parameters["@City"].Value = CompModel.City;
                    cmdUniversal.Parameters["@State"].Value = CompModel.State;
                    cmdUniversal.Parameters["@PinCode"].Value = CompModel.PinCode;
                    cmdUniversal.Parameters["@Country"].Value = CompModel.Country;
                    cmdUniversal.Parameters["@EmailID"].Value = CompModel.EmailID;
                    cmdUniversal.Parameters["@Telephone"].Value = CompModel.Telephone;
                    cmdUniversal.Parameters["@Mobile"].Value = CompModel.Mobile;
                    cmdUniversal.Parameters["@ContactPerson"].Value = CompModel.ContactPerson;
                    cmdUniversal.Parameters["@Website"].Value = CompModel.Website;
                    cmdUniversal.Parameters["@GSTIN"].Value = CompModel.GSTIN;

                    cmdUniversal.ExecuteNonQuery();
                    trans.Commit();
                    this.Close();
                    return nRecAffected = 1;

                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    cnUniversal.Close();
                    return nRecAffected = 0;
                }

            }
        }



    }   /*Class Close*/
}       /*BAL Close*/
