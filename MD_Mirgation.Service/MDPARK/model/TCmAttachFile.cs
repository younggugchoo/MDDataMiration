namespace MD_DataMigration.Service.MDPARK.model
{
	public class TCmAttachFile
	 {
		/// <summary>
		/// 첨부순번
		/// </summary>
		public int AttachSeq {get; set;}

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
