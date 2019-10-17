using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Model
{
    public class MPSRtGoodsDocInfo
    {
        public long ID { get; set; }
        public string DocNo { get; set; }
        public string Base { get; set; }
        public DateTime ModifiedOn { get; set; }
        public List<MPSRtGoodsDocLineInfo> RtGoodsDocLines { get; set; }
    }
    public class MPSRtGoodsDocLineInfo
    {
        public long RtGoodsDoc { get; set; }
        public long ID { get; set; }
        public int RtDocLineNo { get; set; }
        public string ItemCode { get; set; }
        public decimal ConfirmQty { get; set; }
        public string Remark { get; set; }
        public string LineStatus { get; set; }
        public string ASNDocNo { get; set; }
        public decimal ShipQtyTU { get; set; }
        public decimal TotalRcvQtyTU { get; set; }
        public DateTime ShipDate { get; set; }
        public string ASNLineStatus { get; set; }
        public long SrcDocLine { get; set; }
        public decimal RcvQtyPU { get; set; }
        public decimal BreakageQty { get; set; }
        public DateTime RcvDate { get; set; }
    }
}
