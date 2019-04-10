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
    /// 환자데이터 변환
    /// </summary>
    public class ConvertPatient :IDisposable
    {
        
        public event LogEventHandler WorkingInfo;

        private MDPARKService mdParkService;

        public ConvertPatient(MDPARKService mDPARKService)
        {
            this.mdParkService = mDPARKService;
        }

        //변환된 환자목록
        // private List<TAcPtnt> convertedTAcPtntInfos = null;


        public void ConvertData()
        {

            //환자정보 변환
            ConvertTAcPtntInfo();
        }

        /// <summary>
        /// 환자정보 변환
        /// </summary>
        private void ConvertTAcPtntInfo()
        {
            string strSql = ReadQuery.GetInstance(mdParkService.SourceSQLFile).GetQueryText(string.Format("ConvertPatient.ConvertTAcPtntInfo"));
            
            List<TAcPtnt> lstAcPtntInfo = new List<TAcPtnt>();

            using (Data.DatabaseFactory factory = new Data.DatabaseFactory(mdParkService.SourceDBName))
            {
                DbDataReader dr = factory.ExecuteReader(strSql, CommandType.Text, null);
                if (dr.HasRows)
                {
                    TAcPtnt acPtntInfo = null;

                    while (dr.Read())
                    {

                        acPtntInfo = new TAcPtnt();
                        acPtntInfo.HosCd = mdParkService.GetBaseInfo.HosCd;
                        acPtntInfo.PtntCd = dr["Code"].ToStringTrim();
                        acPtntInfo.PtntNm = dr["Nm"].ToStringTrim();
                        acPtntInfo.Jumin1 = dr["Jumin1"].ToStringTrim();
                        acPtntInfo.Jumin2 = dr["Jumin2"].ToStringTrim();


                        acPtntInfo.Sex = dr["Gender"].ToStringTrim();
                        acPtntInfo.BirthDy = dr["BirthDay"].ToStringTrim();
                        acPtntInfo.ZipCd = dr["Post"].ToStringTrim();
                        acPtntInfo.Addr1 = dr["Addr1"].ToStringTrim();
                        acPtntInfo.Addr2 = dr["Addr2"].ToStringTrim();
                        acPtntInfo.MobileNo = dr["Hpp"].ToStringTrim();
                        acPtntInfo.TelNo1 = dr["Tel"].ToStringTrim();

                        acPtntInfo.PrivInfoYn = "";
                        acPtntInfo.ChronicYn = "";
                        acPtntInfo.PregYn = "";
                        acPtntInfo.SmsYn = "";
                        acPtntInfo.PtntEmail = dr["EMail"].ToStringTrim();
                        acPtntInfo.InsuNo = dr["JhId5"].ToStringTrim();
                        acPtntInfo.InsuredNm = "";

                        acPtntInfo.PtntMemo = dr["Mm"].ToStringTrim(); //dr["메모1"].ToString() + "\n" + dr["메모2"].ToString();


                        acPtntInfo.UseYn = "Y";
                        acPtntInfo.InsDt = dr["Ymd"].ToStringTrim();
                        acPtntInfo.InsId = "TRN";
                        acPtntInfo.UpdId = "TRN";
                        acPtntInfo.InsIp = "0.0.0.0";
                        acPtntInfo.UpdIp = "0.0.0.0";
                        acPtntInfo.UpdDt = DateTime.Now.ToString();


                        lstAcPtntInfo.Add(acPtntInfo);
                    }
                }

                mdParkService.ExecuteInsertData(lstAcPtntInfo);

                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환종료", "ConvertTAcPtntInfo"));
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
        // ~ConvertPatient() {
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
