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
   public  class POInfoForModify
    {
        public RetModel<List<POInfoModify>> GetPOInfo(RecModel<POInfoModifyQuery> param)
        {
            RetModel<List<POInfoModify>> result = new RetModel<List<POInfoModify>>();
            result.code = "0";
            result.message = "0";
            #region sql
          
            string sqlLine = "  select top 1000 po.docno as pocPurchaseOrderNo,po.id as pocPurchaseOrderId,pl.doclineno as pocPurchaseOrderLineNo,pl.id as pocPurchaseOrderLineId,im.code as pocMaterielNo,im.NameSegment1 as pocGoodCode,im.Name as pocMaterielName,(case when itemed.DescFlexField_PrivateDescSeg25 = '亲子包'    then '特殊产品' else tempCategory.SaleName end)as pocProductLine,po.Supplier_Code as pocSupplierCode,st.Name as pocSupplierName,im.SPECS as pocSpecs,pl.PurQtyPU as pocPurchaseQty,psl.DeliveryDate as pocDeliveryPeriod,pl.purqtypu - pl.TotalRecievedQtyPU -pl.TotalRtnDeductQtyPU - isnull(#tempdata.qtyc,0)+pl.TotalRtnFillQtyPU as pocChangeableQty from dbo.PM_PurchaseOrder po  left join dbo.CBO_Supplier_Trl st on st.id = po.Supplier_Supplier  left join dbo.Base_Organization o on o.id = po.org left join dbo.PM_POLine pl on pl.PurchaseOrder = po.id left join dbo.PM_POShipLine psl on psl.POLine = pl.id and psl.ItemInfo_ItemID = pl.ItemInfo_ItemID left join(select lineid as SrcDocLineID, sum(qty) as QtyC from( select rdl.SrcDocLineID as lineid, sum(ConfirmQty1) as qty from dbo.Kuka_VPT_RtGoodsDocLine rdl where rdl.LineStatus <= 2 group by SrcDocLineID union all select asnl.SrcDocInfo_SrcDocLine_EntityID as lineid, Sum(asnl.ShipQtyTU) as qty from dbo.PM_ASN asn  left join dbo.PM_ASNLine asnl on asn.id = asnl.ASN where asnl.Status <= 2 group by asnl.SrcDocInfo_SrcDocLine_EntityID  union all select rl.SrcDoc_SrcDocLine_EntityID as lineid, Sum(rl.RcvQtyPU) as qty from dbo.PM_Receivement rcv  left  join dbo.PM_RcvLine rl on rcv.id = rl.Receivement and rl.KitParentLine = 0 where rl.Status <= 3 group by rl.SrcDoc_SrcDocLine_EntityID )t group by lineid)#tempdata on #tempdata.SrcDocLineID=pl.id inner join dbo.CBO_ItemMaster im on im.id= pl.ItemInfo_ItemID     left join dbo.Kuka_BS_ItemEd itemed on itemed.item= im.id        left join (select ct.Name as SaleName, c.id from dbo.CBO_Category c    left join dbo.[CBO_Category_Trl] as ct on (c.[ID] = ct.[ID])) tempCategory on tempCategory.id=im.PurchaseCategory  where (pl.ItemInfo_ItemCode like '91.%' or pl.ItemInfo_ItemCode like '07.%')   and  psl.DeliveryDate>'2017-01-01' and pl.status=2 {0}  ";
            #endregion

            #region 查询
            List<SqlParameter> listParam = new List<SqlParameter>();
            string sqlParam = "";
            if (param.data != null)
            {

                if (!string.IsNullOrEmpty(param.data.pocPurchaseOrderNo))
                {
                    sqlParam += " and po.DocNo=@DocNo";
                    listParam.Add(new SqlParameter("DocNo", param.data.pocPurchaseOrderNo));
                }
                if (param.data.pocPurchaseOrderLineNo != 0)
                {
                    sqlParam += " and pl.DocLineNo=@DocLineNo";
                    listParam.Add(new SqlParameter("DocLineNo", param.data.pocPurchaseOrderLineNo));
                }
                if (!string.IsNullOrEmpty(param.data.pocMaterielNo))
                {
                    sqlParam += " and im.Code like '%'+@ItemCode+'%'";
                    listParam.Add(new SqlParameter("ItemCode", param.data.pocMaterielNo));
                }
                if (!string.IsNullOrEmpty(param.data.pocGoodCode))
                {
                    sqlParam += " and im.NameSegment1 like '%'+@NameSegment1+'%'";
                    listParam.Add(new SqlParameter("NameSegment1", param.data.pocGoodCode));
                }
                if (!string.IsNullOrEmpty(param.data.pocSupplierCode))
                {
                    sqlParam += " and po.Supplier_Code=@Supplier_Code";
                    listParam.Add(new SqlParameter("Supplier_Code", param.data.pocSupplierCode));
                }
            }
            sqlLine = string.Format(sqlLine, sqlParam);
                     
            var dataSet = DbHelperSQL.QueryDataSet(sqlLine, listParam);
            var dataHead = ExtendMethod.ToDataList<POInfoModify>(dataSet.Tables[0]);
            result.data = dataHead;
            #endregion

            return result;
        }

    }
}
