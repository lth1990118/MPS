using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UFSoft.UBF.Service;
using UFSoft.UBF.Util.Context;

namespace MPS.Bussiness.U9Service
{
    public class Common
    {
        public static long ORG_ID = Convert.ToInt64(ConfigurationManager.AppSettings["orgID"]);
        public static string ORG_CODE = ConfigurationManager.AppSettings["orgCode"];

        public static long USER_ID = Convert.ToInt64(ConfigurationManager.AppSettings["userID"]);
        public static string USER_CODE = ConfigurationManager.AppSettings["userCode"];

        public static string ENT_CODE = ConfigurationManager.AppSettings["entCode"];
        public static string CULTURE_NAME = ConfigurationManager.AppSettings["cultureName"];
        /// <summary>
        /// 给上下文信息赋值
        /// </summary>
        /// <returns></returns>
        public static ThreadContext CreateContextObj()
        {
            // 实例化应用上下文对象
            ThreadContext thContext = new ThreadContext();
            System.Collections.Generic.Dictionary<object, object> ns = new Dictionary<object, object>();
            //ns.Add("OrgID", ORG_ID);  //组织
            //ns.Add("UserCode", USER_CODE); //用户
            //ns.Add("EntCode", ENT_CODE);
            //ns.Add("CultureName", CULTURE_NAME);         //语言

            ns.Add("OrgID", ORG_ID);  //组织 201 
                                     //ns.Add("OrgCode", orgcode);  //组织 201 
            ns.Add("UserID", USER_ID);  //用户
            ns.Add("EnterpriseID", ENT_CODE); //企业  26 测试 001    27  6月6  030 正式 010
                                                                      //ns.Add("UserCode", infos[0].FUserCode);
            ns.Add("CultureName", "zh-CN");        //语言
            ns.Add("DefaultCultureName", "zh-CN"); //语言

            thContext.nameValueHas = ns;
            return thContext;
        }

        public static ThreadContext CreateContextObj2()
        {
            // 实例化应用上下文对象
            ThreadContext thContext = new ThreadContext();
            System.Collections.Generic.Dictionary<object, object> ns = new Dictionary<object, object>();
            //EnterpriseID
            ns.Add("EnterpriseID", "010");
            ns.Add("EnterpriseCode", "010");          //企业  001
            ns.Add("EnterpriseName", "");

            ns.Add("OrgID", 1001211240687001);  //组织  1001211240687001
            ns.Add("OrgCode", 101);//组织编码  101

            ns.Add("UserCode", 1001302057948345); //用户  1001302057948345
            ns.Add("UserName", ""); //用户  1001302057948345

            ns.Add("CultureName", "zh-CN");         //语言
            ns.Add("DefaultCultureName", "zh-CN");
            ns.Add("Datetime", DateTime.Now);
            ns.Add("Support_CultureNameList", "zh-CN");

            thContext.nameValueHas = ns;
            return thContext;
        }

        /// <summary>
        /// 提取异常信息
        /// </summary>
        /// <param name="ex"></param>
        public static string GetExceptionMessage(Exception ex)
        {
            string faultMessage = "未知错误，请查看ERP日志！";
            System.TimeoutException timeoutEx = ex as System.TimeoutException;
            if (timeoutEx != null)
            {
                faultMessage = "因第一次访问ERP服务，访问超时，如避免此错误，请先启动ERP系统！";
            }
            else
            {
                FaultException<ServiceException> faultEx = ex as FaultException<ServiceException>;
                if (faultEx == null)
                {
                    faultMessage = ex.Message;
                }
                else
                {
                    ServiceException serviceEx = faultEx.Detail;
                    if (serviceEx != null && !string.IsNullOrEmpty(serviceEx.Message) && !serviceEx.Message.Equals("fault", StringComparison.OrdinalIgnoreCase))
                    {
                        // 错误信息在faultEx.Message中，请提取，
                        // 格式为"Fault:料品不能为空，请录入\n 在....."
                        int startIndex = serviceEx.Message.IndexOf(":");
                        int endIndex = serviceEx.Message.IndexOf("\n");
                        if (endIndex == -1)
                            endIndex = serviceEx.Message.Length;
                        if (endIndex > 0 && endIndex > startIndex + 1)
                        {
                            faultMessage = serviceEx.Message.Substring(startIndex + 1, endIndex - startIndex - 1);
                        }
                        else
                        {
                            faultMessage = serviceEx.Message;
                        }
                    }
                }
            }
            return faultMessage;
        }

    }

    
}
