using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StandardMetals.MODEL;
using StandardMetals.DAL;
using System.Data;

namespace StandardMetals.BAL
{
    
    public class LoginUserMasterBAL
    {
        LoginUserMasterDAL objdal = new LoginUserMasterDAL();

        public DataTable GetRoleDetails()
        {
            return objdal.GetRoleDetails();
        }

        public int SaveLoginUserMaster(LoginUserMasterModel model)
        {
            return objdal.SaveLoginUserMaster(model);
        }

    }

}


