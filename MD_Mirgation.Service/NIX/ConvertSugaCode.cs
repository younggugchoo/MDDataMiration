using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD_DataMigration.Service.MDPARK;
using MD_DataMigration.Service.MDPARK.model;

namespace MD_DataMigration.Service.NIX
{
    public class ConvertSugaCode : IDisposable
    {


        public event LogEventHandler WorkingInfo;

        private MDPARKService mdParkService;


        public ConvertSugaCode(MDPARKService mDPARKService)
        {
            this.mdParkService = mDPARKService;
        }


        public void ConvertData()
        {
            ConvertTCmBsHosSet();
        }

        /// <summary>
        /// NIX 수가코드 변환
        /// </summary>
        private void ConvertTCmBsHosSet()
        {
            string strSql = ReadQuery.GetInstance(mdParkService.SourceSQLFile).GetQueryText(string.Format("ConvertSugaCode.retrieveMedi"));

            List<TCmBsHosSet> lstTcmBsHosSets = new List<TCmBsHosSet>();
            int revId = 0;
           
            using (Data.DatabaseFactory factory = new Data.DatabaseFactory(mdParkService.SourceDBName))
            {
                DbDataReader dr = factory.ExecuteReader(strSql, CommandType.Text, null);
                if (dr.HasRows)
                {
                    TCmBsHosSet cmBsHosSet = null;

                    while (dr.Read())
                    {
                        revId = 1;

                        for (int i = 1; i<6; i++)
                        {
                            if (dr[string.Format("Jk{0}", i)].ToString() != "")
                            {
                                cmBsHosSet.MGb = dr[string.Format("Br4{0}", i)].ToString();
                                cmBsHosSet.HosCd = mdParkService.GetBaseInfo.HosCd;


                                cmBsHosSet.McCd = dr[string.Format("YCode{0}", i)].ToString();

                             
                                cmBsHosSet.HangNo = dr[string.Format("Br1{0}", i)].ToString();
                                cmBsHosSet.MoNo = "";


                                cmBsHosSet.PmcCd = dr["Code"].ToString();
                                cmBsHosSet.Pkor = dr["Code"].ToString();

                                cmBsHosSet.SalNoGb = "";

                                cmBsHosSet.Kor = dr[string.Format("Nmk{0}", i)].ToString();
                                cmBsHosSet.OvhdRateGb = "";
                                cmBsHosSet.DSpec = "";
                                cmBsHosSet.DUnit = dr["Unit"].ToString();
                                cmBsHosSet.DCompNm = dr[string.Format("comp{0}", i)].ToString();
                                //cmBsHosSet.DstbNo = "";

                                cmBsHosSet.DMainIgdt = dr[string.Format("sungbun{0}", i)].ToString();
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

                                cmBsHosSet.EffFrom = "";
                                cmBsHosSet.EffTo = "";

                                if (i == 5)
                                {
                                    cmBsHosSet.EffFrom = dr[string.Format("YCode{0}", i)].ToString();
                                    cmBsHosSet.EffTo = "29991231";
                                }
                                else
                                {
                                    cmBsHosSet.EffFrom = dr[string.Format("YCode{0}", i)].ToString();
                                    cmBsHosSet.EffTo = DateTime.ParseExact(dr[string.Format("YCode{0}", i+1)].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture).AddDays(-1).ToShortDateString().ToDateFormatNonDash();

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
