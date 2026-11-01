using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StandardMetals.MODEL;
using StandardMetals.DAL;
using System.Data;

namespace StandardMetals.BAL
{
    public class MenuMasterBal
    {
        MenuMasterDal MenuDal = new MenuMasterDal();

        public int SaveMenuData(MenuMasterModel masterModel)
        {
            return MenuDal.SaveMenuData(masterModel);
        }

        public DataTable FillMenuItem()
        {
            return MenuDal.FillMenuItem();

        }

        public int SaveSubMenuData(SubMenuModel subMenuModel)
        {
            return MenuDal.SaveSubMenuData(subMenuModel);

        }

        public DataTable FillRoleMasterItem()
        {
            return MenuDal.FillRoleMasterItem();

        }
    }
}
