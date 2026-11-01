using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StandardMetals.BAL;
using StandardMetals.MODEL;
using StandardMetals.WebAPI.AuthFilter;
using StandardMetals.CommonLibrary;

namespace StandardMetals.WebAPI.Controllers
{
    public class LoginDetailController : ApiController
    {
        LoginDetails bal = new LoginDetails();

        [HttpGet]
        //[BasicAuthentication]
        public LoginMaster LoginDetails(string UserName, string Password)
        {
            LogInfo.LogDetailToFile("LoginDetailCtrl-LoginDetails Action(httpget)- Start");

            LoginMaster result = bal.LoginDetailsvalue(UserName, Password);

            LogInfo.LogDetailToFile("LoginDetails - Login Validation Completed");
            LogInfo.LogDetailToFile("LoginDetailCtrl-LoginDetails Action(httpget)- Start-End");

            return result;
        }


        [HttpGet]
        public IHttpActionResult LogoutUser(int LoginUserId)
        {
            LogInfo.LogDetailToFile("LoginDetailCtrl-LogoutUser Action(httpget)- Start");
            LogInfo.LogDetailToFile("LogoutUser - Login User Id : " + LoginUserId);

            bal.LogoutUser(LoginUserId);

            LogInfo.LogDetailToFile("LogoutUser - Logout Completed");
            LogInfo.LogDetailToFile("LoginDetailCtrl-LogoutUser Action(httpget)- Start-End");

            return Ok();
        }
    }
}