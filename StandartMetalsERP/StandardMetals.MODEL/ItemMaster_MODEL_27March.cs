using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace StandardMetals.MODEL
{
    public class ItemMaster_MODEL_27March : MasterDataFieldsModel
    {
        //only item master form property
        public int Id { get; set; }
        public string ItemCode { get; set; }
        public string ItemCodeNo { get; set; }

        public string ItemName { get; set; }
        [Required]
        public string ItemFullName { get; set; }
        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        public string Material { get; set; }
        [Required]
        public int ItemCategeryId { get; set; }
        [Required]
        public int ItemSubCatogoryId { get; set; }
        [Required]
        public int ColourId { get; set; }
        [Required]
        public int UOMId { get; set; }
        [Required]
        public string HSNCODE { get; set; }
        [Required]
        public decimal GSTRate { get; set; }
        [Required]
        public decimal PurchaseCost { get; set; }
        [Required]
        public decimal SellingPrice { get; set; }

        public bool RawMaterial { get; set; }

        //above property are used to bind ItemMaster Form
        public string ItemType { get; set; }
        public string ItemSubType { get; set; }
        public int UserId { get; set; }
        public int LoginBranchId { get; set; }

        
    }


}

public enum ManuFactName
{
    Abc,
    RohanPlastic,
    ArihantMarketing,
    PerfectMetals

}