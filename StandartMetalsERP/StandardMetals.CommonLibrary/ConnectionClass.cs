using System.Configuration;
using System.Data.SqlClient;

namespace StandardMetals.CommonLibrary
{
    public class ConnectionClass
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["ERPConnection"].ConnectionString);
        }
    }
}


