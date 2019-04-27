using MD_DataMigration.Service.MDPARK;
using MD_DataMigration.Service.UISARANG.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_DataMigration.Service.UISARANG
{
    public class UISARANGService: IConvert, IDisposable
    {
        private const string TARGET_DB = "MariaDbMDPark";

        public event LogEventHandler WorkingInfo;
        public event EventHandler Convert_Completed;

        private BaseInfo baseInfo;

        private MDPARKService mdParkService;

        

        public void Dispose()
        {
            //throw new NotImplementedException();
        }


        #region 테스트코드
        public void TestConnection()
        {
            using (Data.DatabaseFactory factory = new Data.DatabaseFactory("syBaseAnywhere"))
            {
                //DbDataReader dr = factory.ExecuteReader("SELECT TOP 10 * FROM SMPSUGA", CommandType.Text, null);

                //if (dr.HasRows)
                //{
                //    while (dr.Read())
                //    {
                //        Console.WriteLine(dr["SEP_H"].ToString());
                //    }   
                //}

                DataSet ds = factory.ExecuteDataSet("SELECT TOP 10 * FROM SMPSUGA", CommandType.Text);

                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Console.WriteLine(r["SEP_H"]);
                }

            }
        }

        public DataSet RetrieveTables()
        {
            using (Data.DatabaseFactory factory = new Data.DatabaseFactory("syBaseAnywhere"))
            {
               
                DataSet ds = factory.ExecuteDataSet(@"
                                        select 
                                          grp_table_name as TABLE_NAME
                                          , max(table_id) as TABLE_ID
                                          , max(isYearly) as IS_YEARLY
                                          , cast(avg(cnt) as int) as AVG_CNT
                                        from
                                        (
                                          select
                                            table_name
                                            , table_id
                                            , count as cnt
                                            , case when isnumeric(substring(table_name, len(table_name) - 3, len(table_name))) = 1
                                                then  substring(table_name, 1, len(table_name) - 4) 
                                                else table_name
                                              end as grp_table_name
                                            , case when isnumeric(substring(table_name, len(table_name) - 3, len(table_name))) = 1
                                                then  'Y'
                                                else 'N'
                                              end as isYearly
                                          from systable
                                          where count > 0
                                        )a
                                        group by grp_table_name
                                        order by grp_table_name", CommandType.Text);

                return ds;

            }
        }

        public DataSet RetrieveColumns(string tableId)
        {

            using (Data.DatabaseFactory factory = new Data.DatabaseFactory("syBaseAnywhere"))
            {

                DataSet ds = factory.ExecuteDataSet( string.Format("SELECT COLUMN_NAME, '' DESCRIPTION FROM SYSCOLUMN WHERE table_id = {0}", tableId), CommandType.Text);

                return ds;

            }
            
        }
        #endregion

        public void StartConvert(BaseInfo baseInfo)
        {
            this.baseInfo = baseInfo;

            mdParkService = new MDPARKService();
            mdParkService.WorkingInfo += MdParkService_WorkingInfo;

            mdParkService.Convert_Completed += MdParkService_Convert_Completed;

            mdParkService.StartConvert(baseInfo);


            Logger.Logger.INFO("UISARANG StartConvert");
            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, "UISARANG StartConvert");

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
                try
                {
                    //MD 접수데이터 초기화
                    mdParkService.dtTMnRcv = null;

                    //MD 처방데이터 초기화
                    mdParkService.dtTMnRcvPsb = null;

                    //접수
                    List<JSO> jsos = null;

                    workItem = baseInfo.ConvertItems.FirstOrDefault(x => x == "TMnRcv");

                    if (workItem != null)
                    {
                        using (ConvertReceipt convertReceipt = new ConvertReceipt(mdParkService))
                        {
                            jsos = convertReceipt.ConvertData(i);
                        }
                    }


                    //증상
                    workItem = baseInfo.ConvertItems.FirstOrDefault(x => x == "TMdSympt");

                    if (workItem != null)
                    {
                        using (ConvertSymptom convertSymptom = new ConvertSymptom(mdParkService))
                        {
                            convertSymptom.ConvertData(i, jsos);
                        }
                    }

                    //진단
                    workItem = baseInfo.ConvertItems.FirstOrDefault(x => x == "TMdDx");

                    if (workItem != null)
                    {
                        using (ConvertDianosis convertDianosis = new ConvertDianosis(mdParkService))
                        {

                            convertDianosis.ConvertData(i, jsos);
                        }
                    }

                    //처방 (줄단위 메모 포함)
                    workItem = baseInfo.ConvertItems.FirstOrDefault(x => x == "TMdPsb");

                    if (workItem != null)
                    {
                        using (ConvertPrescription convertPrescription = new ConvertPrescription(mdParkService))
                        {
                            convertPrescription.ConvertData(i, jsos);
                        }
                    }
                }
                catch(Exception ex)
                {
                    WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, ex.StackTrace);
                  
                    continue;
                }
                
            }

            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, "UISARANG EndConvert");

            MdParkService_Convert_Completed(null, null);
        }

   

        private void MdParkService_Convert_Completed(object sender, EventArgs e)
        {
            Convert_Completed(null, null);
        }

        private void MdParkService_WorkingInfo(CommonStatic.WORK_RESULT workResult, string message)
        {
            WorkingInfo?.Invoke(workResult, message);
        }

        
    }
}
