namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdBasicDt
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int BdataId {get; set;}

		/// <summary>
		/// 신장 측정값
		/// </summary>
		public string Height {get; set;}

		/// <summary>
		/// 체중 측정값
		/// </summary>
		public string Weight {get; set;}

		/// <summary>
		/// BMI 측정값
		/// </summary>
		public string Bmi {get; set;}

		/// <summary>
		/// 허리둘레 측정값
		/// </summary>
		public string Waist {get; set;}

		/// <summary>
		/// 혈당(식전) 측정값
		/// </summary>
		public string Bg1 {get; set;}

		/// <summary>
		/// 혈당(식후) 측정값
		/// </summary>
		public string Bs2 {get; set;}

		/// <summary>
		/// 혈압(고) 측정값
		/// </summary>
		public string Bp1 {get; set;}

		/// <summary>
		/// 혈압(저) 측정값
		/// </summary>
		public string Bp2 {get; set;}

		/// <summary>
		/// 맥박수 측정값
		/// </summary>
		public string Pulse {get; set;}

		/// <summary>
		/// 호흡수 측정값
		/// </summary>
		public string BrthCnt {get; set;}

		/// <summary>
		/// 체온 측정값
		/// </summary>
		public string Temp {get; set;}

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

		/// <summary>
		/// 
		/// </summary>
		public int PtntId {get; set;}

	 }
}
