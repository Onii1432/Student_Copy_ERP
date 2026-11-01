using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StandardMetals.MODEL;
using System.Data;
using System.Data.SqlClient;


namespace StandardMetals.DAL
{
    public class DemoItemMasterDAL : ConncetionClass
    {



        public DataTable FillItemMaster()
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {

                cmdUniversal.CommandText = "GetDemoItem";
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }


        public DataTable BindItemMasterByCode(string ItemCode)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {

                cmdUniversal.CommandText = "GetDemoItem";
                cmdUniversal.Parameters.Add("@ItemCode", SqlDbType.VarChar).Value = ItemCode;
            
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }



        public int SaveItemMaster(DemoItemMasterModel model)
        {
            int nRecAffected = 0;
            try
            {
                this.Initialize();

                using (cmdUniversal)
                {
                    cnUniversal.Open();
                    cmdUniversal = new SqlCommand("[SaveDemoItemMaster]", cnUniversal);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);
                    // cmdUniversal.Parameters["@ItemCode"].Value = dbItem.ItemCode;
                    cmdUniversal.Parameters["@ItemCode"].Value = model.ItemCode;
                    cmdUniversal.Parameters["@ItemName"].Value =  model.ItemName;
                    cmdUniversal.Parameters["@Material"].Value =  model.Material;
                  

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

        //UpdateItemMaster

        public int UpdateItemMaster(DemoItemMasterModel model)
        {
            int nRecAffected = 0;
            try
            {
                this.Initialize();

                using (cmdUniversal)
                {
                    cnUniversal.Open();
                    cmdUniversal = new SqlCommand("[UpdateDemoItemMaster]", cnUniversal);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);
                    // cmdUniversal.Parameters["@ItemCode"].Value = dbItem.ItemCode;
                    cmdUniversal.Parameters["@ItemCode"].Value = model.ItemCode;
                    cmdUniversal.Parameters["@ItemName"].Value = model.ItemName;
                    cmdUniversal.Parameters["@Material"].Value = model.Material;


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
