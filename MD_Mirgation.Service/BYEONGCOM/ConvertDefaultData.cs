using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD_DataMigration.Service.MDPARK;
using MD_DataMigration.Service.MDPARK.model;

namespace MD_DataMigration.Service.BYEONGCOM
{
    public class ConvertDefaultData
    {
        private const string fileName = "sql-byeongcom.xml";

        public event LogEventHandler WorkingInfo;

        private MDPARKService mdParkService;
        public ConvertDefaultData(MDPARKService mDPARKService)
        {
            this.mdParkService = mDPARKService;
        }

        public void Convert()
        {

            string workItem = mdParkService.GetBaseInfo.ConvertItems.FirstOrDefault(x => x == "TCmBsHosSet");

            if (workItem != null)
                //기초자료..처방자료
                ConvertTCmBsHosSet("처방자료", "처방자료");
        }

        /// <summary>
        /// 병컴 수가코드 변환
        /// </summary>
        private void ConvertTCmBsHosSet(string tDbFileName, string tableName)
        {

            using (Data.DatabaseFactory factory = new Data.DatabaseFactory())
            {
                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환시작", tableName));

                
                factory.DatabaseFactoryAccess(tDbFileName);

                string strSql = ReadQuery.GetInstance(fileName).GetQueryText(string.Format("{0}.{1}", tDbFileName, tableName));

                List<TCmBsHosSet> lstTcmBsHosSets = new List<TCmBsHosSet>();

                int revId = 0;
                DataSet ds = factory.ExecuteDataSet(strSql, System.Data.CommandType.Text, null);

                TCmBsHosSet cmBsHosSet = null;

                int price = 0;

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    price = 0;
                    revId = 1;

                    cmBsHosSet = new TCmBsHosSet();
                    cmBsHosSet.MGb = dr["코드구분"].ToString();
                    cmBsHosSet.HosCd = mdParkService.GetBaseInfo.HosCd;

                    cmBsHosSet.McCd = dr["청구코드"].ToString();

                    cmBsHosSet.HangNo = dr["항"].ToString();
                    cmBsHosSet.MoNo = dr["목"].ToString();

                    cmBsHosSet.PmcCd = dr["처방코드"].ToString();
                    cmBsHosSet.Pkor = dr["처방코드"].ToString();

                    cmBsHosSet.SalNoGb = dr["급여구분"].ToString(); //한글로 되어있음

                    cmBsHosSet.Kor = dr["한글명칭"].ToString();
                    cmBsHosSet.OvhdRateGb = "";
                    cmBsHosSet.DSpec = "";
                    cmBsHosSet.DUnit = dr["단위"].ToString();
                    cmBsHosSet.DCompNm = dr["제약사"].ToString();
                    //cmBsHosSet.DstbNo = "";

                    cmBsHosSet.DMainIgdt = dr["성분코드"].ToString();
                    cmBsHosSet.DPsGb = dr["마약분류"].ToString();

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


                    price = GetPrice(dr["재료가"].ToInt32(), dr["행위가"].ToInt32(), dr["일반가"].ToInt32());

                    cmBsHosSet.EdiPrice = price.ToString();
                    cmBsHosSet.GeneralPrice = price.ToString();
                    cmBsHosSet.CarInsPrice = price.ToString();
                    cmBsHosSet.IaciPrice = price.ToString();
                    cmBsHosSet.HighLmtPrice = price.ToString();
                    //cmBsHosSet.CStr = "";
                    cmBsHosSet.EdiRptPrice = price.ToString();


                    cmBsHosSet.UseYn = "Y";

                    cmBsHosSet.RevId = revId;

                    cmBsHosSet.EffFrom = dr["적용일"].ToDateFormatNonDash();
                    cmBsHosSet.EffTo = "29991231";

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

                    //revId++;

                    lstTcmBsHosSets.Add(cmBsHosSet);

                }


                mdParkService.ExecuteInsertData(lstTcmBsHosSets);

                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환종료", "ConvertTCmBsHosSet"));
            }
        }

        private int GetPrice(int a, int b, int c)
        {

            int max= 0;

            if (a >= b)
            {
                max = a;
            }
            else
            {
                max = b;
            }

            if (max < c)
            {
                max = c;
            }

            return max;

        }
    

    }
}
