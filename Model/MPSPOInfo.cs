using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Model
{
    public class MPSPOInfo
    {
        public int ID { get; set; }
        public long POID { get; set; }
        public string PODocNo { get; set; }
        public string Supplier_Code { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Status { get; set; }
        public string ErrorMsg { get; set; }

        public List<MPSPOLineInfo> POLines { get; set; }
    }
    /// <summary>
    /// 行信息
    /// </summary>
    public class MPSPOLineInfo
    {
        public int ID { get; set; }
        public int MPSPO { get; set; }
        public string SrcDocNo { get; set; }
        public long SrcDoc { get; set; }
        public int SrcDocLineNo { get; set; }
        public long SrcDocLine { get; set; }
        public string ItemCode { get; set; }
        public decimal OrderQty { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Remark { get; set; }
        public string ErrorMsg { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public string PODocNo { get; set; }
        public long POID { get; set; }
        public long POLineNo { get; set; }
        public long POLine { get; set; }
        public string Status { get; set; }
    }
}
