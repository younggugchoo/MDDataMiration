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

        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<T> result = new List<T>();

            foreach (var row in table.Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, properties);
                result.Add(item);
            }

            return result;
        }

        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(System.DayOfWeek))
                {
                    DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), row[property.Name].ToString());
                    property.SetValue(item, day, null);
                }
                else
                {
                    if (row[property.Name] == DBNull.Value)
                        property.SetValue(item, null, null);
                    else
                        property.SetValue(item, row[property.Name], null);
                }
            }
            return item;
        }


        public static string ToDateFormat(this Object value)
        {

            if (value == null) return "1990-01-01";
            string str = "";
            str = value.ToStringTrim();

            str = str.Substring(0, 4) + "-" + str.Substring(4, 2) + "-" + str.Substring(6, 2);

            return str;
        }

        public static string ToStringTrim (this Object value)
        {
            if (value == null) return "";
            return value.ToString().Trim();
        }

        public static int ToInt32(this Object value)
        {
            int x = 0;

            if (value == null) return 0;

            Int32.TryParse(value.ToString(), out x) ;

            return x;


        }
    }
}
