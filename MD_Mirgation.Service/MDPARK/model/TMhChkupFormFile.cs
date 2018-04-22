namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMhChkupFormFile
	 {
		/// <summary>
		/// FILE_SEQ
		/// </summary>
		public int FileSeq {get; set;}

		/// <summary>
		/// 사업년월
		/// </summary>
		public string BizYymm {get; set;}

		/// <summary>
		/// 서식구분
		/// </summary>
		public string FormGb {get; set;}

		/// <summary>
		/// 파일명
		/// </summary>
		public string FileNm {get; set;}

		/// <summary>
		/// 파일경로
		/// </summary>
		public string FilePath {get; set;}

		/// <summary>
		/// 서버파일명
		/// </summary>
		public string ServerFileNm {get; set;}

		/// <summary>
		/// 등록자ID
		/// </summary>
		public string InsId {get; set;}

		/// <summary>
		/// 등록일시
		/// </summary>
		public string InsDt {get; set;}

	 }
}
