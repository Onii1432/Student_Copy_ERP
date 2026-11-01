using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using StandardMetals.MODEL;
using System.Data.SqlClient;


namespace StandardMetals.DAL
{
    public class ItemMaster_DAL_27March : ConncetionClass
    {

        public DataTable FillItemMaster()
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

        public DataTable BindManufacturer()
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

        public DataTable BindColor()
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindColourMaster";

                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }


        public DataTable BindUOM()
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindUnitMaster";

                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public int Save_ItemMaster_27March(ItemMaster_MODEL_27March model)
        {
            int nRecAffected = 0;
            try
            {
                this.Initialize();

                using (cmdUniversal)
                {
                    cnUniversal.Open();
                    cmdUniversal = new SqlCommand("Save_ItemMaster_27March", cnUniversal);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);
                    // cmdUniversal.Parameters["@ItemCode"].Value = dbItem.ItemCode;
                    cmdUniversal.Parameters["@ItemName"].Value = model.ItemName;
                    cmdUniversal.Parameters["@ManufacturerId"].Value = model.ManufacturerId;
                    cmdUniversal.Parameters["@Material"].Value = model.Material;

                    cmdUniversal.Parameters["@ColorId"].Value = model.ColourId;
                    cmdUniversal.Parameters["@HSNCODE"].Value = model.HSNCODE;
                    cmdUniversal.Parameters["@UOMId"].Value = model.UOMId;
                    cmdUniversal.Parameters["@GSTRate"].Value = model.GSTRate;
                    cmdUniversal.Parameters["@PurchaseCost"].Value = model.PurchaseCost;
                    cmdUniversal.Parameters["@SellingPrice"].Value = model.SellingPrice;

                    cmdUniversal.Parameters["@UserId"].Value = model.UserId;
                    cmdUniversal.Parameters["@LoginBranchId"].Value = model.LoginBranchId;
                    //cmdUniversal.Parameters["@SystemEntryDate"].Value = System.DateTime.Now;
                    cmdUniversal.Parameters["@RawMaterial"].Value = model.RawMaterial;
                    cmdUniversal.Parameters["@ItemCategoryId"].Value = model.ItemCategeryId;
                    cmdUniversal.Parameters["@ItemSubCategoryId"].Value = model.ItemSubCatogoryId;

                    nRecAffected = cmdUniversal.ExecuteNonQuery();
                    this.Close();

                }
            }
            catch (Exception ex)
            {

            }
            return nRecAffected;
        }


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

        public int Update_ItemMaster_27March(ItemMaster_MODEL_27March model)
        {
            int nRecAffected = 0;
            try
            {
                this.Initialize();

                using (cmdUniversal)
                {
                    cnUniversal.Open();
                    cmdUniversal = new SqlCommand("Update_ItemMaster_27March", cnUniversal);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);

                    cmdUniversal.Parameters["@ItemCode"].Value = model.ItemCode;
                    cmdUniversal.Parameters["@ItemName"].Value = model.ItemName;
                    cmdUniversal.Parameters["@ManufacturerId"].Value = model.ManufacturerId;
                    cmdUniversal.Parameters["@Material"].Value = model.Material;

                    cmdUniversal.Parameters["@ColorId"].Value = model.ColourId;
                    cmdUniversal.Parameters["@HSNCODE"].Value = model.HSNCODE;
                    cmdUniversal.Parameters["@UOMId"].Value = model.UOMId;
                    cmdUniversal.Parameters["@GSTRate"].Value = model.GSTRate;
                    cmdUniversal.Parameters["@PurchaseCost"].Value = model.PurchaseCost;
                    cmdUniversal.Parameters["@SellingPrice"].Value = model.SellingPrice;

                    cmdUniversal.Parameters["@UserId"].Value = model.UserId;
                    cmdUniversal.Parameters["@LoginBranchId"].Value = model.LoginBranchId;
                    //cmdUniversal.Parameters["@SystemEntryDate"].Value = System.DateTime.Now;
                    cmdUniversal.Parameters["@RawMaterial"].Value = model.RawMaterial;
                    cmdUniversal.Parameters["@ItemCategoryId"].Value = model.ItemCategeryId;
                    cmdUniversal.Parameters["@ItemSubCategoryId"].Value = model.ItemSubCatogoryId;

                    nRecAffected = cmdUniversal.ExecuteNonQuery();
                    this.Close();

                }
            }
            catch (Exception ex)
            {

            }
            return nRecAffected;
        }

        public DataTable Search_ItemMaster_March27(string ItemCode)
        {
            {
                this.Initialize();
                int nRecAffected = 0;
                DataTable dt = new DataTable();
                using (cnUniversal)
                {
                    cmdUniversal.CommandText = "Search_ItemMaster_March27";
                    cmdUniversal.Parameters.Add("@ItemCode", SqlDbType.VarChar).Value = ItemCode;
                    this.daUniversal.SelectCommand = cmdUniversal;
                    this.cnUniversal.Open();
                    nRecAffected = this.daUniversal.Fill(dt);
                    this.Close();
                    return dt;
                }
            }
        }
    }
}
