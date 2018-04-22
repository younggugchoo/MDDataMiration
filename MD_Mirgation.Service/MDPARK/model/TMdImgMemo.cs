namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdImgMemo
	 {
		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 처방일련번호
		/// </summary>
		public int OrdSeq {get; set;}

		/// <summary>
		/// 환자ID
		/// </summary>
		public string PtntId {get; set;}

		/// <summary>
		/// 이미지파일명
		/// </summary>
		public string ImgFileNm {get; set;}

		/// <summary>
		/// 파일경로
		/// </summary>
		public string FilePath {get; set;}

		/// <summary>
		/// 서버파일명
		/// </summary>
		public string ServerFileNm {get; set;}

	 }
}
