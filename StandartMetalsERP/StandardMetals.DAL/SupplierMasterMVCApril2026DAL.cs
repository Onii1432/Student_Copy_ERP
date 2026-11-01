// 27/08/2026

using StandardMetals.MODEL;
using StandardMetals.CommonLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace StandardMetals.DAL
{
    public sealed class SupplierMasterMVCApril2026DAL
    {
        private SupplierMasterMVCApril2026DAL()
        {
            LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL Constructor Action");
        }

        private static SupplierMasterMVCApril2026DAL obj;

        public static SupplierMasterMVCApril2026DAL GetInstance()
        {
            LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL GetInstance Static Action");

            if (obj == null)
            {
                LogInfo.LogDetailToFile("Object Initialized");

                obj = new SupplierMasterMVCApril2026DAL();
            }

            return obj;
        }

        string str = @"Data Source=LAPTOP-C9OTCO0G\SQLEXPRESS;Initial Catalog=aaliml4n_MVC_ERP;Integrated Security=True;";


        // Get All Supplier Master

        public List<SupplierMasterMVCApril2026Model> GetAllSupplierMaster()
        {
            LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-GetAllSupplierMaster - Start");

            List<SupplierMasterMVCApril2026Model> list = new List<SupplierMasterMVCApril2026Model>();

            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetAllSupplierMasterApril2026", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("GetAllSupplierMaster - Stored Procedure : SP_GetAllSupplierMasterApril2026");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    LogInfo.LogDetailToFile("GetAllSupplierMaster - Supplier Data Loaded");

                    foreach (DataRow dr in dt.Rows)
                    {
                        list.Add(MapSupplier(dr));
                    }
                }

                LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-GetAllSupplierMaster - Start-End");

                return list;
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("GetAllSupplierMaster - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-GetAllSupplierMaster - Start-End");
                throw;
            }
        }


        // Get Supplier Master By Id

        public SupplierMasterMVCApril2026Model GetSupplierMasterById(int id)
        {
            LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-GetSupplierMasterById - Start");

            SupplierMasterMVCApril2026Model obj = null;

            try
            {
                LogInfo.LogDetailToFile("GetSupplierMasterById - Supplier Id : " + id);

                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetSupplierMasterByIdApril2026", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    LogInfo.LogDetailToFile("GetSupplierMasterById - Stored Procedure : SP_GetSupplierMasterByIdApril2026");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        obj = MapSupplier(dt.Rows[0]);
                        LogInfo.LogDetailToFile("GetSupplierMasterById - Supplier Details Loaded");
                    }
                    else
                    {
                        LogInfo.LogDetailToFile("GetSupplierMasterById - Supplier Not Found");
                    }
                }

                LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-GetSupplierMasterById - Start-End");

                return obj;
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("GetSupplierMasterById - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-GetSupplierMasterById - Start-End");
                throw;
            }
        }


        // Get Supplier Details By Id For Item Supplier Mapping

        public SupplierMasterMVCApril2026Model GetSupplierDetailsById(int supplierId)
        {
            LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-GetSupplierDetailsById - Start");

            try
            {
                LogInfo.LogDetailToFile("GetSupplierDetailsById - Supplier Id : " + supplierId);

                SupplierMasterMVCApril2026Model obj = GetSupplierMasterById(supplierId);

                if (obj != null)
                {
                    LogInfo.LogDetailToFile("GetSupplierDetailsById - Supplier Details Loaded");
                }
                else
                {
                    LogInfo.LogDetailToFile("GetSupplierDetailsById - Supplier Not Found");
                }

                LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-GetSupplierDetailsById - Start-End");

                return obj;
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("GetSupplierDetailsById - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-GetSupplierDetailsById - Start-End");
                throw;
            }
        }


        // Get Supplier Details By Code For Item Supplier Mapping

        public SupplierMasterMVCApril2026Model GetSupplierDetailsByCode(string suppCode)
        {
            LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-GetSupplierDetailsByCode - Start");

            SupplierMasterMVCApril2026Model obj = null;

            try
            {
                LogInfo.LogDetailToFile("GetSupplierDetailsByCode - Supplier Code : " + suppCode);

                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("FillSupplierDetailsByCode", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SuppCode", SqlDbType.VarChar, 50).Value = (object)suppCode ?? DBNull.Value;

                    LogInfo.LogDetailToFile("GetSupplierDetailsByCode - Stored Procedure : FillSupplierDetailsByCode");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        obj = MapSupplier(dt.Rows[0]);
                        LogInfo.LogDetailToFile("GetSupplierDetailsByCode - Supplier Details Loaded");
                    }
                    else
                    {
                        LogInfo.LogDetailToFile("GetSupplierDetailsByCode - Supplier Not Found");
                    }
                }

                LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-GetSupplierDetailsByCode - Start-End");

                return obj;
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("GetSupplierDetailsByCode - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-GetSupplierDetailsByCode - Start-End");
                throw;
            }
        }


        // Save Supplier Master

        public string SaveSupplierMaster(SupplierMasterMVCApril2026Model obj)
        {
            LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-SaveSupplierMaster - Start");

            string suppCode = "";

            try
            {
                LogInfo.LogDetailToFile("SaveSupplierMaster - Supplier Name : " + obj.SuppName);

                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("SP_SaveSupplierMasterApril2026", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("SaveSupplierMaster - Stored Procedure : SP_SaveSupplierMasterApril2026");

                    cmd.Parameters.Add("@SuppName", SqlDbType.VarChar, 100).Value = (object)obj.SuppName ?? DBNull.Value;
                    cmd.Parameters.Add("@ContactPerson", SqlDbType.VarChar, 100).Value = (object)obj.ContactPerson ?? DBNull.Value;
                    cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = obj.BranchId.HasValue ? (object)obj.BranchId.Value : DBNull.Value;
                    cmd.Parameters.Add("@Address1", SqlDbType.VarChar, 200).Value = (object)obj.Address1 ?? DBNull.Value;
                    cmd.Parameters.Add("@Address2", SqlDbType.VarChar, 200).Value = (object)obj.Address2 ?? DBNull.Value;
                    cmd.Parameters.Add("@CityId", SqlDbType.Int).Value = obj.CityId.HasValue ? (object)obj.CityId.Value : DBNull.Value;
                    cmd.Parameters.Add("@StateId", SqlDbType.Int).Value = obj.StateId.HasValue ? (object)obj.StateId.Value : DBNull.Value;
                    cmd.Parameters.Add("@PinCode", SqlDbType.VarChar, 20).Value = (object)obj.PinCode ?? DBNull.Value;
                    cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = obj.CountryId.HasValue ? (object)obj.CountryId.Value : DBNull.Value;
                    cmd.Parameters.Add("@EmailID", SqlDbType.VarChar, 100).Value = (object)obj.EmailID ?? DBNull.Value;
                    cmd.Parameters.Add("@Telephone", SqlDbType.VarChar, 50).Value = (object)obj.Telephone ?? DBNull.Value;
                    cmd.Parameters.Add("@Mobile", SqlDbType.VarChar, 50).Value = (object)obj.Mobile ?? DBNull.Value;
                    cmd.Parameters.Add("@Fax", SqlDbType.VarChar, 50).Value = (object)obj.Fax ?? DBNull.Value;
                    cmd.Parameters.Add("@Website", SqlDbType.VarChar, 200).Value = (object)obj.Website ?? DBNull.Value;
                    cmd.Parameters.Add("@GSTIN", SqlDbType.VarChar, 50).Value = (object)obj.GSTIN ?? DBNull.Value;
                    cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = (object)obj.Remarks ?? DBNull.Value;
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 100).Value = DBNull.Value;
                    cmd.Parameters.Add("@LoginBranch", SqlDbType.VarChar, 100).Value = DBNull.Value;
                    cmd.Parameters.Add("@supptypeid", SqlDbType.Int).Value = DBNull.Value;
                    cmd.Parameters.Add("@LoginUserId", SqlDbType.Int).Value = DBNull.Value;
                    cmd.Parameters.Add("@IsRawMaterial", SqlDbType.Bit).Value = obj.IsRawMaterial;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            if (dr["SuppCode"] != DBNull.Value)
                            {
                                suppCode = dr["SuppCode"].ToString();
                                LogInfo.LogDetailToFile("SaveSupplierMaster - Supplier Code Generated : " + suppCode);
                            }
                        }
                    }
                }

                LogInfo.LogDetailToFile("SaveSupplierMaster - Supplier Saved");
                LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-SaveSupplierMaster - Start-End");

                return suppCode;
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("SaveSupplierMaster - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-SaveSupplierMaster - Start-End");
                throw;
            }
        }


        // Update Supplier Master

        public int UpdateSupplierMaster(SupplierMasterMVCApril2026Model obj)
        {
            LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-UpdateSupplierMaster - Start");

            try
            {
                LogInfo.LogDetailToFile("UpdateSupplierMaster - Supplier Id : " + obj.Id);
                LogInfo.LogDetailToFile("UpdateSupplierMaster - Supplier Name : " + obj.SuppName);

                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateSupplierMasterApril2026", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("UpdateSupplierMaster - Stored Procedure : SP_UpdateSupplierMasterApril2026");

                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = obj.Id;
                    cmd.Parameters.Add("@SuppName", SqlDbType.VarChar, 100).Value = (object)obj.SuppName ?? DBNull.Value;
                    cmd.Parameters.Add("@ContactPerson", SqlDbType.VarChar, 100).Value = (object)obj.ContactPerson ?? DBNull.Value;
                    cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = obj.BranchId.HasValue ? (object)obj.BranchId.Value : DBNull.Value;
                    cmd.Parameters.Add("@Address1", SqlDbType.VarChar, 200).Value = (object)obj.Address1 ?? DBNull.Value;
                    cmd.Parameters.Add("@Address2", SqlDbType.VarChar, 200).Value = (object)obj.Address2 ?? DBNull.Value;
                    cmd.Parameters.Add("@CityId", SqlDbType.Int).Value = obj.CityId.HasValue ? (object)obj.CityId.Value : DBNull.Value;
                    cmd.Parameters.Add("@StateId", SqlDbType.Int).Value = obj.StateId.HasValue ? (object)obj.StateId.Value : DBNull.Value;
                    cmd.Parameters.Add("@PinCode", SqlDbType.VarChar, 20).Value = (object)obj.PinCode ?? DBNull.Value;
                    cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = obj.CountryId.HasValue ? (object)obj.CountryId.Value : DBNull.Value;
                    cmd.Parameters.Add("@EmailID", SqlDbType.VarChar, 100).Value = (object)obj.EmailID ?? DBNull.Value;
                    cmd.Parameters.Add("@Telephone", SqlDbType.VarChar, 50).Value = (object)obj.Telephone ?? DBNull.Value;
                    cmd.Parameters.Add("@Mobile", SqlDbType.VarChar, 50).Value = (object)obj.Mobile ?? DBNull.Value;
                    cmd.Parameters.Add("@Fax", SqlDbType.VarChar, 50).Value = (object)obj.Fax ?? DBNull.Value;
                    cmd.Parameters.Add("@Website", SqlDbType.VarChar, 200).Value = (object)obj.Website ?? DBNull.Value;
                    cmd.Parameters.Add("@GSTIN", SqlDbType.VarChar, 50).Value = (object)obj.GSTIN ?? DBNull.Value;
                    cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = (object)obj.Remarks ?? DBNull.Value;
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 100).Value = DBNull.Value;
                    cmd.Parameters.Add("@LoginBranch", SqlDbType.VarChar, 100).Value = DBNull.Value;
                    cmd.Parameters.Add("@supptypeid", SqlDbType.Int).Value = DBNull.Value;
                    cmd.Parameters.Add("@LoginUserId", SqlDbType.Int).Value = DBNull.Value;
                    cmd.Parameters.Add("@IsRawMaterial", SqlDbType.Bit).Value = obj.IsRawMaterial;

                    con.Open();

                    object result = cmd.ExecuteScalar();
                    int updateResult = 0;

                    if (result != null && result != DBNull.Value)
                    {
                        updateResult = Convert.ToInt32(result);
                    }

                    LogInfo.LogDetailToFile("UpdateSupplierMaster - Update Result : " + updateResult);
                    LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-UpdateSupplierMaster - Start-End");

                    return updateResult;
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("UpdateSupplierMaster - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-UpdateSupplierMaster - Start-End");
                throw;
            }
        }


        // Delete Supplier Master By Id

        public int DeleteSupplierMasterById(int id)
        {
            LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-DeleteSupplierMasterById - Start");

            try
            {
                LogInfo.LogDetailToFile("DeleteSupplierMasterById - Supplier Id : " + id);

                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("SP_DeleteSupplierMasterApril2026", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    LogInfo.LogDetailToFile("DeleteSupplierMasterById - Stored Procedure : SP_DeleteSupplierMasterApril2026");

                    con.Open();

                    object result = cmd.ExecuteScalar();
                    int deleteResult = 0;

                    if (result != null && result != DBNull.Value)
                    {
                        deleteResult = Convert.ToInt32(result);
                    }

                    LogInfo.LogDetailToFile("DeleteSupplierMasterById - Delete Result : " + deleteResult);
                    LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-DeleteSupplierMasterById - Start-End");

                    return deleteResult;
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("DeleteSupplierMasterById - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-DeleteSupplierMasterById - Start-End");
                throw;
            }
        }


        // Bind Supplier Code

        public DataTable BindSupplierCode()
        {
            LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-BindSupplierCode - Start");

            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("SP_BindSupplierCodeApril2026", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("BindSupplierCode - Stored Procedure : SP_BindSupplierCodeApril2026");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    LogInfo.LogDetailToFile("BindSupplierCode - Supplier Code Data Loaded");
                    LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-BindSupplierCode - Start-End");

                    return dt;
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("BindSupplierCode - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-BindSupplierCode - Start-End");
                throw;
            }
        }


        // Bind Supplier Name

        public DataTable BindSupplierName()
        {
            LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-BindSupplierName - Start");

            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("SP_BindSupplierNameApril2026", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("BindSupplierName - Stored Procedure : SP_BindSupplierNameApril2026");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    LogInfo.LogDetailToFile("BindSupplierName - Supplier Name Data Loaded");
                    LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-BindSupplierName - Start-End");

                    return dt;
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("BindSupplierName - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-BindSupplierName - Start-End");
                throw;
            }
        }


        // Bind Branch

        public DataTable BindBranch()
        {
            LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-BindBranch - Start");

            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("SP_BindBranchApril2026", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("BindBranch - Stored Procedure : SP_BindBranchApril2026");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    LogInfo.LogDetailToFile("BindBranch - Branch Data Loaded");
                    LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-BindBranch - Start-End");

                    return dt;
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("BindBranch - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-BindBranch - Start-End");
                throw;
            }
        }


        // Bind Country

        public DataTable BindCountry()
        {
            LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-BindCountry - Start");

            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("SP_BindCountryApril2026", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("BindCountry - Stored Procedure : SP_BindCountryApril2026");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    LogInfo.LogDetailToFile("BindCountry - Country Data Loaded");
                    LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-BindCountry - Start-End");

                    return dt;
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("BindCountry - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-BindCountry - Start-End");
                throw;
            }
        }


        // Bind State By Country

        public DataTable BindState(int countryId)
        {
            LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-BindState - Start");

            try
            {
                LogInfo.LogDetailToFile("BindState - Country Id : " + countryId);

                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("SP_BindStateByCountryApril2026", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = countryId;

                    LogInfo.LogDetailToFile("BindState - Stored Procedure : SP_BindStateByCountryApril2026");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    LogInfo.LogDetailToFile("BindState - State Data Loaded");
                    LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-BindState - Start-End");

                    return dt;
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("BindState - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-BindState - Start-End");
                throw;
            }
        }


        // Bind City By State

        public DataTable BindCity(int stateId)
        {
            LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-BindCity - Start");

            try
            {
                LogInfo.LogDetailToFile("BindCity - State Id : " + stateId);

                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("SP_BindCityByStateApril2026", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@StateId", SqlDbType.Int).Value = stateId;

                    LogInfo.LogDetailToFile("BindCity - Stored Procedure : SP_BindCityByStateApril2026");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    LogInfo.LogDetailToFile("BindCity - City Data Loaded");
                    LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-BindCity - Start-End");

                    return dt;
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("BindCity - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("SupplierMasterMVCApril2026DAL-BindCity - Start-End");
                throw;
            }
        }


        // Map Data Row To Supplier Model

        private SupplierMasterMVCApril2026Model MapSupplier(DataRow dr)
        {
            SupplierMasterMVCApril2026Model obj = new SupplierMasterMVCApril2026Model();

            obj.Id = Convert.ToInt32(dr["Id"]);
            obj.SuppCode = dr["SuppCode"] == DBNull.Value ? null : dr["SuppCode"].ToString();
            obj.SuppName = dr["SuppName"] == DBNull.Value ? null : dr["SuppName"].ToString();
            obj.ContactPerson = dr["ContactPerson"] == DBNull.Value ? null : dr["ContactPerson"].ToString();
            obj.BranchId = dr["BranchId"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["BranchId"]);
            obj.Branch = dr["Branch"] == DBNull.Value ? null : dr["Branch"].ToString();
            obj.Address1 = dr["Address1"] == DBNull.Value ? null : dr["Address1"].ToString();
            obj.Address2 = dr["Address2"] == DBNull.Value ? null : dr["Address2"].ToString();
            obj.CityId = dr["CityId"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["CityId"]);
            obj.City = dr["City"] == DBNull.Value ? null : dr["City"].ToString();
            obj.StateId = dr["StateId"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["StateId"]);
            obj.State = dr["State"] == DBNull.Value ? null : dr["State"].ToString();
            obj.PinCode = dr["PinCode"] == DBNull.Value ? null : dr["PinCode"].ToString();
            obj.CountryId = dr["CountryId"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["CountryId"]);
            obj.Country = dr["Country"] == DBNull.Value ? null : dr["Country"].ToString();
            obj.IsRawMaterial = dr["IsRawMaterial"] == DBNull.Value ? false : Convert.ToBoolean(dr["IsRawMaterial"]);
            obj.EmailID = dr["EmailID"] == DBNull.Value ? null : dr["EmailID"].ToString();
            obj.Telephone = dr["Telephone"] == DBNull.Value ? null : dr["Telephone"].ToString();
            obj.Mobile = dr["Mobile"] == DBNull.Value ? null : dr["Mobile"].ToString();
            obj.Fax = dr["Fax"] == DBNull.Value ? null : dr["Fax"].ToString();
            obj.Website = dr["Website"] == DBNull.Value ? null : dr["Website"].ToString();
            obj.GSTIN = dr["GSTIN"] == DBNull.Value ? null : dr["GSTIN"].ToString();
            obj.Remarks = dr["Remarks"] == DBNull.Value ? null : dr["Remarks"].ToString();

            return obj;
        }
    }
}