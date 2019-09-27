using MPS.Bussiness.U9Service;
using MPS.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace MPS.LogAttrubite
{
    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        //重写基类的异常处理方法
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //异常消息Json串
            RetModel<string> retModel = new RetModel<string>();
            retModel.code = "-1";
            retModel.message = Common.GetExceptionMessage(actionExecutedContext.Exception);

            string errMsg = JsonConvert.SerializeObject(retModel);

            //系统异常码
            var oResponse = new HttpResponseMessage(HttpStatusCode.OK);
            oResponse.Content = new StringContent(errMsg);
            //oResponse.Headers.Add("errMsg", retModel.message);
            actionExecutedContext.Response = oResponse;
            bool isDebug = Convert.ToBoolean(ConfigurationManager.AppSettings["IsDebug"]);
            if (!isDebug)
            {
                try
                {
                    int RondomNum = 0;
                    Random random = new Random(Guid.NewGuid().GetHashCode());
                    RondomNum = random.Next(1000);
                    LogHelper log = LogFactory.GetLogger("logerror");
                    string url = actionExecutedContext.Request.RequestUri.AbsoluteUri;
                    string argument = Newtonsoft.Json.JsonConvert.SerializeObject(actionExecutedContext.ActionContext.ActionArguments);
                    log.Error("[" + RondomNum + "]  " + url + "\r\n 参数：" + argument + "\r\n 错误信息：" + errMsg, actionExecutedContext.Exception);
                }
                catch (Exception ex)
                {
                }
            }
            base.OnException(actionExecutedContext);
        }

    }
}