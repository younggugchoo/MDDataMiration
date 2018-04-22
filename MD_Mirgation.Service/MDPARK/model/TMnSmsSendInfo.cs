namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMnSmsSendInfo
	 {
		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 메시지번호
		/// </summary>
		public string MsgNo {get; set;}

		/// <summary>
		/// 환자ID
		/// </summary>
		public string PtntId {get; set;}

		/// <summary>
		/// 예약번호
		/// </summary>
		public string ResvNo {get; set;}

		/// <summary>
		/// 시스템코드
		/// </summary>
		public string SysCd {get; set;}

		/// <summary>
		/// 발송일
		/// </summary>
		public string SendYmd {get; set;}

		/// <summary>
		/// 시분
		/// </summary>
		public string Hhmm {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string SendDt {get; set;}

		/// <summary>
		/// 발신전용번호
		/// </summary>
		public string SendExno {get; set;}

		/// <summary>
		/// 발신번호
		/// </summary>
		public string SendNo {get; set;}

		/// <summary>
		/// 상용문구코드
		/// </summary>
		public string CmMsgCd {get; set;}

		/// <summary>
		/// 제목
		/// </summary>
		public string Ttl {get; set;}

		/// <summary>
		/// 내용
		/// </summary>
		public string MsgTxt {get; set;}

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

		/// <summary>
		/// 발송구분 1:즉시 2:예약
		/// </summary>
		public string SendGb {get; set;}

		/// <summary>
		/// 발송취소여부
		/// </summary>
		public string SendCanclYn {get; set;}

		/// <summary>
		/// 결과코드
		/// </summary>
		public string RsltCd {get; set;}

		/// <summary>
		/// 발송취소일시
		/// </summary>
		public string SendCanclDT {get; set;}

	 }
}
