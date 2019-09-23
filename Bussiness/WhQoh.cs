using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom;
using MPS.Custom;
using MPS.Model;

namespace MPS.Bussiness
{
    public class WhQoh
    {
        public RetModel<List<WhQohInfo>> GetWhQoh()
        {
            RetModel<List<WhQohInfo>> result = new RetModel<List<WhQohInfo>>();
            result.code = "0";
            result.message = "0";
            DataSet ds = DbHelperSQL.ExecuteDataSet("kuka_basedata.dbo.KUKA_SP_TranskucunForMPS");
            DataTable dt = ds.Tables[0];
            List<WhQohInfo> listData = ExtendMethod.ToDataList<WhQohInfo>(dt);
            result.message = listData.Count().ToString();
            result.data = listData;
            return result;
        }
    }
}
