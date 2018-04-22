namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMnFamHist
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
		/// 가족환자ID
		/// </summary>
		public string FamPtntId {get; set;}

		/// <summary>
		/// 관계
		/// </summary>
		public string Rel {get; set;}

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
		public string UdpDt {get; set;}

		/// <summary>
		/// 비고
		/// </summary>
		public string Rmk {get; set;}

	 }
}
