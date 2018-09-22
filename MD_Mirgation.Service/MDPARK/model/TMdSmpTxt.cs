namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdSmpTxt
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int HisTxtId {get; set;}

		/// <summary>
		/// 병원 코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 과거력_접수 구분  1: 과거력 2: 접수
		/// </summary>
		public string SmpGbCd {get; set;}

		/// <summary>
		/// 과거력 코드
		/// </summary>
		public string HisCd {get; set;}

		/// <summary>
		/// 과거력 내용
		/// </summary>
		public string HisTxt {get; set;}

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
