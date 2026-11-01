using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;


namespace StandardMetals.BAL
{
    public class ProductionNoteMnger
    {
        dbProductionNote _ObjProdNote = new dbProductionNote();

        public int SaveProductionNote(dbProductionNote _dbProdNote)
        {
            return _ObjProdNote.SaveProductionNote(_dbProdNote);
        }

        //public int UpdateProductionNote(dbProductionNote _dbProdNote)
        //{
        //    return _ObjProdNote.UpdateProductionNote(_dbProdNote);
        //}

    }
}
