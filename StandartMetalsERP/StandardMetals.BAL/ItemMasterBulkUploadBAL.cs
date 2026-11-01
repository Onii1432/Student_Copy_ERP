
using StandardMetals.DAL;
using System;
using System.Data;

public class ItemMasterBulkUploadBAL
{ 
    private readonly ItemMasterBulkUploadDAL itemDAL = new ItemMasterBulkUploadDAL();


    // Create Upload ID
    public int InsertUploadMaster(string fileName)
    {
        return itemDAL.InsertUploadMaster(fileName);
    }

    // Bulk insert Excel rows into staging table
    public void BulkInsertItemMaster(DataTable excelData, int uploadId)
    {
        itemDAL.BulkInsertItemMaster(excelData, uploadId);
    }

    // Validate uploaded rows and return counts
    public DataTable ValidateItemMasterUpload(int uploadId)
    {
        return itemDAL.ValidateItemMasterUpload(uploadId);
    }

    // Retrieve failed rows for Excel download
    public DataTable GetFailedItemMasterRecords(int uploadId)
    {
        return itemDAL.GetFailedItemMasterRecords(uploadId);
    }
}



