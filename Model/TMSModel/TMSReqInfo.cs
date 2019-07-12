using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace MPS.Model.TMSModel
{

    [Table("Kuka_TMS_ReqInfo")]
    public partial class TMSReqInfo
    {
        [StringLength(50)]
        public string RtGoodsDocNo { get; set; }

        [StringLength(50)]
        public string CarInfo { get; set; }

        [StringLength(50)]
        public string LoadNo { get; set; }

        [StringLength(50)]
        public string CarpoolingNo { get; set; }

        [StringLength(50)]
        public string Base { get; set; }

        [StringLength(50)]
        public string CusRefNo { get; set; }

        [StringLength(50)]
        public string Status { get; set; }
        /// <summary>
        /// 节点类型
        /// </summary>
        public string NodeType { get; set; }
        /// <summary>
        /// 节点时间
        /// </summary>
        public string NodeTime { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public string BizType { get; set; }
    }
}

