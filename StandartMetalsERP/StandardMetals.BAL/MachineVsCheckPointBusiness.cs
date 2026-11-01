using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Modal;
using System.Data;

namespace StandardMetals.BAL
{
    public class MachineVsCheckPointBusiness
    {
        MachineVsCheckPointData MVCData = new MachineVsCheckPointData();
        MachineVsCheckPointModel MVCModel = new MachineVsCheckPointModel();

        public DataTable BindMachineCode(MachineVsCheckPointModel MVCModel)
        {

            return MVCData.BindMachineCode(MVCModel);
        }

        public DataTable GetMachineVsCheckPoint(MachineVsCheckPointModel MVCModel)
        {

            return MVCData.GetMachineVsCheckPoint(MVCModel);
        }

        public DataTable BindMachineName(MachineVsCheckPointModel MVCModel)
        {

            return MVCData.BindMachineName(MVCModel);
        }

        public DataTable AllMachineVsCheckPoint(MachineVsCheckPointModel MVCModel)
        {
            return MVCData.AllMachineVsCheckPoint(MVCModel);
        }


        public int InsertMachineVsCheckPoint(MachineVsCheckPointModel mcmodel)
        {
            return   MVCData.InsertMachineVsCheckPoint(mcmodel);
        }


        //DuplicateEntry
        public DataTable DuplicateEntryData(MachineVsCheckPointModel MVCModel)
        {
            return MVCData.DuplicateEntryData(MVCModel);
        }








    }
}
