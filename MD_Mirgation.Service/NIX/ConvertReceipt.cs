using MD_DataMigration.Service.MDPARK;
using MD_DataMigration.Service.MDPARK.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_DataMigration.Service.NIX
{
    /// <summary>
    /// 접수데이터 변환
    /// </summary>
    public class ConvertReceipt : IDisposable
    {

        public event LogEventHandler WorkingInfo;
        private MDPARKService mdParkService;

        private string mStrYear = "";

    

        public ConvertReceipt(MDPARKService mDPARKService)
        {
            this.mdParkService = mDPARKService;
        }

        public void ConvertData(int year)
        {
            mStrYear = year.ToString();

            ConvertTMnRcv();

            //for (int i = 1; i < 13; i++)
            //{
            //    ConvertTMnRcv(i.ToString("00"));
            //}
        }

        private void ConvertTMnRcv()
        {
            string strSql = ReadQuery.GetInstance(mdParkService.SourceSQLFile).GetQueryText(string.Format("ConvertChart.ConvertTMnRcv"));

            strSql = strSql.Replace("$YYYY$", mStrYear).Replace("$YY$", mStrYear.Substring(2,2));

            List<TMnRcv> lstTMnRcv = new List<TMnRcv>();
            int ptntId = 0;


            using (Data.DatabaseFactory factory = new Data.DatabaseFactory(mdParkService.SourceDBName))
            {
                DbDataReader dr = factory.ExecuteReader(strSql, CommandType.Text, null);
                if (dr.HasRows)
                {
                    TMnRcv mnRcv = null;

                    while (dr.Read())
                    {
                        try
                        {
                            ptntId = mdParkService.GetPtntIdMdPark(dr["Code"].ToStringTrim());
                        }
                        catch (DuplicateNameException ex)
                        {
                            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("챠트번호 : {0} 1개이상이 존재합니다.", dr["Code"].ToStringTrim()));
                            Logger.Logger.INFO(string.Format("챠트번호 : {0} 1개이상이 존재합니다..", dr["Code"].ToString()));
                            continue;
                        }

                        if (ptntId == 0)
                        {
                            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("챠트번호 : {0} 존재하지 않습니다.", dr["Code"].ToStringTrim()));
                            Logger.Logger.INFO(string.Format("챠트번호 : {0} 존재하지 않습니다.", dr["Code"].ToString()));
                            continue;
                        }

                        mnRcv = new TMnRcv();


                        //접수데이터 재정의 필요
                        mnRcv.OldRcvNo = dr["Code"].ToStringTrim() + dr["Ymd"].ToStringTrim().Replace("-", "");
                        mnRcv.PtntId = ptntId;
                        mnRcv.HosCd = mdParkService.GetBaseInfo.HosCd; //병원코드
                        mnRcv.DeptCd = Convert.ToInt32(dr["Gb2"].ToStringTrim());

                        mnRcv.UserId = dr["license"].ToStringTrim(); //retrieveUserId(dr["Ymd"].ToStringTrim().Replace("-", ""), dr["Code"].ToStringTrim(), month); //  dr["보조문자열"].ToString(); //의사면허번호

                        mnRcv.OffId = 0; //Convert.ToInt32(dr["진료과"]);
                        mnRcv.RcvDt = dr["JubsuTime"].ToStringTrim(); 

                        mnRcv.DiagType = dr["Gb4"].ToStringTrim();

                        mnRcv.ExpCd = ""; //분업예외코드
                        mnRcv.ReductCd = dr["Gb6"].ToStringTrim(); //감면코드

                        mnRcv.MedStartDt = dr["JinStartTime"].ToStringTrim();
                        mnRcv.MedEndDt = dr["JinEndTime"].ToStringTrim();
                        mnRcv.MediSec = 0;
                        mnRcv.PayDt = dr["SunapTime"].ToStringTrim();

                        //1,2,3,24,27,28,30  => 초진
                        //4,5,6,18,23,25,26,29,31 => 재진
                        mnRcv.FstMedGb = dr["tn1"].ToStringTrim(); //NIXPEN2018 -> dbo.Ch_Slip18110( Gb2 ) --> List테이블에 tn1컬럼으로 대체

                        mnRcv.MedPayYn = dr["Sw2"].ToStringTrim()=="1"?"Y":"N"; //dr["수납확인"].ToString() == "0" ? "Y" : "N";
                        mnRcv.RcvStat = "PF"; //접수상태
                        mnRcv.OldRcvNo = dr["Key"].ToStringTrim()  + "^" + dr["Code"].ToStringTrim().Replace("-", ""); //구 진료 NO

                        mnRcv.InsGb = dr["Gb1"].ToStringTrim();
                        mnRcv.OrderDt = dr["JinEndTime"].ToStringTrim(); //오더 시간
                        mnRcv.PacsId = "";


                        mnRcv.InsDt = dr["JubsuTime"].ToStringTrim();
                        mnRcv.InsId = "TRN";
                        mnRcv.InsIp = "0.0.0.0";
                        mnRcv.UpdDt = DateTime.Now.ToString();
                        mnRcv.UpdId = "TRN";
                        mnRcv.UpdIp = "0.0.0.0";
                        mnRcv.UseYn = "Y";

                        lstTMnRcv.Add(mnRcv);
                    }
                }

                mdParkService.ExecuteInsertData(lstTMnRcv);

                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환종료", "ConvertTMnRcv"));
            }
        }

        /// <summary>
        /// 접수시 의사 Licence 조회
        /// </summary>
        /// <param name="ymd"></param>
        /// <param name="code"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        private string retrieveUserId(string ymd, string code, string month)
        {
            string userId = "";
            string YYMM = ymd.Substring(2, 4);

            string strSql = ReadQuery.GetInstance(mdParkService.SourceSQLFile).GetQueryText(string.Format("ConvertChart.retrieveUserId"));

            strSql = strSql.Replace("$YYYY$", ymd.Substring(0,4)).Replace("$YYMM$", ymd.Substring(2,4));

            //strSql = strSql.Replace("$YYMM$", YYMM);

            strSql = strSql.Replace("{ymd}", ymd);
            strSql = strSql.Replace("{code}", code);

            

            using (Data.DatabaseFactory factory = new Data.DatabaseFactory(mdParkService.SourceDBName))
            {
                DbDataReader dr = factory.ExecuteReader(strSql, CommandType.Text, null);

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        userId = dr["license"].ToStringTrim();
                    }
                }

                return userId;
            }

        }

        #region IDisposable Support
        private bool disposedValue = false; // 중복 호출을 검색하려면

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리되는 상태(관리되는 개체)를 삭제합니다.
                }

                // TODO: 관리되지 않는 리소스(관리되지 않는 개체)를 해제하고 아래의 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.

                disposedValue = true;
            }
        }

        // TODO: 위의 Dispose(bool disposing)에 관리되지 않는 리소스를 해제하는 코드가 포함되어 있는 경우에만 종료자를 재정의합니다.
        // ~ConvertReceipt() {
        //   // 이 코드를 변경하지 마세요. 위의 Dispose(bool disposing)에 정리 코드를 입력하세요.
        //   Dispose(false);
        // }

        // 삭제 가능한 패턴을 올바르게 구현하기 위해 추가된 코드입니다.
        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 위의 Dispose(bool disposing)에 정리 코드를 입력하세요.
            Dispose(true);
            // TODO: 위의 종료자가 재정의된 경우 다음 코드 줄의 주석 처리를 제거합니다.
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}
