
using StandardMetals.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StandardMetals.WebApp.UserAccessDtl
{
    public class UserAccessFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Get the current controller and action names.
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;

            // Allow the Login action without checking the session or permissions.
            if (controllerName == "Account" && actionName == "Login")
            {
                return;
            }

            // Check whether the user is logged in.
            if (HttpContext.Current.Session["LoginUserId"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(new { controller = "Account", action = "Login" }));


                return;
            }

            // Get the menu and submenu links assigned to the logged-in user.
            List<LoginDetailsModel> MenuSubMenu = HttpContext.Current.Session["MenuSubMenu"] as List<LoginDetailsModel>;


            // Build the URL for the requested controller and action.
            string strUrl = "../" + controllerName + "/" + actionName;

            // Allow the dashboard for logged-in users.
            if (strUrl == "../Master/DefaultDashboard")
            {
                base.OnActionExecuting(filterContext);
                return;
            }

            // Check whether the requested action exists in the user's permitted menu links.
            bool hasAccess = MenuSubMenu != null &&
                MenuSubMenu.Any(m => m.MenuLink == strUrl);

            // Show the access-denied page if the user does not have permission.
            if (!hasAccess)
            {
                filterContext.Result = new ViewResult()
                {
                    ViewName = "~/Views/Shared/Error_UserAccess.cshtml"
                };

                return;
            }

            // Permission exists, so allow the action to execute.
            base.OnActionExecuting(filterContext);
        }
    }
}



//using StandardMetals.MODEL;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace StandardMetals.WebApp.UserAccessDtl
//{
//    public class UserAccessFilter : ActionFilterAttribute
//    {
//        public override void OnActionExecuting(ActionExecutingContext filterContext)
//        {
//            int str = Convert.ToInt32(System.Web.HttpContext.Current.Session["LoginUserId"].ToString());

//            List<LoginDetailsModel> MenuSubMenu = (List<LoginDetailsModel>)System.Web.HttpContext.Current.Session["MenuSubMenu"];

//            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
//            string actionName = filterContext.ActionDescriptor.ActionName;

//            string strUrl = "../" + controllerName + "/" + actionName;

//            var masterMenu = MenuSubMenu.Select(m => new { m.MenuLink }).Distinct().Where(m => m.MenuLink == strUrl);

//            int cnt = 0;


//            foreach (var val in masterMenu)
//            {

//                cnt++;
//                break;

//            }

//            if (strUrl == "../Master/DefaultDashboard")
//            {
//                cnt = 1;
//            }

//            if (cnt == 0)
//            {
//                //System.Web.HttpContext.Current.Session.Abandon();
//                //  System.Web.HttpContext.Current.Session.Clear();


//                filterContext.Result = new ViewResult()
//                {
//                    ViewName = "Error_UserAccess"
//                };
//            }

//        }
//    }
//}