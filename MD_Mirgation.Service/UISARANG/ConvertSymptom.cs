﻿using MD_DataMigration.Service.MDPARK;
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
    /// 의사랑 증상
    /// </summary>
    public class ConvertSymptom : IDisposable
    {
        public event LogEventHandler WorkingInfo;

        private MDPARKService mdParkService;


        public ConvertSymptom(MDPARKService mDPARKService)
        {
            this.mdParkService = mDPARKService;
        }

        
        /// <summary>
        /// 증상데이터 변환
        /// </summary>
        /// <param name="year">년도</param>
        public void ConvertData(int year, List<JSO> jSOs)
        {            
            ConvertTMdSympt(year, jSOs);
        }
        
        private void ConvertTMdSympt(int year, List<JSO> jSOs)
        {
            List<TMdSympt> lstTMdSympt = new List<TMdSympt>();
            int ptntId = 0;
            int rcvId = 0;

            if (jSOs == null)
            {
                
                string filePath = string.Format(@"{0}\JSO{1}.{2}", ConfigurationManager.AppSettings.Get("uisarangRootPath"), year, ConfigurationManager.AppSettings.Get("uisarangFileExtension"));

                try
                {
                    jSOs = Parser.ConvertParserData<JSO>(filePath);
                }
                catch(Exception ex)
                {
                    Logger.Logger.ERROR(ex.StackTrace);
                    throw ex;
                }
            }

            if (jSOs.Count > 0)
            {
                TMdSympt mdSympt = null;

                foreach (var item in jSOs)
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

                    //접수번호 조회
                    rcvId = mdParkService.GetRcvIdByOldRcvNo(ptntId, string.Format("{0}|{1}", year,  item.wno));

                    if (rcvId == 0)
                    {
                        WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("접수번호 : 챠트번호 [{0}] 진료일자[{1}] 존재하지 않습니다.", item.cno, string.Format("{0}!{1}", year, item.wno)));
                        Logger.Logger.INFO(string.Format("접수번호 : 챠트번호 [{0}] 진료일자[{1}] 존재하지 않습니다.", item.cno, string.Format("{0}!{1}", year, item.wno)));
                        continue;
                    }


                    mdSympt = new TMdSympt();

                    mdSympt.RcvId = rcvId;

                    mdSympt.Sympt = item.phenom;

                    mdSympt.InsDt = string.Format("{0} {1}", item.jsdate, item.jstime);
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
