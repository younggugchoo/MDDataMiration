namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdRxMCd
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int RxMId {get; set;}

		/// <summary>
		/// 방사선 대 카테고리 id
		/// </summary>
		public int RxLId {get; set;}

		/// <summary>
		/// 부위명(한글)
		/// </summary>
		public string RxMNm {get; set;}

		/// <summary>
		/// 부위명(영문)
		/// </summary>
		public string Eng {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string BasicMcCd {get; set;}

		/// <summary>
		/// 화면에서 보여지는 순서
		/// </summary>
		public int MSeq {get; set;}

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
		/// data 생성자 ip
		/// </summary>
		public string InsIp {get; set;}

		/// <summary>
		/// data 수정자 id
		/// </summary>
		public string UpdId {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string UpdDt {get; set;}

		/// <summary>
		/// data 수정자 ip
		/// </summary>
		public string UpdIp {get; set;}

	 }
}
