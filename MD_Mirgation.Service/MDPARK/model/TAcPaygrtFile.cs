namespace MD_DataMigration.Service.MDPARK.model
{
	public class TAcPaygrtFile
	 {
		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 환자ID
		/// </summary>
		public string PtntId {get; set;}

		/// <summary>
		/// 사고일자
		/// </summary>
		public string AcciYmd {get; set;}

		/// <summary>
		/// 파일일련번호
		/// </summary>
		public int AcciFileSeq {get; set;}

		/// <summary>
		/// 파일경로
		/// </summary>
		public string FilePath {get; set;}

		/// <summary>
		/// 파일명
		/// </summary>
		public string FileNm {get; set;}

		/// <summary>
		/// 서버파일명
		/// </summary>
		public string ServerFileNm {get; set;}

		/// <summary>
		/// 비고
		/// </summary>
		public string Rmk {get; set;}

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
