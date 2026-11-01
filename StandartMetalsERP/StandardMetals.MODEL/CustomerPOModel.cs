using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StandardMetals.MODEL
{
    [Serializable]
    public class CustomerPOModel
    {
        
        public string CustCode { get; set; }
        public string CustName { get; set; }
        public int ShipmentId { get; set; }
        public int QuotationID { get; set; }        
        public string PONo { get; set; }
        public DateTime PODate { get; set; }
        public string isPOopen { get; set; }
        public string isPoClosed { get; set; }
        public string ThirdPartyLotNo { get; set; }
        public string CustomerLotNo { get; set; }
        public string ThirdPartyPoNo { get; set; }
        
        public int ConsigneedID { get; set; }
        public string ContactNo { get; set; }
        public string FaxNo { get; set; }
        public string DeliveryAddress { get; set; }
        public string Email { get; set; }
        public string DeliveryCSTNo { get; set; }
        public string DeliveryTINNo { get; set; }
        public string DeliveryECCNo { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonContactName { get; set; }
        public decimal Total { get; set; }
        public decimal GST { get; set; }
        public string Remark { get; set; }

        public int CustomerPODetailId { get; set; }
        public int CustomerPOID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int RequiredQuantity { get; set; }
        public int unitId { get; set; }
        public int transportId { get; set; }
        public decimal rate { get; set; }
        public decimal packingCost { get; set; }
        public decimal Excise { get; set; }
        public int SerialNo { get; set; }
        public decimal MoldAcc { get; set; }
        public decimal QtySchedule1 { get; set; }
        public DateTime DateSchedule1 { get; set; }

        public decimal QtySchedule2 { get; set; }
        public DateTime DateSchedule2 { get; set; }
        public decimal QtySchedule3 { get; set; }
        public DateTime DateSchedule3 { get; set; }
        public decimal QtySchedule4 { get; set; }
        public DateTime DateSchedule4 { get; set; }
        public decimal QtySchedule5 { get; set; }
        public DateTime DateSchedule5 { get; set; }
        public decimal QtySchedule6 { get; set; }
        public DateTime DateSchedule6 { get; set; }
        public decimal QtySchedule7 { get; set; }
        public DateTime DateSchedule7 { get; set; }
        public decimal QtySchedule8 { get; set; }
        public DateTime DateSchedule8 { get; set; }

        public List<CustomerPOModel> POCollection { get; set; }

    }
}
