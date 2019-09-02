using MD_DataMigration.Service.MDPARK;
using MD_DataMigration.Service.MDPARK.model;
using MD_DataMigration.Service.NIX.model;
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
    /// 처방데이터 변환
    /// </summary>
    public class ConvertPrescription : IDisposable
    {
        public event LogEventHandler WorkingInfo;
        private MDPARKService mdParkService;

        private List<NixMedi> lstNixMedi = null;

        private string strYear = "";

        public ConvertPrescription(MDPARKService mDPARKService)
        {
            this.mdParkService = mDPARKService;
        }


        public void ConvertData(int year)
        {
            strYear = year.ToString();

            //12개월 loop
            for (int i = 1; i < 13; i++)
            {
                ConvertTMdPsb(i.ToString("00"));
            }
        }


        private void ConvertTMdPsb(string month)
        {
            string strSql = ReadQuery.GetInstance(mdParkService.SourceSQLFile).GetQueryText(string.Format("ConvertChart.ConvertTMdPsb"));

            strSql = strSql.Replace("$YYYY$", strYear).Replace("$YYMM$", strYear.Substring(2, 2) + month);

            List<TMdPsb> lstTMdPsb = new List<TMdPsb>();

            //줄단위 메모 데이터
            List<TMdPsbLine> lstTMPsbLine = new List<TMdPsbLine>();

            int ptntId = 0;
            int rcvId = 0;

            string psbGb = "";
            string viewGr = "";

            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, string.Format("{0} Data Loading, Year:{1} / Month:{2}", "ConvertTMdPsb", strYear, month));
            Logger.Logger.INFO(string.Format("{0} Data Loading, Year:{1} / Month:{2}", "ConvertTMdPsb", strYear, month));

            using (Data.DatabaseFactory factory = new Data.DatabaseFactory(mdParkService.SourceDBName))
            {
                DbDataReader dr = factory.ExecuteReader(strSql, CommandType.Text, null);
                if (dr.HasRows)
                {
                    

                    while (dr.Read())
                    {
                        try
                        {
                            ptntId = mdParkService.GetPtntIdMdPark(dr["Code"].ToStringTrim());
                        }
                        catch (DuplicateNameException ex)
                        {
                            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("챠트번호 : {0} 1개이상이 존재합니다.", dr["Code"].ToStringTrim()));
                            Logger.Logger.INFO(string.Format("챠트번호 : {0} 1개이상이 존재합니다..", dr["Code"].ToStringTrim()));
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

                        int applyDateColNum = 0;
                        string ymd = dr["Ymd"].ToStringTrim();
                        decimal psbPrice  = 0;
                        // NIX 처방컬럼의 순번(30개) 만큼 LOOP
                        for (int i = 1; i < 31; i++)
                        {
                            if (dr["Code" + i.ToString()].ToStringTrim() == "") continue;

                            TMdPsb mdPsb = new TMdPsb();
                            
                            mdPsb.RcvId = rcvId;

                            mdPsb.PsbCd = dr["Code" + i.ToString()].ToStringTrim(); //처방코드
                            //mdPsb.PsbNm = dr["Nm" + i.ToString()].ToStringTrim(); //처방명

                            NixMedi medi = retrieveMedi(mdPsb.PsbCd);                            

                            applyDateColNum = medi == null ? 0 : retrieveMediApplyDateNumber(mdPsb.PsbCd, Convert.ToInt32(ymd), medi);

                            psbGb = medi == null ? "" : ConvertPsGb(retrieveMediColumnValue(mdPsb.PsbCd, "Br4" + applyDateColNum.ToString(), medi).ToStringTrim());

                            viewGr = medi == null ? "" : ConvertViewGr(retrieveMediColumnValue(mdPsb.PsbCd, "Br1" + applyDateColNum.ToString(), medi).ToString());

                            //mdPsb.MGb = psbGb;
                            //mdPsb.ViewGr = viewGr;

                                

                            mdPsb.HangNo = medi == null ? "" : retrieveMediColumnValue(mdPsb.PsbCd, "Br1" + applyDateColNum.ToString(), medi).ToStringTrim();
                            mdPsb.MoNo = "";  //dr["Br4" + applyDateColNum.ToString()].ToStringTrim();  //retrieveMedi(mdPsb.PsbCd).Br4.ToString(); //보류..확인중...
                            //mdPsb.CdGb = medi == null ? "" : ConvertCdGb(retrieveMediColumnValue(mdPsb.PsbCd, "Br4" + applyDateColNum.ToString(), medi).ToStringTrim());
                            //mdPsb.DrugUnit = medi == null? "":medi.Unit.ToStringTrim(); //약단위

                            if (medi != null)
                            {
                                for (int j = 1; j < 6; j++)
                                {

                                    if (decimal.TryParse(retrieveMediColumnValue(mdPsb.PsbCd, "price" + j.ToString() + applyDateColNum.ToString(), medi).ToString(), out psbPrice))
                                        if (psbPrice > 0) break;
                                        else
                                            break;
                                }
                            }
                            else
                                psbPrice = 0;


                           //mdPsb.PsbPrice = psbPrice.ToString(); 

                            mdPsb.Qd = dr["Yb" + i.ToString()].ToStringTrim();
                            mdPsb.Sd = dr["Dos" + i.ToString()].ToStringTrim();
                            mdPsb.Td = dr["Day" + i.ToString()].ToStringTrim();

                            mdPsb.InOutGb = "";

                            mdPsb.SalGb = "";


                            mdPsb.UnitPrice = "0"; //단가 (0으로  hardcode)
                            //mdPsb.Spec = ""; //스펙

                            

                            mdPsb.ExamChkYn = ""; //검사 확인여부
                            mdPsb.ExamChkDt = ""; //검사 확인 일시
                            mdPsb.ExamChkUserId = ""; //검사 확인 사용자 ID


                            if (!dr["TJCode"].ToStringTrim().Equals(""))
                            {
                                TMdPsbLine mdPsbLine = new TMdPsbLine();

                                mdPsbLine.PsbCd = mdPsb.PsbCd;
                                mdPsbLine.RcvId = mdPsb.RcvId;

                                mdPsbLine.LineCd = dr["TJCode"].ToStringTrim();
                                mdPsbLine.LineMmoTxt = dr["Memo"].ToStringTrim();

                                mdPsbLine.InsDt = dr["Ymd"].ToString();
                                mdPsbLine.InsId = "TRN";
                                mdPsbLine.InsIp = "0.0.0.0";
                                mdPsbLine.UpdDt = DateTime.Now.ToString();
                                mdPsbLine.UpdId = "TRN";
                                mdPsbLine.UpdIp = "0.0.0.0";
                                mdPsbLine.UseYn = "Y";

                                lstTMPsbLine.Add(mdPsbLine);
                            }
                            //mdPsb.LineCd = dr["TJCode"].ToStringTrim(); //줄단위 구분코드
                            //mdPsb.LineMmoTxt = dr["Memo"].ToStringTrim(); //줄단위 메모 txt

                            mdPsb.InsDt = dr["Ymd"].ToString();
                            mdPsb.InsId = "TRN";
                            mdPsb.InsIp = "0.0.0.0";
                            mdPsb.UpdDt = DateTime.Now.ToString();
                            mdPsb.UpdId = "TRN";
                            mdPsb.UpdIp = "0.0.0.0";
                            mdPsb.UseYn = "Y";

                            lstTMdPsb.Add(mdPsb); 
                        }

                       
                    }
                }

                mdParkService.ExecuteInsertData(lstTMdPsb);
                mdParkService.RemoveDtTMnRcvPsb();

                //줄단위 메모데이터 처리
                foreach (TMdPsbLine item in lstTMPsbLine)
                {
                    item.PsbId = mdParkService.GetPsbId(item.RcvId, item.PsbCd, item.InsDt.Substring(0, 7));

                    if (item.PsbId == 0)
                    {
                        WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("접수번호 : {0} 가 psb_id 정보에 존재하지 않음. 처방코드={1} ", item.RcvId, item.PsbCd));
                        Logger.Logger.INFO(string.Format("접수번호 : {0} 가 psb_id 정보에 존재하지 않음. 처방코드={1} ", item.RcvId, item.PsbCd));
                    }
                }

                mdParkService.ExecuteInsertData(lstTMPsbLine);

                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환종료", "ConvertTMdPsb"));
            }
        }

        /*
         * 진료일자에 따라 적용일을 찾아서 그에 해당하는 컬럼값을 조회해야 한다.
         * 예를 들어 진료일자가 20170101 이면 적용일 JK1~JK5의 날짜에 범위에 해당하는 컬럼을 찾아내고
         * 그리고 컬럼 숫자에 해당하는 값을 조회해야 한다.
         */
        private NixMedi retrieveMedi(string code)
        {

            if (code == "") return null;

            if (lstNixMedi == null)
            {
                string strSql = ReadQuery.GetInstance(mdParkService.SourceSQLFile).GetQueryText(string.Format("ConvertCommon.retrieveMedi"));
                using (Data.DatabaseFactory factory = new Data.DatabaseFactory(mdParkService.SourceDBName))
                {

                    DataSet ds = factory.ExecuteDataSet(strSql, CommandType.Text, null);
                    lstNixMedi = ds.Tables[0].ToList<NixMedi>();
                }
            }
            return lstNixMedi.Where(x => x.Code.ToStringTrim() == code).DefaultIfEmpty().First();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="code">분류컬럼</param>
        /// <param name="diagDate"></param>
        /// <returns></returns>
        private int retrieveMediApplyDateNumber(string code, int diagDate, NixMedi nixMedi)
        {
           

            if (code == "" || nixMedi == null )  return 0;


            //startCol ~ endCol
            //JK1 ~ JK5 를 돌면서 diagDate 범위에 해당하는 번호를 찾아냄,
            //colName  = colName  + 찾은 번호값

            
            int colNumber = 0;

            if (nixMedi != null)
            {
                if (diagDate >= nixMedi.Jk1.ToInt32() && diagDate < nixMedi.Jk2.ToInt32()) colNumber = 1;
                else if (diagDate >= nixMedi.Jk2.ToInt32() && diagDate < nixMedi.Jk3.ToInt32()) colNumber = 2;
                else if (diagDate >= nixMedi.Jk3.ToInt32() && diagDate < nixMedi.Jk4.ToInt32()) colNumber = 3;
                else if (diagDate >= nixMedi.Jk4.ToInt32() && diagDate < nixMedi.Jk5.ToInt32()) colNumber = 4;
                else if (diagDate >= nixMedi.Jk5.ToInt32()) colNumber = 5;
                else colNumber = 5; //없는경우엔 최근날짜로...
            }

            
            return colNumber;
        }

        private Object retrieveMediColumnValue(string code, string colName, NixMedi nixMedi)
        {

            if (code == "" || nixMedi ==null) return "";
            
            return nixMedi.GetType().GetProperty(colName).GetValue(nixMedi, null);
            
            
        }

        private string ConvertPsGb(string value)
        {
            string psbGb = "";
            switch (value) 
            {
                case "1":
                    psbGb = "M"; //수가
                    break;
                case "3":
                    psbGb = "D"; //약가
                    break;
               case "6":
                    psbGb = "Z"; //재료
                    break;
            }

            return psbGb;
        }

        private string ConvertCdGb(string value)
        {

            /*
            * br41~br45
            * 1 => mdPsb.CdGb = 1
                3 => mdPsb.CdGb = 3
                6 => mdPsb.CdGb = 8

            */
            string cdGb = "";
            switch (value)
            {
                case "1":
                    cdGb = "1"; 
                    break;
                case "3":
                    cdGb = "3"; 
                    break;
                case "6":
                    cdGb = "8"; 
                    break;
            }

            return cdGb;
        }

        private string ConvertViewGr(string value)
        {
            string viewGr = "";

            //.Br11~Br15 기준으로 
            /*
             * 주사 : 16 ~ 23 =>  viewGr = "I";
                약 : 12 ~ 15  =>    viewGr = "M"
                검사 : 24 ~ 39 =>   viewGr = "C"

             */

            int intValue = 0;

            if (int.TryParse(value, out intValue))
            {

                if (intValue >= 16 && intValue <= 23) viewGr = "I";
                if (intValue >= 12 && intValue <= 15) viewGr = "M";
                if (intValue >= 24 && intValue <= 39) viewGr = "C";
            }

            return viewGr;
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
        // ~ConvertPrescription() {
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
