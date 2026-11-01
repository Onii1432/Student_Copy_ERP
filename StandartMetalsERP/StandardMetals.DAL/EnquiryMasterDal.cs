using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modal;
using System.Data.SqlClient;
using System.Data;

namespace StandardMetals.DAL
{
    public class EnquiryMasterDal : ConncetionClass
    {
        public DataTable BindProductCategory()
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "Marketing_GetProductCategory";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable BindDeliveryType()
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using(cnUniversal)
            {
                cmdUniversal.CommandText = "Marketing_GetDeliveryType";
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }      
        }

        public DataTable BindMedOfEnq()
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "Marketing_GetMedOfEnq";
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable BindCustomer()
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "Marketing_BindCustomer";
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }

        }
        
        //public DataTable BindCustItemData()
        //{
        //    this.Initialize();
        //    int nRecAffected = 0;
        //    DataTable dt = new DataTable();
        //    using (cnUniversal)
        //    {
        //        cmdUniversal.CommandText = "Marketing_BindCustItemsDtls";
        //        cmdUniversal.CommandType = CommandType.StoredProcedure;
        //        //cmdUniversal.Parameters.Add("@ItemCode", SqlDbType.VarChar).Value = ItemCode;
        //        this.daUniversal.SelectCommand = cmdUniversal;
        //        this.cnUniversal.Open();
        //        nRecAffected = this.daUniversal.Fill(dt);
        //        this.Close();
        //        return dt;
        //    }
        //}
        
        public DataTable BindEnquiryNumber(EnquiryMasterModel model)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "Marketing_BindEnquiryNumber";
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        //EM.EnquiryId, EM.EnquiryNumber,EM.EnquiryDate, EM.EnqRefNumber, EM.IsNewCustomer,
        //EM.NewCustCode, EM.NewCustName, EM.Address1, EM.ContactPerson,
        //EM.SystEmentryDate, EM.Remark,EM.QuotationNumber, 
        //EM.QuotationDate, EM.SampleStatus, EM.SampleRequiredDate, EM.SampleProductionDate,		
        //EM.SampleSubmissionQuantity, EM.SampeSubmissionDate, EM.CustomerCode,

        //MEM.MedOfEnqID, MEM.MedOfEnqName,
		
        //CM.CustCode, CM.CustName, CM.Id,
		
        //CatM.CategoryName, CatM.CategoryId,
		
        //SP.supptype, SP.supptypeid,
		
        //EDM.EnquiryDetailId, EDM.EnquiryId, EDM.Quantity, EDM.ItemId, EDM.IsNewItem,
        //EDM.NewItemCode, EDM.NewItemName, EDM.SystemEntryDate, 
		
        //IM.ItemCode, IM.ItemName	

        public List<EnquiryMasterModel> GetAllEnquiryData()
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "Marketing_GetAllEnquiryData";
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();

                List<EnquiryMasterModel> lst = new List<EnquiryMasterModel>();
                if (dt.Rows.Count > 0)
                {
                    for(int i=0; i<dt.Rows.Count; i++)
                    {
                        lst.Add(new EnquiryMasterModel(){
                        EnquiryId = Convert.ToInt32( dt.Rows[i]["EnquiryId"]),
                        EnquiryNumber = dt.Rows[i]["EnquiryNumber"].ToString(),
                        EnquiryDate = Convert.ToDateTime( dt.Rows[i]["EnquiryDate"]),
                        EnqRefNumber = dt.Rows[i]["EnqRefNumber"].ToString(),
                        IsNewCustomer = Convert.ToBoolean( dt.Rows[i]["IsNewCustomer"]),
                        NewCustCode = dt.Rows[i]["NewCustCode"].ToString(),
                        NewCustName = dt.Rows[i]["NewCustName"].ToString(),
                        Address = dt.Rows[i]["Address1"].ToString(),
                        ContactPerson = dt.Rows[i]["ContactPerson"].ToString(),
                        SystemEntryDate = Convert.ToDateTime( dt.Rows[i]["SystEmentryDate"]),
                        Remark = dt.Rows[i]["Remark"].ToString(),
                        QuotationNumber = dt.Rows[i]["QuotationNumber"].ToString(),
                        QuotationDate = Convert.ToDateTime( dt.Rows[i]["QuotationDate"]),
                        SampleStatus = dt.Rows[i]["SampleStatus"].ToString(),
                        SampleRequiredDate = Convert.ToDateTime(dt.Rows[i]["SampleRequiredDate"]),
                        SampleProductionDate = Convert.ToDateTime(dt.Rows[i]["SampleProductionDate"]),
                        SampleSubmissionQuantity = dt.Rows[i]["SampleSubmissionQuantity"].ToString(),
                        SampeSubmissionDate = Convert.ToDateTime(dt.Rows[i]["SampeSubmissionDate"]),
                        CustomerCode = dt.Rows[i]["CustomerCode"].ToString(),
                     //   MedOfEnqId = Convert.ToInt32(dt.Rows[i]["MedOfEnqID"]),
                     //   CustomerId = Convert.ToInt32(dt.Rows[i]["Id"]),
                        CustomerName = dt.Rows[i]["CustName"].ToString(),
                     //   CategoryId = Convert.ToInt32(dt.Rows[i]["CategoryId"]),
                     //   SuppTypeId = Convert.ToInt32(dt.Rows[i]["supptypeid"]),
                        EnqDetailId = Convert.ToInt32(dt.Rows[i]["EnquiryDetailId"]),
                        Quantity = Convert.ToDecimal(dt.Rows[i]["Quantity"]),
                      //  ItemId = Convert.ToInt32(dt.Rows[i]["ItemId"]),
                        IsNewItem = Convert.ToBoolean(dt.Rows[i]["IsNewItem"]),
                        NewItemCode = dt.Rows[i]["NewItemCode"].ToString(),
                        NewItemName = dt.Rows[i]["NewItemName"].ToString(),
                        ItemCode = dt.Rows[i]["ItemCode"].ToString(),
                        ItemName = dt.Rows[i]["ItemName"].ToString()
                        });
                    }
                }
                return lst;
            }
        }



        public DataTable BindCustDtls(string CustCode)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "Marketing_BindCustDtls";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Add("@CustCode", SqlDbType.VarChar).Value = CustCode;
                this.daUniversal.SelectCommand = cmdUniversal; ;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable BindItemsDataDtls(string ItemCode)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "Marketing_BindItemDetails";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Add("@ItemCode", SqlDbType.VarChar).Value = ItemCode;
                this.daUniversal.SelectCommand = cmdUniversal; ;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable GetAutoGenEnqNumber(EnquiryMasterModel model)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "Marketing_GetAutoGenEnqNumber";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public int InsertEnquiryMaster(EnquiryMasterModel model, out string EnquiryNumber)
        {
            int result = 0;
            EnquiryNumber = " ";
            try 
            { 
                this.Initialize();                
                using (cnUniversal)
                {

  
                    cmdUniversal.CommandText = "Markting_InsertEnquiryMaster";
                    cmdUniversal.CommandType = CommandType.StoredProcedure;

                    cnUniversal.Open();
                     cmdUniversal.Parameters.AddWithValue("@EnquiryDate", model.EnquiryDate);
                    cmdUniversal.Parameters.AddWithValue("@EnqRefNumber", model.EnqRefNumber);
                    cmdUniversal.Parameters.AddWithValue("@IsNewCustomer", model.IsNewCustomer);

                    cmdUniversal.Parameters.AddWithValue("@CustomerCode", model.CustomerCode );
                     cmdUniversal.Parameters.AddWithValue("@CategoryID", model.CategoryId);
                    cmdUniversal.Parameters.AddWithValue("@SuppTypeId", model.SuppTypeId);
                    cmdUniversal.Parameters.AddWithValue("@NewCustName", model.NewCustName);
                    cmdUniversal.Parameters.AddWithValue("@NewCustCode", model.NewCustCode);
                    cmdUniversal.Parameters.AddWithValue("@Address1", model.Address);
                    cmdUniversal.Parameters.AddWithValue("@ContactPerson", model.ContactPerson);
                     
                    cmdUniversal.Parameters.AddWithValue("@LoginUserId", model.LoginUserId);
                    cmdUniversal.Parameters.AddWithValue("@BranchId", model.BranchId);
                    cmdUniversal.Parameters.AddWithValue("@Remark", model.Remark);
                    cmdUniversal.Parameters.AddWithValue("@QuotationNumber", model.QuotationNumber);
                    cmdUniversal.Parameters.AddWithValue("@QuotationDate", System.DateTime.Now);
                    cmdUniversal.Parameters.AddWithValue("@SampleStatus", model.SampleStatus);
                    cmdUniversal.Parameters.AddWithValue("@SampleRequiredDate", System.DateTime.Now);
                    cmdUniversal.Parameters.AddWithValue("@SampleProductionDate", System.DateTime.Now);
                    cmdUniversal.Parameters.AddWithValue("@SampleSubmissionQuantity", model.SampleSubmissionQuantity);
                    cmdUniversal.Parameters.AddWithValue("@SampeSubmissionDate", System.DateTime.Now);
                    
                    cmdUniversal.Parameters.AddWithValue("@MedOfEnqId", model.MedOfEnqId);
                    //cmdUniversal.Parameters.Add("@EnquiryNumber", SqlDbType.VarChar, 1).Direction = ParameterDirection.Output;
                    
                    
                    

                    SqlParameter outParam = new SqlParameter();
                    outParam.ParameterName = "@EnquiryId";
                    outParam.SqlDbType = System.Data.SqlDbType.Int;
                    outParam.Direction = System.Data.ParameterDirection.Output;

                    SqlParameter outParamEnqNo = new SqlParameter();
                    outParamEnqNo.ParameterName = "@EnquiryNumber";
                    outParamEnqNo.SqlDbType = SqlDbType.VarChar;
                    outParamEnqNo.Size = 100;
                    outParamEnqNo.Direction = System.Data.ParameterDirection.Output;

                    
                    cmdUniversal.Parameters.Add(outParamEnqNo);
                    cmdUniversal.Parameters.Add(outParam);

                    cmdUniversal.ExecuteNonQuery();
                    result = Convert.ToInt32(outParam.Value.ToString());
                    EnquiryNumber = outParamEnqNo.Value.ToString();


                    cmdUniversal.CommandText = "Marketing_InsertEnquiryDetailMaster";
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);
                    foreach (var EnqDtlModel in model.AllData)
                    {
                        cmdUniversal.Parameters["@EnquiryId"].Value = result;
                        cmdUniversal.Parameters["@ItemCode"].Value = EnqDtlModel.ItemCode;
                        
                        cmdUniversal.Parameters["@NewItemCode"].Value = EnqDtlModel.NewItemCode;
                        cmdUniversal.Parameters["@NewItemName"].Value = EnqDtlModel.NewItemName;
                        cmdUniversal.Parameters["@Quantity"].Value = EnqDtlModel.Quantity;
                        cmdUniversal.Parameters["@IsNewItem"].Value = EnqDtlModel.IsNewItem;
                        cmdUniversal.ExecuteNonQuery();
                    }
                    this.Close();
                }
            }
            catch(Exception ex)
            {
 
            }
            return result;
        }

        public int UpdateEnquiryMaster(EnquiryMasterModel model)
        {
            int result = 0;
            try
            {
                this.Initialize();
                using (cnUniversal)
                {
                    cmdUniversal.CommandText = "Marketing_UpdateEnquiryMaster";
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    cnUniversal.Open();
                    cmdUniversal.Parameters.AddWithValue("@EnquiryId", model.EnquiryId);
                    cmdUniversal.Parameters.AddWithValue("@EnquiryNumber", model.EnquiryNumber);
                    cmdUniversal.Parameters.AddWithValue("@EnquiryDate", model.EnquiryDate);
                    cmdUniversal.Parameters.AddWithValue("@EnqRefNumber", model.EnqRefNumber);
                    cmdUniversal.Parameters.AddWithValue("@IsNewCustomer", model.IsNewCustomer);
                    cmdUniversal.Parameters.AddWithValue("@MedOfEnqId", model.MedOfEnqId);
                    cmdUniversal.Parameters.AddWithValue("@NewCustName", model.NewCustName);
                    cmdUniversal.Parameters.AddWithValue("@NewCustCode", model.NewCustCode);
                    cmdUniversal.Parameters.AddWithValue("@CustomerCode", model.CustomerCode);
                    cmdUniversal.Parameters.AddWithValue("@Address1", model.Address);
                    cmdUniversal.Parameters.AddWithValue("@ContactPerson", model.ContactPerson);
                    cmdUniversal.Parameters.AddWithValue("@SuppTypeId", model.SuppTypeId);
                    cmdUniversal.Parameters.AddWithValue("@CategoryID", model.CategoryId);
                    cmdUniversal.Parameters.AddWithValue("@LoginUserId", model.LoginUserId);
                    cmdUniversal.Parameters.AddWithValue("@BranchId", model.BranchId);
                    cmdUniversal.Parameters.AddWithValue("@Remark", model.Remark);
                    cmdUniversal.Parameters.AddWithValue("@QuotationNumber", model.QuotationNumber);
                    cmdUniversal.Parameters.AddWithValue("@QuotationDate", model.QuotationDate);
                    cmdUniversal.Parameters.AddWithValue("@SampleStatus", model.SampleStatus);
                    cmdUniversal.Parameters.AddWithValue("@SampleRequiredDate", model.SampleRequiredDate);
                    cmdUniversal.Parameters.AddWithValue("@SampleProductionDate", model.SampleProductionDate);
                    cmdUniversal.Parameters.AddWithValue("@SampleSubmissionQuantity", model.SampleSubmissionQuantity);
                    cmdUniversal.Parameters.AddWithValue("@SampeSubmissionDate", model.SampeSubmissionDate);
                    
                    
                    
                    cmdUniversal.ExecuteNonQuery();

                    cmdUniversal.CommandText = "Marketing_InsertEnquiryDetailMaster";
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmdUniversal);
                    foreach (var EnqDtlModel in model.AllData)
                    {
                        cmdUniversal.Parameters["@EnquiryId"].Value = model.EnquiryId;
                        cmdUniversal.Parameters["@ItemCode"].Value = EnqDtlModel.ItemCode; 
                        cmdUniversal.Parameters["@NewItemCode"].Value = EnqDtlModel.NewItemCode;
                        cmdUniversal.Parameters["@NewItemName"].Value = EnqDtlModel.NewItemName;
                        //cmdUniversal.Parameters["@Unit"].Value = EnqDtlModel.UnitId;
                        cmdUniversal.Parameters["@Quantity"].Value = EnqDtlModel.Quantity;
                        cmdUniversal.Parameters["@IsNewItem"].Value = EnqDtlModel.IsNewItem;
                        cmdUniversal.ExecuteNonQuery();
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            { 

            }
            return result; 
        }

        public DataTable FillEnquiryMaster(int EnquiryId)
        {
            this.Initialize();
            int nRecAffected = 0;
            DataTable dt = new DataTable();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "Marketing_FillEnquiryMaster";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.Add("@EnquiryId", SqlDbType.VarChar).Value = EnquiryId;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }
        
    }
}
