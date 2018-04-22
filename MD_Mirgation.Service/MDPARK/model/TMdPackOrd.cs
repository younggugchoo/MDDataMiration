namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdPackOrd
	 {
		/// <summary>
		/// 용도 P:묶음처방 D:약 A:병리 R:방사선 H:검진 v:접종
		/// </summary>
		public string UseTy {get; set;}

		/// <summary>
		/// 대분류ID
		/// </summary>
		public string LdivId {get; set;}

		/// <summary>
		/// 중분류ID
		/// </summary>
		public string MdivId {get; set;}

		/// <summary>
		/// 사용자ID
		/// </summary>
		public string UserId {get; set;}

		/// <summary>
		/// 처방코드
		/// </summary>
		public string OrdCd {get; set;}

		/// <summary>
		/// 용량
		/// </summary>
		public int Qty {get; set;}

		/// <summary>
		/// 일투
		/// </summary>
		public int DayTimes {get; set;}

		/// <summary>
		/// 일수
		/// </summary>
		public int DayCnt {get; set;}

		/// <summary>
		/// 용법코드 공통코드(t_cm_cd)=약용법(DUSE),방사선용법(USA2),처방의용법(USEG)
		/// </summary>
		public string UsageCd {get; set;}

		/// <summary>
		/// 영상=부위-Lt
		/// </summary>
		public string PartLt {get; set;}

		/// <summary>
		/// 영상=부위-Rt
		/// </summary>
		public string PartRt {get; set;}

		/// <summary>
		/// 영상=부위-Both
		/// </summary>
		public string PartBoth {get; set;}

		/// <summary>
		/// 영상=부위-Both개별수가
		/// </summary>
		public string PartBothEdiCd {get; set;}

		/// <summary>
		/// 영상=수가코드
		/// </summary>
		public string EdiCd {get; set;}

		/// <summary>
		/// 비고
		/// </summary>
		public string Rmk {get; set;}

		/// <summary>
		/// 등록일시
		/// </summary>
		public string InsDt {get; set;}

		/// <summary>
		/// 수정일시
		/// </summary>
		public string UpdDt {get; set;}

	 }
}
