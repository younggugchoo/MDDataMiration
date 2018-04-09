using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_DataMigration.Service.MDPARK.model
{
    /// <summary>
    /// 환자기본정보
    /// </summary>
    public class AcPtntInfo
    {
        /// <summary>
        /// 환자ID
        /// </summary>
        public string PtntId { get; set; }

        /// <summary>
        /// 병원코드
        /// </summary>
        public string HosCd { get; set; }

        /// <summary>
        /// 환자명
        /// </summary>
        public string PtntNm { get; set; }

        /// <summary>
        /// 영문명
        /// </summary>
        public string EngNm { get; set; }

        /// <summary>
        /// 주민등록번호1
        /// </summary>
        public string ResRegNo1 { get; set; }

        /// <summary>
        /// 주민등록번호2
        /// </summary>
        public string ResRegNo2 { get; set; }

        /// <summary>
        /// 생년월일
        /// </summary>
        public string BirthYmd { get; set; }

        /// <summary>
        /// 성별
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 우편번호
        /// </summary>
        public string ZipNo { get; set; }

        /// <summary>
        /// 주소
        /// </summary>
        public string Addr { get; set; }

        /// <summary>
        /// 주소상세
        /// </summary>
        public string Addr2 { get; set; }

        /// <summary>
        /// 휴대전화번호
        /// </summary>
        public string MobNo { get; set; }

        /// <summary>
        /// 전화번호1
        /// </summary>
        public string TelNo1 { get; set; }

        /// <summary>
        /// 전화번호1명칭
        /// </summary>
        public string TelNm1 { get; set; }

        /// <summary>
        /// 전화번호2
        /// </summary>
        public string TelNo2 { get; set; }

        /// <summary>
        /// 전화번호2명칭
        /// </summary>
        public string TelNm2 { get; set; }

        /// <summary>
        /// 전화번호3
        /// </summary>
        public string TelNo3 { get; set; }

        /// <summary>
        /// 전화번호3명칭
        /// </summary>
        public string TelNm3 { get; set; }

        /// <summary>
        /// 외국인여부
        /// </summary>
        public string FrgnrYn { get; set; }

        /// <summary>
        /// 개인정보동의여부
        /// </summary>
        public string IndvdlinfoAgreYn { get; set; }

        /// <summary>
        /// 만성질환관리여부
        /// </summary>
        public string ChdsesMngYn { get; set; }

        /// <summary>
        /// 임산부여부
        /// </summary>
        public string PrgncYn { get; set; }

        /// <summary>
        /// SMS수신여부
        /// </summary>
        public string SmsRcveYn { get; set; }

        /// <summary>
        /// EMail
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 혈액형_ABO
        /// </summary>
        public string AboTy { get; set; }

        /// <summary>
        /// 혈액형_RH
        /// </summary>
        public string Rh { get; set; }

        /// <summary>
        /// VIP여부
        /// </summary>
        public string VipYn { get; set; }

        /// <summary>
        /// VIP메모
        /// </summary>
        public string VipMemo { get; set; }

        /// <summary>
        /// 구환자ID
        /// </summary>
        public string OldPtntId { get; set; }

        /// <summary>
        /// 앱설치여부
        /// </summary>
        public string AppUseYn { get; set; }

        /// <summary>
        /// 알레르기메모
        /// </summary>
        public string AlrgMemo { get; set; }

        /// <summary>
        /// 메모
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 등록자ID
        /// </summary>
        public string InsId { get; set; }

        /// <summary>
        /// 등록일시
        /// </summary>
        public string InsDt { get; set; }

        /// <summary>
        /// 수정자ID
        /// </summary>
        public string UpdId { get; set; }

        /// <summary>
        /// 수정일시
        /// </summary>
        public string UpdDt { get; set; }

        /// <summary>
        /// 개인사진여부
        /// </summary>
        public string PhotoYn { get; set; }

        /// <summary>
        /// 파일경로
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 서버파일명
        /// </summary>
        public string ServerFileNm { get; set; }

        /// <summary>
        /// 앱설치일시   
        /// </summary>
        public string AppUseDt { get; set; }

        

        
    }
}
