namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdMmoTxt
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int LineTxtId {get; set;}

		/// <summary>
		/// 병원 코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// MX999 등 심평원 구분 코드(줄단위코드, 명일련단위코드 다 포함함)
		/// </summary>
		public string LineCd {get; set;}

		/// <summary>
		/// 상용문구 순서
		/// </summary>
		public int CommSeq {get; set;}

		/// <summary>
		/// 상욤문구
		/// </summary>
		public string CommTxt {get; set;}

		/// <summary>
		/// 상용코드 사용자가 단순 입력한 코드성 value
		/// </summary>
		public string CommCd {get; set;}

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
