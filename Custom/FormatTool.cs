using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom
{
    public static class FormatTool
    {
        public static String ObjToString(this object obj)
        {
            if (obj == null)
            {
                return String.Empty;
            }
            return obj.ToString();
        }
        public static bool IsInvalidSql(this object obj)
        {
            String s = obj.ObjToString();
            if (s.Contains(",") || s.Contains(";") || s.Contains("'"))
            {
                return true;
            }
            return false;
        }
        public static bool IsNullOrEmpty(this object obj)
        {
            if (obj == null)
            {
                return true;
            }
            if (obj == DBNull.Value)
            {
                return true;
            }
            String s = obj.ToString();
            if (s.Length == 0)
            {
                return true;
            }
            return false;
        }
        public static bool IsNullOrZero(this long? obj)
        {
            if (obj.HasValue)
            {
                return obj.Value < 1;
            }
            else
            {
                return true;
            }
        }
        public static bool IsNullOrZero(this int? obj)
        {
            if (obj.HasValue)
            {
                return obj.Value < 1;
            }
            else
            {
                return true;
            }
        }
        public static bool IsNullOrWriteSpace(this object obj)
        {
            if (obj.IsNullOrEmpty())
            {
                return true;
            }
            if (obj.ToString().Trim().Length == 0)
            {
                return true;
            }
            return false;
        }
        public static bool IsNullOrCountZero(this ICollection obj)
        {
            if (obj == null || obj.Count == 0)
            {
                return true;
            }
            return false;
        }
        public static bool IsNullOrRowsZero(this DataTable obj)
        {
            if (obj == null || obj.Rows.Count == 0)
            {
                return true;
            }
            return false;
        }
        public static Int32? ObjToInt32Null(this object obj)
        {
            if (obj == null)
            {
                return null;
            }
            int i;
            String s = obj.ToString();
            if (Int32.TryParse(s, out i))
            {
                return i;
            }
            bool b;
            if (bool.TryParse(s, out b))
            {
                if (b)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return null;
        }
        public static Int32 ObjToInt32(this object obj, int defaultvalue)
        {
            if (obj == null)
            {
                return defaultvalue;
            }
            int i;
            String s = obj.ToString();
            if (Int32.TryParse(s, out i))
            {
                return i;
            }
            bool b;
            if (bool.TryParse(s, out b))
            {
                if (b)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return defaultvalue;
        }

        public static Int64? ObjToInt64Null(this object obj)
        {
            if (obj == null)
            {
                return null;
            }
            long i;
            String s = obj.ToString();
            if (Int64.TryParse(s, out i))
            {
                return i;
            }
            return null;
        }
        public static Int64 ObjToInt64(this object obj, long defaultvalue)
        {
            if (obj == null)
            {
                return defaultvalue;
            }
            long i;
            String s = obj.ToString();
            if (Int64.TryParse(s, out i))
            {
                return i;
            }
            return defaultvalue;
        }
        public static Boolean? ObjToBooleanNull(this object obj)
        {
            if (obj == null)
            {
                return null;
            }
            bool value;
            String s = obj.ToString();
            if (bool.TryParse(s, out value))
            {
                return value;
            }
            int i;
            if (int.TryParse(s, out i))
            {
                if (i > 0)
                {
                    return true;
                }
                return false;
            }
            return null;
        }
        public static decimal ObjToDecimal(this object obj, decimal defaultvalue)
        {
            if (obj == null)
            {
                return defaultvalue;
            }
            decimal d;
            String s = obj.ToString();
            if (Decimal.TryParse(s, out d))
            {
                return d;
            }
            return defaultvalue;
        }
        public static decimal? ObjToDecimalNull(this object obj)
        {
            if (obj == null)
            {
                return null;
            }
            decimal d;
            String s = obj.ToString();
            if (Decimal.TryParse(s, out d))
            {
                return d;
            }
            return null;
        }
        public static Boolean ObjToBoolean(this object obj, Boolean defaultvalue)
        {
            if (obj == null)
            {
                return defaultvalue;
            }
            bool value;
            String s = obj.ToString();
            if (bool.TryParse(s, out value))
            {
                return value;
            }
            int i;
            if (int.TryParse(s, out i))
            {
                if (i > 0)
                {
                    return true;
                }
                return false;
            }
            return defaultvalue;
        }
        public static DateTime ObjToDateTime(this object obj)
        {
            if (obj == null)
            {
                return System.Data.SqlTypes.SqlDateTime.MinValue.Value;
            }
            try
            {
                return Convert.ToDateTime(obj);
            }
            catch
            {
                return System.Data.SqlTypes.SqlDateTime.MinValue.Value;
            }
        }
        public static DateTime? ObjToDateTimeNull(this object obj)
        {
            if (obj == null)
            {
                return null;
            }
            try
            {
                return Convert.ToDateTime(obj);
            }
            catch
            {
                return null;
            }
        }

        
    }
}
