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
        /// Start Convert
        /// </summary>
        /// <param name="hosCd"></param>
        public void StartConvert(BaseInfo baseInfo)
        {

            mdParkService = new MDPARKService(TARGET_DB);
            mdParkService.WorkingInfo += MdParkService_WorkingInfo;
            mdParkService.StartConvert(baseInfo);

            this.baseInfo = baseInfo;


            Logger.Logger.INFO("BYEONGCOMService StartConvert");
            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, "BYEONGCOMService StartConvert");


            //진료자료
            ConvertDiagnosisData convertDiagnosisData = new ConvertDiagnosisData(mdParkService);
            convertDiagnosisData.ConvertData();

            //차트자료
            ConvertChartData convertChartData = new ConvertChartData(mdParkService);
            convertChartData.Convert();

            //부가자료
            ConvertAdditionalData convertAdditionalData = new ConvertAdditionalData(mdParkService);
            convertAdditionalData.Convert();


            //기초자료
            ConvertDefaultData convertDefaultData = new ConvertDefaultData(mdParkService);
            convertDefaultData.Convert();



            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, "BYEONGCOMService EndConvert");


        }
        
       


        #region Convert Function Base
        public void Convert_(string tDbFileName, string tableName)
        {
            using (Data.DatabaseFactory factory = new Data.DatabaseFactory())
            {
                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환시작", tableName));

                List<TAcCarInsuHist> lstTarget = new List<TAcCarInsuHist>();


                #region select
                factory.DatabaseFactoryAccess(tDbFileName);
                string strSql = ReadQuery.GetInstance(fileName).GetQueryText(string.Format("{0}.{1}", tDbFileName, tableName));


                #endregion

                DataSet ds = factory.ExecuteDataSet(strSql, CommandType.Text, null);

                TAcCarInsuHist item = null;

                #region convert
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    item = new TAcCarInsuHist();

                    lstTarget.Add(item);

                }

                #endregion


                mdParkService.InsertInfo(lstTarget);
                //return lstAcPtntInfo;
                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환종료", tableName));
            }
        }

        #endregion

    }
}
