// 16/08/2026

using System;
using System.Collections.Generic;
using System.Web.Http;
using StandardMetals.BAL;
using StandardMetals.MODEL;
using StandardMetals.CommonLibrary;

namespace StandardMetals.WebAPI.Controllers
{
    public class CustomerMasterApril2026ApiController : ApiController
    {
        CustomerMasterMVCApril2026BAL customerBAL = new CustomerMasterMVCApril2026BAL();


        // GET http://localhost:62335/CustomerMasterApril2026Api/GetAllCustomerMaster
        [HttpGet]
        public List<CustomerMasterMVCApril2026Model> GetAllCustomerMaster()
        {
            LogInfo.LogDetailToFile("CustomerMasterApril2026ApiController-GetAllCustomerMaster Action(httpget)- Start");

            List<CustomerMasterMVCApril2026Model> result = customerBAL.GetAllCustomerMaster();

            LogInfo.LogDetailToFile("GetAllCustomerMaster - Customer List Loaded");
            LogInfo.LogDetailToFile("CustomerMasterApril2026ApiController-GetAllCustomerMaster Action(httpget)- Start-End");

            return result;
        }


        // GET http://localhost:62335/CustomerMasterApril2026Api/GetCustomerById/{id}
        [HttpGet]
        public CustomerMasterMVCApril2026Model GetCustomerById(int id)
        {
            LogInfo.LogDetailToFile("CustomerMasterApril2026ApiController-GetCustomerById Action(httpget)- Start");

            LogInfo.LogDetailToFile("GetCustomerById - Customer Id : " + id);

            CustomerMasterMVCApril2026Model result = customerBAL.GetCustomerMasterById(id);

            LogInfo.LogDetailToFile("GetCustomerById - Customer Details Loaded");
            LogInfo.LogDetailToFile("CustomerMasterApril2026ApiController-GetCustomerById Action(httpget)- Start-End");

            return result;
        }


        // POST http://localhost:62335/CustomerMasterApril2026Api/CreateCustomer
        [HttpPost]
        public string CreateCustomer(CustomerMasterMVCApril2026Model model)
        {
            LogInfo.LogDetailToFile("CustomerMasterApril2026ApiController-CreateCustomer Action(httppost)- Start");

            string result = customerBAL.SaveCustomerMaster(model);

            LogInfo.LogDetailToFile("CreateCustomer - Customer Save Completed : " + result);
            LogInfo.LogDetailToFile("CustomerMasterApril2026ApiController-CreateCustomer Action(httppost)- Start-End");

            return result;
        }


        // PUT http://localhost:62335/CustomerMasterApril2026Api/UpdateCustomer/{id}
        [HttpPut]
        public int UpdateCustomer(int id, CustomerMasterMVCApril2026Model model)
        {
            LogInfo.LogDetailToFile("CustomerMasterApril2026ApiController-UpdateCustomer Action(httpput)- Start");

            LogInfo.LogDetailToFile("UpdateCustomer - Customer Id : " + id);

            model.Id = id;

            int result = customerBAL.UpdateCustomerMaster(model);

            LogInfo.LogDetailToFile("UpdateCustomer - Update Result : " + result);
            LogInfo.LogDetailToFile("CustomerMasterApril2026ApiController-UpdateCustomer Action(httpput)- Start-End");

            return result;
        }


        // DELETE http://localhost:62335/CustomerMasterApril2026Api/DeleteCustomer/{id}
        [HttpDelete]
        public int DeleteCustomer(int id)
        {
            LogInfo.LogDetailToFile("CustomerMasterApril2026ApiController-DeleteCustomer Action(httpdelete)- Start");

            LogInfo.LogDetailToFile("DeleteCustomer - Customer Id : " + id);

            int result = customerBAL.DeleteCustomerMasterById(id);

            LogInfo.LogDetailToFile("DeleteCustomer - Delete Result : " + result);
            LogInfo.LogDetailToFile("CustomerMasterApril2026ApiController-DeleteCustomer Action(httpdelete)- Start-End");

            return result;
        }
    }
}