using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Modal;
using System.Data;

namespace StandardMetals.BAL
{
    public class IndentMasterBAL
    {
        IndentMasterData IndentData = new IndentMasterData();
        

        public DataTable BindIndentNumber(IndentMasterModel IndentModal)
        {
            return IndentData.BindIndentNumber(IndentModal);
        }

        public DataTable BindSupplierPO(IndentMasterModel IndentModel)
        {
            return IndentData.AllIndentDtl(IndentModel);
        }

        public DataTable GetMaxIndentNumber(IndentMasterModel IndentModel)
        {
            return IndentData.GetMaxIndentNumber(IndentModel);
        }

        public DataTable BindItemMaster(IndentMasterModel IndentModel)
        {
            return IndentData.BindItemMaster(IndentModel);
        }
        //BindDepartment
        public DataTable BindDepartment(IndentMasterModel IndentModel)
        {
            return IndentData.BindDepartment(IndentModel);
        }

        //BindUnit
        public DataTable BindUnit(IndentMasterModel IndentModel)
        {
            return IndentData.BindUnit(IndentModel);
        }
        //BindEmployee
        public DataTable BindEmployee(IndentMasterModel IndentModel)
        {
            return IndentData.BindEmployee(IndentModel);
        }
        //FindCurrentStock
        public DataTable FindCurrentStock(IndentMasterModel IndentModel)
        {
            return IndentData.FindCurrentStock(IndentModel);
        }
        //drpIndetType
        public DataTable BindIndentType(IndentMasterModel IndentModel)
        {
            return IndentData.BindIndentType(IndentModel);
        }

        public int InsertIndentMaster(IndentMasterModel IndentModel)
        {
            return IndentData.InsertIndentMaster(IndentModel);
        }
        
        //InsertIndentDetailMaster
        //public int InsertIndentDetailMaster(IndentMasterModel IndentModel)
        //{
        //    return IndentData.InsertIndentDetailMaster(IndentModel);
        //}

    

        //FindDeparmentId
        public DataTable FindDeparmentId(string DeparmentName)
        {
            return IndentData.FindDeparmentId(DeparmentName);
        }

        public int UpdateIndentMaster(IndentMasterModel IndentModel)
        {
            return IndentData.UpdateIndentMaster(IndentModel);
        }
        //public int UpdateIndentDetailMaster(IndentMasterModel IndentModel)
        //{
        //    return IndentData.UpdateIndentDetailMaster(IndentModel);
        //}

        public DataTable FillIndentMaster(int IndentId)
        {
            return IndentData.FillIndentMaster(IndentId);
        }


        public DataTable BindGridIndentDetails(string ItemCode)
        {
            return IndentData.BindGridIndentDetails(ItemCode);
        }
 
    }
}
