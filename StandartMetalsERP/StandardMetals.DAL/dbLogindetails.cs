using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using StandardMetals.MODEL;

namespace StandardMetals.DAL
{
    public class dbLogindetails : ConncetionClass
    {
        DataTable dt;

        public List<LoginMaster> LoginDetailsbackup(string username, string password)
        {
            this.Initialize();

            int nRecAffected = 0;
            DataTable dt = new DataTable();
            List<LoginMaster> lst = new List<LoginMaster>();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetLoginDetails";

                cmdUniversal.Parameters.Add("@UserName", SqlDbType.VarChar).Value = username;

                cmdUniversal.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

                this.cnUniversal.Open();

                this.daUniversal.SelectCommand = cmdUniversal;

                nRecAffected = this.daUniversal.Fill(dt);

                this.Close();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        lst.Add(new LoginMaster()
                        {
                            UserName = Convert.ToString(dt.Rows[i]["UserName"]),
                            LoginUserId = Convert.ToInt32(dt.Rows[i]["LoginUserId"]),
                            BranchName = Convert.ToString(dt.Rows[i]["BranchName"]),
                            BranchId = Convert.ToInt32(dt.Rows[i]["BranchId"]),
                            EmpCode = Convert.ToString(dt.Rows[i]["EmpCode"])
                        });
                    }
                }

                return lst;
            }
        }


        public LoginMaster LoginDetails(string username, string password)
        {
            this.Initialize();

            int nRecAffected = 0;
            DataTable dt = new DataTable();

            LoginMaster objLoginDtl = new LoginMaster();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetLoginDetails";

                cmdUniversal.Parameters.Add("@UserName", SqlDbType.VarChar).Value = username;

                cmdUniversal.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

                this.cnUniversal.Open();

                this.daUniversal.SelectCommand = cmdUniversal;

                nRecAffected = this.daUniversal.Fill(dt);

                this.Close();

                if (dt.Rows.Count > 0)
                {
                    objLoginDtl.UserName = Convert.ToString(dt.Rows[0]["UserName"]);

                    objLoginDtl.LoginUserId = Convert.ToInt32(dt.Rows[0]["LoginUserId"]);

                    objLoginDtl.BranchName = Convert.ToString(dt.Rows[0]["BranchName"]);

                    objLoginDtl.BranchId = Convert.ToInt32(dt.Rows[0]["BranchId"]);

                    objLoginDtl.EmpCode = Convert.ToString(dt.Rows[0]["EmpCode"]);

                    objLoginDtl.LoginStatus = Convert.ToString(dt.Rows[0]["LoginStatus"]);
                }

                return objLoginDtl;
            }
        }


        public void LogoutUser(int LoginUserId)
        {
            this.Initialize();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "LogoutUser";

                cmdUniversal.Parameters.Add("@LoginUserId", SqlDbType.Int).Value = LoginUserId;

                this.cnUniversal.Open();

                cmdUniversal.ExecuteNonQuery();

                this.Close();
            }
        }


        public List<LoginDetailsModel> GetMenuDetail(int LoginUserId)
        {
            this.Initialize();

            int nRecAffected = 0;

            dt = new DataTable();

            List<LoginDetailsModel> lst = new List<LoginDetailsModel>();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "Admin_GetUserAccessDetail";

                cmdUniversal.Parameters.Add("@LoginUserId", SqlDbType.VarChar).Value = LoginUserId;

                this.daUniversal.SelectCommand = cmdUniversal;

                this.cnUniversal.Open();

                nRecAffected = this.daUniversal.Fill(dt);

                this.Close();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        lst.Add(new LoginDetailsModel()
                        {
                            MasterMenuId = Convert.ToInt32(dt.Rows[i]["MasterMenuId"]),
                            MenuName = dt.Rows[i]["MenuName"].ToString(),
                            IsMaster = Convert.ToBoolean(dt.Rows[i]["IsMaster"]),
                            SubMasterMenuId = Convert.ToInt32(dt.Rows[i]["SubMasterMenuId"]),
                            SubMenuName = dt.Rows[i]["SubMenuName"].ToString(),
                            MenuLink = dt.Rows[i]["MenuLink"].ToString(),
                            AddAccess = Convert.ToBoolean(dt.Rows[i]["AddAccess"]),
                            UpdateAccess = Convert.ToBoolean(dt.Rows[i]["UpdateAccess"]),
                            DeleteAccess = Convert.ToBoolean(dt.Rows[i]["DeleteAccess"]),
                            SearchAccess = Convert.ToBoolean(dt.Rows[i]["SearchAccess"])
                        });
                    }
                }

                return lst;
            }
        }


        public List<LoggedInUserModelApril26> GetAllLoginUsers()
        {
            this.Initialize();

            DataTable dt = new DataTable();

            List<LoggedInUserModelApril26> lst =
                new List<LoggedInUserModelApril26>();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetAllLoginUsers";

                this.daUniversal.SelectCommand = cmdUniversal;

                this.cnUniversal.Open();

                this.daUniversal.Fill(dt);

                this.Close();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        lst.Add(new LoggedInUserModelApril26()
                        {
                            LoginUserId =
                                Convert.ToInt32(dt.Rows[i]["LoginUserId"]),

                            UserName =
                                Convert.ToString(dt.Rows[i]["UserName"]),

                            IsLoggedIn =
                                Convert.ToBoolean(dt.Rows[i]["IsLoggedIn"])
                        });
                    }
                }

                return lst;
            }
        }



        public bool IsUserLoggedIn(int LoginUserId)
        {
            this.Initialize();
            DataTable dt = new DataTable();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "CheckLoginStatus";
                cmdUniversal.Parameters.Add("@LoginUserId", SqlDbType.Int).Value = LoginUserId;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                this.daUniversal.Fill(dt);
                this.Close();

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToBoolean(dt.Rows[0]["IsLoggedIn"]);
                }

                return false;
            }
        }
    }
}