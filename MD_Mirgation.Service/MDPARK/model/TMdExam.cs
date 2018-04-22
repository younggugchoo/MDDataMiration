namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdExam
	 {
		/// <summary>
		/// 예문분류 1:증상 2:과거력 3:접수 4:서식 5:메시지 6:청구메모
		/// </summary>
		public string ExamDiv {get; set;}

		/// <summary>
		/// 예문코드
		/// </summary>
		public string ExamCd {get; set;}

		/// <summary>
		/// 사용자ID
		/// </summary>
		public string UserId {get; set;}

		/// <summary>
		/// 사용구분 1:공통 2:개인
		/// </summary>
		public string UseGb {get; set;}

		/// <summary>
		/// 예문제목
		/// </summary>
		public string ExamTtl {get; set;}

		/// <summary>
		/// 예문내용
		/// </summary>
		public string ExamCont {get; set;}

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
