using MD_DataMigration.Service.MDPARK;
using MD_DataMigration.Service.MDPARK.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_DataMigration.Service.BYEONGCOM
{
    public class ConvertDiagnosisData
    {
        private const string TARGET_DB = "MariaDbMDPark";
        private const string fileName = "sql-byeongcom.xml";

        public event LogEventHandler WorkingInfo;
        
        private MDPARKService mdParkService;

        //변환된 환자목록
        private List<TAcPtnt> convertedTAcPtntInfos = null;


        public ConvertDiagnosisData(MDPARKService mDPARKService)
        {
            this.mdParkService = mDPARKService;
        }

        public void ConvertData()
        {
            //환자정보 변환
            ConvertTAcPtntInfo();

            //자보보험 이력
            //ConvertTAcCarInsuHist("환자정보", "자보보험");

            //산재보험 이력
            //ConvertTAcInsuHist("환자정보", "산재보험");

            //보험이력(보험정보)
            //ConvertTAcInlcInsuHist("환자정보", "보험정보");
            //입원정보

            //진료색인(진료데이터)
            
           
            ConvertTMnRcv("진료색인", "진료색인");
            
            //진료소견

            //건강진단서 발급내역

            //방사선판독서

            //범용진단서

            //사망진단서

            //사산증명서

            //상해진단서

            //일반진단서

            //직장진단서

            //진단서 환경

            //진료의뢰서

            //출생증명서

            //접수검사

            //진료검사

            //체크검사

            //심전도 (환자의 심전도 검사내역)

            //백신목록

            //백신접종

            //백신접종표

            //환자의 과거력
        }



        #region //진료데이터 변환


        #region //환자정보
        /// <summary>
        /// 환자정보 변환
        /// </summary>
        private void ConvertTAcPtntInfo()
        {

            string tDbFileName = "환자정보";
            string tableName = "환자정보";

            using (Data.DatabaseFactory factory = new Data.DatabaseFactory())
            {
                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환시작", tableName));

                List<TAcPtnt> lstAcPtntInfo = new List<TAcPtnt>();

                #region select
                factory.DatabaseFactoryAccess(tDbFileName);

                string strSql = ReadQuery.GetInstance(fileName).GetQueryText(string.Format("{0}.{1}", tDbFileName, tableName));

                #endregion

                DataSet ds = factory.ExecuteDataSet(strSql, System.Data.CommandType.Text, null);

                TAcPtnt acPtntInfo = null;

                #region convert
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    acPtntInfo = new TAcPtnt();
                    acPtntInfo.HosCd = mdParkService.GetBaseInfo.HosCd;
                    acPtntInfo.PtntCd = dr["챠트번호"].ToString();
                    acPtntInfo.PtntNm = dr["수진자명"].ToString();
                    acPtntInfo.Jumin1 = dr["챠트번호"].ToString().Substring(0, 6);
                    acPtntInfo.Jumin2 = dr["챠트번호"].ToString().Substring(6, 7);


                    acPtntInfo.Sex = dr["성별"].ToString().Equals("남")?  "M":"F";
                    acPtntInfo.BirthDy = dr["생년월일"].ToString().Replace("-", "");
                    acPtntInfo.ZipCd = dr["우편번호"].ToString();
                    acPtntInfo.Addr1 = dr["주소1"].ToString();
                    acPtntInfo.Addr2 = dr["주소2"].ToString();
                    acPtntInfo.MobileNo = dr["휴대폰번호"].ToString();
                    acPtntInfo.TelNo1 = dr["전화번호"].ToString();
          
                    acPtntInfo.PrivInfoYn = dr["정보동의"].ToString().Equals("0") ? "N" : "Y";
                    acPtntInfo.ChronicYn  = dr["만성질환관리"].ToString();
                    acPtntInfo.PregYn = dr["임부구분"].ToString().Equals("0")? "N":"Y";
                    acPtntInfo.SmsYn = dr["정보동의"].ToString().Equals("0") ? "N" : "Y";
                    acPtntInfo.PtntEmail = dr["전자메일"].ToString();
                    acPtntInfo.InsuNo = dr["증번호"].ToString();
                    acPtntInfo.InsuredNm = dr["피보험자"].ToString();

                    acPtntInfo.PtntMemo = ""; //dr["메모1"].ToString() + "\n" + dr["메모2"].ToString();


                    acPtntInfo.UseYn = "Y";
                    acPtntInfo.InsDt = dr["최초접수일"].ToString();
                    acPtntInfo.InsId = "TRN";
                    acPtntInfo.UpdId = "TRN";
                    acPtntInfo.InsIp = "0.0.0.0";
                    acPtntInfo.UpdIp = "0.0.0.0";
                    acPtntInfo.UpdDt = DateTime.Now.ToString();
                    
                    
                    lstAcPtntInfo.Add(acPtntInfo);
                    
                }

                #endregion

                mdParkService.ExecuteInsertData(lstAcPtntInfo);
                //return lstAcPtntInfo;

                

                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환종료", tableName));

            }
        }

        #endregion //환자정보


        //외래접수
        /// <summary>
        /// 진료자료>진료색인>진료색인
        /// </summary>
        /// <param name="tDbFileName"></param>
        /// <param name="tableName"></param>
        private void ConvertTMnRcv(string tDbFileName, string tableName)
        {
            using (Data.DatabaseFactory factory = new Data.DatabaseFactory())
            {
                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환시작", tableName));


                


                #region select
                factory.DatabaseFactoryAccess(tDbFileName);

                //일년단위로 처리(데이터가 너무 많아 ds에 저장이 안됨.)

                DataSet dsYear = factory.ExecuteDataSet(ReadQuery.GetInstance(fileName).GetQueryText(string.Format("{0}.{1}", tDbFileName, "진료색인_날짜"))
                    , System.Data.CommandType.Text, null);

                int minYear = Convert.ToInt32(dsYear.Tables[0].Rows[0]["MIN_YEAR"]);
                int maxYear = Convert.ToInt32(dsYear.Tables[0].Rows[0]["MAX_YEAR"]);


                for (int sYear = minYear; sYear <= maxYear; sYear++)
                {
                    Logger.Logger.DEBUG(sYear.ToString());
                    //continue;

                    List<TMnRcv> lstMnRcvs = new List<TMnRcv>();
                    string strSql = ReadQuery.GetInstance(fileName).GetQueryText(string.Format("{0}.{1}", tDbFileName, tableName));

                    strSql = strSql.Replace("#{year}", sYear.ToString());

                    #endregion

                    DataSet ds = factory.ExecuteDataSet(strSql, System.Data.CommandType.Text, null);

                    TMnRcv mnRcv = null;

                    int ptntId = 0;
                    #region convert
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        mnRcv = new TMnRcv();

                        try
                        {
                            mnRcv.PtntId = mdParkService.GetPtntIdMdPark(dr["챠트번호"].ToString());
                        }
                        catch (DuplicateNameException ex)
                        {
                            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("챠트번호 : {0} 1개이상이 존재합니다.", dr["챠트번호"].ToString()));
                            Logger.Logger.INFO(string.Format("챠트번호 : {0} 1개이상이 존재합니다..", dr["챠트번호"].ToString()));
                            continue;
                        }
                        if (mnRcv.PtntId == 0)
                        {
                            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("챠트번호 : {0} 존재하지 않습니다.", dr["챠트번호"].ToString()));
                            Logger.Logger.INFO(string.Format("챠트번호 : {0} 존재하지 않습니다.", dr["챠트번호"].ToString()));
                            continue;
                        }

                        mnRcv.RcvNo = dr["챠트번호"].ToString() + dr["진료일자"].ToString().Replace("-", "");
                        mnRcv.HosCd = mdParkService.GetBaseInfo.HosCd; //병원코드
                        mnRcv.DeptId = Convert.ToInt32(dr["진료과"]);
                        mnRcv.UserId = dr["보조문자열"].ToString();
                        mnRcv.OffId = 0; //Convert.ToInt32(dr["진료과"]);
                        mnRcv.RcvDt = dr["진료일자"].ToString() + " " + dr["접수시간"].ToString();
                        mnRcv.DiagType = dr["진료구분"].ToString();

                        mnRcv.ExpCd = ""; //분업예외코드
                        mnRcv.ReductCd = ""; //감면코드

                        mnRcv.MedStartDt = dr["진료일자"].ToString();
                        mnRcv.MedEndDt = dr["진료일자"].ToString();
                        mnRcv.MediSec = 0;
                        mnRcv.PayDt = dr["진료일자"].ToString();

                        mnRcv.FstMedGb = dr["챠트초재진"].ToString();
                        mnRcv.MedPayYn = dr["수납확인"].ToString() == "0" ? "Y" : "N";
                        mnRcv.RcvStat = "PF"; //접수상태
                        mnRcv.OldRcvNo = dr["챠트번호"].ToString() + dr["진료일자"].ToString().Replace("-", ""); //구 진료 NO

                        mnRcv.InsuGb = dr["보험구분"].ToString();
                        mnRcv.OrderDt = dr["진료일자"].ToString(); //오더 시간
                        mnRcv.PacsId = "";


                        mnRcv.InsDt = dr["진료일자"].ToString();
                        mnRcv.InsId = "TRN";
                        mnRcv.InsIp = "0.0.0.0";
                        mnRcv.UpdDt = DateTime.Now.ToString();
                        mnRcv.UpdId = "TRN";
                        mnRcv.UpdIp = "0.0.0.0";
                        mnRcv.UseYn = "Y";

                        lstMnRcvs.Add(mnRcv);

                    }

                    #endregion

                    mdParkService.ExecuteInsertData(lstMnRcvs);
                    //return lstAcPtntInfo;

                }

                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환종료", tableName));

            }
        }


        /// <summary>
        /// 자보보험 이력 변환
        /// </summary>
        /// <returns></returns>
        private void ConvertTAcCarInsuHist(string tDbFileName, string tableName)
        {
            /*
            using (Data.DatabaseFactory factory = new Data.DatabaseFactory())
            {
                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환시작", tableName));

                List<TAcCarInsuHist> lstTarget = new List<TAcCarInsuHist>();


                #region select
                factory.DatabaseFactoryAccess(tDbFileName);
                string strSql = @"";


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


                mdParkService.ExecuteInsertData(lstTarget);
                //return lstAcPtntInfo;
                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환종료", tableName));
            }
            */
        }
        

        /// <summary>
        /// 산재정보
        /// </summary>
        /// <param name="tDbFileName"></param>
        /// <param name="tableName"></param>
        private void ConvertTAcInsuHist(string tDbFileName, string tableName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 보험정보
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        private void ConvertTAcInlcInsuHist(string tDbFileName, string tableName)
        {
            throw new NotImplementedException();
        }

       

        

        #endregion //진료데이터 변환
    }
}
