namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMtTestMst
	 {
		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 검사코드
		/// </summary>
		public string TestCd {get; set;}

		/// <summary>
		/// 적용시작일
		/// </summary>
		public string FrYmd {get; set;}

		/// <summary>
		/// 성별
		/// </summary>
		public string Sex {get; set;}

		/// <summary>
		/// 시작나이
		/// </summary>
		public string Sage {get; set;}

		/// <summary>
		/// 종료나이
		/// </summary>
		public string Eage {get; set;}

		/// <summary>
		/// 요양기관기호
		/// </summary>
		public string Hosnum {get; set;}

		/// <summary>
		/// 처방코드
		/// </summary>
		public string OrdCd {get; set;}

		/// <summary>
		/// 적용종료일
		/// </summary>
		public string ToYmd {get; set;}

		/// <summary>
		/// 검사명_화면표시용
		/// </summary>
		public string TestNmDisp {get; set;}

		/// <summary>
		/// 검사명_바코드출력용
		/// </summary>
		public string TestNmBrcdPrnt {get; set;}

		/// <summary>
		/// 검사시행장소코드
		/// </summary>
		public string TestEnfPlaceCd {get; set;}

		/// <summary>
		/// 검사자동액팅여부
		/// </summary>
		public string TestAaYn {get; set;}

		/// <summary>
		/// 장비코드
		/// </summary>
		public string EqCd {get; set;}

		/// <summary>
		/// 참고치상한
		/// </summary>
		public string RefHval {get; set;}

		/// <summary>
		/// 상한부등호 1:>= 2:>
		/// </summary>
		public string Usign {get; set;}

		/// <summary>
		/// 참고치하한
		/// </summary>
		public string RefLval {get; set;}

		/// <summary>
		/// 하한부등호 1:<= 2:<
		/// </summary>
		public string Lsign {get; set;}

		/// <summary>
		/// 소수자릿수
		/// </summary>
		public string DecDgt {get; set;}

		/// <summary>
		/// 반올림구분 H:올림 L:버림 U:반올림
		/// </summary>
		public string RoundGb {get; set;}

		/// <summary>
		/// 정성정량구분 1:정성-수치 2:정성-판정 3:정량-수치(판정) 4:정량-판정(수치)
		/// </summary>
		public string DevQtyGb {get; set;}

		/// <summary>
		/// 판정구분 1:L/H 2:H/L 3:LOW/HIGH 4:HIGH/LOW 5:NEG/POS 6:POS/NEG 7:NEGATIVE/POSITIVE 8:POSITIVE/NEGATIVE 9:3+/3-(TRACE:±) 10:+++/---(TRACE:+-)
		/// </summary>
		public string JudgGb {get; set;}

		/// <summary>
		/// 사용자지정_상한
		/// </summary>
		public string UsrDefHval {get; set;}

		/// <summary>
		/// 사용자지정_하한
		/// </summary>
		public string UsrDefLval {get; set;}

		/// <summary>
		/// TAT체크여부
		/// </summary>
		public string TatChkYn {get; set;}

		/// <summary>
		/// 바코드출력여부
		/// </summary>
		public string BrcdPrntYn {get; set;}

		/// <summary>
		/// 검사정보
		/// </summary>
		public string TestInfo {get; set;}

		/// <summary>
		/// 재검기준
		/// </summary>
		public string ReTestStdr {get; set;}

		/// <summary>
		/// Comment
		/// </summary>
		public string Comment {get; set;}

		/// <summary>
		/// 통계여부
		/// </summary>
		public string StatYn {get; set;}

		/// <summary>
		/// 변경사유
		/// </summary>
		public string ChgRsen {get; set;}

		/// <summary>
		/// 정렬순서
		/// </summary>
		public int SortOrd {get; set;}

		/// <summary>
		/// 사용여부
		/// </summary>
		public string UseYn {get; set;}

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
