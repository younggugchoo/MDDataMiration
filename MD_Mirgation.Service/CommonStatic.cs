using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MD_DataMigration.Service
{
    public static class CommonStatic
    {

        public enum WORK_RESULT
        {
            NONE
            , SUCCESS 
            , FAIL
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
                    return "";
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

    }
}
