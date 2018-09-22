using MD_DataMigration.Service.MDPARK;
using MD_DataMigration.Service.MDPARK.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Configuration;
using System.IO;
using System.Collections;

namespace MD_DataMigration.Service.BYEONGCOM
{
    public class BYEONGCOMService : IConvert, IDisposable
    {

        private const string TARGET_DB = "MariaDbMDPark";
        private const string fileName = "sql-byeongcom.xml";

        private BaseInfo baseInfo;

        private MDPARKService mdParkService;

        public event LogEventHandler WorkingInfo;
        public event EventHandler Convert_Completed;

        public bool deletePrevData { get; set; }

        public void Dispose()
        {

        }

        private void MdParkService_WorkingInfo(CommonStatic.WORK_RESULT workResult, string message)
        {
            WorkingInfo?.Invoke(workResult, message);
        }

        public List<string> ConvertTaretItems()
        {
            List<string> targets = new List<string>();

            targets.Add("환자정보");


            return targets;
        }


        public DbDataReader TestConnection()
        {
            DbDataReader dr = null;
            //using (Data.DatabaseFactory factory = new Data.DatabaseFactory())
            //{

            Data.DatabaseFactory factory = new Data.DatabaseFactory();
            factory.DatabaseFactoryAccess("일반서식");

            string[] restrictions1 = new string[4] { null, null, "서식내용", null };

            DataTable tt = factory.GetConnection().GetSchema("Columns", restrictions1);

            ArrayList col_Names = new ArrayList();

            for (int j = 0; j < tt.Rows.Count; j++)
            {
                string column = tt.Rows[j][3].ToString();
                col_Names.Add(column);
            }



            dr = factory.ExecuteReader("Select top 10 * FROM 서식내용", CommandType.Text, null);
            //if (dr.HasRows)
            //{
            //    while (dr.Read())
            //    {
            //        Console.WriteLine(dr["서식"].ToString());
            //    }
            //}


            //}

            return dr;
        }

        /// <summary>
        /// 테이블의 컬럼리스트 조회
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public ArrayList RetrieveTableColumnList(string dbName, string tableName)
        {
            using (Data.DatabaseFactory factory = new Data.DatabaseFactory())
            {
                factory.DatabaseFactoryAccess(dbName);

                string[] restrictions1 = new string[4] { null, null, tableName, null };

                DataTable tt = factory.GetConnection().GetSchema("Columns", restrictions1);

                ArrayList col_Names = new ArrayList();

                for (int j = 0; j < tt.Rows.Count; j++)
                {
                    string column = tt.Rows[j][3].ToString();
                    col_Names.Add(column);
                }

                return col_Names;
            }
        }

        /// <summary>
        /// 병컴 데이터 변환 시작
        /// </summary>
        /// <param name="hosCd"></param>
        public void StartConvert(BaseInfo baseInfo)
        {

            mdParkService = new MDPARKService(TARGET_DB);
            mdParkService.WorkingInfo += MdParkService_WorkingInfo;

            mdParkService.Convert_Completed += MdParkService_Convert_Completed;
            
            mdParkService.StartConvert(baseInfo);

            this.baseInfo = baseInfo;


            Logger.Logger.INFO("BYEONGCOMService StartConvert");
            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, "BYEONGCOMService StartConvert");


            //진료자료
            //환자정보,
            ConvertDiagnosisData convertDiagnosisData = new ConvertDiagnosisData(mdParkService);
            //convertDiagnosisData.ConvertData();


            //차트자료
            //접수, 증상, 진단, 처방
            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, "차트자료 StartConvert");
            ConvertChartData convertChartData = new ConvertChartData(mdParkService, this.WorkingInfo);
            convertChartData.ConvertData();
                


            /*
            //부가자료
            ConvertAdditionalData convertAdditionalData = new ConvertAdditionalData(mdParkService);
            convertAdditionalData.Convert();


            //기초자료
            ConvertDefaultData convertDefaultData = new ConvertDefaultData(mdParkService);
            convertDefaultData.Convert();
            */


            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, "BYEONGCOMService EndConvert");

            MdParkService_Convert_Completed (null,null);

        }


        public void convertDiagnosisData() { 
}

        private void MdParkService_Convert_Completed(object sender, EventArgs e)
        {
            Convert_Completed(null, null);
        }




        #region Convert Function Base
        //public void Convert_(string tDbFileName, string tableName)
        //{
        //    using (Data.DatabaseFactory factory = new Data.DatabaseFactory())
        //    {
        //        WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환시작", tableName));

        //        List<TAcCarInsuHist> lstTarget = new List<TAcCarInsuHist>();


        //        #region select
        //        factory.DatabaseFactoryAccess(tDbFileName);
        //        string strSql = ReadQuery.GetInstance(fileName).GetQueryText(string.Format("{0}.{1}", tDbFileName, tableName));


        //        #endregion

        //        DataSet ds = factory.ExecuteDataSet(strSql, CommandType.Text, null);

        //        TAcCarInsuHist item = null;

        //        #region convert
        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            item = new TAcCarInsuHist();

        //            lstTarget.Add(item);

        //        }

        //        #endregion


        //        mdParkService.InsertInfo(lstTarget);
        //        //return lstAcPtntInfo;
        //        WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환종료", tableName));
        //    }
        //}

        #endregion

    }
}
