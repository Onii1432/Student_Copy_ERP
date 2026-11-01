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
    public class OrderAcceptanceDAL:ConncetionClass
    {

        OrderAcceptanceMODEL oam = new OrderAcceptanceMODEL();


        public DataTable BindCustomerName()
        {
            DataTable dt = new DataTable();
            this.Initialize();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetAllCustomerInfo";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;                           

            }


        }



        public DataTable BindOrderAcceptanceNumber()
        {
            DataTable dt = new DataTable();
            this.Initialize();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetOrderAcceptanceNo";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;

            }


        }



        public DataTable BindSalesExecutive()
        {
            DataTable dt = new DataTable();
            this.Initialize();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "GetSalesExecutive";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;

            }


        }



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




        public DataTable BindDatatoGrid()
        {
            DataTable dt = new DataTable();
            this.Initialize();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindGridData";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }

        }




        public DataTable BindCustName_CustPONO()
        {
            DataTable dt = new DataTable();
            this.Initialize();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindCustName_CustPONo";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                this.daUniversal.SelectCommand = cmdUniversal;
                this.cnUniversal.Open();
                this.daUniversal.Fill(dt);
                this.Close();
                return dt;
            }

        }



        public DataTable FillOrderAcceptanceData(string OrderAcceptanceNO)
        {
            DataTable dt = new DataTable();
            this.Initialize();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "FillOrderAcceptanceData";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.AddWithValue("@OrderAcceptanceNO", OrderAcceptanceNO);
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                cnUniversal.Close();
                return dt;

            }


        }



        



        public DataTable GetAllDataVsCustPONO(string CustomerPONo)
        {
            DataTable dt = new DataTable();
            this.Initialize();

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BindAllDataVsCustomerPONumber";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cmdUniversal.Parameters.AddWithValue("@CustomerPONo", CustomerPONo);
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                cnUniversal.Close();
                return dt;

            }


        }




        public int InsertCustomerPO(OrderAcceptanceMODEL oam)
        {
            this.Initialize();
            int Result = 0;
            //CustomerPONO = "";

            using (cnUniversal)
            {
                cmdUniversal.CommandText = "InsertCustomerPOMaster";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                cnUniversal.Open();

                cmdUniversal.Parameters.AddWithValue("@CustName", oam.CustName);
                cmdUniversal.Parameters.AddWithValue("@CustCode", oam.CustCode);
                cmdUniversal.Parameters.AddWithValue("@CustomerPONo", oam.CustomerPONo);
                cmdUniversal.Parameters.AddWithValue("@ThirdPartyPONo", oam.ThirdPartyPONo);
                cmdUniversal.Parameters.AddWithValue("@ThirdPartyPODate", Convert.ToDateTime(oam.ThirdPartyPODate));

                SqlParameter outpara = new SqlParameter();
                outpara.ParameterName = "@CustomerPOID";
                outpara.SqlDbType = System.Data.SqlDbType.Int;
                outpara.Direction = System.Data.ParameterDirection.Output;
                cmdUniversal.Parameters.Add(outpara);


                cmdUniversal.ExecuteNonQuery();



                SqlParameter outPutPoNo = new SqlParameter();
                outPutPoNo.ParameterName = "@CustomerPONo";
                outPutPoNo.SqlDbType = System.Data.SqlDbType.VarChar;
                outPutPoNo.Size = 100;
                outPutPoNo.Direction = System.Data.ParameterDirection.Output;
                cmdUniversal.Parameters.Add(outPutPoNo);



                int CustomerPOID = Convert.ToInt32(outpara.Value.ToString());
                
                
                //string CustomerPONo = outPutPoNo.Value.ToString();

                cmdUniversal.CommandText = "InsertOrderAcceptanceMaster";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cmdUniversal);


                    cmdUniversal.Parameters["@OrderAcceptanceID"].Value = oam.OrderAcceptanceID;                    
                    cmdUniversal.Parameters["@CustomerPOID"].Value = CustomerPOID;
                    

                    cmdUniversal.Parameters["@CustomerName"].Value = oam.CustName;
                    cmdUniversal.Parameters["@CustomerPONo"].Value = oam.CustomerPONo;
                    cmdUniversal.Parameters["@OARemark"].Value = oam.Remark;
                    cmdUniversal.Parameters["@OrderAcceptanceDate"].Value = Convert.ToDateTime(oam.OrderAcceptanceDate);

                    cmdUniversal.Parameters["@Destination"].Value = oam.Destination;
                    cmdUniversal.Parameters["@Documents"].Value = oam.Documents;
                    cmdUniversal.Parameters["@Payment"].Value = oam.PaymentTerms;
                    cmdUniversal.Parameters["@ECC"].Value = Convert.ToInt32(oam.ECC);

                    cmdUniversal.Parameters["@ExciseDuty"].Value = Convert.ToInt32(oam.ExciseDuty);
                    cmdUniversal.Parameters["@SalesTax"].Value = Convert.ToInt32(oam.Excise);
                    cmdUniversal.Parameters["@SalesExecutive"].Value = oam.SalesExecutive;
                    cmdUniversal.Parameters["@OrderAcceptanceNo"].Value = CustomerPOID;

                    Result = cmdUniversal.ExecuteNonQuery();


                
            }

                this.Close();
                return Result;           

        }



        public int UpdateOrderAcceptanceMaster(OrderAcceptanceMODEL oam)
        {
            int nRecAffected = 0;
            try
            {
                this.Initialize();

                using (cmdUniversal)
                {
                    cnUniversal.Open();
                    cmdUniversal.CommandText = "UpdateOrderAcceptanceMaster";
                    cmdUniversal.CommandType = CommandType.StoredProcedure;


                    cmdUniversal.Parameters.AddWithValue("@OrderAcceptanceNo", oam.OrderAcceptanceNO);
                    cmdUniversal.Parameters.AddWithValue("@CustomerName", oam.CustName);
                    cmdUniversal.Parameters.AddWithValue("@OARemark", oam.Remark);

                    cmdUniversal.Parameters.AddWithValue("@Destination", oam.Destination);
                    cmdUniversal.Parameters.AddWithValue("@Documents", oam.Documents);


                    cmdUniversal.Parameters.AddWithValue("@Payment", oam.PaymentTerms);
                    cmdUniversal.Parameters.AddWithValue("@ECC", oam.ECC);

                    cmdUniversal.Parameters.AddWithValue("@ExciseDuty", oam.Excise);
                    cmdUniversal.Parameters.AddWithValue("@SalesTax", oam.Stax);
                    cmdUniversal.Parameters.AddWithValue("@SalesExecutive", oam.SalesExecutive);


                    nRecAffected = cmdUniversal.ExecuteNonQuery();
                    
                }

                this.Close();

            }


            catch (Exception ex)
            {


            }
            
            
            return nRecAffected;

        }






    }
}
