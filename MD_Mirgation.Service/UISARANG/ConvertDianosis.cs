using MD_DataMigration.Service.MDPARK;
using MD_DataMigration.Service.MDPARK.model;
using MD_DataMigration.Service.UISARANG.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_DataMigration.Service.UISARANG
{
    /// <summary>
    /// 의사랑 진단
    /// </summary>
    public class ConvertDianosis : IDisposable
    {
        public event LogEventHandler WorkingInfo;

        private MDPARKService mdParkService;


        public ConvertDianosis(MDPARKService mDPARKService)
        {
            this.mdParkService = mDPARKService;
        }


        /// <summary>
        /// 진단데이터 변환
        /// </summary>
        /// <param name="year">년도</param>
        public void ConvertData(int year, List<JSO> jSOs)
        {
            ConvertTMdDx(year, jSOs);
        }


        private void ConvertTMdDx(int year, List<JSO> jSOs)
        {
            
            string filePath = string.Format(@"{0}\DISO{1}.{2}", ConfigurationManager.AppSettings.Get("uisarangRootPath"), year, ConfigurationManager.AppSettings.Get("uisarangFileExtension"));
            try
            {
                if (jSOs == null)
                {
                    string jsoFilePath = string.Format(@"{0}\JSO{1}.{2}", ConfigurationManager.AppSettings.Get("uisarangRootPath"), year, ConfigurationManager.AppSettings.Get("uisarangFileExtension"));
                    jSOs = Parser.ConvertParserData<JSO>(jsoFilePath);

                }

                List<DISO> convertedList = Parser.ConvertParserData<DISO>(filePath);

                List<TMdDx> lstTMdDx = new List<TMdDx>();

                //저장된 진단정보 순서 변경 0->1 , 1->0으로 바꿈.
                /*
                convertedList.OrderBy(x => x.wno.ToInt32());

                convertedList.ForEach(x =>
                    {
                        if (x.ono == "0")
                        {
                            x.ono = "1";
                        }
                        else if(x.ono == "1")
                        {
                            x.ono = "0";
                        }
                        else
                        {
                            x.ono = x.ono;
                        }
                    }
                );
                */

                List<DISO> orderedConvertedList = convertedList.OrderBy(x => x.wno.ToInt32()).ThenBy(x => x.ono.ToInt32()).ToList();
                int ptntId = 0;
                int rcvId = 0;

                if (orderedConvertedList.Count > 0)
                {
                    TMdDx mdDx = null;

                    foreach (var item in orderedConvertedList)
                    {
                        mdDx = new TMdDx();

                        var jso = jSOs.Where(x => x.wno == item.wno).FirstOrDefault();

                        if (jso == null)
                        {
                            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("접수번호 : {0} 가 JSO 정보에 존재하지 않음.", item.wno));
                            Logger.Logger.INFO(string.Format("접수번호 : {0} 가 JSO 정보에 존재하지 않음.", item.wno));
                            continue;
                        }

                        try
                        {
                            ptntId = mdParkService.GetPtntIdMdPark(jso.cno);
                        }
                        catch (DuplicateNameException ex)
                        {
                            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("챠트번호 : {0} 1개이상이 존재합니다.", jso.cno));
                            Logger.Logger.INFO(string.Format("챠트번호 : {0} 1개이상이 존재합니다..", jso.cno));
                            continue;
                        }

                        //접수번호 조회
                        rcvId = mdParkService.GetRcvIdByOldRcvNo(ptntId, string.Format("{0}|{1}", year, item.wno));

                        if (rcvId == 0)
                        {
                            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("접수번호 : 챠트번호 [{0}] 접수번호[{1}] 존재하지 않습니다.", jso.cno, item.wno));
                            Logger.Logger.INFO(string.Format("접수번호 : 챠트번호 [{0}] 접수번호[{1}] 존재하지 않습니다.", jso.cno, item.wno));
                            continue;
                        }


                        mdDx.RcvId = rcvId;

                        mdDx.DzCd = item.discode;

                        mdDx.DzNm = item.kname;

                        mdDx.MainYn = item.ono.Equals("0") ? "Y" : "N"; // dr["순번"].ToString() == "1" ? "Y" : "N"; //정의필요
                        mdDx.LawDzGb = ""; //나중에 정의하기로 함.
                        mdDx.ReportYn = ""; //나중에 정의하기로 함.

                        mdDx.InsDt = string.Format("{0} {1}", jso.jsdate, jso.jstime);
                        mdDx.InsId = "TRN";
                        mdDx.InsIp = "0.0.0.0";
                        mdDx.UpdDt = DateTime.Now.ToString();
                        mdDx.UpdId = "TRN";
                        mdDx.UpdIp = "0.0.0.0";
                        mdDx.UseYn = "Y";

                        lstTMdDx.Add(mdDx);

                    }
                }

                mdParkService.ExecuteInsertData(lstTMdDx);

                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환종료", "ConvertTMdDx"));
            }
            catch (Exception ex)
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
