using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom;
using MPS.Custom;
using MPS.Model;

namespace MPS.Bussiness
{
    public class ASN
    {
        #region 
        //private string sqlCount = "select Count(1)  from dbo.PM_ASN asn     left join dbo.Base_Organization org on org.id=asn.org    left join (select dv.code,dvt.name from dbo.Base_DefineValue dv left join dbo.Base_DefineValue_Trl dvt on dv.id=dvt.id  	left join dbo.Base_ValueSetDef vsd on vsd.id=dv.ValueSetDef  	where vsd.code='VP_KukaSendAddress') dv on dv.code=asn.DescFlexField_PrivateDescSeg3  	  where org.code='704' ";
        //private string sql = "select ROW_NUMBER() over(order by asn.CreatedOn desc)as rownum,asn.ID, asn.CreatedBy,asn.DocNo,asn.BusinessDate,asn.Supplier_Code,dv.name as SendAddress,asn.DescFlexField_PrivateDescSeg7 as Car_Code,asn.ModifiedOn  ,concat('[',stuff(( select concat(',{\"id\":\"' ,asnl.id ,'\",\"PODocno\":\"' ,asnl.SrcDocInfo_SrcDocNo ,'\",\"DocLineNo\":\"' ,asnl.DocLineNo ,'\",\"ItemCode\":\"' ,im.code ,'\",\"Dept\":\"' ,(case when  itemed.DescFlexField_PrivateDescSeg25='亲子包'  	then '特殊产品' else tempCategory.SaleName  end),'\",\"NameSegment1\":\"' ,im.NameSegment1 ,'\",\"Volume\":\"' ,asnl.DescFlexField_PrivateDescSeg4 ,'\",\"Weight\":\"' ,asnl.DescFlexField_PrivateDescSeg6 ,'\",\"TotalVolume\":\"' ,asnl.DescFlexField_PrivateDescSeg5,'\",\"TotalWeight\":\"' ,asnl.DescFlexField_PrivateDescSeg7,'\",\"ModifiedOn\":\"' , CONVERT(varchar(100), asnl.ModifiedOn, 20) ,'\",\"ShipQty\":\"' ,asnl.ShipQtyTU,'\"','}') from dbo.PM_ASNLine asnl   inner join dbo.CBO_ItemMaster im on im.id=asnl.ItemInfo_ItemID    left join dbo.Kuka_BS_ItemEd itemed on itemed.item=im.id  	  left join ( select ct.Name as SaleName,c.id from dbo.CBO_Category c   	left join dbo.[CBO_Category_Trl] as ct on (c.[ID] = ct.[ID])    	) tempCategory on tempCategory.id=im.PurchaseCategory    where asnl.ASN=asn.id  for xml path('')),1,1,''),']') as ASNLine   from dbo.PM_ASN asn     left join dbo.Base_Organization org on org.id=asn.org    left join (select dv.code,dvt.name from dbo.Base_DefineValue dv left join dbo.Base_DefineValue_Trl dvt on dv.id=dvt.id  	left join dbo.Base_ValueSetDef vsd on vsd.id=dv.ValueSetDef  	where vsd.code='VP_KukaSendAddress') dv on dv.code=asn.DescFlexField_PrivateDescSeg3  	  where org.code='704' ";
        #endregion
        private string sqlHead = " select asn.ID, asn.CreatedBy,asn.DocNo,asn.BusinessDate,asn.Supplier_Code,dv.name as SendAddress,asn.DescFlexField_PrivateDescSeg7 as Car_Code,asn.ModifiedOn    from dbo.PM_ASN asn     left join dbo.Base_Organization org on org.id=asn.org    left join (select dv.code,dvt.name from dbo.Base_DefineValue dv left join dbo.Base_DefineValue_Trl dvt on dv.id=dvt.id  	left join dbo.Base_ValueSetDef vsd on vsd.id=dv.ValueSetDef  	where vsd.code='VP_KukaSendAddress') dv on dv.code=asn.DescFlexField_PrivateDescSeg3  	  where org.code='704' ";
        private string sqlLine = "select asnl.id,asn.id as ASNID,asnl.SrcDocInfo_SrcDocNo as PODocno,asnl.DocLineNo,im.code as ItemCode,(case when  itemed.DescFlexField_PrivateDescSeg25='亲子包'  	then '特殊产品' else tempCategory.SaleName  end)as Dept,im.NameSegment1,asnl.DescFlexField_PrivateDescSeg4 as Volume, asnl.DescFlexField_PrivateDescSeg6 as Weight,asnl.DescFlexField_PrivateDescSeg5 as TotalVolume,asnl.DescFlexField_PrivateDescSeg7 as TotalWeight,asnl.ModifiedOn,asnl.ShipQtyTU as ShipQty from dbo.PM_ASN asn left join dbo.Base_Organization org on org.id= asn.org    left join (select dv.code, dvt.name from dbo.Base_DefineValue dv left join dbo.Base_DefineValue_Trl dvt on dv.id= dvt.id     left join dbo.Base_ValueSetDef vsd on vsd.id= dv.ValueSetDef      where vsd.code= 'VP_KukaSendAddress') dv on dv.code=asn.DescFlexField_PrivateDescSeg3 left join dbo.PM_ASNLine asnl on asnl.ASN= asn.id inner join dbo.CBO_ItemMaster im on im.id= asnl.ItemInfo_ItemID    left join dbo.Kuka_BS_ItemEd itemed on itemed.item= im.id       left join (select ct.Name as SaleName, c.id from dbo.CBO_Category c    left join dbo.[CBO_Category_Trl] as ct on (c.[ID] = ct.[ID])     ) tempCategory on tempCategory.id=im.PurchaseCategory where org.code='704'";
        private string sqlCount = "select Count(1)  from dbo.PM_ASN asn     left join dbo.Base_Organization org on org.id=asn.org    left join (select dv.code,dvt.name from dbo.Base_DefineValue dv left join dbo.Base_DefineValue_Trl dvt on dv.id=dvt.id  	left join dbo.Base_ValueSetDef vsd on vsd.id=dv.ValueSetDef  	where vsd.code='VP_KukaSendAddress') dv on dv.code=asn.DescFlexField_PrivateDescSeg3  	  where org.code='704'";
        private string sqlSOPage = "select ROW_NUMBER() over(order by asn.id)as rownum,asn.id  from dbo.PM_ASN asn left join dbo.Base_Organization org on org.id=asn.org    left join (select dv.code,dvt.name from dbo.Base_DefineValue dv left join dbo.Base_DefineValue_Trl dvt on dv.id=dvt.id  left join dbo.Base_ValueSetDef vsd on vsd.id=dv.ValueSetDef where vsd.code='VP_KukaSendAddress') dv on dv.code=asn.DescFlexField_PrivateDescSeg3  where org.code='704'";
        public RetModel<List<ASNInfo>> GetASNInfo(RecModel<ItemInfoQuery> param)
        {
            RetModel<List<ASNInfo>> result = new RetModel<List<ASNInfo>>();
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
                    sqlLineS.Append(" and asn.ModifiedOn>=@startTime");
                    sqlHeadS.Append(" and asn.ModifiedOn>=@startTime");
                    sqlCount.Append(" and asn.ModifiedOn>=@startTime");
                    sqlExcute.Append(" and asn.ModifiedOn>=@startTime");
                    listParam.Add(new SqlParameter("startTime", param.data.startTime));
                }
                if (param.data.endTime.HasValue)
                {
                    sqlLineS.Append(" and asn.ModifiedOn<@endTime");
                    sqlHeadS.Append(" and asn.ModifiedOn<@endTime");
                    sqlCount.Append(" and asn.ModifiedOn<@endTime");
                    sqlExcute.Append(" and asn.ModifiedOn<@endTime");
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
                    sqlHeadS.Append(" and asn.id in (select ID from #TempA)");
                    sqlLineS.Append(" and asn.id in (select ID from #TempA)");
                }
            }
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.AppendLine(sqlSOPage.ToString());
            sqlQuery.AppendLine(sqlHeadS.ToString());
            sqlQuery.AppendLine(sqlLineS.ToString());
            result.message = DbHelperSQL.QueryCountOnly(sqlCount.ToString(), listParam).ToString();
            var dataSet = DbHelperSQL.QueryDataSet(sqlQuery.ToString(), listParam);
            var dataHead = ExtendMethod.ToDataList<ASNInfo>(dataSet.Tables[0]);
            var dataLine = ExtendMethod.ToDataList<ASNLineInfo>(dataSet.Tables[1]);
            Dictionary<long, List<ASNLineInfo>> map = new Dictionary<long, List<ASNLineInfo>>();
            foreach (ASNLineInfo line in dataLine)
            {
                if (map.ContainsKey(line.ASNID))
                {
                    map[line.ASNID].Add(line);
                }
                else
                {
                    map.Add(line.ASNID, new List<ASNLineInfo>() { line });
                }
            }
            foreach (ASNInfo head in dataHead)
            {
                if (map.ContainsKey(head.ID))
                {
                    head.ASNLine = map[head.ID];
                }
                else
                {
                    head.ASNLine = new List<ASNLineInfo>();
                }
            }
            result.data = dataHead;
            return result;
        }
    }
}
