namespace MD_DataMigration.Service.MDPARK.model
{
	public class TCmHosWeekOff
	 {
		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 주차
		/// </summary>
		public int WeekNo {get; set;}

		/// <summary>
		/// 요일코드 grp_cd:W001
		/// </summary>
		public string WeekCd {get; set;}

	 }
}
