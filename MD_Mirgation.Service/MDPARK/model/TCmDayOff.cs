namespace MD_DataMigration.Service.MDPARK.model
{
	public class TCmDayOff
	 {
		/// <summary>
		/// 공휴일seq
		/// </summary>
		public int DayOffSeq {get; set;}

		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 휴일명
		/// </summary>
		public string OffNm {get; set;}

		/// <summary>
		/// 휴일mmdd
		/// </summary>
		public string OffMmdd {get; set;}

		/// <summary>
		/// 음력여부
		/// </summary>
		public string LrrYn {get; set;}

		/// <summary>
		/// 휴일날수
		/// </summary>
		public string OffCnt {get; set;}

		/// <summary>
		/// 휴일구분
		/// </summary>
		public string OffGb {get; set;}

		/// <summary>
		/// 등록자ID
		/// </summary>
		public string InsId {get; set;}

		/// <summary>
		/// 등록일시
		/// </summary>
		public string InsDt {get; set;}

		/// <summary>
		/// 수정자ID
		/// </summary>
		public string UpdId {get; set;}

		/// <summary>
		/// 수정일시
		/// </summary>
		public string UpdDt {get; set;}

	 }
}
