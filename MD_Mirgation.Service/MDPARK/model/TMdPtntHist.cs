namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdPtntHist
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
		/// 과거력순번
		/// </summary>
		public int HistSeq {get; set;}

		/// <summary>
		/// 과거력내용
		/// </summary>
		public string PastCont {get; set;}

		/// <summary>
		/// 과거력내용_HTML
		/// </summary>
		public string PastContHtml {get; set;}

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
