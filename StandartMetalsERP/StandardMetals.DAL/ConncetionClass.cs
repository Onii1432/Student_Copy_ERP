using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace StandardMetals.DAL
{
    public class ConncetionClass
    {
        internal static string conn;
        internal SqlConnection cnUniversal;
        internal SqlCommand cmdUniversal;
        internal SqlDataAdapter daUniversal;

        public string ConnectionString
        {
            set { conn = value; }
        }

        public ConncetionClass()
        {
            // windows auth
            // conn = @"Data Source=DESKTOP-3BL9M8E;Initial Catalog=MVCAKash_Test;Integrated Security=True";
            //MVCAKash_Test_Test
            //conn = @"Data Source=PRITIRAJE ; Initial catalog=Client_MVC ; Integrated Security=true";


            // Sql Server auth = third party server
            // conn = @"Data Source=208.91.198.174;Initial Catalog=aaliml4n_MVC_ERP;Integrated Security=False;uid=erpmvcuser;password=Mvcerp@123";
            
            // conn = @"Data Source=DESKTOP-3BL9M8E;Initial Catalog=SS!_MVC;Integrated Security=False;uid=Akash;password=Akash@8787";

            // Local Development Database

            conn = @"Data Source=ONKAR\SQLEXPRESS16;Initial Catalog=aaliml4n_MVC_ERPNEW1;Integrated Security=True";


        }
        public virtual void Initialize()
        {
            try
            {
                cnUniversal = new SqlConnection(conn);
                daUniversal = new SqlDataAdapter();
                cmdUniversal = new SqlCommand();
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Connection = cnUniversal;
            }

            catch (Exception e)
            {
                ErrorLog("dbBasis initialization", e);
            }
        }

        public virtual void Close()
        {
            if (cnUniversal.State != System.Data.ConnectionState.Closed)
                cnUniversal.Close();
        }

        protected virtual void ErrorLog(string strMessage, Exception e)
        {
            Exception oException = new Exception(e.InnerException.Message + " \n\n Details:" + strMessage);
            throw oException;
        }

        //// Method to execute a stored procedure
        public DataSet ExecuteStoredProcedure(string storedProcedureName)
        {
            Initialize();
            DataSet ds = new DataSet();
            try
            {
                cmdUniversal.CommandText = storedProcedureName;
                daUniversal.SelectCommand = cmdUniversal;
                daUniversal.Fill(ds);
            }
            catch (Exception e)
            {
                ErrorLog("Executing Stored Procedure", e);
            }
            finally
            {
                Close();
            }
            return ds;
        }
    }
}
