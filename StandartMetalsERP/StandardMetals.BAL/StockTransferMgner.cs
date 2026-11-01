using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;


namespace StandardMetals.BAL
{
    public class StockTransferMgner
    {
        dbStockTransfer dbstocktr=new dbStockTransfer();

        public int SaveStockTransfer(dbStockTransfer _Dbstock)
        {
            return dbstocktr.SaveStockTransfer(_Dbstock);
        }
    }
}
