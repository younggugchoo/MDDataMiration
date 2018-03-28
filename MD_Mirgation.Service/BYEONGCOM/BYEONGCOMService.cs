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

        public void Dispose()
        {
     
        }

        private void MdParkService_WorkingInfo(string message)
        {
            WorkingInfo?.Invoke(message);
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

            try
            {
                Logger.Logger.INFO("BYEONGCOMService StartConvert");
                WorkingInfo?.Invoke("BYEONGCOMService StartConvert");

                //환자정보 변환
                ConvertPntnInfo();



                WorkingInfo?.Invoke("BYEONGCOMService EndConvert");
            }
            catch (Exception ex)
            {                    
                Logger.Logger.ERROR(ex.Message);
                Logger.Logger.ERROR(ex.Source.ToString());
                throw ex;
            }
           
        }

        /// <summary>
        /// 환자정보 변환
        /// </summary>
        private void ConvertPntnInfo()
        {
            try
            {
                WorkingInfo?.Invoke("환자정보 변환시작");
                List<AcPntnInfo> acPntnInfos = SelectPatientBaseInfo();

                WorkingInfo?.Invoke(string.Format("변환대상 수:{0}", acPntnInfos.Count));

                mdParkService.InsertPntnInfo(acPntnInfos);
                WorkingInfo?.Invoke("환자정보 변환종료");
            }
            catch (Exception ex)
            {
                Logger.Logger.DEBUG(ex.Message, ex);
            }

        }

        

        #region //데이터 조회

        /// <summary>
        /// 환자 기본정보 조회
        /// </summary>
        /// <returns></returns>
        private List<AcPntnInfo> SelectPatientBaseInfo()
        {
            using (Data.DatabaseFactory factory = new Data.DatabaseFactory())
            {

                List<AcPntnInfo> lstAcPntnInfo = new List<AcPntnInfo>();

                factory.DatabaseFactoryAccess("환자정보");
                string strSql = @"SELECT
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

                AcPntnInfo acPntnInfo = null;
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    acPntnInfo = new AcPntnInfo();
                    acPntnInfo.HosCd = baseInfo.HosCd;
                    acPntnInfo.PtntNm = dr["수진자명"].ToString();

                    lstAcPntnInfo.Add(acPntnInfo);
                    
                }
                return lstAcPntnInfo;

            }
        }


        #endregion


    }
}
