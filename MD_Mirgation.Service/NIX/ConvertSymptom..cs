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
    /// 증상데이터 변환
    /// </summary>
    public class ConvertSymptom : IDisposable
    {

        public event LogEventHandler WorkingInfo;
        private MDPARKService mdParkService;
        private string strYear = "";

        

        public ConvertSymptom(MDPARKService mDPARKService)
        {
            this.mdParkService = mDPARKService;
        }

        public void ConvertData(int year)
        {

            strYear = year.ToString();

            ConvertTMdSympt();

            //줄단위 형식의 증상
            for (int i = 1; i < 13; i++)
            {
                //증상데이터 변환 
                //Ch_PresentYYMM 테이블에서 변환
                ConvertTMdSympt(i.ToString("00"));
            }
        }


        private void ConvertTMdSympt(string month)
        {
            string strSql = ReadQuery.GetInstance(mdParkService.SourceSQLFile).GetQueryText(string.Format("ConvertChart.ConvertTMdSympt_Ch_Present"));

            strSql = strSql.Replace("$YYYY$", strYear).Replace("$YYMM$", strYear.Substring(2, 2) + month);

            List<TMdSympt> lstTMdSympt = new List<TMdSympt>();
            int ptntId = 0;
            int rcvId = 0;
            StringBuilder sbPre = new StringBuilder();

            using (Data.DatabaseFactory factory = new Data.DatabaseFactory(mdParkService.SourceDBName))
            {
                DbDataReader dr = factory.ExecuteReader(strSql, CommandType.Text, null);
                if (dr.HasRows)
                {
                    TMdSympt mdSympt = null;

                    while (dr.Read())
                    {
                        try
                        {
                            ptntId = mdParkService.GetPtntIdMdPark(dr["Code"].ToStringTrim());
                        }
                        catch (DuplicateNameException ex)
                        {
                            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("챠트번호 : {0} 1개이상이 존재합니다.", dr["Code"].ToStringTrim()));
                            Logger.Logger.INFO(string.Format("챠트번호 : {0} 1개이상이 존재합니다..", dr["ChtNo"].ToString()));
                            continue;
                        }

                        //접수번호 조회
                        rcvId = mdParkService.GetRcvId(ptntId, dr["Ymd"].ToDateFormat());

                        if (rcvId == 0)
                        {
                            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("접수번호 : 챠트번호 [{0}] 진료일자[{1}] 존재하지 않습니다.", dr["Code"].ToStringTrim(), dr["Ymd"].ToStringTrim()));
                            Logger.Logger.INFO(string.Format("접수번호 : 챠트번호 [{0}] 진료일자[{1}] 존재하지 않습니다.", dr["Code"].ToStringTrim(), dr["Ymd"].ToStringTrim()));
                            continue;
                        }

                        // NIX 증상테이블의 (Ch_PresentYYMM) 컬럼의 순번(30개) 만큼 LOOP
                        //loop를 돌면서 한라인으로 처리 (1진료당 1건씩 입력됨)

                        sbPre.Clear();

                        for (int i = 1; i < 31; i++)
                        {
                            if (dr["Pre" + i.ToString()].ToStringTrim().Equals("")) continue;

                            sbPre.AppendLine(dr["Pre" + i.ToString()].ToStringTrim());

                        }

                        mdSympt = new TMdSympt();

                        mdSympt.RcvId = rcvId;

                        mdSympt.Sympt = sbPre.ToString(); //증상명

                        mdSympt.InsDt = dr["Ymd"].ToString();
                        mdSympt.InsId = "TRN";
                        mdSympt.InsIp = "0.0.0.0";
                        mdSympt.UpdDt = DateTime.Now.ToString();
                        mdSympt.UpdId = "TRN";
                        mdSympt.UpdIp = "0.0.0.0";
                        mdSympt.UseYn = "Y";

                        lstTMdSympt.Add(mdSympt);
                    }
                }

                mdParkService.ExecuteInsertData(lstTMdSympt);

                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환종료", "ConvertTMdSympt"));
            }
        }

        /// <summary>
        /// NixPen..Symptom
        /// </summary>
        private void ConvertTMdSympt()
        {
            string strSql = ReadQuery.GetInstance(mdParkService.SourceSQLFile).GetQueryText(string.Format("ConvertChart.ConvertTMdSympt"));
            strSql = strSql.Replace("$YYYY$", strYear);

            List<TMdSympt> lstTMdSympt = new List<TMdSympt>();
            int ptntId = 0;
            int rcvId = 0;

            using (Data.DatabaseFactory factory = new Data.DatabaseFactory(mdParkService.SourceDBName))
            {
                

                DbDataReader dr = factory.ExecuteReader(strSql, CommandType.Text, null);
                if (dr.HasRows)
                {
                    TMdSympt mdSympt = null;

                    while (dr.Read())
                    {
                        try
                        {
                            ptntId = mdParkService.GetPtntIdMdPark(dr["ChtNo"].ToStringTrim());
                        }
                        catch (DuplicateNameException ex)
                        {
                            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("챠트번호 : {0} 1개이상이 존재합니다.", dr["ChtNo"].ToStringTrim()));
                            Logger.Logger.INFO(string.Format("챠트번호 : {0} 1개이상이 존재합니다..", dr["ChtNo"].ToString()));
                            continue;
                        }

                        //접수번호 조회
                        rcvId = mdParkService.GetRcvId(ptntId, dr["Ymd"].ToDateFormat());

                        if (rcvId == 0)
                        {
                            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("접수번호 : 챠트번호 [{0}] 진료일자[{1}] 존재하지 않습니다.", dr["ChtNo"].ToStringTrim(), dr["Ymd"].ToStringTrim()));
                            Logger.Logger.INFO(string.Format("접수번호 : 챠트번호 [{0}] 진료일자[{1}] 존재하지 않습니다.", dr["ChtNo"].ToStringTrim(), dr["Ymd"].ToStringTrim()));
                            continue;
                        }

                        
                        mdSympt = new TMdSympt();

                        mdSympt.RcvId = rcvId;

                        mdSympt.Sympt = dr["Tx"].ToStringTrim();

                        mdSympt.InsDt = dr["Ymd"].ToString();
                        mdSympt.InsId = "TRN";
                        mdSympt.InsIp = "0.0.0.0";
                        mdSympt.UpdDt = DateTime.Now.ToString();
                        mdSympt.UpdId = "TRN";
                        mdSympt.UpdIp = "0.0.0.0";
                        mdSympt.UseYn = "Y";

                        lstTMdSympt.Add(mdSympt);
                        
                    }
                }

                mdParkService.ExecuteInsertData(lstTMdSympt);

                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환종료", "ConvertTMdSympt"));
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
        // ~ConvertSymptom() {
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
