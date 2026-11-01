using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StandardMetals.MODEL;

namespace StandardMetals.DAL
{
    public class SubMenuDal : ConncetionClass
    {
        public int SaveMenuData(SubMenuModel SubModel)
        {

            this.Initialize();
            int nRecAffected = 0;
            using (cmdUniversal)
            {
                cnUniversal.Open();
                cmdUniversal = new SqlCommand("SaveSubMasterMenu", cnUniversal);
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cmdUniversal);
                cmdUniversal.Parameters["@SubMenuName"].Value = SubModel.SubMenuName;
                cmdUniversal.Parameters["@SubMenuLink"].Value = SubModel.SubMenuLink;
                cmdUniversal.Parameters["@MasterMenuId"].Value = SubModel.MasterMenuId;
                cmdUniversal.Parameters["@IsActive"].Value = SubModel.IsActive;
                cmdUniversal.Parameters["@BranchName"].Value = SubModel.BranchName;
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

    }
}
