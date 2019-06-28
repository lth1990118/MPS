using MPS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPS.Model
{
    public class ItemInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// 料号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 品名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string SPECS { get; set; }
        /// <summary>
        /// 业绩归属/产品线
        /// </summary>
        public string Dept { get; set; }
        /// <summary>
        /// 货号
        /// </summary>
        public string NameSegment1 { get; set; }
        /// <summary>
        /// 系列
        /// </summary>
        public string Serious { get; set; }
        
        /// <summary>
        /// 是否电商
        /// </summary>
        public string IsOnline { get; set; }
        /// <summary>
        /// 安全库存
        /// </summary>
        public string SafeQty { get; set; }
        /// <summary>
        /// 最高库存
        /// </summary>
        public string MaxQty { get; set; }
        /// <summary>
        /// 计划模式分类
        /// </summary>
        public string PlanMode { get; set; }
        /// <summary>
        /// 杭州安全库存
        /// </summary>
        public string HZSafeQty { get; set; }
        /// <summary>
        /// 杭州最高库存
        /// </summary>
        public string HZMaxQty { get; set; }
        /// <summary>
        /// 杭州计划模式分类
        /// </summary>
        public string HZPlanMode { get; set; }
        /// <summary>
        /// 河北安全库存
        /// </summary>
        public string HBSafeQty { get; set; }
        /// <summary>
        /// 河北最高库存
        /// </summary>
        public string HBMaxQty { get; set; }
        /// <summary>
        /// 河北计划模式分类
        /// </summary>
        public string HBPlanMode { get; set; }
        /// <summary>
        /// 集成品类
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 上市时间
        /// </summary>
        public string OnMarketTime { get; set; }
        /// <summary>
        /// 下市时间
        /// </summary>
        public string OffMarketTime { get; set; }
        /// <summary>
        /// 采购周期
        /// </summary>
        public int POCycle { get; set; }
        /// <summary>
        /// 最小起订量
        /// </summary>
        public string MinOrder { get; set; }
        /// <summary>
        /// 在销状态
        /// </summary>
        public string OnMarketStatus { get; set; }
        /// <summary>
        /// 促销活动 ---扩展字段4
        /// </summary>
        public string Activity { get; set; }
        /// <summary>
        /// 库存单位
        /// </summary>
        public string InventorySecondUOM { get; set; }
        /// <summary>
        /// 库存单位编码
        /// </summary>
        public string InventorySecondUOM_Code { get; set; }
        /// <summary>
        /// 库存单位名称
        /// </summary>
        public string InventorySecondUOM_Name { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public string ModifiedOn { get; set; }
        /// <summary>
        /// 采购分类
        /// </summary>
        public string PurchaseCategory { get; set; }
        /// <summary>
        /// 库存单位重量
        /// </summary>
        public string Weight { get; set; }
        /// <summary>
        /// 库存单位体积
        /// </summary>
        public string ItemBulk { get; set; }
        /// <summary>
        /// 销量ABC
        /// </summary>
        public string ABC { get; set; }
        /// <summary>
        /// 出样店数
        /// </summary>
        public decimal? CustomNum { get; set; }
        /// <summary>
        /// 返单店率
        /// </summary>
        public string RetCustomNum { get; set; }
        /// <summary>
        /// 活动系数
        /// </summary>
        public string ActiveCOE { get; set; }
        /// <summary>
        /// 预下市 ---扩展字段17
        /// </summary>
        public string OffMarket { get; set; }
        /// <summary>
        /// 产能
        /// </summary>
        public List<Capacity> Capacity
        {
            get;
            set;
        }
        /// <summary>
        /// 公司安全库存河北
        /// </summary>
        public string ComSafeQty { get; set; }
        /// <summary>
        /// 公司安全库存河北
        /// </summary>
        public string HZComSafeQty { get; set; }
        /// <summary>
        /// 公司安全库存杭州
        /// </summary>
        public string HBComSafeQty { get; set; }
        /// <summary>
        /// 供方安全库存
        /// </summary>
        public string SuppSafeQty { get; set; }
    }
}
