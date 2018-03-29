using MD_DataMigration.Service.MDPARK.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
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


        /// <summary>
        /// 테이블 컬럼을 조회해서 Class Propery를 생성
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataSet CreateModelClass(string tableName)
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

                DataSet ds = factory.ExcuteDatSet(sql, CommandType.Text, parameter);


                return ds;
            }
            //return classFileText;

        }

        #region 환자정보입력

        /// <summary>
        /// 환자정보 입력
        /// </summary>
        /// <param name="acPntnInfo"></param>
        public void InsertPntnInfo(List<AcPntnInfo> acPntnInfos)
        {

            using (TransactionScope scope = new TransactionScope())
            {
                using (Data.DatabaseFactory factory = new Data.DatabaseFactory(factoryName))
                {
                    WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE,  "InsertPntnInfo");
                    foreach (AcPntnInfo item in acPntnInfos)
                    {
                        try
                        {
                            factory.ExecuteNonQuery(InsertPntnInfoSql(), InsertPntnInfoParameter(item));
                            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.SUCCESS,  string.Format("success {0}", item.PtntId));
                        }
                        catch (Exception ex)
                        {
                            //변환실패 목록 저장
                            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL,  string.Format("fail {0} : {1}", item.PtntId, ex.Message));
                        }




                    }
                }

                scope.Complete();
            }
                
            
           
        }

        /// <summary>
        /// 환자정보 입력 쿼리생성
        /// </summary>
        /// <returns></returns>
        private string InsertPntnInfoSql()
        {
            // --(SELECT LPAD(max(ptnt_id) + 1, 8, '0') as ptnt_id FROM t_ac_ptnt_info ALIAS_FOR_SUBQUERY) 
            string strSql = @"
                    
                        insert into t_ac_ptnt_info
                        (
                            ptnt_id
                            , hos_cd
                            , ptnt_nm
                        )values
                        (
                           
                             @ptnt_id
                            , @hos_cd
                            , @ptnt_nm
                        )
                ";

            return strSql;
        }

        /// <summary>
        /// 환자정보 입력 파라미터 설정
        /// </summary>
        /// <param name="actPntnInfo"></param>
        /// <returns></returns>
        private MySqlParameter [] InsertPntnInfoParameter(AcPntnInfo actPntnInfo)
        {
            MySqlParameter[] parameter = new MySqlParameter[]
            {
                new MySqlParameter("@ptnt_id", actPntnInfo.PtntId)
                , new MySqlParameter("@hos_cd", actPntnInfo.HosCd)
                , new MySqlParameter("@ptnt_nm", actPntnInfo.PtntNm)

            };

            return parameter;
        }

        #endregion

        #region //Dispose

        public void Dispose()
        {

        }

        public void StartConvert(BaseInfo baseInfo)
        {
            this.baseInfo = baseInfo;
        }
        #endregion
    }
}
