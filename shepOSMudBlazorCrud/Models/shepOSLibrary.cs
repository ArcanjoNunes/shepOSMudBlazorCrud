using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace shepOS
{
    public static class shepOSLibrary
    {
        public const string REPORT_MAIN_TABLENAME = "ReportMainTable";
        public const string REPORT_USER_DATASCHEMA = "UserDataSchema";

        public static string sAppWebPath = "";

        public static T? Clone<T>(this T source)
        {
            string serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(serialized);
        }

        public static T ToObject<T>(this IDictionary<string, object> dictSource) where T : class, new()
        {
            var oObject = new T();
            var oObjectType = oObject.GetType();

            foreach (KeyValuePair<string, object> oKeyPar in dictSource)
            {
                oObjectType.GetProperty(oKeyPar.Key)?.SetValue(oObject, oKeyPar.Value, null);
            }

            return oObject;
        }

        public static IDictionary<string, object?> AsDictionary(this object classSource, BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
        {
            return classSource.GetType().GetProperties(bindingAttr).ToDictionary
            (
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(classSource, null)
            );
        }

        public static void ReloadEntity<TEntity>(this DbContext context, TEntity entity) where TEntity : class
        {
            context.Entry(entity).Reload();
        }

        public static DataTable ToDataTableSingle<T>(this T singlerecord, string dataTablename)
        {
            List<T> list = new List<T> { singlerecord };
            return ToDataTable<T>(list, dataTablename);
        }
        public static DataTable ToDataTable<T>(this IEnumerable<T> collection, string dataTablename)
        {
            DataTable dt = new DataTable(dataTablename);
            Type t = typeof(T);
            PropertyInfo[] propsList = t.GetProperties();

            foreach (PropertyInfo pi in propsList)
            {
                Type ColumnType = pi.PropertyType;
                if ((ColumnType.IsGenericType))
                {
                    ColumnType = ColumnType.GetGenericArguments()[0];
                }
                dt.Columns.Add(pi.Name, ColumnType);
            }

            foreach (T item in collection)
            {
                DataRow dr = dt.NewRow();
                
                dr.BeginEdit();
                foreach (PropertyInfo pi in propsList)
                {
                    if (pi.GetValue(item, null) != null)
                    {
                        dr[pi.Name] = pi.GetValue(item, null);
                    }
                }
                dr.EndEdit();

                dt.Rows.Add(dr);
            }
            return dt;
        }

        public static int GetLanguageID()
        {
            return System.Globalization.CultureInfo.CurrentCulture.Name.Substring(0, 2) switch
            {
                "pt" => 0,
                "es" => 1,
                "en" => 2,
                _ => 2,
            };
        }
    }
}
