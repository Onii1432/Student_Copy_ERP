using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;


namespace StandardMetals.DAL
{
   public class ItemMaster19SeptDAL : ConncetionClass
    {
       public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Manufacturer { get; set; }
        public string Material { get; set; }
        public string ItemType { get; set; }
        public string ItemSubType { get; set; }
        public string Color { get; set; }
        public string UOM { get; set; }
        public string HSNCODE { get; set; }
        public decimal GSTRate { get; set; }
        public decimal PurchaseCost { get; set; }
        public decimal SellingPrice { get; set; }
        public string Username { get; set; }
        public string LoginBranch { get; set; }
        public string RawMaterial { get; set; }
        public int Categoryid { get; set; }
        public int SubCategoryid { get; set; }



        public int 
            SaveItemMaster(ItemMaster19SeptDAL dbItem)
        {
            this.Initialize();
            int nRecAffected = 0;
            using (cmdUniversal)
            {
                cnUniversal.Open();
                cmdUniversal = new SqlCommand("SaveItemMaster", cnUniversal);
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cmdUniversal);
               // cmdUniversal.Parameters["@ItemCode"].Value = dbItem.ItemCode;
                cmdUniversal.Parameters["@ItemName"].Value = dbItem.ItemName;
                cmdUniversal.Parameters["@Manufacturer"].Value = dbItem.Manufacturer;
                cmdUniversal.Parameters["@Material"].Value = dbItem.Material;
                cmdUniversal.Parameters["@ItemType"].Value = dbItem.ItemType;
                cmdUniversal.Parameters["@ItemSubType"].Value = dbItem.ItemSubType;
                cmdUniversal.Parameters["@Color"].Value = dbItem.Color;
                cmdUniversal.Parameters["@HSNCODE"].Value = dbItem.HSNCODE;
                cmdUniversal.Parameters["@UOM"].Value = dbItem.UOM;
                cmdUniversal.Parameters["@GSTRate"].Value = dbItem.GSTRate;
                cmdUniversal.Parameters["@PurchaseCost"].Value = dbItem.PurchaseCost;
                cmdUniversal.Parameters["@SellingPrice"].Value = dbItem.SellingPrice;

                cmdUniversal.Parameters["@username"].Value = dbItem.Username;
                cmdUniversal.Parameters["@LoginBranch"].Value = dbItem.LoginBranch;
                cmdUniversal.Parameters["@SystemEntryDate"].Value = System.DateTime.Now;
                cmdUniversal.Parameters["@RawMaterial"].Value = dbItem.RawMaterial;
                cmdUniversal.Parameters["@CategoryId"].Value = dbItem.Categoryid;
                cmdUniversal.Parameters["@SubCategoryId"].Value = dbItem.SubCategoryid;
                nRecAffected = cmdUniversal.ExecuteNonQuery();
                this.Close();
                return nRecAffected;                
            }

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
       //fill Manufacturer
        public DataTable FillManufacturer()
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
       //fil colour
        public DataTable FillColour()
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

        //fil unitofmeasure
        public DataTable FillUOM()
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
        
        public DataTable RetriveItem(string ItemCode)
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

