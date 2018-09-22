namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdDzCtlP
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int DzLpId {get; set;}

		/// <summary>
		/// 질병분류 대 id (질병분류 테이블과 join용)
		/// </summary>
		public int DzLId {get; set;}

		/// <summary>
		/// 병원 코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 진료과목(HIRA_MD_FLD)01: 내과분야 02: 외과분야03: 산?소아청소년과분야 04: 안?이비인후과분야05: 피부?비뇨기과분야
		/// </summary>
		public string MdDpt {get; set;}

		/// <summary>
		/// 초진산정기간
		/// </summary>
		public int FstMdPrd {get; set;}

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
