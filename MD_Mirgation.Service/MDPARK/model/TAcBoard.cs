namespace MD_DataMigration.Service.MDPARK.model
{
	public class TAcBoard
	 {
		/// <summary>
		/// 게시글 seq  Primary Key(Auto Increment)
		/// </summary>
		public int SeqNo {get; set;}

		/// <summary>
		/// 게시판 id (공지사항은 1, 질문은 2)
		/// </summary>
		public int BoardId {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public int FileId {get; set;}

		/// <summary>
		/// 글 제목
		/// </summary>
		public string BoardTitle {get; set;}

		/// <summary>
		/// 게시글내용
		/// </summary>
		public string Content {get; set;}

		/// <summary>
		/// 조회수
		/// </summary>
		public int HitCnt {get; set;}

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
		/// data 수정일시
		/// </summary>
		public string UpdDt {get; set;}

		/// <summary>
		/// data 수정자 ip
		/// </summary>
		public string UpdIp {get; set;}

	 }
}
