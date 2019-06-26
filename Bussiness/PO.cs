using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom;
using MPS.Bussiness.U9Service;
using MPS.Custom;
using MPS.Model;
using MPS.Model.API;
using UFIDA.U9.Cust.Kuka.MPS.MPSSV.Custom;
using UFSoft.UBF.Util.Context;
using www.ufida.org.EntityData;

namespace MPS.Bussiness
{
    public class PO
    {
        public RetModel<PODto> CreatePO(RecModel<CreatePODto> param)
        {
            CreatePODto createPODto = param.data;
            RetModel<PODto> Result = new RetModel<PODto>();
            Result.code = "0";
            Result.message = "0";
            #region 创建采购订单
            UFIDAU9CustKukaMPSMPSSVICreatePOSVClient Client = new UFIDAU9CustKukaMPSMPSSVICreatePOSVClient();
            www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVCreatePODTOData poDtoData = new www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVCreatePODTOData();
            poDtoData.m_supplier_Code = createPODto.Supplier_Code;
            //poDtoData.m_pOLines = new www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOLineDTOData[];
            //UFIDAU9CustKukaMPSMPSSVPOLineDTOData test = new UFIDAU9CustKukaMPSMPSSVPOLineDTOData();
           List<www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOLineDTOData> poLines=new List<UFIDAU9CustKukaMPSMPSSVPOLineDTOData>();
           
            foreach (var item in createPODto.POLines)
            {
                var dataTable = DbHelperSQL.Query("select ID,Code,Name from dbo.CBO_ItemMaster im where im.code=@Code", new List<System.Data.SqlClient.SqlParameter>() { new System.Data.SqlClient.SqlParameter("Code", item.ItemCode) });
                if (dataTable.Rows.Count == 0)
                {
                    throw new Exception($"料号{item.ItemCode}不存在!");
                }
                www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOLineDTOData poLine = new www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOLineDTOData()
                {
                    m_deliveryDate = item.DeliveryDate,
                    m_orderQty = item.OrderQty,
                    m_itemCode = item.ItemCode,
                    m_remark = item.Remark,
                    m_srcDocNo = item.SrcDocNo,
                    m_createPODTO = poDtoData
                };
                poLines.Add(poLine);                
            }
            poDtoData.m_pOLines = poLines.ToArray();
            www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVCreatePODTOData[] pOList = new www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVCreatePODTOData[] { poDtoData };

            ThreadContext context = Common.CreateContextObj();
            string sqlSupplier = "select o.id,o.code from dbo.CBO_Supplier s left join dbo.Base_Organization o on o.id = s.org where s.code = @Code";
            List<SqlParameter> listParam = new List<SqlParameter>();
            listParam.Add(new SqlParameter("Code", poDtoData.m_supplier_Code));
            var dataTableSupplier = DbHelperSQL.Query(sqlSupplier, listParam);
            if (dataTableSupplier.Rows.Count == 0)
            {
                throw new Exception("没有对应编码的供应商！");
            }
            else {
                context.nameValueHas["OrgID"] = Convert.ToInt64(dataTableSupplier.Rows[0]["id"]);
            }

            www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPODataData result2 = Client.Do(context, poDtoData, out UFSoft.UBF.Exceptions1.MessageBase[] outMessages);
            //Client.Do(new DoResponse());
            #endregion
            Result.data = new PODto()
            {
                DeliveryDate = result2.m_deliverDate,
                PODocNo = result2.m_docNo,
                Supplier_Code = result2.m_supplier
            };
            return Result;
        }

        public RetModel<List<POInfo>> GetPOInfo(RecModel<ItemInfoQuery> param)
        {
            RetModel<List<POInfo>> result = new RetModel<List<POInfo>>();
            result.code = "0";
            result.message = "0";
            #region sql
            string sqlHead = " select po.ID, po.DocNo, po.Supplier_Supplier as Supplier, po.Supplier_Code as SupplierCode, st.Name as SupplierName, po.BusinessDate, po.CreatedBy, po.ModifiedOn  from dbo.PM_PurchaseOrder po  left join dbo.CBO_Supplier_Trl st on st.id=po.Supplier_Supplier  left join dbo.Base_Organization o on o.id=po.org left join dbo.PM_POLine pl on pl.PurchaseOrder=po.id where (pl.ItemInfo_ItemCode like '91.A%' or pl.ItemInfo_ItemCode like '91.K%' 	 or pl.ItemInfo_ItemCode like '91.W%' or pl.ItemInfo_ItemCode like '91.ZZ%' or pl.ItemInfo_ItemCode like '07.%') 	 and pl.ItemInfo_ItemCode not like '07.01%' and po.Status=2 and o.code='704'   {0} 	 group by po.ID, po.DocNo, po.Supplier_Supplier, po.Supplier_Code, st.Name, po.BusinessDate, po.CreatedBy, po.ModifiedOn ";
            string sqlLine = "  select po.ID as PurchaseOrder, 	 pl.DocLineNo ,pl.itemInfo_itemCode as ItemCode ,pl.itemInfo_itemName as ItemName ,(case when  itemed.DescFlexField_PrivateDescSeg25='亲子包'  	then '特殊产品' else tempCategory.SaleName  end)as Dept ,pl.PurQtyPU as PurQtyPU ,pl.TotalRecievedQtyPU as TotalRecievedQtyPU ,pl.TotalRtnDeductQtyPU  as TotalRtnDeductQtyPU ,pl.PurQtyPU-psl.RcvQtyTU-psl.TotalRtnDeductQtyCU as LastQty ,0 as OverDateQty ,null as ChangeDeliveryDate ,pl.PurQtyPU as OriginQty ,(case when pl.DescFlexSegments_PrivateDescSeg20='' then psl.DeliveryDate else pl.DescFlexSegments_PrivateDescSeg20 end) as OriginDeliveryDate ,(case when pl.DescFlexSegments_PrivateDescSeg20='' then psl.DeliveryDate else pl.DescFlexSegments_PrivateDescSeg20 end)  as DeliveryDate  from dbo.PM_PurchaseOrder po  left join dbo.CBO_Supplier_Trl st on st.id=po.Supplier_Supplier  left join dbo.Base_Organization o on o.id=po.org left join dbo.PM_POLine pl on pl.PurchaseOrder=po.id left join dbo.PM_POShipLine psl on psl.POLine=pl.id and psl.ItemInfo_ItemID=pl.ItemInfo_ItemID inner join dbo.CBO_ItemMaster im on im.id= pl.ItemInfo_ItemID     left join dbo.Kuka_BS_ItemEd itemed on itemed.item= im.id        left join (select ct.Name as SaleName, c.id from dbo.CBO_Category c    left join dbo.[CBO_Category_Trl] as ct on (c.[ID] = ct.[ID])) tempCategory on tempCategory.id=im.PurchaseCategory  where (pl.ItemInfo_ItemCode like '91.A%' or pl.ItemInfo_ItemCode like '91.K%' 	 or pl.ItemInfo_ItemCode like '91.W%' or pl.ItemInfo_ItemCode like '91.ZZ%' or pl.ItemInfo_ItemCode like '07.%') 	 and pl.ItemInfo_ItemCode not like '07.01%' and po.Status=2 and o.code='704'  {0}  ";
            string sqlCount = " select count(1) from(select po.id  from dbo.PM_PurchaseOrder po left join dbo.Base_Organization o on o.id=po.org left join dbo.PM_POLine pl on pl.PurchaseOrder=po.id where (pl.ItemInfo_ItemCode like '91.A%' or pl.ItemInfo_ItemCode like '91.K%' 	 or pl.ItemInfo_ItemCode like '91.W%' or pl.ItemInfo_ItemCode like '91.ZZ%' or pl.ItemInfo_ItemCode like '07.%') 	 and pl.ItemInfo_ItemCode not like '07.01%' and po.Status=2 and o.code='704' {0} group by po.id) t  ";
            string sqlSOPage = " select  ROW_NUMBER() over(order by t.id)as rownum,* from ( 	 select po.ID  from dbo.PM_PurchaseOrder po  left join dbo.CBO_Supplier_Trl st on st.id=po.Supplier_Supplier  left join dbo.Base_Organization o on o.id=po.org left join dbo.PM_POLine pl on pl.PurchaseOrder=po.id where (pl.ItemInfo_ItemCode like '91.A%' or pl.ItemInfo_ItemCode like '91.K%' 	 or pl.ItemInfo_ItemCode like '91.W%' or pl.ItemInfo_ItemCode like '91.ZZ%' or pl.ItemInfo_ItemCode like '07.%') 	 and pl.ItemInfo_ItemCode not like '07.01%' and po.Status=2 and o.code='704' {0} group by po.ID) t  ";

            #endregion

            #region 查询
            List<SqlParameter> listParam = new List<SqlParameter>();
            //StringBuilder sqlHeadS = new StringBuilder(sqlHead);
            //StringBuilder sqlLineS = new StringBuilder(sqlLine);
            StringBuilder sqlSOPageS = new StringBuilder();
            //StringBuilder sqlCountS = new StringBuilder(sqlCount);
            //StringBuilder sqlExcute = new StringBuilder(sqlSOPage);
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
            sqlLine = string.Format(sqlLine, sqlParam);
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.AppendLine(sqlSOPageS.ToString());
            sqlQuery.AppendLine(sqlHead);
            sqlQuery.AppendLine(sqlLine);
            result.message = DbHelperSQL.QueryCountOnly(sqlCount.ToString(), listParam).ToString();
            var dataSet = DbHelperSQL.QueryDataSet(sqlQuery.ToString(), listParam);
            var dataHead = ExtendMethod.ToDataList<POInfo>(dataSet.Tables[0]);
            var dataLine = ExtendMethod.ToDataList<POLineInfo>(dataSet.Tables[1]);
            Dictionary<long, List<POLineInfo>> map = new Dictionary<long, List<POLineInfo>>();
            foreach (POLineInfo line in dataLine)
            {
                if (map.ContainsKey(line.PurchaseOrder))
                {
                    map[line.PurchaseOrder].Add(line);
                }
                else
                {
                    map.Add(line.PurchaseOrder, new List<POLineInfo>() { line });
                }
            }
            foreach (POInfo head in dataHead)
            {
                if (map.ContainsKey(head.ID))
                {
                    head.POLines = map[head.ID];
                }
                else
                {
                    head.POLines = new List<POLineInfo>();
                }
            }
            result.data = dataHead;
            #endregion

            return result;
        }

        public RetModel<List<JCPOInfo>> GetJCPOInfo(RecModel<ItemInfoQuery> param)
        {
            
            RetModel<List<JCPOInfo>> result = new RetModel<List<JCPOInfo>>();
            result.code = "0";
            result.message = "0";

            #region sql
            string sqlHead = " select po.ID ,po.DocNo ,po.Supplier_Supplier as Supplier ,po.Supplier_Code as SupplierCode ,st.Name as SupplierName   from dbo.PM_PurchaseOrder po     left join dbo.CBO_Supplier_Trl st on st.id=po.Supplier_Supplier     left join dbo.Base_Organization o     on o.id=po.org left join dbo.PM_POLine pl on pl.PurchaseOrder=po.id     left join dbo.PM_POShipLine psl on psl.POLine=pl.id and psl.ItemInfo_ItemID=pl.ItemInfo_ItemID     inner join dbo.CBO_ItemMaster im on im.id= pl.ItemInfo_ItemID left join dbo.Kuka_BS_ItemEd itemed on itemed.item= im.id left join (select ct.Name as SaleName, c.id from dbo.CBO_Category c    left join dbo.[CBO_Category_Trl] as ct on (c.[ID] = ct.[ID])) tempCategory on tempCategory.id=im.PurchaseCategory   	where (pl.ItemInfo_ItemCode like '91.A%' or pl.ItemInfo_ItemCode like '91.K%' 	 or pl.ItemInfo_ItemCode like '91.W%' or pl.ItemInfo_ItemCode like '91.ZZ%' or pl.ItemInfo_ItemCode like '07.%') 	 and pl.ItemInfo_ItemCode not like '07.01%' and po.Status=2 and o.code='704' and pl.Status=2 {0}  group by  po.ID ,po.DocNo ,po.Supplier_Supplier ,po.Supplier_Code ,st.Name ";
            string sqlLine = "select po.ID as PurchaseOrder ,pl.id as ID, pl.DocLineNo ,pl.itemInfo_itemCode as ItemCode ,pl.itemInfo_itemName as ItemName  ,(case when  itemed.DescFlexField_PrivateDescSeg25='亲子包'  	then '特殊产品' else tempCategory.SaleName  end)as Dept  ,psl.DeliveryDate  as DeliveryDate   ,pl.PurQtyPU  ,pl.PurQtyPU-psl.RcvQtyTU-psl.TotalRtnDeductQtyCU as LastQty ,DocLineNo ,(case pl.status when 0 then '开立' when 1 then '审核中' when 2 then '已审核' when 3 then '自然关闭' when 4  then '短缺关闭' when 5 then '超额关闭' else '' end) as Status ,pl.DocLineNo as ItemCode ,pl.itemInfo_itemName as ItemName ,(case when  itemed.DescFlexField_PrivateDescSeg25='亲子包'  	then '特殊产品' else tempCategory.SaleName  end)as Dept ,psl.DeliveryDate as DeliveryDate ,#tempInv.HZCurrentMonthInv as HZCurrentMonthInv ,#tempInv.HBCurrentMonthInv as HBCurrentMonthInv ,#tempInv.TotalInv as TotalInv ,pl.PurQtyPU as OrderQty ,pl.PurQtyPU-psl.RcvQtyTU-psl.TotalRtnDeductQtyCU as LastQty ,-1 as UsageQty ,0as OrderUsageQty ,#tempASN.HZOnWay as HZOnWay ,#tempASN.HBOnWay as HBOnWay ,#tempNoExpress.HBNoExpress as HBNoExpress ,#tempNoExpress.HZNoExpress as HZNoExpress ,#tempInv.HZTotalInv as HZTotalInv ,#tempInv.HBTotalInv as HBTotalInv ,0as SONoExpress ,0as ComInv   from dbo.PM_PurchaseOrder po     left join dbo.CBO_Supplier_Trl st on st.id=po.Supplier_Supplier     left join dbo.Base_Organization o     on o.id=po.org left join dbo.PM_POLine pl on pl.PurchaseOrder=po.id     left join dbo.PM_POShipLine psl on psl.POLine=pl.id and psl.ItemInfo_ItemID=pl.ItemInfo_ItemID     inner join dbo.CBO_ItemMaster im on im.id= pl.ItemInfo_ItemID    	left join dbo.Kuka_BS_ItemEd itemed on itemed.item= im.id         	left join (select ct.Name as SaleName, c.id from dbo.CBO_Category c    left join dbo.[CBO_Category_Trl] as ct on (c.[ID] = ct.[ID])) tempCategory on tempCategory.id=im.PurchaseCategory   	left join #tempInv on #tempInv.id=pl.id 	left join #tempASN on #tempASN.id=pl.id 	left join #tempNoExpress on #tempNoExpress.采购订单号=po.docno and #tempNoExpress.采购订单行号=pl.doclineno 	where (pl.ItemInfo_ItemCode like '91.A%' or pl.ItemInfo_ItemCode like '91.K%' 	 or pl.ItemInfo_ItemCode like '91.W%' or pl.ItemInfo_ItemCode like '91.ZZ%' or pl.ItemInfo_ItemCode like '07.%') 	 and pl.ItemInfo_ItemCode not like '07.01%' and po.Status=2 and o.code='704'  and pl.Status=2 {0}  ";
            string sqlCount = " select count(1) from(select po.ID  from dbo.PM_PurchaseOrder po     left join dbo.CBO_Supplier_Trl st on st.id=po.Supplier_Supplier     left join dbo.Base_Organization o on o.id=po.org  left join dbo.PM_POLine pl on pl.PurchaseOrder=po.id left join dbo.PM_POShipLine psl on psl.POLine=pl.id and psl.ItemInfo_ItemID=pl.ItemInfo_ItemID     inner join dbo.CBO_ItemMaster im on im.id= pl.ItemInfo_ItemID  left join dbo.Kuka_BS_ItemEd itemed on itemed.item= im.id left join (select ct.Name as SaleName, c.id from dbo.CBO_Category c    left join dbo.[CBO_Category_Trl] as ct on (c.[ID] = ct.[ID])) tempCategory on tempCategory.id=im.PurchaseCategory   	where (pl.ItemInfo_ItemCode like '91.A%' or pl.ItemInfo_ItemCode like '91.K%' 	 or pl.ItemInfo_ItemCode like '91.W%' or pl.ItemInfo_ItemCode like '91.ZZ%' or pl.ItemInfo_ItemCode like '07.%') 	 and pl.ItemInfo_ItemCode not like '07.01%' and po.Status=2 and o.code='704'  and pl.Status=2 {0} group by  po.ID ) t  ";
            string sqlSOPage = " select  ROW_NUMBER() over(order by t.id)as rownum,* from (select po.ID  from dbo.PM_PurchaseOrder po left join dbo.CBO_Supplier_Trl st on st.id=po.Supplier_Supplier     left join dbo.Base_Organization o on o.id=po.org  left join dbo.PM_POLine pl on pl.PurchaseOrder=po.id left join dbo.PM_POShipLine psl on psl.POLine=pl.id and psl.ItemInfo_ItemID=pl.ItemInfo_ItemID inner join dbo.CBO_ItemMaster im on im.id= pl.ItemInfo_ItemID  left join dbo.Kuka_BS_ItemEd itemed on itemed.item= im.id left join (select ct.Name as SaleName, c.id from dbo.CBO_Category c    left join dbo.[CBO_Category_Trl] as ct on (c.[ID] = ct.[ID])) tempCategory on tempCategory.id=im.PurchaseCategory where (pl.ItemInfo_ItemCode like '91.A%' or pl.ItemInfo_ItemCode like '91.K%' 	 or pl.ItemInfo_ItemCode like '91.W%' or pl.ItemInfo_ItemCode like '91.ZZ%' or pl.ItemInfo_ItemCode like '07.%') 	 and pl.ItemInfo_ItemCode not like '07.01%' and po.Status=2 and o.code='704' and pl.Status=2 {0} group by  po.ID ) t  ";

            #endregion

            #region 查询
            List<SqlParameter> listParam = new List<SqlParameter>();
            //StringBuilder sqlHeadS = new StringBuilder(sqlHead);
            //StringBuilder sqlLineS = new StringBuilder(sqlLine);
            StringBuilder sqlSOPageS = new StringBuilder();
            //StringBuilder sqlCountS = new StringBuilder(sqlCount);
            //StringBuilder sqlExcute = new StringBuilder(sqlSOPage);
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
            sqlLine = string.Format(sqlLine, sqlParam);

            #region 采购行其他信息（杭州当月入库、河北当月入库、累计入库、杭州在途、河北在途、河北已排未发、杭州已排未发、该行订单累计杭州入库、该行订单累计河北入库）


            string strInv = $" declare @year int,@month int; set @year=year(GETDATE()); set @month=month(GETDATE()); select pl.id ,sum(rcvl.RcvQtyPU) as TotalInv ,sum(case when wh.DescFlexField_PubDescSeg2='001' then rcvl.RcvQtyPU else 0 end) as HZTotalInv ,sum(case when wh.DescFlexField_PubDescSeg2='002' then rcvl.RcvQtyPU else 0 end) as HBTotalInv ,sum(case when year(rcv.ApprovedOn)=@year and month(rcv.ApprovedOn)=@month then rcvl.RcvQtyPU else 0 end) as TotalCurrentMonthInv ,sum(case when year(rcv.ApprovedOn)=@year and month(rcv.ApprovedOn)=@month and wh.DescFlexField_PubDescSeg2='001' then rcvl.RcvQtyPU else 0 end) as HZCurrentMonthInv ,sum(case when year(rcv.ApprovedOn)=@year and month(rcv.ApprovedOn)=@month and wh.DescFlexField_PubDescSeg2='002' then rcvl.RcvQtyPU else 0 end) as HBCurrentMonthInv into #tempInv from dbo.PM_Receivement rcv left join dbo.PM_RcvLine  rcvl on rcv.id =  rcvl.Receivement left join dbo.Base_Organization_Trl ot on ot.id  = rcv.Org Inner join dbo.pm_poline pl on pl.id =  rcvl.SrcDoc_SrcDocLine_EntityID left join dbo.PM_PurchaseOrder po on po.id = pl.PurchaseOrder left join dbo.cbo_itemmaster im on im.id =  rcvl.ItemInfo_ItemID left join dbo.Base_UOM_Trl uomt on uomt.id =  rcvl.StoreUOM  left join dbo.CBO_Supplier_trl st on st.id = rcv.Supplier_Supplier left join dbo.PM_POShipLine psl on psl.poline = pl.id left join dbo.cbo_wh_trl wht on wht.id =  rcvl.wh left join dbo.cbo_wh wh on wh.id =  rcvl.wh where ot.name in('顾家家居(宁波)有限公司','杭州顾家定制家居有限公司','宁波梅山保税港区顾家寝具有限公司','宁波名尚智能家居有限公司') and (rcvl.ItemInfo_ItemCode like '91.A%' or rcvl.ItemInfo_ItemCode like '91.K%' 	 or rcvl.ItemInfo_ItemCode like '91.W%' or rcvl.ItemInfo_ItemCode like '91.ZZ%' or rcvl.ItemInfo_ItemCode like '07.%') 	 and rcvl.ItemInfo_ItemCode not like '07.01%' {sqlParam} group by pl.id";
            string strASN = $" SELECT  pl.id ,Sum(asnl.ShipQtyTU) as TotalOnWay ,Sum(case when dvt.Name like '%杭州%' then asnl.ShipQtyTU else 0 end) as HZOnWay ,Sum(case when dvt.Name like '%河北%' then asnl.ShipQtyTU else 0 end) as HBOnWay into #tempASN FROM dbo.PM_ASN AS asn  LEFT JOIN  dbo.PM_ASNLine AS asnl ON asn.ID = asnl.ASN  LEFT JOIN dbo.CBO_Supplier_Trl AS s ON s.ID = asn.Supplier_Supplier  LEFT JOIN dbo.Base_ValueSetDef AS vsd ON vsd.Code = 'VP_KukaSendAddress'  LEFT JOIN dbo.Base_DefineValue AS dv ON dv.Code = asn.DescFlexField_PrivateDescSeg3 AND dv.ValueSetDef = vsd.ID  LEFT JOIN dbo.Base_DefineValue_Trl AS dvt ON dv.ID = dvt.ID inner JOIN dbo.PM_POLine AS pl ON pl.ID = asnl.SrcDocInfo_SrcDocLine_EntityID  LEFT JOIN dbo.PM_PurchaseOrder AS po ON po.ID = pl.PurchaseOrder WHERE   (asnl.Status = 2) and asnl.TotalRcvQtyTU =0 {sqlParam} group by pl.id";
            string strNoExpress = $"select rt.采购订单号,rt.采购订单行号 ,Sum(rt.回货计划数量) as TotalNoExpress ,Sum(case when 送货地址 like '%杭州%' then rt.回货计划数量 else 0 end) as HZNoExpress ,Sum(case when 送货地址 like '%河北%' then rt.回货计划数量 else 0 end) as HBNoExpress  into #tempNoExpress from [kuka_basedata].[dbo].[v_RtGoods] rt left join dbo.PM_PurchaseOrder po on  po.DocNo= rt.采购订单号 where rt.回货单状态='已审状态' and ASN单号 is null {sqlParam} group by rt.采购订单号,rt.采购订单行号 ";
            #endregion
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.AppendLine(sqlSOPageS.ToString());

            sqlQuery.AppendLine(strInv);
            sqlQuery.AppendLine(strASN);
            sqlQuery.AppendLine(strNoExpress);
           
            sqlQuery.AppendLine(sqlHead);
            sqlQuery.AppendLine(sqlLine);
            result.message = DbHelperSQL.QueryCountOnly(sqlCount.ToString(), listParam).ToString();
            var dataSet = DbHelperSQL.QueryDataSet(sqlQuery.ToString(), listParam);
            var dataHead = ExtendMethod.ToDataList<JCPOInfo>(dataSet.Tables[0]);
            var dataLine = ExtendMethod.ToDataList<JCPOLineInfo>(dataSet.Tables[1]);
            Dictionary<long, List<JCPOLineInfo>> map = new Dictionary<long, List<JCPOLineInfo>>();
            foreach (JCPOLineInfo line in dataLine)
            {
                if (map.ContainsKey(line.PurchaseOrder))
                {
                    map[line.PurchaseOrder].Add(line);
                }
                else
                {
                    map.Add(line.PurchaseOrder, new List<JCPOLineInfo>() { line });
                }
            }
            foreach (JCPOInfo head in dataHead)
            {
                if (map.ContainsKey(head.ID))
                {
                    head.POLines = map[head.ID];
                }
                else
                {
                    head.POLines = new List<JCPOLineInfo>();
                }
            }
            result.data = dataHead;
            #endregion

            return result;
        }

        public void test() {
            #region 创建采购订单

            //UFIDAU9ISVPOICreatePOSRVClient Client = new UFIDAU9ISVPOICreatePOSRVClient();
            //List<www.ufida.org.EntityData.UFIDAU9PMDTOsOBAPurchaseOrderDTOData> poListDtoData = new List<www.ufida.org.EntityData.UFIDAU9PMDTOsOBAPurchaseOrderDTOData>();

            //#region PO
            //UFIDAU9PMDTOsOBAPurchaseOrderDTOData poDtoData = new UFIDAU9PMDTOsOBAPurchaseOrderDTOData();
            //poListDtoData.Add(poDtoData);
            //SupplierInfoData supplier = EntitiesFinderHelper.FinderSupplier(createPODto.Supplier_Code);
            //if (supplier == null)
            //{
            //    throw new Exception($"没有找到供应商{createPODto.Supplier_Code}");
            //}
            //poDtoData.m_supplier = new UFIDAU9CBOSCMSupplierSupplierMISCInfoData()
            //{
            //    m_code = createPODto.Supplier_Code
            //};

            //poDtoData.m_documentType = new UFIDAU9BaseDTOsIDCodeNameDTOData
            //{
            //    m_code = "PO23"
            //};
            //OrganizationInfoData org = EntitiesFinderHelper.FinderOrganization("704"); //EntitiesFinderHelper.FinderOrganization("704");
            //poDtoData.m_accountOrg = new UFIDAU9BaseDTOsIDCodeNameDTOData
            //{
            //    m_iD = org.ID
            //};

            //poDtoData.m_createdOn = DateTime.Now;
            //poDtoData.m_modifiedOn = DateTime.Now;
            //List<UFIDAU9PMDTOsOBAPOLineDTOData> oPOLineDataList = new List<UFIDAU9PMDTOsOBAPOLineDTOData>();
            //int lineNo = 1;
            //DateTime maxDeliveryDate = DateTime.MinValue;
            //foreach (var item in createPODto.POLines)
            //{
            //    UFIDAU9PMDTOsOBAPOLineDTOData oPOLineData = new UFIDAU9PMDTOsOBAPOLineDTOData();
            //    oPOLineDataList.Add(oPOLineData);
            //    oPOLineData.m_docLineNo = (lineNo++) * 10;//行号
            //    oPOLineData.m_itemInfo = new UFIDAU9CBOSCMItemItemInfoData()
            //    {
            //        m_itemCode = item.ItemCode
            //    };
            //    oPOLineData.m_createdOn = DateTime.Now;
            //    oPOLineData.m_modifiedOn = DateTime.Now;

            //    ItemMasterInfoData itemMaster = EntitiesFinderHelper.FinderItemMaster(item.ItemCode);
            //    if (itemMaster == null)
            //    {
            //        throw new Exception($"料号{item.ItemCode}不存在！");
            //    }
            //    oPOLineData.m_tradeUOM = new UFIDAU9BaseDTOsIDCodeNameDTOData
            //    {
            //        m_iD = itemMaster.PurchaseUOM
            //    };//采购单位

            //    List<UFIDAU9PMDTOsOBAPOShipLineDTOData> listPoShipLines = new List<UFIDAU9PMDTOsOBAPOShipLineDTOData>();
            //    oPOLineData.m_purchaseOrder = poDtoData;
            //    oPOLineData.m_pOShiplines = listPoShipLines.ToArray();

            //    //modify By XCH  2016-10-17
            //    BOMMasterInfoData BOMMaster = EntitiesFinderHelper.FinderBOMMaster(item.ItemCode);// BOMMaster.Finder.Find("ItemMaster.Code=@Code", new UFSoft.UBF.PL.OqlParam[] { new UFSoft.UBF.PL.OqlParam("Code", item.ItemCode) });


            //    if (BOMMaster != null)
            //    {
            //        oPOLineData.m_bom = BOMMaster.ID;
            //        oPOLineData.m_reqQtyTU = item.OrderQty;//需求数量1
            //        oPOLineData.m_purQtyTU = item.OrderQty;
            //    }
            //    else
            //    {
            //        oPOLineData.m_reqQtyTU = item.OrderQty;//需求数量1
            //    }
            //    oPOLineData.m_bOMOwner = new UFIDAU9BaseDTOsIDCodeNameDTOData()
            //    {
            //        m_iD = itemMaster.Org
            //    };
            //    //oPOLineData.BOMOwner.ID = itemMaster.Org.Key.ID;//BOM对应的组织 orgId;

            //    oPOLineData.m_configResult = new UFSoft.UBF.Business.BusinessEntity.EntityKey()
            //    {
            //        ID = itemMaster.ID
            //    };
            //    //oPOLineData.ConfigResult.ID = itemMaster.ID;

            //    //创建人，创建时间
            //    oPOLineData.m_createdOn = DateTime.Now;
            //    oPOLineData.m_modifiedOn = DateTime.Now;
            //    oPOLineData.RcvOrg = org.ID;
            //    oPOLineData.m_rcvOrgCode = org.Code;


            //    List<UFIDAU9PMDTOsOBAPOShipLineDTOData> oPOShipLineList = new List<UFIDAU9PMDTOsOBAPOShipLineDTOData>();
            //    oPOLineData.m_pOShiplines = oPOShipLineList.ToArray();
            //    //计划行（主行）
            //    UFIDAU9PMDTOsOBAPOShipLineDTOData oPOShipLine = new UFIDAU9PMDTOsOBAPOShipLineDTOData();
            //    oPOShipLineList.Add(oPOShipLine);
            //    oPOLineData.m_pOShiplines = oPOShipLineList.ToArray();

            //    oPOShipLine.m_subLineNo = (lineNo++) * 10;
            //    oPOShipLine.m_parentLineNo = 0;
            //    oPOShipLine.m_rcvShipBy = 2;//收发货依据
            //    //oPOShipLine.m_demondCode = -1;//需求分类
            //    oPOShipLine.m_wh = new UFIDAU9BaseDTOsIDCodeNameDTOData()
            //    {
            //        m_code = "WH1"
            //    };
            //    UFIDAU9BaseFlexFieldDescFlexFieldDescFlexSegmentsData descFlexSegments = new UFIDAU9BaseFlexFieldDescFlexFieldDescFlexSegmentsData();
            //    if (item.DeliveryDate != null)
            //    {
            //        oPOShipLine.m_preMaturityDate = item.DeliveryDate; ;//预计到货日期
            //        oPOShipLine.m_planArriveDate = item.DeliveryDate;//计划到货日期
            //        oPOShipLine.m_needPODate = item.DeliveryDate;//应下订单日 
            //        oPOShipLine.m_deliveryDate = item.DeliveryDate;//要求交货日期
            //        if (maxDeliveryDate < item.DeliveryDate)
            //        {
            //            maxDeliveryDate = item.DeliveryDate;
            //        }
            //        descFlexSegments.m_privateDescSeg20 = item.DeliveryDate.ToString("yyyy-MM-dd HH:mm:ss");
            //    }
            //    if (!string.IsNullOrEmpty(item.Remark))
            //    {
            //        descFlexSegments.m_privateDescSeg19 = item.Remark;
            //    }
            //    if (!string.IsNullOrEmpty(item.SrcDocNo))
            //    {
            //        oPOShipLine.m_srcDocInfo = new UFIDAU9CBOSCMPropertyTypesSrcDocInfoData
            //        {
            //            m_srcDocNo = item.SrcDocNo
            //        };
            //    }
            //    oPOLineData.m_descFlexSegments = descFlexSegments;

            //    oPOShipLine.m_itemInfo = new UFIDAU9CBOSCMItemItemInfoData()
            //    {
            //        m_itemCode = item.ItemCode
            //    };

            //    //oPOShipLine.ItemInfo.ItemCode = item.ItemCode;//料号
            //    oPOShipLine.sysState = UFSoft.UBF.PL.Engine.ObjectState.Inserted;
            //    //oPOShipLine.ReqQtyRU = 10;
            //    oPOShipLine.m_reqQtyTU = item.OrderQty;

            //    //创建人，创建时间
            //    oPOShipLine.m_createdOn = DateTime.Now;
            //    oPOShipLine.m_modifiedOn = DateTime.Now;
            //    oPOShipLineList.Add(oPOShipLine);

            //}
            //#endregion

            //poDtoData.m_pOLines = oPOLineDataList.ToArray();

            //ThreadContext context = Common.CreateContextObj();
            //UFIDAU9PMDTOsOBAPurchaseOrderDTOData[] poArrayDtoData = poListDtoData.ToArray();

            //www.ufida.org.EntityData.UFIDAU9PMPOPurchaseOrderData[] result2 = Client.Do(context, poArrayDtoData, out UFSoft.UBF.Exceptions1.MessageBase[] outMessages);

            #endregion

        }

        
    }
}
