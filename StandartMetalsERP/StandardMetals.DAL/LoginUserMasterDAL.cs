using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StandardMetals.MODEL;
using System.Data;
using System.Data.SqlClient;

namespace StandardMetals.DAL
{
    public class LoginUserMasterDAL : ConncetionClass
    {


        public DataTable GetRoleDetails()
        {
            DataTable dt = new DataTable();

            this.Initialize();
            int nRecAffected = 0;
            using (cmdUniversal)
            {
                try
                {
                    cnUniversal.Open();
                    cmdUniversal.CommandText = "Admin_GetRoleDetails";
                    this.daUniversal.SelectCommand = cmdUniversal;
                    // this.cnUniversal.Open();
                    nRecAffected = this.daUniversal.Fill(dt);
                    this.Close();
                }
                catch (Exception ex)
                {
                }
                return dt;
            }

        }



        public int SaveLoginUserMaster(LoginUserMasterModel model)
        {
            int nRecAffected = 0;
            try
            {
                this.Initialize();

                using (cmdUniversal)
                {
                    cnUniversal.Open();
                    cmdUniversal = new SqlCommand("Admin_SaveLoginUserMaster", cnUniversal);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);
                    // cmdUniversal.Parameters["@ItemCode"].Value = dbItem.ItemCode;
                    cmdUniversal.Parameters["@UserName"].Value = model.UserName;
                    cmdUniversal.Parameters["@Password"].Value = model.Password;
                    cmdUniversal.Parameters["@RoleId"].Value = model.RoleId;
                    cmdUniversal.Parameters["@IsActive"].Value = model.IsActive;
                    cmdUniversal.Parameters["@EmployeeId"].Value = model.EmployeeId;
                    cmdUniversal.Parameters["@BranchId"].Value = model.BranchId;
                    
                    nRecAffected = cmdUniversal.ExecuteNonQuery();
                    this.Close();

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.Close();
            }
            return nRecAffected;
        }


    }
}
