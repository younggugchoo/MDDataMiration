namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdVsDtl
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
		/// 활력증상분류코드 grp_cd:VS
		/// </summary>
		public string VsDivCd {get; set;}

		/// <summary>
		/// 활력증상일련번호
		/// </summary>
		public int VsSeq {get; set;}

		/// <summary>
		/// 측정일자
		/// </summary>
		public string MsmtYmd {get; set;}

		/// <summary>
		/// 측정횟수
		/// </summary>
		public int MsmtSeq {get; set;}

		/// <summary>
		/// 측정값
		/// </summary>
		public string MsmtVal {get; set;}

		/// <summary>
		/// 삭제여부
		/// </summary>
		public string DelYn {get; set;}

		/// <summary>
		/// 입력경로  H:병원(default) M:모바일
		/// </summary>
		public string InsPath {get; set;}

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
