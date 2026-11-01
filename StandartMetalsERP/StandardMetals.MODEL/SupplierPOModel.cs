using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StandardMetals.MODEL
{
    [Serializable]
    public class SupplierPOModel
    {
        public string POType { get; set; }
        public int ItemNo { get; set; }
        public string SuppName { get; set; }
        public int SupplierPoId { get; set; }
        public int IndentId { get; set; }
        public int BranchId { get; set; }
        public string SupplierPONo { get; set; }

        public string PaymentType { get; set; }
        public string SuppCode { get; set; }
        public string SupplierName {get; set; } 
        public string PoNo { get; set; }
        public string PODate {get; set; }
        public int QuotationNo {get; set; }
        public int SupplierId { get; set; }

        public int TransportTypeId { get; set; }
        public int TransporterTypeId { get; set; }
        public int ItemId { get; set; }
        public string QuotationDate { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }

        public int SupplierPoDtlId { get; set; }
        public string ApprovedIndent { get; set; }      
        public string TransporterType { get; set; }
        public string TransportType { get; set; }
        public string EmpCode { get; set; }
        public decimal PoQuantity { get; set; }
        public decimal PoRate { get; set; }
       
        
        public int VerifiedById { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public int Excise { get; set; }
        public string Name { get; set; }
       
        public int LoginUserId { get; set; }
        public double VAT { get; set; }
        public int Discount { get; set; }
        public DateTime PoScheduleDate { get; set; }
        public DateTime SupplierPoDate { get; set; }
        public string Payment { get; set; }
        public DateTime ScheduleDate1 { get; set; }
        public DateTime ScheduleDate2 { get; set; }
        public string Createdby { get; set; }

        public int PaymentTypeId { get; set; }
        public string PackingType { get; set; }
        public int Packing { get; set; }
        public int Height { get; set; }
        public string Transport { get; set; }
        public decimal TotalAmount { get; set; }
        public string Remark { get; set; }

        public string UserName { get; set; }
        public string BranchName { get; set; }
        //public int TransporterTypeId { get; set; }
       // public int TransportTypeId { get; set; }
        public string Transporter { get; set; }
        public int Pack { get; set;}


        public int Heights { get; set; }
        //public int TransportTypeId { get; set; }
        public int Warrenty { get; set; }
        public int ServiceTax { get; set; }
        public decimal OtherCharges { get; set; }
        public decimal NetTotal { get; set; }


        public List<SupplierPOModel> AllData { get; set; }
        


    }
}
