namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdSpecCd
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int LineId {get; set;}

		/// <summary>
		/// 줄단위인지 아니면 명일련 단위인지 구분함.L : 줄단위   S:명일련단위(청구단위)
		/// </summary>
		public string LineGb {get; set;}

		/// <summary>
		/// 구분코드 (ex JX999, MX999)
		/// </summary>
		public string LineCd {get; set;}

		/// <summary>
		/// 특정내역
		/// </summary>
		public string Spec {get; set;}

		/// <summary>
		/// 작성요령
		/// </summary>
		public string ExpTxt {get; set;}

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
