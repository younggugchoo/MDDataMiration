using MD_DataMigration.Service.MDPARK.model;
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
    public class MDPARKService : IDisposable, IConvert
    {
        BaseInfo baseInfo;
        string factoryName = "";
        private const string TARGET_DB = "MariaDbMDPark";
        Data.DatabaseFactory factory;

        public event LogEventHandler WorkingInfo;
        public event EventHandler Convert_Completed;



        //변환된 환자목록
        public List<TAcPtnt> convertedTAcPtntInfos = null;

        //변환된 접수데이터
        public List<TMnRcv> convertedTMnRcvInfos = null;

        public DataTable dtTMnRcv { get; set; }

        public DataTable dtTMnRcvPsb { get; set; }

        public DataTable dtTMnRcvLastRcvId { get; set; }

        public MDPARKService()
        {
            //if (!value.Equals(""))
            //{
            //    this.factoryName = value;
            //    factory = new Data.DatabaseFactory(value);
            //}

            this.factoryName = "MariaDbMDPark";
            factory = new Data.DatabaseFactory(TARGET_DB);
            
        }

        public string TargetDBName
        {
            get
            {
                return TARGET_DB;
            }
        }


        public string SourceDBName { get; set; }
        public string SourceSQLFile { get; set; }



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
                where table_schema = 'emrtest'
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
                            where table_schema = 'emrtest'
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

                    
                    param.Add(new MySqlParameter("@" + CommonStatic.ToUnderscoreCase(p.Name), p.GetValue(obj) ));
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

        public void ExecuteInsertData<T>(List<T> data)
        {
            string sql = "";


            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, string.Format("변환대상 수:{0}", data.Count));
            Logger.Logger.INFO(string.Format("변환대상 수:{0}", data.Count));

            
            int cnt = 0;
            if (data.Count == 0) return;


            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.CURRENT_WORK, data[0].GetType().Name);
            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.TARGET_COUNT, data.Count.ToString());


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

                        //Logger.Logger.INFO(item.ToString());
                        //factory.ExecuteNonQuery(InsertPntnInfoSql(), InsertPntnInfoParameter(item));
                        //WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.SUCCESS, string.Format("success {0}", item.PtntId));

                        cnt++;
                        if (cnt % 100 == 0)
                        {
                            Logger.Logger.INFO(string.Format("{0}개 행 적용됨.", cnt));
                            
                        }
                        WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.CURRENT_COUNT, cnt.ToString());

                    }
                    catch (Exception ex)
                    {
                        //변환실패 목록 저장
                        WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("Error InsertInfo {0} ", ex.Message));
                        Logger.Logger.INFO(ex.Message);
                    }
                }
            }

            //scope.Complete();
            Logger.Logger.INFO(string.Format("{0}개 행 적용됨.", cnt));
            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.SUCCESS, data[0].GetType().Name);

        }

        #region 병컴 데이터 변환 관련 함수

        /// <summary>
        /// 병컴데이터에서 이관된 환자의 Ptnt_id 조회
        /// </summary>
        /// <param name="hosCd"></param>
        /// <param name="chartNum"></param>
        /// <returns></returns>
        public int retrievePtntIdFromByeongcom(string chartNum)
        {
            int ptntId = 0;

            string sql = "";

            sql = string.Format("SELECT ptnt_id" +
                " FROM t_ac_ptnt" +
                " WHERE hos_cd='{0}' " +
                "   AND ptnt_cd='{1}'", GetBaseInfo.HosCd, chartNum);



            using (Data.DatabaseFactory factory = new Data.DatabaseFactory(factoryName))
            {
                DataSet ds = factory.ExecuteDataSet(sql);

                if (ds != null)
                {

                    if (ds.Tables[0].Rows.Count > 0) {
                        if (ds.Tables[0].Rows.Count > 1) throw new DuplicateNameException();


                        ptntId = Convert.ToInt32(ds.Tables[0].Rows[0]["ptnt_id"]);
                    }
                }
            }

            return ptntId;
        }

        /// <summary>
        /// 마지막 진료일자의 접수번호조회
        /// </summary>
        /// <param name="ptntId"></param>
        /// <returns></returns>
        public int GetLastRcvId(int ptntId)
        {  
            string sql = "";
            if (dtTMnRcvLastRcvId == null)
            {
                sql = string.Format(
                    "SELECT " +
                    "   ptnt_id, max(rcv_id) as rcv_id" +
                    " FROM t_mn_rcv" +
                    " WHERE hos_cd='{0}' " +
                    " GROUP BY ptnt_id" +
                    "", GetBaseInfo.HosCd);

                using (Data.DatabaseFactory factory = new Data.DatabaseFactory(factoryName))
                {
                    dtTMnRcvLastRcvId = factory.ExecuteDataSet(sql).Tables[0];

                    //convertedTMnRcvInfos = dt.DataTableToList<TMnRcv>();
                }
            }

            // var dataRow = dtTMnRcv.AsEnumerable().Where(x => x.Field<int>("ptnt_id") == ptntId);
            //DataTable dt = dataRow.CopyToDataTable<DataRow>();

            //DataTable dt = dataRow.CopyToDataTable<DataRow>();

            int rcvId = 0;
            try
            {
                DataTable dt2 = dtTMnRcvLastRcvId.Select(string.Format("ptnt_id = {0}", ptntId.ToString())).CopyToDataTable();
                rcvId = Convert.ToInt32(dt2.Rows[0]["rcv_id"]);
            }
            catch (Exception ex)
            {

            }
            
            return rcvId;

        }

        /// <summary>
        /// 환자ID 조회 (MDPark ID)
        /// </summary>
        /// <param name="hosCd"></param>
        /// <returns></returns>
        private List<TAcPtnt> retrievePtntList()
        {
            int ptntId = 0;

            string sql = "";

            sql = string.Format(
                "SELECT " +
                "   ptnt_id, ptnt_cd, hos_cd, ptnt_nm" +
                " FROM t_ac_ptnt" +
                " WHERE hos_cd='{0}' ", GetBaseInfo.HosCd);


            List<TAcPtnt> acPtntInfos = null;

            using (Data.DatabaseFactory factory = new Data.DatabaseFactory(factoryName))
            {
                DataTable dt = factory.ExecuteDataSet(sql).Tables[0];

                convertedTAcPtntInfos = dt.DataTableToList<TAcPtnt>();
            }

            return acPtntInfos;
        }

        /// <summary>
        /// 챠트번호(환자번호)조회
        /// </summary>
        /// <param name="chartNum"></param>
        /// <returns></returns>
        public int GetPtntIdMdPark(string chartNum)
        {
            //return retrievePtntIdFromByeongcom(chartNum);
                       
            int ptntId = 0;

            if (convertedTAcPtntInfos == null)
            {
                retrievePtntList();
            }
            TAcPtnt acPtnt = convertedTAcPtntInfos.Where(x => x.PtntCd == chartNum).DefaultIfEmpty().First();
            
            return acPtnt == null ? 0 : acPtnt.PtntId;
        }

        /// <summary>
        /// 접수번호 조회
        /// </summary>
        /// <param name="ptntId"></param>
        /// <param name="oldRcvNo"></param>
        /// <returns></returns>
        public int GetRcvIdByOldRcvNo(int ptntId, string oldRcvNo)
        {
            string sql = "";
            if (dtTMnRcv == null)
            {


                sql = string.Format(
                    "SELECT " +
                    "   rcv_id,  ptnt_id, DATE_FORMAT(rcv_dt, '%Y-%m-%d') as rcv_dt, old_rcv_no" +
                    " FROM t_mn_rcv" +
                    " WHERE hos_cd='{0}' ", GetBaseInfo.HosCd);



                using (Data.DatabaseFactory factory = new Data.DatabaseFactory(factoryName))
                {
                    dtTMnRcv = factory.ExecuteDataSet(sql).Tables[0];

                    //convertedTMnRcvInfos = dt.DataTableToList<TMnRcv>();
                }

            }



            // var dataRow = dtTMnRcv.AsEnumerable().Where(x => x.Field<int>("ptnt_id") == ptntId);
            //DataTable dt = dataRow.CopyToDataTable<DataRow>();

            //DataTable dt = dataRow.CopyToDataTable<DataRow>();

            int rcvId = 0;
            try
            {
                DataTable dt2 = dtTMnRcv.Select(string.Format("(ptnt_id = {0}) AND (old_rcv_no = '{1}')", ptntId.ToString(), oldRcvNo)).CopyToDataTable();
                rcvId = Convert.ToInt32(dt2.Rows[0]["rcv_id"]);
            }
            catch
            {

            }


            return rcvId;
        }

        /// <summary>
        /// 접수번호 조회
        /// </summary>
        /// <param name="ptntId">mdPark의 변환된 ID</param>
        /// <param name="rcvDt">접수일자</param>
        /// <returns></returns>
        public int GetRcvId(int ptntId, string rcvDt)
        {
            /*
            string sql = "";

            int rcvId = 0;

            sql = string.Format(
                "SELECT " +
                "   rcv_id, ptnt_id, rcv_dt" +
                " FROM t_mn_rcv" +
                " WHERE hos_cd='{0}' AND ptnt_id = {1} AND DATE_FORMAT(rcv_dt,'%Y-%m-%d') = '{2}' ", GetBaseInfo.HosCd, ptntId,  rcvDt);



            using (Data.DatabaseFactory factory = new Data.DatabaseFactory(factoryName))
            {
                DataTable dt = factory.ExecuteDataSet(sql).Tables[0];

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows.Count > 1) throw new DuplicateNameException();
                        rcvId = Convert.ToInt32(dt.Rows[0]["rcv_id"]);
                    }
                
                }
            }

            return rcvId;
            */
            
            string sql = "";
            if (dtTMnRcv == null)
            {


                sql = string.Format(
                    "SELECT " +
                    "   rcv_id,  ptnt_id, DATE_FORMAT(rcv_dt, '%Y-%m-%d') as rcv_dt" +
                    " FROM t_mn_rcv" +
                    " WHERE hos_cd='{0}' ", GetBaseInfo.HosCd);



                using (Data.DatabaseFactory factory = new Data.DatabaseFactory(factoryName))
                {
                    dtTMnRcv = factory.ExecuteDataSet(sql).Tables[0];

                    //convertedTMnRcvInfos = dt.DataTableToList<TMnRcv>();
                }

            }



            // var dataRow = dtTMnRcv.AsEnumerable().Where(x => x.Field<int>("ptnt_id") == ptntId);
            //DataTable dt = dataRow.CopyToDataTable<DataRow>();

            //DataTable dt = dataRow.CopyToDataTable<DataRow>();

            int rcvId = 0;
            try
            {
                DataTable dt2 = dtTMnRcv.Select(string.Format("(ptnt_id = {0}) AND (rcv_dt = '{1}')", ptntId.ToString(), rcvDt)).CopyToDataTable();
                rcvId = Convert.ToInt32(dt2.Rows[0]["rcv_id"]);
            }
            catch
            {
               
            }
        

            return rcvId;

            /*
            var result = (from myRow in dtTMnRcv.AsEnumerable()
                         where myRow.Field<string>("ptnt_id") == ptntId.ToString() //&& myRow.Field<string>("rcv_dt") == rcvDt
                         select new
                         {
                             rcvId = (int) myRow["rcv_id"]
                         }).Take(1);

            


            foreach (var item in result)
            {

                rcvId = item.rcvId;
                break;
            }

            return rcvId;
            //TMnRcv mnRcv = convertedTMnRcvInfos.Where(x => x.PtntId == ptntId && x.RcvDt == rcvDt).DefaultIfEmpty().First();

            //return mnRcv == null ? 0 : mnRcv.RcvId;
            */

        }

        /// <summary>
        /// 처방번호 조회
        /// </summary>
        /// <param name="ptntId"></param>
        /// <param name="oldRcvNo"></param>
        /// <returns></returns>
        public int GetPsbId(int rcvId, string psbCd, string yyyymm)
        {
            int psbId = 0;

            string sql = "";
            if (dtTMnRcvPsb == null)
            {
                sql = string.Format(
                    "SELECT " +
                    "   a.rcv_id, b.psb_id, b.psb_cd " +
                    " FROM t_mn_rcv a" +
                    " join t_md_psb b on a.rcv_id = b.rcv_id" +
                    " WHERE a.hos_cd='{0}' AND DATE_FORMAT(a.rcv_dt, '%Y-%m') = '{1}' ", GetBaseInfo.HosCd, yyyymm);

                using (Data.DatabaseFactory factory = new Data.DatabaseFactory(factoryName))
                {
                    dtTMnRcvPsb = factory.ExecuteDataSet(sql).Tables[0];
                }
            }

            try
            {
                DataTable dt2 = dtTMnRcvPsb.Select(string.Format("(rcv_id = {0}) AND (psb_cd = '{1}')", rcvId.ToString(), psbCd)).CopyToDataTable();
                psbId = Convert.ToInt32(dt2.Rows[0]["psb_id"]);
            }
            catch
            {

            }

            return psbId;
        }

        public void RemoveDtTMnRcvPsb()
        {
            dtTMnRcvPsb = null;
        }

        #endregion 병컴 데이터 변환 관련 함수


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
