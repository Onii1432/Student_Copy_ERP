using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Data;
using System.Data.SqlClient;
using StandardMetals.BAL;
using StandardMetals.MODEL;
using StandardMetals.DAL;
using StandardMetals.CommonLibrary;

namespace StandardMetals.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AdminController : ApiController
    {
        //Bind Menu Master Dropdown 

        RoleMasterBal roleMasterBal = new RoleMasterBal();
        MenuMasterBal bal = new MenuMasterBal();
        MenuMasterModel model = new MenuMasterModel();
        LoginDetails loginDetailsBal = new LoginDetails();

        [HttpGet]
        public DataTable BindMasterMenu()
        {
            LogInfo.LogDetailToFile("AdminCtrl-BindMasterMenu Action(httpget)- Start");

            DataTable dt = new DataTable();
            dt = bal.FillMenuItem();

            LogInfo.LogDetailToFile("BindMasterMenu - Menu Data Loaded");
            LogInfo.LogDetailToFile("AdminCtrl-BindMasterMenu Action(httpget)- Start-End");

            return dt;
        }


        [HttpPost]
        public void SaveMasterMenu(MenuMasterModel masterModel)
        {
            LogInfo.LogDetailToFile("AdminCtrl-SaveMasterMenu Action(httppost)- Start");

            int affrows = 0;
            string status = " ";

            affrows = bal.SaveMenuData(masterModel);

            if (affrows > 0)
            {
                status = "Data is saved";
                LogInfo.LogDetailToFile("SaveMasterMenu - Data Saved Successfully");
            }
            else
            {
                status = "Data is not saved";
                LogInfo.LogDetailToFile("SaveMasterMenu - Data is not saved");
            }

            LogInfo.LogDetailToFile("AdminCtrl-SaveMasterMenu Action(httppost)- Start-End");
        }


        [HttpPost]
        public int SaveSubMenuMaster(SubMenuModel subMenuModel)
        {
            LogInfo.LogDetailToFile("AdminCtrl-SaveSubMenuMaster Action(httppost)- Start");

            int affrows = 0;
            string status = " ";

            affrows = bal.SaveSubMenuData(subMenuModel);

            if (affrows > 0)
            {
                status = "Data is saved";
                LogInfo.LogDetailToFile("SaveSubMenuMaster - Data Saved Successfully");
            }
            else
            {
                status = "Data is not saved";
                LogInfo.LogDetailToFile("SaveSubMenuMaster - Data is not saved");
            }

            LogInfo.LogDetailToFile("AdminCtrl-SaveSubMenuMaster Action(httppost)- Start-End");

            return affrows;
        }


        [HttpGet]
        public DataTable BindRoleMasterItem()
        {
            LogInfo.LogDetailToFile("AdminCtrl-BindRoleMasterItem Action(httpget)- Start");

            DataTable dt = new DataTable();
            dt = bal.FillRoleMasterItem();

            LogInfo.LogDetailToFile("BindRoleMasterItem - Role Master Data Loaded");
            LogInfo.LogDetailToFile("AdminCtrl-BindRoleMasterItem Action(httpget)- Start-End");

            return dt;
        }


        public List<LoginDetailsModel> GetMenuDetail()
        {
            LogInfo.LogDetailToFile("AdminCtrl-GetMenuDetail Action- Start");

            List<LoginDetailsModel> menuList = new List<LoginDetailsModel>();
            menuList = roleMasterBal.GetMenuDetail();

            LogInfo.LogDetailToFile("GetMenuDetail - Menu List Loaded");
            LogInfo.LogDetailToFile("AdminCtrl-GetMenuDetail Action- Start-End");

            return menuList;
        }


        [HttpGet]
        public List<LoggedInUserModelApril26> GetAllLoginUsers()
        {
            LogInfo.LogDetailToFile("AdminCtrl-GetAllLoginUsers Action(httpget)- Start");

            List<LoggedInUserModelApril26> result = loginDetailsBal.GetAllLoginUsers();

            LogInfo.LogDetailToFile("GetAllLoginUsers - Login Users Loaded");
            LogInfo.LogDetailToFile("AdminCtrl-GetAllLoginUsers Action(httpget)- Start-End");

            return result;
        }


        [HttpGet]
        public IHttpActionResult LogoutLoginUser(int LoginUserId)
        {
            LogInfo.LogDetailToFile("AdminCtrl-LogoutLoginUser Action(httpget)- Start");

            LogInfo.LogDetailToFile("LogoutLoginUser - Login User Id : " + LoginUserId);

            loginDetailsBal.LogoutUser(LoginUserId);

            LogInfo.LogDetailToFile("LogoutLoginUser - Logout Completed");
            LogInfo.LogDetailToFile("AdminCtrl-LogoutLoginUser Action(httpget)- Start-End");

            return Ok();
        }
    }
}