using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StandardMetals.MODEL;
using System.Data.SqlClient;
using System.Data;

namespace StandardMetals.DAL
{
    public class CustomerPODal : ConncetionClass
    {
        public int InsertCustomerPO(CustomerPOModel custPoModel)
        {
            
            int res=0;
            this.Initialize();
            using (cnUniversal)
            {

                cmdUniversal.CommandText = "Marketing_InsertCustomerPO";
                cmdUniversal.CommandType = System.Data.CommandType.StoredProcedure;
                cnUniversal.Open();
                

                cmdUniversal.Parameters.AddWithValue("@CustomerCode", custPoModel.CustCode);
                cmdUniversal.Parameters.AddWithValue("@CustomerName", custPoModel.CustName);
                cmdUniversal.Parameters.AddWithValue("@ShipmentID", custPoModel.ShipmentId);
                cmdUniversal.Parameters.AddWithValue("@QuotationId", custPoModel.QuotationID);
                cmdUniversal.Parameters.AddWithValue("@PONo", custPoModel.PONo);
                cmdUniversal.Parameters.AddWithValue("@PoDate", custPoModel.PODate);
                cmdUniversal.Parameters.AddWithValue("@IsPoOpen", custPoModel.isPOopen);
                cmdUniversal.Parameters.AddWithValue("@IsPoClosed", custPoModel.isPoClosed);
                cmdUniversal.Parameters.AddWithValue("@ThirdPartyPoNo", custPoModel.ThirdPartyPoNo);
                cmdUniversal.Parameters.AddWithValue("@CustomerLotNo", custPoModel.CustomerLotNo);
                cmdUniversal.Parameters.AddWithValue("@ThirdPartyLotNo", custPoModel.ThirdPartyLotNo);
                
                cmdUniversal.Parameters.AddWithValue("@ConsigneeId", custPoModel.ConsigneedID);
                cmdUniversal.Parameters.AddWithValue("@ContactNo", custPoModel.ContactNo);
                cmdUniversal.Parameters.AddWithValue("@FaxNo", custPoModel.FaxNo);
                cmdUniversal.Parameters.AddWithValue("@EmailId", custPoModel.Email);
                cmdUniversal.Parameters.AddWithValue("@Address", custPoModel.DeliveryAddress);
                cmdUniversal.Parameters.AddWithValue("@ECCNo", custPoModel.DeliveryECCNo);
                cmdUniversal.Parameters.AddWithValue("@CSTNo", custPoModel.DeliveryCSTNo);
                cmdUniversal.Parameters.AddWithValue("@TINNo", custPoModel.DeliveryTINNo);
                cmdUniversal.Parameters.AddWithValue("@ContactPersonName", custPoModel.ContactPersonName);
                cmdUniversal.Parameters.AddWithValue("@ContactPersonContactName", custPoModel.ContactPersonContactName);
                
                cmdUniversal.Parameters.AddWithValue("@Total", custPoModel.Total);
                cmdUniversal.Parameters.AddWithValue("@GST", custPoModel.GST);
                cmdUniversal.Parameters.AddWithValue("@Remark", custPoModel.Remark);

                SqlParameter outPara = new SqlParameter();
                outPara.ParameterName = "@CustomerPOId";
                outPara.DbType = DbType.Int32;
                outPara.Direction = ParameterDirection.Output;
                cmdUniversal.Parameters.Add(outPara);
                cmdUniversal.ExecuteNonQuery();

                res = Convert.ToInt32(outPara.Value.ToString());


                //Insert CustomerPODetailMaster with CustomerPOMaster 
                cmdUniversal.CommandText="Marketing_InsertCustomerPODetailM";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cmdUniversal);
                foreach (var PoModel in custPoModel.POCollection)
                {
                    cmdUniversal.Parameters["@CustomerPOId"].Value = res;
                    cmdUniversal.Parameters["@ItemName"].Value = PoModel.ItemName;
                    cmdUniversal.Parameters["@ItemCode"].Value = PoModel.ItemCode;
                    cmdUniversal.Parameters["@RequiredQuantity"].Value = PoModel.RequiredQuantity;
                    cmdUniversal.Parameters["@UnitId"].Value = PoModel.unitId;
                    cmdUniversal.Parameters["@TransportId"].Value = PoModel.transportId;
                    cmdUniversal.Parameters["@Rate"].Value = PoModel.rate;
                    cmdUniversal.Parameters["@PackingCost"].Value = PoModel.packingCost;
                    cmdUniversal.Parameters["@Excise"].Value = PoModel.Excise;
                    cmdUniversal.Parameters["@SerialNo"].Value = PoModel.SerialNo;
                    cmdUniversal.Parameters["@MoldAcco"].Value = PoModel.MoldAcc;
                    cmdUniversal.Parameters["@DateSchedule1"].Value = PoModel.DateSchedule1;
                    cmdUniversal.Parameters["@QtySchedule1"].Value = PoModel.QtySchedule1;
                    cmdUniversal.Parameters["@DateSchedule2"].Value = PoModel.DateSchedule2;
                    cmdUniversal.Parameters["@QtySchedule2"].Value = PoModel.QtySchedule2;
                    cmdUniversal.Parameters["@DateSchedule3"].Value = PoModel.DateSchedule3;
                    cmdUniversal.Parameters["@QtySchedule3"].Value = PoModel.QtySchedule3;
                    cmdUniversal.Parameters["@DateSchedule4"].Value = PoModel.DateSchedule4;
                    cmdUniversal.Parameters["@QtySchedule4"].Value = PoModel.QtySchedule4;
                    cmdUniversal.Parameters["@DateSchedule5"].Value = PoModel.DateSchedule5;
                    cmdUniversal.Parameters["@QtySchedule5"].Value = PoModel.QtySchedule5;
                    cmdUniversal.Parameters["@DateSchedule6"].Value = PoModel.DateSchedule6;
                    cmdUniversal.Parameters["@QtySchedule6"].Value = PoModel.QtySchedule6;
                    cmdUniversal.Parameters["@DateSchedule7"].Value = PoModel.DateSchedule7;
                    cmdUniversal.Parameters["@QtySchedule7"].Value = PoModel.QtySchedule7;
                    cmdUniversal.Parameters["@DateSchedule8"].Value = PoModel.DateSchedule8;
                    cmdUniversal.Parameters["@QtySchedule8"].Value = PoModel.QtySchedule8;

                    cmdUniversal.ExecuteNonQuery();
                }



            }
            this.Close();
            return res;
        }

        public int UpdateCustomerPO(CustomerPOModel custPoModel)
        {

            int res = 0;
            this.Initialize();
            using (cnUniversal)
            {

                cmdUniversal.CommandText = "Marketing_UpdateCustomerPOMaster";
                cmdUniversal.CommandType = System.Data.CommandType.StoredProcedure;
                cnUniversal.Open();

                cmdUniversal.Parameters.AddWithValue("@CustomerPOID", custPoModel.CustomerPOID);
                cmdUniversal.Parameters.AddWithValue("@CustomerCode", custPoModel.CustCode);
                cmdUniversal.Parameters.AddWithValue("@CustomerName", custPoModel.CustName);
                cmdUniversal.Parameters.AddWithValue("@ShipmentID", custPoModel.ShipmentId);
                cmdUniversal.Parameters.AddWithValue("@QuotationId", custPoModel.QuotationID);
                cmdUniversal.Parameters.AddWithValue("@PONo", custPoModel.PONo);
                cmdUniversal.Parameters.AddWithValue("@PoDate", custPoModel.PODate);
                cmdUniversal.Parameters.AddWithValue("@IsPoOpen", custPoModel.isPOopen);
                cmdUniversal.Parameters.AddWithValue("@IsPoClosed", custPoModel.isPoClosed);
                cmdUniversal.Parameters.AddWithValue("@ThirdPartyPoNo", custPoModel.ThirdPartyPoNo);
                cmdUniversal.Parameters.AddWithValue("@CustomerLotNo", custPoModel.CustomerLotNo);
                cmdUniversal.Parameters.AddWithValue("@ThirdPartyLotNo", custPoModel.ThirdPartyLotNo);

                cmdUniversal.Parameters.AddWithValue("@ConsigneeId", custPoModel.ConsigneedID);
                cmdUniversal.Parameters.AddWithValue("@ContactNo", custPoModel.ContactNo);
                cmdUniversal.Parameters.AddWithValue("@FaxNo", custPoModel.FaxNo);
                cmdUniversal.Parameters.AddWithValue("@EmailId", custPoModel.Email);
                cmdUniversal.Parameters.AddWithValue("@Address", custPoModel.DeliveryAddress);
                cmdUniversal.Parameters.AddWithValue("@ECCNo", custPoModel.DeliveryECCNo);
                cmdUniversal.Parameters.AddWithValue("@CSTNo", custPoModel.DeliveryCSTNo);
                cmdUniversal.Parameters.AddWithValue("@TINNo", custPoModel.DeliveryTINNo);
                cmdUniversal.Parameters.AddWithValue("@ContactPersonName", custPoModel.ContactPersonName);
                cmdUniversal.Parameters.AddWithValue("@ContactPersonContactName", custPoModel.ContactPersonContactName);

                cmdUniversal.Parameters.AddWithValue("@Total", custPoModel.Total);
                cmdUniversal.Parameters.AddWithValue("@GST", custPoModel.GST);
                cmdUniversal.Parameters.AddWithValue("@Remark", custPoModel.Remark);

                res = cmdUniversal.ExecuteNonQuery();

                //Insert CustomerPODetailMaster with CustomerPOMaster 
                cmdUniversal.CommandText = "Marketing_InsertCustomerPODetailM";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cmdUniversal);
                foreach (var PoModel in custPoModel.POCollection)
                {
                    cmdUniversal.Parameters["@CustomerPOId"].Value = custPoModel.CustomerPOID;
                    cmdUniversal.Parameters["@ItemName"].Value = PoModel.ItemName;
                    cmdUniversal.Parameters["@ItemCode"].Value = PoModel.ItemCode;
                    cmdUniversal.Parameters["@RequiredQuantity"].Value = PoModel.RequiredQuantity;
                    cmdUniversal.Parameters["@UnitId"].Value = PoModel.unitId;
                    cmdUniversal.Parameters["@TransportId"].Value = PoModel.transportId;
                    cmdUniversal.Parameters["@Rate"].Value = PoModel.rate;
                    cmdUniversal.Parameters["@PackingCost"].Value = PoModel.packingCost;
                    cmdUniversal.Parameters["@Excise"].Value = PoModel.Excise;
                    cmdUniversal.Parameters["@SerialNo"].Value = PoModel.SerialNo;
                    cmdUniversal.Parameters["@MoldAcco"].Value = PoModel.MoldAcc;
                    cmdUniversal.Parameters["@DateSchedule1"].Value = PoModel.DateSchedule1;
                    cmdUniversal.Parameters["@QtySchedule1"].Value = PoModel.QtySchedule1;
                    cmdUniversal.Parameters["@DateSchedule2"].Value = PoModel.DateSchedule2;
                    cmdUniversal.Parameters["@QtySchedule2"].Value = PoModel.QtySchedule2;
                    cmdUniversal.Parameters["@DateSchedule3"].Value = PoModel.DateSchedule3;
                    cmdUniversal.Parameters["@QtySchedule3"].Value = PoModel.QtySchedule3;
                    cmdUniversal.Parameters["@DateSchedule4"].Value = PoModel.DateSchedule4;
                    cmdUniversal.Parameters["@QtySchedule4"].Value = PoModel.QtySchedule4;
                    cmdUniversal.Parameters["@DateSchedule5"].Value = PoModel.DateSchedule5;
                    cmdUniversal.Parameters["@QtySchedule5"].Value = PoModel.QtySchedule5;
                    cmdUniversal.Parameters["@DateSchedule6"].Value = PoModel.DateSchedule6;
                    cmdUniversal.Parameters["@QtySchedule6"].Value = PoModel.QtySchedule6;
                    cmdUniversal.Parameters["@DateSchedule7"].Value = PoModel.DateSchedule7;
                    cmdUniversal.Parameters["@QtySchedule7"].Value = PoModel.QtySchedule7;
                    cmdUniversal.Parameters["@DateSchedule8"].Value = PoModel.DateSchedule8;
                    cmdUniversal.Parameters["@QtySchedule8"].Value = PoModel.QtySchedule8;

                    cmdUniversal.ExecuteNonQuery();
                }



            }
            this.Close();
            return res;
        }

        public DataTable FillCustomerPO(int CustomerPOID)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "MArketing_FillCustomerPOMaster";
                cmdUniversal.CommandType = CommandType.StoredProcedure;

                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                cmdUniversal.Parameters.Add("@CustomerPOID", SqlDbType.Int).Value = CustomerPOID;

                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        //public DataTable BIndCustomerDetails(string CustomerCode)
        //{
        //    DataTable dt = new DataTable();
        //    this.Initialize();
        //    using (cnUniversal)
        //    {
        //        cmdUniversal.CommandText = "Marketing_BindCustomerDetails";
        //        cmdUniversal.CommandType = CommandType.StoredProcedure;

        //        this.daUniversal.SelectCommand = cmdUniversal;
        //        cnUniversal.Open();
        //        cmdUniversal.Parameters.Add("@CustomerCode", SqlDbType.VarChar).Value = CustomerCode;

        //        daUniversal.Fill(dt);
        //        this.Close();
        //        return dt;
        //    }
        //}

        public DataTable BindItemInfo(string ItemCode)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "Marketing_BindItemInfo";
                cmdUniversal.CommandType = CommandType.StoredProcedure;

                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                cmdUniversal.Parameters.Add("@ItemCode", SqlDbType.VarChar).Value = ItemCode;

                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable BindCustomerPO(CustomerPOModel model)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "Marketing_BinDCustomerPO";
                cmdUniversal.CommandType = CommandType.StoredProcedure;

                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }


        public DataTable BindShimentAccount(CustomerPOModel model)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "Marketing_BindShipMentAccount";
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                
                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable BindQuotattionNum(CustomerPOModel model)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BinQuatationNumber";
                cmdUniversal.CommandType = CommandType.StoredProcedure;

                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }



        public DataTable BindConsigneeName(CustomerPOModel model)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "BinDCustometerMaster";
                cmdUniversal.CommandType = CommandType.StoredProcedure;

                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public DataTable BindModeOfTrasport(CustomerPOModel model)
        {
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "ModeOfTransPort";
                cmdUniversal.CommandType = CommandType.StoredProcedure;

                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();
                return dt;
            }
        }

        public List<CustomerPOModel> GetAllData(CustomerPOModel model)
        {

            List<CustomerPOModel> custPOList = new List<CustomerPOModel>(); 
            DataTable dt = new DataTable();
            this.Initialize();
            using (cnUniversal)
            {
                cmdUniversal.CommandText = "MArketing_getAllCustomerPOData";
                cmdUniversal.CommandType = CommandType.StoredProcedure;

                this.daUniversal.SelectCommand = cmdUniversal;
                cnUniversal.Open();
                daUniversal.Fill(dt);
                this.Close();


                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        custPOList.Add(new CustomerPOModel() { 
                        
                        CustomerPOID = Convert.ToInt32( dt.Rows[i]["CustomerPOId"]),
                        CustCode = dt.Rows[i]["CustomerCode"].ToString(),
                        CustName = dt.Rows[i]["CustomerName"].ToString(),
                        ConsigneedID = Convert.ToInt32( dt.Rows[i]["ConsigneeID"]),
                        PONo = dt.Rows[i]["PoNo"].ToString(),
                        isPOopen = dt.Rows[i]["IsPoOpen"].ToString(),
                        isPoClosed = dt.Rows[i]["IsPoClosed"].ToString(),
                        CustomerLotNo = dt.Rows[i]["CustomerLotNo"].ToString(),
                        ThirdPartyLotNo = dt.Rows[i]["ThirdPartyLotNo"].ToString(),
                        ThirdPartyPoNo = dt.Rows[i]["ThirdPartyPoNo"].ToString(),
                        ContactNo = dt.Rows[i]["ContactNo"].ToString(),
                        FaxNo = dt.Rows[i]["FaxNo"].ToString(),
                        Email = dt.Rows[i]["EmailID"].ToString(),
                        DeliveryAddress = dt.Rows[i]["Address"].ToString(),
                        DeliveryECCNo = dt.Rows[i]["ECCNo"].ToString(),
                        DeliveryCSTNo = dt.Rows[i]["CSTNo"].ToString(),
                        DeliveryTINNo = dt.Rows[i]["TINNo"].ToString(),
                        ContactPersonName = dt.Rows[i]["ContactPersonName"].ToString(),
                        ContactPersonContactName = dt.Rows[i]["ContactPersonContactName"].ToString(),
                        Total = Convert.ToDecimal( dt.Rows[i]["Total"]),
                        GST = Convert.ToDecimal(dt.Rows[i]["GST"]),                        
                        Remark = dt.Rows[i]["Remark"].ToString(),


                        ItemName = dt.Rows[i]["ItemName"].ToString(),
                        ItemCode = dt.Rows[i]["ItemCode"].ToString(),
                        unitId = Convert.ToInt32(dt.Rows[i]["UnitId"]),
                        QuotationID = Convert.ToInt32(dt.Rows[i]["Id"]),
                        ShipmentId = Convert.ToInt32(dt.Rows[i]["ShipmentID"]),
                        RequiredQuantity = Convert.ToInt32(dt.Rows[i]["RequiredQuantity"]),
                        rate = Convert.ToDecimal(dt.Rows[i]["Rate"]),
                        packingCost = Convert.ToDecimal(dt.Rows[i]["PackingCost"]),
                        Excise = Convert.ToDecimal(dt.Rows[i]["Excise"]),
                        SerialNo = Convert.ToInt32(dt.Rows[i]["SerialNo"]),
                        MoldAcc = Convert.ToDecimal(dt.Rows[i]["MoldAcco"]),
                        DateSchedule1 = Convert.ToDateTime(dt.Rows[i]["DateSchedule1"]),
                        QtySchedule1 = Convert.ToDecimal(dt.Rows[i]["QtySchedule1"]),
                        DateSchedule2 = Convert.ToDateTime(dt.Rows[i]["DateSchedule2"]),
                        QtySchedule2 = Convert.ToDecimal(dt.Rows[i]["QtySchedule2"]),

                        DateSchedule3 = Convert.ToDateTime(dt.Rows[i]["DateSchedule3"]),
                        QtySchedule3 = Convert.ToDecimal(dt.Rows[i]["QtySchedule3"]),

                        DateSchedule4 = Convert.ToDateTime(dt.Rows[i]["DateSchedule4"]),
                        QtySchedule4 = Convert.ToDecimal(dt.Rows[i]["QtySchedule4"]),
                        DateSchedule5 = Convert.ToDateTime(dt.Rows[i]["DateSchedule5"]),
                        QtySchedule5 = Convert.ToDecimal(dt.Rows[i]["QtySchedule5"]),
                        DateSchedule6 = Convert.ToDateTime(dt.Rows[i]["DateSchedule6"]),
                        QtySchedule6 = Convert.ToDecimal(dt.Rows[i]["QtySchedule6"]),
                        DateSchedule7 = Convert.ToDateTime(dt.Rows[i]["DateSchedule7"]),
                        QtySchedule7 = Convert.ToDecimal(dt.Rows[i]["QtySchedule7"]),
                        DateSchedule8 = Convert.ToDateTime(dt.Rows[i]["DateSchedule8"]),
                        QtySchedule8 = Convert.ToDecimal(dt.Rows[i]["QtySchedule8"])
                        
                        });
                    }
                }
            }
            return custPOList;
        }

    }
}
