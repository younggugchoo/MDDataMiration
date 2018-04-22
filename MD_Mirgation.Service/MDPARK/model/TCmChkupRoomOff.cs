namespace MD_DataMigration.Service.MDPARK.model
{
	public class TCmChkupRoomOff
	 {
		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 검사실코드
		/// </summary>
		public string ChkupRoomCd {get; set;}

		/// <summary>
		/// 휴진일
		/// </summary>
		public string OffYmd {get; set;}

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
