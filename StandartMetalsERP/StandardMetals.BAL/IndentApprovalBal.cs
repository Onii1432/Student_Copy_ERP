using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Modal;
using DAL;

namespace StandardMetals.BAL
{
    public class IndentApprovalBal
    {
        IndentApprovalDal IndentAppDal = new IndentApprovalDal();
        public DataTable GetNonApprovedIndent(IndentApprovalModal IndentAppModal)
        {
            return IndentAppDal.GetNonApprovedIndent(IndentAppModal);
        }
        public int GetLoginDetails(string UserName)
        {
            return IndentAppDal.GetLoginDetails(UserName);
        }

        public int UpdateIndentDetailMaster(IndentApprovalModal IndentAppModal)
        {
            return IndentAppDal.UpdateIndentDetailMaster(IndentAppModal);
        }
    }
}
