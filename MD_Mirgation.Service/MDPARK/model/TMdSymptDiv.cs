namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdSymptDiv
	 {
		/// <summary>
		/// 증상분류코드
		/// </summary>
		public string SymptDivCd {get; set;}

		/// <summary>
		/// 사용자ID
		/// </summary>
		public string UserId {get; set;}

		/// <summary>
		/// 증상분류명
		/// </summary>
		public string SymptDivNm {get; set;}

		/// <summary>
		/// 상위증상분류코드
		/// </summary>
		public string OwnerSymptDivCd {get; set;}

		/// <summary>
		/// 분류DEPTH
		/// </summary>
		public int DivDepth {get; set;}

		/// <summary>
		/// 정렬순서
		/// </summary>
		public int SortOrd {get; set;}

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
