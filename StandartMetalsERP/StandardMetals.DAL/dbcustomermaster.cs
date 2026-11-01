using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StandardMetals.MODEL;

namespace StandardMetals.DAL
{
    public class dbcustomermaster:ConncetionClass
    {

        //BindCustomer

        public DataTable BindCustomer(CustomerMasterModel CustModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindCustomer";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                //cmdUniversal.Parameters.Add("@CustCode", SqlDbType.VarChar, 100).Value = CustModel.CustCode;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }


        //FillCustomer
        public DataTable FillCustomer(CustomerMasterModel CustModel)
        {
            DataTable dt = new DataTable();
            SqlTransaction trans;
            this.Initialize();
            int nRecAffected = 0;
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetCustomerMaster";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Add("@CustCode", SqlDbType.VarChar).Value = CustModel.CustCode;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }


        public int InsertCustomerMaster(CustomerMasterModel CustModel)
        {
            SqlTransaction trans;
            this.Initialize();
            int nRecAffected = 0;
            using (cmdUniversal)
            {
                cnUniversal.Open();
                trans = cnUniversal.BeginTransaction();
                try
                {
                    cmdUniversal = new SqlCommand("InsertCustomer", cnUniversal);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);
                    cmdUniversal.Parameters["@CustCode"].Value = CustModel.CustCode;
                    cmdUniversal.Parameters["@ContactPerson"].Value = CustModel.ContactPerson;
                    cmdUniversal.Parameters["@Branch"].Value = CustModel.Branch;
                    cmdUniversal.Parameters["@Address1"].Value = CustModel.Address1;
                    cmdUniversal.Parameters["@Address2"].Value = CustModel.Address2;
                    cmdUniversal.Parameters["@City"].Value = CustModel.City;
                    cmdUniversal.Parameters["@State"].Value = CustModel.State;
                    cmdUniversal.Parameters["@PinCode"].Value = CustModel.PinCode;
                    cmdUniversal.Parameters["@Country"].Value = CustModel.Country;
                    cmdUniversal.Parameters["@EmailID"].Value = CustModel.EmailID;
                    cmdUniversal.Parameters["@Telephone"].Value = CustModel.Telephone;
                    cmdUniversal.Parameters["@Mobile"].Value = CustModel.Mobile;
                    cmdUniversal.Parameters["@Fax"].Value = CustModel.Fax;
                    cmdUniversal.Parameters["@Website"].Value = CustModel.Website;
                    cmdUniversal.Parameters["@GSTIN"].Value = CustModel.GSTIN;
                    cmdUniversal.Parameters["@Remarks"].Value = CustModel.Remarks;
                    cmdUniversal.Parameters["@username"].Value = "Amol";
                    cmdUniversal.Parameters["@LoginBranch"].Value = "SA";
                    cmdUniversal.Parameters["@systemEntryDate"].Value = System.DateTime.Now;

                    cmdUniversal.ExecuteNonQuery();
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

        public int UpdateCustomer(CustomerMasterModel CustModel)
        {
            SqlTransaction trans;
            this.Initialize();
            int nRecAffected = 0;
            using (cmdUniversal)
            {
                cnUniversal.Open();
                trans = cnUniversal.BeginTransaction();
                try
                {
                    cmdUniversal = new SqlCommand("UpdateCustomer", cnUniversal, trans);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);
                    cmdUniversal.Parameters["@CustCode"].Value = CustModel.CustCode;
                    cmdUniversal.Parameters["@ContactPerson"].Value = CustModel.ContactPerson;
                    cmdUniversal.Parameters["@Branch"].Value = CustModel.Branch;
                    cmdUniversal.Parameters["@Address1"].Value = CustModel.Address1;
                    cmdUniversal.Parameters["@Address2"].Value = CustModel.Address2;
                    cmdUniversal.Parameters["@City"].Value = CustModel.City;
                    cmdUniversal.Parameters["@State"].Value = CustModel.State;
                    cmdUniversal.Parameters["@PinCode"].Value = CustModel.PinCode;
                    cmdUniversal.Parameters["@Country"].Value = CustModel.Country;
                    cmdUniversal.Parameters["@EmailID"].Value = CustModel.EmailID;
                    cmdUniversal.Parameters["@Telephone"].Value = CustModel.Telephone;
                    cmdUniversal.Parameters["@Mobile"].Value = CustModel.Mobile;
                    cmdUniversal.Parameters["@Fax"].Value = CustModel.Fax;
                    cmdUniversal.Parameters["@Website"].Value = CustModel.Website;
                    cmdUniversal.Parameters["@GSTIN"].Value = CustModel.GSTIN;
                    cmdUniversal.Parameters["@Remarks"].Value = CustModel.Remarks;
                    //cmdUniversal.Parameters["@username"].Value = CustModel.Username;
                    //cmdUniversal.Parameters["@LoginBranch"].Value = CustModel.LoginBranch;
                    cmdUniversal.Parameters["@username"].Value = "Sid";
                    cmdUniversal.Parameters["@LoginBranch"].Value = "SA_Tech";
                    cmdUniversal.Parameters["@systemEntryDate"].Value = System.DateTime.Now;

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

        public DataTable FillCust(dbcustomermaster objdbcustomermaster)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetCustomerMaster";
                cmdUniversal.Parameters.Add("@custcode", SqlDbType.VarChar).Value = string.Empty;
                cmdUniversal.Parameters.Add("@Flag", SqlDbType.Int).Value = 1;                
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }
    }
}
