namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdDiag
	 {
		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 접수번호
		/// </summary>
		public int RcveNo {get; set;}

		/// <summary>
		/// 상병코드
		/// </summary>
		public string DiagCd {get; set;}

		/// <summary>
		/// 환자ID
		/// </summary>
		public string PtntId {get; set;}

		/// <summary>
		/// 적용시작일
		/// </summary>
		public string FrYmd {get; set;}

		/// <summary>
		/// 진료일
		/// </summary>
		public string MedYmd {get; set;}

		/// <summary>
		/// 진료과코드
		/// </summary>
		public string MedDeptCd {get; set;}

		/// <summary>
		/// 진료의
		/// </summary>
		public string MedDrId {get; set;}

		/// <summary>
		/// 주상병여부
		/// </summary>
		public string MainDiagYn {get; set;}

		/// <summary>
		/// 의증여부
		/// </summary>
		public string RuleOutYn {get; set;}

		/// <summary>
		/// 치열_상좌
		/// </summary>
		public string TeeUpLt {get; set;}

		/// <summary>
		/// 치열_상우
		/// </summary>
		public string TeeUpRt {get; set;}

		/// <summary>
		/// 치열_하좌
		/// </summary>
		public string TeeDwLt {get; set;}

		/// <summary>
		/// 치령_하우
		/// </summary>
		public string TeeDwRt {get; set;}

		/// <summary>
		/// 법정감염병구분
		/// </summary>
		public string LegalIcdGb {get; set;}

		/// <summary>
		/// 감염병신고여부
		/// </summary>
		public string IcdRptYn {get; set;}

		/// <summary>
		/// 삭제여부
		/// </summary>
		public string DelYn {get; set;}

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
