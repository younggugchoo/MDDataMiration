namespace MD_DataMigration.Service.MDPARK.model
{
	public class TCmUserAuth
	 {
		/// <summary>
		/// 사용자ID
		/// </summary>
		public string UserId {get; set;}

		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 서브_시스템_코드
		/// </summary>
		public string SubSysCd {get; set;}

		/// <summary>
		/// 권한코드 권한그룹코드 grp_cd:U001
		/// </summary>
		public string AuthCd {get; set;}

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
