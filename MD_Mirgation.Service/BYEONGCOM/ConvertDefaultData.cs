using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD_DataMigration.Data;
using MD_DataMigration.Service.MDPARK;
using MD_DataMigration.Service.MDPARK.model;

namespace MD_DataMigration.Service.BYEONGCOM
{
    public class ConvertDefaultData
    {
        private Dictionary<string, string> category = new Dictionary<string, string>();
        private Dictionary<string, string> drugCategory = new Dictionary<string, string>();
        private string bunchUserId;

        private const string fileName = "sql-byeongcom.xml";

        public event LogEventHandler WorkingInfo;

        private MDPARKService mdParkService;
        public ConvertDefaultData(MDPARKService mDPARKService)
        {
            this.mdParkService = mDPARKService;
        }

        public void ConvertData()
        {

            string workItem = mdParkService.GetBaseInfo.ConvertItems.FirstOrDefault(x => x == "TCmBsHosSet");

            if (workItem != null)
                //기초자료..처방자료
                ConvertTCmBsHosSet("처방자료", "처방자료");

            if (this.mdParkService.GetBaseInfo.ConvertItems.FirstOrDefault<string>((Func<string, bool>)(x => x == "TMdBunch")) != null)
            {
                this.ConvertTMdBunchCate("참고자료", "묶음분류");
                this.ConvertTMdBunch("참고자료", "묶음처방");
                this.ConvertTMdBunchRxAndDiag("참고자료", "묶음처방내용");
                this.ConvertTMdBunchAuth();
            }
            if (this.mdParkService.GetBaseInfo.ConvertItems.FirstOrDefault<string>((Func<string, bool>)(x => x == "TMdBunchDrug")) != null)
            {
                this.mdParkService.convertedTMdBunchCate = (List<TMdBunchCate>)null;
                this.mdParkService.convertedTMdBunch = (List<TMdBunch>)null;
                this.ConvertTMdBunchDrugCate("참고자료", "처방");
                this.ConvertTMdBunchDrug();
                this.ConvertTMdBunchDrugDetail("참고자료", "처방");
                this.ConvertTMdBunchDrugAuth();
            }
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
            int num = a < b ? b : a;
            if (num < c)
                num = c;
            return num;
        }

        private void ConvertTMdBunchCate(string tDbFileName, string tableName)
        {
            MD_DataMigration.Service.LogEventHandler workingInfo1 = this.WorkingInfo;
            if (workingInfo1 != null)
                workingInfo1(CommonStatic.WORK_RESULT.NONE, string.Format("{0} 변환시작", (object)nameof(ConvertTMdBunchCate)));
            using (DatabaseFactory databaseFactory = new DatabaseFactory())
            {
                MD_DataMigration.Service.LogEventHandler workingInfo2 = this.WorkingInfo;
                if (workingInfo2 != null)
                    workingInfo2(CommonStatic.WORK_RESULT.NONE, string.Format("{0} 변환시작", (object)tableName));
                databaseFactory.DatabaseFactoryAccess(tDbFileName);
                string queryText = ReadQuery.GetInstance("sql-byeongcom.xml").GetQueryText(string.Format("{0}.{1}", (object)tDbFileName, (object)tableName));
                foreach (DataRow row in (InternalDataCollectionBase)databaseFactory.ExecuteDataSet(queryText, CommandType.Text, (IDbDataParameter[])null).Tables[0].Rows)
                    this.category.Add(row["그룹"].ToStringTrim(), row["내용"].ToStringTrim());
            }
            List<TMdBunchCate> data = new List<TMdBunchCate>();
            int num = 0;
            foreach (KeyValuePair<string, string> keyValuePair in this.category)
            {
                data.Add(new TMdBunchCate()
                {
                    CateGb = "1"
                  , UserId = this.bunchUserId
                  , CateBunchNm = keyValuePair.Value
                  , CateSeq = ++num
                  , UseYn = "Y"
                  , InsDt = DateTime.Now.ToString()
                  , InsId = "TRN"
                  , InsIp = "0.0.0.0"
                  , UpdDt = DateTime.Now.ToString()
                  , UpdId = "TRN"
                  , UpdIp = "0.0.0.0"
                });
            }
            this.mdParkService.ExecuteInsertData<TMdBunchCate>(data);
            MD_DataMigration.Service.LogEventHandler workingInfo3 = this.WorkingInfo;
            if (workingInfo3 == null)
                return;
            workingInfo3(CommonStatic.WORK_RESULT.NONE, string.Format("{0} 변환종료", (object)nameof(ConvertTMdBunchCate)));
        }

        private void ConvertTMdBunch(string tDbFileName, string tableName)
        {
            MD_DataMigration.Service.LogEventHandler workingInfo1 = this.WorkingInfo;
            if (workingInfo1 != null)
                workingInfo1(CommonStatic.WORK_RESULT.NONE, string.Format("{0} 변환시작", (object)nameof(ConvertTMdBunch)));
            using (DatabaseFactory databaseFactory = new DatabaseFactory())
            {
                MD_DataMigration.Service.LogEventHandler workingInfo2 = this.WorkingInfo;
                if (workingInfo2 != null)
                    workingInfo2(CommonStatic.WORK_RESULT.NONE, string.Format("{0} 변환시작", (object)tableName));
                databaseFactory.DatabaseFactoryAccess(tDbFileName);
                string queryText = ReadQuery.GetInstance(fileName).GetQueryText(string.Format("{0}.{1}", (object)tDbFileName, (object)tableName));
                DataSet dataSet = databaseFactory.ExecuteDataSet(queryText, CommandType.Text, (IDbDataParameter[])null);
                List<TMdBunch> data = new List<TMdBunch>();
                int num = 0;
                foreach (DataRow row in (InternalDataCollectionBase)dataSet.Tables[0].Rows)
                {
                    if (row["그룹"].ToStringTrim().Length > 0)
                    {
                        data.Add(new TMdBunch()
                        {
                            CateBunchId = this.retrieveTMdBunchCate(row["그룹"].ToStringTrim()).CateBunchId
                            , BunchCd = row["코드"].ToStringTrim()
                            , BunchNm = row["내용"].ToStringTrim()
                            , BunchSeq = ++num
                            , UseYn = "Y"
                            , InsDt = DateTime.Now.ToString()
                            , InsId = "TRN"
                            , InsIp = "0.0.0.0"             
                            , UpdDt = DateTime.Now.ToString()
                            , UpdId = "TRN"
                            , UpdIp = "0.0.0.0"
                        });

                    }
                }
                this.mdParkService.ExecuteInsertData<TMdBunch>(data);
                MD_DataMigration.Service.LogEventHandler workingInfo3 = this.WorkingInfo;
                if (workingInfo3 == null)
                    return;
                workingInfo3(CommonStatic.WORK_RESULT.NONE, string.Format("{0} 변환종료", (object)nameof(ConvertTMdBunch)));
            }
        }

        private TMdBunchCate retrieveTMdBunchCate(string groupCode)
        {
            string cateBunchNm = "";
            foreach (KeyValuePair<string, string> keyValuePair in this.category)
            {
                if (groupCode.Equals(keyValuePair.Key))
                    cateBunchNm = keyValuePair.Value;
            }
            return this.mdParkService.retrieveTMdBunchCate(this.bunchUserId, "1").First<TMdBunchCate>((Func<TMdBunchCate, bool>)(x => x.CateBunchNm == cateBunchNm));
        }

        private void ConvertTMdBunchRxAndDiag(string tDbFileName, string tableName)
        {
            MD_DataMigration.Service.LogEventHandler workingInfo1 = this.WorkingInfo;
            if (workingInfo1 != null)
                workingInfo1(CommonStatic.WORK_RESULT.NONE, string.Format("{0} 변환시작", (object)"ConvertTMdBunchRx"));
            using (DatabaseFactory databaseFactory = new DatabaseFactory())
            {
                MD_DataMigration.Service.LogEventHandler workingInfo2 = this.WorkingInfo;
                if (workingInfo2 != null)
                    workingInfo2(CommonStatic.WORK_RESULT.NONE, string.Format("{0} 변환시작", (object)tableName));
                databaseFactory.DatabaseFactoryAccess(tDbFileName);
                string queryText = ReadQuery.GetInstance("sql-byeongcom.xml").GetQueryText(string.Format("{0}.{1}", (object)tDbFileName, (object)tableName));
                DataSet dataSet = databaseFactory.ExecuteDataSet(queryText, CommandType.Text, (IDbDataParameter[])null);
                List<TMdBunchDiag> data1 = new List<TMdBunchDiag>();
                List<TMdBunchRx> data2 = new List<TMdBunchRx>();
                foreach (DataRow row in (InternalDataCollectionBase)dataSet.Tables[0].Rows)
                {
                    DataRow dr = row;
                    TMdBunch tmdBunch = this.mdParkService.retrieveTMdBunch(this.bunchUserId, "1").FirstOrDefault<TMdBunch>((Func<TMdBunch, bool>)(x => x.BunchCd == dr["묶음처방"].ToStringTrim()));
                    if (tmdBunch == null)
                    {
                        MD_DataMigration.Service.LogEventHandler workingInfo3 = this.WorkingInfo;
                        if (workingInfo3 != null)
                            workingInfo3(CommonStatic.WORK_RESULT.NONE, string.Format("묶음처방코드 [{0}]에 해당하는 분류코드가 존재하지 않습니다.", (object)dr["묶음처방"].ToString()));
                        Logger.Logger.INFO(string.Format("묶음처방코드 [{0}]에 해당하는 분류코드가 존재하지 않습니다.", (object)dr["묶음처방"].ToString()));
                    }
                    else
                    {
                        int bunchId = tmdBunch.BunchId;
                       
                        if ("1".Equals(dr["병명"].ToStringTrim()))
                        {
                            data1.Add(new TMdBunchDiag()
                            {
                                BunchId = bunchId
                               , BunchDiagCd = dr["처방코드"].ToStringTrim()
                               , BunchDiagNm = dr["처방명칭"].ToStringTrim()
                               , UseYn = "Y"
                               , InsDt = DateTime.Now.ToString()
                               , InsId = "TRN"
                               , InsIp = "0.0.0.0"
                               , UpdDt = DateTime.Now.ToString()
                               , UpdId = "TRN"
                               , UpdIp = "0.0.0.0"
                            });
                        }
                        else
                        {
                            data2.Add(new TMdBunchRx()
                            {
                                BunchId = bunchId
                                , BunchRxCd = dr["처방코드"].ToStringTrim()
                                , BunchCnt = dr["횟수"].ToStringTrim()
                                , BunchDay = dr["일수"].ToStringTrim()
                                , BunchQty = dr["용량"].ToStringTrim()
                                , BunchUsg = dr["용법"].ToStringTrim()
                                , BunchSts = ""
                                , InOutGb = ""
                                , UseYn = "Y"
                                , InsDt = DateTime.Now.ToString()
                                , InsId = "TRN"
                                , InsIp = "0.0.0.0"
                                , UpdDt = DateTime.Now.ToString()
                                , UpdId = "TRN"
                                , UpdIp = "0.0.0.0"
                            });
                            
               
                        }
                    }
                }
                this.mdParkService.ExecuteInsertData<TMdBunchDiag>(data1);
                this.mdParkService.ExecuteInsertData<TMdBunchRx>(data2);
                MD_DataMigration.Service.LogEventHandler workingInfo4 = this.WorkingInfo;
                if (workingInfo4 == null)
                    return;
                workingInfo4(CommonStatic.WORK_RESULT.NONE, string.Format("{0} 변환종료", (object)"ConvertTMdBunchRx"));
            }
        }

        private void ConvertTMdBunchAuth()
        {
            MD_DataMigration.Service.LogEventHandler workingInfo1 = this.WorkingInfo;
            if (workingInfo1 != null)
                workingInfo1(CommonStatic.WORK_RESULT.NONE, string.Format("{0} 변환시작", (object)nameof(ConvertTMdBunchAuth)));
            List<TMdBunchAuth> data = new List<TMdBunchAuth>();
            foreach (TMdBunch tmdBunch in this.mdParkService.retrieveTMdBunch(this.bunchUserId, "1"))
                data.Add(new TMdBunchAuth()
                {
                    BunchId = tmdBunch.BunchId,
                    UserId = this.bunchUserId,
                    UseYn = "Y",
                    InsDt = DateTime.Now.ToString(),
                    InsId = "TRN",
                    InsIp = "0.0.0.0",
                    UpdDt = DateTime.Now.ToString(),
                    UpdId = "TRN",
                    UpdIp = "0.0.0.0"
                });
            this.mdParkService.ExecuteInsertData<TMdBunchAuth>(data);
            MD_DataMigration.Service.LogEventHandler workingInfo2 = this.WorkingInfo;
            if (workingInfo2 == null)
                return;
            workingInfo2(CommonStatic.WORK_RESULT.NONE, string.Format("{0} 변환종료", (object)nameof(ConvertTMdBunchAuth)));
        }

        private void ConvertTMdBunchDrugCate(string tDbFileName, string tableName)
        {
            MD_DataMigration.Service.LogEventHandler workingInfo1 = this.WorkingInfo;
            if (workingInfo1 != null)
                workingInfo1(CommonStatic.WORK_RESULT.NONE, string.Format("{0} 변환시작", (object)nameof(ConvertTMdBunchDrugCate)));
            using (DatabaseFactory databaseFactory = new DatabaseFactory())
            {
                MD_DataMigration.Service.LogEventHandler workingInfo2 = this.WorkingInfo;
                if (workingInfo2 != null)
                    workingInfo2(CommonStatic.WORK_RESULT.NONE, string.Format("{0} 변환시작", (object)tableName));
                databaseFactory.DatabaseFactoryAccess(tDbFileName);
                string queryText = ReadQuery.GetInstance("sql-byeongcom.xml").GetQueryText(string.Format("{0}.{1}", (object)tDbFileName, (object)tableName));
                foreach (DataRow row in (InternalDataCollectionBase)databaseFactory.ExecuteDataSet(queryText, CommandType.Text, (IDbDataParameter[])null).Tables[0].Rows)
                {
                    if ("1".Equals(row["비고"].ToStringTrim()))
                        this.drugCategory.Add(row["그룹"].ToStringTrim(), row["내용"].ToStringTrim());
                }
            }
            List<TMdBunchCate> data = new List<TMdBunchCate>();
            int num = 0;
            foreach (KeyValuePair<string, string> keyValuePair in this.drugCategory)
            {
                data.Add(new TMdBunchCate()
                {
                    CateGb = "2"
                    , UserId = this.bunchUserId
                    , CateBunchNm = keyValuePair.Value
                    , CateSeq = ++num
                    , UseYn = "Y"
                    , InsDt = DateTime.Now.ToString()
                    , InsId = "TRN"
                    , InsIp = "0.0.0.0"
                    , UpdDt = DateTime.Now.ToString()
                    , UpdId = "TRN"
                    , UpdIp = "0.0.0.0"
                });
            }
            this.mdParkService.ExecuteInsertData<TMdBunchCate>(data);
            MD_DataMigration.Service.LogEventHandler workingInfo3 = this.WorkingInfo;
            if (workingInfo3 == null)
                return;
            workingInfo3(CommonStatic.WORK_RESULT.NONE, string.Format("{0} 변환종료", (object)nameof(ConvertTMdBunchDrugCate)));
        }

        private TMdBunchCate retrieveTMdBunchDrugCate(string groupCode)
        {
            string cateBunchNm = "";
            foreach (KeyValuePair<string, string> keyValuePair in this.drugCategory)
            {
                if (groupCode.Equals(keyValuePair.Key))
                    cateBunchNm = keyValuePair.Value;
            }
            return this.mdParkService.retrieveTMdBunchCate(this.bunchUserId, "2").First<TMdBunchCate>((Func<TMdBunchCate, bool>)(x => x.CateBunchNm == cateBunchNm));
        }

        private void ConvertTMdBunchDrug()
        {
            List<TMdBunch> data = new List<TMdBunch>();
            int num = 1;
            foreach (KeyValuePair<string, string> keyValuePair in this.drugCategory)
            {
                TMdBunch tmdBunch1 = new TMdBunch();
                tmdBunch1.CateBunchId = this.retrieveTMdBunchDrugCate(keyValuePair.Key).CateBunchId;
                tmdBunch1.BunchCd = keyValuePair.Key;
                tmdBunch1.BunchNm = keyValuePair.Value;
                tmdBunch1.BunchSeq = num;
                tmdBunch1.UseYn = "Y";

                tmdBunch1.InsDt = DateTime.Now.ToString();
                tmdBunch1.InsId = "TRN";
                tmdBunch1.InsIp = "0.0.0.0";
                tmdBunch1.UpdDt = DateTime.Now.ToString();
                tmdBunch1.UpdId = "TRN";
                tmdBunch1.UpdIp = "0.0.0.0";

                num++;
                data.Add(tmdBunch1);
            }
            this.mdParkService.ExecuteInsertData<TMdBunch>(data);
            MD_DataMigration.Service.LogEventHandler workingInfo = this.WorkingInfo;
            if (workingInfo == null)
                return;
            workingInfo(CommonStatic.WORK_RESULT.NONE, string.Format("{0} 변환종료", (object)"ConvertTMdBunch"));
        }

        private void ConvertTMdBunchDrugDetail(string tDbFileName, string tableName)
        {
            MD_DataMigration.Service.LogEventHandler workingInfo1 = this.WorkingInfo;
            if (workingInfo1 != null)
                workingInfo1(CommonStatic.WORK_RESULT.NONE, string.Format("{0} 변환시작", (object)nameof(ConvertTMdBunchDrugDetail)));
            using (DatabaseFactory databaseFactory = new DatabaseFactory())
            {
                MD_DataMigration.Service.LogEventHandler workingInfo2 = this.WorkingInfo;
                if (workingInfo2 != null)
                    workingInfo2(CommonStatic.WORK_RESULT.NONE, string.Format("{0} 변환시작", (object)tableName));
                databaseFactory.DatabaseFactoryAccess(tDbFileName);
                string queryText = ReadQuery.GetInstance("sql-byeongcom.xml").GetQueryText(string.Format("{0}.{1}", (object)tDbFileName, (object)tableName));
                DataSet dataSet = databaseFactory.ExecuteDataSet(queryText, CommandType.Text, (IDbDataParameter[])null);
                List<TMdBunchRx> data = new List<TMdBunchRx>();
                foreach (DataRow row in (InternalDataCollectionBase)dataSet.Tables[0].Rows)
                {
                    DataRow dr = row;
                    if (!"1".Equals(dr["비고"].ToStringTrim()))
                    {
                        TMdBunch tmdBunch = this.mdParkService.retrieveTMdBunch(this.bunchUserId, "2").FirstOrDefault<TMdBunch>((Func<TMdBunch, bool>)(x => x.BunchCd == dr["그룹"].ToStringTrim()));
                        if (tmdBunch == null)
                        {
                            MD_DataMigration.Service.LogEventHandler workingInfo3 = this.WorkingInfo;
                            if (workingInfo3 != null)
                                workingInfo3(CommonStatic.WORK_RESULT.NONE, string.Format("묶음처방코드 [{0}]에 해당하는 분류코드가 존재하지 않습니다.", (object)dr["그룹"].ToString()));
                            Logger.Logger.INFO(string.Format("묶음처방코드 [{0}]에 해당하는 분류코드가 존재하지 않습니다.", (object)dr["그룹"].ToString()));
                        }
                        else
                        {
                            int bunchId = tmdBunch.BunchId;
                            data.Add(new TMdBunchRx()
                            {
                                BunchId = bunchId,
                                BunchRxCd = dr["코드"].ToStringTrim(),
                                BunchCnt = "",
                                BunchDay = "",
                                BunchQty = "",
                                BunchUsg = "",
                                BunchSts = "",
                                InOutGb = "",
                                UseYn = "Y",
                                InsDt = DateTime.Now.ToString(),
                                InsId = "TRN",
                                InsIp = "0.0.0.0",
                                UpdDt = DateTime.Now.ToString(),
                                UpdId = "TRN",
                                UpdIp = "0.0.0.0"
                            });
                        }
                    }
                }
                this.mdParkService.ExecuteInsertData<TMdBunchRx>(data);
            }
            MD_DataMigration.Service.LogEventHandler workingInfo4 = this.WorkingInfo;
            if (workingInfo4 == null)
                return;
            workingInfo4(CommonStatic.WORK_RESULT.NONE, string.Format("{0} 변환종료", (object)nameof(ConvertTMdBunchDrugDetail)));
        }

        private void ConvertTMdBunchDrugAuth()
        {
            MD_DataMigration.Service.LogEventHandler workingInfo1 = this.WorkingInfo;
            if (workingInfo1 != null)
                workingInfo1(CommonStatic.WORK_RESULT.NONE, string.Format("{0} 변환시작", (object)nameof(ConvertTMdBunchDrugAuth)));
            List<TMdBunchAuth> data = new List<TMdBunchAuth>();
            foreach (TMdBunch tmdBunch in this.mdParkService.retrieveTMdBunch(this.bunchUserId, "2"))
                data.Add(new TMdBunchAuth()
                {
                    BunchId = tmdBunch.BunchId,
                    UserId = this.bunchUserId,
                    UseYn = "Y",
                    InsDt = DateTime.Now.ToString(),
                    InsId = "TRN",
                    InsIp = "0.0.0.0",
                    UpdDt = DateTime.Now.ToString(),
                    UpdId = "TRN",
                    UpdIp = "0.0.0.0"
                });
            this.mdParkService.ExecuteInsertData<TMdBunchAuth>(data);
            MD_DataMigration.Service.LogEventHandler workingInfo2 = this.WorkingInfo;
            if (workingInfo2 == null)
                return;
            workingInfo2(CommonStatic.WORK_RESULT.NONE, string.Format("{0} 변환종료", (object)nameof(ConvertTMdBunchDrugAuth)));
        }


    }
}
