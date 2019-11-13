using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Model
{
    public class POInfoModifyQuery
    {
        public string pocPurchaseOrderNo { get; set; }
        public int pocPurchaseOrderLineNo { get; set; }
        public string pocMaterielNo { get; set; }
        public string pocGoodCode { get; set; }
        public string pocSupplierCode { get; set; }
    }
    public class POInfoModify
    {
        public string createdBy { get; set; }
        public string pocPurchaseOrderNo { get; set; }
        public long pocPurchaseOrderId { get; set; }
        public int pocPurchaseOrderLineNo { get; set; }
        public long pocPurchaseOrderLineId { get; set; }
        public string pocMaterielNo { get; set; }
        public string pocGoodCode { get; set; }
        public string pocProductLine { get; set; }
        public string pocMaterielName { get; set; }
        public string pocSupplierCode { get; set; }
        public string pocSupplierName { get; set; }
        public string pocSpecs { get; set; }
        public decimal pocPurchaseQty { get; set; }
        public DateTime pocDeliveryPeriod { get; set; }
        public decimal pocChangeableQty { get; set; }
    }
}
