namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdPaDtl
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int PaDtlId {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public int PaLineId {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public int McDtlId {get; set;}

		/// <summary>
		/// 단위
		/// </summary>
		public string PaUnit {get; set;}

		/// <summary>
		/// 상한 검사치
		/// </summary>
		public int High {get; set;}

		/// <summary>
		/// 하한검사치
		/// </summary>
		public int Low {get; set;}

		/// <summary>
		/// 원내/원외여부 (IN_OUT_GB)
		/// </summary>
		public string InOut {get; set;}

		/// <summary>
		/// 조회순서 :  level 1 에서의 조회순서임.
		/// </summary>
		public int DtlSeq {get; set;}

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
