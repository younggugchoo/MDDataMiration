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
    /// 의사랑 처방
    /// </summary>
    public class ConvertPrescription : IDisposable
    {
        public event LogEventHandler WorkingInfo;

        private MDPARKService mdParkService;

        List<SUGACODE> sUGACODEs = null;
        List<EXAMCODE> eXAMCODEs = null;

        public ConvertPrescription(MDPARKService mDPARKService)
        {
            this.mdParkService = mDPARKService;
        }


        /// <summary>
        /// 처방데이터 변환
        /// </summary>
        /// <param name="year">년도</param>
        public void ConvertData(int year, List<JSO> jSOs)
        {
            ConvertTMdPsb(year, jSOs);
        }


        private void ConvertTMdPsb(int year, List<JSO> jSOs)
        {

            string filePath = string.Format(@"{0}\TRO{1}.{2}", ConfigurationManager.AppSettings.Get("uisarangRootPath"), year, ConfigurationManager.AppSettings.Get("uisarangFileExtension"));

            try
            {
                List<TRO> tROs = Parser.ConvertParserData<TRO>(filePath);

                filePath = string.Format(@"{0}\SUTAKCODEO{1}.{2}", ConfigurationManager.AppSettings.Get("uisarangRootPath"), year, ConfigurationManager.AppSettings.Get("uisarangFileExtension"));

                List<SUTAKCODEO> sUTAKCODEOs = Parser.ConvertParserData<SUTAKCODEO>(filePath);

                //처방데이터
                List<TMdPsb> lstTMdPsb = new List<TMdPsb>();

                //줄단위 메모 데이터
                List<TMdPsbLine> lstTMPsbLine = new List<TMdPsbLine>();

                if (jSOs == null)
                {
                    string jsoFilePath = string.Format(@"{0}\JSO{1}.{2}", ConfigurationManager.AppSettings.Get("uisarangRootPath"), year, ConfigurationManager.AppSettings.Get("uisarangFileExtension"));
                    jSOs = Parser.ConvertParserData<JSO>(jsoFilePath);

                }

                int ptntId = 0;
                int rcvId = 0;

                //string psbGb = "";
                //string viewGr = "";

                //int applyDateColNum = 0;

                //처방테이블(TRO) ,  줄단위(SUTAKCODEO) JOIN
                var convertedList = (from Item1 in tROs
                                     join Item2 in sUTAKCODEOs
                                     on new { Item1.wno, Item1.ono } equals new { Item2.wno, Item2.ono }
                                     into grouping
                                     from Item2 in grouping.DefaultIfEmpty()
                                     select new { Item1, Item2 }).ToList();




                if (convertedList.Count > 0)
                {
                    TRO tro = new TRO();
                    SUTAKCODEO sutakcodeo = new SUTAKCODEO();

                    foreach (var item in convertedList)
                    {

                        tro = item.Item1;
                        sutakcodeo = item.Item2;


                        var jso = jSOs.Where(x => x.wno == tro.wno).FirstOrDefault();
                        if (jso == null)
                        {
                            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("접수번호 : {0} 가 JSO 정보에 존재하지 않음.", tro.wno));
                            Logger.Logger.INFO(string.Format("접수번호 : {0} 가 JSO 정보에 존재하지 않음.", tro.wno));
                            continue;
                        }

                        //환자정보 조회
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

                        //MD_PARK 에 저장된 접수번호 조회
                        rcvId = mdParkService.GetRcvIdByOldRcvNo(ptntId, string.Format("{0}|{1}", year, tro.wno));

                        if (rcvId == 0)
                        {
                            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("접수번호 : 챠트번호 [{0}] 접수번호[{1}] 존재하지 않습니다.", jso.cno, tro.wno));
                            Logger.Logger.INFO(string.Format("접수번호 : 챠트번호 [{0}] 접수번호[{1}] 존재하지 않습니다.", jso.cno, tro.wno));
                            continue;
                        }

                        TMdPsb mdPsb = new TMdPsb();
                        

                        mdPsb.RcvId = rcvId;

                        mdPsb.PsbCd = tro.trcode; //처방코드
                        //mdPsb.PsbNm = tro.kname; //처방명

                        //SUGACODE sUGACODE = retrieveSUGACODE(tro.trcode);

                        //mdPsb.MGb = ConvertMGb(tro.cdgubun); //(1:M , 3:D, 8:Z, 4:확인중)
                        //mdPsb.ViewGr = ConvertViewGr(tro.item); //(item 앞2자리 => 04:I, 03:M, 09:C)

                        mdPsb.HangNo = tro.item.Substring(0, 2); //11 이후의 값이 존재함 -> 확인필요
                        mdPsb.MoNo = tro.item.Substring(2, 2);
                        //mdPsb.CdGb = tro.cdgubun;
                        //mdPsb.DrugUnit = tro.sepsymbol;

                        //mdPsb.PsbPrice = tro.cgsuga;

                        mdPsb.Qd = ""; //정의필요
                        mdPsb.Sd = tro.trdose;
                        mdPsb.Td = tro.trday;

                        mdPsb.InOutGb = "";

                        mdPsb.SalGb = "";

                        mdPsb.UnitPrice = "0"; //단가 (0으로  hardcode)
                        //mdPsb.Spec = ""; //스펙

                        mdPsb.ExamChkYn = ""; //검사 확인여부
                        mdPsb.ExamChkDt = ""; //검사 확인 일시
                        mdPsb.ExamChkUserId = ""; //검사 확인 사용자 ID

                        /*
                         * SUTAKCODEOYYYY 테이블에서 조회
                         * mdPsb.LineCd - > SUTAKCODEOYYYY.ONO
                         * SUTAKCODEOYYYY.JTRCM 컬럼의 값이 있을 경우에만 줄단위 데이터 이관
                         */

                        //sutakcodeo = sUTAKCODEOs.FirstOrDefault(x => x.wno == tro.wno && x.ono == tro.ono);

                        //mdPsb.LineCd = ""; //줄단위 구분코드
                        //mdPsb.LineMmoTxt = ""; //줄단위 메모 txt

                        if (sutakcodeo != null)
                        {
                            if (!string.IsNullOrEmpty(sutakcodeo.jtrcm))
                            {
                                TMdPsbLine mdPsbLine = new TMdPsbLine();

                                mdPsbLine.PsbCd = mdPsb.PsbCd;
                                mdPsbLine.RcvId = mdPsb.RcvId;

                                mdPsbLine.LineCd = sutakcodeo.jtrcm.Substring(0, 5);
                                mdPsbLine.LineMmoTxt = sutakcodeo.jtrcm.Substring(5, sutakcodeo.jtrcm.Length - 5);

                                mdPsbLine.InsDt = string.Format("{0} {1}", jso.jsdate, jso.jstime);
                                mdPsbLine.InsId = "TRN";
                                mdPsbLine.InsIp = "0.0.0.0";
                                mdPsbLine.UpdDt = DateTime.Now.ToString();
                                mdPsbLine.UpdId = "TRN";
                                mdPsbLine.UpdIp = "0.0.0.0";
                                mdPsbLine.UseYn = "Y";

                                lstTMPsbLine.Add(mdPsbLine);
                     
                            }
                        }

                        mdPsb.InsDt = string.Format("{0} {1}", jso.jsdate, jso.jstime);
                        mdPsb.InsId = "TRN";
                        mdPsb.InsIp = "0.0.0.0";
                        mdPsb.UpdDt = DateTime.Now.ToString();
                        mdPsb.UpdId = "TRN";
                        mdPsb.UpdIp = "0.0.0.0";
                        mdPsb.UseYn = "Y";

                        lstTMdPsb.Add(mdPsb);

                    }
                }

                mdParkService.ExecuteInsertData(lstTMdPsb);
                mdParkService.RemoveDtTMnRcvPsb();

                //줄단위 메모데이터 처리
                foreach (TMdPsbLine item in lstTMPsbLine)
                {
                    item.PsbId = mdParkService.GetPsbId(item.RcvId, item.PsbCd, item.InsDt.Substring(0,7));

                    if (item.PsbId == 0)
                    {
                        WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("접수번호 : {0} 가 psb_id 정보에 존재하지 않음. 처방코드={1} ", item.RcvId, item.PsbCd));
                        Logger.Logger.INFO(string.Format("접수번호 : {0} 가 psb_id 정보에 존재하지 않음. 처방코드={1} ", item.RcvId, item.PsbCd));
                    }
                }

                mdParkService.ExecuteInsertData(lstTMPsbLine);

                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환종료", "ConvertTMdPsb"));
            }
            catch(Exception ex)
            {
                Logger.Logger.ERROR(ex.ToString());
                throw ex;
            }
        }


        /// <summary>
        /// 처방코드 조회
        /// </summary>
        /// <param name="trcode">처방코드</param>
        /// <returns></returns>
        private SUGACODE retrieveSUGACODE(string trcode)
        {
            string filePath = string.Format(@"{0}\SUGACODE.{1}", ConfigurationManager.AppSettings.Get("uisarangRootPath"), ConfigurationManager.AppSettings.Get("uisarangFileExtension"));

            if (sUGACODEs == null)
                sUGACODEs = Parser.ConvertParserData<SUGACODE>(filePath);

            return sUGACODEs.Where(x => x.ucode == trcode).FirstOrDefault();
        }

        /// <summary>
        /// 검사코드 조회
        /// </summary>
        /// <param name="ucode"></param>
        /// <returns></returns>
        private EXAMCODE retrieveEXAMCODE(string ucode)
        {
            if (eXAMCODEs == null)
            {
                string filePath = string.Format(@"{0}\ExamCode.{1}", ConfigurationManager.AppSettings.Get("uisarangRootPath"), ConfigurationManager.AppSettings.Get("uisarangFileExtension"));
                eXAMCODEs = Parser.ConvertParserData<EXAMCODE>(filePath);

            }

            return eXAMCODEs.Where(x => x.ucode == ucode).FirstOrDefault();
        }


        private string ConvertMGb(string value)
        {
            string retVal = "";
            //(1:M , 3:D, 8:Z, 4:확인중)
            switch (value)
            {
                case "1":
                    retVal= "M";
                    break;
                case "3":
                    retVal = "D";
                    break;
                case "8":
                    retVal = "Z";
                    break;
                case "4":
                    retVal = "";
                    break;
            }

            return retVal;
        }

        private string ConvertViewGr(string value)
        {
            //(item 앞2자리 => 04:I, 03:M, 09:C)
            string retVal = "";


            switch (value.Substring(0, 2))
            {
                case "04":
                    retVal = "I";
                    break;
                case "03":
                    retVal = "M";
                    break;
                case "09":
                    retVal = "C";
                    break;
            }

            return retVal;
        }

        //private int retrieveMediApplyDateNumber(SUGACODE sUGACODE,  string sdate)
        //{
        //    if (sUGACODE == null) return 0;

        //    //startCol ~ endCol
        //    //JK1 ~ JK5 를 돌면서 diagDate 범위에 해당하는 번호를 찾아냄,
        //    //colName  = colName  + 찾은 번호값

        //    int colNumber = 0;

        //    if (nixMedi != null)
        //    {
        //        if (diagDate >= nixMedi.Jk1.ToInt32() && diagDate < nixMedi.Jk2.ToInt32()) colNumber = 1;
        //        else if (diagDate >= nixMedi.Jk2.ToInt32() && diagDate < nixMedi.Jk3.ToInt32()) colNumber = 2;
        //        else if (diagDate >= nixMedi.Jk3.ToInt32() && diagDate < nixMedi.Jk4.ToInt32()) colNumber = 3;
        //        else if (diagDate >= nixMedi.Jk4.ToInt32() && diagDate < nixMedi.Jk5.ToInt32()) colNumber = 4;
        //        else if (diagDate >= nixMedi.Jk5.ToInt32()) colNumber = 5;
        //        else colNumber = 5; //없는경우엔 최근날짜로...
        //    }


        //    return colNumber;
        //}
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
