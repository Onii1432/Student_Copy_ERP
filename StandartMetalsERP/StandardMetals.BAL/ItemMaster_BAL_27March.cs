using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using StandardMetals.MODEL;
using StandardMetals.DAL;


namespace StandardMetals.BAL
{
    public class ItemMaster_BAL_27March
    {
        ItemMaster_DAL_27March dal = new ItemMaster_DAL_27March();

        public DataTable FillItemMaster()
        {
            return dal.FillItemMaster();
        }

        public DataTable BindManufacturer()
        {
            return dal.BindManufacturer();
        }

        public DataTable BindColor()
        {
            return dal.BindColor();
        }

        public DataTable BindUOM()
        {
            return dal.BindUOM();
        }


        public int Save_ItemMaster_27March(ItemMaster_MODEL_27March model)
        {
            return dal.Save_ItemMaster_27March(model);
        }

        public int Update_ItemMaster_27March(ItemMaster_MODEL_27March model)
        {
            return dal.Update_ItemMaster_27March(model);
        }

        public DataTable Search_ItemMaster_March27(string ItemCode)
        {
            return dal.Search_ItemMaster_March27(ItemCode);
        }

        public DataTable FillCategory(int CategoryId)
        {
            return dal.FillCategory(CategoryId);
        }
    }
}
