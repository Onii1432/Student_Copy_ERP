using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using StandardMetals.MODEL;
using System.Threading.Tasks;
using StandardMetals.BAL;
using StandardMetals.CommonLibrary;

namespace StandardMetals.WebApp.Controllers
{
    public class AccountController : Controller
    {
        LoginDetails menuSubMenu = new LoginDetails();


        // Login Page

        public ActionResult Login()
        {
            LogInfo.LogDetailToFile("AccountController-Login(GET) - Start");

            LogInfo.LogDetailToFile("Login(GET) - Login Page Loaded");

            LogInfo.LogDetailToFile("AccountController-Login(GET) - Start-End");

            return View();
        }


        // Login

        [HttpPost]
        public async Task<ActionResult> Login(LoginMaster Logindtl)
        {
            LogInfo.LogDetailToFile("AccountController-Login(POST) - Start");

            if (ModelState.IsValid)
            {
                try
                {
                    LoginMaster objLoginDtl = new LoginMaster();

                    string apiUrl = "http://localhost:62335/LoginDetail/LoginDetails?UserName=" + Logindtl.UserName.ToString() + "&" + "Password=" + Logindtl.Password.ToString();

                    LogInfo.LogDetailToFile("Login(POST) - Login API URL Prepared");

                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(apiUrl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage response = await client.GetAsync(apiUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            var data = await response.Content.ReadAsStringAsync();

                            objLoginDtl = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginMaster>(data);

                            LogInfo.LogDetailToFile("Login(POST) - Login API Response Received");
                        }
                        else
                        {
                            LogInfo.LogDetailToFile("Login(POST) - Login API Request Failed");
                        }
                    }

                    if (objLoginDtl != null && objLoginDtl.LoginStatus == "SUCCESS")
                    {
                        LogInfo.LogDetailToFile("Login(POST) - Login Successful");

                        Session["Username"] = objLoginDtl.UserName;
                        Session["Branch"] = objLoginDtl.BranchName;
                        Session["BranchId"] = objLoginDtl.BranchId;
                        Session["EmpCode"] = objLoginDtl.EmpCode;
                        Session["LoginUserId"] = objLoginDtl.LoginUserId;

                        int LoginUserId = objLoginDtl.LoginUserId;

                        LogInfo.LogDetailToFile("Login(POST) - Login User Id : " + LoginUserId);

                        List<LoginDetailsModel> MenuSubMenu = menuSubMenu.GetMenuDetail(LoginUserId);

                        Session["MenuSubMenu"] = MenuSubMenu;

                        LogInfo.LogDetailToFile("Login(POST) - Menu And SubMenu Loaded");

                        var palneTextByte = System.Text.Encoding.UTF8.GetBytes(Logindtl.UserName + ":" + Logindtl.Password);

                        string token = System.Convert.ToBase64String(palneTextByte);

                        Session["Token"] = token;

                        LogInfo.LogDetailToFile("Login(POST) - Token Generated");

                        LogInfo.LogDetailToFile("Login(POST) - Redirecting To Default Dashboard");

                        LogInfo.LogDetailToFile("AccountController-Login(POST) - Start-End");

                        return RedirectToAction("DefaultDashboard", "Master");
                    }
                    else if (objLoginDtl != null && objLoginDtl.LoginStatus == "ALREADY_LOGGED_IN")
                    {
                        LogInfo.LogDetailToFile("Login(POST) - User Already Logged In");

                        ViewBag.ErroMsg = "User is already logged in.";
                    }
                    else
                    {
                        LogInfo.LogDetailToFile("Login(POST) - Invalid Username Or Password");

                        ViewBag.ErroMsg = "User name or password is incorrect...";
                    }
                }
                catch (Exception ex)
                {
                    LogInfo.LogDetailToFile("Login(POST) - Exception : " + ex.Message);

                    ViewBag.ErroMsg = "An error occurred while processing login.";
                }
            }
            else
            {
                LogInfo.LogDetailToFile("Login(POST) - ModelState Is Invalid");
            }

            LogInfo.LogDetailToFile("AccountController-Login(POST) - Start-End");

            return View();
        }


        public async Task<ActionResult> SignOut()
        {
            LogInfo.LogDetailToFile("AccountController-SignOut - Start");

            try
            {
                if (Session["LoginUserId"] != null)
                {
                    int LoginUserId = Convert.ToInt32(Session["LoginUserId"]);

                    LogInfo.LogDetailToFile("SignOut - Login User Id : " + LoginUserId);

                    string apiUrl = "http://localhost:62335/LoginDetail/LogoutUser?LoginUserId=" + LoginUserId;

                    LogInfo.LogDetailToFile("SignOut - Logout API URL Prepared");

                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(apiUrl);

                        HttpResponseMessage response = await client.GetAsync(apiUrl);

                        LogInfo.LogDetailToFile("SignOut - Logout API Completed");
                    }
                }
                else
                {
                    LogInfo.LogDetailToFile("SignOut - Login User Id Not Found In Session");
                }

                Session.Clear();
                Session.Abandon();

                LogInfo.LogDetailToFile("SignOut - Session Cleared");

                LogInfo.LogDetailToFile("AccountController-SignOut - Start-End");

                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                LogInfo.LogDetailToFile("SignOut - Exception : " + ex.Message);

                Session.Clear();
                Session.Abandon();

                LogInfo.LogDetailToFile("SignOut - Session Cleared After Exception");

                LogInfo.LogDetailToFile("AccountController-SignOut - Start-End");

                return RedirectToAction("Login", "Account");
            }
        }


        //// Exception Logging

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    Exception ex = filterContext.Exception;
        //}

    }
}