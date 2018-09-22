namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdPtntColSet
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int ViewSetId {get; set;}

		/// <summary>
		/// 사용자 id
		/// </summary>
		public string UserId {get; set;}

		/// <summary>
		/// 차트번호
		/// </summary>
		public string Basic1 {get; set;}

		/// <summary>
		/// 수진자명
		/// </summary>
		public string Basic2 {get; set;}

		/// <summary>
		/// 성별
		/// </summary>
		public string Basic3 {get; set;}

		/// <summary>
		/// 주민번호
		/// </summary>
		public string Basic4 {get; set;}

		/// <summary>
		/// 피보험자
		/// </summary>
		public string Basic5 {get; set;}

		/// <summary>
		/// 보험구분
		/// </summary>
		public string Basic6 {get; set;}

		/// <summary>
		/// 외래입원
		/// </summary>
		public string Basic7 {get; set;}

		/// <summary>
		/// 내원일시
		/// </summary>
		public string Basic8 {get; set;}

		/// <summary>
		/// 담당의
		/// </summary>
		public string Basic9 {get; set;}

		/// <summary>
		/// 초_재_진
		/// </summary>
		public string Diag1 {get; set;}

		/// <summary>
		/// 주야_공휴
		/// </summary>
		public string Diag2 {get; set;}

		/// <summary>
		/// 약
		/// </summary>
		public string Diag3 {get; set;}

		/// <summary>
		/// 주사
		/// </summary>
		public string Diag4 {get; set;}

		/// <summary>
		/// 물리치료
		/// </summary>
		public string Test1 {get; set;}

		/// <summary>
		/// 공단검진
		/// </summary>
		public string Test2 {get; set;}

		/// <summary>
		/// 방사선
		/// </summary>
		public string Test3 {get; set;}

		/// <summary>
		/// 초음파
		/// </summary>
		public string Test4 {get; set;}

		/// <summary>
		/// 내시경
		/// </summary>
		public string Test5 {get; set;}

		/// <summary>
		/// 임상병리
		/// </summary>
		public string Test6 {get; set;}

		/// <summary>
		/// 처치_수술
		/// </summary>
		public string Test7 {get; set;}

		/// <summary>
		/// 총진료비
		/// </summary>
		public string Pay1 {get; set;}

		/// <summary>
		/// 청구액
		/// </summary>
		public string Pay2 {get; set;}

		/// <summary>
		/// 본인부담금
		/// </summary>
		public string Pay3 {get; set;}

		/// <summary>
		/// 비급여
		/// </summary>
		public string Pay4 {get; set;}

		/// <summary>
		/// 카드수납액
		/// </summary>
		public string Pay5 {get; set;}

		/// <summary>
		/// 현금수납액
		/// </summary>
		public string Pay6 {get; set;}

		/// <summary>
		/// 미수_환불
		/// </summary>
		public string Pay7 {get; set;}

		/// <summary>
		/// 메모
		/// </summary>
		public string Memo {get; set;}

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

	 }
}
