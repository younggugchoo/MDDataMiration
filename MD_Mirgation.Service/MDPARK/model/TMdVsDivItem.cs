namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdVsDivItem
	 {
		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 활력증상분류코드 grp_cd:VS
		/// </summary>
		public string VsDivCd {get; set;}

		/// <summary>
		/// 활력증상일련번호
		/// </summary>
		public int VsSeq {get; set;}

		/// <summary>
		/// 활력증상항목
		/// </summary>
		public string VsItem {get; set;}

		/// <summary>
		/// 정렬순서
		/// </summary>
		public int SortOrd {get; set;}

		/// <summary>
		/// 사용여부
		/// </summary>
		public string UseYn {get; set;}

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
