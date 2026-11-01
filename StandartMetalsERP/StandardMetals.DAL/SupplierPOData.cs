using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modal;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace StandardMetals.DAL
{
    public class SupplierPOData : ConncetionClass
    {

        SupplierPOModel SPM = new SupplierPOModel();


        // St.Proc to get Supplier PO Number

        public DataTable BindSupplierPO(SupplierPOModel SPM)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "Purchase_BindSupplierPO";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        //St.Proc to get Item name and Item code

        public DataTable BindItemMasterData(int IndentId)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "Purchase_BindItemName_ItemCode";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.AddWithValue("@IndentId", IndentId);
            
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;

            }


        }


        //St.Proc to get PO Rate

        public DataTable Purchase_BindSupplierPO_Rate(SupplierPOModel SPM)
        {

            DataTable dt = new DataTable();
            this.Initialize();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "Purchase_BindSupplierPO_Rate";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                this.daUniversal.Fill(dt);
                this.Close();
                return dt;

            }



        }

      
        //St.Proc to get ItemName and supplierName on radio button

        public DataTable BindItemName_SupplierName(SupplierPOModel SPM)
        {
            DataTable dt = new DataTable();
            this.Initialize();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "Purchase_ItemNameVsSupplierName";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;

            }


        }


        public DataTable GetSupplierItemWise(string ItemCode)
        {

            DataTable dt = new DataTable();
            this.Initialize();

            using (cnUniversal)
            {

                cmdUniversal.CommandText = "Purchase_ItemNameVsSupplierName";

                cmdUniversal.Parameters.AddWithValue("@ItemCode", ItemCode);
                
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;

            }


        }

        //GetUnitRateByItem
        public DataTable GetUnitRateByItem(string ItemCode)
        {

            DataTable dt = new DataTable();
            this.Initialize();

            using (cnUniversal)
            {

                cmdUniversal.CommandText = "Purchase_GetUnitRateByItem";

                cmdUniversal.Parameters.AddWithValue("@ItemCode", ItemCode);

                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;

            }


        }




        public DataTable GetQuantityByIndentItem(string ItemCode, int IndentId)
        {

            DataTable dt = new DataTable();
            this.Initialize();

            using (cnUniversal)
            {

                cmdUniversal.CommandText = "Purchase_GetQuantityByIndentItem";

                cmdUniversal.Parameters.AddWithValue("@ItemCode", ItemCode);
                cmdUniversal.Parameters.AddWithValue("IndentId", IndentId);

                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;

            }


        }


        public DataTable BindPurchase_ApprovedIndent(SupplierPOModel SPM)
        {
            DataTable dt = new DataTable();
            this.Initialize();

            using (cnUniversal)
            {

                cmdUniversal.CommandText = "Purchase_ApprovedIndentSPO";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                this.daUniversal.Fill(dt);
                this.Close();
                return dt;

            }


        }

         
        public DataTable BindEmployeeCode_Name(SupplierPOModel SPM)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindEmployee";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;

            }
        }


        public DataTable BindApprovedIndent_ItemDetails()
        {

            DataTable dt = new DataTable();
            this.Initialize();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "Purchase_ApprovedIndentSPO";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }


        }


        // code to get PaymentType

        public DataTable BindPaymentTpye()
        {
            DataTable dt = new DataTable();
            this.Initialize();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "Purchase_BindPayment";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }

        }



        public DataTable BindTransportType()
        {
            DataTable dt = new DataTable();
            this.Initialize();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "Purchase_BindTransport";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                this.daUniversal.Fill(dt);
                this.Close();
                return dt;

            }
        }



        public DataTable BindTransporterType()
        {
            DataTable dt = new DataTable();
            this.Initialize();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "Purchase_BindTransporterType";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                this.daUniversal.Fill(dt);
                this.Close();
                return dt;

            }
        }



       

        public List<SupplierPOModel> GetSuppPOMasternMDetails()
        {
            this.Initialize();
            int nRecAffected = 0;
            
           DataTable dtm = new DataTable();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetSupplierMasternMDetails";
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                nRecAffected = this.daUniversal.Fill(dtm);
                this.Close();

                List<SupplierPOModel> lstdtl = new List<SupplierPOModel>();
                if (dtm.Rows.Count > 0)
                {
                    for (int i = 0; i < dtm.Rows.Count; i++)
                    {
                        lstdtl.Add(new SupplierPOModel()
                        {
                            SupplierPoId = Convert.ToInt32(dtm.Rows[i]["SupplierPoId"]),
                            SupplierPONo = (dtm.Rows[i]["SupplierPONo"].ToString()),
                            SuppName = (dtm.Rows[i]["SuppName"].ToString()),
                            PaymentType = (dtm.Rows[i]["PaymentType"].ToString()),
                            Packing = Convert.ToInt32(dtm.Rows[i]["Packing"]),
                            Height = Convert.ToInt32(dtm.Rows[i]["Height"]),
                            TransportType = (dtm.Rows[i]["TransportType"].ToString()),
                            TotalAmount = Convert.ToInt32(dtm.Rows[i]["TotalAmount"]),
                            Name = (dtm.Rows[i]["Name"].ToString()),
                            Warrenty = Convert.ToInt32(dtm.Rows[i]["Warrenty"]),
                            ServiceTax = Convert.ToInt32(dtm.Rows[i]["ServiceTax"]),
                            OtherCharges = Convert.ToInt32(dtm.Rows[i]["OtherCharges"]),
                            NetTotal = Convert.ToInt32(dtm.Rows[i]["NetTotal"]),
                            Remark = (dtm.Rows[i]["Remark"].ToString()),
                            TransporterType = (dtm.Rows[i]["TransporterType"].ToString()),
                            UserName = (dtm.Rows[i]["UserName"].ToString()),
                            BranchName = (dtm.Rows[i]["BranchName"].ToString()),
                            SupplierPoDate = Convert.ToDateTime(dtm.Rows[i]["SupplierPoDate"].ToString()),

                            SupplierPoDtlId = Convert.ToInt32(dtm.Rows[i]["SupplierPoDtlId"]),
                            ItemId = Convert.ToInt32(dtm.Rows[i]["ItemId"]),
                            ItemName = (dtm.Rows[i]["ItemName"].ToString()),
                            ItemCode = (dtm.Rows[i]["ItemCode"].ToString()),
                            PoRate = Convert.ToDecimal(dtm.Rows[i]["PoRate"]),
                            PoQuantity = Convert.ToDecimal(dtm.Rows[i]["PoQuantity"]),
                            Excise = Convert.ToInt32(dtm.Rows[i]["Excise"]),
                            Discount = Convert.ToInt32(dtm.Rows[i]["Discount"]),
                            PoScheduleDate = Convert.ToDateTime(dtm.Rows[i]["PoScheduleDate"].ToString())

                            //SupplierPONo = (dtm.Rows[i]["ID21"].ToString()),
                            //SuppName = (dtm.Rows[i]["ID22"].ToString()),
                            //PaymentType = (dtm.Rows[i]["ID23"].ToString()),
                            //Packing = Convert.ToInt32(dtm.Rows[i]["ID24"]),
                            //Height = Convert.ToInt32(dtm.Rows[i]["ID25"]),
                            //TransportType = (dtm.Rows[i]["ID26"].ToString()),
                            //TotalAmount = Convert.ToInt32(dtm.Rows[i]["ID27"]),
                            //Name = (dtm.Rows[i]["ID28"].ToString()),
                            //Warrenty = Convert.ToInt32(dtm.Rows[i]["ID29"]),
                            //ServiceTax = Convert.ToInt32(dtm.Rows[i]["ID30"]),
                            //OtherCharges = Convert.ToInt32(dtm.Rows[i]["ID31"]),
                            //NetTotal = Convert.ToInt32(dtm.Rows[i]["ID32"]),
                            //Remark = (dtm.Rows[i]["ID33"].ToString()),
                            //TransporterType = (dtm.Rows[i]["ID34"].ToString()),
                            //UserName = (dtm.Rows[i]["ID35"].ToString()),
                            //BranchName = (dtm.Rows[i]["ID36"].ToString()),
                            //SupplierPoDate = Convert.ToDateTime(dtm.Rows[i]["ID37"].ToString()),

                            //ItemId = Convert.ToInt32(dtm.Rows[i]["ID38"]),
                            //ItemName = (dtm.Rows[i]["ID39"].ToString()),
                            //ItemCode = (dtm.Rows[i]["ID40"].ToString()),
                            //PoRate = Convert.ToDecimal(dtm.Rows[i]["ID41"]),
                            //PoQuantity = Convert.ToDecimal(dtm.Rows[i]["ID42"]),
                            //Excise = Convert.ToInt32(dtm.Rows[i]["ID43"]),
                            //Discount = Convert.ToInt32(dtm.Rows[i]["ID44"])




                        });


                    }

                }

                return lstdtl;

            }
        }




     


        // Code to Insert SupplierPO ItemDetails in SupplierPODetailMaster
                
        public int Purchase_InsertSupplierPODtl_ItemDetails(SupplierPOModel SPM, out string SupplierPONo)
        {

            this.Initialize();
            int Result = 0;
            SupplierPONo = "";

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "Purchase_InsertSupplierPOMaster";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cnUniversal.Open();

                cmdUniversal.Parameters.AddWithValue("@IndentId", SPM.IndentId);
                cmdUniversal.Parameters.AddWithValue("@SupplierPoDate", DateTime.Now) ;
                cmdUniversal.Parameters.AddWithValue("@TotalAmount", SPM.TotalAmount);
                 
                cmdUniversal.Parameters.AddWithValue("@Remark", SPM.Remark);
                cmdUniversal.Parameters.AddWithValue("@BranchId", SPM.BranchId);
                cmdUniversal.Parameters.AddWithValue("@EmployeeCode", SPM.EmpCode);
                
                cmdUniversal.Parameters.AddWithValue("@LoginUserId", SPM.LoginUserId);
                cmdUniversal.Parameters.AddWithValue("@SupplierCode", SPM.SuppCode);
                cmdUniversal.Parameters.AddWithValue("@PaymentType", SPM.PaymentType);

                cmdUniversal.Parameters.AddWithValue("@TransportType", SPM.TransportType);
                cmdUniversal.Parameters.AddWithValue("@TransporterType", SPM.TransporterType);
                
                cmdUniversal.Parameters.AddWithValue("@Packing", SPM.Pack);
                cmdUniversal.Parameters.AddWithValue("@Height", SPM.Heights);
                cmdUniversal.Parameters.AddWithValue("@Warrenty", SPM.Warrenty);

                cmdUniversal.Parameters.AddWithValue("@ServiceTax", SPM.ServiceTax);
                cmdUniversal.Parameters.AddWithValue("@OtherCharges", SPM.OtherCharges);
                cmdUniversal.Parameters.AddWithValue("@NetTotal", SPM.NetTotal);
                
                                
                
                //Add the output parameter to the command object
                 
                SqlParameter outPutParameter = new SqlParameter();
                outPutParameter.ParameterName = "@SupplierPoId";
                outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter.Direction = System.Data.ParameterDirection.Output;
                cmdUniversal.Parameters.Add(outPutParameter);

                 SqlParameter outPutPoNo = new SqlParameter();
                outPutPoNo.ParameterName = "@SupplierPONo";
                outPutPoNo.SqlDbType = System.Data.SqlDbType.VarChar;
                outPutPoNo.Size = 100;
                outPutPoNo.Direction = System.Data.ParameterDirection.Output;
                cmdUniversal.Parameters.Add(outPutPoNo);

                cmdUniversal.ExecuteNonQuery();
                int SupplierPoId = Convert.ToInt32(outPutParameter.Value.ToString());
                string SupplierPoNo = outPutParameter.Value.ToString();

                cmdUniversal.CommandText = "Purchase_InsertSupplierPODtl_ItemDetails";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cmdUniversal);
               
                foreach (var SPODtlModel in SPM.AllData)
                {
                    cmdUniversal.Parameters["@SupplierPoId"].Value = SupplierPoId;
                    cmdUniversal.Parameters["@ItemCode"].Value = SPODtlModel.ItemCode;
                    cmdUniversal.Parameters["@ItemName"].Value = SPODtlModel.ItemName;
                    cmdUniversal.Parameters["@Rate"].Value = Convert.ToDecimal(SPODtlModel.Rate);
                    cmdUniversal.Parameters["@Quantity"].Value = SPODtlModel.Quantity;
                    cmdUniversal.Parameters["@POScheduleDate"].Value = Convert.ToDateTime(SPODtlModel.ScheduleDate1);

                    cmdUniversal.Parameters["@Excise"].Value = SPODtlModel.Excise;
                    cmdUniversal.Parameters["@Discount"].Value = SPODtlModel.Discount;

                    cmdUniversal.ExecuteNonQuery();

                }


                this.Close();
                return Result;

            }
        }


        // Update code

        public int UpdateSupplierPOMaster(SupplierPOModel SPM)
        {
            int nRecAffected = 0;
            try
            {
                this.Initialize();

                using (cmdUniversal)
                {
                    cnUniversal.Open();
                    cmdUniversal.CommandText = "Update_SupplierPOMaster";
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                                      
                    
                    cmdUniversal.Parameters.AddWithValue("@SupplierPONo", SPM.SupplierPONo);
                    cmdUniversal.Parameters.AddWithValue("@IndentId", SPM.IndentId);

                    cmdUniversal.Parameters.AddWithValue("@TotalAmount", SPM.TotalAmount);
                    cmdUniversal.Parameters.AddWithValue("@Remark", SPM.Remark);

                    // cmdUniversal.Parameters.AddWithValue("@LoginUserId", SPM.SupplierPONo);
                    //cmdUniversal.Parameters.AddWithValue("@BranchId", SPM.IndentId);

                    //cmdUniversal.Parameters.AddWithValue("@VerifiedById", SPM.SupplierPONo);
                    //cmdUniversal.Parameters.AddWithValue("@SupplierId", SPM.IndentId);

                    cmdUniversal.Parameters.AddWithValue("@PaymentTypeId", SPM.PaymentTypeId);
                    cmdUniversal.Parameters.AddWithValue("@TransportTypeId", SPM.TransportTypeId);

                    cmdUniversal.Parameters.AddWithValue("@TransporterTypeId", SPM.TransporterTypeId);
                    cmdUniversal.Parameters.AddWithValue("@Packing", SPM.Packing);

                    cmdUniversal.Parameters.AddWithValue("@Height", SPM.Height);
                    cmdUniversal.Parameters.AddWithValue("@Warrenty", SPM.Warrenty);

                    cmdUniversal.Parameters.AddWithValue("@ServiceTax", SPM.ServiceTax);
                    cmdUniversal.Parameters.AddWithValue("@OtherCharges", SPM.OtherCharges);
                    cmdUniversal.Parameters.AddWithValue("@NetTotal", SPM.NetTotal);

                    nRecAffected = cmdUniversal.ExecuteNonQuery();
                    this.Close();

                }
            }


            catch (Exception ex)
            {

            }

            return nRecAffected;

        }






        //@SupplierPONo varchar(100),
        //@IndentId int,
        //@TotalAmount Decimal(18, 0),
        //@Remark varchar(100),
        //@LoginUserId int,
        //@BranchId int,
        //@VerifiedById int,
        //@SupplierId int,
        //@PaymentTypeId int,
        //@TransportTypeId int,
        //@TransporterTypeId int,
        //@Packing int,
        //@Height int,
        //@Warrenty int,
        //@ServiceTax int,
        //@OtherCharges decimal(10,2),
        //@NetTotal decimal(10,2),
















    }
}

