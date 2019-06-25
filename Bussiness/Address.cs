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
    public class Address
    {
        public RetModel<List<AddressInfo>> GetAddressInfo(RecModel<ItemInfoQuery> param)
        {
            RetModel<List<AddressInfo>> result = new RetModel<List<AddressInfo>>();
            result.code = "0";
            result.message = "0";
            string str = "select * from (select ROW_NUMBER() over(order by dv.ModifiedOn)as rownum,dv.ID,dv.code,dvt.Name,dv.ModifiedOn from dbo.Base_DefineValue dv left join dbo.Base_DefineValue_Trl dvt on dvt.id = dv.id left join dbo.Base_ValueSetDef vsd on  vsd.id = dv.ValueSetDef where vsd.id = 1004008154268399 {0}) t";
            string strCount = "select Count(1) from dbo.Base_DefineValue dv left join dbo.Base_DefineValue_Trl dvt on dvt.id = dv.id left join dbo.Base_ValueSetDef vsd on  vsd.id = dv.ValueSetDef where vsd.id = 1004008154268399";
            List<SqlParameter> listParam = new List<SqlParameter>();
            string strQuery = "";
            if (param.data != null)
            {
                
                if (param.data.startTime.HasValue)
                {
                    strQuery += " and dv.ModifiedOn>=@startTime";
                    listParam.Add(new SqlParameter("startTime", param.data.startTime));
                }
                if (param.data.endTime.HasValue)
                {
                    strQuery += " and dv.ModifiedOn<@endTime";
                    listParam.Add(new SqlParameter("endTime", param.data.endTime));
                }
                strCount += strQuery;
                str = string.Format(str, strQuery);
                
                if (param.data.pageSize != 0)
                {
                    str += " where rownum>@skip and rownum<=@Take";
                    listParam.Add(new SqlParameter("skip", param.data.pageIndex * param.data.pageSize));
                    listParam.Add(new SqlParameter("Take", (param.data.pageIndex + 1) * param.data.pageSize));
                }
            }            
            result.message = DbHelperSQL.QueryCountOnly(strCount, listParam).ToString();
            var dataTable = DbHelperSQL.Query(str, listParam);
            var data = ExtendMethod.ToDataList<AddressInfo>(dataTable);
            result.data = data;
            return result;
        }
    }
}
