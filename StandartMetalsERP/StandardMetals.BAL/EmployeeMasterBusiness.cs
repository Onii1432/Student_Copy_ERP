using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using Modal;

namespace StandardMetals.BAL
{
    public sealed class EmployeeMasterBusiness
    {
        EmployeeMasterData empData = new EmployeeMasterData();


        private static EmployeeMasterBusiness obj = null;
        private EmployeeMasterBusiness()
      { 
      
      }

        public static EmployeeMasterBusiness GetEmployeeObject()
    {
        if (obj == null)
        {
            obj = new EmployeeMasterBusiness();
        }
        return obj;
    }



        public DataTable radEmpSearch(EmployeeMasterModel empModel)
        {
            return empData.radEmpSearch(empModel);
        }

        public DataTable BindAllEmployeeDropDownList(EmployeeMasterModel empModel)
        {

            return empData.BindAllEmployeeDropDownList(empModel);
        }

        public DataTable BindBloodGroup(EmployeeMasterModel empModel)
        {

            return empData.BindBloodGroup(empModel);
        }

        public DataTable BindQualification(EmployeeMasterModel empModel)
        {

            return empData.BindQualification(empModel);
        }

        public DataTable BindDesignation(EmployeeMasterModel empModel)
        {

            return empData.BindDesignation(empModel);
        }

        public DataTable BindDepartment(EmployeeMasterModel empModel)
        {

            return empData.BindDepartment(empModel);
        }

        public DataTable BindCategory(EmployeeMasterModel empModel)
        {

            return empData.BindCategory(empModel);
        }

        public DataTable BindWeekOf(EmployeeMasterModel empModel)
        {

            return empData.BindWeekOf(empModel);
        }

        public DataTable BindContractor(EmployeeMasterModel empModel)
        {

            return empData.BindContractor(empModel);
        }

        public DataTable BindTypeOfStaff(EmployeeMasterModel empModel)
        {

            return empData.BindTypeOfStaff(empModel);
        }

        public DataTable BindPayType(EmployeeMasterModel empModel)
        {

            return empData.BindPayType(empModel);
        }

        public DataTable Bindunit(EmployeeMasterModel empModel)
        {

            return empData.Bindunit(empModel);
        }

        public DataTable BindMaritalStatus(EmployeeMasterModel empModel)
        {

            return empData.BindMaritalStatus(empModel);
        }

        public DataTable BindLeave(EmployeeMasterModel empModel)
        {

            return empData.BindLeave(empModel);
        }

        public DataTable FillEmployeeDetails(EmployeeMasterModel empModel)
        {
            return empData.FillEmployeeDetails(empModel);
        }

        public int InsertEmployeeData(EmployeeMasterModel empModel)
        {

            return empData.InsertEmployeeData(empModel);
        }

        public int UpdateEmployeeData(EmployeeMasterModel emoModel)
        {
            return empData.UpdateEmployeeData(emoModel);
        }
        //DeleteEmployeeDetails

        public int DeleteEmployeeDetails(EmployeeMasterModel emoModel)
        {
            return empData.DeleteEmployeeDetails(emoModel);
        }




    }
}
