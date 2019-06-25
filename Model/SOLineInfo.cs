using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Model
{
    public class SOInfo {
        /// <summary>
        /// SO id
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// 组织
        /// </summary>
        public string Org { get; set; }
        /// <summary>
        /// 单号
        /// </summary>
        public string DocNo { get; set; }
        /// <summary>
        /// 客户编码
        /// </summary>
        public string CustomerCode { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 业务日期
        /// </summary>
        public DateTime? BussinessDate { get; set; }
        /// <summary>
        /// 制单人
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// 变更时间
        /// </summary>
        public DateTime? ModifiedOn { get; set; }
        /// <summary>
        /// 行信息
        /// </summary>
        public List<SOLineInfo> SOLine { get; set; }
    }
    public class SOLineInfo
    {
        /// <summary>
        /// SOLine id
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// SO id
        /// </summary>
        public long SOID { get; set; }
        /// <summary>
        /// 行类型
        /// </summary>
        public string LineType { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 料号
        /// </summary>
        public string ItemCode { get; set; }
        /// <summary>
        /// 库存分类
        /// </summary>
        public string StockCategory { get; set; }
        /// <summary>
        /// 库存分类编码
        /// </summary>
        public string StockCategoryCode { get; set; }
        /// <summary>
        /// 库存分类名称
        /// </summary>
        public string StockCategoryName { get; set; }
        /// <summary>
        /// 货号
        /// </summary>
        public string NameSegment1 { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string SPECS { get; set; }
        /// <summary>
        /// 销售单位
        /// </summary>
        public string SOUOM { get; set; }
        /// <summary>
        /// 行号
        /// </summary>
        public string DocLineNo { get; set; }
        /// <summary>
        /// 订单数量
        /// </summary>
        public string OrderByQtyCU { get; set; }
        /// <summary>
        /// 最晚交期
        /// </summary>
        public DateTime? DeliveryDate { get; set; }
        /// <summary>
        /// 基地
        /// </summary>
        public string Base { get; set; }
        /// <summary>
        /// 变更时间
        /// </summary>
        public DateTime? ModifiedOn { get; set; }
        /// <summary>
        /// 出库数量
        /// </summary>
        public decimal SalesOutQuantity { get; set; }
        /// <summary>
        /// 未出库数量
        /// </summary>
        public decimal SalesInQuantity { get; set; }
        /// <summary>
        /// 出库状态
        /// </summary>
        public string SalesOutStatus { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal SalesPrice { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal SalesAmount { get; set; }

    }
}
