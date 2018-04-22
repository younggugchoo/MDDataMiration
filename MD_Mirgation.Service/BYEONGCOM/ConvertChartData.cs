using MD_DataMigration.Service.MDPARK;
using MD_DataMigration.Service.MDPARK.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_DataMigration.Service.BYEONGCOM
{
    public class ConvertChartData
    {
        private const string TARGET_DB = "MariaDbMDPark";
        private const string fileName = "sql-byeongcom.xml";

        public event LogEventHandler WorkingInfo;

        
        private MDPARKService mdParkService;
        public ConvertChartData(MDPARKService mDPARKService)
        {
            this.mdParkService = mDPARKService;
        }

        public void Convert()
        {
            List<string> orderChartFiles = DynamicDbFileList("챠트");

            //챠트.진단명
            foreach (string dbFile in orderChartFiles)
            {
                //ConvertPtntOrderList(Path.GetFileNameWithoutExtension(dbFile), "챠트", "진단명");
            }

            foreach (string dbFile in orderChartFiles)
            {
                //ConvertPtntOrderList(dbFile, "처방");
            }

            foreach (string dbFile in orderChartFiles)
            {
                //ConvertPtntOrderList(dbFile, "처방메모");
            }

            foreach (string dbFile in orderChartFiles)
            {
                //ConvertPtntOrderList(dbFile, "특정내역");
            }


            //처방전.처방
            //YYMM 목록 Loop
            List<string> orderDBFiles = DynamicDbFileList("처방전");

            foreach (string dbFile in orderDBFiles)
            {
                //ConvertPtntOrderList(dbFile, "처방");
                ConvertPtntOrderList(Path.GetFileNameWithoutExtension(dbFile), "처방전", "처방");
            }

            foreach (string dbFile in orderDBFiles)
            {
                //ConvertPtntOrderList(dbFile, "원내주사");
            }

            foreach (string dbFile in orderDBFiles)
            {
                //ConvertPtntOrderList(dbFile, "특정내역");
            }
        }

        private List<string> DynamicDbFileList(string firstName)
        {
            List<string> resultList = new List<string>();

            string rootPath = ConfigurationManager.AppSettings.Get("byengcomRootPath");
            string path = rootPath + "\\" + ConfigurationManager.AppSettings.Get("MSAccessPathChartData");

            string[] fileLists = Directory.GetFiles(path, string.Format("{0}*.mdb", firstName));


            resultList = fileLists.ToList<string>();

            return resultList;
        }

        #region //챠트자료 변환

        /// <summary>
        /// 처방전.처방
        /// 환자처방내역
        /// </summary>
        /// <param name="tDbFileName"></param>
        /// <param name="tableName"></param>
        private void ConvertPtntOrderList(string tDbFileName, string dbFileM,  string tableName)
        {
            using (Data.DatabaseFactory factory = new Data.DatabaseFactory())
            {
                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환시작", tableName));

                List<TAcCarInsuHist> lstTarget = new List<TAcCarInsuHist>();


                #region select
                factory.DatabaseFactoryAccess(tDbFileName);


                string strSql = ReadQuery.GetInstance(fileName).GetQueryText(string.Format("{0}.{1}", dbFileM, tableName));


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
