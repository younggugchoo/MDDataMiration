namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdPsbExamMst
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int ExamMstId {get; set;}

		/// <summary>
		/// 처방 id
		/// </summary>
		public int PsbId {get; set;}

		/// <summary>
		/// 환자 id
		/// </summary>
		public int PtntId {get; set;}

		/// <summary>
		/// 검사결과 입력여부
		/// </summary>
		public string WriteYn {get; set;}

		/// <summary>
		/// 검사결과
		/// </summary>
		public string ExamRslt {get; set;}

		/// <summary>
		/// 검사결과 입력일시
		/// </summary>
		public string ExamWriteDt {get; set;}

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
