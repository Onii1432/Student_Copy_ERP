using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Modal;
using System.Data;

namespace StandardMetals.BAL
{
    public class MachineMasterBAL
    {

        MachineMasterDAL MMData = new MachineMasterDAL();
        MachineMasterModal MMModel = new MachineMasterModal();

        //BindMachineCode
        public DataTable BindMachineCode(MachineMasterModal MMModel)
        {

            return MMData.BindMachineCode(MMModel);
        }

    }
}
