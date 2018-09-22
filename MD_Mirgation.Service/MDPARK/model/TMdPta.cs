namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdPta
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int PtaId {get; set;}

		/// <summary>
		/// 환자 id
		/// </summary>
		public int PtntId {get; set;}

		/// <summary>
		/// 데시벨250
		/// </summary>
		public int D250 {get; set;}

		/// <summary>
		/// 데시벨500
		/// </summary>
		public int D500 {get; set;}

		/// <summary>
		/// 데시벨1000
		/// </summary>
		public int D1000 {get; set;}

		/// <summary>
		/// 데시벨2000
		/// </summary>
		public int D2000 {get; set;}

		/// <summary>
		/// 데시벨4000
		/// </summary>
		public int D4000 {get; set;}

		/// <summary>
		/// 데시벨6000
		/// </summary>
		public int D6000 {get; set;}

		/// <summary>
		/// 데시벨8000
		/// </summary>
		public int D8000 {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string LrGb {get; set;}

		/// <summary>
		/// 측정일
		/// </summary>
		public string TestDy {get; set;}

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
