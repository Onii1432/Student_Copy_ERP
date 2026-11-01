using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using StandardMetals.MODEL;
using StandardMetals.CommonLibrary;

namespace StandardMetals.DAL
{
    public sealed class ItemList17Dec_Dal
    {
        private ItemList17Dec_Dal()
        {
            LogInfo.LogDetailToFile("ItemList17Dec_Dal Constructor Action");
        }

        private static ItemList17Dec_Dal obj;

        public static ItemList17Dec_Dal GetInstance()
        {
            LogInfo.LogDetailToFile("ItemList17Dec_Dal GetInstance Static Action");

            if (obj == null)
            {
                LogInfo.LogDetailToFile("Object Initialized");

                obj = new ItemList17Dec_Dal();
            }

            return obj;
        }

        ConnectionClass connectionClass = new ConnectionClass();

        // Get All Item Master Data

        public List<ItemMaster_Modal_AprBtch> GetAllItemMasterDAL()
        {
            LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetAllItemMasterDAL - Start");

            List<ItemMaster_Modal_AprBtch> list = new List<ItemMaster_Modal_AprBtch>();

            try
            {
                using (SqlConnection conn = connectionClass.GetConnection())
                {
                    SqlCommand command = new SqlCommand("GetAllItem", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("GetAllItemMasterDAL - Stored Procedure : GetAllItem");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet set = new DataSet();
                    adapter.Fill(set);

                    LogInfo.LogDetailToFile("GetAllItemMasterDAL - Item Data Loaded");

                    DataTable table = set.Tables[0];

                    foreach (DataRow row in table.Rows)
                    {
                        list.Add(new ItemMaster_Modal_AprBtch()
                        {
                            Id = row["ID"] == DBNull.Value ? 0 : Convert.ToInt32(row["ID"]),
                            ItemCode = row["ItemCode"] == DBNull.Value ? "" : row["ItemCode"].ToString(),
                            ItemName = row["ItemName"] == DBNull.Value ? "" : row["ItemName"].ToString(),
                            Material = row["Material"] == DBNull.Value ? "" : row["Material"].ToString(),
                            HSNCODE = row["HSNCODE"] == DBNull.Value ? "" : row["HSNCODE"].ToString(),
                            GSTRate = row["GSTRate"] == DBNull.Value ? 0 : Convert.ToDouble(row["GSTRate"]),
                            PurchaseCost = row["PurchaseCost"] == DBNull.Value ? 0 : Convert.ToDouble(row["PurchaseCost"]),
                            SellingPrice = row["SellingPrice"] == DBNull.Value ? 0 : Convert.ToDouble(row["SellingPrice"]),
                            CategoryId = row["CategoryId"] == DBNull.Value ? 0 : Convert.ToInt32(row["CategoryId"]),
                            CategoryName = row["CategoryName"] == DBNull.Value ? "" : row["CategoryName"].ToString(),
                            SubCategoryId = row["SubCategoryId"] == DBNull.Value ? 0 : Convert.ToInt32(row["SubCategoryId"]),
                            SubCategoryName = row["SubCategoryName"] == DBNull.Value ? "" : row["SubCategoryName"].ToString(),
                            ManufactureId = row["ManufacturerId"] == DBNull.Value ? 0 : Convert.ToInt32(row["ManufacturerId"]),
                            ManufactureName = row["ManufacturerName"] == DBNull.Value ? "" : row["ManufacturerName"].ToString(),
                            ColourId = row["ColourId"] == DBNull.Value ? 0 : Convert.ToInt32(row["ColourId"]),
                            ColourName = row["ColourName"] == DBNull.Value ? "" : row["ColourName"].ToString(),
                            UnitId = row["UnitId"] == DBNull.Value ? 0 : Convert.ToInt32(row["UnitId"]),
                            UnitName = row["UnitName"] == DBNull.Value ? "" : row["UnitName"].ToString()
                        });
                    }
                }

                LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetAllItemMasterDAL - Start-End");

                return list;
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("GetAllItemMasterDAL - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetAllItemMasterDAL - Start-End");

                throw;
            }
        }


        // Save New Item + Supplier Mapping + Customer Mapping

        public string SaveNewItemDetails(ItemMaster_Modal_AprBtch model)
        {
            LogInfo.LogDetailToFile("ItemList17Dec_Dal-SaveNewItemDetails - Start");

            try
            {
                LogInfo.LogDetailToFile("SaveNewItemDetails - Item Name : " + model.ItemName);

                object result = null;

                using (SqlConnection conn = connectionClass.GetConnection())
                {
                    SqlCommand command = new SqlCommand("SPCreateItem1", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("SaveNewItemDetails - Stored Procedure : SPCreateItem1");

                    command.Parameters.AddWithValue("@ItemName", model.ItemName);
                    command.Parameters.AddWithValue("@ManufacturerId", model.ManufactureId);
                    command.Parameters.AddWithValue("@Material", model.Material);
                    command.Parameters.AddWithValue("@CategoryId", model.CategoryId);
                    command.Parameters.AddWithValue("@SubCategoryId", model.SubCategoryId);
                    command.Parameters.AddWithValue("@ColourId", model.ColourId);
                    command.Parameters.AddWithValue("@UnitId", model.UnitId);
                    command.Parameters.AddWithValue("@HSNCode", model.HSNCODE);
                    command.Parameters.AddWithValue("@GSTRate", model.GSTRate);
                    command.Parameters.AddWithValue("@PurchaseCost", model.PurchaseCost);
                    command.Parameters.AddWithValue("@SellingPrice", model.SellingPrice);

                    // Create TVP for all selected Suppliers

                    DataTable supplierTable = new DataTable();
                    supplierTable.Columns.Add("SupplierId", typeof(int));

                    foreach (int supplierId in model.SupplierIds)
                    {
                        supplierTable.Rows.Add(supplierId);
                    }

                    SqlParameter supplierParameter = command.Parameters.AddWithValue("@SupplierList", supplierTable);
                    supplierParameter.SqlDbType = SqlDbType.Structured;
                    supplierParameter.TypeName = "dbo.SupplierIdTable";

                    // Create TVP for all selected Customers

                    DataTable customerTable = new DataTable();
                    customerTable.Columns.Add("CustomerId", typeof(int));

                    foreach (int customerId in model.CustomerIds)
                    {
                        customerTable.Rows.Add(customerId);
                    }

                    SqlParameter customerParameter = command.Parameters.AddWithValue("@CustomerList", customerTable);
                    customerParameter.SqlDbType = SqlDbType.Structured;
                    customerParameter.TypeName = "dbo.CustomerIdTable";

                    conn.Open();

                    result = command.ExecuteScalar();

                    LogInfo.LogDetailToFile("SaveNewItemDetails - Execute Result : " +
                        (result == null ? "NULL" : result.ToString()));

                    if (result == null)
                    {
                        LogInfo.LogDetailToFile("SaveNewItemDetails - Unable To Save Item");
                        LogInfo.LogDetailToFile("ItemList17Dec_Dal-SaveNewItemDetails - Start-End");

                        return "";
                    }

                    if (result.ToString() == "DUPLICATE_ITEM")
                    {
                        LogInfo.LogDetailToFile("SaveNewItemDetails - Duplicate Item Found");
                        LogInfo.LogDetailToFile("ItemList17Dec_Dal-SaveNewItemDetails - Start-End");

                        return "DUPLICATE_ITEM";
                    }
                }

                LogInfo.LogDetailToFile("ItemList17Dec_Dal-SaveNewItemDetails - Start-End");

                return result.ToString();
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("SaveNewItemDetails - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("ItemList17Dec_Dal-SaveNewItemDetails - Start-End");

                throw;
            }
        }


        // Save New Item for JQuery Item Master form

        public string SaveItemJW(ItemMaster_Modal_AprBtch model)
        {
            LogInfo.LogDetailToFile("ItemList17Dec_Dal-SaveItemJW - Start");

            try
            {
                LogInfo.LogDetailToFile("SaveItemJW - Item Name : " + model.ItemName);

                using (SqlConnection conn = connectionClass.GetConnection())
                {
                    SqlCommand command = new SqlCommand("SPCreateItemJW", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("SaveItemJW - Stored Procedure : SPCreateItemJW");

                    command.Parameters.AddWithValue("@ItemName", model.ItemName);
                    command.Parameters.AddWithValue("@ManufacturerId", model.ManufactureId);
                    command.Parameters.AddWithValue("@Material", model.Material);
                    command.Parameters.AddWithValue("@CategoryId", model.CategoryId);
                    command.Parameters.AddWithValue("@SubCategoryId", model.SubCategoryId);
                    command.Parameters.AddWithValue("@ColourId", model.ColourId);
                    command.Parameters.AddWithValue("@UnitId", model.UnitId);
                    command.Parameters.AddWithValue("@HSNCode", model.HSNCODE);
                    command.Parameters.AddWithValue("@GSTRate", model.GSTRate);
                    command.Parameters.AddWithValue("@PurchaseCost", model.PurchaseCost);
                    command.Parameters.AddWithValue("@SellingPrice", model.SellingPrice);

                    conn.Open();

                    object result = command.ExecuteScalar();

                    LogInfo.LogDetailToFile("SaveItemJW - Execute Result : " +
                        (result == null ? "NULL" : result.ToString()));

                    if (result == null)
                    {
                        LogInfo.LogDetailToFile("SaveItemJW - Unable To Save Item");
                        LogInfo.LogDetailToFile("ItemList17Dec_Dal-SaveItemJW - Start-End");

                        return "";
                    }

                    LogInfo.LogDetailToFile("ItemList17Dec_Dal-SaveItemJW - Start-End");

                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("SaveItemJW - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("ItemList17Dec_Dal-SaveItemJW - Start-End");

                throw;
            }
        }


        // Get Existing Supplier Details By ItemId

        public List<SupplierMasterMVCApril2026Model> GetSupplierDetailsByItemId(int itemId)
        {
            LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetSupplierDetailsByItemId - Start");

            List<SupplierMasterMVCApril2026Model> list = new List<SupplierMasterMVCApril2026Model>();

            try
            {
                LogInfo.LogDetailToFile("GetSupplierDetailsByItemId - Item Id : " + itemId);

                using (SqlConnection conn = connectionClass.GetConnection())
                {
                    SqlCommand command = new SqlCommand("SP_Oct_GetSupplierDetailsByItemId", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ItemId", itemId);

                    LogInfo.LogDetailToFile("GetSupplierDetailsByItemId - Stored Procedure : SP_Oct_GetSupplierDetailsByItemId");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    LogInfo.LogDetailToFile("GetSupplierDetailsByItemId - Supplier Data Loaded : " + table.Rows.Count);

                    foreach (DataRow row in table.Rows)
                    {
                        list.Add(new SupplierMasterMVCApril2026Model
                        {
                            Id = row["Id"] == DBNull.Value ? 0 : Convert.ToInt32(row["Id"]),
                            SuppCode = row["SuppCode"] == DBNull.Value ? "" : row["SuppCode"].ToString(),
                            SuppName = row["SuppName"] == DBNull.Value ? "" : row["SuppName"].ToString()
                        });
                    }
                }

                LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetSupplierDetailsByItemId - Start-End");

                return list;
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("GetSupplierDetailsByItemId - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetSupplierDetailsByItemId - Start-End");

                throw;
            }
        }


        // Get Existing Customer Details By ItemId

        public List<CustomerMasterMVCApril2026Model> GetCustomerDetailsByItemId(int itemId)
        {
            LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetCustomerDetailsByItemId - Start");

            List<CustomerMasterMVCApril2026Model> list = new List<CustomerMasterMVCApril2026Model>();

            try
            {
                LogInfo.LogDetailToFile("GetCustomerDetailsByItemId - Item Id : " + itemId);

                using (SqlConnection conn = connectionClass.GetConnection())
                {
                    SqlCommand command = new SqlCommand("SP_GetCustomerDetailsByItemId", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ItemId", itemId);

                    LogInfo.LogDetailToFile("GetCustomerDetailsByItemId - Stored Procedure : SP_GetCustomerDetailsByItemId");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    LogInfo.LogDetailToFile("GetCustomerDetailsByItemId - Customer Data Loaded : " + table.Rows.Count);

                    foreach (DataRow row in table.Rows)
                    {
                        list.Add(new CustomerMasterMVCApril2026Model
                        {
                            Id = row["Id"] == DBNull.Value ? 0 : Convert.ToInt32(row["Id"]),
                            CustCode = row["CustCode"] == DBNull.Value ? "" : row["CustCode"].ToString(),
                            CustName = row["CustName"] == DBNull.Value ? "" : row["CustName"].ToString()
                        });
                    }
                }

                LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetCustomerDetailsByItemId - Start-End");

                return list;
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("GetCustomerDetailsByItemId - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetCustomerDetailsByItemId - Start-End");

                throw;
            }
        }


        // Get Item Details By ID

        public ItemMaster_Modal_AprBtch GetItemDetailsByID(int itemId)
        {
            LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetItemDetailsByID - Start");

            try
            {
                LogInfo.LogDetailToFile("GetItemDetailsByID - Item Id : " + itemId);

                using (SqlConnection conn = connectionClass.GetConnection())
                {
                    SqlCommand command = new SqlCommand("editbyidfeb25", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", itemId);

                    LogInfo.LogDetailToFile("GetItemDetailsByID - Stored Procedure : editbyidfeb25");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet set = new DataSet();
                    adapter.Fill(set);

                    LogInfo.LogDetailToFile("GetItemDetailsByID - Item Data Loaded");

                    DataTable table = set.Tables[0];

                    ItemMaster_Modal_AprBtch model = new ItemMaster_Modal_AprBtch()
                    {
                        Id = itemId,
                        ItemCode = table.Rows[0]["ItemCode"] == DBNull.Value ? "" : table.Rows[0]["ItemCode"].ToString(),
                        ItemName = table.Rows[0]["ItemName"] == DBNull.Value ? "" : table.Rows[0]["ItemName"].ToString(),
                        Material = table.Rows[0]["Material"] == DBNull.Value ? "" : table.Rows[0]["Material"].ToString(),
                        GSTRate = table.Rows[0]["GSTRate"] == DBNull.Value ? 0 : Convert.ToDouble(table.Rows[0]["GSTRate"]),
                        PurchaseCost = table.Rows[0]["PurchaseCost"] == DBNull.Value ? 0 : Convert.ToDouble(table.Rows[0]["PurchaseCost"]),
                        SellingPrice = table.Rows[0]["SellingPrice"] == DBNull.Value ? 0 : Convert.ToDouble(table.Rows[0]["SellingPrice"]),
                        CategoryId = table.Rows[0]["CategoryId"] == DBNull.Value ? 0 : Convert.ToInt32(table.Rows[0]["CategoryId"]),
                        SubCategoryId = table.Rows[0]["SubCategoryId"] == DBNull.Value ? 0 : Convert.ToInt32(table.Rows[0]["SubCategoryId"]),
                        ManufactureId = table.Rows[0]["ManufacturerId"] == DBNull.Value ? 0 : Convert.ToInt32(table.Rows[0]["ManufacturerId"]),
                        ColourId = table.Rows[0]["ColourId"] == DBNull.Value ? 0 : Convert.ToInt32(table.Rows[0]["ColourId"]),
                        UnitId = table.Rows[0]["UnitId"] == DBNull.Value ? 0 : Convert.ToInt32(table.Rows[0]["UnitId"]),
                        HSNCODE = table.Rows[0]["HSNCODE"] == DBNull.Value ? "" : table.Rows[0]["HSNCODE"].ToString()
                    };

                    LogInfo.LogDetailToFile("GetItemDetailsByID - Item Details Loaded");
                    LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetItemDetailsByID - Start-End");

                    return model;
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("GetItemDetailsByID - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetItemDetailsByID - Start-End");

                throw;
            }
        }


        // Update Item + Supplier Mapping + Customer Mapping

        public int UpdateItemDetails(int itemId, ItemMaster_Modal_AprBtch model)
        {
            LogInfo.LogDetailToFile("ItemList17Dec_Dal-UpdateItemDetails - Start");

            try
            {
                LogInfo.LogDetailToFile("UpdateItemDetails - Item Id : " + itemId);

                using (SqlConnection conn = connectionClass.GetConnection())
                {
                    SqlCommand command = new SqlCommand("EditItemMasterData", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("UpdateItemDetails - Stored Procedure : EditItemMasterData");

                    command.Parameters.AddWithValue("@ID", itemId);
                    command.Parameters.AddWithValue("@ItemCode", model.ItemCode);
                    command.Parameters.AddWithValue("@ItemName", model.ItemName);
                    command.Parameters.AddWithValue("@ManufacturerId", model.ManufactureId);
                    command.Parameters.AddWithValue("@Material", model.Material);
                    command.Parameters.AddWithValue("@CategoryId", model.CategoryId);
                    command.Parameters.AddWithValue("@SubCategoryId", model.SubCategoryId);
                    command.Parameters.AddWithValue("@ColourId", model.ColourId);
                    command.Parameters.AddWithValue("@UnitId", model.UnitId);
                    command.Parameters.AddWithValue("@HSNCode", model.HSNCODE);
                    command.Parameters.AddWithValue("@GSTRate", model.GSTRate);
                    command.Parameters.AddWithValue("@PurchaseCost", model.PurchaseCost);
                    command.Parameters.AddWithValue("@SellingPrice", model.SellingPrice);

                    // Create TVP for selected Suppliers

                    DataTable supplierTable = new DataTable();
                    supplierTable.Columns.Add("SupplierId", typeof(int));

                    foreach (int supplierId in model.SupplierIds)
                    {
                        supplierTable.Rows.Add(supplierId);
                    }

                    SqlParameter supplierParameter = command.Parameters.AddWithValue("@SupplierList", supplierTable);
                    supplierParameter.SqlDbType = SqlDbType.Structured;
                    supplierParameter.TypeName = "dbo.SupplierIdTable";

                    // Create TVP for selected Customers

                    DataTable customerTable = new DataTable();
                    customerTable.Columns.Add("CustomerId", typeof(int));

                    foreach (int customerId in model.CustomerIds)
                    {
                        customerTable.Rows.Add(customerId);
                    }

                    SqlParameter customerParameter = command.Parameters.AddWithValue("@CustomerList", customerTable);
                    customerParameter.SqlDbType = SqlDbType.Structured;
                    customerParameter.TypeName = "dbo.CustomerIdTable";

                    conn.Open();

                    int result = command.ExecuteNonQuery();

                    LogInfo.LogDetailToFile("UpdateItemDetails - Update Result : " + result);

                    LogInfo.LogDetailToFile("ItemList17Dec_Dal-UpdateItemDetails - Start-End");

                    return result;
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("UpdateItemDetails - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("ItemList17Dec_Dal-UpdateItemDetails - Start-End");

                throw;
            }
        }


        // Update Item for JQuery Item Master form

        public string UpdateItemJW(int id, ItemMaster_Modal_AprBtch model)
        {
            LogInfo.LogDetailToFile("ItemList17Dec_Dal-UpdateItemJW - Start");

            try
            {
                LogInfo.LogDetailToFile("UpdateItemJW - Item Id : " + id);

                using (SqlConnection conn = connectionClass.GetConnection())
                {
                    SqlCommand command = new SqlCommand("SPUpdateItemJW", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("UpdateItemJW - Stored Procedure : SPUpdateItemJW");

                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@ItemName", model.ItemName);
                    command.Parameters.AddWithValue("@ManufacturerId", model.ManufactureId);
                    command.Parameters.AddWithValue("@Material", model.Material);
                    command.Parameters.AddWithValue("@CategoryId", model.CategoryId);
                    command.Parameters.AddWithValue("@SubCategoryId", model.SubCategoryId);
                    command.Parameters.AddWithValue("@ColourId", model.ColourId);
                    command.Parameters.AddWithValue("@UnitId", model.UnitId);
                    command.Parameters.AddWithValue("@HSNCode", model.HSNCODE);
                    command.Parameters.AddWithValue("@GSTRate", model.GSTRate);
                    command.Parameters.AddWithValue("@PurchaseCost", model.PurchaseCost);
                    command.Parameters.AddWithValue("@SellingPrice", model.SellingPrice);

                    conn.Open();

                    object result = command.ExecuteScalar();

                    LogInfo.LogDetailToFile("UpdateItemJW - Execute Result : " +
                        (result == null ? "NULL" : result.ToString()));

                    if (result == null)
                    {
                        LogInfo.LogDetailToFile("UpdateItemJW - Unable To Update Item");
                        LogInfo.LogDetailToFile("ItemList17Dec_Dal-UpdateItemJW - Start-End");

                        return "";
                    }

                    LogInfo.LogDetailToFile("ItemList17Dec_Dal-UpdateItemJW - Start-End");

                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("UpdateItemJW - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("ItemList17Dec_Dal-UpdateItemJW - Start-End");

                throw;
            }
        }


        // Getting Colour Data For DropDownList

        public List<ItemMaster_Modal_AprBtch> GetColours()
        {
            LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetColours - Start");

            List<ItemMaster_Modal_AprBtch> list = new List<ItemMaster_Modal_AprBtch>();

            try
            {
                using (SqlConnection conn = connectionClass.GetConnection())
                {
                    SqlCommand command = new SqlCommand("BindColorMaster", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("GetColours - Stored Procedure : BindColorMaster");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet set = new DataSet();
                    adapter.Fill(set);

                    LogInfo.LogDetailToFile("GetColours - Colour Data Loaded");

                    DataTable table = set.Tables[0];

                    foreach (DataRow row in table.Rows)
                    {
                        list.Add(new ItemMaster_Modal_AprBtch()
                        {
                            ColourId = Convert.ToInt32(row["ColourId"]),
                            ColourName = row["ColourName"].ToString()
                        });
                    }
                }

                LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetColours - Start-End");

                return list;
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("GetColours - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetColours - Start-End");

                throw;
            }
        }


        // Getting Manufacturer Data For DropDownList

        public List<ItemMaster_Modal_AprBtch> GetManufacturer()
        {
            LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetManufacturer - Start");

            List<ItemMaster_Modal_AprBtch> list = new List<ItemMaster_Modal_AprBtch>();

            try
            {
                using (SqlConnection conn = connectionClass.GetConnection())
                {
                    SqlCommand command = new SqlCommand("BindManufacturerMaster", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("GetManufacturer - Stored Procedure : BindManufacturerMaster");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet set = new DataSet();
                    adapter.Fill(set);

                    LogInfo.LogDetailToFile("GetManufacturer - Manufacturer Data Loaded");

                    DataTable table = set.Tables[0];

                    foreach (DataRow row in table.Rows)
                    {
                        list.Add(new ItemMaster_Modal_AprBtch()
                        {
                            ManufactureId = Convert.ToInt32(row["ManufacturerId"]),
                            ManufactureName = row["ManufacturerName"].ToString()
                        });
                    }
                }

                LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetManufacturer - Start-End");

                return list;
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("GetManufacturer - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetManufacturer - Start-End");

                throw;
            }
        }


        // Getting Category Data For DropDownList

        public List<ItemMaster_Modal_AprBtch> GetCategories()
        {
            LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetCategories - Start");

            List<ItemMaster_Modal_AprBtch> list = new List<ItemMaster_Modal_AprBtch>();

            try
            {
                using (SqlConnection conn = connectionClass.GetConnection())
                {
                    SqlCommand command = new SqlCommand("BindCategory", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("GetCategories - Stored Procedure : BindCategory");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet set = new DataSet();
                    adapter.Fill(set);

                    LogInfo.LogDetailToFile("GetCategories - Category Data Loaded");

                    DataTable table = set.Tables[0];

                    foreach (DataRow row in table.Rows)
                    {
                        list.Add(new ItemMaster_Modal_AprBtch()
                        {
                            CategoryId = Convert.ToInt32(row["CategoryId"]),
                            CategoryName = row["CategoryName"].ToString()
                        });
                    }
                }

                LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetCategories - Start-End");

                return list;
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("GetCategories - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetCategories - Start-End");

                throw;
            }
        }


        // Getting SubCategory Data For DropDownList

        public List<ItemMaster_Modal_AprBtch> GetSubCategories(int categoryId)
        {
            LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetSubCategories - Start");

            List<ItemMaster_Modal_AprBtch> list = new List<ItemMaster_Modal_AprBtch>();

            try
            {
                LogInfo.LogDetailToFile("GetSubCategories - Category Id : " + categoryId);

                using (SqlConnection conn = connectionClass.GetConnection())
                {
                    SqlCommand command = new SqlCommand("BindSubCategory", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryId", categoryId);

                    LogInfo.LogDetailToFile("GetSubCategories - Stored Procedure : BindSubCategory");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet set = new DataSet();
                    adapter.Fill(set);

                    LogInfo.LogDetailToFile("GetSubCategories - SubCategory Data Loaded");

                    DataTable table = set.Tables[0];

                    foreach (DataRow row in table.Rows)
                    {
                        list.Add(new ItemMaster_Modal_AprBtch()
                        {
                            SubCategoryId = Convert.ToInt32(row["SubCategoryId"]),
                            SubCategoryName = row["SubCategoryName"].ToString()
                        });
                    }
                }

                LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetSubCategories - Start-End");

                return list;
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("GetSubCategories - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetSubCategories - Start-End");

                throw;
            }
        }


        // Getting Unit Data For DropDownList

        public List<ItemMaster_Modal_AprBtch> GetUnit()
        {
            LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetUnit - Start");

            List<ItemMaster_Modal_AprBtch> list = new List<ItemMaster_Modal_AprBtch>();

            try
            {
                using (SqlConnection conn = connectionClass.GetConnection())
                {
                    SqlCommand command = new SqlCommand("BindUnit", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("GetUnit - Stored Procedure : BindUnit");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet set = new DataSet();
                    adapter.Fill(set);

                    LogInfo.LogDetailToFile("GetUnit - Unit Data Loaded");

                    DataTable table = set.Tables[0];

                    foreach (DataRow row in table.Rows)
                    {
                        list.Add(new ItemMaster_Modal_AprBtch()
                        {
                            UnitId = Convert.ToInt32(row["UnitId"]),
                            UnitName = row["UnitName"].ToString()
                        });
                    }
                }

                LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetUnit - Start-End");

                return list;
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("GetUnit - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("ItemList17Dec_Dal-GetUnit - Start-End");

                throw;
            }
        }


        // Get all available ItemCodes

        public List<ItemMaster_Modal_AprBtch> getItemCodes()
        {
            LogInfo.LogDetailToFile("ItemList17Dec_Dal-getItemCodes - Start");

            try
            {
                using (SqlConnection conn = connectionClass.GetConnection())
                {
                    SqlCommand command = new SqlCommand("GetItemCode_Oct25", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("getItemCodes - Stored Procedure : GetItemCode_Oct25");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet set = new DataSet();
                    adapter.Fill(set);

                    LogInfo.LogDetailToFile("getItemCodes - Item Code Data Loaded");

                    DataTable table = set.Tables[0];
                    List<ItemMaster_Modal_AprBtch> list = new List<ItemMaster_Modal_AprBtch>();

                    foreach (DataRow row in table.Rows)
                    {
                        list.Add(new ItemMaster_Modal_AprBtch()
                        {
                            Id = Convert.ToInt32(row["ID"]),
                            ItemCode = row["ItemCode"].ToString()
                        });
                    }

                    LogInfo.LogDetailToFile("ItemList17Dec_Dal-getItemCodes - Start-End");

                    return list;
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("getItemCodes - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("ItemList17Dec_Dal-getItemCodes - Start-End");

                throw;
            }
        }


        // Get all available ItemNames

        public List<ItemMaster_Modal_AprBtch> getItemNames()
        {
            LogInfo.LogDetailToFile("ItemList17Dec_Dal-getItemNames - Start");

            try
            {
                using (SqlConnection conn = connectionClass.GetConnection())
                {
                    SqlCommand command = new SqlCommand("GetItemName_Oct25", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("getItemNames - Stored Procedure : GetItemName_Oct25");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet set = new DataSet();
                    adapter.Fill(set);

                    LogInfo.LogDetailToFile("getItemNames - Item Name Data Loaded");

                    DataTable table = set.Tables[0];
                    List<ItemMaster_Modal_AprBtch> list = new List<ItemMaster_Modal_AprBtch>();

                    foreach (DataRow row in table.Rows)
                    {
                        list.Add(new ItemMaster_Modal_AprBtch()
                        {
                            Id = Convert.ToInt32(row["ID"]),
                            ItemName = row["ItemName"].ToString()
                        });
                    }

                    LogInfo.LogDetailToFile("ItemList17Dec_Dal-getItemNames - Start-End");

                    return list;
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("getItemNames - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("ItemList17Dec_Dal-getItemNames - Start-End");

                throw;
            }
        }
    }
}