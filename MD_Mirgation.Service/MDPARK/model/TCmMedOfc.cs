namespace MD_DataMigration.Service.MDPARK.model
{
	public class TCmMedOfc
	 {
		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 진료과코드
		/// </summary>
		public string MedDeptCd {get; set;}

		/// <summary>
		/// 진료실코드
		/// </summary>
		public string MedOfcCd {get; set;}

		/// <summary>
		/// 의사ID
		/// </summary>
		public string UserId {get; set;}

		/// <summary>
		/// 진료실명
		/// </summary>
		public string MedOfc {get; set;}

		/// <summary>
		/// 의사상태 1:진료중 2:검사중 0:휴식중
		/// </summary>
		public string MedDrSt {get; set;}

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
