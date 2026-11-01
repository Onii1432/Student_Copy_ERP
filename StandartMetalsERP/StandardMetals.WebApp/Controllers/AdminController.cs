using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StandardMetals.MODEL;
using System.Net.Http;
using System.Configuration;
using Newtonsoft.Json;
using StandardMetals.CommonLibrary;

namespace StandardMetals.WebApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            LogInfo.LogDetailToFile("AdminController-Index Action(httpget)- Start");
            LogInfo.LogDetailToFile("AdminController-Index - View Loaded");
            LogInfo.LogDetailToFile("AdminController-Index Action(httpget)- Start-End");
            return View();
        }


        public ActionResult LoginUserMaster()
        {
            LogInfo.LogDetailToFile("AdminController-LoginUserMaster Action(httpget)- Start");
            LogInfo.LogDetailToFile("LoginUserMaster - View Loaded");
            LogInfo.LogDetailToFile("AdminController-LoginUserMaster Action(httpget)- Start-End");
            return View();
        }


        [HttpPost]
        public ActionResult LoginUserMaster(LoginUserMasterModel logindtl)
        {
            LogInfo.LogDetailToFile("AdminController-LoginUserMaster Action(httppost)- Start");

            LogInfo.LogDetailToFile("LoginUserMaster - Login Details Received");

            LogInfo.LogDetailToFile("AdminController-LoginUserMaster Action(httppost)- Start-End");

            return View();
        }


        public ActionResult MenuMaster()
        {
            LogInfo.LogDetailToFile("AdminController-MenuMaster Action(httpget)- Start");
            LogInfo.LogDetailToFile("MenuMaster - View Loaded");
            LogInfo.LogDetailToFile("AdminController-MenuMaster Action(httpget)- Start-End");
            return View();
        }


        //[HttpPost]
        //public ActionResult MenuMaster()
        //{
        //    return View();
        //}


        public ActionResult SubMenuMaster()
        {
            LogInfo.LogDetailToFile("AdminController-SubMenuMaster Action(httpget)- Start");
            LogInfo.LogDetailToFile("SubMenuMaster - View Loaded");
            LogInfo.LogDetailToFile("AdminController-SubMenuMaster Action(httpget)- Start-End");
            return View();
        }


        //[HttpPost]
        //public ActionResult SubMenuMaster()
        //{
        //    return View();
        //}


        public ActionResult RoleMaster()
        {
            LogInfo.LogDetailToFile("AdminController-RoleMaster Action(httpget)- Start");
            LogInfo.LogDetailToFile("RoleMaster - View Loaded");
            LogInfo.LogDetailToFile("AdminController-RoleMaster Action(httpget)- Start-End");
            return View();
        }


        //public ActionResult RoleMaster()
        //{
        //    return View();
        //}


        public ActionResult LoggedInUsers()
        {
            LogInfo.LogDetailToFile("AdminController-LoggedInUsers Action(httpget)- Start");

            string apiUrl = ConfigurationManager.AppSettings["APIURL"] + "Admin/GetAllLoginUsers";

            LogInfo.LogDetailToFile("LoggedInUsers - API URL : " + apiUrl);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    List<LoggedInUserModelApril26> users = JsonConvert.DeserializeObject<List<LoggedInUserModelApril26>>(json);

                    LogInfo.LogDetailToFile("LoggedInUsers - Users List Loaded");

                    LogInfo.LogDetailToFile("AdminController-LoggedInUsers Action(httpget)- Start-End");

                    return View(users);
                }
            }

            LogInfo.LogDetailToFile("LoggedInUsers - Unable To Load Users");

            LogInfo.LogDetailToFile("AdminController-LoggedInUsers Action(httpget)- Start-End");

            return View(new List<LoggedInUserModelApril26>());
        }


        [HttpPost]
        public ActionResult LogoutLoginUser(int LoginUserId)
        {
            LogInfo.LogDetailToFile("AdminController-LogoutLoginUser Action(httppost)- Start");

            LogInfo.LogDetailToFile("LogoutLoginUser - Login User Id : " + LoginUserId);

            string apiUrl = ConfigurationManager.AppSettings["APIURL"] + "Admin/LogoutLoginUser?LoginUserId=" + LoginUserId;

            LogInfo.LogDetailToFile("LogoutLoginUser - API URL : " + apiUrl);

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            }

            LogInfo.LogDetailToFile("LogoutLoginUser - Logout Completed");

            LogInfo.LogDetailToFile("AdminController-LogoutLoginUser Action(httppost)- Start-End");

            return RedirectToAction("LoggedInUsers");
        }
    }
}