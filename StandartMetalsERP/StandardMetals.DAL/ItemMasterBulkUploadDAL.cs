
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace StandardMetals.DAL
{
    public class ItemMasterBulkUploadDAL
    {
        // GET CONNECTION FROM WEB.CONFIG

        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["ERPConnection"].ConnectionString);
        }

        // 1. INSERT UPLOAD MASTER

        public int InsertUploadMaster(string fileName)
        {
            using (SqlConnection con = GetConnection())
            using (SqlCommand cmd = new SqlCommand("UpdateMasterInsertIMAug25", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FileNames", SqlDbType.VarChar, 200).Value = fileName;
                cmd.Parameters.Add("@UploadType", SqlDbType.VarChar, 50).Value = "ItemMaster";

                con.Open();
                object result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                    return 0;

                return Convert.ToInt32(result);
            }
        }

        // 2. BULK INSERT ITEM MASTER

        public void BulkInsertItemMaster(DataTable excelData, int uploadId)
        {
            if (excelData == null)
                throw new ArgumentNullException("excelData");

            DataTable stagingData = new DataTable();

            stagingData.Columns.Add("ItemCode", typeof(string));
            stagingData.Columns.Add("ItemName", typeof(string));
            stagingData.Columns.Add("Material", typeof(string));
            stagingData.Columns.Add("HSNCODE", typeof(string));
            stagingData.Columns.Add("GSTRate", typeof(string));
            stagingData.Columns.Add("PurchaseCost", typeof(string));
            stagingData.Columns.Add("SellingPrice", typeof(string));
            stagingData.Columns.Add("ManufacturerName", typeof(string));
            stagingData.Columns.Add("ColourName", typeof(string));
            stagingData.Columns.Add("UnitName", typeof(string));
            stagingData.Columns.Add("CategoryName", typeof(string));
            stagingData.Columns.Add("SubCategoryName", typeof(string));
            stagingData.Columns.Add("UploadId", typeof(int));

            foreach (DataRow excelRow in excelData.Rows)
            {
                DataRow newRow = stagingData.NewRow();

                newRow["ItemCode"] = GetExcelValue(excelRow, "Item Code", "ItemCode");
                newRow["ItemName"] = GetExcelValue(excelRow, "Item Name", "ItemName");
                newRow["Material"] = GetExcelValue(excelRow, "Material");
                newRow["HSNCODE"] = GetExcelValue(excelRow, "HSN-Code", "HSNCODE");
                newRow["GSTRate"] = GetExcelValue(excelRow, "GST Rate", "GSTRate");
                newRow["PurchaseCost"] = GetExcelValue(excelRow, "Purchase Cost", "PurchaseCost");
                newRow["SellingPrice"] = GetExcelValue(excelRow, "Selling Price", "SellingPrice");
                newRow["ManufacturerName"] = GetExcelValue(excelRow, "Manufacture", "ManufacturerName", "Manufacturer");
                newRow["ColourName"] = GetExcelValue(excelRow, "Colour", "ColourName");
                newRow["UnitName"] = GetExcelValue(excelRow, "Unit", "UnitName");
                newRow["CategoryName"] = GetExcelValue(excelRow, "Category", "CategoryName");
                newRow["SubCategoryName"] = GetExcelValue(excelRow, "Sub Category", "SubCategoryName", "SubCategory");
                newRow["UploadId"] = uploadId;

                stagingData.Rows.Add(newRow);
            }

            using (SqlConnection con = GetConnection())
            {
                con.Open();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con))
                {
                    bulkCopy.DestinationTableName = "dbo.ItemMaster_DummyExcel";

                    bulkCopy.ColumnMappings.Add("ItemCode", "ItemCode");
                    bulkCopy.ColumnMappings.Add("ItemName", "ItemName");
                    bulkCopy.ColumnMappings.Add("Material", "Material");
                    bulkCopy.ColumnMappings.Add("HSNCODE", "HSNCODE");
                    bulkCopy.ColumnMappings.Add("GSTRate", "GSTRate");
                    bulkCopy.ColumnMappings.Add("PurchaseCost", "PurchaseCost");
                    bulkCopy.ColumnMappings.Add("SellingPrice", "SellingPrice");
                    bulkCopy.ColumnMappings.Add("ManufacturerName", "ManufacturerName");
                    bulkCopy.ColumnMappings.Add("ColourName", "ColourName");
                    bulkCopy.ColumnMappings.Add("UnitName", "UnitName");
                    bulkCopy.ColumnMappings.Add("CategoryName", "CategoryName");
                    bulkCopy.ColumnMappings.Add("SubCategoryName", "SubCategoryName");
                    bulkCopy.ColumnMappings.Add("UploadId", "UploadId");

                    bulkCopy.WriteToServer(stagingData);
                }
            }
        }

        // 3. VALIDATE ITEM MASTER AND GET COUNTS

        public DataTable ValidateItemMasterUpload(int uploadId)
        {
            using (SqlConnection con = GetConnection())
            using (SqlCommand cmd = new SqlCommand("ValidateItemMasterAug25", con))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UploadId", SqlDbType.Int).Value = uploadId;

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }

        // 4. GET FAILED ITEM MASTER RECORDS

        public DataTable GetFailedItemMasterRecords(int uploadId)
        {
            using (SqlConnection con = GetConnection())
            using (SqlCommand cmd = new SqlCommand("GetByUploadIdFailItemIMAug25", con))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UploadId", SqlDbType.Int).Value = uploadId;

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }

        // 5. GET EXCEL COLUMN VALUE

        private string GetExcelValue(DataRow row, params string[] names)
        {
            foreach (string name in names)
            {
                foreach (DataColumn column in row.Table.Columns)
                {
                    if (string.Equals(column.ColumnName.Trim(), name, StringComparison.OrdinalIgnoreCase))
                    {
                        if (row[column] == DBNull.Value)
                            return null;

                        string value = Convert.ToString(row[column]);
                        return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
                    }
                }
            }

            return null;
        }
    }
}
