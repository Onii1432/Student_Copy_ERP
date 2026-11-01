using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Modal;
namespace StandardMetals.DAL
{
     public  class MasterReportFormData : ConncetionClass
    {
         dbItemMaster ItemData = new dbItemMaster();
         public DataTable MachinveVsCheckPointAllData()
         {
             DataTable dt = new DataTable();
             this.Initialize();
             using (cnUniversal)
             {
                 cmdUniversal.CommandText = "AllMachineVsCheckPoint";
                 cmdUniversal.CommandType = CommandType.StoredProcedure;
                 this.daUniversal.SelectCommand = cmdUniversal;
                 cnUniversal.Open();
                 daUniversal.Fill(dt);
                 this.Close();
                 return dt;
             }
         }
         //MachineMasterMachineWiseDtl
         public DataTable MachineMasterMachineWiseDtl(int SrNo)
         {
             this.Initialize();
             int nRecAffected = 0;
             DataTable dt = new DataTable();
             using (cnUniversal)
             {
                 cmdUniversal.CommandText = "RptMachineMaster";
                 cmdUniversal.Parameters.Add("@SrNo", SqlDbType.VarChar).Value = SrNo;
                 this.daUniversal.SelectCommand = cmdUniversal;
                 this.cnUniversal.Open();
                 nRecAffected = this.daUniversal.Fill(dt);
                 this.Close();
                 return dt;
             }
         }

         //MachineMasterAllDtl
         public DataTable MachineMasterAllDtl()
         {
             this.Initialize();
             int nRecAffected = 0;
             DataTable dt = new DataTable();
             using (cnUniversal)
             {
                 cmdUniversal.CommandText = "RptMachineMaster";
                 cmdUniversal.Parameters.Add("@SrNo", SqlDbType.VarChar).Value = "0";
                 this.daUniversal.SelectCommand = cmdUniversal;
                 this.cnUniversal.Open();
                 nRecAffected = this.daUniversal.Fill(dt);
                 this.Close();
                 return dt;
             }
         }

         public DataTable ItemMasterAllDtl()
         {
             this.Initialize();
             int nRecAffected = 0;
             DataTable dt = new DataTable();
             using (cnUniversal)
             {
                 cmdUniversal.CommandText = "Rpt_GetItemMasterAllData";
                 cmdUniversal.Parameters.Add("@ItemCode", SqlDbType.VarChar).Value = "0";
                 this.daUniversal.SelectCommand = cmdUniversal;
                 this.cnUniversal.Open();
                 nRecAffected = this.daUniversal.Fill(dt);
                 this.Close();
                 return dt;
             }
         }

        //ItemMasterItemWiseDtl
         public string SearchItemCode { get; set; }
         
         public DataTable ItemMasterItemWiseDtl(string ItemCode)
         {
             this.Initialize();
             int nRecAffected = 0;
             DataTable dt = new DataTable();
             using (cnUniversal)
             {
                 cmdUniversal.CommandText = "Rpt_GetItemMasterAllData";
                 cmdUniversal.Parameters.Add("@ItemCode", SqlDbType.VarChar).Value = ItemCode;
                 this.daUniversal.SelectCommand = cmdUniversal;
                 this.cnUniversal.Open();
                 nRecAffected = this.daUniversal.Fill(dt);
                 this.Close();
                 return dt;
             }
         }
        //EmployeeMasterCodeWiseDtl
         public DataTable EmployeeMasterCodeWiseDtl(string EmpCode)
         {
             this.Initialize();
             int nRecAffected = 0;
             DataTable dt = new DataTable();
             using (cnUniversal)
             {
                 cmdUniversal.CommandText = "EmployeeMasterAllData";
                 cmdUniversal.Parameters.Add("@EmpCode", SqlDbType.VarChar).Value = EmpCode;
                 this.daUniversal.SelectCommand = cmdUniversal;
                 this.cnUniversal.Open();
                 nRecAffected = this.daUniversal.Fill(dt);
                 this.Close();
                 return dt;
             }
         }

        //EmployeeMasterAllDtl
         public DataTable EmployeeMasterAllDtl()
         {
             this.Initialize();
             int nRecAffected = 0;
             DataTable dt = new DataTable();
             using (cnUniversal)
             {
                 cmdUniversal.CommandText = "EmployeeMasterAllData";
                 cmdUniversal.Parameters.Add("@EmpCode", SqlDbType.VarChar).Value = "0";
                 this.daUniversal.SelectCommand = cmdUniversal;
                 this.cnUniversal.Open();
                 nRecAffected = this.daUniversal.Fill(dt);
                 this.Close();
                 return dt;
             }
         }
        //SupplierPO
         public DataTable SupplierPO(MasterFormsReportModal mod)
         {
             this.Initialize();
             int nRecAffected = 0;
             DataTable dt = new DataTable();
             using (cnUniversal)
             {
                 cmdUniversal.CommandText = "Rpt_SupplierPo_Report";
                 cmdUniversal.Parameters.Add("@SupplierPONo", SqlDbType.VarChar).Value = mod.SupplierPONo;
                 this.daUniversal.SelectCommand = cmdUniversal;
                 this.cnUniversal.Open();
                 nRecAffected = this.daUniversal.Fill(dt);
                 this.Close();
                 return dt;
             }
         }
        //RptIndetDetailIReport
         public DataTable RptIndetDetailIReport(MasterFormsReportModal mod)
         {
             this.Initialize();
             int nRecAffected = 0;
             DataTable dt = new DataTable();
             using (cnUniversal)
             {
                 cmdUniversal.CommandText = "RptIndetDetailIReport";
                 cmdUniversal.Parameters.Add("@IndentNo", SqlDbType.VarChar).Value =mod.IndentNoAutoGen;
                 this.daUniversal.SelectCommand = cmdUniversal;
                 this.cnUniversal.Open();
                 nRecAffected = this.daUniversal.Fill(dt);
                 this.Close();
                 return dt;
             }
         }

        //RptMsvhinrVsCheckPointMachineWise
         public DataTable RptMsvhinrVsCheckPointMachineWise(MasterFormsReportModal mod)
         {
             this.Initialize();
             int nRecAffected = 0;
             DataTable dt = new DataTable();
             using (cnUniversal)
             {
                 cmdUniversal.CommandText = "RptMachineVsCheckPoint";
                 cmdUniversal.Parameters.Add("@MachineCode", SqlDbType.VarChar).Value = mod.MachineCode;
                 this.daUniversal.SelectCommand = cmdUniversal;
                 this.cnUniversal.Open();
                 nRecAffected = this.daUniversal.Fill(dt);
                 this.Close();
                 return dt;
             }
         }


    }
}
