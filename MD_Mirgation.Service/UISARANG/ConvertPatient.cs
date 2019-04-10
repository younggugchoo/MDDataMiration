using MD_DataMigration.Service.MDPARK;
using MD_DataMigration.Service.MDPARK.model;
using MD_DataMigration.Service.UISARANG.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_DataMigration.Service.UISARANG
{
    /// <summary>
    /// 의사랑 환자
    /// </summary>
    public class ConvertPatient : IDisposable
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
            string filePath = string.Format(@"{0}\PATIENT.{1}", ConfigurationManager.AppSettings.Get("uisarangRootPath"), ConfigurationManager.AppSettings.Get("uisarangFileExtension"));
            string filePath1 = string.Format(@"{0}\PATIENT1.{1}", ConfigurationManager.AppSettings.Get("uisarangRootPath"), ConfigurationManager.AppSettings.Get("uisarangFileExtension"));

            List<PATIENT> patients = Parser.ConvertParserData<PATIENT>(filePath);
            List<PATIENT1> patient1s = Parser.ConvertParserData<PATIENT1>(filePath1);

            List<TAcPtnt> lstAcPtntInfo = new List<TAcPtnt>();


            if (patients.Count > 0)
            {
                TAcPtnt acPtntInfo = null;

                foreach (var item in patients)
                {
                    if (item.pregi.Replace("-", "").Length == 13)
                    {
                        var patient1 = patient1s.Find(x => x.cno == item.cno);

                        acPtntInfo = new TAcPtnt();
                        acPtntInfo.HosCd = mdParkService.GetBaseInfo.HosCd;
                        acPtntInfo.PtntCd = item.cno;
                        acPtntInfo.PtntNm = item.patient;
                        acPtntInfo.Jumin1 = item.pregi.Substring(0, 6);
                        acPtntInfo.Jumin2 = item.pregi.Substring(7, 7);

                        acPtntInfo.Sex = item.gender; //F , M
                        acPtntInfo.BirthDy = item.birthday.Replace("-", "").ToStringTrim();
                        acPtntInfo.ZipCd = item.postnum;
                        acPtntInfo.Addr1 = item.address;
                        acPtntInfo.Addr2 = "";
                        acPtntInfo.MobileNo = patient1 != null ? patient1.tel2 : "";
                        acPtntInfo.TelNo1 = item.tel;

                        acPtntInfo.PrivInfoYn = "";
                        acPtntInfo.ChronicYn = "";
                        acPtntInfo.PregYn = "";
                        acPtntInfo.SmsYn = "";
                        acPtntInfo.PtntEmail = patient1 != null ? patient1.email : "";
                        acPtntInfo.InsuNo = item.cardnum;
                        acPtntInfo.InsuredNm = "";

                        acPtntInfo.PtntMemo = item.smemo;

                        acPtntInfo.UseYn = "Y";
                        acPtntInfo.InsDt = DateTime.Now.ToString(); //dr["Ymd"].ToStringTrim();
                        acPtntInfo.InsId = "TRN";
                        acPtntInfo.UpdId = "TRN";
                        acPtntInfo.InsIp = "0.0.0.0";
                        acPtntInfo.UpdIp = "0.0.0.0";
                        acPtntInfo.UpdDt = DateTime.Now.ToString();


                        lstAcPtntInfo.Add(acPtntInfo);
                    }
                }
            }

            mdParkService.ExecuteInsertData(lstAcPtntInfo);

            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환종료", "ConvertTAcPtntInfo"));

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