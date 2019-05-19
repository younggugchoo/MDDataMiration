using MD_DataMigration.Service.MDPARK;
using MD_DataMigration.Service.MDPARK.model;
using MD_DataMigration.Service.UISARANG.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_DataMigration.Service.UISARANG
{
    public class ConvertSugaCode : IDisposable
    {

        public event LogEventHandler WorkingInfo;

        private MDPARKService mdParkService;

        private List<YAKGALIB> yakgalib;


        public ConvertSugaCode(MDPARKService mDPARKService)
        {
            this.mdParkService = mDPARKService;
        }


        /// <summary>
        /// 의사랑 SUAGACODE, examcode 데이터 변환
        /// </summary>
        
        public void ConvertData()
        {
            ConvertTCmBsHosSet_Suga();

            ConvertTCmBsHosSet_Exam();
        }

        /// <summary>
        /// 의사랑 SUAGACODE 데이터 변환
        /// </summary>
        private void ConvertTCmBsHosSet_Suga()
        {
            List<TCmBsHosSet> lstTcmBsHosSets = new List<TCmBsHosSet>();

            int revId = 0;

            string filePath = string.Format(@"{0}\SUGACODE.{1}", ConfigurationManager.AppSettings.Get("uisarangRootPath"), ConfigurationManager.AppSettings.Get("uisarangFileExtension"));

            List<SUGACODE> sUGACODEs;
            try
            {
                sUGACODEs = Parser.ConvertParserData<SUGACODE>(filePath);
            }
            catch (Exception ex)
            {
                Logger.Logger.ERROR(ex.StackTrace);
                throw ex;
            }
            
            //수가코드 변환시작
            if (sUGACODEs.Count > 0)
            {
                TCmBsHosSet cmBsHosSet = null;
                string cgcode = "";

                foreach (var item in sUGACODEs)
                {

                    if (item.cgcode == null || item.cgcode.Length == 0) continue;

                    revId = 1;
                    for (int i = 3; i > 0; i--)
                    {
                        if (item.GetType().GetProperty("sdate" + i.ToString()).GetValue(item, null) != null)
                        {
                            cmBsHosSet = new TCmBsHosSet();
                                                        
                            cmBsHosSet.MGb = item.cdgubun;
                            cmBsHosSet.HosCd = mdParkService.GetBaseInfo.HosCd;

                            cgcode = item.cgcode;

                            if (cgcode.Reverse().Substring(0, 3) == "000")
                            {
                                cgcode = cgcode.Reverse().Substring(3).Reverse();
                            }
                            cmBsHosSet.McCd = cgcode;

                            //cmBsHosSet.JangCd = "";
                            if (item.item.Length > 0)
                            {
                                cmBsHosSet.HangNo = item.item.Substring(0, 2);
                                cmBsHosSet.MoNo = item.item.Substring(2, 2);
                            }
                            else
                            {
                                cmBsHosSet.HangNo = "";
                                cmBsHosSet.MoNo = "";
                            }


                            cmBsHosSet.PmcCd = item.ucode.ToStringTrim();
                            cmBsHosSet.Pkor = item.kname.ToStringTrim();

                            cmBsHosSet.SalNoGb = "";

                            cmBsHosSet.Kor = item.kname.ToStringTrim();
                            cmBsHosSet.OvhdRateGb = "";
                            cmBsHosSet.DSpec = "";
                            cmBsHosSet.DUnit = item.unit;
                            cmBsHosSet.DCompNm =item.mname;
                            //cmBsHosSet.DstbNo = "";

                            cmBsHosSet.DMainIgdt = ""; //retrieveDMainIgdt(item.cgcode);
                            cmBsHosSet.DPsGb = "";

                            //cmBsHosSet.MdcSalGb = "";
                            cmBsHosSet.InOutGb = "O";
                            //cmBsHosSet.DrgExcCd = "";
                            //cmBsHosSet.DSpecialGb = "";
                            //cmBsHosSet.DPath = "";
                            //cmBsHosSet.InjectionGb = "";
                            //cmBsHosSet.Dose = "";
                            //cmBsHosSet.DoseCnt = 0;
                            //cmBsHosSet.DoseDays = 0;
                            /*
                            cmBsHosSet.LimitDose = "";
                            cmBsHosSet.LimitDoseCnt = 0;
                            cmBsHosSet.LimitDoseDays = 0;
                            cmBsHosSet.CapaDtlGb = "";
                            cmBsHosSet.CDistCd = "";
                            cmBsHosSet.COt = "";
                            cmBsHosSet.CSgyYn = "";
                            cmBsHosSet.DupYn = "";
                            cmBsHosSet.CEng = "";
                            cmBsHosSet.CSpcCd = "";
                            cmBsHosSet.EquivGb = "";
                            cmBsHosSet.ActAddGb = "";
                            cmBsHosSet.TestGb = "";
                            cmBsHosSet.DsGb = "";
                            cmBsHosSet.CnmtId = 0;
                            cmBsHosSet.DedExcCd = "";
                            cmBsHosSet.MSpec = "";
                            cmBsHosSet.MUnit = "";
                            cmBsHosSet.MMaterial = "";
                            cmBsHosSet.MMaker = "";
                            cmBsHosSet.MImporter = "";
                            cmBsHosSet.ReportGb = "";
                            cmBsHosSet.CautMmo = "";
                            cmBsHosSet.LineMYn = "";
                            cmBsHosSet.LineCd = "";
                            cmBsHosSet.LineMmo = "";
                            cmBsHosSet.Sex = "";
                            cmBsHosSet.PgGb = "";
                            cmBsHosSet.AgeLmtGb = "";
                            cmBsHosSet.ManUnder = 0;
                            cmBsHosSet.ManOver = 0;
                            cmBsHosSet.WmUnder = 0;
                            cmBsHosSet.WmOver = 0;
                            cmBsHosSet.SmpTxtId = 0;
                            cmBsHosSet.PohPsbGb = "";
                            cmBsHosSet.Qd = "";
                            cmBsHosSet.Sd = 0;
                            cmBsHosSet.Td = 0;
                            cmBsHosSet.PsbLmtDyGb = "";
                            cmBsHosSet.PsbLmtDy = 0;
                            cmBsHosSet.FmGb = "";
                            cmBsHosSet.FmGbRmk = "";
                            cmBsHosSet.PsbCntGb = "";
                            cmBsHosSet.UsgEx = "";
                            */

                            cmBsHosSet.SearchTxt = "";
                            /*
                            cmBsHosSet.EdiPrice = "";
                            cmBsHosSet.GeneralPrice = "";
                            cmBsHosSet.CarInsPrice = "";
                            cmBsHosSet.IaciPrice = "";
                            cmBsHosSet.HighLmtPrice = "";
                            cmBsHosSet.CStr = "";
                            cmBsHosSet.EdiRptPrice = "";
                            */

                            cmBsHosSet.UseYn = "Y";

                            cmBsHosSet.RevId = revId;
                            //switch (i)
                            //{
                            //    case 1:
                            //        cmBsHosSet.EffFrom = item.sdate1.ToDateFormatNonDash();
                            //        cmBsHosSet.EffTo = "29991231";
                            //        break;
                            //    case 2:
                            //        cmBsHosSet.EffFrom = item.sdate2.ToDateFormatNonDash();
                            //        cmBsHosSet.EffTo = item.sdate1.ToDateFormatNonDash();
                            //        break;
                            //    case 3:
                            //        cmBsHosSet.EffFrom = item.sdate3.ToDateFormatNonDash();
                            //        cmBsHosSet.EffTo = item.sdate2.ToDateFormatNonDash();
                            //        break;
                            //}



                            cmBsHosSet.EffFrom = "";
                            cmBsHosSet.EffTo = "";

                            switch (i)
                            {
                                case 1:
                                    cmBsHosSet.EffFrom = item.sdate1.ToDateFormatNonDash();
                                    cmBsHosSet.EffTo = "29991231";
                                    break;
                                case 2:
                                    if (item.sdate2 != "" && item.sdate1 != "")
                                    {
                                        cmBsHosSet.EffFrom = item.sdate2.ToDateFormatNonDash();
                                        cmBsHosSet.EffTo = DateTime.ParseExact(item.sdate1.ToDateFormatNonDash(), "yyyyMMdd", CultureInfo.InvariantCulture).AddDays(-1).ToShortDateString().ToDateFormatNonDash();
                                    }

                                    break;
                                case 3:
                                    if (item.sdate3 != "" && item.sdate2 != "")
                                    {
                                        cmBsHosSet.EffFrom = item.sdate3.ToDateFormatNonDash();
                                        cmBsHosSet.EffTo = DateTime.ParseExact(item.sdate2.ToDateFormatNonDash(), "yyyyMMdd", CultureInfo.InvariantCulture).AddDays(-1).ToShortDateString().ToDateFormatNonDash();
                                    }

                                    break;
                            }

                            //cmBsHosSet.RcptCd = "";
                            //cmBsHosSet.P50 = "";
                            //cmBsHosSet.P80 = "";
                            //cmBsHosSet.P90 = "";
                            //cmBsHosSet.P100 = "";

                            cmBsHosSet.InsDt = DateTime.Now.ToString();
                            cmBsHosSet.InsId = "TRN";
                            cmBsHosSet.InsIp = "0.0.0.0";
                            cmBsHosSet.UpdDt = DateTime.Now.ToString();
                            cmBsHosSet.UpdId = "TRN";
                            cmBsHosSet.UpdIp = "0.0.0.0";

                            //cmBsHosSet.CateBunchId = 0;

                            revId++;

                            lstTcmBsHosSets.Add(cmBsHosSet);
                        }
                    }

                }
            }

            mdParkService.ExecuteInsertData(lstTcmBsHosSets);

            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환종료", "ConvertTMdSympt"));
        }


        private string retrieveDMainIgdt(string cgcode)
        {
            string ret = "";

            if (yakgalib == null)
            {
                string filePath = string.Format(@"{0}\YAKGALIB.{1}", ConfigurationManager.AppSettings.Get("uisarangRootPath"), ConfigurationManager.AppSettings.Get("uisarangFileExtension"));

                yakgalib = Parser.ConvertParserData<YAKGALIB>(filePath);

            }

            YAKGALIB yak = yakgalib.Where(x => x.cgcode == cgcode).FirstOrDefault();

            if (yak != null)
                ret = yak.cingcode;
            
            return ret;

        }

        /// <summary>
        /// 의사랑 Exam 데이터 변환
        /// </summary>
        private void ConvertTCmBsHosSet_Exam()
        {
            List<TCmBsHosSet> lstTcmBsHosSets = new List<TCmBsHosSet>();


            string filePath = string.Format(@"{0}\ExamCode.{1}", ConfigurationManager.AppSettings.Get("uisarangRootPath"), ConfigurationManager.AppSettings.Get("uisarangFileExtension"));

            List<EXAMCODE> eXAMCODEs;
            try
            {
                eXAMCODEs = Parser.ConvertParserData<EXAMCODE>(filePath);
            }
            catch (Exception ex)
            {
                Logger.Logger.ERROR(ex.StackTrace);
                throw ex;
            }

            int revId = 0;

            //수가코드 변환시작
            if (eXAMCODEs.Count > 0)
            {
                TCmBsHosSet cmBsHosSet = null;
                string cgcode = "";

                foreach (var item in eXAMCODEs)
                {

                    if (item.cgcode == null || item.cgcode.Length == 0) continue;

                    revId = 1;
                    for (int i = 3; i > 0; i--)
                    {
                        if (item.GetType().GetProperty("sdate" + i.ToString()).GetValue(item, null) != null)
                        {
                            cmBsHosSet = new TCmBsHosSet();

                            cmBsHosSet.MGb = item.cdgubun;
                            cmBsHosSet.HosCd = mdParkService.GetBaseInfo.HosCd;

                            cgcode = item.cgcode;

                            if (cgcode.Reverse().Substring(0, 3) == "000")
                            {
                                cgcode = cgcode.Reverse().Substring(3).Reverse();
                            }
                            cmBsHosSet.McCd = cgcode;

                            //cmBsHosSet.JangCd = "";
                            if (item.item.Length > 0)
                            {
                                cmBsHosSet.HangNo = item.item.Substring(0, 2);
                                cmBsHosSet.MoNo = item.item.Substring(2, 2);
                            }
                            else
                            {
                                cmBsHosSet.HangNo = "";
                                cmBsHosSet.MoNo = "";
                            }


                            cmBsHosSet.PmcCd = item.ucode.ToStringTrim();
                            cmBsHosSet.Pkor = item.kname.ToStringTrim();

                            cmBsHosSet.SalNoGb = "";

                            cmBsHosSet.Kor = item.kname.ToStringTrim();
                            cmBsHosSet.OvhdRateGb = "";
                            cmBsHosSet.DSpec = "";
                            cmBsHosSet.DUnit = item.unit;

                            cmBsHosSet.DCompNm = "";
                            //cmBsHosSet.DstbNo = "";

                            cmBsHosSet.DMainIgdt = ""; //retrieveDMainIgdt(item.cgcode);
                            cmBsHosSet.DPsGb = "";

                            //cmBsHosSet.MdcSalGb = "";
                            cmBsHosSet.InOutGb = "O";
                            //cmBsHosSet.DrgExcCd = "";
                            //cmBsHosSet.DSpecialGb = "";
                            //cmBsHosSet.DPath = "";
                            //cmBsHosSet.InjectionGb = "";
                            //cmBsHosSet.Dose = "";
                            //cmBsHosSet.DoseCnt = 0;
                            //cmBsHosSet.DoseDays = 0;
                            /*
                            cmBsHosSet.LimitDose = "";
                            cmBsHosSet.LimitDoseCnt = 0;
                            cmBsHosSet.LimitDoseDays = 0;
                            cmBsHosSet.CapaDtlGb = "";
                            cmBsHosSet.CDistCd = "";
                            cmBsHosSet.COt = "";
                            cmBsHosSet.CSgyYn = "";
                            cmBsHosSet.DupYn = "";
                            cmBsHosSet.CEng = "";
                            cmBsHosSet.CSpcCd = "";
                            cmBsHosSet.EquivGb = "";
                            cmBsHosSet.ActAddGb = "";
                            cmBsHosSet.TestGb = "";
                            cmBsHosSet.DsGb = "";
                            cmBsHosSet.CnmtId = 0;
                            cmBsHosSet.DedExcCd = "";
                            cmBsHosSet.MSpec = "";
                            cmBsHosSet.MUnit = "";
                            cmBsHosSet.MMaterial = "";
                            cmBsHosSet.MMaker = "";
                            cmBsHosSet.MImporter = "";
                            cmBsHosSet.ReportGb = "";
                            cmBsHosSet.CautMmo = "";
                            cmBsHosSet.LineMYn = "";
                            cmBsHosSet.LineCd = "";
                            cmBsHosSet.LineMmo = "";
                            cmBsHosSet.Sex = "";
                            cmBsHosSet.PgGb = "";
                            cmBsHosSet.AgeLmtGb = "";
                            cmBsHosSet.ManUnder = 0;
                            cmBsHosSet.ManOver = 0;
                            cmBsHosSet.WmUnder = 0;
                            cmBsHosSet.WmOver = 0;
                            cmBsHosSet.SmpTxtId = 0;
                            cmBsHosSet.PohPsbGb = "";
                            cmBsHosSet.Qd = "";
                            cmBsHosSet.Sd = 0;
                            cmBsHosSet.Td = 0;
                            cmBsHosSet.PsbLmtDyGb = "";
                            cmBsHosSet.PsbLmtDy = 0;
                            cmBsHosSet.FmGb = "";
                            cmBsHosSet.FmGbRmk = "";
                            cmBsHosSet.PsbCntGb = "";
                            cmBsHosSet.UsgEx = "";
                            */

                            cmBsHosSet.SearchTxt = "";
                            /*
                            cmBsHosSet.EdiPrice = "";
                            cmBsHosSet.GeneralPrice = "";
                            cmBsHosSet.CarInsPrice = "";
                            cmBsHosSet.IaciPrice = "";
                            cmBsHosSet.HighLmtPrice = "";
                            cmBsHosSet.CStr = "";
                            cmBsHosSet.EdiRptPrice = "";
                            */

                            cmBsHosSet.UseYn = "Y";

                            cmBsHosSet.RevId = revId;
                            //switch (i)
                            //{
                            //    case 1:
                            //        cmBsHosSet.EffFrom = item.sdate1.ToDateFormatNonDash();
                            //        cmBsHosSet.EffTo = "29991231";
                            //        break;
                            //    case 2:
                            //        cmBsHosSet.EffFrom = item.sdate2.ToDateFormatNonDash();
                            //        cmBsHosSet.EffTo = item.sdate1.ToDateFormatNonDash();
                            //        break;
                            //    case 3:
                            //        cmBsHosSet.EffFrom = item.sdate3.ToDateFormatNonDash();
                            //        cmBsHosSet.EffTo = item.sdate2.ToDateFormatNonDash();
                            //        break;
                            //}

                            cmBsHosSet.EffFrom = "";
                            cmBsHosSet.EffTo = "";
                            switch (i)
                            {
                                case 1:
                                    cmBsHosSet.EffFrom = item.sdate1.ToDateFormatNonDash();
                                    cmBsHosSet.EffTo = "29991231";
                                    break;
                                case 2:
                                    if (item.sdate2 != "" && item.sdate1 != "")
                                    {
                                        cmBsHosSet.EffFrom = item.sdate2.ToDateFormatNonDash();
                                        cmBsHosSet.EffTo = DateTime.ParseExact(item.sdate1.ToDateFormatNonDash(), "yyyyMMdd", CultureInfo.InvariantCulture).AddDays(-1).ToShortDateString().ToDateFormatNonDash();
                                    }

                                    break;
                                case 3:
                                    if (item.sdate3 != "" && item.sdate2 != "")
                                    {
                                        cmBsHosSet.EffFrom = item.sdate3.ToDateFormatNonDash();
                                        cmBsHosSet.EffTo = DateTime.ParseExact(item.sdate2.ToDateFormatNonDash(), "yyyyMMdd", CultureInfo.InvariantCulture).AddDays(-1).ToShortDateString().ToDateFormatNonDash();
                                    }

                                    break;
                            }




                            //cmBsHosSet.RcptCd = "";
                            //cmBsHosSet.P50 = "";
                            //cmBsHosSet.P80 = "";
                            //cmBsHosSet.P90 = "";
                            //cmBsHosSet.P100 = "";

                            cmBsHosSet.InsDt = DateTime.Now.ToString();
                            cmBsHosSet.InsId = "TRN";
                            cmBsHosSet.InsIp = "0.0.0.0";
                            cmBsHosSet.UpdDt = DateTime.Now.ToString();
                            cmBsHosSet.UpdId = "TRN";
                            cmBsHosSet.UpdIp = "0.0.0.0";

                            //cmBsHosSet.CateBunchId = 0;

                            revId++;

                            lstTcmBsHosSets.Add(cmBsHosSet);
                        }
                    }

                }
            }

            mdParkService.ExecuteInsertData(lstTcmBsHosSets);

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
        // ~ConvertSugaCode() {
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
