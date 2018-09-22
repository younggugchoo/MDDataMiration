namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdVcHist
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int VcHistId {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public int VcId {get; set;}

		/// <summary>
		/// 환자 id
		/// </summary>
		public int PtntId {get; set;}

		/// <summary>
		/// 접종차수 : 1, 2, 3차...
		/// </summary>
		public int VcTime {get; set;}

		/// <summary>
		/// 접종일자
		/// </summary>
		public string VcDy {get; set;}

		/// <summary>
		/// 접종부위 ( INJECTION_PART ) 
		/// </summary>
		public string VcLoc {get; set;}

		/// <summary>
		/// 비고 : 접종부위가 기타일 경우 작성함.
		/// </summary>
		public string Remark {get; set;}

		/// <summary>
		/// 원내여부 ( IN_OUT_GB )
		/// </summary>
		public string OutYn {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string ReportYn {get; set;}

		/// <summary>
		/// 질병관리공단 신고일자
		/// </summary>
		public string ReportDy {get; set;}

		/// <summary>
		/// 질병관리공단 신고자
		/// </summary>
		public string Reporter {get; set;}

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
