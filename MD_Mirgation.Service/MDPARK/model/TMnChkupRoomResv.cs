namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMnChkupRoomResv
	 {
		/// <summary>
		/// 예약번호
		/// </summary>
		public string ResvNo {get; set;}

		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 검진종류코드
		/// </summary>
		public string ChkupKindCd {get; set;}

		/// <summary>
		/// 검사실코드
		/// </summary>
		public string ChkupRoomCd {get; set;}

		/// <summary>
		/// 시작시분
		/// </summary>
		public string Shhmm {get; set;}

		/// <summary>
		/// 표시구분
		/// </summary>
		public string DispGb {get; set;}

		/// <summary>
		/// 표시값
		/// </summary>
		public string DispVal {get; set;}

	 }
}
