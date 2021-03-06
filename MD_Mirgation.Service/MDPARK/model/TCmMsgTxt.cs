namespace MD_DataMigration.Service.MDPARK.model
{
	public class TCmMsgTxt
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int MsgTxtId {get; set;}

		/// <summary>
		/// 병원 코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 상용문구 코드명( 코드명을 click하면 연결된 내용이 화면에 출력됨)
		/// </summary>
		public string TxtCdNm {get; set;}

		/// <summary>
		/// 상용문구제목
		/// </summary>
		public string TxtTitle {get; set;}

		/// <summary>
		/// 상용 문구
		/// </summary>
		public string Txt {get; set;}

		/// <summary>
		/// 상용문구순서
		/// </summary>
		public int TxtSeq {get; set;}

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
