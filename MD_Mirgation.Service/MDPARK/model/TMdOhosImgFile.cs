namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdOhosImgFile
	 {
		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 접수번호
		/// </summary>
		public int RcveNo {get; set;}

		/// <summary>
		/// 이미지SEQ
		/// </summary>
		public int ImgSeq {get; set;}

		/// <summary>
		/// 이미지파일순번
		/// </summary>
		public int FileSeq {get; set;}

		/// <summary>
		/// 환자ID
		/// </summary>
		public string PtntId {get; set;}

		/// <summary>
		/// 이미지파일명
		/// </summary>
		public string ImgFileNm {get; set;}

		/// <summary>
		/// 이미지파일경로
		/// </summary>
		public string ImgFilePth {get; set;}

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
