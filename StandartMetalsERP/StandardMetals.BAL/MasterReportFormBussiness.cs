using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using Modal;

namespace StandardMetals.BAL
{

   public   class MasterReportFormBussiness
    {
       MasterReportFormData masterdata = new MasterReportFormData();

       public DataTable MachinveVsCheckPointAllData() 
   {
       return masterdata.MachinveVsCheckPointAllData();
   }
       //MachineMasterAllDtl
       public DataTable MachineMasterAllDtl()
       {
           return masterdata.MachineMasterAllDtl();
       }
       //MachineMasterMachineWiseDtl
       public DataTable MachineMasterMachineWiseDtl(int SrNo)
       {
           return masterdata.MachineMasterMachineWiseDtl(SrNo);
       }

       public DataTable ItemMasterAllDtl()
       {
           return masterdata.ItemMasterAllDtl();
       }

        //ItemMasterItemWiseDtl
       public DataTable ItemMasterItemWiseDtl(string ItemCode)
       {
           return masterdata.ItemMasterItemWiseDtl(ItemCode);
       }
        //EmployeeMasterCodeWiseDtl
       public DataTable EmployeeMasterCodeWiseDtl(string EmpCode)
       {
           return masterdata.EmployeeMasterCodeWiseDtl(EmpCode);
       }

        //EmployeeMasterAllDtl
       public DataTable EmployeeMasterAllDtl()
       {
           return masterdata.EmployeeMasterAllDtl();
       }

        //SupplierPO
       public DataTable SupplierPO(MasterFormsReportModal mod)
       {
           return masterdata.SupplierPO(mod);
       }
        //RptIndetDetailIReport
       public DataTable RptIndetDetailIReport(MasterFormsReportModal mod)
       {
           return masterdata.RptIndetDetailIReport(mod);
       }
        //RptMsvhinrVsCheckPointMachineWise
       public DataTable RptMsvhinrVsCheckPointMachineWise(MasterFormsReportModal mod)
       {
           return masterdata.RptMsvhinrVsCheckPointMachineWise(mod);
       }



    }
}
