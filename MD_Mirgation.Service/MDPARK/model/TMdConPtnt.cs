namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdConPtnt
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
		/// 의사_ID
		/// </summary>
		public string UserId {get; set;}

		/// <summary>
		/// 환자ID
		/// </summary>
		public string PtntId {get; set;}

		/// <summary>
		/// 관심환자등록일시
		/// </summary>
		public string ConSdt {get; set;}

		/// <summary>
		/// 관심환자종료일시
		/// </summary>
		public string ConEdt {get; set;}

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
