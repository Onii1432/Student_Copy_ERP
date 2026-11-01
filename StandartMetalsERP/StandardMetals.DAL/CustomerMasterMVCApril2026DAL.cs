// 20/08/2026

using StandardMetals.MODEL;
using StandardMetals.CommonLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace StandardMetals.DAL
{
    public sealed class CustomerMasterMVCApril2026DAL
    {

        private CustomerMasterMVCApril2026DAL()
        {
            LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL Constructor Action");
        }

        private static CustomerMasterMVCApril2026DAL obj;

        public static CustomerMasterMVCApril2026DAL GetInstance()
        {
            LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL GetInstance Static Action");

            if (obj == null)
            {
                LogInfo.LogDetailToFile("Object Initialized");

                obj = new CustomerMasterMVCApril2026DAL();
            }

            return obj;
        }


        string str = @"Data Source=LAPTOP-C9OTCO0G\SQLEXPRESS;Initial Catalog=aaliml4n_MVC_ERP;Integrated Security=True;";

        // Get All Customer Master
        public List<CustomerMasterMVCApril2026Model> GetAllCustomerMaster()
        {
            LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-GetAllCustomerMaster - Start");

            List<CustomerMasterMVCApril2026Model> list = new List<CustomerMasterMVCApril2026Model>();

            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("GetAllCustomerMaster", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("GetAllCustomerMaster - Stored Procedure : GetAllCustomerMaster");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    LogInfo.LogDetailToFile("GetAllCustomerMaster - Customer Data Loaded : " + dt.Rows.Count);

                    foreach (DataRow dr in dt.Rows)
                    {
                        CustomerMasterMVCApril2026Model obj = new CustomerMasterMVCApril2026Model();

                        obj.Id = Convert.ToInt32(dr["Id"]);
                        obj.CustCode = dr["CustCode"] == DBNull.Value ? null : dr["CustCode"].ToString();
                        obj.CustName = dr["CustName"] == DBNull.Value ? null : dr["CustName"].ToString();
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

                        obj.EmailID = dr["EmailID"] == DBNull.Value ? null : dr["EmailID"].ToString();
                        obj.Telephone = dr["Telephone"] == DBNull.Value ? null : dr["Telephone"].ToString();
                        obj.Mobile = dr["Mobile"] == DBNull.Value ? null : dr["Mobile"].ToString();
                        obj.Fax = dr["Fax"] == DBNull.Value ? null : dr["Fax"].ToString();
                        obj.Website = dr["Website"] == DBNull.Value ? null : dr["Website"].ToString();
                        obj.GSTIN = dr["GSTIN"] == DBNull.Value ? null : dr["GSTIN"].ToString();
                        obj.Remarks = dr["Remarks"] == DBNull.Value ? null : dr["Remarks"].ToString();

                        list.Add(obj);
                    }

                    LogInfo.LogDetailToFile("GetAllCustomerMaster - Customer List Prepared : " + list.Count);
                }

                LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-GetAllCustomerMaster - Start-End");

                return list;
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("GetAllCustomerMaster - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-GetAllCustomerMaster - Start-End");

                throw;
            }
        }


        // Get Customer By Id
        public CustomerMasterMVCApril2026Model GetCustomerMasterById(int id)
        {
            LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-GetCustomerMasterById - Start");

            CustomerMasterMVCApril2026Model obj = new CustomerMasterMVCApril2026Model();

            try
            {
                LogInfo.LogDetailToFile("GetCustomerMasterById - Customer Id : " + id);

                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("GetCustomerMasterById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    LogInfo.LogDetailToFile("GetCustomerMasterById - Stored Procedure : GetCustomerMasterById");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    LogInfo.LogDetailToFile("GetCustomerMasterById - Customer Data Loaded : " + dt.Rows.Count);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];

                        obj.Id = Convert.ToInt32(dr["Id"]);
                        obj.CustCode = dr["CustCode"] == DBNull.Value ? null : dr["CustCode"].ToString();
                        obj.CustName = dr["CustName"] == DBNull.Value ? null : dr["CustName"].ToString();
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

                        obj.EmailID = dr["EmailID"] == DBNull.Value ? null : dr["EmailID"].ToString();
                        obj.Telephone = dr["Telephone"] == DBNull.Value ? null : dr["Telephone"].ToString();
                        obj.Mobile = dr["Mobile"] == DBNull.Value ? null : dr["Mobile"].ToString();
                        obj.Fax = dr["Fax"] == DBNull.Value ? null : dr["Fax"].ToString();
                        obj.Website = dr["Website"] == DBNull.Value ? null : dr["Website"].ToString();
                        obj.GSTIN = dr["GSTIN"] == DBNull.Value ? null : dr["GSTIN"].ToString();
                        obj.Remarks = dr["Remarks"] == DBNull.Value ? null : dr["Remarks"].ToString();

                        LogInfo.LogDetailToFile("GetCustomerMasterById - Customer Details Loaded");
                    }
                    else
                    {
                        LogInfo.LogDetailToFile("GetCustomerMasterById - Customer Not Found");
                    }
                }

                LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-GetCustomerMasterById - Start-End");

                return obj;
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("GetCustomerMasterById - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-GetCustomerMasterById - Start-End");

                throw;
            }
        }


        // Get Customer Details By Code
        public CustomerMasterMVCApril2026Model GetCustomerDetailsByCode(string custCode)
        {
            LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-GetCustomerDetailsByCode - Start");

            CustomerMasterMVCApril2026Model obj = new CustomerMasterMVCApril2026Model();

            try
            {
                LogInfo.LogDetailToFile("GetCustomerDetailsByCode - Customer Code : " + custCode);

                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("GetCustomerDetailsByCode", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CustCode", SqlDbType.VarChar, 50).Value = (object)custCode ?? DBNull.Value;

                    LogInfo.LogDetailToFile("GetCustomerDetailsByCode - Stored Procedure : GetCustomerDetailsByCode");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    LogInfo.LogDetailToFile("GetCustomerDetailsByCode - Customer Data Loaded : " + dt.Rows.Count);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];

                        obj.Id = Convert.ToInt32(dr["Id"]);
                        obj.CustCode = dr["CustCode"] == DBNull.Value ? null : dr["CustCode"].ToString();
                        obj.CustName = dr["CustName"] == DBNull.Value ? null : dr["CustName"].ToString();
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

                        obj.EmailID = dr["EmailID"] == DBNull.Value ? null : dr["EmailID"].ToString();
                        obj.Telephone = dr["Telephone"] == DBNull.Value ? null : dr["Telephone"].ToString();
                        obj.Mobile = dr["Mobile"] == DBNull.Value ? null : dr["Mobile"].ToString();
                        obj.Fax = dr["Fax"] == DBNull.Value ? null : dr["Fax"].ToString();
                        obj.Website = dr["Website"] == DBNull.Value ? null : dr["Website"].ToString();
                        obj.GSTIN = dr["GSTIN"] == DBNull.Value ? null : dr["GSTIN"].ToString();
                        obj.Remarks = dr["Remarks"] == DBNull.Value ? null : dr["Remarks"].ToString();

                        LogInfo.LogDetailToFile("GetCustomerDetailsByCode - Customer Details Loaded");
                    }
                    else
                    {
                        LogInfo.LogDetailToFile("GetCustomerDetailsByCode - Customer Not Found");
                    }
                }

                LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-GetCustomerDetailsByCode - Start-End");

                return obj;
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("GetCustomerDetailsByCode - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-GetCustomerDetailsByCode - Start-End");

                throw;
            }
        }


        // Save Customer
        public string SaveCustomerMaster(CustomerMasterMVCApril2026Model obj)
        {
            LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-SaveCustomerMaster - Start");

            string custCode = "";

            try
            {
                LogInfo.LogDetailToFile("SaveCustomerMaster - Customer Name : " + obj.CustName);

                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("SaveCustomerMaster", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("SaveCustomerMaster - Stored Procedure : SaveCustomerMaster");

                    cmd.Parameters.Add("@CustName", SqlDbType.NVarChar, 100).Value = (object)obj.CustName ?? DBNull.Value;
                    cmd.Parameters.Add("@ContactPerson", SqlDbType.NVarChar, 100).Value = (object)obj.ContactPerson ?? DBNull.Value;
                    cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = obj.BranchId.HasValue ? (object)obj.BranchId.Value : DBNull.Value;
                    cmd.Parameters.Add("@Address1", SqlDbType.NVarChar, 200).Value = (object)obj.Address1 ?? DBNull.Value;
                    cmd.Parameters.Add("@Address2", SqlDbType.NVarChar, 200).Value = (object)obj.Address2 ?? DBNull.Value;
                    cmd.Parameters.Add("@CityId", SqlDbType.Int).Value = obj.CityId.HasValue ? (object)obj.CityId.Value : DBNull.Value;
                    cmd.Parameters.Add("@StateId", SqlDbType.Int).Value = obj.StateId.HasValue ? (object)obj.StateId.Value : DBNull.Value;
                    cmd.Parameters.Add("@PinCode", SqlDbType.NVarChar, 20).Value = (object)obj.PinCode ?? DBNull.Value;
                    cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = obj.CountryId.HasValue ? (object)obj.CountryId.Value : DBNull.Value;
                    cmd.Parameters.Add("@EmailID", SqlDbType.NVarChar, 100).Value = (object)obj.EmailID ?? DBNull.Value;
                    cmd.Parameters.Add("@Telephone", SqlDbType.NVarChar, 50).Value = (object)obj.Telephone ?? DBNull.Value;
                    cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar, 50).Value = (object)obj.Mobile ?? DBNull.Value;
                    cmd.Parameters.Add("@Fax", SqlDbType.NVarChar, 50).Value = (object)obj.Fax ?? DBNull.Value;
                    cmd.Parameters.Add("@Website", SqlDbType.NVarChar, 100).Value = (object)obj.Website ?? DBNull.Value;
                    cmd.Parameters.Add("@GSTIN", SqlDbType.NVarChar, 50).Value = (object)obj.GSTIN ?? DBNull.Value;
                    cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar, 500).Value = (object)obj.Remarks ?? DBNull.Value;

                    con.Open();

                    LogInfo.LogDetailToFile("SaveCustomerMaster - Connection Opened");

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            custCode = dr["CustCode"] == DBNull.Value ? "" : dr["CustCode"].ToString();

                            LogInfo.LogDetailToFile("SaveCustomerMaster - Customer Save Completed : " + custCode);
                        }
                        else
                        {
                            LogInfo.LogDetailToFile("SaveCustomerMaster - Customer Save Result Not Found");
                        }
                    }
                }

                if (!string.IsNullOrEmpty(custCode))
                {
                    LogInfo.LogDetailToFile("SaveCustomerMaster - Customer Saved Successfully");
                }
                else
                {
                    LogInfo.LogDetailToFile("SaveCustomerMaster - Unable To Save Customer");
                }

                LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-SaveCustomerMaster - Start-End");

                return custCode;
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("SaveCustomerMaster - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-SaveCustomerMaster - Start-End");

                throw;
            }
        }


        // Update Customer
        public int UpdateCustomerMaster(CustomerMasterMVCApril2026Model obj)
        {
            LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-UpdateCustomerMaster - Start");

            try
            {
                LogInfo.LogDetailToFile("UpdateCustomerMaster - Customer Id : " + obj.Id);
                LogInfo.LogDetailToFile("UpdateCustomerMaster - Customer Code : " + obj.CustCode);
                LogInfo.LogDetailToFile("UpdateCustomerMaster - Customer Name : " + obj.CustName);

                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("UpdateCustomerMaster", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("UpdateCustomerMaster - Stored Procedure : UpdateCustomerMaster");

                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = obj.Id;
                    cmd.Parameters.Add("@CustCode", SqlDbType.VarChar, 50).Value = (object)obj.CustCode ?? DBNull.Value;
                    cmd.Parameters.Add("@CustName", SqlDbType.VarChar, 100).Value = (object)obj.CustName ?? DBNull.Value;
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

                    con.Open();

                    LogInfo.LogDetailToFile("UpdateCustomerMaster - Connection Opened");

                    object result = cmd.ExecuteScalar();

                    LogInfo.LogDetailToFile("UpdateCustomerMaster - Update Result : " +
                        (result == null || result == DBNull.Value ? "NULL" : result.ToString()));

                    if (result != null && result != DBNull.Value)
                    {
                        int updateResult = Convert.ToInt32(result);

                        if (updateResult > 0)
                        {
                            LogInfo.LogDetailToFile("UpdateCustomerMaster - Customer Updated Successfully");
                        }
                        else
                        {
                            LogInfo.LogDetailToFile("UpdateCustomerMaster - Unable To Update Customer");
                        }

                        LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-UpdateCustomerMaster - Start-End");

                        return updateResult;
                    }
                }

                LogInfo.LogDetailToFile("UpdateCustomerMaster - Unable To Update Customer");
                LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-UpdateCustomerMaster - Start-End");

                return 0;
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("UpdateCustomerMaster - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-UpdateCustomerMaster - Start-End");

                throw;
            }
        }


        // Delete Customer
        public int DeleteCustomerMasterById(int id)
        {
            LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-DeleteCustomerMasterById - Start");

            try
            {
                LogInfo.LogDetailToFile("DeleteCustomerMasterById - Customer Id : " + id);

                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("DeleteCustomerMasterById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    LogInfo.LogDetailToFile("DeleteCustomerMasterById - Stored Procedure : DeleteCustomerMasterById");

                    con.Open();

                    LogInfo.LogDetailToFile("DeleteCustomerMasterById - Connection Opened");

                    object result = cmd.ExecuteScalar();

                    LogInfo.LogDetailToFile("DeleteCustomerMasterById - Delete Result : " +
                        (result == null || result == DBNull.Value ? "NULL" : result.ToString()));

                    if (result != null && result != DBNull.Value)
                    {
                        int deleteResult = Convert.ToInt32(result);

                        if (deleteResult > 0)
                        {
                            LogInfo.LogDetailToFile("DeleteCustomerMasterById - Customer Deleted Successfully");
                        }
                        else
                        {
                            LogInfo.LogDetailToFile("DeleteCustomerMasterById - Unable To Delete Customer");
                        }

                        LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-DeleteCustomerMasterById - Start-End");

                        return deleteResult;
                    }
                }

                LogInfo.LogDetailToFile("DeleteCustomerMasterById - Unable To Delete Customer");
                LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-DeleteCustomerMasterById - Start-End");

                return 0;
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("DeleteCustomerMasterById - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-DeleteCustomerMasterById - Start-End");

                throw;
            }
        }


        // Bind Customer
        public DataTable BindCustomer()
        {
            LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-BindCustomer - Start");

            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("BindCustomer", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("BindCustomer - Stored Procedure : BindCustomer");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    LogInfo.LogDetailToFile("BindCustomer - Customer Data Loaded : " + dt.Rows.Count);

                    LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-BindCustomer - Start-End");

                    return dt;
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("BindCustomer - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-BindCustomer - Start-End");

                throw;
            }
        }


        // Bind Branch
        public DataTable BindBranch()
        {
            LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-BindBranch - Start");

            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("BindBranch", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("BindBranch - Stored Procedure : BindBranch");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    LogInfo.LogDetailToFile("BindBranch - Branch Data Loaded : " + dt.Rows.Count);

                    LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-BindBranch - Start-End");

                    return dt;
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("BindBranch - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-BindBranch - Start-End");

                throw;
            }
        }


        // Bind Country
        public DataTable BindCountry()
        {
            LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-BindCountry - Start");

            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("BindCountry", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    LogInfo.LogDetailToFile("BindCountry - Stored Procedure : BindCountry");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    LogInfo.LogDetailToFile("BindCountry - Country Data Loaded : " + dt.Rows.Count);

                    LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-BindCountry - Start-End");

                    return dt;
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("BindCountry - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-BindCountry - Start-End");

                throw;
            }
        }


        // Bind State
        public DataTable BindState(int countryId)
        {
            LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-BindState - Start");

            try
            {
                LogInfo.LogDetailToFile("BindState - Country Id : " + countryId);

                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("BindState", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = countryId;

                    LogInfo.LogDetailToFile("BindState - Stored Procedure : BindState");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    LogInfo.LogDetailToFile("BindState - State Data Loaded : " + dt.Rows.Count);

                    LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-BindState - Start-End");

                    return dt;
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("BindState - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-BindState - Start-End");

                throw;
            }
        }


        // Bind City
        public DataTable BindCity(int stateId)
        {
            LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-BindCity - Start");

            try
            {
                LogInfo.LogDetailToFile("BindCity - State Id : " + stateId);

                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("BindCity", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@StateId", SqlDbType.Int).Value = stateId;

                    LogInfo.LogDetailToFile("BindCity - Stored Procedure : BindCity");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    LogInfo.LogDetailToFile("BindCity - City Data Loaded : " + dt.Rows.Count);

                    LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-BindCity - Start-End");

                    return dt;
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("BindCity - Exception : " + ex.Message);
                LogInfo.LogDetailToFile("CustomerMasterMVCApril2026DAL-BindCity - Start-End");

                throw;
            }
        }
    }
}