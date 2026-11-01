using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StandardMetals.DAL;

namespace StandardMetals.BAL
{
    public class indentBAL
    {
        indentDAL dal = new indentDAL();   
        public DataTable GetIndentNoAutoGen()
        {
            return dal.GetIndentNoAutoGen();
        }

        public DataTable GetIndentType()
        {
            return dal.GetIndentType();
        }

        public DataTable GetItemType()
        {
            return dal.GetItemType();
        }

        public DataTable GetItemnameType()
        {
            return dal.GetItemnameType();
        }
        public DataTable GetDepartment()
        {
            return dal.GetDepartment();
        }
        public DataTable GetUnit()
        {
            return dal.GetUnit();
        }

        public DataTable GetItemDetails(string itemName)
        {
            return dal.GetItemDetails(itemName);
        }
    }
}
