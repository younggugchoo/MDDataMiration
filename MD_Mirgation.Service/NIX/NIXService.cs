using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD_DataMigration.Service.MDPARK;
using MD_DataMigration.Service.MDPARK.model;

namespace MD_DataMigration.Service.NIX
{
    public class NIXService : IConvert, IDisposable
    {

        //private const string TARGET_DB = "MariaDbMDPark";
        private const string SOURCE_SQL = "sql-nix.xml";
        private const string SOURCE_DB = "MSSQL_NIXPEN";

        public event LogEventHandler WorkingInfo;
        public event EventHandler Convert_Completed;

        private BaseInfo baseInfo;
        private MDPARKService mdParkService;
        private DataSet dsDatabase = null;

        public void StartConvert(BaseInfo baseInfo)
        {

            //this.StartYear = 2016;
            //this.EndYear = 2017;

            this.baseInfo = baseInfo;

            mdParkService = new MDPARKService();
            mdParkService.WorkingInfo += MdParkService_WorkingInfo;

            mdParkService.Convert_Completed += MdParkService_Convert_Completed;

            mdParkService.SourceDBName = SOURCE_DB;
            mdParkService.SourceSQLFile = SOURCE_SQL;
            mdParkService.StartConvert(baseInfo);
       

            Logger.Logger.INFO("NIXService StartConvert");
            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, "NIXService StartConvert");

            dsDatabase = RetrieveDatabase();

            /*
             * 데이터 변환 
             */

            //환자정보 변환
            string workItem = baseInfo.ConvertItems.FirstOrDefault(x => x == "TAcPtnt");

            if (workItem != null)
            {
                using (ConvertPatient convertPatient = new ConvertPatient(mdParkService))
                {

                    convertPatient.ConvertData();
                }
            }

            //사용자지정 수가
            workItem = baseInfo.ConvertItems.FirstOrDefault(x => x == "TCmBsHosSet");

            if (workItem != null)
            {
                using (ConvertSugaCode convertSugacode = new ConvertSugaCode(mdParkService))
                {
                    convertSugacode.ConvertData();
                }
            }





            for (int i = baseInfo.StartYear; i < baseInfo.EndYear + 1; i++)
            {
                if (HasDatabase(i))
                {
                    //MD 접수데이터 초기화
                    mdParkService.dtTMnRcv = null;
                    //접수
                    workItem = baseInfo.ConvertItems.FirstOrDefault(x => x == "TMnRcv");

                    if (workItem != null)
                    {
                        using (ConvertReceipt convertReceipt = new ConvertReceipt(mdParkService))
                        {
                            convertReceipt.ConvertData(i);
                        }
                    }

                    //증상
                    workItem = baseInfo.ConvertItems.FirstOrDefault(x => x == "TMdSympt");

                    if (workItem != null)
                    {
                        using (ConvertSymptom convertSymptom = new ConvertSymptom(mdParkService))
                        {
                            convertSymptom.ConvertData(i);
                        }
                    }

                    //진단
                    workItem = baseInfo.ConvertItems.FirstOrDefault(x => x == "TMdDx");

                    if (workItem != null)
                    {
                        using (ConvertDianosis convertDianosis = new ConvertDianosis(mdParkService))
                        {

                            convertDianosis.ConvertData(i);
                        }
                    }

                    //처방
                    workItem = baseInfo.ConvertItems.FirstOrDefault(x => x == "TMdPsb");

                    if (workItem != null)
                    {
                        using (ConvertPrescription convertPrescription = new ConvertPrescription(mdParkService))
                        {
                            convertPrescription.ConvertData(i);
                        }
                    }


                }

                
            }
            


            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, "NIXService EndConvert");

            MdParkService_Convert_Completed(null, null);
        }


        private DataSet RetrieveDatabase()
        {
            string strSql = ReadQuery.GetInstance(mdParkService.SourceSQLFile).GetQueryText(string.Format("ConvertCommon.RetrieveDatabase"));


            using (Data.DatabaseFactory factory = new Data.DatabaseFactory(mdParkService.SourceDBName))
            {
                 DataSet ds = factory.ExecuteDataSet(strSql, CommandType.Text, null);

                return ds;
            }
        }

        /// <summary>
        /// 년도에 해당하는 데이터베이스가 존재하는지 확인
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private Boolean HasDatabase(int year)
        {
            string dbName = "NIXPEN" + year.ToString();

            var dataRow = dsDatabase.Tables[0].AsEnumerable().Where(x => x.Field<string>("name") == dbName);

            if (dataRow.ToList().Count  == 0)
                return false;
            else
                return true;
        }

        private void MdParkService_Convert_Completed(object sender, EventArgs e)
        {
            Convert_Completed(null, null);
        }

        private void MdParkService_WorkingInfo(CommonStatic.WORK_RESULT workResult, string message)
        {
            WorkingInfo?.Invoke(workResult, message);
        }

        public void Dispose()
        {

        }

        public void TestConnection()
        {
            //using (Data.DatabaseFactory factory = new Data.DatabaseFactory("MSSQL_NIXPEN"))
            //{
            //    DbDataReader dr = factory.ExecuteReader("select top 10 * from person", CommandType.Text, null);

            //    List<TAcPtnt> lstAcPtntInfo = new List<TAcPtnt>();

            //    if (dr.HasRows)
            //    {

            //        TAcPtnt acPtntInfo = null;

            //        while (dr.Read())
            //        {

            //            acPtntInfo = new TAcPtnt();
            //            Console.WriteLine(dr["code"].ToString());
            //            Logger.Logger.INFO(dr["code"].ToString());


            //            lstAcPtntInfo.Add(acPtntInfo);
            //        }
            //    }

            //    mdParkService.ExecuteInsertData(lstAcPtntInfo);
            //    //return lstAcPtntInfo;



            //    WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환종료", tableName));

            //}
        }

        public void TestConnectionParam()
        {



            using (Data.DatabaseFactory factory = new Data.DatabaseFactory("MariaDb_local"))
            {
                MySqlParameter[] parameter = new MySqlParameter[]
                {
                    new MySqlParameter("@PRICE", 100)
                    
                };

                //DbDataReader dr = factory.ExecuteReader("select * from products;", CommandType.Text, null);
                //DbDataReader dr = factory.ExecuteReader("select * from test.users;", CommandType.Text, null);
                DataSet ds = factory.ExecuteDataSet("select * from users", CommandType.Text);

                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Console.WriteLine(r["username"]);
                }

                parameter = new MySqlParameter[]
                {
                    new MySqlParameter("@USERNAME", "asfsafd")
                    , new MySqlParameter("@PASSWORD", "1234")
                    , new MySqlParameter("@ENABLED", 1)
                };

                try
                {
                    factory.ExecuteNonQuery("insert into users (username, password, enabled)values(@USERNAME, @PASSWORD, @ENABLED)", parameter);
                }
                catch
                {
                }

                //if (dr.HasRows)
                //{
                //    while (dr.Read())
                //    {                     
                //        Logger.Logger.INFO(dr["username"].ToString());
                //    }
                //}
            }

            using (Data.DatabaseFactory factory = new Data.DatabaseFactory("MSSQL_Test"))
            {
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@USE_F", "Y"),
                    new SqlParameter("@BL_CO_CD", 118)
                };

                //DbDataReader dr = factory.ExecuteReader("select top 10 * from T_MEM_M_IDV WHERE USE_F =@USE_F AND BL_CO_CD = @BL_CO_CD", CommandType.Text, parameter);
                //if (dr.HasRows)
                //{
                //    while (dr.Read())
                //    {
                //        Logger.Logger.INFO(dr["MEM_KO_NM"].ToString());
                //    }
                //}

                DataSet ds = factory.ExecuteDataSet("select top 10 * from T_MEM_M_IDV WHERE USE_F =@USE_F AND BL_CO_CD = @BL_CO_CD", CommandType.Text, parameter);

                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Console.WriteLine(r["MEM_KO_NM"]);
                }

            }
        }


    }
}
