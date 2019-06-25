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
    public class SO
    {
        //private string sql = " select ROW_NUMBER() over(order by sl.id)as rownum,sl.id,ot.Name as Org,so.docno,so.OrderBy_Code as CustomerCode  	,so.OrderBy_ShortName as CustomerName,t.name as LineType,  	(case sl.status when 0 then '草稿' when 1 then '开立' when 2 then '审核中'  	when 3 then '审核' when 4 then '自然关闭' when 5 then '短缺关闭'  	when 6 then '超额关闭' else '' end) as Status,im.code as ItemCode,ca.ID as StockCategory,ca.code as StockCategoryCode,cat.name as StockCategoryName,im.NameSegment1,im.SPECS,uomt.name as SOUOM,sl.DocLineNo  	,sl.OrderByQtyPU as OrderByQtyCU,(select max(RequireDate) from dbo.SM_SOShipLine ssl where ssl.SOline=sl.id) as DeliveryDate,t2.name as Base,so.BusinessDate as BussinessDate,so.CreatedBy,SL.ModifiedOn  	from dbo.SM_SO so  	left join dbo.SM_SOLine sl on so.id=sl.so  	left join dbo.Base_Organization o on o.id=so.org  	left join dbo.Base_Organization_Trl ot on ot.id=o.id  	left join (  	select dv.code,dvt.name from dbo.Base_DefineValue dv left join dbo.Base_DefineValue_Trl dvt on dv.id=dvt.id  left join dbo.Base_ValueSetDef vsd on vsd.id=dv.ValueSetDef where vsd.code='MO_hlx'  	) t on t.code=sl.DescFlexField_PubDescSeg14  	left join dbo.CBO_ItemMaster im on im.id=sl.ItemInfo_ItemID  	left join dbo.CBO_Category ca on ca.id=im.StockCategory   	left join dbo.CBO_Category_trl cat on cat.id=im.StockCategory   	left join dbo.Base_UOM_trl uomt on uomt.id=sl.TU	  	left join (  	select dv.code,dvt.name from dbo.Base_DefineValue dv left join dbo.Base_DefineValue_Trl dvt on dv.id=dvt.id  left join dbo.Base_ValueSetDef vsd on vsd.id=dv.ValueSetDef where vsd.code='G007'  	) t2 on t2.code=sl.DescFlexField_PrivateDescSeg22  	where 1=1 and o.code='704' and sl.status=3";
        //private string sqlCount = " select Count(1)	from dbo.SM_SO so  	left join dbo.SM_SOLine sl on so.id=sl.so  	left join dbo.Base_Organization o on o.id=so.org  	left join dbo.Base_Organization_Trl ot on ot.id=o.id  	left join (  	select dv.code,dvt.name from dbo.Base_DefineValue dv left join dbo.Base_DefineValue_Trl dvt on dv.id=dvt.id  left join dbo.Base_ValueSetDef vsd on vsd.id=dv.ValueSetDef where vsd.code='MO_hlx'  	) t on t.code=sl.DescFlexField_PubDescSeg14  	left join dbo.CBO_ItemMaster im on im.id=sl.ItemInfo_ItemID  	left join dbo.CBO_Category ca on ca.id=im.StockCategory   	left join dbo.CBO_Category_trl cat on cat.id=im.StockCategory   	left join dbo.Base_UOM_trl uomt on uomt.id=sl.TU	  	left join (  	select dv.code,dvt.name from dbo.Base_DefineValue dv left join dbo.Base_DefineValue_Trl dvt on dv.id=dvt.id  left join dbo.Base_ValueSetDef vsd on vsd.id=dv.ValueSetDef where vsd.code='G007'  	) t2 on t2.code=sl.DescFlexField_PrivateDescSeg22  	where 1=1 and o.code='704' and sl.status=3";
        private string sqlCount = "select count(1)  from dbo.SM_SO so  inner join (select so2.id from dbo.SM_SO so2   left join dbo.SM_SOLine sl on so2.id=sl.so where sl.Status=3 group by so2.id)temp  on temp.id=so.id  left join dbo.Base_Organization o on o.id=so.org  	  left join dbo.Base_Organization_Trl ot on ot.id=o.id  where 1=1 and o.code='704' ";
       

        private string sqlSOPage = "select ROW_NUMBER() over(order by so.id)as rownum,so.id  from dbo.SM_SO so  inner join (select so2.id from dbo.SM_SO so2   left join dbo.SM_SOLine sl on so2.id=sl.so where sl.Status=3 group by so2.id )temp  on temp.id=so.id  left join dbo.Base_Organization o on o.id=so.org  	  left join dbo.Base_Organization_Trl ot on ot.id=o.id  where o.code='704'";
        private string sqlHead = "select so.id,ot.Name as Org,so.docno,so.OrderBy_Code as CustomerCode,so.OrderBy_ShortName as CustomerName,so.BusinessDate as BussinessDate,so.CreatedBy,so.ModifiedOn   from dbo.SM_SO so    left join dbo.Base_Organization o on o.id=so.org  	    left join dbo.Base_Organization_Trl ot on ot.id=o.id    where 1=1 and o.code='704'";
        private string sqlLine = "select top 100 sl.id ,t.name as LineType,(case sl.status when 0 then '草稿' when 1 then '开立' when 2 then '审核中'  	when 3 then '审核' when 4 then '自然关闭' when 5 then '短缺关闭'  	when 6 then '超额关闭' else '' end)as Status,im.code as ItemCode,ca.ID as StockCategory,ca.code as StockCategoryCode  ,cat.name as StockCategoryName,im.NameSegment1,im.SPECS,uomt.name as SOUOM,sl.DocLineNo as DocLineNo,sl.OrderByQtyPU as OrderByQtyCU,shl.RequireDate as DeliveryDate,shl.SOShipLineSumInfo_SumShipedQtyPU as SalesOutQuantity,sl.OrderByQtyPU-shl.SOShipLineSumInfo_SumShipedQtyPU as SalesInQuantity,(case when sl.OrderByQtyPU - shl.SOShipLineSumInfo_SumShipedQtyPU = 0 then '全部出货' when shl.SOShipLineSumInfo_SumShipedQtyPU > 0 then '部分出库' else '未出货' end) as SalesOutStatus, sl.FinallyPriceTC as SalesPrice,sl.TotalMoneyTC as SalesAmount,t2.name as Base,sl.ModifiedOn,so.id as SOID from dbo.SM_SO so  inner join(select so2.id from dbo.SM_SO so2   left join dbo.SM_SOLine sl on so2.id= sl.so where sl.Status= 3 group by so2.id )temp on temp.id=so.id left join dbo.Base_Organization o on o.id= so.org       left join dbo.Base_Organization_Trl ot on ot.id= o.id   left join  dbo.SM_SOLine sl  on sl.SO= SO.id left join dbo.SM_SOShipline shl on shl.SOLine= sl.id and shl.ItemInfo_ItemID= sl.ItemInfo_ItemID left join (select dv.code, dvt.name from dbo.Base_DefineValue dv left join dbo.Base_DefineValue_Trl dvt on dv.id= dvt.id  left join dbo.Base_ValueSetDef vsd on vsd.id= dv.ValueSetDef where vsd.code= 'MO_hlx') t on t.code=sl.DescFlexField_PubDescSeg14 left join dbo.CBO_ItemMaster im on im.id= sl.ItemInfo_ItemID     left join dbo.CBO_Category ca on ca.id= im.StockCategory         left join dbo.CBO_Category_trl cat on cat.id= im.StockCategory       left join dbo.Base_UOM_trl uomt on uomt.id= sl.TU        left join (select dv.code, dvt.name from dbo.Base_DefineValue dv left join dbo.Base_DefineValue_Trl dvt on dv.id= dvt.id  left join dbo.Base_ValueSetDef vsd on vsd.id= dv.ValueSetDef where vsd.code= 'G007') t2 on t2.code=sl.DescFlexField_PrivateDescSeg22 where 1=1 and o.code='704' ";
        public RetModel<List<SOInfo>> GetSOLineInfo(RecModel<ItemInfoQuery> param)
        {
            RetModel<List<SOInfo>> result = new RetModel<List<SOInfo>>();
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
                    sqlLineS.Append(" and so.ModifiedOn>=@startTime");
                    sqlHeadS.Append(" and so.ModifiedOn>=@startTime");
                    sqlCount.Append(" and so.ModifiedOn>=@startTime");
                    sqlExcute.Append(" and so.ModifiedOn>=@startTime");
                    listParam.Add(new SqlParameter("startTime", param.data.startTime));
                }
                if (param.data.endTime.HasValue)
                {
                    sqlLineS.Append(" and so.ModifiedOn<@endTime");
                    sqlHeadS.Append(" and so.ModifiedOn<@endTime");
                    sqlCount.Append(" and so.ModifiedOn<@endTime");
                    sqlExcute.Append(" and so.ModifiedOn<@endTime");
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
                    sqlHeadS.Append(" and so.id in (select ID from #TempA)");
                    sqlLineS.Append(" and so.id in (select ID from #TempA)");
                }
            }
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.AppendLine(sqlSOPage.ToString());
            sqlQuery.AppendLine(sqlHeadS.ToString());
            sqlQuery.AppendLine(sqlLineS.ToString());
            result.message = DbHelperSQL.QueryCountOnly(sqlCount.ToString(), listParam).ToString();
            var dataSet = DbHelperSQL.QueryDataSet(sqlQuery.ToString(), listParam);
            var dataHead = ExtendMethod.ToDataList<SOInfo>(dataSet.Tables[0]);
            var dataLine = ExtendMethod.ToDataList<SOLineInfo>(dataSet.Tables[1]);
            Dictionary<long, List<SOLineInfo>> map = new Dictionary<long, List<SOLineInfo>>();
            foreach (SOLineInfo line in dataLine)
            {
                if (map.ContainsKey(line.SOID))
                {
                    map[line.SOID].Add(line);
                }
                else
                {
                    map.Add(line.SOID, new List<SOLineInfo>() { line });
                }
            }
            foreach (SOInfo head in dataHead)
            {
                if (map.ContainsKey(head.ID))
                {
                    head.SOLine = map[head.ID];
                }
                else
                {
                    head.SOLine = new List<SOLineInfo>();
                }
            }
            result.data = dataHead;
            return result;
        }
    }
}
