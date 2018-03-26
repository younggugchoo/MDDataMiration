using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_DataMigration.Service.MDPARK.model
{
    /// <summary>
    /// 환자기본정보
    /// </summary>
    public class AcPntnInfo
    {
        //환자ID
        public string PtntId { get; set; }

        //병원코드
        public string HosCd { get; set; }

        //환자명
        public string PtntNm { get; set; }

        //영문명
        public string EngNm { get; set; }

        //주민등록번호1
        public string ResRegNo1 { get; set; }

        //주민등록번호2
        public string ResRegNo2 { get; set; }

        //생년월일
        public string BirthYmd { get; set; }

        //성별
        public string Sex { get; set; }

        //우편번호
        public string ZipNo { get; set; }

        //주소
        public string Addr { get; set; }

        //주소상세
        public string Addr2 { get; set; }

        //휴대전화번호
        public string MobNo { get; set; }

        //전화번호1
        public string TelNo1 { get; set; }

        //전화번호1명칭
        public string TelNm1 { get; set; }

        //전화번호2
        public string TelNo2 { get; set; }

        //전화번호2명칭
        public string TelNm2 { get; set; }

        //전화번호3
        public string TelNo3 { get; set; }

        //전화번호3명칭
        public string TelNm3 { get; set; }

        //외국인여부
        public string FrgnrYn { get; set; }

        //개인정보동의여부
        public string IndvdlinfoAgreYn { get; set; }

        //만성질환관리여부
        public string ChdsesMngYn { get; set; }

        //임산부여부
        public string PrgncYn { get; set; }

        //SMS수신여부
        public string SmsRcveYn { get; set; }

        //EMail
        public string Email { get; set; }

        //혈액형_ABO
        public string AboTy { get; set; }

        //혈액형_RH
        public string Rh { get; set; }

        //VIP여부
        public string VipYn { get; set; }

        //VIP메모
        public string VipMemo { get; set; }

        //구환자ID
        public string OldPtntId { get; set; }

        //앱설치여부
        public string AppUseYn { get; set; }

        //알레르기메모
        public string AlrgMemo { get; set; }

        //메모
        public string Memo { get; set; }

        //등록자ID
        public string InsId { get; set; }

        //등록일시
        public string InsDt { get; set; }

        //수정자ID
        public string UpdId { get; set; }

        //수정일시
        public string UpdDt { get; set; }

        //개인사진여부
        public string PhotoYn { get; set; }

        //파일경로
        public string FilePath { get; set; }

        //서버파일명
        public string ServerFileNm { get; set; }

        //앱설치일시
        public string AppUseDt { get; set; }

    }
}
