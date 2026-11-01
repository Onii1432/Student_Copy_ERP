using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modal;
using System.Data;
using DAL;

namespace StandardMetals.BAL
{
    public class SubMenuBal
    {

        SubMenuDal SubDal = new SubMenuDal();

        public int SaveMenuData(SubMenuModel SubModel)
        {
            return SubDal.SaveMenuData(SubModel);
        }

        public DataTable FillMenuItem()
        {
            return SubDal.FillMenuItem();

        }
    }
}
