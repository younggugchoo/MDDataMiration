namespace MD_DataMigration.Service.MDPARK.model
{
	public class TAcEdiMat
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
		/// 급여구분
		/// </summary>
		public string SalGb {get; set;}

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
		/// 상한금액
		/// </summary>
		public int MaxAmt {get; set;}

		/// <summary>
		/// 제조회사
		/// </summary>
		public string MnfCo {get; set;}

		/// <summary>
		/// 재질
		/// </summary>
		public string Mat {get; set;}

		/// <summary>
		/// 수입업소
		/// </summary>
		public string IncmCo {get; set;}

		/// <summary>
		/// 비고_1
		/// </summary>
		public string Rmk1 {get; set;}

		/// <summary>
		/// 비고_2
		/// </summary>
		public string Rmk2 {get; set;}

		/// <summary>
		/// 등록자ID
		/// </summary>
		public string InsId {get; set;}

		/// <summary>
		/// 등록일시
		/// </summary>
		public string InsDt {get; set;}

	 }
}
