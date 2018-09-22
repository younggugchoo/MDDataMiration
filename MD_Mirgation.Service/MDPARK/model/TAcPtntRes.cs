namespace MD_DataMigration.Service.MDPARK.model
{
	public class TAcPtntRes
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int ResRxId {get; set;}

		/// <summary>
		/// 병원 코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 예약환자 id
		/// </summary>
		public int ResPtntId {get; set;}

		/// <summary>
		/// 예약일
		/// </summary>
		public string ResDy {get; set;}

		/// <summary>
		/// 예약 상태(lookup type : RES_STS)
		/// </summary>
		public string ResStat {get; set;}

		/// <summary>
		/// 처방코드중에 random한 1개의 처방코드를 표기함prescription 
		/// </summary>
		public string RxCd {get; set;}

		/// <summary>
		/// 담당의사 id
		/// </summary>
		public string ResUserId {get; set;}

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
