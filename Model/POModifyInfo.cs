using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Model
{
    public class MPSPOModifyInfo
    {
        public int ID { get; set; }
        public long POModify { get; set; }
        public string POModifyDocNo { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public long POID { get; set; }
        public string PODocNo { get; set; }
        public string MPSParam { get; set; }
        public string ErrorMsg { get; set; }

    }
    public class POModifyInfo
    {
        public int Status { get; set; }
        public long POModify { get; set; }
        public POModifyLineDTOInfo POModifyLines { get; set; }
    }
    public class POModifyDTOInfo
    {
        public long PurchaseOrder { get; set; }
        public List<POModifyLineDTOInfo> POModifyLines { get; set; }
    }

    public class POModifyLineDTOInfo
    {
        public long POLine { get; set; }
        public ActionType? ActionType { get; set; }
        public decimal PurQtyPU { get; set; }
        public long Supplier { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
    /// <summary>
    /// Cancel-取消、Delay-延期、TransFac-转厂
    /// </summary>
    public enum ActionType : byte
    {
        /// <summary>
        /// 取消
        /// </summary>
        Cancel = 0,
        /// <summary>
        /// 延期
        /// </summary>
        Delay = 1,
        /// <summary>
        /// 转厂
        /// </summary>
        TransFac = 2
    }

    public class POLineValidateInfo
    {
        [Key]
        public long POLine { get; set; }
        public string DocNo { get; set; }
        public long PurchaseOrder { get; set; }
        public int DocLineNo { get; set; }
       
        public string ItemCode { get; set; }
        public long ItemID { get; set; }
        public string SupplierCode { get; set; }
        public long Supplier { get; set; }
        public decimal PurQtyPU { get; set; }
        public decimal TotalRecievedQtyPU { get; set; }
        public decimal TotalRtnDeductQtyPU { get; set; }
        public decimal OnlineQty { get; set; }

        public int POLineStatus { get; set; }
    }

    public class POModifyResult
    {
        public long POModify { get; set; }
        public string POModifyDocNo { get; set; }
        public string Status { get; set; }
        public List<PurchaseOrder> PurchaseOrders { get; set; }

    }
    public class PurchaseOrder
    {
        public long ID { get; set; }
        public string DocNo { get; set; }
        public string Status { get; set; }
    }
}
