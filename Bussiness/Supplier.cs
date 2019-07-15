using Custom;
using MPS.Custom;
using MPS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Bussiness
{
    public class Supplier
    {
        private string sql = "select ROW_NUMBER() over(order by s.code)as rownum,s.id,s.code,st.Name,s.ShortName,s.Category,sc.code as Category_Code,sct.Name as Category_Name ,concat('[',stuff((select concat(',{\"id\":\"' , ss.id ,'\",\"name\":\"' ,Replace(sst.name,'\\',''),'\",\"code\":\"',ss.code,'\"}') from dbo.CBO_SupplierSite ss  left join dbo.CBO_SupplierSite_Trl sst on sst.id=ss.id where ss.Supplier=s.id   for xml path('')),1,1,''),']') as SupplierSites   ,t.id as Territory,t.code as Territory_Code,tt.Name as Territory_Name   ,s.EvaluateLevel,s.Carrier,s.IsAssistance,s.IsMISC,s.OfficialLocation,loc.code as OfficialLocation_Code,loct.name as OfficialLocation_Name   ,s.RegisterLocation,loc2.code as RegisterLocation_Code,loct2.name as RegisterLocation_Name   ,concat('[',stuff((select concat(',{\"id\":\"' , ss.id ,'\",\"name\":\"' ,Replace(sst.name,'\\',''),'\",\"code\":\"',ss.code,'\"}') from dbo.CBO_SupplierSite ss  left join dbo.CBO_SupplierSite_Trl sst on sst.id=ss.id where ss.Supplier=s.id   for xml path('')),1,1,''),']') as DefaultShipTo   ,s.TransitLeadTime,s.Effective_IsEffective as  Effective ,s.HoldDate,s.HoldReason,s.HoldUser,s.IsHoldRelease ,s.ReleaseDate,s.ReleaseReason,s.ReleaseUser ,s.State,s.StateTime,s.StateUser ,s.CreatedBy,s.CreatedOn,s.ModifiedBy,s.ModifiedOn,s.DescFlexField_PrivateDescSeg8 as SrmCode from dbo.CBO_Supplier s left join dbo.CBO_Supplier_trl st on st.id=s.id left join dbo.CBO_SupplierCategory sc on sc.id=s.Category left join dbo.CBO_SupplierCategory_Trl sct on sct.id=s.Category left join dbo.Base_Territory t on t.id=s.Territory left join dbo.Base_Territory_Trl tt on tt.id=s.Territory left join dbo.Base_Location loc on loc.id=s.OfficialLocation left join dbo.Base_Location_Trl loct on loct.id=s.OfficialLocation left join dbo.Base_Location loc2 on loc2.id=s.RegisterLocation left join dbo.Base_Location_Trl loct2 on loct2.id=s.RegisterLocation left join dbo.Base_Organization o on o.id=s.Org where 1=1 and sc.code like  '01-05-%' and o.code in('704','713') ";
        public RetModel<List<SupplierInfo>> GetSupplierInfo(RecModel<ItemInfoQuery> param)
        {
            RetModel<List<SupplierInfo>> result = new RetModel<List<SupplierInfo>>();
            result.code = "0";
            result.message = "0";

            List<SqlParameter> listParam = new List<SqlParameter>();
            StringBuilder sqlQuery = new StringBuilder();
            StringBuilder sqlExcute = new StringBuilder(this.sql);
            if (param.data != null)
            {
                if (param.data.startTime.HasValue)
                {
                    sqlExcute.Append(" and s.ModifiedOn>=@startTime");
                    listParam.Add(new SqlParameter("startTime", param.data.startTime));
                }
                if (param.data.endTime.HasValue)
                {
                    sqlExcute.Append(" and s.ModifiedOn<@endTime");
                    listParam.Add(new SqlParameter("endTime", param.data.endTime));
                }
                sqlQuery.Append("select * from (");
                sqlQuery.Append(sqlExcute);
                sqlQuery.Append(") t");

                if (param.data.pageSize != 0)
                {
                    sqlQuery.Append(" where rownum>@skip and rownum<=@Take");
                    listParam.Add(new SqlParameter("skip", param.data.pageIndex * param.data.pageSize));
                    listParam.Add(new SqlParameter("Take", (param.data.pageIndex + 1) * param.data.pageSize));
                }
            }
            else
            {
                sqlQuery = sqlExcute;
            }
            result.message = DbHelperSQL.QueryCount(sqlExcute.ToString(), listParam).ToString();
            var dataTable = DbHelperSQL.Query(sqlQuery.ToString(), listParam);
            var data = ExtendMethod.ToDataList<SupplierInfo>(dataTable);
            result.data = data;
            return result;
        }
    }
}
