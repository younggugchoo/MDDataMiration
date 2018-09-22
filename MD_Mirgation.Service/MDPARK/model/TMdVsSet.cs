namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdVsSet
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int VsId {get; set;}

		/// <summary>
		/// 기본정보 Tab 혹은 바이탈 Tab 구분 : ( BASIC_BTL_GB )
		/// </summary>
		public string BasicBtlGb {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string UserId {get; set;}

		/// <summary>
		/// 신장
		/// </summary>
		public string HeightYn {get; set;}

		/// <summary>
		/// 체중
		/// </summary>
		public string WeightYn {get; set;}

		/// <summary>
		/// BMI
		/// </summary>
		public string BmiYn {get; set;}

		/// <summary>
		/// 허리둘레
		/// </summary>
		public string WaistYn {get; set;}

		/// <summary>
		/// 혈당(식전) Blood sugar
		/// </summary>
		public string Bs1Yn {get; set;}

		/// <summary>
		/// 혈당(식후)
		/// </summary>
		public string Bs2Yn {get; set;}

		/// <summary>
		/// 혈압(고) Blood pressure
		/// </summary>
		public string Bp1Yn {get; set;}

		/// <summary>
		/// 혈압(저)
		/// </summary>
		public string Bp2Yn {get; set;}

		/// <summary>
		/// 맥박수
		/// </summary>
		public string PulseYn {get; set;}

		/// <summary>
		/// 호흡수
		/// </summary>
		public string BrthCntYn {get; set;}

		/// <summary>
		/// 체온
		/// </summary>
		public string TempYn {get; set;}

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
