namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdOrdMst
	 {
		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 처방코드
		/// </summary>
		public string OrdCd {get; set;}

		/// <summary>
		/// 청구코드
		/// </summary>
		public string EdiCd {get; set;}

		/// <summary>
		/// 분류번호코드 grp_cd:DIVD
		/// </summary>
		public string DivNoCd {get; set;}

		/// <summary>
		/// 처방명_한글
		/// </summary>
		public string KorNm {get; set;}

		/// <summary>
		/// 처방명_영문
		/// </summary>
		public string EngNm {get; set;}

		/// <summary>
		/// 적용시작일
		/// </summary>
		public string FrYmd {get; set;}

		/// <summary>
		/// 적용종료일
		/// </summary>
		public string ToYmd {get; set;}

		/// <summary>
		/// 사용분류코드
		/// </summary>
		public string UseDivCd {get; set;}

		/// <summary>
		/// 행위가산코드
		/// </summary>
		public string ActAddCd {get; set;}

		/// <summary>
		/// 코드구분
		/// </summary>
		public string CdGb {get; set;}

		/// <summary>
		/// 약구분코드 grp_cd:REF0
		/// </summary>
		public string DrugGbCd {get; set;}

		/// <summary>
		/// 병원 사용여부
		/// </summary>
		public string HosUseYn {get; set;}

		/// <summary>
		/// 원내처방사유코드
		/// </summary>
		public string InOrdRsnCd {get; set;}

		/// <summary>
		/// 원외전체적용여부
		/// </summary>
		public string OutAllAppYn {get; set;}

		/// <summary>
		/// 마약분류코드
		/// </summary>
		public string SpecDrugDivCd {get; set;}

		/// <summary>
		/// 기본용량
		/// </summary>
		public int StdQty {get; set;}

		/// <summary>
		/// 단위
		/// </summary>
		public string Unit {get; set;}

		/// <summary>
		/// 용법코드 grp_cd:DUSE
		/// </summary>
		public string UsageCd {get; set;}

		/// <summary>
		/// 설정용량
		/// </summary>
		public int SetQty {get; set;}

		/// <summary>
		/// 설정일수
		/// </summary>
		public int SetDayCnt {get; set;}

		/// <summary>
		/// 제한일수
		/// </summary>
		public int LmtDayCnt {get; set;}

		/// <summary>
		/// 제한용량
		/// </summary>
		public int LmtQty {get; set;}

		/// <summary>
		/// 용량투여
		/// </summary>
		public int QtyMed {get; set;}

		/// <summary>
		/// 투여횟수
		/// </summary>
		public int MedCnt {get; set;}

		/// <summary>
		/// 재료행위구분 1:재료 2:행위
		/// </summary>
		public string MatActGb {get; set;}

		/// <summary>
		/// 의원금액
		/// </summary>
		public int UnitPrice1 {get; set;}

		/// <summary>
		/// 일반가
		/// </summary>
		public int GnlPrice {get; set;}

		/// <summary>
		/// 상한가
		/// </summary>
		public int MaxPrice {get; set;}

		/// <summary>
		/// 점수
		/// </summary>
		public int Score {get; set;}

		/// <summary>
		/// 처방종류 공통코드 grp_cd:ORDK
		/// </summary>
		public string OrdKind {get; set;}

		/// <summary>
		/// 항분류코드
		/// </summary>
		public string LargCd {get; set;}

		/// <summary>
		/// 목분류코드
		/// </summary>
		public string MiddCd {get; set;}

		/// <summary>
		/// 검사등록
		/// </summary>
		public string TestReg {get; set;}

		/// <summary>
		/// 검사순번
		/// </summary>
		public string TestSeq {get; set;}

		/// <summary>
		/// 신규등록
		/// </summary>
		public string NewReg {get; set;}

		/// <summary>
		/// 비고
		/// </summary>
		public string Rmk {get; set;}

		/// <summary>
		/// 예외수탁기관기호
		/// </summary>
		public string EcptOrgSymbl {get; set;}

		/// <summary>
		/// 위탁기관구분
		/// </summary>
		public string MtOrgGb {get; set;}

		/// <summary>
		/// 외부코드
		/// </summary>
		public string OutCd {get; set;}

		/// <summary>
		/// 주성분코드
		/// </summary>
		public string MainIngreCd {get; set;}

		/// <summary>
		/// 성분명칭
		/// </summary>
		public string IngreNm {get; set;}

		/// <summary>
		/// 급여구분코드
		/// </summary>
		public string SalGbCd {get; set;}

		/// <summary>
		/// 제약사
		/// </summary>
		public string DrugComp {get; set;}

		/// <summary>
		/// 구청구코드
		/// </summary>
		public string OldReqCd {get; set;}

		/// <summary>
		/// 포장단위책정
		/// </summary>
		public string PackUnitaprp {get; set;}

		/// <summary>
		/// 코팅약품
		/// </summary>
		public string CotDrug {get; set;}

		/// <summary>
		/// 내용액제
		/// </summary>
		public string Liquid {get; set;}

		/// <summary>
		/// 본부비율
		/// </summary>
		public string HeadOfcRt {get; set;}

		/// <summary>
		/// 급여구분무시
		/// </summary>
		public string SalGbIgnore {get; set;}

		/// <summary>
		/// 청구규격
		/// </summary>
		public string ReqStndrd {get; set;}

		/// <summary>
		/// 그룹싱글구분 G:그룹 S:싱글
		/// </summary>
		public string GrpSnglGb {get; set;}

		/// <summary>
		/// 등록자ID
		/// </summary>
		public string InsId {get; set;}

		/// <summary>
		/// 등록일시
		/// </summary>
		public string InsDt {get; set;}

		/// <summary>
		/// 수정자ID
		/// </summary>
		public string UpdId {get; set;}

		/// <summary>
		/// 수정일시
		/// </summary>
		public string UpdDt {get; set;}

	 }
}
