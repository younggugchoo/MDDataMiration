namespace MD_DataMigration.Service.MDPARK.model
{
	public class TCmBanner
	 {
		/// <summary>
		/// 순번
		/// </summary>
		public int Seq {get; set;}

		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 배너위치 L:좌측 R:우측
		/// </summary>
		public string BannerLoc {get; set;}

		/// <summary>
		/// 사용여부
		/// </summary>
		public string UseYn {get; set;}

		/// <summary>
		/// 링크URL
		/// </summary>
		public string LinkUrl {get; set;}

		/// <summary>
		/// 제목
		/// </summary>
		public string Ttl {get; set;}

		/// <summary>
		/// 상세내용
		/// </summary>
		public string Cont {get; set;}

		/// <summary>
		/// 이미지파일명
		/// </summary>
		public string ImgFileNm {get; set;}

		/// <summary>
		/// 서버이미지파일명
		/// </summary>
		public string ServerImgFileNm {get; set;}

		/// <summary>
		/// 파일경로
		/// </summary>
		public string FilePath {get; set;}

		/// <summary>
		/// 클릭조회수
		/// </summary>
		public int ClkCnt {get; set;}

		/// <summary>
		/// 오픈구분 N:새창 M:본창
		/// </summary>
		public string OpenGb {get; set;}

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
