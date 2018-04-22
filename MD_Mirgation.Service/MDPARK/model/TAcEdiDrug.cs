namespace MD_DataMigration.Service.MDPARK.model
{
	public class TAcEdiDrug
	 {
		/// <summary>
		/// 기준수가코드
		/// </summary>
		public string EdiCd {get; set;}

		/// <summary>
		/// 적용시작일
		/// </summary>
		public string FrYmd {get; set;}

		/// <summary>
		/// 분류번호
		/// </summary>
		public string DivNoCd {get; set;}

		/// <summary>
		/// 급여기준
		/// </summary>
		public string SalGb {get; set;}

		/// <summary>
		/// 상한가
		/// </summary>
		public int MaxAmt {get; set;}

		/// <summary>
		/// 가산금
		/// </summary>
		public int AddAmt {get; set;}

		/// <summary>
		/// 투여경로
		/// </summary>
		public string MedPath {get; set;}

		/// <summary>
		/// 품명
		/// </summary>
		public string KorNm {get; set;}

		/// <summary>
		/// 규격
		/// </summary>
		public string Stndrd {get; set;}

		/// <summary>
		/// 단위
		/// </summary>
		public string Unit {get; set;}

		/// <summary>
		/// 업소명
		/// </summary>
		public string PhmCo {get; set;}

		/// <summary>
		/// 주성분코드
		/// </summary>
		public string MainIngreCd {get; set;}

		/// <summary>
		/// 전문일반
		/// </summary>
		public string SpcGen {get; set;}

		/// <summary>
		/// 퇴장방지
		/// </summary>
		public string ExitChkGb {get; set;}

		/// <summary>
		/// 의약품동등성
		/// </summary>
		public string DrugEqlGb {get; set;}

		/// <summary>
		/// 저가대체가산여부
		/// </summary>
		public string LowPriceReplcAddYn {get; set;}

		/// <summary>
		/// 예외의약품구분
		/// </summary>
		public string EcptDrugGb {get; set;}

		/// <summary>
		/// 임의조제불가항목
		/// </summary>
		public string NoPprmdcItem {get; set;}

		/// <summary>
		/// 고시일자
		/// </summary>
		public string NotiYmd {get; set;}

		/// <summary>
		/// 대응코드
		/// </summary>
		public string CntrmsrCd {get; set;}

		/// <summary>
		/// 희귀의약품구분
		/// </summary>
		public string RareDrugGb {get; set;}

		/// <summary>
		/// 판매예정일
		/// </summary>
		public string SalePreaYmd {get; set;}

		/// <summary>
		/// 동일의약품
		/// </summary>
		public string SameDrugCd {get; set;}

		/// <summary>
		/// 청구규격
		/// </summary>
		public string ReqStndrd {get; set;}

		/// <summary>
		/// 비고
		/// </summary>
		public string Rmk {get; set;}

		/// <summary>
		/// 입력자ID
		/// </summary>
		public string InsId {get; set;}

		/// <summary>
		/// 입력일시
		/// </summary>
		public string InsDt {get; set;}

	 }
}
