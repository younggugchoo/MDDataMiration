namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMhChkupKind
	 {
		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 검진종류코드
		/// </summary>
		public string ChkupKindCd {get; set;}

		/// <summary>
		/// 검사실1
		/// </summary>
		public string Room1 {get; set;}

		/// <summary>
		/// 검사실2
		/// </summary>
		public string Room2 {get; set;}

		/// <summary>
		/// 검사실3
		/// </summary>
		public string Room3 {get; set;}

		/// <summary>
		/// 검사실4
		/// </summary>
		public string Room4 {get; set;}

		/// <summary>
		/// 검사실5
		/// </summary>
		public string Room5 {get; set;}

		/// <summary>
		/// 표시여부
		/// </summary>
		public string DispYn {get; set;}

		/// <summary>
		/// 검진여부 A:건강검진공통 B:암검진
		/// </summary>
		public string ChkupGb {get; set;}

		/// <summary>
		/// 내시경여부
		/// </summary>
		public string EdscopeYn {get; set;}

	 }
}
