using MPS.Bussiness.U9Service;
using MPS.Model;
using MPS.Model.TMSModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MPS.Controllers
{
    public class TMSController : ApiController
    {
        /// <summary>
        /// TMS插入U9中间表各个环节时间节点信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public object InsertReqInfo(RecModel<List<TMSReqInfo>> param)
        {
            RetModel<String> retModel = new RetModel<String>();
            try
            {
                Bussiness.TMSReqInfoBuss tms = new Bussiness.TMSReqInfoBuss();
                retModel = tms.InsertTMSReqInfo(param.data);
            }
            catch (Exception e)
            {
                retModel.message = Common.GetExceptionMessage(e);
                retModel.code = "-1";
            }
            return retModel;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public object RtGoodsDocInfo(RecModel<ItemInfoQuery> param)
        {
            RetModel<List<RtGoodsDocInfo>> retModel = new RetModel<List<RtGoodsDocInfo>>();
            try
            {
                Bussiness.TMSReqInfoBuss tms = new Bussiness.TMSReqInfoBuss();
                retModel = tms.GetRtGoodsDocInfo(param);
            }
            catch (Exception e)
            {
                retModel.message = Common.GetExceptionMessage(e);
                retModel.code = "-1";
            }
            return retModel;
        }
    }
}
