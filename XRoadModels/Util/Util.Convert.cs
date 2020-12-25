using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Net;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using NLog;
using System.Configuration;
using System.ComponentModel;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace XRoadModels
{
    public static partial class Util
    {
        public static DateTime DefaultDate { get; } = new DateTime(1900, 1, 1);

        public static DateTime ToSafeDate(this DateTime date)
        {
            return date < DefaultDate ? DefaultDate : date;
        }

        public static string ToSafeString(this string str)
        {
            return string.IsNullOrEmpty(str) ? string.Empty : str;
        }

        public static DateTime ToDate(this DateTime? dateTime)
        {
            var date = dateTime.HasValue ? dateTime.Value.ToSafeDate() : DefaultDate;
            return date;
        }

        public static T? ToNullable<T>(this string s) where T : struct
        {
            var result = new T?();
            try
            {
                if (!string.IsNullOrEmpty(s) && s.Trim().Length > 0)
                {
                    TypeConverter conv = TypeDescriptor.GetConverter(typeof(T));
                    result = (T)conv.ConvertFrom(s);
                }
            }
            catch(Exception ex)
            {
                ex.Error();
            }
            return result;
        }

        public static void SynchronizedInvoke(this ISynchronizeInvoke sync, Action action)
        {
            if (!sync.InvokeRequired)
            {
                action();
                return;
            }

            sync.Invoke(action, new object[] { });
        }

        public static string GetDisplayDate(this object obj, bool end = false)
        {
            var properties = obj.GetType().GetProperties();
            var result = string.Empty;
            foreach (var prop in properties)
            {
                if (prop.PropertyType == typeof(DateTime?))
                {
                    if (end)
                    {
                        end = false;
                        continue;
                    }
                    var dd = prop.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                    result = dd?.Name;
                }
            }
            return result;
        }

        public static string GetDisplay(this object obj, Type type, int numElem = 0)
        {
            var properties = obj.GetType().GetProperties();
            foreach (var prop in properties)
            {
                if (numElem-- > 0) continue;
                if (prop.PropertyType == type)
                {
                    var dd = prop.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                    return dd?.Name;
                }
            }
            return string.Empty;
        }

        public static string GetFieldsData(this object response, bool isArray = false)
        {
            if (response == null) return string.Empty;
            var result = string.Empty;

            var baseFields = response.GetType().BaseType.GetProperties();

            foreach (var field in baseFields)
            {
                var val = field.GetValue(response);
                result += $"{field.Name}: {val};{Environment.NewLine}";
            }

            var fields = response.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var field in fields)
            {
                var val = field.GetValue(response);
                if (!field.PropertyType.IsArray)
                {
                    result += $"{field.Name}: {val};\t";
                    if (!isArray)
                        result += Environment.NewLine;
                }
                else
                {
                    result += $"{field.Name}: ";
                    var items = val as Array;
                    if (items == null || items.Length == 0)
                    {
                        result += $"[]{Environment.NewLine}";
                        continue;
                    }
                    result += $"[{items.Length}]{Environment.NewLine}";
                    foreach (var elem in items)
                    {
                        result += $"\t{elem.GetFieldsData(isArray: true)}";
                        result += $"{Environment.NewLine}\t-------------------------------{Environment.NewLine}";
                    }
                }
            }
            return result;
        }

        public static bool IsNullOrEmpty(this Array array)
        {
            return (array == null || array.Length == 0);
        }

    }
}