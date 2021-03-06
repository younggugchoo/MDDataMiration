namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdVtSet
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int ColId {get; set;}

		/// <summary>
		/// 의사 id
		/// </summary>
		public string UserId {get; set;}

		/// <summary>
		/// 컬럼의 원래 이름
		/// </summary>
		public string ColNm {get; set;}

		/// <summary>
		/// 컬럼의 화면에서 조회 순서
		/// </summary>
		public int ColSeq {get; set;}

		/// <summary>
		/// 컬럼의 원래 이름에서 단축된 이름
		/// </summary>
		public string ColMark {get; set;}

		/// <summary>
		/// combo에서 선택한 검사 group id
		/// </summary>
		public int RxGrpId {get; set;}

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
