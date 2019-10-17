using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Model
{
    public class RcvInfo
    {
        public long ID { get; set; }
        public string Org { get; set; }
        public string DocNo { get; set; }
        public DateTime BusinessDate { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Supplier_Code { get; set; }
        public string Supplier_ShortName { get; set; }
        public string Supplier_Supplier { get; set; }
        public List<RcvLineInfo> RcvLines { get; set; }

    }
    public class RcvLineInfo
    {
        public long ID { get; set; }
        public int DocLineNo { get; set; }
        public string ItemInfo_ItemCode { get; set; }
        public decimal RcvQtyPU { get; set; }
        public decimal ArriveQtyPU { get; set; }
        public decimal FinallyPriceAC { get; set; }
        public long SrcDoc_SrcDoc_EntityID { get; set; }
        public string SrcDoc_SrcDocNo { get; set; }
        public long SrcDoc_SrcDocLine_EntityID { get; set; }
        public int SrcDoc_SrcDocLineNo { get; set; }
        public long Receivement { get; set; }
    }
}
