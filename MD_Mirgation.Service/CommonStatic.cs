using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Reflection;

namespace MD_DataMigration.Service
{
    public static class CommonStatic
    {

        public enum WORK_RESULT
        {
            NONE
            , SUCCESS
            , FAIL
            , CURRENT_WORK
            , TARGET_COUNT
            , CURRENT_COUNT
        }

        public static string ConvertDataType(string type)
        {
            switch (type)
            {
                case "varchar":
                case "char":
                case "datetime":
                    return "string";

                case "decimal":
                case "int":
                    return "int";
                default:
                    return "string";
            }
        }

        /// <summary>
        /// Convert underscore to PascalCase
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToPascalCase(string value)
        {
            string ret = "";

            const string pattern = @"(-|_)\w{1}|^\w";
            return Regex.Replace(value, pattern, match => match.Value.Replace("-", string.Empty).Replace("_", string.Empty).ToUpper());
        }

        public static string ToUnderscoreCase(this string str)
        {
            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }


        /// <summary>
        /// Converts a DataTable to a list with generic objects
        /// </summary>
        /// <typeparam name="T">Generic object</typeparam>
        /// <param name="table">DataTable</param>
        /// <returns>List with generic objects</returns>
        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {

                            if (prop.GetCustomAttributes(typeof(KeyAttribute), false).Count() > 0) {
                                PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                                propertyInfo.SetValue(obj, Convert.ChangeType(row[ToUnderscoreCase(prop.Name)].ToString(), propertyInfo.PropertyType), null);
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }
    }
}
