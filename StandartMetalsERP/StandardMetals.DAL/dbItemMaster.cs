using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using StandardMetals.MODEL;

namespace StandardMetals.DAL
{
    public class dbItemMaster : ConncetionClass
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int ManufacturerId { get; set; }
        public string Material { get; set; }
        public string ItemType { get; set; }
        public string ItemSubType { get; set; }
        public int ColorId { get; set; }
        public int UnitId { get; set; }
        public string HSNCODE { get; set; }
        public decimal GSTRate { get; set; }
        public decimal PurchaseCost { get; set; }
        public decimal SellingPrice { get; set; }
        public string Username { get; set; }
        public string LoginBranch { get; set; }
        public string RawMaterial { get; set; }
        public string Specification { get; set; }
        public DateTime SystemDate { get; set; }
        public int ItemCategoryid { get; set; }
        public int ItemSubCategoryid { get; set; }


        
        public DataTable BindCategory(int CategoryId)
        {
            this.Initialize();
            int nRecAffected = 0;   
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindCategorySubCategory";
                this.daUniversal.SelectCommand = cmdUniversal;
                cmdUniversal.Parameters.Add("@CategoryId", SqlDbType.VarChar).Value = CategoryId;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable BindUom()
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindUom";
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }


        public DataTable BindColor()
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindColorMaster";
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable BindManfacturer()
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindManufacturerMaster";
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable ItemMasterFill()
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "FillItemMaster";
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        // Save Item Master Grid view Data
        public int SaveGridViewData(ItemMasterModel SaveGridViewData)
        {
            int nRecAffected = 0;
            try
            {
                this.Initialize();

                using (cmdUniversal)
                {
                    cnUniversal.Open();
                    cmdUniversal = new SqlCommand("SaveItemMasterGridView", cnUniversal);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);
                    cmdUniversal.Parameters["@itemCode"].Value = SaveGridViewData.ItemCode;
                    cmdUniversal.Parameters["@itemName"].Value = SaveGridViewData.ItemName;
                    cmdUniversal.Parameters["@material"].Value = SaveGridViewData.Material;
                    cmdUniversal.Parameters["@itemType"].Value = SaveGridViewData.ItemType;
                    cmdUniversal.Parameters["@itemSubType"].Value = SaveGridViewData.ItemSubType;
                    cmdUniversal.Parameters["@color"].Value = SaveGridViewData.Color;
                    cmdUniversal.Parameters["@hsncode"].Value = SaveGridViewData.HSNCODE;
                    cmdUniversal.Parameters["@gstRate"].Value = SaveGridViewData.GSTRate;
                    cmdUniversal.Parameters["@purchaseCost"].Value = SaveGridViewData.PurchaseCost;
                    cmdUniversal.Parameters["@sellingPrice"].Value = SaveGridViewData.SellingPrice;
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
        // Update Item Master Grid view Data
        public int UpdateDataGridView(ItemMasterModel UpdateGridViewData)
        {
            int nRecAffected = 0;
            try
            {
                this.Initialize();

                using (cmdUniversal)
                {
                    cnUniversal.Open();
                    cmdUniversal = new SqlCommand("UpdateItemMasterGridView", cnUniversal);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);
                   // cmdUniversal.Parameters["@id"].Value = UpdateGridViewData.ID;
                    cmdUniversal.Parameters["@itemCode"].Value = UpdateGridViewData.ItemCode;
                    cmdUniversal.Parameters["@itemName"].Value = UpdateGridViewData.ItemName;
                    cmdUniversal.Parameters["@material"].Value = UpdateGridViewData.Material;
                    cmdUniversal.Parameters["@itemType"].Value = UpdateGridViewData.ItemType;
                    cmdUniversal.Parameters["@itemSubType"].Value = UpdateGridViewData.ItemSubType;
                    cmdUniversal.Parameters["@color"].Value = UpdateGridViewData.Color;
                    cmdUniversal.Parameters["@hsncode"].Value = UpdateGridViewData.HSNCODE;
                    cmdUniversal.Parameters["@gstRate"].Value = UpdateGridViewData.GSTRate;
                    cmdUniversal.Parameters["@purchaseCost"].Value = UpdateGridViewData.PurchaseCost;
                    cmdUniversal.Parameters["@sellingPrice"].Value = UpdateGridViewData.SellingPrice;
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


        public int SaveItemMaster(ItemMasterModel dbItemMaster)
        {
            int nRecAffected = 0;
            try
            {
                this.Initialize();

                using (cmdUniversal)
                {
                    cnUniversal.Open();
                    cmdUniversal = new SqlCommand("Save_ItemMaster_MvcJquery", cnUniversal);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);
                    //cmdUniversal.Parameters["@ItemCode"].Value = dbItemMaster.ItemCode;
                    cmdUniversal.Parameters["@ItemName"].Value = dbItemMaster.ItemName;
                    cmdUniversal.Parameters["@ManufacturereId"].Value = dbItemMaster.ManufacturerId;
                    cmdUniversal.Parameters["@Material"].Value = dbItemMaster.Material;
                    cmdUniversal.Parameters["@ItemCategoryId"].Value = dbItemMaster.ItemCategoryId;
                    cmdUniversal.Parameters["@ItemSubCategoryId"].Value = dbItemMaster.ItemSubCategoryId;
                    cmdUniversal.Parameters["@ColorId"].Value = dbItemMaster.ColourId;
                    cmdUniversal.Parameters["@UnitId"].Value = dbItemMaster.UnitId;
                    cmdUniversal.Parameters["@HSNCODE"].Value = dbItemMaster.HSNCODE;
                    cmdUniversal.Parameters["@GSTRate"].Value = dbItemMaster.GSTRate;
                    cmdUniversal.Parameters["@PurchaseCost"].Value = dbItemMaster.PurchaseCost;
                    cmdUniversal.Parameters["@SellingPrice"].Value = dbItemMaster.SellingPrice;
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



        public int Update_ItemMaster(ItemMasterModel dbItemMaster)
        {
            int nRecAffected = 0;
            try
            {
                this.Initialize();

                using (cmdUniversal)
                {
                    cnUniversal.Open();
                    cmdUniversal = new SqlCommand("Update_ItemMaster_MvcJquery", cnUniversal);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);

                    cmdUniversal.Parameters["@ItemCode"].Value = dbItemMaster.ItemCode;
                    cmdUniversal.Parameters["@ItemName"].Value = dbItemMaster.ItemName;
                    cmdUniversal.Parameters["@ManufacturerId"].Value = dbItemMaster.ManufacturerId;
                    cmdUniversal.Parameters["@Material"].Value = dbItemMaster.Material;
                    cmdUniversal.Parameters["@ItemCategoryId"].Value = dbItemMaster.ItemCategoryId;
                    cmdUniversal.Parameters["@ItemSubCategoryId"].Value = dbItemMaster.ItemSubCategoryId;
                    cmdUniversal.Parameters["@ColorId"].Value = dbItemMaster.ColourId;
                    cmdUniversal.Parameters["@UOMId"].Value = dbItemMaster.UnitId;
                    cmdUniversal.Parameters["@HSNCODE"].Value = dbItemMaster.HSNCODE;
                    cmdUniversal.Parameters["@GSTRate"].Value = dbItemMaster.GSTRate;
                    cmdUniversal.Parameters["@PurchaseCost"].Value = dbItemMaster.PurchaseCost;
                    cmdUniversal.Parameters["@SellingPrice"].Value = dbItemMaster.SellingPrice;
                    
                    nRecAffected = cmdUniversal.ExecuteNonQuery();
                    this.Close();

                }
            }
            catch (Exception ex)
            {
                this.Close();
            }
            return nRecAffected;
        }


        //FillCategory
        public DataTable FillCategory(int CategoryId)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.Parameters.Add("@CategoryId", SqlDbType.VarChar).Value = CategoryId;
                cmdUniversal.CommandText = "BindCategorySubCategory";
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }



        //check Dup Item
        public int CheckDupItem(string ItemName,string ItemCode)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.Parameters.Add("@ItemName", SqlDbType.VarChar).Value = ItemName;
                cmdUniversal.Parameters.Add("@ItemCode", SqlDbType.VarChar).Value = ItemCode;
                cmdUniversal.CommandText = "CheckDuplicateItem";
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                int res = dt.Rows.Count >= 1 ? 1 : 0;
                return res;
            }
        }


        public DataTable FillItem(string CmpCode, string ItemName,string ItemType,string ItemSubType)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetItemMaster";
                cmdUniversal.Parameters.Add("@CmpCode", SqlDbType.VarChar).Value = CmpCode;
                cmdUniversal.Parameters.Add("@ItemName", SqlDbType.VarChar).Value = ItemName;
                cmdUniversal.Parameters.Add("@ItemType", SqlDbType.VarChar).Value = ItemType;
                cmdUniversal.Parameters.Add("@ItemSubType", SqlDbType.VarChar).Value = ItemSubType;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }
        
        public DataTable RetriveItem1(string ItemCode)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "RetriveItemMaster";
                cmdUniversal.Parameters.Add("@ItemCode", SqlDbType.VarChar).Value = ItemCode;                
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable RetrieveDataByItemCode(int ID)
        {
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            string conn = @"Data Source=208.91.198.174;Initial Catalog=aaliml4n_MVC_ERP;Integrated Security=False;uid=erpmvcuser;password=Mvcerp@123";
            SqlConnection con = new SqlConnection(conn);
            //SqlCommand cmd1 = new SqlCommand("RetriveItemMaster",con);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "RetrieveDataById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = ID;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            nRecAffected = da.Fill(dt);
            return dt;
        }




        public DataTable RetriveItem(string ItemCode)
        {
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            string conn = @"Data Source=DESKTOP-3BL9M8E;Initial Catalog=MVCAKash_Test;Integrated Security=True";

            SqlConnection con = new SqlConnection(conn);
            //SqlCommand cmd1 = new SqlCommand("RetriveItemMaster",con);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "RetriveItemMasterAll";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ItemCode", SqlDbType.VarChar).Value = ItemCode;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            nRecAffected = da.Fill(dt);
             return dt;
          }

        public DataTable AllItem()
        {
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            string conn = @"Data Source=DESKTOP-3BL9M8E;Initial Catalog=MVCAKash_Test;Integrated Security=True";

            SqlConnection con = new SqlConnection(conn);
            //SqlCommand cmd1 = new SqlCommand("RetriveItemMaster",con);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "AllItemMaster";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            nRecAffected = da.Fill(dt);
            return dt;
        }



        public DataTable GetMAXItemNumber(string RawMaterial)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetMaxItemNumber";
                cmdUniversal.Parameters.Add("@RawMaterial", SqlDbType.VarChar).Value = RawMaterial;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable FillItemMasterdetail(string CmpCode, string ItemName, string ItemType, string ItemSubType,int flag)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetItemMasterDetails";
                cmdUniversal.Parameters.Add("@CmpCode", SqlDbType.VarChar).Value = CmpCode;
                cmdUniversal.Parameters.Add("@ItemName", SqlDbType.VarChar).Value = ItemName;
                cmdUniversal.Parameters.Add("@ItemType", SqlDbType.VarChar).Value = ItemType;
                cmdUniversal.Parameters.Add("@ItemSubType", SqlDbType.VarChar).Value = ItemSubType;
                cmdUniversal.Parameters.Add("@Flag", SqlDbType.Int).Value = flag;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }
    }
}
