using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Model
{
    public class SupplierSite {
        public long ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class SupplierInfo
    {
        /// <summary>
        /// 供应商ID
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// 供应商编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 简称
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 分类编码
        /// </summary>
        public string Category_Code { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string Category_Name { get; set; }
        /// <summary>
        /// 供应商位置
        /// </summary>
        public List<SupplierSite> SupplierSites { get; set; }
        /// <summary>
        /// 供应商位置编码
        /// </summary>
        //public string SupplierSites_Code { get; set; }
        ///// <summary>
        ///// 供应商位置名称
        ///// </summary>
        //public string SupplierSites_Name { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        public string Territory { get; set; }
        /// <summary>
        /// 地区编码
        /// </summary>
        public string Territory_Code { get; set; }
        /// <summary>
        /// 地区名称
        /// </summary>
        public string Territory_Name { get; set; }
        /// <summary>
        /// 评估等级
        /// </summary>
        public string EvaluateLevel { get; set; }
       /// <summary>
       /// 主承运商
       /// </summary>
        public string Carrier { get; set; }
        /// <summary>
        /// 外协供应商
        /// </summary>
        public string IsAssistance { get; set; }
        /// <summary>
        /// 一次性供应商
        /// </summary>
        public string IsMISC { get; set; }
        /// <summary>
        /// 办公地址
        /// </summary>
        public string OfficialLocation { get; set; }
        /// <summary>
        /// 办公地址编码
        /// </summary>
        public string OfficialLocation_Code { get; set; }
        /// <summary>
        /// 办公地址名称
        /// </summary>
        public string OfficialLocation_Name { get; set; }
        /// <summary>
        /// 注册地址
        /// </summary>
        public string RegisterLocation { get; set; }
        /// <summary>
        /// 注册地址编码
        /// </summary>
        public string RegisterLocation_Code { get; set; }
        /// <summary>
        /// 注册地址名称
        /// </summary>
        public string RegisterLocation_Name { get; set; }
        /// <summary>
        /// 出货位置
        /// </summary>
        public List<SupplierSite> DefaultShipTo { get; set; }
        ///// <summary>
        ///// 出货位置编码
        ///// </summary>
        //public string DefaultShipTo_Code { get; set; }
        ///// <summary>
        ///// 出货位置名称
        ///// </summary>
        //public string DefaultShipTo_Name { get; set; }
        /// <summary>
        /// 运输提前期
        /// </summary>
        public string TransitLeadTime { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Effective { get; set; }
        /// <summary>
        /// 挂起日期
        /// </summary>
        public DateTime HoldDate { get; set; }
        /// <summary>
        /// 挂起原因
        /// </summary>
        public string HoldReason { get; set; }
        /// <summary>
        /// 挂起人
        /// </summary>
        public string HoldUser { get; set; }
        /// <summary>
        /// 挂起
        /// </summary>
        public string IsHoldRelease { get; set; }
        /// <summary>
        /// 解除日期
        /// </summary>
        public DateTime ReleaseDate { get; set; }
        /// <summary>
        /// 解除原因
        /// </summary>
        public string ReleaseReason { get; set; }
        /// <summary>
        /// 解除人
        /// </summary>
        public string ReleaseUser { get; set; }
        /// <summary>
        /// 供应商状态
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 状态时间
        /// </summary>
        public DateTime StateTime { get; set; }
        /// <summary>
        /// 状态人
        /// </summary>
        public string StateUser { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string ModifiedBy { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifiedOn { get; set; }
        /// <summary>
        /// srm供应商编码
        /// </summary>
        public string SrmCode { get; set; }

    }
}
