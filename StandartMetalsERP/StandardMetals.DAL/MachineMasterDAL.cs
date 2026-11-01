using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Modal;
using System.Collections;

namespace StandardMetals.DAL
{
    public class MachineMasterDAL:ConncetionClass
    {
        MachineMasterModal MMModel = new MachineMasterModal();

        //BindMachineCode
        public DataTable BindMachineCode(MachineMasterModal MMModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindMachineName";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

    }
}
