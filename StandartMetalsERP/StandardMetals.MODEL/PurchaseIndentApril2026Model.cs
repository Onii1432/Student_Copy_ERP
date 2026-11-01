
using System;
using System.Collections.Generic;

namespace StandardMetals.MODEL
{
    public class PurchaseIndentApril2026Model
    {
        // Indent Master fields
        public int IndentId { get; set; }
        public string IndentNoAutoGen { get; set; }
        public int IndentTypeId { get; set; }
        public DateTime IndentDate { get; set; }
        public string IndentTime { get; set; }
        public string IndentType { get; set; }

        // Indent Detail fields
        public int IndentDetailId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Specification { get; set; }
        public string DrawingNo { get; set; }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public int UnitId { get; set; }
        public string UnitName { get; set; }

        public string Purpose { get; set; }
        public decimal CurrentStock { get; set; }
        public DateTime RequiredDate { get; set; }
        public decimal ToOrderQuantity { get; set; }
        public string ToOrderUnit { get; set; }

        // Indent additional fields
        public string Remark { get; set; }
        public string PreparedByCode { get; set; }
        public string PreparedByName { get; set; }

        // Holds multiple item rows for one indent
        public List<PurchaseIndentApril2026Model> ItemDetails { get; set; }
    }
}
