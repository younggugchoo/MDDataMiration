namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdPaDtlMst
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int McDtlId {get; set;}

		/// <summary>
		/// 병원 코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string McCd {get; set;}

		/// <summary>
		/// 처방코드
		/// </summary>
		public string ExamCd {get; set;}

		/// <summary>
		/// 병리검사 세부명
		/// </summary>
		public string ExamNm {get; set;}

		/// <summary>
		/// 검사 결과 단위
		/// </summary>
		public string PaUnit {get; set;}

		/// <summary>
		/// 검사 결과 상한
		/// </summary>
		public int High {get; set;}

		/// <summary>
		/// 검사 결과 하한
		/// </summary>
		public int Low {get; set;}

		/// <summary>
		/// 원내/원외여부( IN_OUT_GB )
		/// </summary>
		public string InOut {get; set;}

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
