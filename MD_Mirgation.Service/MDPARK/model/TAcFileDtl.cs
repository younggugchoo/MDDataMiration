namespace MD_DataMigration.Service.MDPARK.model
{
	public class TAcFileDtl
	 {
		/// <summary>
		/// 
		/// </summary>
		public int FileId {get; set;}

		/// <summary>
		/// file_id에 대한 파일 순서
		/// </summary>
		public int Seq {get; set;}

		/// <summary>
		/// 파일 원래 이름
		/// </summary>
		public string OrigNm {get; set;}

		/// <summary>
		/// 변경된 파일 이름
		/// </summary>
		public string ChgNm {get; set;}

		/// <summary>
		/// 파일 크기
		/// </summary>
		public int FileSize {get; set;}

		/// <summary>
		/// NAS 저장 위치
		/// </summary>
		public string FileLoc {get; set;}

		/// <summary>
		/// 현 Row의 사용 여부(Y/N)사용중이면 Y,  삭제되어 사용하지 않는다면 N으로 표기함.
		/// </summary>
		public string UseYn {get; set;}

		/// <summary>
		/// data 생성자
		/// </summary>
		public string InsId {get; set;}

		/// <summary>
		/// data 생성일시
		/// </summary>
		public string InsDt {get; set;}

		/// <summary>
		/// data 생성자 ip
		/// </summary>
		public string InsIp {get; set;}

		/// <summary>
		/// data 수정자 id
		/// </summary>
		public string UpdId {get; set;}

		/// <summary>
		/// data 수정일자
		/// </summary>
		public string UpdDt {get; set;}

		/// <summary>
		/// data 수정자 ip
		/// </summary>
		public string UpdIp {get; set;}

	 }
}
