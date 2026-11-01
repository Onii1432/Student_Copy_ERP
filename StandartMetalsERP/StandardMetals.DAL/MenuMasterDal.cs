using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StandardMetals.MODEL;
using System.Data.SqlClient;
using System.Data;


namespace StandardMetals.DAL
{
   public class MenuMasterDal:ConncetionClass
    {
       public int  SaveSubMenuData(SubMenuModel subMenuModel)
        {

            this.Initialize();
            int nRecAffected = 0;
            using (cmdUniversal)
            {
                cnUniversal.Open();
                cmdUniversal = new SqlCommand("SaveSubMasterMenu", cnUniversal);
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cmdUniversal);
                cmdUniversal.Parameters["@SubMenuName"].Value = subMenuModel.SubMenuName;
                cmdUniversal.Parameters["@SubMenuLink"].Value = subMenuModel.SubMenuLink;
                cmdUniversal.Parameters["@MasterMenuId"].Value = subMenuModel.MasterMenuId;
                cmdUniversal.Parameters["@IsActive"].Value = subMenuModel.IsActive;
                cmdUniversal.Parameters["@BranchName"].Value = subMenuModel.BranchName;
                nRecAffected = cmdUniversal.ExecuteNonQuery();
                this.Close();
                return nRecAffected;
            }


        }
        
       public int SaveMenuData(MenuMasterModel masterModel)
       {
           
            this.Initialize();
            int nRecAffected = 0;
            using (cmdUniversal)
            {
                cnUniversal.Open();
                cmdUniversal = new SqlCommand("SaveMasterMenu", cnUniversal);
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cmdUniversal);
                cmdUniversal.Parameters["@MenuName"].Value = masterModel.MenuName;
                cmdUniversal.Parameters["@IsActive"].Value = masterModel.IsActive;
                cmdUniversal.Parameters["@BranchName"].Value = masterModel.BranchName;
                nRecAffected = cmdUniversal.ExecuteNonQuery();
                this.Close();
                return nRecAffected;
            }

            
       }

       public DataTable FillMenuItem()
       {
           DataTable dt = new DataTable();

           this.Initialize();
           int nRecAffected = 0;
           using (cmdUniversal)
           {
               try
               {
                   cnUniversal.Open();
                   cmdUniversal.CommandText = "BindMenuMaster";
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

        public DataTable FillRoleMasterItem()
        {
            DataTable dt = new DataTable();

            this.Initialize();
            int nRecAffected = 0;
            using (cmdUniversal)
            {
                try
                {
                    cnUniversal.Open();
                    cmdUniversal.CommandText = "Admin_GetRoleDetail";
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
    }
}
