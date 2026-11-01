using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace StandardMetals.DAL
{
   public class dbSupplierMaster:ConncetionClass
    {
        public string Id { get; set; }
        public string SuppCode { get; set; }
        public string SuppName { get; set; }
        public string ContactPerson { get; set; }
        public string Branch { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string Country { get; set; }
        public string EmailID { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string GSTIN { get; set; }
        public string Remarks { get; set; }
        public string Action { get; set; }

        public string Username { get; set; }
        public string LoginBranch { get; set; }

        public int SaveSupplierMaster(dbSupplierMaster objdbSupplierMaster)
        {
            this.Initialize();
            int nRecAffected = 0;
            using (cmdUniversal)
            {
                cnUniversal.Open();
                cmdUniversal = new SqlCommand("InsertSupplierMaster", cnUniversal);
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cmdUniversal);
                cmdUniversal.Parameters["@Action"].Value = "0";
                cmdUniversal.Parameters["@Id"].Value = "0";
                cmdUniversal.Parameters["@SuppCode"].Value = objdbSupplierMaster.SuppCode;
                cmdUniversal.Parameters["@SuppName"].Value = objdbSupplierMaster.SuppName;
                cmdUniversal.Parameters["@ContactPerson"].Value = objdbSupplierMaster.ContactPerson;
                cmdUniversal.Parameters["@Branch"].Value = objdbSupplierMaster.Branch;
                cmdUniversal.Parameters["@Address1"].Value = objdbSupplierMaster.Address1;
                cmdUniversal.Parameters["@Address2"].Value = objdbSupplierMaster.Address2;
                cmdUniversal.Parameters["@City"].Value = objdbSupplierMaster.City;
                cmdUniversal.Parameters["@State"].Value = objdbSupplierMaster.State;
                cmdUniversal.Parameters["@PinCode"].Value = objdbSupplierMaster.PinCode;
                cmdUniversal.Parameters["@Country"].Value = objdbSupplierMaster.Country;
                cmdUniversal.Parameters["@EmailID"].Value = objdbSupplierMaster.EmailID;
                cmdUniversal.Parameters["@Telephone"].Value = objdbSupplierMaster.Telephone;
                cmdUniversal.Parameters["@Mobile"].Value = objdbSupplierMaster.Mobile;
                cmdUniversal.Parameters["@Fax"].Value = objdbSupplierMaster.Fax;
                cmdUniversal.Parameters["@Website"].Value = objdbSupplierMaster.Website;
                cmdUniversal.Parameters["@GSTIN"].Value = objdbSupplierMaster.GSTIN;
                cmdUniversal.Parameters["@Remarks"].Value = objdbSupplierMaster.Remarks;

                cmdUniversal.Parameters["@username"].Value = objdbSupplierMaster.Username;
                cmdUniversal.Parameters["@LoginBranch"].Value = objdbSupplierMaster.LoginBranch;
                cmdUniversal.Parameters["@systemEntryDate"].Value = System.DateTime.Now;

                nRecAffected = cmdUniversal.ExecuteNonQuery();
                this.Close();
                return nRecAffected;
            }

        }

        public int UpdateSupplierMaster(dbSupplierMaster objdbSupplierMaster)
        {
            this.Initialize();
            int nRecAffected = 0;
            using (cmdUniversal)
            {
                cnUniversal.Open();
                cmdUniversal = new SqlCommand("InsertSupplierMaster", cnUniversal);
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cmdUniversal);
                cmdUniversal.Parameters["@Action"].Value = "1";
                cmdUniversal.Parameters["@Id"].Value = "0";
                cmdUniversal.Parameters["@SuppCode"].Value = objdbSupplierMaster.SuppCode;
                cmdUniversal.Parameters["@SuppName"].Value = objdbSupplierMaster.SuppName;
                cmdUniversal.Parameters["@ContactPerson"].Value = objdbSupplierMaster.ContactPerson;
                cmdUniversal.Parameters["@Branch"].Value = objdbSupplierMaster.Branch;
                cmdUniversal.Parameters["@Address1"].Value = objdbSupplierMaster.Address1;
                cmdUniversal.Parameters["@Address2"].Value = objdbSupplierMaster.Address2;
                cmdUniversal.Parameters["@City"].Value = objdbSupplierMaster.City;
                cmdUniversal.Parameters["@State"].Value = objdbSupplierMaster.State;
                cmdUniversal.Parameters["@PinCode"].Value = objdbSupplierMaster.PinCode;
                cmdUniversal.Parameters["@Country"].Value = objdbSupplierMaster.Country;
                cmdUniversal.Parameters["@EmailID"].Value = objdbSupplierMaster.EmailID;
                cmdUniversal.Parameters["@Telephone"].Value = objdbSupplierMaster.Telephone;
                cmdUniversal.Parameters["@Mobile"].Value = objdbSupplierMaster.Mobile;
                cmdUniversal.Parameters["@Fax"].Value = objdbSupplierMaster.Fax;
                cmdUniversal.Parameters["@Website"].Value = objdbSupplierMaster.Website;
                cmdUniversal.Parameters["@GSTIN"].Value = objdbSupplierMaster.GSTIN;
                cmdUniversal.Parameters["@Remarks"].Value = objdbSupplierMaster.Remarks;
                nRecAffected = cmdUniversal.ExecuteNonQuery();
                this.Close();
                return nRecAffected;
            }

        }

        public DataTable FillSupplier(dbSupplierMaster objdbcustomermaster)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetSupplierMaster";
                cmdUniversal.Parameters.Add("@Suppcode", SqlDbType.VarChar).Value = string.Empty;
                cmdUniversal.Parameters.Add("@Flag", SqlDbType.Int).Value = 1;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable ReteiveSupplierData(string Suppcode)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetSupplierMaster";
                cmdUniversal.Parameters.Add("@Suppcode", SqlDbType.VarChar).Value =Suppcode;
                cmdUniversal.Parameters.Add("@Flag", SqlDbType.Int).Value = 2;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable GetMAXSuppNumber()
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetMaxSuppNumber";
                //cmdUniversal.Parameters.Add("@RawMaterial", SqlDbType.VarChar).Value = RawMaterial;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }
    }
}
