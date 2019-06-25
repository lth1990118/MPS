
using MPS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPS.Model
{
    public class ItemInfoBack
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
        /// 计划模式分类
        /// </summary>
        public string PlanMode { get; set; }
        /// <summary>
        /// 是否电商
        /// </summary>
        public string IsOnline { get; set; }
        /// <summary>
        /// 安全库存
        /// </summary>
        public decimal SafeQty { get; set; }
        /// <summary>
        /// 最高库存
        /// </summary>
        public decimal MaxQty { get; set; }
        /// <summary>
        /// 集成品类
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 上市时间
        /// </summary>
        public DateTime OnMarketTime { get; set; }
        /// <summary>
        /// 下市时间
        /// </summary>
        public DateTime OffMarketTime { get; set; }
        /// <summary>
        /// 采购周期
        /// </summary>
        public int POCycle { get; set; }
        /// <summary>
        /// 最小起订量
        /// </summary>
        public decimal MinOrder { get; set; }
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
        public DateTime ModifiedOn { get; set; }
        /// <summary>
        /// 采购分类
        /// </summary>
        public string PurchaseCategory { get; set; }
        /// <summary>
        /// 库存单位重量
        /// </summary>
        public decimal Weight { get; set; }
        /// <summary>
        /// 库存单位体积
        /// </summary>
        public decimal ItemBulk { get; set; }
        /// <summary>
        /// 销量ABC
        /// </summary>
        public string ABC { get; set; }
        /// <summary>
        /// 出样店数
        /// </summary>
        public decimal CustomNum { get; set; }
        /// <summary>
        /// 返单店率
        /// </summary>
        public decimal RetCustomNum { get; set; }
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
        private List<Capacity> capacity = new List<Capacity>() {
            new Capacity(){
                Supplier=0,CapacityQty=0,ItemMaster=0
            }
        };
        public List<Capacity> Capacity
        {
            get
            {
                return new List<Capacity>() {
                    new Capacity(){
                        Supplier=0,CapacityQty=0,ItemMaster=0
                    }
                };
            }
            set
            {

            }
        }
    }
}