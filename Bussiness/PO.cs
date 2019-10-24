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
            List<www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOLineDTOData> poLines = new List<UFIDAU9CustKukaMPSMPSSVPOLineDTOData>();
            List<CreatePOLineDto> listUnValidate = new List<CreatePOLineDto>();
            foreach (var item in createPODto.POLines)
            {
                #region 料品检查               
                var dataTable = DbHelperSQL.Query("select ID,Code,Name from dbo.CBO_ItemMaster im where im.code=@Code and im.Effective_IsEffective=1 and im.Effective_EffectiveDate<=GETDATE() and im.Effective_DisableDate>=GETDATE()", new List<System.Data.SqlClient.SqlParameter>() { new System.Data.SqlClient.SqlParameter("Code", item.ItemCode) });
                if (dataTable.Rows.Count == 0)
                {
                    throw new Exception($"料号{item.ItemCode}不存在或失效!");
                    //item.ErrorMsg = $"料号{item.ItemCode}不存在或失效!";
                    //listUnValidate.Add(item);
                }
                #endregion

                #region 厂商价目表检查

                var dataTablePPR = DbHelperSQL.Query("select pp.Supplier,ppl.ItemInfo_ItemCode,pp.Code as PPRCode, ppl.FromDate, ppl.ToDate, ppl.DocLineNo, ppl.Price, im.code as ItemCode, im2.code as BOMCode from PPR_PurPriceList pp inner join CBO_Supplier s on s.id = pp.supplier left join PPR_PurPriceLine ppl on ppl.PurPriceList = pp.id left join(select code, id from CBO_ItemMaster where code = @ItemCode)im on im.id = ppl.iteminfo_itemid left join(select im2.code as Code,im2.id as ID from CBO_BOMMaster bm left join CBO_BOMComponent bc on bc.BOMMaster = bm.id left join CBO_ItemMaster im on im.id = bm.itemmaster left join CBO_ItemMaster im2 on im2.id = bc.itemmaster where im.code = @ItemCode and bc.IsEffective = 1 and bc.EffectiveDate <= GETDATE() and bc.DisableDate >= GETDATE()) im2 on im2.ID = ppl.iteminfo_itemid where s.code = @SupplierCode and(im.code is not null or im2.code is not null) and ppl.FromDate <= GETDATE() and ppl.ToDate >= GETDATE()", new List<System.Data.SqlClient.SqlParameter>() { new System.Data.SqlClient.SqlParameter("ItemCode", item.ItemCode), new System.Data.SqlClient.SqlParameter("SupplierCode", poDtoData.m_supplier_Code) });
                if (dataTablePPR.Rows.Count == 0)
                {
                    throw new Exception($"料号{item.ItemCode}没有维护厂商价目表或失效!");
                    //item.ErrorMsg = $"供应商{poDtoData.m_supplier_Code}和料号{item.ItemCode}没有维护厂商价目表或失效!";
                    //listUnValidate.Add(item);
                }
                #endregion

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
            string sqlSupplier = "select o.id,o.code from dbo.CBO_Supplier s left join dbo.Base_Organization o on o.id = s.org where s.code = @Code and s.Effective_IsEffective=1 and s.Effective_EffectiveDate<=GETDATE() and s.Effective_DisableDate>=GETDATE()";
            List<SqlParameter> listParam = new List<SqlParameter>();
            listParam.Add(new SqlParameter("Code", poDtoData.m_supplier_Code));
            var dataTableSupplier = DbHelperSQL.Query(sqlSupplier, listParam);
            if (dataTableSupplier.Rows.Count == 0)
            {
                throw new Exception("没有对应编码的供应商或失效！");
            }
            else
            {
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
        public RetModel<object> CreatePOV2(RecModel<CreatePODto> param)
        {
            CreatePODto createPODto = param.data;
            RetModel<object> Result = new RetModel<object>();
            Result.code = "0";
            Result.message = "0";
            #region 创建采购订单
            UFIDAU9CustKukaMPSMPSSVICreatePOSVClient Client = new UFIDAU9CustKukaMPSMPSSVICreatePOSVClient();
            www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVCreatePODTOData poDtoData = new www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVCreatePODTOData();
            poDtoData.m_supplier_Code = createPODto.Supplier_Code;
            //poDtoData.m_pOLines = new www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOLineDTOData[];
            //UFIDAU9CustKukaMPSMPSSVPOLineDTOData test = new UFIDAU9CustKukaMPSMPSSVPOLineDTOData();
           List<www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOLineDTOData> poLines=new List<UFIDAU9CustKukaMPSMPSSVPOLineDTOData>();
            List<CreatePOLineDto> listUnValidate = new List<CreatePOLineDto>();
            foreach (var item in createPODto.POLines)
            {
                StringBuilder builder = new StringBuilder();
                #region 料品检查               
                var dataTable = DbHelperSQL.Query("select ID,Code,Name from dbo.CBO_ItemMaster im where im.code=@Code and im.Effective_IsEffective=1 and im.Effective_EffectiveDate<=GETDATE() and im.Effective_DisableDate>=GETDATE()", new List<System.Data.SqlClient.SqlParameter>() { new System.Data.SqlClient.SqlParameter("Code", item.ItemCode) });
                if (dataTable.Rows.Count == 0)
                {
                    //throw new Exception($"料号{item.ItemCode}不存在或失效!");
                    builder.AppendLine($"料号{item.ItemCode}不存在或失效!");
                    //item.ErrorMsg = $"料号{item.ItemCode}不存在或失效!";
                    //listUnValidate.Add(item);
                }
                #endregion

                #region 厂商价目表检查

                var dataTablePPR = DbHelperSQL.Query("select pp.Supplier,ppl.ItemInfo_ItemCode,pp.Code as PPRCode, ppl.FromDate, ppl.ToDate, ppl.DocLineNo, ppl.Price, im.code as ItemCode, im2.code as BOMCode from PPR_PurPriceList pp inner join CBO_Supplier s on s.id = pp.supplier left join PPR_PurPriceLine ppl on ppl.PurPriceList = pp.id left join(select code, id from CBO_ItemMaster where code = @ItemCode)im on im.id = ppl.iteminfo_itemid left join(select im2.code as Code,im2.id as ID from CBO_BOMMaster bm left join CBO_BOMComponent bc on bc.BOMMaster = bm.id left join CBO_ItemMaster im on im.id = bm.itemmaster left join CBO_ItemMaster im2 on im2.id = bc.itemmaster where im.code = @ItemCode and bc.IsEffective = 1 and bc.EffectiveDate <= GETDATE() and bc.DisableDate >= GETDATE()) im2 on im2.ID = ppl.iteminfo_itemid where s.code = @SupplierCode and(im.code is not null or im2.code is not null) and ppl.FromDate <= GETDATE() and ppl.ToDate >= GETDATE() and ppl.Active=1", new List<System.Data.SqlClient.SqlParameter>() { new System.Data.SqlClient.SqlParameter("ItemCode", item.ItemCode), new System.Data.SqlClient.SqlParameter("SupplierCode", poDtoData.m_supplier_Code) });
                if (dataTablePPR.Rows.Count == 0)
                {
                    //throw new Exception($"料号{item.ItemCode}没有维护厂商价目表或失效!"); 
                    builder.AppendLine($"供应商{poDtoData.m_supplier_Code}和料号{item.ItemCode}没有维护厂商价目表或失效!");
                }
                #endregion
                if (!builder.IsNullOrEmpty())
                {
                    item.ErrorMsg = builder.ToString();
                    listUnValidate.Add(item);
                    continue;
                }

                www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOLineDTOData poLine = new www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOLineDTOData()
                {
                    m_deliveryDate = item.DeliveryDate,
                    m_orderQty = item.OrderQty,
                    m_itemCode = item.ItemCode,
                    m_remark = item.Remark,
                    m_srcDocNo = item.SrcDocNo,                    
                    m_createPODTO = poDtoData,
                    m_srcDoc=item.SrcDoc,
                    m_srcDocLine=item.SrcDocLine,
                    m_srcDocLineNo=item.SrcDocLineNo
                };
                poLines.Add(poLine);
            }
            poDtoData.m_pOLines = poLines.ToArray();
            www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVCreatePODTOData[] pOList = new www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVCreatePODTOData[] { poDtoData };

            ThreadContext context = Common.CreateContextObj();
            string sqlSupplier = "select o.id,o.code from dbo.CBO_Supplier s left join dbo.Base_Organization o on o.id = s.org where s.code = @Code and s.Effective_IsEffective=1 and s.Effective_EffectiveDate<=GETDATE() and s.Effective_DisableDate>=GETDATE()";
            List<SqlParameter> listParam = new List<SqlParameter>();
            listParam.Add(new SqlParameter("Code", poDtoData.m_supplier_Code));
            var dataTableSupplier = DbHelperSQL.Query(sqlSupplier, listParam);
            if (dataTableSupplier.Rows.Count == 0)
            {
                throw new Exception("没有对应编码的供应商或失效！");
            }
            else {
                context.nameValueHas["OrgID"] = Convert.ToInt64(dataTableSupplier.Rows[0]["id"]);
            }

            www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPODataData result2 = Client.Do(context, poDtoData, out UFSoft.UBF.Exceptions1.MessageBase[] outMessages);
            //Client.Do(new DoResponse());
            #endregion            
            Result.data = new
            {
                POInfo = new PODto()
                {
                    DeliveryDate = result2.m_deliverDate,
                    PODocNo = result2.m_docNo,
                    Supplier_Code = result2.m_supplier
                },
                ErrorLine = listUnValidate
            };
            return Result;
        }

        public RetModel<List<MPSPOInfo>> GetMPSPOInfo(RecModel<ItemInfoQuery> param)
        {
            RetModel<List<MPSPOInfo>> result = new RetModel<List<MPSPOInfo>>();
            result.code = "0";
            result.message = "0";
            #region sql
            string sqlHead = " select * from kuka_mps_po po where 1=1 {0} ";
            string sqlLine = " select * from kuka_mps_poline pl left join kuka_mps_po po on po.id=pl.mpspo where 1=1 {0} ";
            string sqlCount = " select count(1) from kuka_mps_po po where 1=1 {0} ";
            string sqlSOPage = " select  ROW_NUMBER() over(order by po.id)as rownum,* from kuka_mps_po po where 1=1 {0}";

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
                    sqlParam += " and po.PODocNo=@PODocNo";
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
            sqlLine = string.Format(sqlLine, sqlParam);
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.AppendLine(sqlSOPageS.ToString());
            sqlQuery.AppendLine(sqlHead);
            sqlQuery.AppendLine(sqlLine);
            result.message = DbHelperSQL.QueryCountOnly(sqlCount.ToString(), listParam).ToString();
            var dataSet = DbHelperSQL.QueryDataSet(sqlQuery.ToString(), listParam);
            var dataHead = ExtendMethod.ToDataList<MPSPOInfo>(dataSet.Tables[0]);
            var dataLine = ExtendMethod.ToDataList<MPSPOLineInfo>(dataSet.Tables[1]);
            Dictionary<int, List<MPSPOLineInfo>> map = new Dictionary<int, List<MPSPOLineInfo>>();
            foreach (MPSPOLineInfo line in dataLine)
            {
                if (map.ContainsKey(line.MPSPO))
                {
                    map[line.MPSPO].Add(line);
                }
                else
                {
                    map.Add(line.MPSPO, new List<MPSPOLineInfo>() { line });
                }
            }
            foreach (MPSPOInfo head in dataHead)
            {
                if (map.ContainsKey(head.ID))
                {
                    head.POLines = map[head.ID];
                }
                else
                {
                    head.POLines = new List<MPSPOLineInfo>();
                }
            }
            result.data = dataHead;
            #endregion

            return result;
        }

        public RetModel<List<POInfo>> GetPOInfo(RecModel<ItemInfoQuery> param)
        {
            RetModel<List<POInfo>> result = new RetModel<List<POInfo>>();
            result.code = "0";
            result.message = "0";
            #region sql
            string sqlHead = " select po.ID, po.DocNo,(case po.status when 0 then '开立' when 1 then '审核中' when 2 then '已审核' when 3 then '自然关闭' when 4  then '短缺关闭' when 5 then '超额关闭' else '' end) as Status, po.Supplier_Supplier as Supplier, po.Supplier_Code as SupplierCode, st.Name as SupplierName, po.BusinessDate, po.CreatedBy, po.ModifiedOn  from dbo.PM_PurchaseOrder po  left join dbo.CBO_Supplier_Trl st on st.id=po.Supplier_Supplier  left join dbo.Base_Organization o on o.id=po.org left join dbo.PM_POLine pl on pl.PurchaseOrder=po.id left join dbo.PM_POShipLine psl on psl.Poline=pl.id and pl.ItemInfo_ItemID=psl.ItemInfo_ItemID where (pl.ItemInfo_ItemCode like '91.%' or pl.ItemInfo_ItemCode like '07.%')  and  psl.DeliveryDate>'2017-01-01' {0} 	 group by po.ID, po.DocNo, po.Supplier_Supplier, po.Supplier_Code, st.Name, po.BusinessDate, po.CreatedBy, po.ModifiedOn,po.status ";
            string sqlLine = "  select po.ID as PurchaseOrder, (case pl.status when 0 then '开立' when 1 then '审核中' when 2 then '已审核' when 3 then '自然关闭' when 4  then '短缺关闭' when 5 then '超额关闭' else '' end) as Status,	 pl.DocLineNo ,pl.itemInfo_itemCode as ItemCode ,pl.itemInfo_itemName as ItemName ,(case when  itemed.DescFlexField_PrivateDescSeg25='亲子包'  	then '特殊产品' else tempCategory.SaleName  end)as Dept,pl.FinallyPriceAC ,pl.PurQtyPU as PurQtyPU ,pl.TotalRecievedQtyPU as TotalRecievedQtyPU ,pl.TotalRtnDeductQtyPU  as TotalRtnDeductQtyPU ,case when pl.status>2 then 0 else pl.PurQtyPU-psl.RcvQtyTU-psl.TotalRtnDeductQtyCU end as LastQty ,0 as OverDateQty ,null as ChangeDeliveryDate ,pl.PurQtyPU as OriginQty ,(case when psl.DeliveryDate is null  then pl.DescFlexSegments_PrivateDescSeg20 else  psl.DeliveryDate end) as OriginDeliveryDate ,(case when psl.DeliveryDate is null  then pl.DescFlexSegments_PrivateDescSeg20 else  psl.DeliveryDate end)  as DeliveryDate  from dbo.PM_PurchaseOrder po  left join dbo.CBO_Supplier_Trl st on st.id=po.Supplier_Supplier  left join dbo.Base_Organization o on o.id=po.org left join dbo.PM_POLine pl on pl.PurchaseOrder=po.id left join dbo.PM_POShipLine psl on psl.POLine=pl.id and psl.ItemInfo_ItemID=pl.ItemInfo_ItemID inner join dbo.CBO_ItemMaster im on im.id= pl.ItemInfo_ItemID     left join dbo.Kuka_BS_ItemEd itemed on itemed.item= im.id        left join (select ct.Name as SaleName, c.id from dbo.CBO_Category c    left join dbo.[CBO_Category_Trl] as ct on (c.[ID] = ct.[ID])) tempCategory on tempCategory.id=im.PurchaseCategory  where (pl.ItemInfo_ItemCode like '91.%' or pl.ItemInfo_ItemCode like '07.%')   and  psl.DeliveryDate>'2017-01-01'  {0}  ";
            string sqlCount = " select count(1) from(select po.id  from dbo.PM_PurchaseOrder po left join dbo.Base_Organization o on o.id=po.org left join dbo.PM_POLine pl on pl.PurchaseOrder=po.id left join dbo.PM_POShipLine psl on psl.Poline=pl.id and pl.ItemInfo_ItemID=psl.ItemInfo_ItemID where (pl.ItemInfo_ItemCode like '91.%' or pl.ItemInfo_ItemCode like '07.%')  and  psl.DeliveryDate>'2017-01-01' {0} group by po.id) t  ";
            string sqlSOPage = " select  ROW_NUMBER() over(order by t.id)as rownum,* from ( 	 select po.ID  from dbo.PM_PurchaseOrder po  left join dbo.CBO_Supplier_Trl st on st.id=po.Supplier_Supplier  left join dbo.Base_Organization o on o.id=po.org left join dbo.PM_POLine pl on pl.PurchaseOrder=po.id left join dbo.PM_POShipLine psl on psl.Poline=pl.id and pl.ItemInfo_ItemID=psl.ItemInfo_ItemID where (pl.ItemInfo_ItemCode like '91.%' or pl.ItemInfo_ItemCode like '07.%')  and  psl.DeliveryDate>'2017-01-01' {0} group by po.ID) t  ";

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
                if (!string.IsNullOrEmpty(param.data.keyValue))
                {
                    sqlParam += " and po.DocNo=@DocNo";
                    listParam.Add(new SqlParameter("DocNo", param.data.keyValue));
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
            string sqlHead = " select po.ID ,po.DocNo ,po.Supplier_Supplier as Supplier ,po.Supplier_Code as SupplierCode ,st.Name as SupplierName   from dbo.PM_PurchaseOrder po  left join dbo.PM_PODocType pot on pot.id = po.DocumentType   left join dbo.CBO_Supplier_Trl st on st.id=po.Supplier_Supplier     left join dbo.Base_Organization o     on o.id=po.org left join dbo.PM_POLine pl on pl.PurchaseOrder=po.id     left join dbo.PM_POShipLine psl on psl.POLine=pl.id and psl.ItemInfo_ItemID=pl.ItemInfo_ItemID     inner join dbo.CBO_ItemMaster im on im.id= pl.ItemInfo_ItemID left join dbo.Kuka_BS_ItemEd itemed on itemed.item= im.id left join (select ct.Name as SaleName, c.id from dbo.CBO_Category c    left join dbo.[CBO_Category_Trl] as ct on (c.[ID] = ct.[ID])) tempCategory on tempCategory.id=im.SaleCategory  where (pl.ItemInfo_ItemCode like '91.%' or pl.ItemInfo_ItemCode like '07.%') and len(pl.ItemInfo_ItemCode)<=12 and  psl.DeliveryDate>'2017-01-01' and pl.status>=2 and po.Org in( '1003703211326886','1003703211328215','1002902253057451','1003703211331940','1003704015042704','1003703211330900') and pot.BusinessType = '316'  {0}  group by  po.ID ,po.DocNo ,po.Supplier_Supplier ,po.Supplier_Code ,st.Name ";
            string sqlLine = "select po.ID as PurchaseOrder ,pl.id as ID, pl.DocLineNo ,pl.itemInfo_itemCode as ItemCode ,pl.itemInfo_itemName as ItemName  ,(case when  itemed.DescFlexField_PrivateDescSeg25='亲子包'  	then '特殊产品' else tempCategory.SaleName  end)as Dept  ,psl.DeliveryDate  as DeliveryDate   ,pl.PurQtyPU  ,(case pl.status when 0 then '开立' when 1 then '审核中' when 2 then '已审核' when 3 then '自然关闭' when 4  then '短缺关闭' when 5 then '超额关闭' else '' end) as Status,#tempInv.HZCurrentMonthInv as HZCurrentMonthInv ,#tempInv.HBCurrentMonthInv as HBCurrentMonthInv ,#tempInv.TotalInv as TotalInv ,pl.PurQtyPU as OrderQty ,case when pl.status>2 then 0 else pl.PurQtyPU-pl.TotalRecievedQtyPU-pl.TotalRtnDeductQtyPU-IsNull(#tempOpenRcv.RcvQtyPU,0) end as LastQty ,-1 as UsageQty ,0as OrderUsageQty ,#tempASN.HZOnWay as HZOnWay ,#tempASN.HBOnWay as HBOnWay ,#tempNoExpress.HBNoExpress as HBNoExpress ,#tempNoExpress.HZNoExpress as HZNoExpress ,#tempInv.HZTotalInv as HZTotalInv ,#tempInv.HBTotalInv as HBTotalInv ,#tempSONoExpress.销售未发 as SONoExpress ,0as ComInv   from dbo.PM_PurchaseOrder po    left join dbo.PM_PODocType pot on pot.id = po.DocumentType left join dbo.CBO_Supplier_Trl st on st.id=po.Supplier_Supplier     left join dbo.Base_Organization o     on o.id=po.org left join dbo.PM_POLine pl on pl.PurchaseOrder=po.id     left join dbo.PM_POShipLine psl on psl.POLine=pl.id and psl.ItemInfo_ItemID=pl.ItemInfo_ItemID     inner join dbo.CBO_ItemMaster im on im.id= pl.ItemInfo_ItemID    	left join dbo.Kuka_BS_ItemEd itemed on itemed.item= im.id         	left join (select ct.Name as SaleName, c.id from dbo.CBO_Category c    left join dbo.[CBO_Category_Trl] as ct on (c.[ID] = ct.[ID])) tempCategory on tempCategory.id=im.SaleCategory   	left join #tempInv on #tempInv.id=psl.id 	left join #tempASN on #tempASN.id=psl.id left join #tempOpenRcv on #tempOpenRcv.pslid=psl.id	left join #tempNoExpress on #tempNoExpress.采购订单号=po.docno and #tempNoExpress.采购订单行号=pl.doclineno left join #tempSONoExpress on #tempSONoExpress.料品=pl.ItemInfo_ItemCode where (pl.ItemInfo_ItemCode like '91.%' or pl.ItemInfo_ItemCode like '07.%') and len(pl.ItemInfo_ItemCode)<=12   and  psl.DeliveryDate>'2017-01-01' and pl.status>=2  and po.Org in('1003703211326886','1003703211328215','1002902253057451','1003703211331940','1003704015042704','1003703211330900') and pot.BusinessType = '316'  {0}  ";
            string sqlCount = " select count(1) from(select po.ID  from dbo.PM_PurchaseOrder po   left join dbo.PM_PODocType pot on pot.id = po.DocumentType  left join dbo.CBO_Supplier_Trl st on st.id=po.Supplier_Supplier     left join dbo.Base_Organization o on o.id=po.org  left join dbo.PM_POLine pl on pl.PurchaseOrder=po.id left join dbo.PM_POShipLine psl on psl.POLine=pl.id and psl.ItemInfo_ItemID=pl.ItemInfo_ItemID     inner join dbo.CBO_ItemMaster im on im.id= pl.ItemInfo_ItemID  left join dbo.Kuka_BS_ItemEd itemed on itemed.item= im.id left join (select ct.Name as SaleName, c.id from dbo.CBO_Category c    left join dbo.[CBO_Category_Trl] as ct on (c.[ID] = ct.[ID])) tempCategory on tempCategory.id=im.SaleCategory  where (pl.ItemInfo_ItemCode like '91.%' or pl.ItemInfo_ItemCode like '07.%')  and len(pl.ItemInfo_ItemCode)<=12  and  psl.DeliveryDate>'2017-01-01' and pl.status>=2   and po.Org in('1003703211326886','1003703211328215','1002902253057451','1003703211331940','1003704015042704','1003703211330900') and pot.BusinessType = '316'  {0} group by  po.ID ) t  ";
            string sqlSOPage = " select  ROW_NUMBER() over(order by t.id)as rownum,* from (select po.ID  from dbo.PM_PurchaseOrder po left join dbo.PM_PODocType pot on pot.id = po.DocumentType left join dbo.CBO_Supplier_Trl st on st.id=po.Supplier_Supplier     left join dbo.Base_Organization o on o.id=po.org  left join dbo.PM_POLine pl on pl.PurchaseOrder=po.id left join dbo.PM_POShipLine psl on psl.POLine=pl.id and psl.ItemInfo_ItemID=pl.ItemInfo_ItemID inner join dbo.CBO_ItemMaster im on im.id= pl.ItemInfo_ItemID  left join dbo.Kuka_BS_ItemEd itemed on itemed.item= im.id left join (select ct.Name as SaleName, c.id from dbo.CBO_Category c    left join dbo.[CBO_Category_Trl] as ct on (c.[ID] = ct.[ID])) tempCategory on tempCategory.id=im.SaleCategory where (pl.ItemInfo_ItemCode like '91.%' or pl.ItemInfo_ItemCode like '07.%')  and len(pl.ItemInfo_ItemCode)<=12  and  psl.DeliveryDate>'2017-01-01' and pl.status>=2  and po.Org in( '1003703211326886','1003703211328215','1002902253057451','1003703211331940','1003704015042704','1003703211330900') and pot.BusinessType = '316'  {0} group by  po.ID ) t  ";

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
                if (!string.IsNullOrEmpty(param.data.keyValue))
                {
                    sqlParam += " and po.docno=@DocNo";
                    listParam.Add(new SqlParameter("DocNo", param.data.keyValue));
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


            string strInv = $" declare @year int,@month int; set @year=year(GETDATE()-1); set @month=month(GETDATE()-1); select psl.id ,sum(rcvl.RcvQtyPU) as TotalInv ,sum(case when wh.DescFlexField_PubDescSeg2='001' or wht.Name not like '%河北%' then rcvl.RcvQtyPU else 0 end) as HZTotalInv ,sum(case when wh.DescFlexField_PubDescSeg2='002' or wht.Name like '%河北%' then rcvl.RcvQtyPU else 0 end) as HBTotalInv ,sum(case when year(rcv.ApprovedOn)=@year and month(rcv.ApprovedOn)=@month then rcvl.RcvQtyPU else 0 end) as TotalCurrentMonthInv ,sum(case when year(rcv.ApprovedOn)=@year and month(rcv.ApprovedOn)=@month and (wh.DescFlexField_PubDescSeg2='001' or wht.Name not like '%河北%') then rcvl.RcvQtyPU else 0 end) as HZCurrentMonthInv ,sum(case when year(rcv.ApprovedOn)=@year and month(rcv.ApprovedOn)=@month and (wh.DescFlexField_PubDescSeg2='002'or wht.Name like '%河北%') then rcvl.RcvQtyPU else 0 end) as HBCurrentMonthInv into #tempInv from dbo.PM_Receivement rcv left join dbo.PM_RcvLine rcvl on rcv.id = rcvl.Receivement and rcvl.KitParentLine=0 left join dbo.Base_Organization_Trl ot on ot.id = rcv.Org Inner join dbo.PM_POShipLine psl on psl.id = rcvl.SrcDoc_SrcDocSubline_EntityID  Inner join dbo.pm_poline pl on pl.id = psl.poline  left join dbo.PM_PurchaseOrder po on po.id = pl.PurchaseOrder left join dbo.PM_PODocType pot on pot.id = po.DocumentType left join dbo.cbo_itemmaster im on im.id = rcvl.ItemInfo_ItemID left join dbo.Base_UOM_Trl uomt on uomt.id = rcvl.StoreUOM  left join dbo.CBO_Supplier_trl st on st.id = rcv.Supplier_Supplier  left join dbo.cbo_wh_trl wht on wht.id = rcvl.wh left join dbo.cbo_wh wh on wh.id = rcvl.wh where ot.id in( '1003703211326886','1003703211328215','1002902253057451','1003703211331940','1003704015042704','1003703211330900') and  (rcvl.ItemInfo_ItemCode like '91.%' or rcvl.ItemInfo_ItemCode like '07.%') and len(rcvl.ItemInfo_ItemCode)<=12  and pl.status>=2   {sqlParam} group by psl.id";//and rcv.ApprovedOn<cast(GETDATE()-1 as date) 

            string strASN = $" SELECT  psl.id ,case when psl.status>2 then 0 else Sum(asnl.ShipQtyTU) end as TotalOnWay ,case when psl.status>2 then 0 else Sum(case when dvt.Name not like '%河北%' then asnl.ShipQtyTU else 0 end) end as HZOnWay ,case when psl.status > 2 then 0 else Sum(case when dvt.Name like '%河北%' then asnl.ShipQtyTU else 0 end) end as HBOnWay into #tempASN FROM dbo.PM_ASN AS asn  LEFT JOIN  dbo.PM_ASNLine AS asnl ON asn.ID = asnl.ASN  LEFT JOIN dbo.CBO_Supplier_Trl AS s ON s.ID = asn.Supplier_Supplier LEFT JOIN dbo.Base_ValueSetDef AS vsd ON vsd.Code = 'VP_KukaSendAddress'  LEFT JOIN dbo.Base_DefineValue AS dv ON dv.Code =asn.DescFlexField_PrivateDescSeg3 AND dv.ValueSetDef = vsd.ID  LEFT JOIN dbo.Base_DefineValue_Trl AS dvt ON dv.ID = dvt.ID Inner join dbo.PM_POShipLine psl on psl.id =asnl.SrcDocInfo_SrcDocSubline_EntityID  Inner join dbo.pm_poline pl on pl.id = psl.poline  LEFT JOIN dbo.PM_PurchaseOrder AS po ON po.ID = pl.PurchaseOrder left join dbo.PM_PODocType pot on pot.id = po.DocumentType WHERE(asnl.Status >= 2) and asnl.TotalRcvQtyTU = 0 and pl.status >= 2 and len(pl.ItemInfo_ItemCode)<= 12  {sqlParam} group by psl.id,psl.status";
            string strNoExpress = $"select rt.采购订单号,rt.采购订单行号 ,case when pl.status>2 then 0 else  Sum(rt.回货计划数量) end as TotalNoExpress ,case when pl.status > 2 then 0 else Sum(case when dvt.name not like '%河北%' then rt.回货计划数量 else 0 end) end as HZNoExpress ,case when pl.status > 2 then 0 else Sum(case when dvt.name like '%河北%' then rt.回货计划数量 else 0 end) end as HBNoExpress  into #tempNoExpress from [kuka_basedata].[dbo].[v_RtGoods] rt left join dbo.Kuka_VPT_RtGoodsDoc rd on rd.docno = rt.回货计划单号 LEFT JOIN dbo.Base_DefineValue_trl AS dvt ON dvt.id = rd.AddressRef left join dbo.PM_PurchaseOrder po on po.DocNo = rt.采购订单号 left join dbo.PM_POline pl on po.id = pl.PurchaseOrder and pl.DocLineNo = rt.采购订单行号 where rt.回货行状态 = '已审状态' and ASN单号 is null {sqlParam} group by rt.采购订单号,rt.采购订单行号,pl.status ";

            string strSONoExpress = $"select 料品,Sum(未出库数量) as 销售未发 into #tempSONoExpress from kuka_basedata.dbo.v_kuka_OrderMonitorSO_nx1 where 出库状态  not like '已出库' and(料品 like '91%'  OR 料品 like '07.%') and len(料品)<=12 AND 销售订单行状态 like '%审核' group by 料品";

            string openRcv = "select rcvl.SrcDoc_SrcDocSubLine_EntityID as pslid,sum(rcvl.RcvQtyPU) as RcvQtyPU into #tempOpenRcv from dbo.PM_Receivement rcv left join dbo.PM_RcvLine rcvl on rcv.id = rcvl.Receivement and rcvl.KitParentLine=0 left join dbo.Base_Organization_Trl ot on ot.id = rcv.Org Inner join dbo.PM_POShipLine psl on psl.id = rcvl.SrcDoc_SrcDocSubline_EntityID  Inner join dbo.pm_poline pl on pl.id = psl.poline  left join dbo.PM_PurchaseOrder po on po.id = pl.PurchaseOrder left join dbo.PM_PODocType pot on pot.id = po.DocumentType left join dbo.cbo_itemmaster im on im.id = rcvl.ItemInfo_ItemID left join dbo.Base_UOM_Trl uomt on uomt.id = rcvl.StoreUOM  left join dbo.CBO_Supplier_trl st on st.id = rcv.Supplier_Supplier  left join dbo.cbo_wh_trl wht on wht.id = rcvl.wh left join dbo.cbo_wh wh on wh.id = rcvl.wh where ot.id in( '1003703211326886','1003703211328215','1002902253057451','1003703211331940','1003704015042704','1003703211330900') and  (rcvl.ItemInfo_ItemCode like '91.%' or rcvl.ItemInfo_ItemCode like '07.%') and len(rcvl.ItemInfo_ItemCode)<=12 and rcvl.Status <= 3 group by rcvl.SrcDoc_SrcDocSubLine_EntityID";
            #endregion
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.AppendLine(sqlSOPageS.ToString());

            sqlQuery.AppendLine(strInv);
            sqlQuery.AppendLine(strASN);
            sqlQuery.AppendLine(strNoExpress);
            sqlQuery.AppendLine(strSONoExpress);
            sqlQuery.AppendLine(openRcv);

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


        public RetModel<List<JCPOInfo>> GetJCPOInfoV2(RecModel<ItemInfoQuery> param)
        {

            RetModel<List<JCPOInfo>> result = new RetModel<List<JCPOInfo>>();
            result.code = "0";
            result.message = "0";

            #region sql
            string sqlHead = " select po.ID ,po.DocNo ,po.Supplier_Supplier as Supplier ,po.Supplier_Code as SupplierCode ,st.Name as SupplierName   from dbo.PM_PurchaseOrder po  left join dbo.PM_PODocType pot on pot.id = po.DocumentType   left join dbo.CBO_Supplier_Trl st on st.id=po.Supplier_Supplier     left join dbo.Base_Organization o     on o.id=po.org left join dbo.PM_POLine pl on pl.PurchaseOrder=po.id     left join dbo.PM_POShipLine psl on psl.POLine=pl.id and psl.ItemInfo_ItemID=pl.ItemInfo_ItemID     inner join dbo.CBO_ItemMaster im on im.id= pl.ItemInfo_ItemID left join dbo.Kuka_BS_ItemEd itemed on itemed.item= im.id left join (select ct.Name as SaleName, c.id from dbo.CBO_Category c    left join dbo.[CBO_Category_Trl] as ct on (c.[ID] = ct.[ID])) tempCategory on tempCategory.id=im.SaleCategory  where (pl.ItemInfo_ItemCode like '91.%' or pl.ItemInfo_ItemCode like '07.%') and len(pl.ItemInfo_ItemCode)<=12 and  psl.DeliveryDate>'2017-01-01' and pl.status>=2 and po.Org in( '1003703211326886','1003703211328215','1002902253057451','1003703211331940','1003704015042704','1003703211330900') and pot.BusinessType = '316'  {0}  group by  po.ID ,po.DocNo ,po.Supplier_Supplier ,po.Supplier_Code ,st.Name ";
            string sqlLine = "select po.ID as PurchaseOrder ,pl.id as ID, pl.DocLineNo ,pl.itemInfo_itemCode as ItemCode ,pl.itemInfo_itemName as ItemName  ,(case when  itemed.DescFlexField_PrivateDescSeg25='亲子包'  	then '特殊产品' else tempCategory.SaleName  end)as Dept  ,psl.DeliveryDate  as DeliveryDate   ,pl.PurQtyPU  ,(case pl.status when 0 then '开立' when 1 then '审核中' when 2 then '已审核' when 3 then '自然关闭' when 4  then '短缺关闭' when 5 then '超额关闭' else '' end) as Status,#tempInv.HZCurrentMonthInv as HZCurrentMonthInv ,#tempInv.HBCurrentMonthInv as HBCurrentMonthInv ,#tempInv.TotalInv as TotalInv ,pl.PurQtyPU as OrderQty ,case when pl.status>2 then 0 else pl.PurQtyPU-pl.TotalRecievedQtyPU-pl.TotalRtnDeductQtyPU-IsNull(#tempOpenRcv.RcvQtyPU,0) end as LastQty ,-1 as UsageQty ,0as OrderUsageQty ,#tempASN.HZOnWay as HZOnWay ,#tempASN.HBOnWay as HBOnWay ,#tempNoExpress.HBNoExpress as HBNoExpress ,#tempNoExpress.HZNoExpress as HZNoExpress ,#tempInv.HZTotalInv as HZTotalInv ,#tempInv.HBTotalInv as HBTotalInv ,#tempSONoExpress.销售未发 as SONoExpress ,0as ComInv   from dbo.PM_PurchaseOrder po    left join dbo.PM_PODocType pot on pot.id = po.DocumentType left join dbo.CBO_Supplier_Trl st on st.id=po.Supplier_Supplier     left join dbo.Base_Organization o     on o.id=po.org left join dbo.PM_POLine pl on pl.PurchaseOrder=po.id     left join dbo.PM_POShipLine psl on psl.POLine=pl.id and psl.ItemInfo_ItemID=pl.ItemInfo_ItemID     inner join dbo.CBO_ItemMaster im on im.id= pl.ItemInfo_ItemID    	left join dbo.Kuka_BS_ItemEd itemed on itemed.item= im.id         	left join (select ct.Name as SaleName, c.id from dbo.CBO_Category c    left join dbo.[CBO_Category_Trl] as ct on (c.[ID] = ct.[ID])) tempCategory on tempCategory.id=im.SaleCategory   	left join #tempInv on #tempInv.id=psl.id 	left join #tempASN on #tempASN.id=psl.id 	left join #tempNoExpress on #tempNoExpress.采购订单号=po.docno and #tempNoExpress.采购订单行号=pl.doclineno left join #tempOpenRcv on #tempOpenRcv.pslid=psl.id left join #tempSONoExpress on #tempSONoExpress.料品=pl.ItemInfo_ItemCode where (pl.ItemInfo_ItemCode like '91.%' or pl.ItemInfo_ItemCode like '07.%') and len(pl.ItemInfo_ItemCode)<=12   and  psl.DeliveryDate>'2017-01-01' and pl.status>=2  and po.Org in('1003703211326886','1003703211328215','1002902253057451','1003703211331940','1003704015042704','1003703211330900') and pot.BusinessType = '316'  {0}  ";
            string sqlCount = " select count(1) from(select po.ID  from dbo.PM_PurchaseOrder po   left join dbo.PM_PODocType pot on pot.id = po.DocumentType  left join dbo.CBO_Supplier_Trl st on st.id=po.Supplier_Supplier     left join dbo.Base_Organization o on o.id=po.org  left join dbo.PM_POLine pl on pl.PurchaseOrder=po.id left join dbo.PM_POShipLine psl on psl.POLine=pl.id and psl.ItemInfo_ItemID=pl.ItemInfo_ItemID     inner join dbo.CBO_ItemMaster im on im.id= pl.ItemInfo_ItemID  left join dbo.Kuka_BS_ItemEd itemed on itemed.item= im.id left join (select ct.Name as SaleName, c.id from dbo.CBO_Category c    left join dbo.[CBO_Category_Trl] as ct on (c.[ID] = ct.[ID])) tempCategory on tempCategory.id=im.SaleCategory  where (pl.ItemInfo_ItemCode like '91.%' or pl.ItemInfo_ItemCode like '07.%')  and len(pl.ItemInfo_ItemCode)<=12  and  psl.DeliveryDate>'2017-01-01' and pl.status>=2   and po.Org in('1003703211326886','1003703211328215','1002902253057451','1003703211331940','1003704015042704','1003703211330900') and pot.BusinessType = '316'  {0} group by  po.ID ) t  ";
            string sqlSOPage = " select  ROW_NUMBER() over(order by t.id)as rownum,* from (select po.ID  from dbo.PM_PurchaseOrder po left join dbo.PM_PODocType pot on pot.id = po.DocumentType left join dbo.CBO_Supplier_Trl st on st.id=po.Supplier_Supplier     left join dbo.Base_Organization o on o.id=po.org  left join dbo.PM_POLine pl on pl.PurchaseOrder=po.id left join dbo.PM_POShipLine psl on psl.POLine=pl.id and psl.ItemInfo_ItemID=pl.ItemInfo_ItemID inner join dbo.CBO_ItemMaster im on im.id= pl.ItemInfo_ItemID  left join dbo.Kuka_BS_ItemEd itemed on itemed.item= im.id left join (select ct.Name as SaleName, c.id from dbo.CBO_Category c    left join dbo.[CBO_Category_Trl] as ct on (c.[ID] = ct.[ID])) tempCategory on tempCategory.id=im.SaleCategory where (pl.ItemInfo_ItemCode like '91.%' or pl.ItemInfo_ItemCode like '07.%')  and len(pl.ItemInfo_ItemCode)<=12  and  psl.DeliveryDate>'2017-01-01' and pl.status>=2  and po.Org in( '1003703211326886','1003703211328215','1002902253057451','1003703211331940','1003704015042704','1003703211330900') and pot.BusinessType = '316'  {0} group by  po.ID ) t  ";

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
                if (!string.IsNullOrEmpty(param.data.keyValue))
                {
                    sqlParam += " and po.docno=@DocNo";
                    listParam.Add(new SqlParameter("DocNo", param.data.keyValue));
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


            string strInv = $" declare @year int,@month int; set @year=year(GETDATE()-1); set @month=month(GETDATE()-1); select psl.id ,sum(rcvl.RcvQtyPU) as TotalInv ,sum(case when wh.DescFlexField_PubDescSeg2='001' or wht.Name not like '%河北%' then rcvl.RcvQtyPU else 0 end) as HZTotalInv ,sum(case when wh.DescFlexField_PubDescSeg2='002' or wht.Name like '%河北%' then rcvl.RcvQtyPU else 0 end) as HBTotalInv ,sum(case when year(rcv.ApprovedOn)=@year and month(rcv.ApprovedOn)=@month then rcvl.RcvQtyPU else 0 end) as TotalCurrentMonthInv ,sum(case when year(rcv.ApprovedOn)=@year and month(rcv.ApprovedOn)=@month and (wh.DescFlexField_PubDescSeg2='001' or wht.Name not like '%河北%') then rcvl.RcvQtyPU else 0 end) as HZCurrentMonthInv ,sum(case when year(rcv.ApprovedOn)=@year and month(rcv.ApprovedOn)=@month and (wh.DescFlexField_PubDescSeg2='002'or wht.Name like '%河北%') then rcvl.RcvQtyPU else 0 end) as HBCurrentMonthInv into #tempInv from dbo.PM_Receivement rcv left join dbo.PM_RcvLine rcvl on rcv.id = rcvl.Receivement left join dbo.Base_Organization_Trl ot on ot.id = rcv.Org Inner join dbo.PM_POShipLine psl on psl.id = rcvl.SrcDoc_SrcDocSubline_EntityID  Inner join dbo.pm_poline pl on pl.id = psl.poline  left join dbo.PM_PurchaseOrder po on po.id = pl.PurchaseOrder left join dbo.PM_PODocType pot on pot.id = po.DocumentType left join dbo.cbo_itemmaster im on im.id = rcvl.ItemInfo_ItemID left join dbo.Base_UOM_Trl uomt on uomt.id = rcvl.StoreUOM  left join dbo.CBO_Supplier_trl st on st.id = rcv.Supplier_Supplier  left join dbo.cbo_wh_trl wht on wht.id = rcvl.wh left join dbo.cbo_wh wh on wh.id = rcvl.wh where ot.id in( '1003703211326886','1003703211328215','1002902253057451','1003703211331940','1003704015042704','1003703211330900') and  (rcvl.ItemInfo_ItemCode like '91.%' or rcvl.ItemInfo_ItemCode like '07.%') and len(rcvl.ItemInfo_ItemCode)<=12  and pl.status>=2    {sqlParam} group by psl.id";//and rcv.ApprovedOn<cast(GETDATE()-1 as date)

            string strASN = $" SELECT  psl.id ,case when psl.status>2 then 0 else Sum(asnl.ShipQtyTU) end as TotalOnWay ,case when psl.status>2 then 0 else Sum(case when dvt.Name not like '%河北%' then asnl.ShipQtyTU else 0 end) end as HZOnWay ,case when psl.status > 2 then 0 else Sum(case when dvt.Name like '%河北%' then asnl.ShipQtyTU else 0 end) end as HBOnWay into #tempASN FROM dbo.PM_ASN AS asn  LEFT JOIN  dbo.PM_ASNLine AS asnl ON asn.ID = asnl.ASN  LEFT JOIN dbo.CBO_Supplier_Trl AS s ON s.ID = asn.Supplier_Supplier LEFT JOIN dbo.Base_ValueSetDef AS vsd ON vsd.Code = 'VP_KukaSendAddress'  LEFT JOIN dbo.Base_DefineValue AS dv ON dv.Code =asn.DescFlexField_PrivateDescSeg3 AND dv.ValueSetDef = vsd.ID  LEFT JOIN dbo.Base_DefineValue_Trl AS dvt ON dv.ID = dvt.ID Inner join dbo.PM_POShipLine psl on psl.id =asnl.SrcDocInfo_SrcDocSubline_EntityID  Inner join dbo.pm_poline pl on pl.id = psl.poline  LEFT JOIN dbo.PM_PurchaseOrder AS po ON po.ID = pl.PurchaseOrder left join dbo.PM_PODocType pot on pot.id = po.DocumentType WHERE(asnl.Status >= 2) and asnl.TotalRcvQtyTU = 0 and pl.status >= 2 and len(pl.ItemInfo_ItemCode)<= 12  {sqlParam} group by psl.id,psl.status";
            string strNoExpress = $"select rt.采购订单号,rt.采购订单行号 ,case when pl.status>2 then 0 else  Sum(rt.回货计划数量) end as TotalNoExpress ,case when pl.status > 2 then 0 else Sum(case when dvt.name not like '%河北%' then rt.回货计划数量 else 0 end) end as HZNoExpress ,case when pl.status > 2 then 0 else Sum(case when dvt.name like '%河北%' then rt.回货计划数量 else 0 end) end as HBNoExpress  into #tempNoExpress from [kuka_basedata].[dbo].[v_RtGoods] rt left join dbo.Kuka_VPT_RtGoodsDoc rd on rd.docno = rt.回货计划单号 LEFT JOIN dbo.Base_DefineValue_trl AS dvt ON dvt.id = rd.AddressRef left join dbo.PM_PurchaseOrder po on po.DocNo = rt.采购订单号 left join dbo.PM_POline pl on po.id = pl.PurchaseOrder and pl.DocLineNo = rt.采购订单行号 where rt.回货行状态 = '已审状态' and ASN单号 is null {sqlParam} group by rt.采购订单号,rt.采购订单行号,pl.status ";

            string strSONoExpress = $"SELECT   t2.ItemInfo_ItemCode as 料品, SUM(t2.OrderByQtyTU - t2.SOLineSumInfo_SumShipQtyPU) AS 销售未发 into #tempSONoExpress FROM production.dbo.SM_SO AS t1 INNER JOIN production.dbo.SM_SOLine AS t2 ON t1.ID = t2.SO INNER JOIN  production.dbo.Base_Organization_Trl AS org ON t1.AccountOrg = org.ID AND org.SysMLFlag = 'zh-CN' INNER JOIN production.dbo.SM_SODocType AS t4 ON t1.DocumentType = t4.ID LEFT OUTER JOIN production.dbo.CBO_Customer AS t10 ON t1.OrderBy_Customer = t10.ID WHERE(t2.Status = 3) AND(t4.IsExport = 0) AND(org.Name IN('浙江顾家梅林家居有限公司','宁波梅山保税港区顾家寝具有限公司', '宁波名尚智能家居有限公司', '杭州顾家定制家居有限公司','顾家家居(宁波)有限公司', '顾家家居股份有限公司2', '宁波卡文家居有限公司')) AND (t4.ShortName NOT IN('内销备货订单', 'SO2', '外销人民币销售单')) AND(t10.Code NOT IN('CU-8899988', 'CU-799999', 'CU-7999993', 'CU-7999994', 'CU-79999991', 'CU-8799971', 'CU-87999980', 'CU-87999998', 'CU-889998', 'PU-790011')) AND(t2.OrderByQtyTU > t2.SOLineSumInfo_SumShipQtyPU) AND(t2.ItemInfo_ItemCode LIKE '91%' OR t2.ItemInfo_ItemCode LIKE '07.%') AND(LEN(t2.ItemInfo_ItemCode) <= 12) GROUP BY t2.ItemInfo_ItemCode";

            string openRcv = "select rcvl.SrcDoc_SrcDocSubLine_EntityID as pslid,sum(rcvl.RcvQtyPU) as RcvQtyPU into #tempOpenRcv from dbo.PM_Receivement rcv left join dbo.PM_RcvLine rcvl on rcv.id = rcvl.Receivement and rcvl.KitParentLine=0 left join dbo.Base_Organization_Trl ot on ot.id = rcv.Org Inner join dbo.PM_POShipLine psl on psl.id = rcvl.SrcDoc_SrcDocSubline_EntityID  Inner join dbo.pm_poline pl on pl.id = psl.poline  left join dbo.PM_PurchaseOrder po on po.id = pl.PurchaseOrder left join dbo.PM_PODocType pot on pot.id = po.DocumentType left join dbo.cbo_itemmaster im on im.id = rcvl.ItemInfo_ItemID left join dbo.Base_UOM_Trl uomt on uomt.id = rcvl.StoreUOM  left join dbo.CBO_Supplier_trl st on st.id = rcv.Supplier_Supplier  left join dbo.cbo_wh_trl wht on wht.id = rcvl.wh left join dbo.cbo_wh wh on wh.id = rcvl.wh where ot.id in( '1003703211326886','1003703211328215','1002902253057451','1003703211331940','1003704015042704','1003703211330900') and  (rcvl.ItemInfo_ItemCode like '91.%' or rcvl.ItemInfo_ItemCode like '07.%') and len(rcvl.ItemInfo_ItemCode)<=12 and rcvl.Status <= 3 group by rcvl.SrcDoc_SrcDocSubLine_EntityID";
            #endregion
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.AppendLine(sqlSOPageS.ToString());

            sqlQuery.AppendLine(strInv);
            sqlQuery.AppendLine(strASN);
            sqlQuery.AppendLine(strNoExpress);
            sqlQuery.AppendLine(strSONoExpress);
            sqlQuery.AppendLine(openRcv);

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
