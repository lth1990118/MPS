using Custom;
using MPS.Bussiness.U9Service;
using MPS.Custom;
using MPS.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFSoft.UBF.Util.Context;
using www.ufida.org.EntityData;

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
            sqlQuery.Append("select  pl.status as POLineStatus,po.Supplier_Code as SupplierCode,po.Supplier_Supplier as Supplier,pl.ItemInfo_ItemID as ItemID,pl.ItemInfo_ItemCode as ItemCode,pl.id as POLine,po.ID as PurchaseOrder,po.docno,po.DescFlexField_PubDescSeg42,pl.DocLineNo,pl.PurQtyPU,pl.TotalRecievedQtyPU, pl.TotalRtnDeductQtyPU,#tempdata.qtyc as OnlineQty from dbo.PM_PurchaseOrder po left join dbo.PM_POLine pl on po.id=pl.PurchaseOrder left join ( select lineid as SrcDocLineID,sum(qty) as QtyC from( select rdl.SrcDocLineID as lineid, sum( ConfirmQty1) as qty from dbo.Kuka_VPT_RtGoodsDocLine rdl  where rdl.LineStatus <= 2 group by SrcDocLineID   union all  select asnl.SrcDocInfo_SrcDocLine_EntityID as lineid,Sum(asnl.ShipQtyTU) as qty from dbo.PM_ASN asn  left join  dbo.PM_ASNLine asnl on asn.id=asnl.ASN  where asnl.Status<=2   group by asnl.SrcDocInfo_SrcDocLine_EntityID   union all  select rl.SrcDoc_SrcDocLine_EntityID as lineid,Sum(rl.RcvQtyPU) as qty from dbo.PM_Receivement rcv  left join  dbo.PM_RcvLine rl on rcv.id=rl.Receivement and rl.KitParentLine=0  where rl.Status<=3  group by rl.SrcDoc_SrcDocLine_EntityID  )t group by lineid )#tempdata on #tempdata.SrcDocLineID=pl.id where po.id=@POID");
            listParam.Add(new SqlParameter("POID", param.data.PurchaseOrder));
            var dataTable = DbHelperSQL.QueryDataSet(sqlQuery.ToString(), listParam).Tables[0];
            List<POLineValidateInfo> listPOLine = ExtendMethod.ToDataList<POLineValidateInfo>(dataTable);
            if (listPOLine.Count == 0) {
                throw new Exception(string.Format("采购订单ID不存在{0}", param.data.PurchaseOrder));
            }
            UFIDAU9CustKukaMPSMPSSVPOModifyDTOData head = new UFIDAU9CustKukaMPSMPSSVPOModifyDTOData()
            {
                m_purchaseOrder = new UFIDAU9CustKukaMPSMPSSVIDCodeNameData()
                {
                    m_iD = param.data.PurchaseOrder
                },
                m_jsonStr = param.JsonObjToString()
            };
            List<UFIDAU9CustKukaMPSMPSSVPOShipLineDTOData> listPOModifyLine = new List<UFIDAU9CustKukaMPSMPSSVPOShipLineDTOData>();
            foreach (var poModifyLine in param.data.POModifyLines)
            {
                var item = listPOLine.Where(p => p.POLine == poModifyLine.POLine).FirstOrDefault();
                if (item == null) {
                    throw new Exception(string.Format("采购订单行ID不存在{0}", poModifyLine.POLine));
                }
                if (item.POLineStatus != 2)
                {
                    throw new Exception(string.Format("采购订单{0}行号{1}状态不是审核状态", item.DocNo, item.DocLineNo));
                }
                //可变数量验证
                if (poModifyLine.PurQtyPU > item.PurQtyPU - item.TotalRecievedQtyPU - item.TotalRtnDeductQtyPU - item.OnlineQty)
                {
                    throw new Exception(string.Format("变更数量{0}大于可变更数量{1}", poModifyLine.PurQtyPU, item.PurQtyPU - item.TotalRecievedQtyPU - item.TotalRtnDeductQtyPU - item.OnlineQty));
                }
                //转厂需要验证厂商价目表
                if (poModifyLine.ActionType == ActionType.TransFac) {
                    ValidatePPR(item.Supplier,item.SupplierCode,item.ItemID, item.ItemCode);
                }
                listPOModifyLine.Add(new UFIDAU9CustKukaMPSMPSSVPOShipLineDTOData()
                {
                    m_pOLine = poModifyLine.POLine,
                    m_changeType = Convert.ToInt16(poModifyLine.ActionType.Value),
                    m_qty = poModifyLine.PurQtyPU,
                    m_deliveryDate = poModifyLine.DeliveryDate,
                    m_supplier = new UFIDAU9CustKukaMPSMPSSVIDCodeNameData()
                    {
                        m_iD = poModifyLine.Supplier
                    },
                    m_pOModifyDTO = head
                });
            }
            head.m_pOLines = listPOModifyLine.ToArray();
            ThreadContext context = Common.CreateContextObj();
            UFIDAU9CustKukaMPSMPSSVICreatePOModifySvClient client = new UFIDAU9CustKukaMPSMPSSVICreatePOModifySvClient();
            UFIDAU9CustKukaMPSMPSSVPOModifyResultData result = client.Do(context, head, out UFSoft.UBF.Exceptions1.MessageBase[] outMessages);
            //string POModifyDocNo = "";
            //string Status = "";
            //SqlParameter out1 = new SqlParameter("POModifyDocNo", POModifyDocNo);
            //out1.Direction = System.Data.ParameterDirection.Output;
            //SqlParameter out2 = new SqlParameter("Status", Status);
            //out2.Direction = System.Data.ParameterDirection.Output;
            //DbHelperSQL.ExecuteDataSet("kuka_basedata.dbo.Insert_MPS_POModify", new SqlParameter[] {
            //    new SqlParameter("POModify",result.m_pOModify),
            //    new SqlParameter("POID",param.data.PurchaseOrder),
            //    new SqlParameter("PODocNo",listPOLine[0].DocNo),
            //     new SqlParameter("MPSParam",param.JsonObjToString()),
            //    out1,
            //    out2
            //});
            Result.data = 
            new POModifyResult
            {
                POModify = result.m_pOModify,
                POModifyDocNo = result.m_pOModifyDocNo,
                Status = result.m_status,
                PurchaseOrders = result.m_purchaseOrders.Select(t=>new PurchaseOrder() {
                    DocNo=t.m_docNo,
                    ID=t.m_iD,
                    Status=t.m_status
                }).ToList()
            };
            return Result;
        }

        private void ValidatePPR(long supplier, string supplierCode, long itemID, string itemCode)
        {
            List<System.Data.SqlClient.SqlParameter> param = new List<System.Data.SqlClient.SqlParameter>() {
                new System.Data.SqlClient.SqlParameter("itemID", itemID),
                new System.Data.SqlClient.SqlParameter("supplier", supplier)
            };
            var dataTablePPR = DbHelperSQL.Query("select pp.Supplier,ppl.ItemInfo_ItemCode,pp.Code as PPRCode, ppl.FromDate, ppl.ToDate, ppl.DocLineNo, ppl.Price, im.code as ItemCode, im2.code as BOMCode from PPR_PurPriceList pp inner join CBO_Supplier s on s.id = pp.supplier left join PPR_PurPriceLine ppl on ppl.PurPriceList = pp.id left join(select code, id from CBO_ItemMaster where id = @itemID)im on im.id = ppl.iteminfo_itemid left join(select im2.code as Code,im2.id as ID from CBO_BOMMaster bm left join CBO_BOMComponent bc on bc.BOMMaster = bm.id left join CBO_ItemMaster im on im.id = bm.itemmaster left join CBO_ItemMaster im2 on im2.id = bc.itemmaster where im.id = @itemID and bc.IsEffective = 1 and bc.EffectiveDate <= GETDATE() and bc.DisableDate >= GETDATE()) im2 on im2.ID = ppl.iteminfo_itemid where s.id = @supplier and(im.code is not null or im2.code is not null) and ppl.FromDate <= GETDATE() and ppl.ToDate >= GETDATE()", param);
            if (dataTablePPR.Rows.Count == 0)
            {
                throw new Exception($"供应商{supplierCode}料号{itemCode}没有维护厂商价目表或失效!");
            }
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
                    throw new Exception("变更类型不能为空");
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

        public RetModel<List<MPSPOModifyInfo>> GetPOModify(RecModel<ItemInfoQuery> param)
        {
            RetModel<List<MPSPOModifyInfo>> result = new RetModel<List<MPSPOModifyInfo>>();
            result.code = "0";
            result.message = "0";
            #region sql
            string sqlHead = " select * from MPS_POModify po where 1=1 {0} ";            
            string sqlCount = " select count(1) from MPS_POModify po where 1=1 {0} ";
            string sqlSOPage = " select  ROW_NUMBER() over(order by po.id)as rownum,* from MPS_POModify po where 1=1 {0}";

            #endregion

            #region 查询
            List<SqlParameter> listParam = new List<SqlParameter>();
            StringBuilder sqlSOPageS = new StringBuilder();
            string sqlParam = "";
            if (param.data != null)
            {

                if (param.data.startTime.HasValue)
                {
                    sqlParam += " and po.ModifiedOn>=@startTime";
                    listParam.Add(new SqlParameter("startTime", param.data.startTime));
                }
                if (param.data.endTime.HasValue)
                {
                    sqlParam += " and po.ModifiedOn<@endTime";
                    listParam.Add(new SqlParameter("endTime", param.data.endTime));
                }
                if (!string.IsNullOrEmpty(param.data.keyValue))
                {
                    sqlParam += " and po.POModifyDocNo=@PODocNo";
                    listParam.Add(new SqlParameter("PODocNo", param.data.keyValue));
                }
            }
            sqlSOPageS.Append("select ID into #TempA from (");
            sqlSOPageS.Append(string.Format(sqlSOPage, sqlParam));
            sqlSOPageS.Append(") t");

            sqlCount = string.Format(sqlCount, sqlParam);
            if (param.data != null)
            {
                if (param.data.pageSize != 0)
                {
                    sqlSOPageS.Append(" where rownum>@skip and rownum<=@Take ");
                    listParam.Add(new SqlParameter("skip", param.data.pageIndex * param.data.pageSize));
                    listParam.Add(new SqlParameter("Take", (param.data.pageIndex + 1) * param.data.pageSize));
                    sqlParam += " and po.id in (select ID from #TempA)";
                }
            }
            sqlHead = string.Format(sqlHead, sqlParam);
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.AppendLine(sqlSOPageS.ToString());
            sqlQuery.AppendLine(sqlHead);
            result.message = DbHelperSQL.QueryCountOnly(sqlCount.ToString(), listParam).ToString();
            var dataSet = DbHelperSQL.QueryDataSet(sqlQuery.ToString(), listParam);
            var dataHead = ExtendMethod.ToDataList<MPSPOModifyInfo>(dataSet.Tables[0]);
            result.data = dataHead;
            #endregion

            return result;
        }
    }
}
