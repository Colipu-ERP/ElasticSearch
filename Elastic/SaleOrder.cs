using System.Collections.Generic;

namespace Elastic
{
    public class SaleOrder
    {
        public int SaleOrderId { get; set; }

        public string SaleOrderCode { get; set; }

        public List<SaleOrderDetail> SaleOrderDetails { get; set; }
    }

    public class SaleOrderDetail
    {
        public int SaleOrderDetailId { get; set; }

        public string FullName { get; set; }
    }
}
