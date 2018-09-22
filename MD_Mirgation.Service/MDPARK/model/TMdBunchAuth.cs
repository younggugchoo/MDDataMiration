namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdBunchAuth
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int BunchAuthId {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public int BunchId {get; set;}

		/// <summary>
		/// 사용자 id 임.전체 :  ALL의사전체 : DOC_ALL간호사전체 : NURSE_ALL그외는 사용자 ID가 들어갈 것임.
		/// </summary>
		public string UserId {get; set;}

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
		/// data 수정일시
		/// </summary>
		public string UpdDt {get; set;}

		/// <summary>
		/// data 수정자 ip
		/// </summary>
		public string UpdIp {get; set;}

	 }
}
