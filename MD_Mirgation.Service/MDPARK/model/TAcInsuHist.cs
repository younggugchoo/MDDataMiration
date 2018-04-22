namespace MD_DataMigration.Service.MDPARK.model
{

    /// <summary>
    /// 보험이력
    /// </summary>
	public class TAcInsuHist
	 {
		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 환자ID
		/// </summary>
		public string PtntId {get; set;}

		/// <summary>
		/// 보험구분
		/// </summary>
		public string InsuGb {get; set;}

		/// <summary>
		/// 적용시작일
		/// </summary>
		public string FrYmd {get; set;}

		/// <summary>
		/// 적용종료일
		/// </summary>
		public string ToYmd {get; set;}

		/// <summary>
		/// 조합기호
		/// </summary>
		public string InsuCd {get; set;}

		/// <summary>
		/// 증번호
		/// </summary>
		public string InsuNo {get; set;}

		/// <summary>
		/// 자격취득일자
		/// </summary>
		public string LicAcqYmd {get; set;}

		/// <summary>
		/// 피보험자성명
		/// </summary>
		public string InsuNm {get; set;}

		/// <summary>
		/// 피보험자주민번호1
		/// </summary>
		public string InsuResRegNo1 {get; set;}

		/// <summary>
		/// 피보험자주민번호2
		/// </summary>
		public string InsuResRegNo2 {get; set;}

		/// <summary>
		/// 관계
		/// </summary>
		public string RelGb {get; set;}

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
