namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMhChkupForm
	 {
		/// <summary>
		/// 사업년월
		/// </summary>
		public string BizYymm {get; set;}

		/// <summary>
		/// 서식구분 A0:기본문진 A1:노인기능평가 A2:인지기능장애평가 A3:정신건강검사(우울증)평가 B0:암문진 B1:위암 B2:간암 B3:대장암 B4:유방암 B5:자궁경부암 10:흡연 11:금연처방전 20:음주 21:금주/절주처방전 30:운동 31:운동처방전 40:영양 41:영양처방전 50:비만 51:비만처방전
		/// </summary>
		public string FormGb {get; set;}

		/// <summary>
		/// 서식제목
		/// </summary>
		public string FormTtl {get; set;}

		/// <summary>
		/// 대상자
		/// </summary>
		public string Target {get; set;}

		/// <summary>
		/// 등록자ID
		/// </summary>
		public string InsId {get; set;}

		/// <summary>
		/// 등록일시
		/// </summary>
		public string InsDt {get; set;}

	 }
}
