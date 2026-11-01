using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StandardMetals.MODEL
{
  public  class IndentApprovalModal
    {
        public bool IsApproved { get; set; }
        public string IndentNoAutoGen { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Purpose { get; set; }
        public string CurrentStock { get; set; }
        public string RequiredDate { get; set; }
        public string ToOrderQuantity { get; set; }
        public string ApprovedQuantity { get; set; }
        public string RejectedQuantity { get; set; }
        public string Remark { get; set; }
        public string IndentCreateBy { get; set; }
        public int IndentApprovedByCode { get; set; }
        public string IndentApprovedByName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime CurrentDate { get; set; }
        public DateTime CurrentTime { get; set; }
        public List<IndentApprovalModal> lst1 { get; set; }
        public List<IndentApprovalModal> AllData { get; set; }
    }
}
