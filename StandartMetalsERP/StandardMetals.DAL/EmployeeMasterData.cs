using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;
using Modal;


namespace StandardMetals.DAL
{
    public class EmployeeMasterData : ConncetionClass
    {
        
        public DataTable radEmpSearch(EmployeeMasterModel empModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindEmpSearch";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable BindAllEmployeeDropDownList(EmployeeMasterModel empModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindAllEmployeeDropDownList";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Add("@Action", SqlDbType.VarChar, 100).Value = "Gender";
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable BindBloodGroup(EmployeeMasterModel empModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindAllEmployeeDropDownList";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Add("@Action", SqlDbType.VarChar, 100).Value = "BloodGroup";
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }

        }

        public DataTable BindQualification(EmployeeMasterModel empModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindAllEmployeeDropDownList";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Add("@Action", SqlDbType.VarChar, 100).Value = "QualificationName";
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }

        }

        public DataTable BindDesignation(EmployeeMasterModel empModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindAllEmployeeDropDownList";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Add("@Action", SqlDbType.VarChar, 100).Value = "Designation";
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }

        }

        public DataTable BindDepartment(EmployeeMasterModel empModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindAllEmployeeDropDownList";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Add("@Action", SqlDbType.VarChar, 100).Value = "Department";
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }

        }


        public DataTable BindCategory(EmployeeMasterModel empModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindAllEmployeeDropDownList";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Add("@Action", SqlDbType.VarChar, 100).Value = "Category";
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }

        }


        public DataTable BindWeekOf(EmployeeMasterModel empModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindAllEmployeeDropDownList";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Add("@Action", SqlDbType.VarChar, 100).Value = "WeekOf";
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }

        }


        public DataTable BindContractor(EmployeeMasterModel empModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindAllEmployeeDropDownList";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Add("@Action", SqlDbType.VarChar, 100).Value = "Contractor";
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }

        }

        public DataTable BindTypeOfStaff(EmployeeMasterModel empModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindAllEmployeeDropDownList";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Add("@Action", SqlDbType.VarChar, 100).Value = "TypeOfStaff";
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }

        }

        public DataTable BindPayType(EmployeeMasterModel empModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindAllEmployeeDropDownList";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Add("@Action", SqlDbType.VarChar, 100).Value = "PayType";
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }

        }

        public DataTable Bindunit(EmployeeMasterModel empModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindAllEmployeeDropDownList";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Add("@Action", SqlDbType.VarChar, 100).Value = "UnitName";
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }

        }

        public DataTable BindMaritalStatus(EmployeeMasterModel empModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindAllEmployeeDropDownList";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Add("@Action", SqlDbType.VarChar, 100).Value = "MaritalStatus";
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }

        }

        public DataTable BindLeave(EmployeeMasterModel empModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindAllEmployeeDropDownList";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Add("@Action", SqlDbType.VarChar, 100).Value = "LeaveName";
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }

        }

        //FillEmployeeDetails
        public DataTable FillEmployeeDetails(EmployeeMasterModel empModel)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "FillEmployeeDetails";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Add("@EmpCode", SqlDbType.VarChar, 100).Value = empModel.EmpCode;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }

        }

        public int InsertEmployeeData(EmployeeMasterModel empmodel)
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
                    cmdUniversal = new SqlCommand("InsertEmployeeData", cnUniversal, trans);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);
                    cmdUniversal.Parameters["@EmpCode"].Value = empmodel.EmpCode;
                    cmdUniversal.Parameters["@Title"].Value = empmodel.Title;
                    cmdUniversal.Parameters["@FristName"].Value = empmodel.FristName;
                    cmdUniversal.Parameters["@MiddleName"].Value = empmodel.MiddleName;
                    cmdUniversal.Parameters["@LastName"].Value = empmodel.LastName;
                    cmdUniversal.Parameters["@ContactNo"].Value = empmodel.ContactNo;
                    cmdUniversal.Parameters["@MobileNo"].Value = empmodel.MobileNo;
                    cmdUniversal.Parameters["@EmailId"].Value = empmodel.EmailId;
                    cmdUniversal.Parameters["@DOB"].Value = empmodel.DOB;
                    cmdUniversal.Parameters["@GenderID"].Value = empmodel.GID;
                    cmdUniversal.Parameters["@BloodGroupID"].Value = empmodel.BloodGroupID;
                    cmdUniversal.Parameters["@MaritalStatusID"].Value = empmodel.MSID;
                    cmdUniversal.Parameters["@CTC"].Value = empmodel.CTC;
                    cmdUniversal.Parameters["@GrossAmount"].Value = empmodel.GrossAmount;
                    cmdUniversal.Parameters["@TempAddress"].Value = empmodel.TempAddress;
                    cmdUniversal.Parameters["@DocumentName"].Value = empmodel.DocumentName;
                    cmdUniversal.Parameters["@TrainingDetails"].Value = empmodel.TrainingDetails;
                    cmdUniversal.Parameters["@PanNo"].Value = empmodel.PanNo;
                    cmdUniversal.Parameters["@ESICACCNO"].Value = empmodel.ESICACCNO;
                    cmdUniversal.Parameters["@AutoMail"].Value = empmodel.AutoMail;
                    cmdUniversal.Parameters["@LeaveRule"].Value = empmodel.LeaveId;
                    cmdUniversal.Parameters["@AttendanceID"].Value = empmodel.AttendanceID;
                    cmdUniversal.Parameters["@EmpPhoto"].Value = empmodel.EmpPhoto;
                    cmdUniversal.Parameters["@DateofJoin"].Value = empmodel.DateofJoin;
                    cmdUniversal.Parameters["@Qualification"].Value = empmodel.QualificationId;
                    cmdUniversal.Parameters["@Designation"].Value = empmodel.DesignationId;
                    cmdUniversal.Parameters["@DepartmentID"].Value = empmodel.did;
                    cmdUniversal.Parameters["@Category"].Value = empmodel.CategoryId;
                    cmdUniversal.Parameters["@WeekOffID"].Value = empmodel.WID;
                    cmdUniversal.Parameters["@Contractor"].Value = empmodel.ContractorId;
                    cmdUniversal.Parameters["@TypeofStaff"].Value = empmodel.StaffId;
                    cmdUniversal.Parameters["@PayType"].Value = empmodel.PayTypeId;
                    cmdUniversal.Parameters["@Unit"].Value = empmodel.UnitId;
                    cmdUniversal.Parameters["@AadharNo"].Value = empmodel.AadharNo;
                    cmdUniversal.Parameters["@Balance"].Value = empmodel.Balance;
                    cmdUniversal.Parameters["@PermanentAddress"].Value = empmodel.PermanentAddress;
                    cmdUniversal.Parameters["@Asset"].Value = empmodel.Asset;
                    cmdUniversal.Parameters["@ApprasalHistory"].Value = empmodel.ApprasalHistory;
                    cmdUniversal.Parameters["@PFAccNo"].Value = empmodel.PFAccNo;
                    cmdUniversal.Parameters["@IsLeft"].Value = empmodel.IsLeft;
                    cmdUniversal.Parameters["@LeftDate"].Value = empmodel.LeftDate;
                    cmdUniversal.ExecuteNonQuery();
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

        //UpdateEmployeeData
        public int UpdateEmployeeData(EmployeeMasterModel empModel)
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
                    cmdUniversal = new SqlCommand("UpdateEmployeeData", cnUniversal, trans);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);
                    cmdUniversal.Parameters["@EmpCode"].Value = empModel.EmpCode;
                    cmdUniversal.Parameters["@Title"].Value = empModel.Title;
                    cmdUniversal.Parameters["@FristName"].Value = empModel.FristName;
                    cmdUniversal.Parameters["@MiddleName"].Value = empModel.MiddleName;
                    cmdUniversal.Parameters["@LastName"].Value = empModel.LastName;
                    cmdUniversal.Parameters["@ContactNo"].Value = empModel.ContactNo;
                    cmdUniversal.Parameters["@MobileNo"].Value = empModel.MobileNo;
                    cmdUniversal.Parameters["@EmailId"].Value = empModel.EmailId;
                    cmdUniversal.Parameters["@DOB"].Value = empModel.DOB;
                    cmdUniversal.Parameters["@GenderID"].Value = empModel.GID;
                    cmdUniversal.Parameters["@BloodGroupID"].Value = empModel.BloodGroupID;
                    cmdUniversal.Parameters["@MaritalStatusID"].Value = empModel.MSID;
                    cmdUniversal.Parameters["@CTC"].Value = empModel.CTC;
                    cmdUniversal.Parameters["@GrossAmount"].Value = empModel.GrossAmount;
                    cmdUniversal.Parameters["@TempAddress"].Value = empModel.TempAddress;
                    cmdUniversal.Parameters["@DocumentName"].Value = empModel.DocumentName;
                    cmdUniversal.Parameters["@TrainingDetails"].Value = empModel.TrainingDetails;
                    cmdUniversal.Parameters["@PanNo"].Value = empModel.PanNo;
                    cmdUniversal.Parameters["@ESICACCNO"].Value = empModel.ESICACCNO;
                    cmdUniversal.Parameters["@AutoMail"].Value = empModel.AutoMail;
                    cmdUniversal.Parameters["@LeaveRule"].Value = empModel.LeaveId;
                    cmdUniversal.Parameters["@AttendanceID"].Value = empModel.AttendanceID;
                    cmdUniversal.Parameters["@EmpPhoto"].Value = empModel.EmpPhoto;
                    cmdUniversal.Parameters["@DateofJoin"].Value = empModel.DateofJoin;
                    cmdUniversal.Parameters["@Qualification"].Value = empModel.QualificationId;
                    cmdUniversal.Parameters["@Designation"].Value = empModel.DesignationId;
                    cmdUniversal.Parameters["@DepartmentID"].Value = empModel.did;
                    cmdUniversal.Parameters["@Category"].Value = empModel.CategoryId;
                    cmdUniversal.Parameters["@WeekOffID"].Value = empModel.WID;
                    cmdUniversal.Parameters["@Contractor"].Value = empModel.ContractorId;
                    cmdUniversal.Parameters["@TypeofStaff"].Value = empModel.StaffId;
                    cmdUniversal.Parameters["@PayType"].Value = empModel.PayTypeId;
                    cmdUniversal.Parameters["@Unit"].Value = empModel.UnitId;
                    cmdUniversal.Parameters["@AadharNo"].Value = empModel.AadharNo;
                    cmdUniversal.Parameters["@Balance"].Value = empModel.Balance;
                    cmdUniversal.Parameters["@PermanentAddress"].Value = empModel.PermanentAddress;
                    cmdUniversal.Parameters["@Asset"].Value = empModel.Asset;
                    cmdUniversal.Parameters["@ApprasalHistory"].Value = empModel.ApprasalHistory;
                    cmdUniversal.Parameters["@PFAccNo"].Value = empModel.PFAccNo;
                    cmdUniversal.Parameters["@IsLeft"].Value = empModel.IsLeft;
                    cmdUniversal.Parameters["@LeftDate"].Value = empModel.LeftDate;
                    cmdUniversal.ExecuteNonQuery();
                    trans.Commit();
                    this.Close();
                    return nRecAffected = 1;
                }
                catch(Exception ex)
                {
                    trans.Rollback();
                    cnUniversal.Close();
                    return nRecAffected = 0;
                }
            }
        }

        //DeleteEmployeeDetails
        public int DeleteEmployeeDetails(EmployeeMasterModel empModel)
        {
            DataTable dt = new DataTable();

            this.Initialize();
            int nRecAffected = 0;
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "DeleteEmployeeDetails";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Add("@EmpCode", SqlDbType.Int).Value = empModel.EmpCode;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return nRecAffected = 1;
            }
        }














    }
}
