using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace StandardMetals.DAL
{
   public class SupplierMasterDAL05Oct : ConncetionClass
    {
        public string SuppCode { get; set; }
        public string SuppName { get; set; }
        public string ContactPerson { get; set; }
        public string Branch { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PinCode { get; set; }
        public string Country { get; set; }
        public string EmailID { get; set; }
        public int Telephone { get; set; }
        public int Mobile { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string GSTIN { get; set; }
        public string Remarks { get; set; }
        public string UserName { get; set; }
        public string LoginBranch { get; set; }
        public string supptypeid { get; set; }
       
        public int
            SaveSupplierMaster(SupplierMasterDAL05Oct dbSupplier)
        {
            this.Initialize();
            int nRecAffected = 0;
            using (cmdUniversal)
            {
                cnUniversal.Open();
                cmdUniversal = new SqlCommand("SaveSupplierMaster", cnUniversal);
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cmdUniversal);
               
                cmdUniversal.Parameters["@SuppName"].Value = dbSupplier.SuppName;
                cmdUniversal.Parameters["@ContactPerson"].Value = dbSupplier.ContactPerson;
                cmdUniversal.Parameters["@Branch"].Value = dbSupplier.Branch;
                cmdUniversal.Parameters["@Address1"].Value = dbSupplier.Address1;
                cmdUniversal.Parameters["@Address2"].Value = dbSupplier.Address2;
                cmdUniversal.Parameters["@City"].Value = dbSupplier.City;
                cmdUniversal.Parameters["@State"].Value = dbSupplier.State;
                cmdUniversal.Parameters["@PinCode"].Value = dbSupplier.PinCode;
                cmdUniversal.Parameters["@Country"].Value = dbSupplier.Country;
                cmdUniversal.Parameters["@EmailID"].Value = dbSupplier.EmailID;
                cmdUniversal.Parameters["@Telephone"].Value = dbSupplier.Telephone;
                cmdUniversal.Parameters["@Mobile"].Value = dbSupplier.Mobile;
                cmdUniversal.Parameters["@Fax"].Value = dbSupplier.Fax;
                cmdUniversal.Parameters["@Website"].Value = dbSupplier.Website;
                cmdUniversal.Parameters["@GSTIN"].Value = dbSupplier.GSTIN;
                cmdUniversal.Parameters["@Remarks"].Value = dbSupplier.Remarks;
                cmdUniversal.Parameters["@Username"].Value = dbSupplier.UserName;
                cmdUniversal.Parameters["@LoginBranch"].Value = dbSupplier.LoginBranch;
                cmdUniversal.Parameters["@SystemEntryDate"].Value = System.DateTime.Now;
                cmdUniversal.Parameters["@supptypeid"].Value = dbSupplier.supptypeid;

                nRecAffected = cmdUniversal.ExecuteNonQuery();
                this.Close();
                return nRecAffected;
            }

        }

        public DataTable FillSupplier(string SuppCode)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetSupplierMaster";
                cmdUniversal.Parameters.Add("@SuppCode", SqlDbType.VarChar).Value = SuppCode;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

    }
}
