using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modal;
using DAL;
using System.Data;
namespace StandardMetals.BAL
{
    public class UploadMasterBAL
    {
        UploadMasterDAL ClientData = new UploadMasterDAL();

        public DataTable BindCompany(UploadMasterModel ClientModel)
        {
            return ClientData.BindCompany(ClientModel);
        }
        //BindUploadType
        public DataTable BindUploadType(UploadMasterModel ClientModel)
        {
            return ClientData.BindUploadType(ClientModel);
        }
        //BindUploadName
        public DataTable BindUploadName(UploadMasterModel ClientModel)
        {
            return ClientData.BindUploadName(ClientModel);
        }

    }
}
