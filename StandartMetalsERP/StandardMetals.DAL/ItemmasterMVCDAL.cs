using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StandardMetals.MODEL;

namespace StandardMetals.DAL
{
   public class ItemmasterMVCDAL //:ConncetionClass
    {
        string connectionString = @"Data Source=208.91.198.174;Initial Catalog=aaliml4n_MVC_ERP;Integrated Security=False;uid=erpmvcuser;password=Mvcerp@123";

        public List<ItemMasterMVCModal> GetAllItemMasterDAL()
        {
            List<ItemMasterMVCModal> list = new List<ItemMasterMVCModal>();

            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("GetAllItem", conn);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet set = new DataSet();
                adapter.Fill(set);

                DataTable table = new DataTable();
                table = set.Tables[0];



                foreach (DataRow row in table.Rows)
                {
                    list.Add(new ItemMasterMVCModal()
                    {
                        ID = row["ID"] == DBNull.Value ? 0 : Convert.ToInt32(row["ID"]),
                        ItemCode = row["ItemCode"] == DBNull.Value ? "" : row["ItemCode"].ToString(),
                        ItemName = row["ItemName"].ToString(),
                        Material = row["Material"].ToString(),
                        HSNCODE = row["HSNCODE"].ToString(),
                        GSTRate = Convert.ToDouble(row["GSTRate"]),
                        PurchaseCost = Convert.ToDouble(row["PurchaseCost"]),
                        SellingPrice = Convert.ToDouble(row["SellingPrice"]),
                        CategoryId = Convert.ToInt32(row["CategoryId"]),
                        CategoryName = row["CategoryName"].ToString(),
                        SubCategoryId = Convert.ToInt32(row["SubCategoryId"]),
                        SubCategoryName = row["SubCategoryName"].ToString(),
                        ManufacturerId = Convert.ToInt32(row["ManufacturerId"]),
                        ManufacturerName = row["ManufacturerName"].ToString(),
                        ColourId = Convert.ToInt32(row["ColourId"]),
                        ColourName = row["Color"].ToString(),
                        UnitId = Convert.ToInt32(row["UnitId"]),
                        UnitName = row["UnitName"].ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return list;

        }

        public int SaveNewItemDetails(ItemMasterMVCModal model)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SPCreateItem1", conn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ItemCode", model.ItemCode);
            command.Parameters.AddWithValue("@ItemName", model.ItemName);
            command.Parameters.AddWithValue("@ManufacturerId", model.ManufacturerId);
            command.Parameters.AddWithValue("@Material", model.Material);
            command.Parameters.AddWithValue("@CategoryId", model.CategoryId);
            command.Parameters.AddWithValue("@SubCategoryId", model.SubCategoryId);
            command.Parameters.AddWithValue("@ColourId", model.ColourId);
            command.Parameters.AddWithValue("@UnitId", model.UnitId);
            command.Parameters.AddWithValue("@HSNCODE", model.HSNCODE);
            command.Parameters.AddWithValue("@GSTRate", model.GSTRate);
            command.Parameters.AddWithValue("@PurchaseCost", model.PurchaseCost);
            command.Parameters.AddWithValue("@SellingPrice", model.SellingPrice);

            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();

            return result;
        }


        public ItemMasterMVCModal GetItemDetailsByID(int itemId)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("editbyidfeb25", conn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ID", itemId);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet set = new DataSet();
            adapter.Fill(set);

            DataTable table = new DataTable();
            table = set.Tables[0];

            ItemMasterMVCModal model = new ItemMasterMVCModal()
            {
                ID = itemId,
                ItemCode = table.Rows[0]["ItemCode"] == DBNull.Value ? "" : table.Rows[0]["ItemCode"].ToString(),
                ItemName = table.Rows[0]["ItemName"] == DBNull.Value ? "" : table.Rows[0]["ItemName"].ToString(),
                Material = table.Rows[0]["Material"] == DBNull.Value ? "" : table.Rows[0]["Material"].ToString(),
                GSTRate = table.Rows[0]["GSTRate"] == DBNull.Value ? 0 : Convert.ToDouble(table.Rows[0]["GSTRate"]),
                PurchaseCost = table.Rows[0]["PurchaseCost"] == DBNull.Value ? 0 : Convert.ToDouble(table.Rows[0]["PurchaseCost"]),
                SellingPrice = table.Rows[0]["SellingPrice"] == DBNull.Value ? 0 : Convert.ToDouble(table.Rows[0]["SellingPrice"]),
                CategoryId = table.Rows[0]["CategoryId"] == DBNull.Value ? 0 : Convert.ToInt32(table.Rows[0]["CategoryId"]),
                SubCategoryId = table.Rows[0]["SubCategoryId"] == DBNull.Value ? 0 : Convert.ToInt32(table.Rows[0]["SubCategoryId"]),
                ManufacturerId = table.Rows[0]["ManufacturerId"] == DBNull.Value ? 0 : Convert.ToInt32(table.Rows[0]["ManufacturerId"]),
                ColourId = table.Rows[0]["ColourId"] == DBNull.Value ? 0 : Convert.ToInt32(table.Rows[0]["ColourId"]),
                UnitId = table.Rows[0]["UnitId"] == DBNull.Value ? 0 : Convert.ToInt32(table.Rows[0]["UnitId"]),
                HSNCODE = table.Rows[0]["HSNCODE"] == DBNull.Value ? "" : table.Rows[0]["HSNCODE"].ToString(),
            };

            return model;
        }


        public int UpdateItemDetails(int itemId, ItemMasterMVCModal model)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("EditItemMasterData", conn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ID", itemId);
            command.Parameters.AddWithValue("@ItemCode", model.ItemCode);
            command.Parameters.AddWithValue("@ItemName", model.ItemName);
            command.Parameters.AddWithValue("@ManufacturerId", model.ManufacturerId);
            command.Parameters.AddWithValue("@Material", model.Material);
            command.Parameters.AddWithValue("@CategoryId", model.CategoryId);
            command.Parameters.AddWithValue("@SubCategoryId", model.SubCategoryId);
            command.Parameters.AddWithValue("@ColourId", model.ColourId);
            command.Parameters.AddWithValue("@UnitId", model.UnitId);
            command.Parameters.AddWithValue("@HSNCODE", model.HSNCODE);
            command.Parameters.AddWithValue("@GSTRate", model.GSTRate);
            command.Parameters.AddWithValue("@PurchaseCost", model.PurchaseCost);
            command.Parameters.AddWithValue("@SellingPrice", model.SellingPrice);

            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        // Getting Data For DropDownList

        public List<ItemMasterMVCModal> GetColours()
        {
            List<ItemMasterMVCModal> list = new List<ItemMasterMVCModal>();

            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("BindColorMaster", conn);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet set = new DataSet();
                adapter.Fill(set);

                DataTable table = new DataTable();
                table = set.Tables[0];

                foreach (DataRow row in table.Rows)
                {
                    list.Add(new ItemMasterMVCModal()
                    {
                        ColourId = Convert.ToInt32(row["ColourId"]),
                        ColourName = row["ColourName"].ToString(),
                    });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return list;
        }

        public List<ItemMasterMVCModal> GetManufacturer()
        {
            List<ItemMasterMVCModal> list = new List<ItemMasterMVCModal>();

            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("BindManufacturerMaster", conn);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet set = new DataSet();
                adapter.Fill(set);

                DataTable table = new DataTable();
                table = set.Tables[0];

                foreach (DataRow row in table.Rows)
                {
                    list.Add(new ItemMasterMVCModal()
                    {
                        ManufacturerId = Convert.ToInt32(row["ManufacturerId"]),
                        ManufacturerName = row["ManufacturerName"].ToString(),
                    });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return list;
        }

        public List<ItemMasterMVCModal> GetCategories()
        {
            List<ItemMasterMVCModal> list = new List<ItemMasterMVCModal>();

            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("BindCategory", conn);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet set = new DataSet();
                adapter.Fill(set);

                DataTable table = new DataTable();
                table = set.Tables[0];

                foreach (DataRow row in table.Rows)
                {
                    list.Add(new ItemMasterMVCModal()
                    {
                        CategoryId = Convert.ToInt32(row["CategoryId"]),
                        CategoryName = row["CategoryName"].ToString(),
                    });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return list;
        }

        public List<ItemMasterMVCModal> GetSubCategories(int categoryId)
        {
            List<ItemMasterMVCModal> list = new List<ItemMasterMVCModal>();

            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("BindSubCategory", conn);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@CategoryId", categoryId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet set = new DataSet();
                adapter.Fill(set);

                DataTable table = new DataTable();
                table = set.Tables[0];

                foreach (DataRow row in table.Rows)
                {
                    list.Add(new ItemMasterMVCModal()
                    {
                        SubCategoryId = Convert.ToInt32(row["SubCategoryId"]),
                        SubCategoryName = row["SubCategoryName"].ToString(),
                    });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return list;
        }

        public List<ItemMasterMVCModal> GetUnit()
        {
            List<ItemMasterMVCModal> list = new List<ItemMasterMVCModal>();

            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("BindUnit", conn);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet set = new DataSet();
                adapter.Fill(set);

                DataTable table = new DataTable();
                table = set.Tables[0];

                foreach (DataRow row in table.Rows)
                {
                    list.Add(new ItemMasterMVCModal()
                    {
                        UnitId = Convert.ToInt32(row["UnitId"]),
                        UnitName = row["UnitName"].ToString(),
                    });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return list;
        }




        ///////// For JQUERY Project

        // Get all the available ItemCodes from the database
        public List<ItemMasterMVCModal> getItemCodes()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("GetItemCode_Oct25", conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet set = new DataSet();
            adapter.Fill(set);

            DataTable table = new DataTable();
            table = set.Tables[0];

            List<ItemMasterMVCModal> list = new List<ItemMasterMVCModal>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new ItemMasterMVCModal()
                {
                    ID = Convert.ToInt32(row["ID"]),
                    ItemCode = row["ItemCode"].ToString(),
                });
            }
            return list;
        }

        // Get all the available ItemNames from the database
        public List<ItemMasterMVCModal> getItemNames()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("GetItemName_Oct25", conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet set = new DataSet();
            adapter.Fill(set);

            DataTable table = new DataTable();
            table = set.Tables[0];

            List<ItemMasterMVCModal> list = new List<ItemMasterMVCModal>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new ItemMasterMVCModal()
                {
                    ID = Convert.ToInt32(row["ID"]),
                    ItemName = row["ItemName"].ToString(),
                });
            }
            return list;
        }
    }
}
