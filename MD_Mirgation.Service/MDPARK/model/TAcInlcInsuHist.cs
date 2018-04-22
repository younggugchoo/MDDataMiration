namespace MD_DataMigration.Service.MDPARK.model
{
	public class TAcInlcInsuHist
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
		/// 재해발생일
		/// </summary>
		public string AcciYmd {get; set;}

		/// <summary>
		/// 적용시작일
		/// </summary>
		public string FrYmd {get; set;}

		/// <summary>
		/// 적용종료일
		/// </summary>
		public string ToYmd {get; set;}

		/// <summary>
		/// 사업장명
		/// </summary>
		public string BzNm {get; set;}

		/// <summary>
		/// 후유증상여부
		/// </summary>
		public string AftYn {get; set;}

		/// <summary>
		/// 취소일시
		/// </summary>
		public string RejtDt {get; set;}

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
