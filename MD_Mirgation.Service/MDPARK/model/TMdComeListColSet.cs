namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdComeListColSet
	 {
		/// <summary>
		/// 사용자ID
		/// </summary>
		public string UserId {get; set;}

		/// <summary>
		/// 칼럼ID
		/// </summary>
		public string ColId {get; set;}

		/// <summary>
		/// 칼럼명
		/// </summary>
		public string ColNm {get; set;}

		/// <summary>
		/// 사용여부
		/// </summary>
		public string UseYn {get; set;}

		/// <summary>
		/// 정렬순서
		/// </summary>
		public int SortOrd {get; set;}

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
