using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Model
{
    public class ASNInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// 制单人
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// 送货单号
        /// </summary>
        public string DocNo { get; set; }
        /// <summary>
        /// 送货日期       
        /// </summary>
        public string BusinessDate { get; set; }
        /// <summary>
        ///  供应商编码       
        /// </summary>
        public string Supplier_Code { get; set; }
        /// <summary>
        /// 送货地址
        /// </summary>
        public string SendAddress { get; set; }
        /// <summary>
        /// 车辆编号（暂时为空）
        /// </summary>
        public string Car_Code { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedOn { get; set; }
        /// <summary>
        /// 行信息
        /// </summary>
        public List<ASNLineInfo> ASNLine { get; set; }
    }

    public class ASNLineInfo {
        public long ID { get; set; }
        public long ASNID { get; set; }
        /// <summary>
        /// 行号
        /// </summary>
        public int DocLineNo { get; set; }
        /// <summary>
        /// 采购订单号
        /// </summary>
        public string PODocno { get; set; }
        /// <summary>
        ///  物料编码
        /// </summary>
        public string ItemCode { get; set; }
        /// <summary>
        /// 业绩归属
        /// </summary>
        public string Dept { get; set; }
        /// <summary>
        ///  货号       
        /// </summary>
        public string NameSegment1 { get; set; }
        /// <summary>
        /// 发货量   
        /// </summary>
        public string ShipQty { get; set; }
        /// <summary>
        /// 单体积
        /// </summary>
        public string Volume { get; set; }
        /// <summary>
        ///  单重量        
        /// </summary>
        public string Weight { get; set; }
        /// <summary>
        /// 河北总体积
        /// </summary>
        public string TotalVolume { get; set; }
        /// <summary>
        /// 河北总重量
        /// </summary>
        public string TotalWeight { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedOn { get; set; }
    }
}
