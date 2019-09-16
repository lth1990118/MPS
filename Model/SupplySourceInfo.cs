using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Model
{
    public class SupplySourceInfo
    {
        public long ID { get; set; }
        public long Supplier { get; set; }
        public string Supplier_Code { get; set; }
        public string Supplier_Name { get; set; }
        public long Item { get; set; }
        public string Item_Code { get; set; }
        public string NameSegment1 { get; set; }
        public decimal SupplierQuota { get; set; }
        public DateTime ModifiedOn { get; set; }

        public bool Effective_IsEffective { get; set; }
        public DateTime Effective_effectivedate { get; set; }
        public DateTime Effective_disabledate { get; set; }
    }
}
