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
    public class SupplySource
    {
        private string sql = "select ROW_NUMBER() over(order by ss.id)as rownum, ss.ID,ss.ModifiedOn,ss.SupplierQuota,im.id as Item,im.code as Item_Code,Im.NameSegment1,s.id as Supplier ,s.code as Supplier_code,st.Name as Supplier_Name  from dbo.CBO_SupplySource ss left join dbo.CBO_ItemMaster im on im.id=ss.itemInfo_itemID left join dbo.CBO_Supplier s on ss.SupplierInfo_Supplier=s.id left join dbo.CBO_Supplier_Trl st on ss.SupplierInfo_Supplier=st.id where 1=1";
        public RetModel<List<SupplySourceInfo>> GetSupplierInfo(RecModel<ItemInfoQuery> param)
        {
            RetModel<List<SupplySourceInfo>> result = new RetModel<List<SupplySourceInfo>>();
            result.code = "0";
            result.message = "0";

            List<SqlParameter> listParam = new List<SqlParameter>();
            StringBuilder sqlQuery = new StringBuilder();
            StringBuilder sqlExcute = new StringBuilder(this.sql);
            if (param.data != null)
            {
                if (param.data.startTime.HasValue)
                {
                    sqlExcute.Append(" and ss.ModifiedOn>=@startTime");
                    listParam.Add(new SqlParameter("startTime", param.data.startTime));
                }
                if (param.data.endTime.HasValue)
                {
                    sqlExcute.Append(" and ss.ModifiedOn<@endTime");
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
            var data = ExtendMethod.ToDataList<SupplySourceInfo>(dataTable);
            result.data = data;
            return result;
        }
    }
}
