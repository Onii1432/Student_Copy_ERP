using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace StandardMetals.MODEL
{
    public class CompanyMasterModel
    {
        public int Id { get; set; }
        public string CmpCode { get; set; }
        public string CmpName { get; set; }
        public string ContactPerson { get; set; }
        public string Branch { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string Country { get; set; }
        public string EmailID { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string GSTIN { get; set; }
        public string Remarks { get; set; }
        public string Action { get; set; }

        public DateTime SystemDate { get; set; }
    }
}
