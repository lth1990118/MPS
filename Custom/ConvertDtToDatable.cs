using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Custom
{
    public class ConvertDtToDatable
    {
        public static List<T> TableToResult<T>(DataTable table)
        {
            List<T> reuslts = new List<T>();
            Type entitytype = typeof(T);
            PropertyInfo[] tempinfos = entitytype.GetProperties();
            FieldInfo[] tempfieldinfos = entitytype.GetFields();
            List<PropertyInfo> infos = new List<PropertyInfo>();
            List<FieldInfo> fieldinfos = new List<FieldInfo>();
            foreach (PropertyInfo info in tempinfos)
            {
                String name = info.Name;
                if (table.Columns.Contains(name))
                {
                    infos.Add(info);
                }
            }
            foreach (FieldInfo info in tempfieldinfos)
            {
                String name = info.Name;
                if (table.Columns.Contains(name))
                {
                    fieldinfos.Add(info);
                }
            }
            foreach (DataRow row in table.Rows)
            {
                T result = Activator.CreateInstance<T>();
                foreach (PropertyInfo info in infos)
                {
                    String name = info.Name;
                    object value = ConvertVlaue(row[name], info.PropertyType);
                    if (value != null)
                        info.SetValue(result, value, null);
                }
                foreach (FieldInfo info in fieldinfos)
                {
                    String name = info.Name;
                    object value = ConvertVlaue(row[name], info.FieldType);
                    if (value != null)
                        info.SetValue(result, value);
                }
                reuslts.Add(result);
            }
            return reuslts;
        }
        private static Object ConvertVlaue(object value, Type conversionType)
        {
            if (value == null || value == DBNull.Value)
            {
                return null;
            }
            Type valuetype = conversionType;
            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                Type[] types = conversionType.GetGenericArguments();
                if (types.Length == 0)
                {
                    throw new Exception("泛型类型里面的参数为空");
                }
                valuetype = types[0];
            }
            if (valuetype.Equals(typeof(String)))
            {
                return value.ObjToString();
            }
            else if (valuetype.Equals(typeof(Int32)))
            {
                return value.ObjToInt32Null();
            }
            else if (valuetype.Equals(typeof(Int64)))
            {
                return value.ObjToInt64Null();
            }
            else if (valuetype.Equals(typeof(Decimal)))
            {
                return value.ObjToDecimalNull();
            }
            else if (valuetype.Equals(typeof(Boolean)))
            {
                return value.ObjToBooleanNull();
            }
            else if (valuetype.Equals(typeof(DateTime)))
            {
                return value.ObjToDateTimeNull();
            }
            else {
               
            }

            return null;
        }
    }
}
