using Custom;
using MPS.Bussiness.Custom;
using MPS.Bussiness.U9Service;
using MPS.Custom;
using MPS.Model;
using MPS.Model.TMSModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFSoft.UBF.Exceptions1;
using UFSoft.UBF.Util.Context;
using www.ufida.org.EntityData;

namespace MPS.Bussiness
{
    public class TMSReqInfoBuss
    {
        public RetModel<string> InsertTMSReqInfo(List<TMSReqInfo> list)
        {
            RetModel<string> result = new RetModel<string>();
            result.code = "0";
            result.message = "Success";

            UFIDAU9CustKukaBSBSSVIPubSPOperateionSVClient proxy
             = new UFIDAU9CustKukaBSBSSVIPubSPOperateionSVClient(); //代理客户端
            
            ThreadContext ThreadContext = Common.CreateContextObj(); //服务必须，上下文
            string fromSys = "TMS";
            string operatedBy = "Admin";
            string sPName = "Kuka_SPPub_InsertTMSReqInfo";

            List<UFIDAU9CustKukaBSBSSVParamsDTOData> sPParams = new List<UFIDAU9CustKukaBSBSSVParamsDTOData>();
            UFIDAU9CustKukaBSBSSVParamsDTOData para = new UFIDAU9CustKukaBSBSSVParamsDTOData();
            para.m_pName = "TMSReqInfos";
            para.m_pType = "String";
            string pValue = JsonHelper.Serialize(list);
            para.m_pValue = pValue;
            para.m_pVType = "DataTable";
            sPParams.Add(para);
            UFIDAU9CustKukaBSBSSVSPResultDTOData rtDto = proxy.Do(out MessageBase[] returnMsg, ThreadContext, sPName, sPParams.ToArray(), fromSys, operatedBy);

            result.data = "插入成功";
            return result;
        }

        string sqlCount = " select count(1)  from Kuka_VPT_RtGoodsDoc rgd     left join CBO_Supplier s on s.id=rgd.SupplierID   left join CBO_Supplier_Trl st on st.id=rgd.SupplierID   left join Base_Organization o on o.id=rgd.RcvOrg    left join Base_Organization_Trl ot on ot.id=rgd.RcvOrg    left join (  select dv.Code,dvt.Name from Base_ValueSetDef vsd    left join Base_DefineValue dv on dv.ValueSetDef=vsd.id   left join Base_DefineValue_Trl dvt on dvt.id=dv.id    where vsd.code='VP_KukaSendAddress') #tempData    on #tempData.Name=rgd.DeliveryAddress     where #tempData.Name!='直发' and rgd.RtStatus=2  ";
        private string sqlHead = "select ROW_NUMBER() over(order by rgd.id)as rownum,rgd.ID,rgd.DocNo as RtDocNo,rgd.DescFlexField_PrivateDescSeg5 as CarpoolingNo   ,s.ID as Supplier,s.code as SupplierCode,st.name as SupplierName   ,o.id as RcvOrg,o.code as RcvOrgCode,ot.name as RcvOrgName   ,rgd.DeliveryAddress as SendAddressName,#tempData.code as SendAddressCode    from Kuka_VPT_RtGoodsDoc rgd     left join CBO_Supplier s on s.id=rgd.SupplierID   left join CBO_Supplier_Trl st on st.id=rgd.SupplierID   left join Base_Organization o on o.id=rgd.RcvOrg    left join Base_Organization_Trl ot on ot.id=rgd.RcvOrg    left join (  select dv.Code,dvt.Name from Base_ValueSetDef vsd    left join Base_DefineValue dv on dv.ValueSetDef=vsd.id   left join Base_DefineValue_Trl dvt on dvt.id=dv.id    where vsd.code='VP_KukaSendAddress') #tempData    on #tempData.Name=rgd.DeliveryAddress     where #tempData.Name!='直发' and rgd.RtStatus=2  ";
        string sqlLine = "select rgd.id as RtGoodsDoc,rgdl.ItemID as Item,im.code as ItemCode,im.name as ItemName   ,rgdl.ConfirmQty1 as PlanQty from Kuka_VPT_RtGoodsDoc rgd     left join CBO_Supplier s on s.id=rgd.SupplierID   left join CBO_Supplier_Trl st on st.id=rgd.SupplierID   left join Base_Organization o on o.id=rgd.RcvOrg    left join Base_Organization_Trl ot on ot.id=rgd.RcvOrg    left join (  select dv.Code,dvt.Name from Base_ValueSetDef vsd    left join Base_DefineValue dv on dv.ValueSetDef=vsd.id   left join Base_DefineValue_Trl dvt on dvt.id=dv.id    where vsd.code='VP_KukaSendAddress') #tempData    on #tempData.Name=rgd.DeliveryAddress left join Kuka_VPT_RtGoodsDocLine rgdl on rgd.id=rgdl.RtGoodsDoc left join CBO_ItemMaster im on im.id= rgdl.ItemId  where #tempData.Name!='直发' and rgd.RtStatus=2";
        private string sqlSOPage = "select ROW_NUMBER() over(order by rgd.id)as rownum,rgd.id from Kuka_VPT_RtGoodsDoc rgd     left join CBO_Supplier s on s.id=rgd.SupplierID   left join CBO_Supplier_Trl st on st.id=rgd.SupplierID   left join Base_Organization o on o.id=rgd.RcvOrg    left join Base_Organization_Trl ot on ot.id=rgd.RcvOrg    left join (  select dv.Code,dvt.Name from Base_ValueSetDef vsd    left join Base_DefineValue dv on dv.ValueSetDef=vsd.id   left join Base_DefineValue_Trl dvt on dvt.id=dv.id    where vsd.code='VP_KukaSendAddress') #tempData    on #tempData.Name=rgd.DeliveryAddress     where #tempData.Name!='直发' and rgd.RtStatus=2 ";
        public RetModel<List<RtGoodsDocInfo>> GetRtGoodsDocInfo(RecModel<ItemInfoQuery> param)
        {
            RetModel<List<RtGoodsDocInfo>> result = new RetModel<List<RtGoodsDocInfo>>();
            result.code = "0";
            result.message = "0";

            List<SqlParameter> listParam = new List<SqlParameter>();
            StringBuilder sqlHeadS = new StringBuilder(this.sqlHead);
            StringBuilder sqlLineS = new StringBuilder(this.sqlLine);
            StringBuilder sqlSOPage = new StringBuilder();
            StringBuilder sqlCount = new StringBuilder(this.sqlCount);
            StringBuilder sqlExcute = new StringBuilder(this.sqlSOPage);
            if (param.data != null)
            {
                if (param.data.startTime.HasValue)
                {
                    sqlLineS.Append(" and rgd.ModifiedOn>=@startTime");
                    sqlHeadS.Append(" and rgd.ModifiedOn>=@startTime");
                    sqlCount.Append(" and rgd.ModifiedOn>=@startTime");
                    sqlExcute.Append(" and rgd.ModifiedOn>=@startTime");
                    //sqlExcute.Append(" and rgd.ModifiedOn>=@startTime");
                    listParam.Add(new SqlParameter("startTime", param.data.startTime));
                }
                if (param.data.endTime.HasValue)
                {
                    //sqlExcute.Append(" and rgd.ModifiedOn<@endTime");
                    sqlLineS.Append(" and rgd.ModifiedOn<@endTime");
                    sqlHeadS.Append(" and rgd.ModifiedOn<@endTime");
                    sqlCount.Append(" and rgd.ModifiedOn<@endTime");
                    sqlExcute.Append(" and rgd.ModifiedOn<@endTime");
                    listParam.Add(new SqlParameter("endTime", param.data.endTime));
                }
                sqlSOPage.Append("select ID into #TempA from (");
                sqlSOPage.Append(sqlExcute);
                sqlSOPage.Append(") t");

                if (param.data.pageSize != 0)
                {
                    sqlSOPage.Append(" where rownum>@skip and rownum<=@Take ");
                    listParam.Add(new SqlParameter("skip", param.data.pageIndex * param.data.pageSize));
                    listParam.Add(new SqlParameter("Take", (param.data.pageIndex + 1) * param.data.pageSize));
                    sqlHeadS.Append(" and rgd.id in (select ID from #TempA)");
                    sqlLineS.Append(" and rgd.id in (select ID from #TempA)");
                }
            }
            
             StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.AppendLine(sqlSOPage.ToString());
            sqlQuery.AppendLine(sqlHeadS.ToString());
            sqlQuery.AppendLine(sqlLineS.ToString());
            result.message = DbHelperSQL.QueryCountOnly(sqlCount.ToString(), listParam).ToString();
            var dataSet = DbHelperSQL.QueryDataSet(sqlQuery.ToString(), listParam);
            var dataHead = ExtendMethod.ToDataList<RtGoodsDocInfo>(dataSet.Tables[0]);
            var dataLine = ExtendMethod.ToDataList<RtGoodsDocLineInfo>(dataSet.Tables[1]);
            Dictionary<long, List<RtGoodsDocLineInfo>> map = new Dictionary<long, List<RtGoodsDocLineInfo>>();
            foreach (RtGoodsDocLineInfo line in dataLine)
            {
                if (map.ContainsKey(line.RtGoodsDoc))
                {
                    map[line.RtGoodsDoc].Add(line);
                }
                else
                {
                    map.Add(line.RtGoodsDoc, new List<RtGoodsDocLineInfo>() { line });
                }
            }
            foreach (RtGoodsDocInfo head in dataHead)
            {
                if (map.ContainsKey(head.ID))
                {
                    head.RtGoodsDocLines = map[head.ID];
                }
                else
                {
                    head.RtGoodsDocLines = new List<RtGoodsDocLineInfo>();
                }
            }
            result.data = dataHead;
            return result;
        }
    }
}
