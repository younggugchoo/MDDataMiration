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
    public class MDPARKService: IDisposable
    {
        string factoryName = "";
        Data.DatabaseFactory factory;

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

        #region DataInsert

        /// <summary>
        /// 환자정보 입력
        /// </summary>
        /// <param name="acPntnInfo"></param>
        public void InsertPntnInfo(List<AcPntnInfo> acPntnInfos)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (Data.DatabaseFactory factory = new Data.DatabaseFactory(factoryName))
                    {
                        foreach (AcPntnInfo item in acPntnInfos)
                        {
                            factory.ExecuteNonQuery(InsertPntnInfoSql(), InsertPntnInfoParameter(item));
                        }
                    }

                    //scope.Complete();
                }
                
            }
            catch(Exception ex)
            {
                
            }
        }

        public string InsertPntnInfoSql()
        {
            string strSql = @"
                    
                        insert into t_ac_ptnt_info
                        (
                            ptnt_id
                            , hos_cd
                            , ptnt_nm
                        )values
                        (
                            (SELECT LPAD(max(ptnt_id) + 1, 8, '0') as ptnt_id FROM t_ac_ptnt_info ALIAS_FOR_SUBQUERY) 
                            , @hos_cd
                            , @ptnt_nm
                        )
                ";

            return strSql;
        }

        public MySqlParameter [] InsertPntnInfoParameter(AcPntnInfo actPntnInfo)
        {
            MySqlParameter[] parameter = new MySqlParameter[]
            {
                new MySqlParameter("@hos_cd", actPntnInfo.HosCd)
                , new MySqlParameter("@ptnt_nm", actPntnInfo.PtntNm)

            };

            return parameter;
        }

        #endregion

        #region //Dispose

        public void Dispose()
        {

        }
        #endregion
    }
}
