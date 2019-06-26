using MPS.Bussiness.Custom;
using MPS.Bussiness.U9Service;
using MPS.Model;
using MPS.Model.TMSModel;
using System;
using System.Collections.Generic;
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
    }
}
