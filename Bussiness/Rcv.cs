using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom;
using MPS.Custom;
using MPS.Model;

namespace MPS.Bussiness
{
    public class Rcv
    {
        public RetModel<List<RcvInfo>> GetRcvInfo(RecModel<ItemInfoQuery> param)
        {
            RetModel<List<RcvInfo>> result = new RetModel<List<RcvInfo>>();
            result.code = "0";
            result.message = "0";

            DataSet ds = DbHelperSQL.ExecuteDataSet("kuka_basedata.dbo.Kuka_MPS_GetRcv", new SqlParameter[] {
                new SqlParameter("startTime",param.data.startTime==null?"":param.data.startTime.Value.ToString("yyyy-MM-dd HH:mm:ss")),
                new SqlParameter("endTime",param.data.endTime==null?"":param.data.endTime.Value.ToString("yyyy-MM-dd HH:mm:ss")),
                new SqlParameter("pageIndex",param.data.pageIndex),
                new SqlParameter("pageSize",param.data.pageSize),
                new SqlParameter("keyValue",param.data.keyValue==null?"":param.data.keyValue)
            });
            //var dataSet2 = DbHelperSQL.QueryDataSet(sqlQuery.ToString(), listParam);
            result.message = ds.Tables[0].Rows[0][0].ToString();
            var dataHead = ExtendMethod.ToDataList<RcvInfo>(ds.Tables[1]);
            var dataLine = ExtendMethod.ToDataList<RcvLineInfo>(ds.Tables[2]);
            Dictionary<long, List<RcvLineInfo>> map = new Dictionary<long, List<RcvLineInfo>>();
            foreach (RcvLineInfo line in dataLine)
            {
                if (map.ContainsKey(line.Receivement))
                {
                    map[line.Receivement].Add(line);
                }
                else
                {
                    map.Add(line.Receivement, new List<RcvLineInfo>() { line });
                }
            }
            foreach (RcvInfo head in dataHead)
            {
                if (map.ContainsKey(head.ID))
                {
                    head.RcvLines = map[head.ID];
                }
                else
                {
                    head.RcvLines = new List<RcvLineInfo>();
                }
            }
            result.data = dataHead;
            return result;
        }
    }
}
