namespace MD_DataMigration.Service.MDPARK.model
{
	public class TAcMedDrt
	 {
		/// <summary>
		/// 진료시간id
		/// </summary>
		public int DrtId {get; set;}

		/// <summary>
		/// 접수 id
		/// </summary>
		public int RcvId {get; set;}

		/// <summary>
		/// 진료시작시간
		/// </summary>
		public string ConStTm {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string ConEndTm {get; set;}

		/// <summary>
		/// 진료의사id
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
