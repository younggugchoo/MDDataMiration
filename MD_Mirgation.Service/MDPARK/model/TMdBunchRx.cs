namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdBunchRx
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int BunchRxId {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public int BunchId {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string BunchRxNm {get; set;}

		/// <summary>
		/// 묶음 처방코드
		/// </summary>
		public string BunchRxCd {get; set;}

		/// <summary>
		/// 용량
		/// </summary>
		public string BunchQty {get; set;}

		/// <summary>
		/// 횟수
		/// </summary>
		public string BunchCnt {get; set;}

		/// <summary>
		/// 일수
		/// </summary>
		public string BunchDay {get; set;}

		/// <summary>
		/// 용법
		/// </summary>
		public string BunchUsg {get; set;}

		/// <summary>
		/// 상태
		/// </summary>
		public string BunchSts {get; set;}

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
