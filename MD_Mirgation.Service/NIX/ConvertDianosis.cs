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
    ///  진단 데이터 변환
    /// 
    /// </summary>
    public class ConvertDianosis : IDisposable
    {

        public event LogEventHandler WorkingInfo;
        private MDPARKService mdParkService;
  
        private string strYear = "";

        public ConvertDianosis(MDPARKService mDPARKService)
        {
            this.mdParkService = mDPARKService;
        }


        public void ConvertData(int year)
        {
            strYear = year.ToString();

            for (int i = 1; i < 13; i++)
            {
                ConvertTMdDx(i.ToString("00"));
            }
        }


        private void ConvertTMdDx(string month)
        {
            string strSql = ReadQuery.GetInstance(mdParkService.SourceSQLFile).GetQueryText(string.Format("ConvertChart.ConvertTMdDx"));

            strSql = strSql.Replace("$YYYY$", strYear).Replace("$YYMM$", strYear.Substring(2, 2) + month);

            List<TMdDx> lstTMdDx = new List<TMdDx>();
            int ptntId = 0;
            int rcvId = 0;

            using (Data.DatabaseFactory factory = new Data.DatabaseFactory(mdParkService.SourceDBName))
            {
                DbDataReader dr = factory.ExecuteReader(strSql, CommandType.Text, null);
                if (dr.HasRows)
                {
                    TMdDx mdDx = null;

                    while (dr.Read())
                    {
                        try
                        {
                            ptntId = mdParkService.GetPtntIdMdPark(dr["Code"].ToStringTrim());
                        }
                        catch (DuplicateNameException ex)
                        {
                            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("챠트번호 : {0} 1개이상이 존재합니다.", dr["Code"].ToStringTrim()));
                            Logger.Logger.INFO(string.Format("챠트번호 : {0} 1개이상이 존재합니다..", dr["ChtNo"].ToStringTrim()));
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

                        // NIX 진단컬럼의 순번(12개) 만큼 LOOP
                        for (int i = 1; i < 13; i++)
                        {
                            if (dr["Code" + i.ToString()].ToStringTrim().Equals("")) continue;
                            mdDx = new TMdDx();

                            mdDx.RcvId = rcvId;

                            mdDx.DzCd = dr["Code" + i.ToString()].ToStringTrim();
                            

                            mdDx.DzNm = dr["Nm" + i.ToString()].ToStringTrim();

                            mdDx.MainYn = i==1?"Y":"N"; // dr["순번"].ToString() == "1" ? "Y" : "N"; //정의필요
                            mdDx.LawDzGb = ""; //정의필요
                            mdDx.ReportYn = ""; //정의필요

                            mdDx.InsDt = dr["Ymd"].ToStringTrim();
                            mdDx.InsId = "TRN";
                            mdDx.InsIp = "0.0.0.0";
                            mdDx.UpdDt = DateTime.Now.ToString();
                            mdDx.UpdId = "TRN";
                            mdDx.UpdIp = "0.0.0.0";
                            mdDx.UseYn = "Y";

                            lstTMdDx.Add(mdDx);
                        }
                    }
                }

                mdParkService.ExecuteInsertData(lstTMdDx);

                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환종료", "ConvertTMdDx"));
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
        // ~ConvertDianosis() {
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
