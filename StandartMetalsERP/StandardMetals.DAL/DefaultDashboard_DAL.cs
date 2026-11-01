using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using StandardMetals.MODEL;
using StandardMetals.CommonLibrary;

namespace StandardMetals.DAL
{
    public class DefaultDashboard_DAL
    {
        string str = @"Data Source = ONKAR\SQLEXPRESS16; Initial Catalog = aaliml4n_MVC_ERPNEW1; Integrated Security = True;";

        public DefaultDashboardModel GetSupplierWiseItemDashboard()
        {
            LogInfo.LogDetailToFile("DefaultDashboard_DAL-GetSupplierWiseItemDashboard - Start");

            DefaultDashboardModel model = new DefaultDashboardModel();
            model.SupplierWiseItems = new List<SupplierWiseItemModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    SqlCommand command = new SqlCommand("SP_GetSupplierWiseItemDashboard", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("GetSupplierWiseItemDashboard - Stored Procedure : SP_GetSupplierWiseItemDashboard");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet set = new DataSet();
                    adapter.Fill(set);

                    if (set.Tables.Count > 0)
                    {
                        foreach (DataRow row in set.Tables[0].Rows)
                        {
                            model.SupplierWiseItems.Add(new SupplierWiseItemModel
                            {
                                SupplierName = row["SupplierName"] == DBNull.Value ? "" : row["SupplierName"].ToString(),
                                ItemCount = row["ItemCount"] == DBNull.Value ? 0 : Convert.ToInt32(row["ItemCount"])
                            });
                        }

                        LogInfo.LogDetailToFile("GetSupplierWiseItemDashboard - Supplier Wise Item Data Loaded : " + model.SupplierWiseItems.Count);
                    }

                    if (set.Tables.Count > 1 && set.Tables[1].Rows.Count > 0)
                    {
                        DataRow row = set.Tables[1].Rows[0];

                        model.TotalSupplierCount = row["TotalSupplierCount"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalSupplierCount"]);

                        LogInfo.LogDetailToFile("GetSupplierWiseItemDashboard - Total Supplier Count : " + model.TotalSupplierCount);
                    }

                    if (set.Tables.Count > 2 && set.Tables[2].Rows.Count > 0)
                    {
                        DataRow row = set.Tables[2].Rows[0];

                        model.TotalItemCount = row["TotalItemCount"] == DBNull.Value ? 0 : Convert.ToInt32(row["TotalItemCount"]);

                        LogInfo.LogDetailToFile("GetSupplierWiseItemDashboard - Total Item Count : " + model.TotalItemCount);
                    }
                }

                LogInfo.LogDetailToFile("DefaultDashboard_DAL-GetSupplierWiseItemDashboard - Start-End");

                return model;
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("GetSupplierWiseItemDashboard - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("DefaultDashboard_DAL-GetSupplierWiseItemDashboard - Start-End");

                throw;
            }
        }
    }
}

