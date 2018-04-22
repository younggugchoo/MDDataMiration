namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdSympt
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
		/// 증상일련번호
		/// </summary>
		public int SymptSeq {get; set;}

		/// <summary>
		/// 환자ID
		/// </summary>
		public string PtntId {get; set;}

		/// <summary>
		/// 증상
		/// </summary>
		public string Sympt {get; set;}

		/// <summary>
		/// 증상_HTML
		/// </summary>
		public string SymptHtml {get; set;}

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
