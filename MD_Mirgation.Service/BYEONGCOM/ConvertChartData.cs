using MD_DataMigration.Service.MDPARK;
using MD_DataMigration.Service.MDPARK.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_DataMigration.Service.BYEONGCOM
{
    public class ConvertChartData
    {
        
        private const string fileName = "sql-byeongcom.xml";

        public event LogEventHandler WorkingInfo;

        private MDPARKService mdParkService;
        public ConvertChartData(MDPARKService mDPARKService, LogEventHandler WorkingInfo)
        {
            this.mdParkService = mDPARKService;
            this.WorkingInfo = WorkingInfo;


        }

        private void ConvertChartData_WorkingInfo(CommonStatic.WORK_RESULT workResult, string message)
        {
            
        }

        private List<string> DynamicDbFileList(string prefix, string filePath)
        {
            List<string> resultList = new List<string>();

            string rootPath = ConfigurationManager.AppSettings.Get("byengcomRootPath");
            string path = rootPath + "\\" + ConfigurationManager.AppSettings.Get(filePath);

            string[] fileLists = Directory.GetFiles(path, string.Format("{0}*.mdb", prefix));


            resultList = fileLists.ToList<string>();

            return resultList;
        }

        /// <summary>
        /// 증상, 진단, 처방 데이터 
        /// </summary>
        public void ConvertData()
        {
            //챠트YYMM
            List<string> orderChartFiles = DynamicDbFileList("챠트", "MSAccessPathChartData");

            //List<string> orderRcvFiles = DynamicDbFileList("월별색인", "MSAccessPathDiagnosisData");

            //처방전YYMM
            List<string> prescriptionFiles = DynamicDbFileList("처방전", "MSAccessPathChartData");

            //접수
            //접수는 진료자료>진료색인 파일에서 처리함.
            //foreach (string dbFile in orderChartFiles)
            //{
            //WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, dbFile);
            //ConvertTMnRcv( "챠트", Path.GetFileNameWithoutExtension(dbFile), "처방_접수");
            //}

            //증상
            foreach (string dbFile in orderChartFiles)
            {
                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, dbFile);
                ConvertTMdSympt("챠트", Path.GetFileNameWithoutExtension(dbFile), "처방_증상");
            }

            //진단
            foreach (string dbFile in orderChartFiles)
            {
                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, dbFile);
                ConvertTMdDx("챠트", Path.GetFileNameWithoutExtension(dbFile), "진단명");
            }

            //처방(수가, 재료)
            foreach (string dbFile in orderChartFiles)
            {
                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, dbFile);
                ConvertTMdPsb("챠트", Path.GetFileNameWithoutExtension(dbFile), "처방");
            }

            //처방전(약가)
            //1101월 부터 특정내역 테이블 존재함.
            string tempQueryId = "";
            foreach(string dbFile in prescriptionFiles)
            {
                Logger.Logger.INFO(dbFile);
                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, dbFile);

                //Path.GetFileNameWithoutExtension(dbFile).Substring(3, 4)
                if (Convert.ToInt32(Path.GetFileNameWithoutExtension(dbFile).Substring(3, 4)) > 1012) //2010년12월 이후
                    tempQueryId = "처방2";
                else
                    tempQueryId = "처방";

                ConvertTMdPsb("처방전", Path.GetFileNameWithoutExtension(dbFile), tempQueryId);
                //ConvertTMdPsb("처방전", Path.GetFileNameWithoutExtension(dbFile), "원내주사"); //원내주사는 처방과 겹침.
            }
        }

        

        #region //챠트자료 변환


        /// <summary>
        /// 접수데이터 입력
        /// </summary>
        /// <param name="tDbFileName"></param>
        /// <param name="dbFileM"></param>
        /// <param name="tableName"></param>
        private void ConvertTMnRcv(string prefixName, string tDbFileName, string tableName)
        {
            using (Data.DatabaseFactory factory = new Data.DatabaseFactory())
            {
                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환시작", "처방_접수" + tDbFileName));

                List<TMnRcv> lstMnRcvs = new List<TMnRcv>();

                #region select
                factory.DatabaseFactoryAccess(tDbFileName, prefixName);

                string strSql = ReadQuery.GetInstance(fileName).GetQueryText(string.Format("{0}.{1}", prefixName, tableName));

                //string strSql2 = ReadQuery.GetInstance(fileName).GetQueryText(string.Format("{0}.{1}", "월별색인", "월별색인")); //젒시간

                #endregion

                DataSet ds = factory.ExecuteDataSet(strSql, System.Data.CommandType.Text, null);

                TMnRcv mnRcv = null;

                #region convert
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    mnRcv = new TMnRcv();


                    mnRcv.HosCd = mdParkService.GetBaseInfo.HosCd; //병원코드

                    try
                    {
                        mnRcv.PtntId = mdParkService.GetPtntIdMdPark(dr["챠트번호"].ToString());
                    }
                    catch (DuplicateNameException ex)
                    {
                        WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("챠트번호 : {0} 1개이상이 존재합니다.", dr["챠트번호"].ToString()));
                        Logger.Logger.INFO(string.Format("챠트번호 : {0} 1개이상이 존재합니다..", dr["챠트번호"].ToString()));
                        continue;
                    }
                    if (mnRcv.PtntId == 0)
                    {
                        WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("챠트번호 : {0} 존재하지 않습니다.", dr["챠트번호"].ToString()));
                        Logger.Logger.INFO(string.Format("챠트번호 : {0} 존재하지 않습니다.", dr["챠트번호"].ToString()));
                        continue;
                    }
                    mnRcv.DeptId = Convert.ToInt32(dr["DEPT_ID"]);
                    mnRcv.DiagType = dr["DIAG_TYPE"].ToString();
                    //mnRcv.ExpCd = "";
                    mnRcv.FstMedGb = dr["FIRST_MED_GB"].ToString();
                    mnRcv.InsDt = dr["진료일자"].ToString();
                    mnRcv.InsId = "TRN";
                    mnRcv.InsIp = "0.0.0.0";
                    mnRcv.InsGb = dr["INSU_GB"].ToString();
                    mnRcv.MedEndDt = dr["진료일자"].ToString();
                    mnRcv.MediSec = 0;
                    mnRcv.MedPayYn = "Y";
                    mnRcv.MedStartDt = dr["진료일자"].ToString();
                    mnRcv.OffId = Convert.ToInt32(dr["DEPT_ID"]);
                    //mnRcv.OldRcvNo = "";
                    mnRcv.OrderDt = dr["진료일자"].ToString();
                    //mnRcv.PacsId = "";
                    mnRcv.PayDt = dr["진료일자"].ToString();

                    mnRcv.RcvDt = dr["진료일자"].ToString();
                    
                    mnRcv.OldRcvNo = dr["챠트번호"].ToString()  + dr["진료일자"].ToString().Replace("-", "");
                    mnRcv.RcvStat = "A"; //
                    //Rcv.ReductCd = "";
                    mnRcv.UpdDt = DateTime.Now.ToString();
                    mnRcv.UpdId = "TRN";
                    mnRcv.UpdIp = "0.0.0.0";
                    mnRcv.UserId = dr["USER_ID"].ToString();
                    mnRcv.UseYn = "Y";

                    lstMnRcvs.Add(mnRcv);

                }

                #endregion

                try
                {
                    mdParkService.ExecuteInsertData(lstMnRcvs);
                    //return lstAcPtntInfo;
                }catch(Exception ex)
                {
                    Logger.Logger.ERROR(ex.Message);
                }


                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환종료", "처방_접수" + tDbFileName));

            }
        }

        /// <summary>
        /// 증상데이터 입력
        /// </summary>
        /// <param name="prefixName"></param>
        /// <param name="tDbFileName"></param>
        /// <param name="tableName"></param>
        /// 
        private void ConvertTMdSympt(string prefixName, string tDbFileName, string tableName)
        {
            using (Data.DatabaseFactory factory = new Data.DatabaseFactory())
            {
                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환시작", "처방_증상" + tDbFileName));

                List<TMdSympt> lstTMdSympt = new List<TMdSympt>();

                #region select
                factory.DatabaseFactoryAccess(tDbFileName, prefixName);

                string strSql = ReadQuery.GetInstance(fileName).GetQueryText(string.Format("{0}.{1}", prefixName, tableName));

                //string strSql2 = ReadQuery.GetInstance(fileName).GetQueryText(string.Format("{0}.{1}", "월별색인", "월별색인")); //젒시간

                #endregion

                DataSet ds = factory.ExecuteDataSet(strSql, System.Data.CommandType.Text, null);

                TMdSympt mdSympt = null;

                int ptntId = 0;
                #region convert

                DataTable dt = ds.Tables[0];
      
                if (dt.Rows.Count == 0) return;

                DataTable dtResult = new DataTable();
                dtResult.Columns.Add("CHART_NO", typeof(string));
                dtResult.Columns.Add("DIAG_DATE", typeof(string));
                dtResult.Columns.Add("SYMPT", typeof(string));


                var result = dt.AsEnumerable()
                              .GroupBy(x => new { ID = x.Field<string>("챠트번호"), DATE = x.Field<string>("진료일자") })
                              .Select  (x => new
                              {
                                 
                                  CHART_NO =  x.Key.ID
                                  ,
                                  DIAG_DATE = x.Key.DATE
                                  ,
                                  SYMPT =string.Join("\n", x.Select(z=>z.Field<string>("SYMPT")))

                                 
                              }).ToList();

                foreach(var item in result)
                {
                    dtResult.Rows.Add(item.CHART_NO, item.DIAG_DATE, item.SYMPT);
                }

                //DataSet drResult = new DataSet();
                //drResult.Tables.Add(dtResult);

                //Logger.Logger.INFO(drResult.GetXml());



                foreach (DataRow dr in dtResult.Rows)
                {

                    mdSympt = new TMdSympt();

                    try
                    {
                        ptntId = mdParkService.GetPtntIdMdPark(dr["CHART_NO"].ToString());
                    }
                    catch (DuplicateNameException ex)
                    {
                        WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("챠트번호 : {0} 1개이상이 존재합니다.", dr["CHART_NO"].ToString()));
                        Logger.Logger.INFO(string.Format("챠트번호 : {0} 1개이상이 존재합니다..", dr["CHART_NO"].ToString()));
                        continue;
                    }

                    mdSympt.RcvId = mdParkService.GetRcvId(ptntId, dr["DIAG_DATE"].ToString());

                    if (mdSympt.RcvId == 0)
                    {
                        WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("접수번호 : PtntID [{0}] 진료일자[{1}] 존재하지 않습니다.", ptntId, dr["DIAG_DATE"].ToString()));
                        Logger.Logger.INFO(string.Format("접수번호 : PtntID [{0}] 진료일자[{1}] 존재하지 않습니다.", ptntId, dr["DIAG_DATE"].ToString()));
                        continue;
                    }


                    mdSympt.Sympt = dr["SYMPT"].ToString();

                    mdSympt.InsDt = dr["DIAG_DATE"].ToString();
                    mdSympt.InsId = "TRN";
                    mdSympt.InsIp = "0.0.0.0";
                    mdSympt.UpdDt = DateTime.Now.ToString();
                    mdSympt.UpdId = "TRN";
                    mdSympt.UpdIp = "0.0.0.0";
                    mdSympt.UseYn = "Y";


                    lstTMdSympt.Add(mdSympt);



                }

                #endregion


                mdParkService.ExecuteInsertData(lstTMdSympt);
       
                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환종료", "처방_증상" + tDbFileName));

            }
        }

        /// <summary>
        /// 진단데이터 입력
        /// </summary>
        /// <param name="prefixName"></param>
        /// <param name="tDbFileName"></param>
        /// <param name="tableName"></param>
        private void ConvertTMdDx(string prefixName, string tDbFileName, string tableName)
        {
            using (Data.DatabaseFactory factory = new Data.DatabaseFactory())
            {
                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환시작", "처방_증상" + tDbFileName));

                List<TMdDx> lstTMdDx = new List<TMdDx>();

                #region select
                factory.DatabaseFactoryAccess(tDbFileName, prefixName);

                string strSql = ReadQuery.GetInstance(fileName).GetQueryText(string.Format("{0}.{1}", prefixName, tableName));

                //string strSql2 = ReadQuery.GetInstance(fileName).GetQueryText(string.Format("{0}.{1}", "월별색인", "월별색인")); //젒시간

                #endregion

                DataSet ds = factory.ExecuteDataSet(strSql, System.Data.CommandType.Text, null);

                TMdDx mdDx = null;

                int ptntId = 0;
                #region convert
                foreach (DataRow dr in ds.Tables[0].Rows)
                {


                    mdDx = new TMdDx();


                    try
                    {
                        ptntId = mdParkService.GetPtntIdMdPark(dr["챠트번호"].ToString());
                    }
                    catch (DuplicateNameException ex)
                    {
                        WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("챠트번호 : {0} 1개이상이 존재합니다.", dr["챠트번호"].ToString()));
                        Logger.Logger.INFO(string.Format("챠트번호 : {0} 1개이상이 존재합니다..", dr["챠트번호"].ToString()));
                        continue;
                    }

                    mdDx.RcvId = mdParkService.GetRcvId(ptntId, dr["진단일자"].ToString());

                    if (mdDx.RcvId == 0)
                    {
                        WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("접수번호 : 챠트번호 [{0}] 진료일자[{1}] 존재하지 않습니다.", dr["챠트번호"].ToString(), dr["진단일자"].ToString()));
                        Logger.Logger.INFO(string.Format("접수번호 : 챠트번호 [{0}] 진료일자[{1}] 존재하지 않습니다.", dr["챠트번호"].ToString(), dr["진단일자"].ToString()));
                        continue;
                    }

                    mdDx.DzCd = dr["병명코드"].ToString();
                    mdDx.DzNm = dr["진단명"].ToString();


                    mdDx.MainYn = dr["순번"].ToString() =="1"? "Y":"N";
                    mdDx.LawDzGb = "";
                    mdDx.ReportYn = "";


                    mdDx.InsDt = dr["진단일자"].ToString();
                    mdDx.InsId = "TRN";
                    mdDx.InsIp = "0.0.0.0";
                    mdDx.UpdDt = DateTime.Now.ToString();
                    mdDx.UpdId = "TRN";
                    mdDx.UpdIp = "0.0.0.0";
                    mdDx.UseYn = "Y";


                    lstTMdDx.Add(mdDx);

                }

                #endregion


                mdParkService.ExecuteInsertData(lstTMdDx);

                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환종료", "처방_증상" + tDbFileName));

            }
        }
        
        /// <summary>
        /// 처방데이터 입력
        /// </summary>
        /// <param name="prefixName"></param>
        /// <param name="tDbFileName"></param>
        /// <param name="tableName"></param>
        private void ConvertTMdPsb(string prefixName, string tDbFileName, string tableName)
        {
            using (Data.DatabaseFactory factory = new Data.DatabaseFactory())
            {
                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환시작", "처방" + tDbFileName));

                List<TMdPsb> lstTMdPsb = new List<TMdPsb>();

                //줄단위 메모 데이터
                List<TMdPsbLine> lstTMPsbLine = new List<TMdPsbLine>();

                #region select
                factory.DatabaseFactoryAccess(tDbFileName, prefixName);

                string strSql = ReadQuery.GetInstance(fileName).GetQueryText(string.Format("{0}.{1}", prefixName, tableName));

                //string strSql2 = ReadQuery.GetInstance(fileName).GetQueryText(string.Format("{0}.{1}", "월별색인", "월별색인")); //젒시간

                #endregion

                DataSet ds = factory.ExecuteDataSet(strSql, System.Data.CommandType.Text, null);

                TMdPsb mdPsb = null;

                string dateName = prefixName.Equals("처방전") ? "발행일자" : "진료일자";

                int ptntId = 0;
                #region convert

                string psbGb = "";
                string viewGr = "";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    mdPsb = new TMdPsb();

                    try
                    {
                        ptntId = mdParkService.GetPtntIdMdPark(dr["챠트번호"].ToString());
                    }
                    catch (DuplicateNameException ex)
                    {
                        WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, string.Format("챠트번호 : {0} 1개이상이 존재합니다.", dr["챠트번호"].ToString()));
                        Logger.Logger.INFO(string.Format("챠트번호 : {0} 1개이상이 존재합니다..", dr["챠트번호"].ToString()));
                        continue;
                    }


                    mdPsb.RcvId = mdParkService.GetRcvId(ptntId, dr[dateName].ToString());

                    if (mdPsb.RcvId == 0)
                    {
                        Logger.Logger.INFO(string.Format("접수번호 : 챠트번호 [{0}] 진료일자[{1}] 존재하지 않습니다.", dr["챠트번호"].ToString(), dr[dateName].ToString()));
                        continue;
                    }

                    mdPsb.PsbCd = dr["처방코드"].ToString();
                    //mdPsb.PsbNm = dr["처방명칭"].ToString();

                    switch (dr["코드구분"].ToString())
                    {
                        case "1":
                            psbGb = "M"; //약가
                            break;
                        case "3":
                            psbGb = "D"; //수가
                            break;
                        case "8":
                            psbGb = "Z"; //재료
                            break;
                    }

                    switch (dr["항"].ToString())
                    {
                        case "04":
                            viewGr = "I"; //
                            break;
                        case "09":
                        case "10":
                        case "S":
                            viewGr = "C"; 
                            break;
                        case "03":
                            viewGr = "M"; //
                            break;
                    }

                    //mdPsb.MGb = psbGb;
                    //mdPsb.ViewGr = viewGr;

                    //mdPsb.PsbPrice = "";

                    mdPsb.Qd = dr["용량"].ToString();
                    mdPsb.Sd = dr["일투"].ToString();
                    mdPsb.Td = dr["일수"].ToString();

                    mdPsb.InOutGb = "";

                    mdPsb.SalGb = "";

                    if (prefixName.Equals("챠트"))
                    {
                        mdPsb.HangNo = dr["항"].ToString();
                        mdPsb.MoNo = dr["목"].ToString();
                        //mdPsb.CdGb = dr["코드구분"].ToString();
                    }
                    
                    mdPsb.UnitPrice = "0"; //단가
                    //mdPsb.Spec = ""; //스펙
                    
                    if (prefixName.Equals("처방전"))
                    {
                        //mdPsb.DrugUnit = ""; //약단위
                    }

                    mdPsb.ExamChkYn = ""; //검사 확인여부
                    mdPsb.ExamChkDt = ""; //검사 확인 일시
                    mdPsb.ExamChkUserId = ""; //검사 확인 사용자 ID

                    //mdPsb.LineCd = dr["내역코드"].ToString().Equals("")? null: dr["내역코드"].ToString(); //줄단위 구분코드
                    //mdPsb.LineMmoTxt = dr["내역"].ToString().Equals("")? null: dr["내역"].ToString(); //줄단위 메모 txt

                    if (!dr["내역코드"].ToString().Equals(""))
                    {
                        TMdPsbLine mdPsbLine = new TMdPsbLine();

                        mdPsbLine.PsbCd = mdPsb.PsbCd;
                        mdPsbLine.RcvId = mdPsb.RcvId;

                        mdPsbLine.LineCd = dr["내역코드"].ToString();
                        mdPsbLine.LineMmoTxt = dr["내역"].ToString();

                        mdPsbLine.InsDt = dr["Ymd"].ToString();
                        mdPsbLine.InsId = "TRN";
                        mdPsbLine.InsIp = "0.0.0.0";
                        mdPsbLine.UpdDt = DateTime.Now.ToString();
                        mdPsbLine.UpdId = "TRN";
                        mdPsbLine.UpdIp = "0.0.0.0";
                        mdPsbLine.UseYn = "Y";

                        lstTMPsbLine.Add(mdPsbLine);
                    }

                    mdPsb.InsDt = dr[dateName].ToString();
                    mdPsb.InsId = "TRN";
                    mdPsb.InsIp = "0.0.0.0";
                    mdPsb.UpdDt = DateTime.Now.ToString();
                    mdPsb.UpdId = "TRN";
                    mdPsb.UpdIp = "0.0.0.0";
                    mdPsb.UseYn = "Y";

                    lstTMdPsb.Add(mdPsb);

                }
                  
                #endregion

                mdParkService.ExecuteInsertData(lstTMdPsb);

                //줄단위 메모데이터 처리
                foreach (TMdPsbLine item in lstTMPsbLine)
                {
                    item.PsbId = mdParkService.GetPsbId(item.RcvId, item.PsbCd);

                    if (item.PsbId == 0)
                    {
                        WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.FAIL, string.Format("접수번호 : {0} 가 psb_id 정보에 존재하지 않음. 처방코드={1} ", item.RcvId, item.PsbCd));
                        Logger.Logger.INFO(string.Format("접수번호 : {0} 가 psb_id 정보에 존재하지 않음. 처방코드={1} ", item.RcvId, item.PsbCd));
                    }
                }

                mdParkService.ExecuteInsertData(lstTMPsbLine);

                WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE, String.Format("{0} 변환종료", "처방" + tDbFileName));

            }
        }

        #endregion
    }
}
