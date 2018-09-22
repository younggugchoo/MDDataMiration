namespace MD_DataMigration.Service.MDPARK.model
{
	public class TCmMsgHist
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int MsgHistId {get; set;}

		/// <summary>
		/// 메시지 id
		/// </summary>
		public int MsgId {get; set;}

		/// <summary>
		/// 병원 코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 예상발송시간
		/// </summary>
		public string SchSendDt {get; set;}

		/// <summary>
		/// 실제 발송시간
		/// </summary>
		public string SendDt {get; set;}

		/// <summary>
		/// 발송 방법 1: SMS + APP 2:SMS 3: APP
		/// </summary>
		public string SendMtd {get; set;}

		/// <summary>
		/// 발송번호( system에서 메시지를 발송하는 번호, 병원전화번호임)
		/// </summary>
		public string SendNo {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string MsgTxt {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public int PtntId {get; set;}

		/// <summary>
		/// 메시지 구분(1: Msg, 2: CRM)
		/// </summary>
		public string MsgGb {get; set;}

		/// <summary>
		/// 메시지가 개인 혹은 그룹에서 호출되었는지 check
		/// </summary>
		public string MsgGb2 {get; set;}

		/// <summary>
		/// 연관되는 진료 id(증상 crm 텍스트로 보낼 경우에 해당됨)
		/// </summary>
		public int RcvId {get; set;}

		/// <summary>
		/// 진료차트의 증상 입력중 crm 문구를 작성할 수 있음.
		/// </summary>
		public string SxCrmTxt {get; set;}

		/// <summary>
		/// 메시지 등록상태1: 등록2: 확인최초에는 등록이 되며 확인상태로 변경되면 batch에서 한번에 보낸다.
		/// </summary>
		public string MstStat {get; set;}

		/// <summary>
		/// 전송상태1: 임시저장 (최초 저장시에는 임시저장임)2: 실제발송요청3. 발송완료
		/// </summary>
		public string SendYn {get; set;}

		/// <summary>
		/// 환자 구분( 많은 case가 있음. 초진환자 .. 심부전증 .. 용종..)
		/// </summary>
		public string PtntGb {get; set;}

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
