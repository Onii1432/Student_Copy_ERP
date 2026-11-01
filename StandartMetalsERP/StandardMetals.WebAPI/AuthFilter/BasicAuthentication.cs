using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Configuration;


namespace StandardMetals.WebAPI.AuthFilter
{
    public class BasicAuthentication: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization==null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string dcodeAuthToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string[] arr = dcodeAuthToken.Split(':');
                string username = arr[0];
                string password = arr[1];
                bool isValidUser = GetUsrNameAndPassword(username, password);

                if (isValidUser)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }

        public bool GetUsrNameAndPassword(string username, string password)
        {
            // string conString = "Data Source = DESKTOP-L9K61I0; Initial Catalog=StandardMetals_Com_MVC;Integrated Security=false;uid=Akash;password=Akash@8787";
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["ERPConnection"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(conString);

            SqlCommand sqlCommand = new SqlCommand("GetUserNameAndPassword", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@userName", username);
            sqlCommand.Parameters.AddWithValue("@password", password);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}