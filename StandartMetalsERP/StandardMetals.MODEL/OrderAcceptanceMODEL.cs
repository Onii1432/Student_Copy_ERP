using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StandardMetals.MODEL
{
    public class OrderAcceptanceMODEL
    {
        public string CustName { get; set; }
        public string CustCode { get; set; }
        public string CustomerPONo { get; set; }
        public string Remark { get; set; }
        
        
        public string ThirdPartyPONo { get; set; }
        public DateTime ThirdPartyPODate { get; set; }
        public DateTime OrderAcceptanceDate { get; set; }
        public string Destination { get; set; }


        public string Documents { get; set; }
        public string PaymentTerms { get; set; }
        public int ECC { get; set; }
        public int ExciseDuty { get; set; }


        public string OrderAcceptanceNO { get; set; }
        public int CustomerPOID { get; set; }
        public int SalesTax { get; set; }
        public string SalesExecutive { get; set; }


        public int SalesExecutiveId { get; set; }
        public string CustomerName { get; set; }
        public int OrderAcceptanceID { get; set; }
        public decimal Excise { get; set; }
        public decimal Stax { get; set; }


        public List<OrderAcceptanceMODEL> AllData { get; set; }

    }
}
