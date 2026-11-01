using StandardMetals.DAL;
using StandardMetals.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace StandardMetals.BAL
{
    public class RoleMasterBal
    {
        RoleMasterDAL objdal = new RoleMasterDAL();

        public List<LoginDetailsModel> GetMenuDetail()
        {
            return objdal.GetMenuDetail();
        }
    }
}
