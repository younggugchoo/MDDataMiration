namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdPackOrdMidd
	 {
		/// <summary>
		/// 용도 P:묶음처방 D:약 A:병리 R:방사선 H:검진 v:접종
		/// </summary>
		public string UseTy {get; set;}

		/// <summary>
		/// 대분류ID
		/// </summary>
		public string LdivId {get; set;}

		/// <summary>
		/// 중분류ID
		/// </summary>
		public string MdivId {get; set;}

		/// <summary>
		/// 사용자ID
		/// </summary>
		public string UserId {get; set;}

		/// <summary>
		/// 중분류명
		/// </summary>
		public string MdivNm {get; set;}

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
