using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StandardMetals.MODEL
{
    [Serializable]
    public class EnquiryMasterModel
    {
        public int EnquiryId { get; set; }
        public string EnquiryNumber { get; set; }
        public int CategoryId { get; set; }
        public int SuppTypeId { get; set; }
        public int CustomerId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public DateTime EnquiryDate { get; set; }
        public string EnqRefNumber { get; set; }
        public string NewCustName { get; set; }
        public string NewCustCode { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public DateTime SystemEntryDate { get; set; }
        public int BranchId { get; set; }
        public string ContactPerson { get; set; }
        public int LoginUserId { get; set; }
        public int MedOfEnqId { get; set; }
        public int EnqDetailId { get; set; }
        public decimal Quantity { get; set; }
        public string NewItemCode { get; set; }
        public string NewItemName { get; set; }
        public int UnitId { get; set; }
        public string Remark { get; set; }
        public string QuotationNumber { get; set; }
        public DateTime QuotationDate { get; set; }
        public string SampleStatus { get; set; }
        public DateTime SampleRequiredDate { get; set; }
        public DateTime SampleProductionDate { get; set; }
        public string SampleSubmissionQuantity { get; set; }
        public DateTime SampeSubmissionDate { get; set; }
        public bool IsNewItem { get; set; }
        public bool IsNewCustomer { get; set; }
        public bool IsActive { get; set; }
        public List<EnquiryMasterModel> AllData { get; set; }
    }
}
