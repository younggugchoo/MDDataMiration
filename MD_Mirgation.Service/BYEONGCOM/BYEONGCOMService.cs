using MD_DataMigration.Service.MDPARK;
using MD_DataMigration.Service.MDPARK.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MD_DataMigration.Service.BYEONGCOM
{
    public class BYEONGCOMService: IConvert, IDisposable
    {

        private const string TARGET_DB = "MariaDbMDPark";
        private string hosCd;
        public void Dispose()
        {
     
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
        public void StartConvert(string hosCd)
        {
            this.hosCd = hosCd;
            
            try
            {
                Logger.Logger.INFO("BYEONGCOMService StartConvert");

                using (MDPARKService mdParkService = new MDPARKService(TARGET_DB))
                {
                    mdParkService.InsertPntnInfo(SelectPatientBaseInfo());
                }

                


            }
            catch (Exception ex)
            {                    
                Logger.Logger.ERROR(ex.Message);
                Logger.Logger.ERROR(ex.Source.ToString());
                throw ex;
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
                string strSql = @"select top 10
                    챠트번호
                    , 수진자명
                    , 주민등록 
                    from 환자정보";
                DataSet ds = factory.ExcuteDatSet(strSql, CommandType.Text, null);

                AcPntnInfo acPntnInfo = null;
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    acPntnInfo = new AcPntnInfo();
                    acPntnInfo.HosCd = hosCd;
                    acPntnInfo.PtntNm = dr["수진자명"].ToString();

                    lstAcPntnInfo.Add(acPntnInfo);

                   

                }
                return lstAcPntnInfo;

            }
        }


        #endregion


    }
}
