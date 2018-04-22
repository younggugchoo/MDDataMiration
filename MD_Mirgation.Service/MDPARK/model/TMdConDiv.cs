namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdConDiv
	 {
		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 분류코드
		/// </summary>
		public string ConDivCd {get; set;}

		/// <summary>
		/// 분류명
		/// </summary>
		public string ConDivNm {get; set;}

		/// <summary>
		/// 상위분류코드
		/// </summary>
		public string OwnerConDivCd {get; set;}

		/// <summary>
		/// 분류DEPTH
		/// </summary>
		public int DivDepth {get; set;}

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
