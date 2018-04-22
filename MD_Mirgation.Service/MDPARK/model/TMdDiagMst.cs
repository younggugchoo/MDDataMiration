namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdDiagMst
	 {
		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 상병코드
		/// </summary>
		public string DiagCd {get; set;}

		/// <summary>
		/// 적용시작일
		/// </summary>
		public string FrYmd {get; set;}

		/// <summary>
		/// 기준상병코드
		/// </summary>
		public string EdiDiagCd {get; set;}

		/// <summary>
		/// 상병일련번호
		/// </summary>
		public int DiagSeq {get; set;}

		/// <summary>
		/// 적용종료일
		/// </summary>
		public string ToYmd {get; set;}

		/// <summary>
		/// 한글명
		/// </summary>
		public string KorNm {get; set;}

		/// <summary>
		/// 영문명
		/// </summary>
		public string EngNm {get; set;}

		/// <summary>
		/// 법정감염병구분 1:제1군 2:제2군 3:제3군 4:제4군 5:제5군 Z:지정군
		/// </summary>
		public string LegalIcdGb {get; set;}

		/// <summary>
		/// 성별구분
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
		/// 산정특례여부
		/// </summary>
		public string SpecCalYn {get; set;}

		/// <summary>
		/// 희귀상병여부
		/// </summary>
		public string RareDiagYn {get; set;}

		/// <summary>
		/// 완전코드구분
		/// </summary>
		public string PrfectCdGb {get; set;}

		/// <summary>
		/// 급여구분 1:급여 2:비급여 3:50/100급여 4:80/100급여 5:100/100급여
		/// </summary>
		public string SalGb {get; set;}

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

		/// <summary>
		/// 주상병사용구분
		/// </summary>
		public string MainDiagUseGb {get; set;}

	 }
}
