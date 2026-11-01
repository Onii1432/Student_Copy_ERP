using System.Collections.Generic;

namespace StandardMetals.MODEL
{
    public class SupplierWiseItemModel
    {
        public string SupplierName { get; set; }
        public int ItemCount { get; set; }
    }

    public class DefaultDashboardModel
    {
        public List<SupplierWiseItemModel> SupplierWiseItems { get; set; }
        public int TotalSupplierCount { get; set; }
        public int TotalItemCount { get; set; }
    }
}


