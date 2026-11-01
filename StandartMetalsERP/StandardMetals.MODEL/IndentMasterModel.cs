using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StandardMetals.MODEL
{
    public class IndentMasterModel
    {
        public int IndentId { get; set; }
        public string IndentNoAutoGen { get; set; }
        public int IndentTypeId { get; set; }
        public DateTime IndentDate { get; set; }
        public string IndentTime { get; set; }
        public string IndentType { get; set; }


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
        public int CurrentStock { get; set; }
        public DateTime RequiredDate { get; set; }
        public int ToOrderQuantity { get; set; }
        public string ToOrderUnit { get; set; }
    }
}
