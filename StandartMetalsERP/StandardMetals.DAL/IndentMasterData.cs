using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modal;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace StandardMetals.DAL
{
    public class IndentMasterData : ConncetionClass
    {

        public DataTable AllIndentDtl(IndentMasterModel IMM)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "RptIndetDetailIReport";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        //BindIndentNumber
        public DataTable BindIndentNumber(IndentMasterModel IndentModal)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindIndentNumber";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        //GetMaxIndentNumber
        public DataTable GetMaxIndentNumber(IndentMasterModel IndentModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetMaxIndentNumber";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }
        //BindItemMaster
        public DataTable BindItemMaster(IndentMasterModel IndentModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindItemMaster";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        //BindDepartment
        public DataTable BindDepartment(IndentMasterModel IndentModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindDepartment";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }
        //BindUnit
        public DataTable BindUnit(IndentMasterModel IndentModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindUnit";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }
        //BindEmployee
        public DataTable BindEmployee(IndentMasterModel IndentModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindEmployee";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }
        //FindCurrentStock
        public DataTable FindCurrentStock(IndentMasterModel IndentModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "FindCurrentStock";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Add("@ItemCode", SqlDbType.VarChar).Value = IndentModel.ItemCode;
                cmdUniversal.Parameters.Add("@Branch", SqlDbType.VarChar).Value = IndentModel.Branch;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }
        //drpIndetType
        public DataTable BindIndentType(IndentMasterModel IndentModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindIndentType";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        //FindDeparmentId
        public DataTable FindDeparmentId(string DepartmentName)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = @"select did,dname from DepartmentMaster where dname like '%" + DepartmentName + "%'";
                cmdUniversal.CommandType = CommandType.Text;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public int InsertIndentMaster(IndentMasterModel IndentModel)
        {

            this.Initialize();
            int Result = 0;

            using (cnUniversal)
            {
                // cnUniversal.Open();
                cmdUniversal.CommandText = "InsertIndentMaster";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                //  SqlCommandBuilder.DeriveParameters(cmdUniversal);
                cnUniversal.Open();

               
                    //    cmdUniversal.Parameters["@IndentNoAutoGen"].Value = IndentItModel.IndentNoAutoGen;
                    //    cmdUniversal.Parameters["@IndentTypeId"].Value =IndentItModel.IndentTypeId;
                    ////  cmdUniversal.Parameters["@IndentDate"].Value = IndentItModel.IndentDate;
                    //    cmdUniversal.Parameters["@IndentRemark"].Value = IndentItModel.Remark;
                    //    cmdUniversal.Parameters["@IndentNote"].Value = IndentItModel.Remark;
                    //    cmdUniversal.Parameters["@CreatedBy"].Value = IndentItModel.Createdby;

                cmdUniversal.Parameters.AddWithValue("@IndentNoAutoGen", IndentModel.IndentNoAutoGen);
                cmdUniversal.Parameters.AddWithValue("@IndentTypeId", IndentModel.IndentTypeId);
                cmdUniversal.Parameters.AddWithValue("@IndentRemark", IndentModel.Remark);
                cmdUniversal.Parameters.AddWithValue("@IndentNote", IndentModel.Remark);
                cmdUniversal.Parameters.AddWithValue("@CreatedBy", IndentModel.Createdby);

                    //   Add the output parameter to the command object
                    SqlParameter outPutParameter = new SqlParameter();
                    outPutParameter.ParameterName = "@IndentId";
                    outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outPutParameter.Direction = System.Data.ParameterDirection.Output;
                    cmdUniversal.Parameters.Add(outPutParameter);

                    cmdUniversal.ExecuteNonQuery();
                    Result = Convert.ToInt32(outPutParameter.Value.ToString());

                

                    cmdUniversal.CommandText = "InsertIndentDetailMaster";
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);
                    foreach (var IndentDtlModel in IndentModel.AllData)
                    {
                        cmdUniversal.Parameters["@IndentId"].Value = IndentDtlModel.IndentId;
                        cmdUniversal.Parameters["@ItemCode"].Value = IndentDtlModel.ItemCode;
                        cmdUniversal.Parameters["@ItemName"].Value = IndentDtlModel.ItemName;
                        cmdUniversal.Parameters["@Specification"].Value = IndentDtlModel.Specification;
                        cmdUniversal.Parameters["@DrawingNo"].Value = IndentDtlModel.DrowingNo;
                        cmdUniversal.Parameters["@DepartmentId"].Value = IndentDtlModel.Department;
                        cmdUniversal.Parameters["@Purpose"].Value = IndentDtlModel.Purpose;
                        cmdUniversal.Parameters["@CurrentStock"].Value = Convert.ToDecimal(IndentDtlModel.CurrentStock);
                        cmdUniversal.Parameters["@RequiredDate"].Value = IndentDtlModel.RequirdDate;
                        cmdUniversal.Parameters["@RequiredQuantity"].Value = Convert.ToDecimal(IndentDtlModel.RequiredQuantity);
                        cmdUniversal.Parameters["@RequiredQuantityUnit"].Value = IndentDtlModel.RequiredQuentityUnit;
                        // cmdUniversal.Parameters["@IsApporved"].Value = IndeontDtlModel.IsApporved;
                        cmdUniversal.ExecuteNonQuery();
                    }

                    this.Close();
                    return Result;

            }
        }

        
        
        public int UpdateIndentMaster(IndentMasterModel IndentModel)
        {
            int Result = 0;
            try
            {
                this.Initialize();
                

                using (cnUniversal)
                {
                    // cnUniversal.Open();
                    cmdUniversal.CommandText = "Update_IndentMaster";
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    //  SqlCommandBuilder.DeriveParameters(cmdUniversal);
                    cnUniversal.Open();

                    cmdUniversal.Parameters.AddWithValue("@IndentId", IndentModel.IndentId);
                    //cmdUniversal.Parameters.AddWithValue("@IndentNoAutoGen", IndentModel.IndentNoAutoGen);
                    cmdUniversal.Parameters.AddWithValue("@IndentTypeId", IndentModel.IndentTypeId);
                    cmdUniversal.Parameters.AddWithValue("@IndentRemark", IndentModel.Remark);
                    cmdUniversal.Parameters.AddWithValue("@IndentNote", IndentModel.Remark);
                    cmdUniversal.Parameters.AddWithValue("@CreatedBy", IndentModel.Createdby);
                     Result= cmdUniversal.ExecuteNonQuery();

                    cmdUniversal.CommandText = "InsertIndentDetailMaster";
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);
                    foreach (var IndentDtlModel in IndentModel.AllData)
                    {
                        cmdUniversal.Parameters["@IndentId"].Value = IndentModel.IndentId; 
                        cmdUniversal.Parameters["@ItemCode"].Value = IndentDtlModel.ItemCode;
                        cmdUniversal.Parameters["@ItemName"].Value = IndentDtlModel.ItemName;
                        cmdUniversal.Parameters["@Specification"].Value = IndentDtlModel.Specification;
                        cmdUniversal.Parameters["@DrawingNo"].Value = IndentDtlModel.DrowingNo;
                        cmdUniversal.Parameters["@DepartmentId"].Value = IndentDtlModel.Department;
                        cmdUniversal.Parameters["@Purpose"].Value = IndentDtlModel.Purpose;
                        cmdUniversal.Parameters["@CurrentStock"].Value = Convert.ToDecimal(IndentDtlModel.CurrentStock);
                        cmdUniversal.Parameters["@RequiredDate"].Value = IndentDtlModel.RequirdDate;
                        cmdUniversal.Parameters["@RequiredQuantity"].Value = Convert.ToDecimal(IndentDtlModel.RequiredQuantity);
                        cmdUniversal.Parameters["@RequiredQuantityUnit"].Value = IndentDtlModel.RequiredQuentityUnit;
                        // cmdUniversal.Parameters["@IsApporved"].Value = IndeontDtlModel.IsApporved;
                        cmdUniversal.ExecuteNonQuery();
                    }

                    this.Close();
                    
                }
               

            }
            
            catch (Exception Ex)
            {
 
            }
            return Result;
        }



        public DataTable FillIndentMaster(int IndentId)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "FillIndentMaster";
                cmdUniversal.Parameters.Add("@IndentId", SqlDbType.VarChar).Value = IndentId;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable BindGridIndentDetails(string ItemCode)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindGridIndentDetails";
                cmdUniversal.Parameters.Add("@ItemCode", SqlDbType.VarChar).Value = ItemCode;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }
       
    }
}