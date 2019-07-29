using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Model.TMSModel
{
    public class RtGoodsDocInfo
    {
        public long ID { get; set; }
        /// <summary>
        /// 回货计划单号
        /// </summary>
        public string RtDocNo { get; set; }
        /// <summary>
        /// 拼车单号
        /// </summary>
        public string CarpoolingNo { get; set; }
        public DateTime ModifiedOn { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public string Supplier { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        /// <summary>
        /// 收货组织
        /// </summary>
        public string RcvOrg { get; set; }
        public string RcvOrgCode { get; set; }
        public string RcvOrgName { get; set; }
        /// <summary>
        /// 送货地址
        /// </summary>
        public string SendAddressName { get; set; }
        public string SendAddressCode { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public string LogisticsDocNo { get; set; }

        public List<RtGoodsDocLineInfo> RtGoodsDocLines { get; set; }

       
    }
    public class RtGoodsDocLineInfo
    {
        public long RtGoodsDoc { get; set; }
        /// <summary>
        /// 料品
        /// </summary>
        public long Item { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        /// <summary>
        /// 回货计划确认数量
        /// </summary>
        public string PlanQty { get; set; }

        public decimal TotalVolume { get; set; }
        public decimal TotalWeight { get; set; }
    }
}
