namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdOrdMain
	 {
		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 처방일련번호
		/// </summary>
		public int OrdSeq {get; set;}

		/// <summary>
		/// 접수번호
		/// </summary>
		public int RcveNo {get; set;}

		/// <summary>
		/// 환자ID
		/// </summary>
		public string PtntId {get; set;}

		/// <summary>
		/// 진료과코드
		/// </summary>
		public string MedDeptCd {get; set;}

		/// <summary>
		/// 계산구분 D:통원수술 E:응급 I:입원 O:외래
		/// </summary>
		public string CalGb {get; set;}

		/// <summary>
		/// 처방종류 grp_cd:ORDK
		/// </summary>
		public string OrdKindCd {get; set;}

		/// <summary>
		/// 처방일
		/// </summary>
		public string OrdYmd {get; set;}

		/// <summary>
		/// 처방시간
		/// </summary>
		public string OrdHhmm {get; set;}

		/// <summary>
		/// 처방코드
		/// </summary>
		public string OrdCd {get; set;}

		/// <summary>
		/// 처방의사
		/// </summary>
		public string OrdDrId {get; set;}

		/// <summary>
		/// D/C여부
		/// </summary>
		public string DcYn {get; set;}

		/// <summary>
		/// D/C처방의사
		/// </summary>
		public string DcOrdDrId {get; set;}

		/// <summary>
		/// D/C처방일시
		/// </summary>
		public string DcOrdDt {get; set;}

		/// <summary>
		/// D/C원처방일
		/// </summary>
		public string DcOrdYmd {get; set;}

		/// <summary>
		/// D/C원처방일련번호
		/// </summary>
		public int DcOrdSeq {get; set;}

		/// <summary>
		/// 특기사항
		/// </summary>
		public string Rmk {get; set;}

		/// <summary>
		/// 메시지처방
		/// </summary>
		public string MsgOrd {get; set;}

		/// <summary>
		/// 용량
		/// </summary>
		public int Qty {get; set;}

		/// <summary>
		/// 단위
		/// </summary>
		public string Unit {get; set;}

		/// <summary>
		/// 일투
		/// </summary>
		public int DayTimes {get; set;}

		/// <summary>
		/// 일수
		/// </summary>
		public int DayCnt {get; set;}

		/// <summary>
		/// 용법코드 grp_cd:DUSE
		/// </summary>
		public string UsageCd {get; set;}

		/// <summary>
		/// 조제타입
		/// </summary>
		public string PprmdcTy {get; set;}

		/// <summary>
		/// 검체코드
		/// </summary>
		public string SmplCd {get; set;}

		/// <summary>
		/// 급여구분 1:급여 2:비급여 3:50/100급여 4:80/100급여 5:100/100급여
		/// </summary>
		public string SalGb {get; set;}

		/// <summary>
		/// 무료여부
		/// </summary>
		public string FreeYn {get; set;}

		/// <summary>
		/// 야간여부
		/// </summary>
		public string NightYn {get; set;}

		/// <summary>
		/// 처방수행부서
		/// </summary>
		public string ExecDeptCd {get; set;}

		/// <summary>
		/// 처방희망일자
		/// </summary>
		public string HopeYmd {get; set;}

		/// <summary>
		/// 처방희망시간
		/// </summary>
		public string HopeHhmm {get; set;}

		/// <summary>
		/// 수술구분 M:주수술 R:재수술 S:부수술 T:부재수술 5:50%체감 Z:기타수술
		/// </summary>
		public string OpGb {get; set;}

		/// <summary>
		/// 주사실접수여부
		/// </summary>
		public string InjRecvYn {get; set;}

		/// <summary>
		/// 처방전유효일자
		/// </summary>
		public string OrdVldYmd {get; set;}

		/// <summary>
		/// 원내처방사유코드
		/// </summary>
		public string OrdResnCd {get; set;}

		/// <summary>
		/// 원외처방교부번호
		/// </summary>
		public string IssueNo {get; set;}

		/// <summary>
		/// 진행상태
		/// </summary>
		public string ProgSt {get; set;}

		/// <summary>
		/// 수납상태
		/// </summary>
		public string RcpSt {get; set;}

		/// <summary>
		/// 수납일시
		/// </summary>
		public string RcpDt {get; set;}

		/// <summary>
		/// 보험구분
		/// </summary>
		public string InsuGb {get; set;}

		/// <summary>
		/// 유형보조
		/// </summary>
		public string TypeCd {get; set;}

		/// <summary>
		/// 실시일시
		/// </summary>
		public string ExecDt {get; set;}

		/// <summary>
		/// 판독일시
		/// </summary>
		public string ReadDt {get; set;}

		/// <summary>
		/// 조제시참고사항
		/// </summary>
		public string PprmdcComment {get; set;}

		/// <summary>
		/// 처방전사용기간
		/// </summary>
		public string UseTerm {get; set;}

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
		/// 원내원외구분 I:원내 O:원외
		/// </summary>
		public string InoutGb {get; set;}

		/// <summary>
		/// 사용분류코드
		/// </summary>
		public string UseDivCd {get; set;}

		/// <summary>
		/// 행위가산코드
		/// </summary>
		public string ActAddCd {get; set;}

		/// <summary>
		/// 코드구분
		/// </summary>
		public string CdGb {get; set;}

		/// <summary>
		/// 의원금액
		/// </summary>
		public int UnitPrice1 {get; set;}

		/// <summary>
		/// 일반가
		/// </summary>
		public int GnlPrice {get; set;}

		/// <summary>
		/// 상한가
		/// </summary>
		public int MaxPrice {get; set;}

		/// <summary>
		/// 검사예약구분
		/// </summary>
		public string TestResvGb {get; set;}

		/// <summary>
		/// 검사예약메모
		/// </summary>
		public string TestResvMemo {get; set;}

	 }
}
