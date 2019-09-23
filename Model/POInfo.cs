using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Model
{
    public class POInfo
    {
        public long ID { get; set; }
        public string DocNo { get; set; }
        public long Supplier { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public DateTime BusinessDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Status { get; set; }
        public List<POLineInfo> POLines { get; set; }

    }

    public class POLineInfo
    {
        public long PurchaseOrder { get; set; }
        public int DocLineNo { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Dept { get; set; }
        public int IsOverDate { get; set; }
        public decimal PurQtyPU { get; set; }
        public decimal TotalRecievedQtyPU { get; set; }
        public decimal TotalRtnDeductQtyPU { get; set; }
        public decimal LastQty { get; set; }
        public decimal OverDateQty { get; set; }
        public DateTime? ChangeDeliveryDate { get; set; }
        public decimal OriginQty { get; set; }
        public DateTime? OriginDeliveryDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Status { get; set; }

    }

    public class JCPOInfo
    {
        public long ID { get; set; }
        public string DocNo { get; set; }
        public long Supplier { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public List<JCPOLineInfo> POLines { get; set; }

    }
    public class JCPOLineInfo
    {
        public long PurchaseOrder { get; set; }
        /// <summary>
        /// 子行id
        /// </summary>
        public long SubLineID { get; set; }
        /// <summary>
        /// 子行行号
        /// </summary>
        public int SubLineNo { get; set; }
        /// <summary>
        /// 子行行号
        /// </summary>
        public decimal TotalQty { get; set; }
        /// <summary>
        /// 行id
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// 行号
        /// </summary>
        public int DocLineNo { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 料号
        /// </summary>
        public string ItemCode { get; set; }
        /// <summary>
        /// 品名
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 业绩归属
        /// </summary>
        public string Dept { get; set; }
        /// <summary>
        /// 交期
        /// </summary>
        public DateTime? DeliveryDate { get; set; }
        /// <summary>
        /// 杭州当月入库
        /// </summary>
        public decimal HZCurrentMonthInv { get; set; }
        /// <summary>
        /// 河北当月入库
        /// </summary>
        public decimal HBCurrentMonthInv { get; set; }
        /// <summary>
        /// 累计入库
        /// </summary>
        public decimal TotalInv { get; set; }
        /// <summary>
        /// 订单数量
        /// </summary>
        public decimal OrderQty { get; set; }
        /// <summary>
        /// 剩余订单数量
        /// </summary>
        public decimal LastQty { get; set; }
        /// <summary>
        /// 订单可用数量
        /// </summary>
        public decimal UsageQty { get; set; }
        /// <summary>
        /// 订单可用库存数量
        /// </summary>
        public decimal OrderUsageQty { get; set; }
        /// <summary>
        /// 总在途数据
        /// </summary>
        public decimal TotalOnWay { get; set; }
        /// <summary>
        /// 杭州在途数量
        /// </summary>
        public decimal HZOnWay { get; set; }
        /// <summary>
        /// 河北在途数量
        /// </summary>
        public decimal HBOnWay { get; set; }
        /// <summary>
        /// 杭州已排未发数量
        /// </summary>
        public decimal HZNoExpress { get; set; }
        /// <summary>
        /// 河北已排未发数量
        /// </summary>
        public decimal HBNoExpress { get; set; }
        /// <summary>
        /// 杭州总入库数量
        /// </summary>
        public decimal HZTotalInv { get; set; }
        /// <summary>
        /// 河北总入库数量
        /// </summary>
        public decimal HBTotalInv { get; set; }
        /// <summary>
        /// 销售订单未发数量
        /// </summary>
        public decimal SONoExpress { get; set; }
        /// <summary>
        /// 公司仓库库存
        /// </summary>
        public decimal ComInv { get; set; }
    }

}
