namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdMemo
	 {
		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 환자ID
		/// </summary>
		public string PtntId {get; set;}

		/// <summary>
		/// 메모구분 N:접수메모 D:진료메모
		/// </summary>
		public string MemoGb {get; set;}

		/// <summary>
		/// 메모번호
		/// </summary>
		public int MemoSeq {get; set;}

		/// <summary>
		/// 메모
		/// </summary>
		public string Memo {get; set;}

		/// <summary>
		/// 삭제여부
		/// </summary>
		public string DelYn {get; set;}

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
