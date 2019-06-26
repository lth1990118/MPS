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
        public object InsertReqInfo(List<TMSReqInfo> param)
        {
            RetModel<String> retModel = new RetModel<String>();
            try
            {
                Bussiness.TMSReqInfoBuss tms = new Bussiness.TMSReqInfoBuss();
                retModel = tms.InsertTMSReqInfo(param);
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
