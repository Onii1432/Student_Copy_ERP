
using System;
using System.Data;
using System.Data.SqlClient;
using StandardMetals.MODEL;

namespace StandardMetals.DAL
{
    public class PurchaseIndentApril2026DAL : ConncetionClass
    {
        public DataTable GetIndentNoAutoGenApril2026()
        {
            this.Initialize();
            DataTable dt = new DataTable();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "indentgetall";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Clear();
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable GetIndentTypeApril2026()
        {
            this.Initialize();
            DataTable dt = new DataTable();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "indentTypegetall";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Clear();
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable GetItemTypeApril2026()
        {
            this.Initialize();
            DataTable dt = new DataTable();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "itemTypegetall";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Clear();
                this.daUniversal.SelectCommand = cmdUniversal;
                cmdUniversal.Parameters.Clear();
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable GetItemnameTypeApril2026()
        {
            this.Initialize();
            DataTable dt = new DataTable();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "itemTypeNamegetall";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Clear();
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable GetDepartmentApril2026()
        {
            this.Initialize();
            DataTable dt = new DataTable();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "DepartmentGetall";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Clear();
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable GetUnitApril2026()
        {
            this.Initialize();
            DataTable dt = new DataTable();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "UnitGetall";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Clear();
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable GetItemDetailsApril2026(string itemName)
        {
            this.Initialize();
            DataTable dt = new DataTable();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "usp_GetItemDetailsByName";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Clear();
                cmdUniversal.Parameters.Add("@ItemName", SqlDbType.NVarChar, 100).Value = itemName;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        // Get existing indent header and item details
        public DataSet GetIndentDetailsApril2026(int indentId)
        {
            this.Initialize();
            DataSet ds = new DataSet();

            try
            {
                using (cnUniversal)
                {
                    cmdUniversal.CommandText = "GetIndentDetailsApril2026";
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    cmdUniversal.Parameters.Clear();
                    cmdUniversal.Parameters.Add("@IndentId", SqlDbType.Int).Value = indentId;
                    this.daUniversal.SelectCommand = cmdUniversal;
                    this.cnUniversal.Open();
                    this.daUniversal.Fill(ds);
                }
            }
            catch (Exception ex)
            {
                DataTable errorTable = new DataTable();
                errorTable.Columns.Add("ErrorMessage", typeof(string));
                errorTable.Rows.Add(ex.Message);
                ds.Tables.Add(errorTable);
            }
            finally
            {
                this.Close();
            }

            return ds;
        }

        public DataTable SaveIndentApril2026(PurchaseIndentApril2026Model model)
        {
            DataTable resultTable = new DataTable();

            resultTable.Columns.Add("SaveStatus", typeof(string));
            resultTable.Columns.Add("IndentId", typeof(int));
            resultTable.Columns.Add("IndentNoAutoGen", typeof(string));
            resultTable.Columns.Add("ErrorMessage", typeof(string));

            if (model == null)
            {
                resultTable.Rows.Add("ERROR", 0, "", "Indent information is missing.");
                return resultTable;
            }

            if (model.ItemDetails == null || model.ItemDetails.Count == 0)
            {
                resultTable.Rows.Add("ERROR", 0, "", "Please add at least one item before saving.");
                return resultTable;
            }

            DataTable itemTable = new DataTable();
            itemTable.Columns.Add("ItemCode", typeof(string));
            itemTable.Columns.Add("ItemName", typeof(string));
            itemTable.Columns.Add("Specification", typeof(string));
            itemTable.Columns.Add("DrawingNo", typeof(string));
            itemTable.Columns.Add("DepartmentId", typeof(int));
            itemTable.Columns.Add("Purpose", typeof(string));
            itemTable.Columns.Add("CurrentStock", typeof(decimal));
            itemTable.Columns.Add("RequiredDate", typeof(string));
            itemTable.Columns.Add("ToOrderQuantity", typeof(decimal));
            itemTable.Columns.Add("ToOrderUnit", typeof(string));

            foreach (PurchaseIndentApril2026Model item in model.ItemDetails)
            {
                if (item == null || string.IsNullOrWhiteSpace(item.ItemCode))
                {
                    resultTable.Rows.Add("ERROR", 0, "", "An item is missing its Item Code.");
                    return resultTable;
                }

                string unitName = !string.IsNullOrWhiteSpace(item.ToOrderUnit) ? item.ToOrderUnit : item.UnitName;

                itemTable.Rows.Add(item.ItemCode, (object)item.ItemName ?? DBNull.Value, (object)item.Specification ?? DBNull.Value, (object)item.DrawingNo ?? DBNull.Value, item.DepartmentId, (object)item.Purpose ?? DBNull.Value, item.CurrentStock, item.RequiredDate.ToString("yyyy-MM-dd"), item.ToOrderQuantity, (object)unitName ?? DBNull.Value);
            }

            this.Initialize();

            try
            {
                using (cnUniversal)
                {
                    cmdUniversal.CommandText = "SPCreateIndentApril2026";
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    cmdUniversal.Parameters.Clear();

                    cmdUniversal.Parameters.Add("@IndentTypeId", SqlDbType.Int).Value = model.IndentTypeId;
                    cmdUniversal.Parameters.Add("@IndentDate", SqlDbType.DateTime).Value = model.IndentDate;
                    cmdUniversal.Parameters.Add("@IndentTime", SqlDbType.VarChar, 15).Value = (object)model.IndentTime ?? DBNull.Value;
                    cmdUniversal.Parameters.Add("@Remark", SqlDbType.VarChar, 150).Value = (object)model.Remark ?? DBNull.Value;
                    cmdUniversal.Parameters.Add("@PreparedByCode", SqlDbType.VarChar, 20).Value = (object)model.PreparedByCode ?? DBNull.Value;
                    cmdUniversal.Parameters.Add("@PreparedByName", SqlDbType.VarChar, 50).Value = (object)model.PreparedByName ?? DBNull.Value;

                    SqlParameter itemParameter = cmdUniversal.Parameters.AddWithValue("@ItemDetails", itemTable);
                    itemParameter.SqlDbType = SqlDbType.Structured;
                    itemParameter.TypeName = "dbo.IndentItemListApril2026";

                    this.cnUniversal.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmdUniversal))
                    {
                        adapter.Fill(resultTable);
                    }
                }
            }
            catch (Exception ex)
            {
                resultTable.Rows.Clear();
                resultTable.Rows.Add("ERROR", 0, "", ex.Message);
            }
            finally
            {
                this.Close();
            }

            return resultTable;
        }

        public DataTable UpdateIndentApril2026(PurchaseIndentApril2026Model model)
        {
            DataTable resultTable = new DataTable();

            if (model == null)
            {
                resultTable.Columns.Add("SaveStatus", typeof(string));
                resultTable.Columns.Add("ErrorMessage", typeof(string));
                resultTable.Rows.Add("ERROR", "Indent information is missing.");
                return resultTable;
            }

            if (model.ItemDetails == null || model.ItemDetails.Count == 0)
            {
                resultTable.Columns.Add("SaveStatus", typeof(string));
                resultTable.Columns.Add("ErrorMessage", typeof(string));
                resultTable.Rows.Add("ERROR", "Please add at least one item.");
                return resultTable;
            }

            DataTable itemTable = new DataTable();
            itemTable.Columns.Add("IndentDetailId", typeof(int));
            itemTable.Columns.Add("ItemCode", typeof(string));
            itemTable.Columns.Add("ItemName", typeof(string));
            itemTable.Columns.Add("Specification", typeof(string));
            itemTable.Columns.Add("DrawingNo", typeof(string));
            itemTable.Columns.Add("DepartmentId", typeof(int));
            itemTable.Columns.Add("Purpose", typeof(string));
            itemTable.Columns.Add("CurrentStock", typeof(decimal));
            itemTable.Columns.Add("RequiredDate", typeof(string));
            itemTable.Columns.Add("ToOrderQuantity", typeof(decimal));
            itemTable.Columns.Add("ToOrderUnit", typeof(string));

            foreach (PurchaseIndentApril2026Model item in model.ItemDetails)
            {
                if (item == null || string.IsNullOrWhiteSpace(item.ItemCode))
                {
                    resultTable.Columns.Add("SaveStatus", typeof(string));
                    resultTable.Columns.Add("ErrorMessage", typeof(string));
                    resultTable.Rows.Add("ERROR", "An item is missing its Item Code.");
                    return resultTable;
                }

                string unitName = !string.IsNullOrWhiteSpace(item.ToOrderUnit) ? item.ToOrderUnit : item.UnitName;
                string requiredDate = item.RequiredDate == DateTime.MinValue ? "" : item.RequiredDate.ToString("yyyy-MM-dd");

                itemTable.Rows.Add(
                    item.IndentDetailId,
                    item.ItemCode,
                    (object)item.ItemName ?? DBNull.Value,
                    (object)item.Specification ?? DBNull.Value,
                    (object)item.DrawingNo ?? DBNull.Value,
                    item.DepartmentId,
                    (object)item.Purpose ?? DBNull.Value,
                    item.CurrentStock,
                    requiredDate,
                    item.ToOrderQuantity,
                    (object)unitName ?? DBNull.Value
                );
            }

            this.Initialize();

            try
            {
                using (cnUniversal)
                {
                    cmdUniversal.CommandText = "SPUpdateIndentApril2026";
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    cmdUniversal.Parameters.Clear();

                    cmdUniversal.Parameters.Add("@IndentId", SqlDbType.Int).Value = model.IndentId;
                    cmdUniversal.Parameters.Add("@IndentTypeId", SqlDbType.Int).Value = model.IndentTypeId;
                    cmdUniversal.Parameters.Add("@IndentDate", SqlDbType.DateTime).Value = model.IndentDate;
                    cmdUniversal.Parameters.Add("@IndentTime", SqlDbType.VarChar, 15).Value = (object)model.IndentTime ?? DBNull.Value;
                    cmdUniversal.Parameters.Add("@Remark", SqlDbType.VarChar, 150).Value = (object)model.Remark ?? DBNull.Value;

                    SqlParameter itemParameter = cmdUniversal.Parameters.AddWithValue("@ItemDetails", itemTable);
                    itemParameter.SqlDbType = SqlDbType.Structured;
                    itemParameter.TypeName = "dbo.IndentItemUpdateListApril2026";

                    this.cnUniversal.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmdUniversal))
                    {
                        adapter.Fill(resultTable);
                    }
                }
            }
            catch (Exception ex)
            {
                resultTable = new DataTable();
                resultTable.Columns.Add("SaveStatus", typeof(string));
                resultTable.Columns.Add("ErrorMessage", typeof(string));
                resultTable.Rows.Add("ERROR", ex.Message);
            }
            finally
            {
                this.Close();
            }

            return resultTable;
        }
    }
}



