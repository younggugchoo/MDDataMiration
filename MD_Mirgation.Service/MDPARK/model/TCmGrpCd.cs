namespace MD_DataMigration.Service.MDPARK.model
{
	public class TCmGrpCd
	 {
		/// <summary>
		/// 그룹코드
		/// </summary>
		public string GrpCd {get; set;}

		/// <summary>
		/// 서브시스템코드
		/// </summary>
		public string SubSysCd {get; set;}

		/// <summary>
		/// 병원코드:000(공통)
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 그룹코드명
		/// </summary>
		public string GrpCdNm {get; set;}

		/// <summary>
		/// 그룹코드영문명
		/// </summary>
		public string GrpCdEngNm {get; set;}

		/// <summary>
		/// 사용여부
		/// </summary>
		public string UseYn {get; set;}

		/// <summary>
		/// 비고
		/// </summary>
		public string Rmk {get; set;}

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
