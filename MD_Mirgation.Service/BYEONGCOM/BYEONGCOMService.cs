using MD_DataMigration.Service.MDPARK;
using MD_DataMigration.Service.MDPARK.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace MD_DataMigration.Service.BYEONGCOM
{
    public class BYEONGCOMService: IConvert, IDisposable
    {

        private const string TARGET_DB = "MariaDbMDPark";
       
        private BaseInfo baseInfo;

        private MDPARKService mdParkService; 

        public event LogEventHandler WorkingInfo;
        public event EventHandler Convert_Completed;

        public void Dispose()
        {
     
        }

        private void MdParkService_WorkingInfo(CommonStatic.WORK_RESULT workResult, string message)
        {
            WorkingInfo?.Invoke(workResult, message);
        }


        public DbDataReader TestConnection()
        {
            DbDataReader dr = null;
            //using (Data.DatabaseFactory factory = new Data.DatabaseFactory())
            //{

            Data.DatabaseFactory factory = new Data.DatabaseFactory();
            factory.DatabaseFactoryAccess("일반서식");
            dr = factory.ExecuteReader("Select top 10 * FROM 서식내용", CommandType.Text, null);
            //if (dr.HasRows)
            //{
            //    while (dr.Read())
            //    {
            //        Console.WriteLine(dr["서식"].ToString());
            //    }
            //}


            //}

            return dr;
        }

        /// <summary>
        /// Start Convert
        /// </summary>
        /// <param name="hosCd"></param>
        public void StartConvert(BaseInfo baseInfo)
        {
           
            mdParkService = new MDPARKService(TARGET_DB);
            mdParkService.WorkingInfo += MdParkService_WorkingInfo;
            mdParkService.StartConvert(baseInfo);

            this.baseInfo = baseInfo;

            
            Logger.Logger.INFO("BYEONGCOMService StartConvert");
            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE,  "BYEONGCOMService StartConvert");

            //환자정보 변환
            ConvertPntnInfo();



            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE,  "BYEONGCOMService EndConvert");
           
           
        }

  

        /// <summary>
        /// 환자정보 변환
        /// </summary>
        private void ConvertPntnInfo()
        {
        
            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE,  "환자정보 변환시작");
            List<AcPtntInfo> AcPtntInfos = SelectPatientBaseInfo();

            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE,  string.Format("변환대상 수:{0}", AcPtntInfos.Count));

            //mdParkService.InsertPntnInfo(AcPtntInfos);
            mdParkService.InsertInfo(AcPtntInfos);
            WorkingInfo?.Invoke(CommonStatic.WORK_RESULT.NONE,  "환자정보 변환종료");

        }

        

        #region //데이터 조회

        /// <summary>
        /// 환자 기본정보 조회
        /// </summary>
        /// <returns></returns>
        private List<AcPtntInfo> SelectPatientBaseInfo()
        {
            using (Data.DatabaseFactory factory = new Data.DatabaseFactory())
            {

                List<AcPtntInfo> lstAcPtntInfo = new List<AcPtntInfo>();

                factory.DatabaseFactoryAccess("환자정보");
                string strSql = @"SELECT TOP 100
	                환자정보.[챠트번호]
                   ,환자정보.[수진자명]
                   ,환자정보.[주민등록]
                   ,환자정보.[전화번호]
                   ,환자정보.[우편번호]
                   ,환자정보.[주소1]
                   ,환자정보.[주소2]
                   ,환자정보.[메모1]
                   ,환자정보.[메모2]
                   ,환자정보.[가족번호]
                   ,환자정보.[가족메모]
                   ,환자정보.[성별]
                   ,환자정보.[나이]
                   ,환자정보.[개월수]
                   ,환자정보.[체온]
                   ,환자정보.[체중]
                   ,환자정보.[혈압1]
                   ,환자정보.[혈압2]
                   ,환자정보.[최초접수일]
                   ,환자정보.[보험적용일]
                   ,환자정보.[조합기호]
                   ,환자정보.[조합명칭]
                   ,환자정보.[조합구분]
                   ,환자정보.[증번호]
                   ,환자정보.[피보험자]
                   ,환자정보.[관계]
                   ,환자정보.[보험구분]
                   ,환자정보.[보호종별]
                   ,환자정보.[진료구분]
                   ,환자정보.[진료과]
                   ,환자정보.[접수구분]
                   ,환자정보.[자료변경일자]
                   ,환자정보.[자료변경자]
                   ,환자정보.[등록번호]
                   ,환자정보.[약국코드]
                   ,환자정보.[약국명칭]
                   ,환자정보.[원내환자구분]
                   ,환자정보.[보조필드]
                   ,환자정보.[여분필드]
                   ,환자정보.[여분문자열]
                   ,환자정보.[보조문자열]
                   ,환자정보.[사진경로]
                   ,환자정보.[휴대폰번호]
                   ,환자정보.[임신일자]
                   ,환자정보.[출산일자]
                   ,환자정보.[생년월일]
                   ,환자정보.[전자메일]
                   ,환자정보.[본인부담여부]
                   ,환자정보.[공제누락]
                   ,환자정보.[본부구분]
                   ,환자정보.[임부구분]
                   ,환자정보.[인식번호]
                   ,환자정보.[질환보고]
                   ,환자정보.[정보동의]
                   ,환자정보.[만성질환관리]
                   ,환자정보.[남여구분]
                   ,환자정보.[주민번호오류]
                   ,환자정보.[최종내원일]
                FROM 환자정보;";
                DataSet ds = factory.ExcuteDatSet(strSql, CommandType.Text, null);

                AcPtntInfo AcPtntInfo = null;
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    AcPtntInfo = new AcPtntInfo();
                    AcPtntInfo.HosCd = baseInfo.HosCd;
                    AcPtntInfo.PtntId = dr["챠트번호"].ToString();                    
                    AcPtntInfo.PtntNm = dr["수진자명"].ToString();
                    //AcPtntInfo.ResRegNo1 = dr["주민등록"].ToString();
                    //AcPtntInfo.ResRegNo2 = dr["주민등록"].ToString();
                   // AcPtntInfo.BirthYmd = dr["생년월일"].ToString();
                    AcPtntInfo.Sex = dr["남여구분"].ToString();
                    
                    AcPtntInfo.ZipNo = dr["우편번호"].ToString();
                    AcPtntInfo.Addr = dr["주소1"].ToString();
                    AcPtntInfo.Addr2 = dr["주소2"].ToString();
                    AcPtntInfo.MobNo = dr["휴대폰번호"].ToString();
                    AcPtntInfo.TelNo1 = dr["전화번호"].ToString();
                    //AcPtntInfo.TelNm1 = dr[""].ToString();
                    //AcPtntInfo.TelNo2 = dr[""].ToString();
                    //AcPtntInfo.TelNm2 = dr[""].ToString();
                    //AcPtntInfo.TelNo3 = dr[""].ToString();
                    //AcPtntInfo.TelNm3 = dr[""].ToString();
                    AcPtntInfo.IndvdlinfoAgreYn = dr["정보동의"].ToString();
                    AcPtntInfo.ChdsesMngYn = dr["만성질환관리"].ToString();
                    AcPtntInfo.PrgncYn = dr["임부구분"].ToString();
                    AcPtntInfo.SmsRcveYn = dr["정보동의"].ToString();
                    AcPtntInfo.Email = dr["전자메일"].ToString();
                    //AcPtntInfo.AboTy = dr[""].ToString(); //혈액형 ABO
                    //AcPtntInfo.Rh = dr[""].ToString();
                    //AcPtntInfo.VipYn = dr[""].ToString();
                    //AcPtntInfo.VipMemo = dr[""].ToString();
                    //AcPtntInfo.OldPtntId = dr[""].ToString();
                    //AcPtntInfo.AppUseYn = dr[""].ToString();
                    //AcPtntInfo.AlrgMemo = dr[""].ToString();
                    AcPtntInfo.Memo = dr["메모1"].ToString()  + "\n" + dr["메모2"].ToString();
                    //AcPtntInfo.InsId = dr[""].ToString();
                    AcPtntInfo.InsDt = dr["최초접수일"].ToString();
                    //AcPtntInfo.PhotoYn = dr[""].ToString();
                    AcPtntInfo.FilePath = dr["사진경로"].ToString();
                    //AcPtntInfo.ServerFileNm = dr[""].ToString();
                    //AcPtntInfo.AppUseDt = dr[""].ToString();





                    lstAcPtntInfo.Add(AcPtntInfo);
                    
                }
                return lstAcPtntInfo;

            }
        }

        public List<string> ConvertTaretItems()
        {
            List<string> targets = new List<string>();

            targets.Add("환자정보");


            return targets;
        }


        #endregion


    }
}
