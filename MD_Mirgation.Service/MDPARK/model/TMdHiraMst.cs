namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdHiraMst
	 {
		/// <summary>
		/// 심평원 코드
		/// </summary>
		public string McCd {get; set;}

		/// <summary>
		/// 마스터 구분 1:수가 2: 약 3: 재료
		/// </summary>
		public string MGb {get; set;}

		/// <summary>
		/// 한글명과 영문명을 concat 해서 처리해서 검색에 용이하게 처리함.
		/// </summary>
		public string KorEngNm {get; set;}

		/// <summary>
		/// 한글명
		/// </summary>
		public string Kor {get; set;}

		/// <summary>
		/// 영문명
		/// </summary>
		public string Eng {get; set;}

		/// <summary>
		/// 금액
		/// </summary>
		public string UnitPrice {get; set;}

		/// <summary>
		/// 가산금액
		/// </summary>
		public string AdjPrice {get; set;}

		/// <summary>
		/// 투약경로
		/// </summary>
		public string Path {get; set;}

		/// <summary>
		/// 유효일자 from
		/// </summary>
		public string EffFrom {get; set;}

		/// <summary>
		/// 유효일자 to
		/// </summary>
		public string EffTo {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string Jang {get; set;}

	 }
}
