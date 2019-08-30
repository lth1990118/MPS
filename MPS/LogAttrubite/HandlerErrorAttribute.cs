
using MPS.Model;
using System;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace NFine.Web
{
    public class HandlerErrorAttribute : HandleErrorAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = 200;

            RetModel<string> retModel = new RetModel<string>()
            {
                code = "-1",
                message = context.Exception.Message
            };            
            string msg = Newtonsoft.Json.JsonConvert.SerializeObject(retModel);
            context.Result = new ContentResult { Content = msg };

        }
        private void WriteLog(ExceptionContext context)
        {
            if (context == null)
                return;
            
            try
            {
               
            }
            catch (Exception ex){

            }
        }
    }
}