namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdPdHistDx
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int DxHistId {get; set;}

		/// <summary>
		/// 처방전 발행 id
		/// </summary>
		public int PdHistId {get; set;}

		/// <summary>
		/// 진단 id (UI에서 checked로 표시된 항목만 표기함)
		/// </summary>
		public int DxId {get; set;}

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
