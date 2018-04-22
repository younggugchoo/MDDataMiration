namespace MD_DataMigration.Service.MDPARK.model
{
	public class TCmMenu
	 {
		/// <summary>
		/// 메뉴id
		/// </summary>
		public string MenuId {get; set;}

		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 서브_시스템_코드 HU: 홈페이지사용자메뉴 HO:홈페이지관리자메뉴
		/// </summary>
		public string SubSysCd {get; set;}

		/// <summary>
		/// 메뉴명
		/// </summary>
		public string MenuNm {get; set;}

		/// <summary>
		/// 링크URL
		/// </summary>
		public string LinkUrl {get; set;}

		/// <summary>
		/// 정렬순서
		/// </summary>
		public int SortOrd {get; set;}

		/// <summary>
		/// 상위메뉴id
		/// </summary>
		public string OwnerMenuId {get; set;}

		/// <summary>
		/// 메뉴depth
		/// </summary>
		public string MenuDepth {get; set;}

		/// <summary>
		/// 사용여부
		/// </summary>
		public string UseYn {get; set;}

		/// <summary>
		/// 표시여부 default:Y
		/// </summary>
		public string DispYn {get; set;}

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
