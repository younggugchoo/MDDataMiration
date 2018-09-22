namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdVcClr
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int VcClrId {get; set;}

		/// <summary>
		/// 병원 코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 부위(INJECTION_PART)
		/// </summary>
		public string VcLoc {get; set;}

		/// <summary>
		/// 배경색상(VC_COLOR)
		/// </summary>
		public string VcClr {get; set;}

		/// <summary>
		/// 백신등록구분  (VC_LOCAL_GB)
		/// </summary>
		public string VcGb {get; set;}

		/// <summary>
		/// 백신등록구분이 기타일 경우 비고를 사용함.
		/// </summary>
		public string Remark {get; set;}

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
