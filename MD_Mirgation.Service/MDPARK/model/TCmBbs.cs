namespace MD_DataMigration.Service.MDPARK.model
{
	public class TCmBbs
	 {
		/// <summary>
		/// 게시순번
		/// </summary>
		public int BbsSeq {get; set;}

		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 서브시스템코드
		/// </summary>
		public string SubSysCd {get; set;}

		/// <summary>
		/// 게시판구분 A:공지 E:이벤트 F:FAQ
		/// </summary>
		public string BbsGb {get; set;}

		/// <summary>
		/// 상단공지여부
		/// </summary>
		public string UpperYn {get; set;}

		/// <summary>
		/// 제목
		/// </summary>
		public string Ttl {get; set;}

		/// <summary>
		/// 상세내용
		/// </summary>
		public string Cont {get; set;}

		/// <summary>
		/// 표시여부
		/// </summary>
		public string DispYn {get; set;}

		/// <summary>
		/// 조회수
		/// </summary>
		public int ReadCnt {get; set;}

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
