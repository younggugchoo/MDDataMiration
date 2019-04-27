namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdPsb
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int PsbId {get; set;}

		/// <summary>
		/// 접수 id
		/// </summary>
		public int RcvId {get; set;}

		/// <summary>
		/// 처방 코드
		/// </summary>
		public string PsbCd {get; set;}

		/// <summary>
		/// 처방 명: 심평원 코드가 갑자기 사라질 수 있어 이름까지 관리함.
		/// </summary>
		//public string PsbNm {get; set;}

		/// <summary>
		/// 처방이 어떤 table인지 구분-. 심평원 약가 혹은 수가 어느쪽에서 가져오는지 구분함.(M:수가,  D;약가   Z:재료)
		/// </summary>
		//public string MGb {get; set;}

		/// <summary>
		/// 처방 그룹 : 과거차트에서 그룹별로 보여주는 용도로 사용함.( 주사:I, 검사:C, 내복:M)
		/// </summary>
		//public string ViewGr {get; set;}

		/// <summary>
		/// 처방금액
		/// </summary>
		//public string PsbPrice {get; set;}

		/// <summary>
		/// 용량
		/// </summary>
		public string Qd {get; set;}

		/// <summary>
		/// 일일 투여횟수
		/// </summary>
		public string Sd {get; set;}

		/// <summary>
		/// 투여일수
		/// </summary>
		public string Td {get; set;}

		/// <summary>
		/// 원내 원외 구분IN_OUT_GB
		/// </summary>
		public string InOutGb {get; set;}

		/// <summary>
		/// 급여구분 ( SAL_GB )(1: 급여  2:비급여  100, 90, 80, 50, 30)
		/// </summary>
		public string SalGb {get; set;}

		/// <summary>
		/// 01: 진찰료 02: 입원료 03: 투약료 04: 주사료05: 마취료 06: 이학요법료 07: 정신요법료08: 처치 및 수술료09: 검사료 10: 영상진단 및 방사선치료료L: 요양병원·완화의료 정액S: 특수장비 T: 특수재료 및 관련 행위료A: 100분의100미만 본인부담 1B: 100분의100미만 본인부담 2U: 건강보험(의료급여) 100분의100본인부담V: 보훈 등 100분의100본인부담 W: 비급여
		/// </summary>
		public string HangNo {get; set;}

		/// <summary>
		/// 18개 항의 소분류 단위로 부여된 번호 기재?목번호 분류 예시- 진찰료01: 초진 02: 재진03: 응급 및 회송료 등- 입원료01: 일반02: 내과질환자, 정신질환자, 만8세미만의 소아03: 중환자실 04: 격리병실10: 기본식대 11: 가산식대12: (사용유보) 13: (사용유보)99: 기타입원료 ....
		/// </summary>
		public string MoNo {get; set;}

		/// <summary>
		/// 1: 수가(상대가치점수표에 수록된 코드)2: 준용수가3: 보험등재약(“약제 급여 목록 및 급여 상한금액표”에수록된 코드)4: 원료약, 요양기관 자체 조제(제제)약8: 치료재료
		/// </summary>
		//public string CdGb {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string UnitPrice {get; set;}

		/// <summary>
		/// 약의 spec : 몇개 단위인지 표현
		/// </summary>
		//public string Spec {get; set;}

		/// <summary>
		/// 약의 단위 : 정,  mL/병 등.
		/// </summary>
		//public string DrugUnit {get; set;}

		/// <summary>
		/// 검사 확인여부 : 검사처방일 경우 의사가 확인여부
		/// </summary>
		public string ExamChkYn {get; set;}

		/// <summary>
		/// 검사 확인 일시 : 의사가 처방한 검사를 의사가 확인한 일시
		/// </summary>
		public string ExamChkDt {get; set;}

		/// <summary>
		/// 검사확인 사용자 id
		/// </summary>
		public string ExamChkUserId {get; set;}

		/// <summary>
		/// 현 Row의 사용 여부(Y/N)사용중이면 Y,  삭제되어 사용하지 않는다면 N으로 표기함.
		/// </summary>
		public string UseYn {get; set;}

		/// <summary>
		/// data 생성자
		/// </summary>
		public string InsId {get; set;}

		/// <summary>
		/// data 생성자 ip
		/// </summary>
		public string InsIp {get; set;}

		/// <summary>
		/// data 생성일시
		/// </summary>
		public string InsDt {get; set;}

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

		/// <summary>
		/// 
		/// </summary>
		//public string LineMmoTxt {get; set;}

		/// <summary>
		/// 
		/// </summary>
		//public string LineCd {get; set;}

	 }
}
