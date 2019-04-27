using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_DataMigration.Service.MDPARK.model
{
    public class TCmBsHosSet
    {

        /// <summary>
        /// Primary Key(Auto Increment)
        /// </summary>
        [ColunmException(true)]
        public int HosSetId { get; set; }

        /// <summary>
        /// 1: 수가, 3:약가, 8:재료가
        /// </summary>
        public string MGb { get; set; }

        /// <summary>
        /// 병원코드
        /// </summary>
        public string HosCd { get; set; }

        /// <summary>
        /// 심평원 수가코드 : null이 될 수 있는 것은 사용자가 임의로 작성한 코드가 있을 수 있기에.
        /// </summary>
        public string McCd { get; set; }

        /// <summary>
        /// 장코드(JANG_CD)
        /// </summary>
        public string JangCd { get; set; }

        /// <summary>
        /// 항번호(HANG_NO)
        /// </summary>
        public string HangNo { get; set; }

        /// <summary>
        /// 목번호(MO_NO)
        /// </summary>
        public string MoNo { get; set; }

        /// <summary>
        /// 사용자 코드
        /// </summary>
        public string PmcCd { get; set; }

        /// <summary>
        /// 사용자 명칭
        /// </summary>
        public string Pkor { get; set; }

        /// <summary>
        /// 급여구분 ( SAL_NO_GB ) 급여, 비급여
        /// </summary>
        public string SalNoGb { get; set; }

        /// <summary>
        /// 한글명(공통)
        /// </summary>
        public string Kor { get; set; }

        /// <summary>
        /// 본인부담율 구분(공통) ( OVHD_RATE_GB )
        /// </summary>
        public string OvhdRateGb { get; set; }

        /// <summary>
        /// 규격
        /// </summary>
        public string DSpec { get; set; }

        /// <summary>
        /// 단위
        /// </summary>
        public string DUnit { get; set; }

        /// <summary>
        /// 업소명
        /// </summary>
        public string DCompNm { get; set; }

        /// <summary>
        /// 분류번호
        /// </summary>
        public string DstbNo { get; set; }

        /// <summary>
        /// 성분코드
        /// </summary>
        public string DMainIgdt { get; set; }

        /// <summary>
        /// 마약/향정 여부(약)  psychotropic substance ( D_PS_GB )
        /// </summary>
        public string DPsGb { get; set; }

        /// <summary>
        /// 약구분(약) ( MDC_SAL_GB )  보험등재약..
        /// </summary>
        public string MdcSalGb { get; set; }

        /// <summary>
        /// 원내원외구분( IN_OUT_GB )
        /// </summary>
        public string InOutGb { get; set; }

        /// <summary>
        /// 원내약품 예외코드 ( DRG_EXC_CD )
        /// </summary>
        public string DrgExcCd { get; set; }

        /// <summary>
        /// 전문/일반(약가)
        /// </summary>
        public string DSpecialGb { get; set; }

        /// <summary>
        /// 용법 사용분류(약) : PSB_GB의 내복, 외용, 주사만 가져와야 함.
        /// </summary>
        public string DPath { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string InjectionGb { get; set; }

        /// <summary>
        /// 용량
        /// </summary>
        public string Dose { get; set; }

        /// <summary>
        /// 횟수
        /// </summary>
        public int DoseCnt { get; set; }

        /// <summary>
        /// 일수
        /// </summary>
        public int DoseDays { get; set; }

        /// <summary>
        /// 제한용량
        /// </summary>
        public string LimitDose { get; set; }

        /// <summary>
        /// 제한횟수
        /// </summary>
        public int LimitDoseCnt { get; set; }

        /// <summary>
        /// 제한일수
        /// </summary>
        public int LimitDoseDays { get; set; }

        /// <summary>
        /// 용량세부조건(약) ( CAPA_DTL_GB )
        /// </summary>
        public string CapaDtlGb { get; set; }

        /// <summary>
        /// 분류번호(수가)
        /// </summary>
        public string CDistCd { get; set; }

        /// <summary>
        /// 1_2 구분
        /// </summary>
        public string COt { get; set; }

        /// <summary>
        /// 수술여부
        /// </summary>
        public string CSgyYn { get; set; }

        /// <summary>
        /// 중복인정여부
        /// </summary>
        public string DupYn { get; set; }

        /// <summary>
        /// 영문명(수가)
        /// </summary>
        public string CEng { get; set; }

        /// <summary>
        /// 산정명칭
        /// </summary>
        public string CSpcCd { get; set; }

        /// <summary>
        /// 준용명칭 ( EQUIV_GB )
        /// </summary>
        public string EquivGb { get; set; }

        /// <summary>
        /// 행위가산 ( ACT_ADD_GB )
        /// </summary>
        public string ActAddGb { get; set; }

        /// <summary>
        /// 검사 구분 : 검사종류로서 검체, 병리등 검사 종류 구분 (TEST_GB)
        /// </summary>
        public string TestGb { get; set; }

        /// <summary>
        /// 처리구분(수가) : 검사를 원내 혹은 수탁에서 할 것인지 구분 DS_GB
        /// </summary>
        public string DsGb { get; set; }

        /// <summary>
        /// 수탁기관 id ( t_cm_cnmt_set table과 연관 )
        /// </summary>
        public int CnmtId { get; set; }

        /// <summary>
        /// 의료비소득공제제외 코드(수가)
        /// </summary>
        public string DedExcCd { get; set; }

        /// <summary>
        /// 규격(치료재료)
        /// </summary>
        public string MSpec { get; set; }

        /// <summary>
        /// 단위(치료재료)
        /// </summary>
        public string MUnit { get; set; }

        /// <summary>
        /// 재질(치료재료)
        /// </summary>
        public string MMaterial { get; set; }

        /// <summary>
        /// 제조회사(치료재료)
        /// </summary>
        public string MMaker { get; set; }

        /// <summary>
        /// 수입업소(치료재료)
        /// </summary>
        public string MImporter { get; set; }

        /// <summary>
        /// 심평원 신고여부(치료재료) ( REPORT_GB )
        /// </summary>
        public string ReportGb { get; set; }

        /// <summary>
        /// 주의메모
        /// </summary>
        public string CautMmo { get; set; }

        /// <summary>
        /// 청구메모 필수 여부 (USE_YN) mandatory
        /// </summary>
        public string LineMYn { get; set; }

        /// <summary>
        /// 줄단위 메모코드
        /// </summary>
        public string LineCd { get; set; }

        /// <summary>
        /// 줄단위 메모내용
        /// </summary>
        public string LineMmo { get; set; }

        /// <summary>
        /// 성별 ( SEX )
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 임산부제한(약가) PG_GB
        /// </summary>
        public string PgGb { get; set; }

        /// <summary>
        /// 나이제한 구분
        /// </summary>
        public string AgeLmtGb { get; set; }

        /// <summary>
        /// 남자나이미만
        /// </summary>
        public int ManUnder { get; set; }

        /// <summary>
        /// 남자나이이상
        /// </summary>
        public int ManOver { get; set; }

        /// <summary>
        /// 여자나이미만
        /// </summary>
        public int WmUnder { get; set; }

        /// <summary>
        /// 여자나이이상
        /// </summary>
        public int WmOver { get; set; }

        /// <summary>
        /// 용법예문코드id
        /// </summary>
        public int SmpTxtId { get; set; }

        /// <summary>
        /// 분할처방(약가) : POS_PSB_GB
        /// </summary>
        public string PohPsbGb { get; set; }

        /// <summary>
        /// 1회투여량(약가)
        /// </summary>
        public string Qd { get; set; }

        /// <summary>
        /// 일총투여량(약가)
        /// </summary>
        public int Sd { get; set; }

        /// <summary>
        /// 1회 처방일수(약가)
        /// </summary>
        public int Td { get; set; }

        /// <summary>
        /// 총 처방일수(약가) : PSB_LMT_DY_GB
        /// </summary>
        public string PsbLmtDyGb { get; set; }

        /// <summary>
        /// 처방제한일수(약가) : 일/년/월별로 00회로 제한된 처방
        /// </summary>
        public int PsbLmtDy { get; set; }

        /// <summary>
        /// 초진처방구분 ( FM_GB )
        /// </summary>
        public string FmGb { get; set; }

        /// <summary>
        /// 초진처방 주의사항
        /// </summary>
        public string FmGbRmk { get; set; }

        /// <summary>
        /// 처방횟수
        /// </summary>
        public string PsbCntGb { get; set; }

        /// <summary>
        /// 용법(약가) 예문 코드
        /// </summary>
        public string UsgEx { get; set; }

        /// <summary>
        /// 검색조회조건 : 사용자코드, 수가코드, 한글명칭, 영문명칭 등을 concat하여 조회용도임.
        /// </summary>
        public string SearchTxt { get; set; }

        /// <summary>
        /// 심평원 보험가격 : 약가, 수가일 경우 심평원 가격
        /// </summary>
        public string EdiPrice { get; set; }

        /// <summary>
        /// 일반가격(비보험가격)
        /// </summary>
        public string GeneralPrice { get; set; }

        /// <summary>
        /// 자보가격
        /// </summary>
        public string CarInsPrice { get; set; }

        /// <summary>
        /// 산재가격
        /// </summary>
        public string IaciPrice { get; set; }

        /// <summary>
        /// 상한가 : 약가 및 치료재료에 해당됨.
        /// </summary>
        public string HighLmtPrice { get; set; }

        /// <summary>
        /// 상대가치점수
        /// </summary>
        public string CStr { get; set; }

        /// <summary>
        /// 심평원 신고가(치료재료)
        /// </summary>
        public string EdiRptPrice { get; set; }

        /// <summary>
        /// 현재 유효하게 사용하는 것 구분함.(USE_YN)
        /// </summary>
        public string UseYn { get; set; }

        /// <summary>
        /// 해당 사용자코드별로 revision_id를 땀(1,2,3,4)
        /// </summary>
        public int RevId { get; set; }

        /// <summary>
        /// 유효시작 일자
        /// </summary>
        public string EffFrom { get; set; }

        /// <summary>
        /// 유효종료일자
        /// </summary>
        public string EffTo { get; set; }

        /// <summary>
        /// 리포트에서 조회할 구분 코드 ( RCPT_CD )
        /// </summary>
        public string RcptCd { get; set; }

        /// <summary>
        /// 본인부담율 50
        /// </summary>
        public string P50 { get; set; }

        /// <summary>
        /// 본인부담율 80
        /// </summary>
        public string P80 { get; set; }

        /// <summary>
        /// 본인부담율 90
        /// </summary>
        public string P90 { get; set; }

        /// <summary>
        /// 본인부담율 100
        /// </summary>
        public string P100 { get; set; }

        /// <summary>
        /// data 생성자 id
        /// </summary>
        public string InsId { get; set; }

        /// <summary>
        /// data 생성일시
        /// </summary>
        public string InsDt { get; set; }

        /// <summary>
        /// data 생성자 ip
        /// </summary>
        public string InsIp { get; set; }

        /// <summary>
        /// data 수정자 id
        /// </summary>
        public string UpdId { get; set; }

        /// <summary>
        /// data 수정일시
        /// </summary>
        public string UpdDt { get; set; }

        /// <summary>
        /// data 수정자 ip
        /// </summary>
        public string UpdIp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CateBunchId { get; set; }

    }
}
