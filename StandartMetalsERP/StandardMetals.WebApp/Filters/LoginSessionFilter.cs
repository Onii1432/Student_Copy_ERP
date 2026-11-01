using System;
using System.Web.Mvc;
using StandardMetals.BAL;

namespace StandardMetals.WebApp.Filters
{
    public class LoginSessionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;

            // Allow Login page without session
            if (controllerName == "Account" && actionName == "Login")
            {
                base.OnActionExecuting(filterContext);
                return;
            }

            var session = filterContext.HttpContext.Session;

            // Session does not exist
            if (session["LoginUserId"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary
                    {
                        { "controller", "Account" },
                        { "action", "Login" }
                    });

                return;
            }

            int loginUserId = Convert.ToInt32(session["LoginUserId"]);

            LoginDetails loginDetails = new LoginDetails();

            bool isLoggedIn = loginDetails.IsUserLoggedIn(loginUserId);

            // Admin has forcefully logged out this user
            if (!isLoggedIn)
            {
                session.Clear();
                session.Abandon();

                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary
                    {
                        { "controller", "Account" },
                        { "action", "Login" }
                    });

                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}