namespace MD_DataMigration.Service.MDPARK.model
{
	public class TCmUserOff
	 {
		/// <summary>
		/// 사용자ID
		/// </summary>
		public string UserId {get; set;}

		/// <summary>
		/// 휴일YMD
		/// </summary>
		public string OffYmd {get; set;}

		/// <summary>
		/// 휴일날수
		/// </summary>
		public string OffCnt {get; set;}

		/// <summary>
		/// 휴일구분 1:정기휴가 2:연가 3:병가 4:특별휴가
		/// </summary>
		public string OffGb {get; set;}

		/// <summary>
		/// 휴일상세내용
		/// </summary>
		public string OffDesc {get; set;}

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
