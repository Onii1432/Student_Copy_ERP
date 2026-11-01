using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace StandardMetals.MODEL
{
    public class ItemMasterModel
    {
        public int ID { get; set; }
        public string ItemCode { get; set; }
        public string ItemCodeNo { get; set; }
        public string ItemName { get; set; }

        [Required(ErrorMessage ="Enter Item Name")]
        public string ItemFullName { get; set; }
        [Required(ErrorMessage ="Select Manufacturere")]
        public int ManufacturerId { get; set; }
        [Required(ErrorMessage = "Enter Material Name")]
        public string Material { get; set; }
        [Required(ErrorMessage ="Select Category")]
        public int ItemCategoryId { get; set; }
        [Required(ErrorMessage = "Select Sub Category")]
        public int ItemSubCategoryId { get; set; }
        [Required(ErrorMessage ="Select Color")]
        public int ColourId { get; set; }

        [Required(ErrorMessage = "Select Unit Of Measurement")]
        public int UnitId { get; set; }
        [Required(ErrorMessage = "Housing Code is Required")]
        public string HSNCODE { get; set; }
        [Required(ErrorMessage = "Gst Rate Is Required")]
        public decimal GSTRate { get; set; }
        [Required(ErrorMessage = "Purchase Cost Is Required")]
        public decimal PurchaseCost { get; set; }
        [Required(ErrorMessage = "Selling Price Is Required")]
        public decimal SellingPrice { get; set; }

        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }

        //below are unused property
        public string ManufacturerName { get; set; }
        public string ItemType { get; set; }
        public string ItemSubType { get; set; }
        public string ColourName { get; set; }
        public string Color { get; set; }

        public string UnitName { get; set; }
        
        public string Username { get; set; }
        public string LoginBranch { get; set; }
        public bool RawMaterial { get; set; }
        //public string ItemCategory { get; set; }
        //public string ItemSubCategory { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }

        public string City { get; set; }

    }
}
