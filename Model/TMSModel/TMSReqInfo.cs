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

    [Table("TMS_ReqInfo")]
    public partial class TMSReqInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(50)]
        public string RtGoodsDocNo { get; set; }

        [StringLength(50)]
        public string CarInfo { get; set; }

        [StringLength(50)]
        public string CarpoolingNo { get; set; }

        [StringLength(50)]
        public string Base { get; set; }

        public string ReqPickTime { get; set; }

        public string ReqArrivalTime { get; set; }

        [StringLength(50)]
        public string CusRefNo { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public string PlanCompleteTime { get; set; }

        public string PlanArriveTime { get; set; }

        public string ConfirmTime { get; set; }

        public string StartLoadTime { get; set; }

        public string FinishLoadTime { get; set; }

        public string ConfirmLeaveTime { get; set; }

        public string ArriveWhTime { get; set; }

        public string StartUnloadTime { get; set; }

        public string FinishUnloadTime { get; set; }

        public string LeaveWhTime { get; set; }

        public string EnterWhTime { get; set; }
    }
}

