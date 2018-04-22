namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdPackOrdLarg
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
		/// 사용자ID
		/// </summary>
		public string UserId {get; set;}

		/// <summary>
		/// 대분류명
		/// </summary>
		public string LdivNm {get; set;}

		/// <summary>
		/// NR사용여부
		/// </summary>
		public string NruseYn {get; set;}

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
