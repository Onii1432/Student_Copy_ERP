using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using StandardMetals.MODEL;
using StandardMetals.DAL;


namespace StandardMetals.BAL
{
    public class LoginDetails
    {
        dbLogindetails objdbLogindetails = new dbLogindetails();
        public LoginMaster LoginDetailsvalue(string UserName, string Password)
        {
            return objdbLogindetails.LoginDetails(UserName, Password);
        }
        public List<LoginDetailsModel> GetMenuDetail(int LoginUserId)
        {
            return objdbLogindetails.GetMenuDetail(LoginUserId);
        }

        public void LogoutUser(int LoginUserId)
        {
            objdbLogindetails.LogoutUser(LoginUserId);
        }


        public List<LoggedInUserModelApril26> GetAllLoginUsers()
        {
            dbLogindetails dal = new dbLogindetails();

            return dal.GetAllLoginUsers();
        }

        public bool IsUserLoggedIn(int LoginUserId)
        {
            dbLogindetails dal = new dbLogindetails();
            return dal.IsUserLoggedIn(LoginUserId);
        }
    }
}



