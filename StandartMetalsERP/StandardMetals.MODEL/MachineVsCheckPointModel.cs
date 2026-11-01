using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StandardMetals.MODEL
{
    public class MachineVsCheckPointModel
    {
        public int SrNo { get; set; }
        public int cid { get; set; }
        public string MachineCode { get; set; }
        public string Location { get; set; }
        public string Parameter { get; set; }
        public string Check_Point { get; set; }
        public string PlanType { get; set; }
        public string Scheduler { get; set; }
        public DateTime EnteryDate { get; set; }
        public string CmpName { get; set; }
        public string IPAddress { get; set; }
        public int FinancialYear { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public List<MachineVsCheckPointModel> AllData = new List<MachineVsCheckPointModel>();


    }
}
