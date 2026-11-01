using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StandardMetals.MODEL;

namespace StandardMetals.DAL
{
   public class RoleMasterDAL : ConncetionClass
    {
       DataTable dt = null;

       public List<LoginDetailsModel> GetMenuDetail()
       {
           this.Initialize();
           int nRecAffected = 0;
           dt = new DataTable();
           List<LoginDetailsModel> lst = new List<LoginDetailsModel>();
           using (cnUniversal)
           {
               cmdUniversal.CommandText = "GetMenuDetails";
               //cmdUniversal.Parameters.Add("@UserName", SqlDbType.VarChar).Value = username;
               //cmdUniversal.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
               this.daUniversal.SelectCommand = cmdUniversal;
               this.cnUniversal.Open();
               nRecAffected = this.daUniversal.Fill(dt);
               this.Close();

               if (dt.Rows.Count > 0)
               {
                   for (int i = 0; i < dt.Rows.Count; i++)
                   {
                       lst.Add(new LoginDetailsModel()
                       {
                           MasterMenuId = Convert.ToInt32(dt.Rows[i]["MasterMenuId"]),
                           MenuName = dt.Rows[i]["MenuName"].ToString(),
                           IsMaster = Convert.ToBoolean(dt.Rows[i]["IsMaster"]),
                           SubMasterMenuId = Convert.ToInt32(dt.Rows[i]["SubMasterMenuId"]),
                           SubMenuName = dt.Rows[i]["SubMenuName"].ToString(),
                           MenuLink = dt.Rows[i]["MenuLink"].ToString(),

                       });
                   }
               }

               return lst;
           }
       }




       public List<RoleMasterModel> GetRoleDetail()
       {
           this.Initialize();
           int nRecAffected = 0;
           dt = new DataTable();
           List<RoleMasterModel> lst = new List<RoleMasterModel>();
           using (cnUniversal)
           {
               cmdUniversal.CommandText = "Admin_GetRoleDetail";
               //cmdUniversal.Parameters.Add("@UserName", SqlDbType.VarChar).Value = username;
               //cmdUniversal.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
               this.daUniversal.SelectCommand = cmdUniversal;
               this.cnUniversal.Open();
               nRecAffected = this.daUniversal.Fill(dt);
               this.Close();

               if (dt.Rows.Count > 0)
               {
                   for (int i = 0; i < dt.Rows.Count; i++)
                   {
                       lst.Add(new RoleMasterModel()
                       {
                           RoleId  = Convert.ToInt32(dt.Rows[i]["RoleId"]),
                           RoleName = dt.Rows[i]["RoleName"].ToString(),
                            
                       });
                   }
               }

               return lst;
           }
       }



       public List<RoleMasterModel> GetMenuDetailById(int RoleId)
       {
           this.Initialize();
           int nRecAffected = 0;
           dt = new DataTable();
           List<RoleMasterModel> lst = new List<RoleMasterModel>();
           using (cnUniversal)
           {
               cmdUniversal.CommandText = "Admin_GetMenuDetailsById";
              cmdUniversal.Parameters.Add("@RoleId", SqlDbType.Int).Value = RoleId;
                this.daUniversal.SelectCommand = cmdUniversal;
               this.cnUniversal.Open();
               nRecAffected = this.daUniversal.Fill(dt);
               this.Close();

               if (dt.Rows.Count > 0)
               {
                   for (int i = 0; i < dt.Rows.Count; i++)
                   {
                       lst.Add(new RoleMasterModel()
                       {
                           MasterMenuId = Convert.ToInt32(dt.Rows[i]["MasterMenuId"]),
                           RoleName = dt.Rows[i]["RoleName"].ToString(),
                           IsActive = Convert.ToBoolean(dt.Rows[i]["IsMaster"]),
                           SubMasterMenuId = Convert.ToInt32(dt.Rows[i]["SubMasterMenuId"]),
                           AddAccess = Convert.ToBoolean(dt.Rows[i]["AddAccess"]),
                           UpdateAccess = Convert.ToBoolean(dt.Rows[i]["UpdateAccess"]),
                           SearchAccess = Convert.ToBoolean(dt.Rows[i]["SearchAccess"]),
                           DeleteAccess = Convert.ToBoolean(dt.Rows[i]["DeleteAccess"]),
  });
                   }
               }

               return lst;
           }
       }




       public int SaveRoleMasterMaster(RoleMasterModel model)
       {
           int nRecAffected = 0;
           int RoleId = 0;

           try
           {
               this.Initialize();

               using (cmdUniversal)
               {
                   cnUniversal.Open();
                   cmdUniversal = new SqlCommand("Admin_SaveRoleMaster", cnUniversal);
                   cmdUniversal.CommandType = CommandType.StoredProcedure;
                   //   SqlCommandBuilder.DeriveParameters(cmdUniversal);


                   cmdUniversal.Parameters.AddWithValue("@RoleName", model.RoleName);
                   cmdUniversal.Parameters.AddWithValue("@IsActive", model.IsActive);

                   //   Add the output parameter to the command object
                   SqlParameter outPutParameter = new SqlParameter();
                   outPutParameter.ParameterName = "@RoleId";
                   outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                   outPutParameter.Direction = System.Data.ParameterDirection.Output;
                   cmdUniversal.Parameters.Add(outPutParameter);

                   cmdUniversal.ExecuteNonQuery();
                   RoleId = Convert.ToInt32(outPutParameter.Value.ToString());

                   // insert access details

                   cmdUniversal = new SqlCommand("Admin_SaveRoleAccessDetail", cnUniversal);
                   cmdUniversal.CommandType = CommandType.StoredProcedure;
                   SqlCommandBuilder.DeriveParameters(cmdUniversal);

                   foreach (RoleMasterModel val in model.getAccessDtl)
                   {

                       cmdUniversal.Parameters["@RoleId"].Value = RoleId;
                       cmdUniversal.Parameters["@MasterMenuId"].Value = val.MasterMenuId;
                       cmdUniversal.Parameters["@SubMasterMenuId"].Value = val.SubMasterMenuId;
                       cmdUniversal.Parameters["@AddAccess"].Value = val.AddAccess;
                       cmdUniversal.Parameters["@UpdateAccess"].Value = val.UpdateAccess;
                       cmdUniversal.Parameters["@SearchAccess"].Value = val.SearchAccess;
                       cmdUniversal.Parameters["@DeleteAccess"].Value = val.DeleteAccess;

                       cmdUniversal.ExecuteNonQuery();
                   }
               }
           }
           catch (Exception ex)
           {

           }
           finally
           {
               this.Close();
           }
           return RoleId;
       }

       public int UpdateRoleMasterMaster(RoleMasterModel model)
       {
           int nRecAffected = 0;
 
           try
           {
               this.Initialize();

               using (cmdUniversal)
               {
                   cnUniversal.Open();
                   cmdUniversal = new SqlCommand("Admin_UpdateRoleMaster", cnUniversal);
                   cmdUniversal.CommandType = CommandType.StoredProcedure;
                   //   SqlCommandBuilder.DeriveParameters(cmdUniversal);


                   cmdUniversal.Parameters.AddWithValue("@RoleId", model.RoleId);
                   cmdUniversal.Parameters.AddWithValue("@RoleName", model.RoleName);
                   cmdUniversal.Parameters.AddWithValue("@IsActive", model.IsActive);

                   //   Add the output parameter to the command object
                  // SqlParameter outPutParameter = new SqlParameter();
                  // outPutParameter.ParameterName = "@RoleId";
                  // outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                  // outPutParameter.Direction = System.Data.ParameterDirection.Output;
                  // cmdUniversal.Parameters.Add(outPutParameter);

                   cmdUniversal.ExecuteNonQuery();
                  // RoleId = Convert.ToInt32(outPutParameter.Value.ToString());

                   // insert access details

                   cmdUniversal = new SqlCommand("Admin_SaveRoleAccessDetail", cnUniversal);
                   cmdUniversal.CommandType = CommandType.StoredProcedure;
                   SqlCommandBuilder.DeriveParameters(cmdUniversal);

                   foreach (RoleMasterModel val in model.getAccessDtl)
                   {

                       cmdUniversal.Parameters["@RoleId"].Value = model.RoleId;
;
                       cmdUniversal.Parameters["@MasterMenuId"].Value = val.MasterMenuId;
                       cmdUniversal.Parameters["@SubMasterMenuId"].Value = val.SubMasterMenuId;
                       cmdUniversal.Parameters["@AddAccess"].Value = val.AddAccess;
                       cmdUniversal.Parameters["@UpdateAccess"].Value = val.UpdateAccess;
                       cmdUniversal.Parameters["@SearchAccess"].Value = val.SearchAccess;
                       cmdUniversal.Parameters["@DeleteAccess"].Value = val.DeleteAccess;

                       cmdUniversal.ExecuteNonQuery();
                    }
                   nRecAffected = 1;
                   
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
