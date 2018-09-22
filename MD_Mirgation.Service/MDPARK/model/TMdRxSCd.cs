namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdRxSCd
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int RxSId {get; set;}

		/// <summary>
		/// 방사선 중 카테고리 id
		/// </summary>
		public int RxMId {get; set;}

		/// <summary>
		/// 용법명
		/// </summary>
		public string RxSNm {get; set;}

		/// <summary>
		/// 순서
		/// </summary>
		public int SSeq {get; set;}

		/// <summary>
		/// 현 Row의 사용 여부(Y/N)사용중이면 Y,  삭제되어 사용하지 않는다면 N으로 표기함.
		/// </summary>
		public string UseYn {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string InsId {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string InsDt {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string InsIp {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string UpdId {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string UpdDt {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string UpdIp {get; set;}

	 }
}
