﻿using MD_DataMigration.Service.MDPARK.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MD_DataMigration.Service.MDPARK
{
    public class MDPARKService: IDisposable, IConvert
    {
        BaseInfo baseInfo;
        string factoryName = "";
        Data.DatabaseFactory factory;

        public event LogEventHandler WorkingInfo;
        public event EventHandler Convert_Completed;

        public MDPARKService(string value)
        {
            
            this.factoryName = value;
            factory = new Data.DatabaseFactory(value);
        }


        #region //Test
        public void TestConnection()
        {
            using (Data.DatabaseFactory factory = new Data.DatabaseFactory(factoryName))
            {
                DbDataReader dr = factory.ExecuteReader("select * from user", CommandType.Text, null);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine(dr["FIRSTNAME"].ToString());
                    }
                }

                
            }
        }
        #endregion

        #region //입력쿼리 생성, 입력 파라미터 생성 공통
        /// <summary>
        /// 테이블 컬럼을 조회해서 Class Propery를 생성
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataSet SelectColumnList(string tableName)
        {
            using (Data.DatabaseFactory factory = new Data.DatabaseFactory(factoryName))
            {
                string classFileText = "";
                string sql = @"select 
                    column_name
                    , data_type
                    , column_comment
                 from INFORMATION_SCHEMA.columns
                where table_schema = 'mdemr'
                    and table_name = @tableName
                 order by ordinal_position; ";

                MySqlParameter[] parameter = new MySqlParameter[]
                {
                    new MySqlParameter("@tableName", tableName)

                };

                DataSet ds = factory.ExecuteDataSet(sql, CommandType.Text, parameter);


                return ds;
            }
            //return classFileText;

        }

        public DataSet SelectTableList()
        {
            using(Data.DatabaseFactory factory = new Data.DatabaseFactory(factoryName))
            {
                string sql = @"select table_name
                            from information_schema.TABLES
                            where table_schema = 'mdemr'
                                and TABLE_NAME like 't_%'
                            order by table_name
                            ";

                DataSet ds = factory.ExecuteDataSet(sql);
                return ds;
                
            }
        }

        /// <summary>
        /// 파라미터 생성
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        private MySqlParameter[] InsertParameter<T>(T obj)
        {
            List<MySqlParameter> param = new List<MySqlParameter>();

            Type t = obj.GetType();
            PropertyInfo[] pi = t.GetProperties();

            foreach (PropertyInfo p in pi)
            {
                if (p.GetCustomAttribute(typeof(ColunmExceptionAttribute), true) == null)
                {
                    Logger.Logger.DEBUG(string.Format("{0} : {1} ", "@" + CommonStatic.ToUnderscoreCase(p.Name), p.GetValue(obj)));

                    param.Add(new MySqlParameter("@" + CommonStatic.ToUnderscoreCase(p.Name), p.GetValue(obj)));
                } 
                
            }


            return param.ToArray();
            //return parameter;
        }

        /// <summary>
        /// Insert sql문 생성
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        private string GenerateInsertSql<T>(T item)
        {
            // --(SELECT LPAD(max(ptnt_id) + 1, 8, '0') as ptnt_id FROM t_ac_ptnt_info ALIAS_FOR_SUBQUERY) 

            StringBuilder sbSql = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            StringBuilder sbParams = new StringBuilder();


            Type t = item.GetType();
            PropertyInfo[] pi = t.GetProperties();

            foreach (PropertyInfo p in pi)
            {
                if (p.GetCustomAttribute(typeof(ColunmExceptionAttribute), true) == null)
                {

                    sbValues.AppendFormat("{0} {1}", sbValues.Length > 0 ? "," : "", CommonStatic.ToUnderscoreCase(p.Name));
                    sbParams.AppendFormat("{0} @{1}", sbParams.Length > 0 ? "," : "", CommonStatic.ToUnderscoreCase(p.Name));
                }
            }

            sbSql.AppendFormat("insert into {0}\n", CommonStatic.ToUnderscoreCase(item.GetType().Name));
            sbSql.AppendLine("(");
            sbSql.AppendLine(sbValues.ToString());
            sbSql.AppendLine(") values");
            sbSql.AppendLine("(");
            sbSql.AppendLine(sbParams.ToString());
            sbSql.AppendLine(")");

            return sbSql.ToString();
        }
        #endregion

        public void InsertInfo<T>(List<T> data)
        {
            string sql = "";
            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, string.Format("변환대상 수:{0}", data.Count));
            using (TransactionScope scope = new TransactionScope())
            {
                using (Data.DatabaseFactory factory = new Data.DatabaseFactory(factoryName))
                {
                    WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, data[0].GetType().Name);

                    //Generate Insert sql
                    sql = GenerateInsertSql(data[0]);

                    foreach (T item in data)
                    {
                        try
                        {
                            //generate parameter datas and send sql
                            factory.ExecuteNonQuery(sql, InsertParameter(item));

                            //factory.ExecuteNonQuery(InsertPntnInfoSql(), InsertPntnInfoParameter(item));
                            //WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.SUCCESS, string.Format("success {0}", item.PtntId));
                        }
                        catch (Exception ex)
                        {
                            //변환실패 목록 저장
                            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("Error InsertInfo {0} ",  ex.Message));
                        }
                    }
                }

                scope.Complete();
                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.SUCCESS, data[0].GetType().Name);
            }
        }


        //#region 환자정보입력

        ///// <summary>
        ///// 환자정보 입력
        ///// </summary>
        ///// <param name="AcPtntInfo"></param>
        //public void InsertPntnInfo(List<AcPtntInfo> AcPtntInfos)
        //{

        //    using (TransactionScope scope = new TransactionScope())
        //    {
        //        using (Data.DatabaseFactory factory = new Data.DatabaseFactory(factoryName))
        //        {
        //            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE,  "InsertPntnInfo");
        //            foreach (AcPtntInfo item in AcPtntInfos)
        //            {
        //                try
        //                {
        //                    factory.ExecuteNonQuery(InsertPntnInfoSql(), InsertParameter(item));  

        //                    //factory.ExecuteNonQuery(InsertPntnInfoSql(), InsertPntnInfoParameter(item));
        //                    WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.SUCCESS,  string.Format("success {0}", item.PtntId));
        //                }
        //                catch (Exception ex)
        //                {
        //                    //변환실패 목록 저장
        //                    WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL,  string.Format("fail {0} : {1}", item.PtntId, ex.Message));
        //                }
        //            }
        //        }

        //        scope.Complete();
        //    }
        //}

        ///// <summary>
        ///// 환자정보 입력 쿼리생성
        ///// </summary>
        ///// <returns></returns>
        //private string InsertPntnInfoSql()
        //{
        //    // --(SELECT LPAD(max(ptnt_id) + 1, 8, '0') as ptnt_id FROM t_ac_ptnt_info ALIAS_FOR_SUBQUERY) 
        //    string strSql = @"
                    
        //                insert into t_ac_ptnt_info
        //                (
        //                    ptnt_id
        //                    , hos_cd
        //                    , ptnt_nm
        //                )values
        //                (
                           
        //                     @ptnt_id
        //                    , @hos_cd
        //                    , @ptnt_nm
        //                )
        //        ";

        //    return strSql;
        //}

        ///// <summary>
        ///// 환자정보 입력 파라미터 설정
        ///// </summary>
        ///// <param name="actPntnInfo"></param>
        ///// <returns></returns>
        //private MySqlParameter [] InsertPntnInfoParameter(AcPtntInfo actPntnInfo)
        //{
        //    MySqlParameter[] parameter = new MySqlParameter[]
        //    {
        //        new MySqlParameter("@ptnt_id", actPntnInfo.PtntId)
        //        , new MySqlParameter("@hos_cd", actPntnInfo.HosCd)
        //        , new MySqlParameter("@ptnt_nm", actPntnInfo.PtntNm)

        //    };

        //    Type t = actPntnInfo.GetType();
        //    PropertyInfo[] pi = t.GetProperties();

        //    foreach (PropertyInfo p in pi)
        //    {
                
        //        Logger.Logger.DEBUG(string.Format("{0} : {1} ", p.Name, p.GetValue(actPntnInfo)));
        //    }


        //    List<MySqlParameter> param = new List<MySqlParameter>();
        //    param.Add(new MySqlParameter("", actPntnInfo.PtntId));

        //    parameter = param.ToArray();
        //    return parameter;
        //}

        

        //#endregion

        #region //Dispose

        public void Dispose()
        {

        }

        public void StartConvert(BaseInfo baseInfo)
        {
            this.baseInfo = baseInfo;
        }

        public BaseInfo GetBaseInfo { get { return this.baseInfo; } }

        public List<string> ConvertTaretItems()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
