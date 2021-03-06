﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Model
{
    public class RtGoodsInfo
    {
        /// <summary>
        /// 供应商编码
        /// </summary>
        public string SupplierCode { get; set; }
        /// <summary>
        /// 确认日期
        /// </summary>
        public DateTime ConfirmDate { get; set; }
        
        /// <summary>
        /// 送货地址
        /// </summary>
        public string DeliveryAddress { get; set; }
        /// <summary>
        /// 拼车单号
        /// </summary>
        public string CarpoolNo { get; set; }
        /// <summary>
        /// 物流确认书单号
        /// </summary>
        public string LogisticsDocNo { get; set; }
        /// <summary>
        /// 车型
        /// </summary>
        public string CarCode { get; set; }
        /// <summary>
        /// AbnormalBillType=1或者空是正常单，AbnormalBillType=2是异常单
        /// </summary>
        public int AbnormalBillType { get; set; }
        /// <summary>
        /// 供应商编码
        /// </summary>
        public List<RtGoodsLineInfo> RtGoodsLines { get; set; }
    }

    public class RtGoodsLineInfo
    {
        /// <summary>
        /// 料品编码
        /// </summary>
        public string ItemCode { get; set; }
        /// <summary>
        /// 确认日期
        /// </summary>
        public DateTime ConfirmDate { get; set; }
        /// <summary>
        /// 手工确认量
        /// </summary>
        public decimal ConfirmQty { get; set; }
        /// <summary>
        /// 采购订单子行id
        /// </summary>
        public long POShipLineID { get; set; }
        /// <summary>
        /// 采购订单行id
        /// </summary>
        public long POLineID { get; set; }
        /// <summary>
        /// 采购订单号
        /// </summary>
        public string PODocNo { get; set; }

        /// <summary>
        /// 总体积
        /// </summary>
        public decimal TotalVolume { get; set; }
        /// <summary>
        /// 总重量
        /// </summary>
        public decimal TotalWeight { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }
}
