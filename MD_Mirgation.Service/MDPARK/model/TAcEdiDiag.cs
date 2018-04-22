namespace MD_DataMigration.Service.MDPARK.model
{
	public class TAcEdiDiag
	 {
		/// <summary>
		/// 기준상병코드
		/// </summary>
		public string EdiDiagCd {get; set;}

		/// <summary>
		/// 상병일련번호
		/// </summary>
		public int DiagSeq {get; set;}

		/// <summary>
		/// 한글명
		/// </summary>
		public string KorNm {get; set;}

		/// <summary>
		/// 영문명
		/// </summary>
		public string EngNm {get; set;}

		/// <summary>
		/// 완전코드구분
		/// </summary>
		public string PrfectCdGb {get; set;}

		/// <summary>
		/// 법정감염병구분
		/// </summary>
		public string LegalHepatGb {get; set;}

		/// <summary>
		/// 성별
		/// </summary>
		public string Sex {get; set;}

		/// <summary>
		/// 상한연령
		/// </summary>
		public string MaxAge {get; set;}

		/// <summary>
		/// 하한연령
		/// </summary>
		public string MinAge {get; set;}

		/// <summary>
		/// 양한방구분
		/// </summary>
		public string YangHanGb {get; set;}

		/// <summary>
		/// 등록자id
		/// </summary>
		public string InsId {get; set;}

		/// <summary>
		/// 등록일시
		/// </summary>
		public string InsDt {get; set;}

		/// <summary>
		/// 주상병사용구분
		/// </summary>
		public string MainDiagUseGb {get; set;}

	 }
}
