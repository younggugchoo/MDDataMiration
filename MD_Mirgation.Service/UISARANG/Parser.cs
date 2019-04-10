using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MD_DataMigration.Service.UISARANG
{
    public class Parser
    {
        public static List<T> ConvertParserData<T>(string filePath) where T : class, new()
        {
            string line;
            List<T> convertResult = new List<T>();
            int idx = 0;
            //파일읽기
            try
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(filePath, Encoding.Default))
                {

                    try
                    {
                        // 파일을 라인단위로 읽어서 파싱실행                  
                        while ((line = file.ReadLine()) != null)
                        {
                            List<string> colsData = TextParsing(line); //1개의 컬럼결과 반환

                            T obj = new T();

                            //if (colsData.Count != obj.GetType().GetProperties().Count())
                            //{
                            //    throw new KeyNotFoundException();
                            //}

                            for (int i = 0; i < colsData.Count; i++)
                            {
                                if (obj.GetType().GetProperties().Count() - 1 < i) break;
                                var prop = obj.GetType().GetProperties()[i];
                                PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                                propertyInfo.SetValue(obj, colsData[i].Replace("'", "").Replace("\\x0d\\x0a", Environment.NewLine));
                            }
                            convertResult.Add(obj);
                        }

                        return convertResult;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                throw ex;
            }

            
                //return null;
            
        }


        /// <summary>
        /// 구분자 기준으로 column parsing
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private static List<string> TextParsing(string source)
        {

            List<string> resultList = new List<string>();

            try
            {
                string[] parse = source.Split(',');

                StringBuilder sbTemp = new StringBuilder();

                for (int i = 0; i < parse.Length; i++)
                {

                    if (parse[i].Length > 0)
                    {
                        if (parse[i].Substring(0, 1).Equals("'") && parse[i].Substring(parse[i].Length - 1, 1).Equals("'")) // 'data'
                        {
                            resultList.Add(parse[i]);

                        }
                        else if (parse[i].Substring(0, 1).Equals("'") && !parse[i].Substring(parse[i].Length - 1, 1).Equals("'")) // 'data
                        {
                            for (int j = i; i < parse.Length; j++)
                            {

                                if (parse[j].Length > 0)
                                {
                                    if (parse[j].Substring(parse[j].Length - 1, 1).Equals("'"))
                                    {
                                        sbTemp.Append(parse[j]);
                                        i = j;
                                        resultList.Add(sbTemp.ToString());
                                        sbTemp.Clear();
                                        break;
                                    }

                                    sbTemp.Append(parse[j]);
                                    sbTemp.Append(",");
                                }

                            }
                        }

                        else if (!parse[i].Substring(0, 1).Equals("'") && !parse[i].Substring(parse[i].Length - 1, 1).Equals("'")) // data (숫자)
                        {
                            resultList.Add(parse[i]);
                        }
                    }
                    else
                    {
                        resultList.Add(parse[i]);
                    }

                }

            }

            catch (Exception ex)
            {
                throw ex;
            }
            return resultList;
        }
    }
}
