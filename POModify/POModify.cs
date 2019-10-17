using Custom;
using MPS.Custom;
using MPS.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Bussiness
{
    public class POModify
    {
        public RetModel<object> CreatePOModify(RecModel<POModifyDTOInfo> param) {
            RetModel<object> Result = new RetModel<object>();
            Result.code = "0";
            Result.message = "0";
            ValidateParam(param);
            List<SqlParameter> listParam = new List<SqlParameter>();
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("select pl.ItemInfo_ItemCode as ItemCode,pl.id as POLine,po.ID as PurchaseOrder,po.docno,pl.DocLineNo,po.DescFlexField_PubDescSeg42,pl.DocLineNo,pl.PurQtyPU,pl.TotalRecievedQtyPU, pl.TotalRtnDeductQtyPU,#tempdata.qtyc as OnlineQty from production.dbo.PM_PurchaseOrder po left join production.dbo.PM_POLine pl on po.id=pl.PurchaseOrder left join ( select lineid as SrcDocLineID,sum(qty) as QtyC from( select rdl.SrcDocLineID as lineid, sum( ConfirmQty1) as qty from production.dbo.Kuka_VPT_RtGoodsDocLine rdl  where rdl.LineStatus <= 2 group by SrcDocLineID   union all  select asnl.SrcDocInfo_SrcDocLine_EntityID as lineid,Sum(asnl.ShipQtyTU) as qty from production.dbo.PM_ASN asn  left join  production.dbo.PM_ASNLine asnl on asn.id=asnl.ASN  where asnl.Status<=2   group by asnl.SrcDocInfo_SrcDocLine_EntityID   union all  select rl.SrcDoc_SrcDocLine_EntityID as lineid,Sum(rl.RcvQtyPU) as qty from production.dbo.PM_Receivement rcv  left join  production.dbo.PM_RcvLine rl on rcv.id=rl.Receivement and rl.KitParentLine=0  where rl.Status<=3  group by rl.SrcDoc_SrcDocLine_EntityID  )t group by lineid )#tempdata on #tempdata.SrcDocLineID=pl.id where po.id=@POID");
            listParam.Add(new SqlParameter("POID", param.data.PurchaseOrder));
            var dataTable = DbHelperSQL.Query(sqlQuery.ToString(), listParam);
            List<POLineValidateInfo> list= ExtendMethod.ToDataList<POLineValidateInfo>(dataTable);
            if (list.Count == 0) {
                throw new Exception(string.Format("采购订单ID不存在{0}", param.data.PurchaseOrder));
            }
            foreach (var poModifyLine in param.data.POModifyLines)
            {
                var item = list.Where(p => p.POLine == poModifyLine.POLine).FirstOrDefault();
                if (item == null) {
                    throw new Exception(string.Format("采购订单行ID不存在{0}", poModifyLine.POLine));
                }
                if (poModifyLine.PurQtyPU > item.PurQtyPU - item.TotalRecievedQtyPU - item.TotalRtnDeductQtyPU - item.OnlineQty)
                {
                    throw new Exception(string.Format("变更数量{0}大于可变更数量{1}", poModifyLine.PurQtyPU, item.PurQtyPU - item.TotalRecievedQtyPU - item.TotalRtnDeductQtyPU - item.OnlineQty));
                }
            }

            return Result;
        }

        private void ValidateParam(RecModel<POModifyDTOInfo> param)
        {
            if (param == null) {
                throw new Exception("参数格式有误或参数没传入");
            }
            if (param.data == null) {
                throw new Exception("参数格式有误或参数没传入");
            }
            if (param.data.PurchaseOrder <= 0) {
                throw new Exception("缺少订单ID");
            }
            if (param.data.POModifyLines.Count == 0) {
                throw new Exception("缺少需要变更的订单行信息");
            }
            foreach (var item in param.data.POModifyLines)
            {
                if (item.POLine == 0)
                {
                    throw new Exception("缺少订单行ID");
                }
                if (item.PurQtyPU <= 0)
                {
                    throw new Exception("需要变更的数量必须大于0");
                }
                if (string.IsNullOrEmpty(item.ActionType.ToString()))
                {
                    throw new Exception("变更类型");
                }
                switch (item.ActionType.Value) {
                    case ActionType.Cancel:
                        break;
                    case ActionType.Delay:
                        if (item.DeliveryDate == DateTime.MinValue)
                        {
                            throw new Exception("变更类型为延期时，缺少新的交期字段");
                        }
                        break;
                    case ActionType.TransFac:
                        if (item.DeliveryDate == DateTime.MinValue)
                        {
                            throw new Exception("变更类型为转厂时，缺少新的交期字段");
                        }
                        if (item.Supplier == 0)
                        {
                            throw new Exception("变更类型为转厂时，缺少新的供应商字段");
                        }
                        break;
                    default:
                        throw new Exception("不能识别的变更类型");
                }
            }
        }
    }
}
