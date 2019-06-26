using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace MPS.Bussiness.Custom
{
    public class JsonHelper
    {
        static JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        
        public static string Serialize(Object obj)
        {
            return jsSerializer.Serialize(obj);
        }
        public static T DeserializeObject<T>(String json) where T : class,new()
        {
            jsSerializer.MaxJsonLength = Int32.MaxValue;
            return jsSerializer.Deserialize<T>(json);

        }
    }
}
