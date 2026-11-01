using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Modal;
using System.Data;


namespace StandardMetals.BAL
{
    public class SupplierPOBussiness
    {
        SupplierPOData SPD = new SupplierPOData();

        
        
        public DataTable BindSupplierPO(SupplierPOModel SPM)
        {
          
            return SPD.BindSupplierPO(SPM);
       
        }




        public DataTable BindItemMasterData( int IndentId )
        {

            return SPD.BindItemMasterData(IndentId);

        }




        public DataTable Purchase_BindSupplierPO_Rate(SupplierPOModel SPM)
        {

            return SPD.Purchase_BindSupplierPO_Rate(SPM);

        }



         


        public DataTable BindItemName_SupplierName(SupplierPOModel SPM)
        {

            return SPD.BindItemName_SupplierName(SPM);

        }



        public DataTable GetSupplierItemWise(string ItemCode)
        {

            return SPD.GetSupplierItemWise(ItemCode);

        }

        //GetUnitByItem
        public DataTable GetUnitRateByItem(string ItemCode)
        {

            return SPD.GetUnitRateByItem(ItemCode);

        }

        //GetQuantityByIndentItem
        public DataTable GetQuantityByIndentItem(string ItemCode,int IndentId)
        {

            return SPD.GetQuantityByIndentItem(ItemCode, IndentId);

        }





        public DataTable BindPurchase_ApprovedIndent(SupplierPOModel SPM)
        {

            return SPD.BindPurchase_ApprovedIndent(SPM);

        }



        

        public DataTable BindEmployeeCode_Name(SupplierPOModel SPM)
        {

            return SPD.BindEmployeeCode_Name(SPM);

        }




        public DataTable BindApprovedIndent_ItemDetails()
        {
            return SPD.BindApprovedIndent_ItemDetails();

        }



        public DataTable BindPaymentTpye()
        {
            return SPD.BindPaymentTpye();

        }




        public DataTable BindTransportType()
        {
            return SPD.BindTransportType();

        }



        public DataTable BindTransporterType()
        {
            return SPD.BindTransporterType();

        }




        public List<SupplierPOModel> GetSuppPOMasternMDetails()
        {
            return SPD.GetSuppPOMasternMDetails();
        }








        public int Purchase_InsertSupplierPODtl_ItemDetails(SupplierPOModel SPM, out string SupplierPONo)
        {

            return SPD.Purchase_InsertSupplierPODtl_ItemDetails(SPM, out SupplierPONo);

        }



        public int UpdateSupplierPOMaster(SupplierPOModel SPM)
        {
            return SPD.UpdateSupplierPOMaster(SPM);

        }












    }
}
