namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdAlrgInfo
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
		/// 알레르기일련번호
		/// </summary>
		public int AlrgSeq {get; set;}

		/// <summary>
		/// 알레르기구분 D:약품 F:식품 Z:기타
		/// </summary>
		public string AlrgGb {get; set;}

		/// <summary>
		/// 처방코드 식품코드 기타코드
		/// </summary>
		public string OrdCd {get; set;}

		/// <summary>
		/// 알레르기명
		/// </summary>
		public string AlrgNm {get; set;}

		/// <summary>
		/// 성분코드
		/// </summary>
		public string IngreCd {get; set;}

		/// <summary>
		/// 기타
		/// </summary>
		public string Etc {get; set;}

		/// <summary>
		/// 특이사항
		/// </summary>
		public string Rmk {get; set;}

		/// <summary>
		/// 의심/확실구분 1:의심 2:확실
		/// </summary>
		public string DoubtSureGb {get; set;}

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
