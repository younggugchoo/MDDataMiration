namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMhPersInf
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int HPersId {get; set;}

		/// <summary>
		/// 병원 코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 환자 id
		/// </summary>
		public int PtntId {get; set;}

		/// <summary>
		/// 사용자 id
		/// </summary>
		public string UserId {get; set;}

		/// <summary>
		/// 건강검진 접수일
		/// </summary>
		public string HChkDy {get; set;}

		/// <summary>
		/// 대상자구분 ( HEALTH_TARGET_GB) : 일반, 영유아..
		/// </summary>
		public string TargetGb {get; set;}

		/// <summary>
		/// 검진 년도
		/// </summary>
		public string ExamYr {get; set;}

		/// <summary>
		/// 소속지사 (EX 시흥지사)
		/// </summary>
		public string AssignBranch {get; set;}

		/// <summary>
		/// 보험증번호
		/// </summary>
		public string InsNo {get; set;}

		/// <summary>
		/// 직역구분 (ex 직장)
		/// </summary>
		public string JobGb {get; set;}

		/// <summary>
		/// 사업장번호
		/// </summary>
		public string BizAreaNo {get; set;}

		/// <summary>
		/// 진단대상(ex 직장가입자)
		/// </summary>
		public string ChkTarget {get; set;}

		/// <summary>
		/// 국가암 통보처
		/// </summary>
		public string CancerInfPlace {get; set;}

		/// <summary>
		/// 현 Row의 사용 여부(Y/N)사용중이면 Y,  삭제되어 사용하지 않는다면 N으로 표기함.
		/// </summary>
		public string UseYn {get; set;}

		/// <summary>
		/// data 생성자 id
		/// </summary>
		public string InsId {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string InsDt {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string InsIp {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string UpdId {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string UpdDt {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string UpdIp {get; set;}

	 }
}
