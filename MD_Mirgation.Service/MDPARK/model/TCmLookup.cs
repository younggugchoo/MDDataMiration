namespace MD_DataMigration.Service.MDPARK.model
{
	public class TCmLookup
	 {
		/// <summary>
		/// lookup type
		/// </summary>
		public string LookupType {get; set;}

		/// <summary>
		/// lookup code
		/// </summary>
		public string LookupCode {get; set;}

		/// <summary>
		/// meaning
		/// </summary>
		public string Meaning {get; set;}

		/// <summary>
		/// 조회 순서
		/// </summary>
		public int Seq {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string Attr1 {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string Attr2 {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string Attr3 {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string Attr4 {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string Attr5 {get; set;}

		/// <summary>
		/// 현 Row의 사용 여부(Y/N)사용중이면 Y,  삭제되어 사용하지 않는다면 N으로 표기함.
		/// </summary>
		public string UseYn {get; set;}

		/// <summary>
		/// data 생성자
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
		/// data 수정일자
		/// </summary>
		public string UpdDt {get; set;}

		/// <summary>
		/// data 수정자 ip
		/// </summary>
		public string UpdIp {get; set;}

	 }
}
