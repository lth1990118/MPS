using MPS.Bussiness.Custom;
using MPS.LogAttrubite;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

public class ActionFilter : ActionFilterAttribute
{
    private const string Key = "action";
    private int RondomNum = 0;
    private LogHelper log;
    public override void OnActionExecuting(HttpActionContext actionContext)
    {
        try
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            RondomNum = random.Next(1000);
            Stopwatch stopWatch = new Stopwatch();

            actionContext.Request.Properties[Key] = stopWatch;

            string url = actionContext.Request.RequestUri.AbsoluteUri;
            string actionName = actionContext.ActionDescriptor.ActionName;
            string argument = Newtonsoft.Json.JsonConvert.SerializeObject(actionContext.ActionArguments);
            bool isDebug = Convert.ToBoolean(ConfigurationManager.AppSettings["IsDebug"]);
            if (!isDebug|| actionName.ToUpper().Contains("CREATE"))
            {
                log = LogFactory.GetLogger("loginfo");
                log.Info("[" + RondomNum + "]  " + url + "\r\n 参数：" + argument);
            }
            stopWatch.Start();
        }
        catch {
        }

    }
    public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    {
        try
        {
            Stopwatch stopWatch = actionExecutedContext.Request.Properties[Key] as Stopwatch;

            if (stopWatch != null)
            {

                stopWatch.Stop();
                object obj = new object();
                var a = actionExecutedContext.ActionContext.Response.Content.ReadAsAsync<object>();
                if (!a.IsFaulted)
                {                    
                    //结果转为自定义消息格式
                    if (actionExecutedContext.ActionContext.ActionDescriptor.ActionName.ToUpper().Contains("CREATE"))
                    {
                        // 取得由 API 返回的资料
                        obj = actionExecutedContext.ActionContext.Response.Content.ReadAsAsync<object>().Result;
                        string json = JsonHelper.Serialize(obj);
                        log = LogFactory.GetLogger("loginfo");
                        log.Info("[" + RondomNum + "]  耗时：" + stopWatch.Elapsed.ToString() + "\r\n 返回：" + json);
                    }
                }
               
            }
        }
        catch {

        }
    }
}