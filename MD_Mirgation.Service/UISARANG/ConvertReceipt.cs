using MD_DataMigration.Service.MDPARK;
using MD_DataMigration.Service.MDPARK.model;
using MD_DataMigration.Service.UISARANG.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_DataMigration.Service.UISARANG
{
    /// <summary>
    /// 의사랑 접수
    /// </summary>
    public class ConvertReceipt : IDisposable
    {
        public event LogEventHandler WorkingInfo;

        private MDPARKService mdParkService;


        public ConvertReceipt(MDPARKService mDPARKService)
        {
            this.mdParkService = mDPARKService;
        }


        /// <summary>
        /// 접수데이터 변환
        /// </summary>
        /// <param name="year">년도</param>
        public List<JSO> ConvertData(int year)
        {
            return ConvertTMnRcv(year);
        }


        private List<JSO> ConvertTMnRcv(int year)
        {
            
            string filePath = string.Format(@"{0}\JSO{1}.{2}", ConfigurationManager.AppSettings.Get("uisarangRootPath"), year, ConfigurationManager.AppSettings.Get("uisarangFileExtension"));

            try
            {
                List<JSO> convertedList = Parser.ConvertParserData<JSO>(filePath);

                List<TMnRcv> lstTMnRcv = new List<TMnRcv>();
                int ptntId = 0;


                /* Tablename : JSOYYYY
                 * Name	Datatype	Comment
                    ISDISREGDATA	varchar(1024) : 산정특례코드	

                 */

                if (convertedList.Count > 0)
                {
                    TMnRcv mnRcv = null;

                    foreach (var item in convertedList)
                    {
                        try
                        {
                            ptntId = mdParkService.GetPtntIdMdPark(item.cno);
                        }
                        catch (DuplicateNameException ex)
                        {
                            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("챠트번호 : {0} 1개이상이 존재합니다.", item.cno));
                            Logger.Logger.INFO(string.Format("챠트번호 : {0} 1개이상이 존재합니다..", item.cno));
                            continue;
                        }

                        if (ptntId == 0)
                        {
                            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("챠트번호 : {0} 존재하지 않습니다.", item.cno));
                            Logger.Logger.INFO(string.Format("챠트번호 : {0} 존재하지 않습니다.", item.cno));
                            continue;
                        }

                        mnRcv = new TMnRcv();


                        //접수데이터 재정의 필요
                        mnRcv.OldRcvNo = item.cno + item.jsdate.Replace("-", "");
                        mnRcv.PtntId = ptntId;
                        mnRcv.HosCd = mdParkService.GetBaseInfo.HosCd; //병원코드
                        mnRcv.DeptCd = Int32.Parse(item.subject);

                        mnRcv.UserId = item.doctoruid;

                        int offId = 0;
                        if (Int32.TryParse(item.ucode, out offId))
                            mnRcv.OffId = offId;
                        else
                            mnRcv.OffId = 0;

                        mnRcv.RcvDt = string.Format("{0} {1}", item.jsdate, item.jstime);

                        mnRcv.DiagType = item.udept;

                        mnRcv.ExpCd = "";
                        mnRcv.ReductCd = "";

                        DateTime medStratDt ;
                        if (DateTime.TryParse(item.firstjindate, out medStratDt)) // dr["JinStartTime"].ToStringTrim();
                            mnRcv.MedStartDt = medStratDt.ToString();
                        else
                            mnRcv.MedStartDt = "";
                        mnRcv.MedEndDt = string.Format("{0} {1}", item.lastjindate, item.lastjintime);
                        mnRcv.MediSec = 0;
                        mnRcv.PayDt = string.Format("{0} {1}", item.lastjindate, item.lastjintime);

                        //1,2,3,24,27,28,30  => 초진
                        //4,5,6,18,23,25,26,29,31 => 재진
                        mnRcv.FstMedGb = item.chojae;

                        mnRcv.MedPayYn = ""; //나중에 정의하기로 함.
                        mnRcv.RcvStat = "PF"; //접수상태
                        mnRcv.OldRcvNo = string.Format("{0}|{1}", year, item.wno);

                        mnRcv.InsGb = item.jjgubun; //"추후 확인필요";
                        mnRcv.OrderDt = string.Format("{0} {1}", item.lastjindate, item.lastjintime); //dr["JinEndTime"].ToStringTrim(); //오더 시간
                        mnRcv.PacsId = "";


                        mnRcv.InsDt = string.Format("{0} {1}", item.jsdate, item.jstime);
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

                return convertedList;
            }
            catch(Exception ex)
            {
                Logger.Logger.ERROR(ex.StackTrace);
                throw ex;
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
