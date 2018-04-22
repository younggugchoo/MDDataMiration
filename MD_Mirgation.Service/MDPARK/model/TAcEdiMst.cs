namespace MD_DataMigration.Service.MDPARK.model
{
	public class TAcEdiMst
	 {
		/// <summary>
		/// 기준수가코드
		/// </summary>
		public string EdiCd {get; set;}

		/// <summary>
		/// 적용시작일
		/// </summary>
		public string FrYmd {get; set;}

		/// <summary>
		/// EDI구분 1:수가 2:약가 3:치료재료대
		/// </summary>
		public string EdiGb {get; set;}

		/// <summary>
		/// EDI적용종료일
		/// </summary>
		public string ToYmd {get; set;}

	 }
}
