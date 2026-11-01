
using System.Data;
using StandardMetals.DAL;
using StandardMetals.MODEL;

namespace StandardMetals.BAL
{
    public class PurchaseIndentApril2026BAL
    {
        PurchaseIndentApril2026DAL dal = new PurchaseIndentApril2026DAL();

        public DataTable GetIndentNoAutoGenApril2026()
        {
            return dal.GetIndentNoAutoGenApril2026();
        }

        public DataTable GetIndentTypeApril2026()
        {
            return dal.GetIndentTypeApril2026();
        }

        public DataTable GetItemTypeApril2026()
        {
            return dal.GetItemTypeApril2026();
        }

        public DataTable GetItemnameTypeApril2026()
        {
            return dal.GetItemnameTypeApril2026();
        }

        public DataTable GetDepartmentApril2026()
        {
            return dal.GetDepartmentApril2026();
        }

        public DataTable GetUnitApril2026()
        {
            return dal.GetUnitApril2026();
        }

        public DataTable GetItemDetailsApril2026(string itemName)
        {
            return dal.GetItemDetailsApril2026(itemName);
        }

        public DataTable SaveIndentApril2026(PurchaseIndentApril2026Model model)
        {
            return dal.SaveIndentApril2026(model);
        }

        public DataSet GetIndentDetailsApril2026(int indentId)
        {
            return dal.GetIndentDetailsApril2026(indentId);
        }

        public DataTable UpdateIndentApril2026(PurchaseIndentApril2026Model model)
        {
            return dal.UpdateIndentApril2026(model);
        }
    }
}
