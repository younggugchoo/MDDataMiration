namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdVcSet
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int VcId {get; set;}

		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 백신코드(VC_GB)
		/// </summary>
		public string VcCd {get; set;}

		/// <summary>
		/// 대부분 비급여로서 원내코드일 것임.
		/// </summary>
		public string McCd {get; set;}

		/// <summary>
		/// 백신이 화면에서 보여지는 순서
		/// </summary>
		public int VcTime {get; set;}

		/// <summary>
		/// 백신 주기
		/// </summary>
		public string VcCycle {get; set;}

		/// <summary>
		/// 현 Row의 사용 여부(Y/N)사용중이면 Y,  삭제되어 사용하지 않는다면 N으로 표기함.
		/// </summary>
		public string UseYn {get; set;}

		/// <summary>
		/// data 생성자 id
		/// </summary>
		public string InsId {get; set;}

		/// <summary>
		/// data 생성일시
		/// </summary>
		public string InsDt {get; set;}

		/// <summary>
		/// data 생성자 ip
		/// </summary>
		public string InsIp {get; set;}

		/// <summary>
		/// data 수정자 id
		/// </summary>
		public string UpdId {get; set;}

		/// <summary>
		/// data 수정일시
		/// </summary>
		public string UpdDt {get; set;}

		/// <summary>
		/// data 수정자 ip
		/// </summary>
		public string UpdIp {get; set;}

	 }
}
