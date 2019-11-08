using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Model.API
{
    public class CreatePODto
    {
        /// <summary>
        /// 供应商编码
        /// </summary>
        public string Supplier_Code { get; set; }        
        /// <summary>
        /// 采购行信息
        /// </summary>
        public List<CreatePOLineDto> POLines { get; set; }
    }
    public class CreatePOLineDto {
        /// <summary>
        /// 来源单号
        /// </summary>
        public string SrcDocNo { get; set; }
        /// <summary>
        /// 来源单ID
        /// </summary>
        public long SrcDoc { get; set; }
        /// <summary>
        /// 来源行号
        /// </summary>
        public int SrcDocLineNo { get; set; }
        /// <summary>
        /// 来源行ID
        /// </summary>
        public long SrcDocLine { get; set; }
        /// <summary>
        /// 料号
        /// </summary>
        public string ItemCode { get; set; }
        /// <summary>
        /// 系统下单数量
        /// </summary>
        public decimal OrderQty { get; set; }
        /// <summary>
        /// 交期
        /// </summary>
        public DateTime DeliveryDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMsg { get; set; }
    }

    public class PODto
    {
        /// <summary>
        /// 采购单号
        /// </summary>
        public string PODocNo { get; set; }
        /// <summary>
        /// 交期
        /// </summary>
        public DateTime DeliveryDate { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public string Supplier_Code { get; set; }
        public string ErrorMsg { get; set; }
    }
}
