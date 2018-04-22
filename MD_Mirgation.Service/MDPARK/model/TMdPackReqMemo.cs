namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdPackReqMemo
	 {
		/// <summary>
		/// 용도
		/// </summary>
		public string UseTy {get; set;}

		/// <summary>
		/// 대분류ID
		/// </summary>
		public string LdivId {get; set;}

		/// <summary>
		/// 중분류ID
		/// </summary>
		public string MdivId {get; set;}

		/// <summary>
		/// 사용자ID
		/// </summary>
		public string UserId {get; set;}

		/// <summary>
		/// 청구메모
		/// </summary>
		public string ReqMemo {get; set;}

		/// <summary>
		/// 등록일시
		/// </summary>
		public string InsDt {get; set;}

		/// <summary>
		/// 수정일시
		/// </summary>
		public string UpdDt {get; set;}

	 }
}
