namespace MD_DataMigration.Service.MDPARK.model
{
    /// <summary>
    /// 자보보험이력
    /// </summary>
	public class TAcCarInsuHist
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
		/// 사고일자
		/// </summary>
		public string AcciYmd {get; set;}

		/// <summary>
		/// 적용시작일
		/// </summary>
		public string FrYmd {get; set;}

		/// <summary>
		/// 적용종료일
		/// </summary>
		public string ToYmd {get; set;}

		/// <summary>
		/// 보험회사
		/// </summary>
		public string InsuCd {get; set;}

		/// <summary>
		/// 사고번호
		/// </summary>
		public string AcciNo {get; set;}

		/// <summary>
		/// 사고장소
		/// </summary>
		public string AcciPalce {get; set;}

		/// <summary>
		/// 가해차량번호
		/// </summary>
		public string InjCarNo {get; set;}

		/// <summary>
		/// 지급보증서파일유무
		/// </summary>
		public string PayFileFg {get; set;}

		/// <summary>
		/// 비고
		/// </summary>
		public string Rmk {get; set;}

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
