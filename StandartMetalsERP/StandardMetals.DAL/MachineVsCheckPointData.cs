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
    public class MachineVsCheckPointData : ConncetionClass
    {
        MachineVsCheckPointModel MVCModel = new MachineVsCheckPointModel();

        public DataTable BindMachineCode(MachineVsCheckPointModel MVCModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindMachineCode";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable GetMachineVsCheckPoint(MachineVsCheckPointModel MVCModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetMachineVsCheckPoint";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Add("@cid", SqlDbType.Int).Value = MVCModel.cid;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable BindMachineName(MachineVsCheckPointModel MVCModel)
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

        public DataTable AllMachineVsCheckPoint(MachineVsCheckPointModel MVCModel)
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




        public int InsertMachineVsCheckPoint(MachineVsCheckPointModel MVCMODEL)
        {

            SqlTransaction trans;
            this.Initialize();
            int nRecAffected = 0;
            using (cnUniversal)
            {
                cnUniversal.Open();
                trans = cnUniversal.BeginTransaction();
                try
                {
                    cmdUniversal = new SqlCommand("InsertMachineVsCheckPoint", cnUniversal, trans);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);

                    foreach (var mcmodel in MVCMODEL.AllData)
                    { 
                      
                    cmdUniversal.Parameters["@cid"].Value = mcmodel.cid;
                    cmdUniversal.Parameters["@MachineCode"].Value = mcmodel.MachineCode;
                    cmdUniversal.Parameters["@Location"].Value = mcmodel.Location;
                    cmdUniversal.Parameters["@Parameter"].Value = mcmodel.Parameter;
                    cmdUniversal.Parameters["@Check_Point"].Value = mcmodel.Check_Point;
                    cmdUniversal.Parameters["@PlanType"].Value = mcmodel.PlanType;
                    cmdUniversal.Parameters["@Scheduler"].Value = mcmodel.Scheduler;
                    // cmdUniversal.Parameters["@EnteryDate"].Value = mcmodel.EnteryDate;
                    cmdUniversal.Parameters["@CmpName"].Value = mcmodel.CmpName;
                    cmdUniversal.Parameters["@IPAddress"].Value = mcmodel.IPAddress;
                    cmdUniversal.Parameters["@FinancialYear"].Value = mcmodel.FinancialYear;
                    cmdUniversal.Parameters["@UserName"].Value = mcmodel.UserName;
                    cmdUniversal.Parameters["@Password"].Value = mcmodel.Password;
                    cmdUniversal.Parameters["@SrNo"].Value = mcmodel.SrNo;
                    cmdUniversal.ExecuteNonQuery();
                    
                    }
                    
                    trans.Commit();
                    this.Close();
                    return nRecAffected = 1;

                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    cnUniversal.Close();
                    return nRecAffected = 0;
                }

            }
        }

        public DataTable DuplicateEntryData(MachineVsCheckPointModel MVCModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "DuplicateEntry";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Add("@MachineCode", SqlDbType.VarChar, 100).Value = MVCModel.MachineCode;
                cmdUniversal.Parameters.Add("@PlanType", SqlDbType.VarChar, 100).Value = MVCModel.PlanType;
                cmdUniversal.Parameters.Add("@Check_Point", SqlDbType.VarChar, 100).Value = MVCModel.Check_Point;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }


















    }
}
