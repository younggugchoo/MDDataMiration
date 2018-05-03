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

        public ConvertDiagnosisData(MDPARKService mDPARKService)
        {
            this.mdParkService = mDPARKService;
        }

        public void ConvertData()
        {
            //환자정보 변환
            ConvertTAcPtntInfo("환자정보", "환자정보");

            //자보보험 이력
            ConvertTAcCarInsuHist("환자정보", "자보보험");

            //산재보험 이력
            ConvertTAcInsuHist("환자정보", "산재보험");

            //보험이력(보험정보)
            ConvertTAcInlcInsuHist("환자정보", "보험정보");
            //입원정보

            //진료색인(진료데이터)

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
        private void ConvertTAcPtntInfo(string tDbFileName, string tableName)
        {

            using (Data.DatabaseFactory factory = new Data.DatabaseFactory())
            {
                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환시작", tableName));

                List<TAcPtntInfo> lstAcPtntInfo = new List<TAcPtntInfo>();

                #region select
                factory.DatabaseFactoryAccess(tDbFileName);

                string strSql = ReadQuery.GetInstance(fileName).GetQueryText(string.Format("{0}.{1}", tDbFileName, tableName));

                #endregion

                DataSet ds = factory.ExecuteDataSet(strSql, System.Data.CommandType.Text, null);

                TAcPtntInfo acPtntInfo = null;

                #region convert
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    acPtntInfo = new TAcPtntInfo();
                    acPtntInfo.HosCd = mdParkService.GetBaseInfo.HosCd;
                    acPtntInfo.PtntId = dr["챠트번호"].ToString();
                    acPtntInfo.PtntNm = dr["수진자명"].ToString();
                    //AcPtntInfo.ResRegNo1 = dr["주민등록"].ToString();
                    //AcPtntInfo.ResRegNo2 = dr["주민등록"].ToString();
                    // AcPtntInfo.BirthYmd = dr["생년월일"].ToString();
                    acPtntInfo.Sex = dr["남여구분"].ToString();

                    acPtntInfo.ZipNo = dr["우편번호"].ToString();
                    acPtntInfo.Addr = dr["주소1"].ToString();
                    acPtntInfo.Addr2 = dr["주소2"].ToString();
                    acPtntInfo.MobNo = dr["휴대폰번호"].ToString();
                    acPtntInfo.TelNo1 = dr["전화번호"].ToString();
                    //AcPtntInfo.TelNm1 = dr[""].ToString();
                    //AcPtntInfo.TelNo2 = dr[""].ToString();
                    //AcPtntInfo.TelNm2 = dr[""].ToString();
                    //AcPtntInfo.TelNo3 = dr[""].ToString();
                    //AcPtntInfo.TelNm3 = dr[""].ToString();
                    acPtntInfo.IndvdlinfoAgreYn = dr["정보동의"].ToString();
                    acPtntInfo.ChdsesMngYn = dr["만성질환관리"].ToString();
                    acPtntInfo.PrgncYn = dr["임부구분"].ToString();
                    acPtntInfo.SmsRcveYn = dr["정보동의"].ToString();
                    acPtntInfo.Email = dr["전자메일"].ToString();
                    //AcPtntInfo.AboTy = dr[""].ToString(); //혈액형 ABO
                    //AcPtntInfo.Rh = dr[""].ToString();
                    //AcPtntInfo.VipYn = dr[""].ToString();
                    //AcPtntInfo.VipMemo = dr[""].ToString();
                    //AcPtntInfo.OldPtntId = dr[""].ToString();
                    //AcPtntInfo.AppUseYn = dr[""].ToString();
                    //AcPtntInfo.AlrgMemo = dr[""].ToString();
                    acPtntInfo.Memo = dr["메모1"].ToString() + "\n" + dr["메모2"].ToString();
                    //AcPtntInfo.InsId = dr[""].ToString();
                    acPtntInfo.InsDt = dr["최초접수일"].ToString();
                    //AcPtntInfo.PhotoYn = dr[""].ToString();
                    acPtntInfo.FilePath = dr["사진경로"].ToString();
                    //AcPtntInfo.ServerFileNm = dr[""].ToString();
                    //AcPtntInfo.AppUseDt = dr[""].ToString();

                    lstAcPtntInfo.Add(acPtntInfo);

                }

                #endregion

                mdParkService.InsertInfo(lstAcPtntInfo);
                //return lstAcPtntInfo;
                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환종료", tableName));

            }
        }

        /// <summary>
        /// 자보보험 이력 변환
        /// </summary>
        /// <returns></returns>
        private void ConvertTAcCarInsuHist(string tDbFileName, string tableName)
        {
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


                mdParkService.InsertInfo(lstTarget);
                //return lstAcPtntInfo;
                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환종료", tableName));
            }

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

        #endregion //환자정보

        #region //진료요약
        
        #endregion


        #endregion
    }
}
