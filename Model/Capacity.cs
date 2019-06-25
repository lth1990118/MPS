using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Model
{
    public class Capacity
    {
        /// <summary>
        /// 供应商ID
        /// </summary>
        public long Supplier { get; set; }
        /// <summary>
        /// 料品ID
        /// </summary>
        public long ItemMaster { get; set; }
        /// <summary>
        /// 产能
        /// </summary>
        public decimal CapacityQty { get; set; }
        public string Remark { get; set; }
    }
}
