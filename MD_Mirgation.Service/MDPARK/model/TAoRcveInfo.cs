namespace MD_DataMigration.Service.MDPARK.model
{
	public class TAoRcveInfo
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
		/// 환자ID
		/// </summary>
		public string PtntId {get; set;}

		/// <summary>
		/// 접수구분 1:진료 2:검진 3:검사 4:물리
		/// </summary>
		public string RcveGb {get; set;}

		/// <summary>
		/// 접수상태 R:일반 C:취소 B:보류
		/// </summary>
		public string RcveSt {get; set;}

		/// <summary>
		/// 내원구분 O:외래 E:응급
		/// </summary>
		public string ComeGb {get; set;}

		/// <summary>
		/// 보험구분  10:일반 21:보험 31:의료보호1종 32:의료보호2종 40:산재 50:공상 60:자보 70:외국인
		/// </summary>
		public string InsuGb {get; set;}

		/// <summary>
		/// 진료과코드
		/// </summary>
		public string MedDeptCd {get; set;}

		/// <summary>
		/// 진료의사ID
		/// </summary>
		public string MedDrId {get; set;}

		/// <summary>
		/// 접수일시
		/// </summary>
		public string RcveDt {get; set;}

		/// <summary>
		/// 대기순서
		/// </summary>
		public int WaitNo {get; set;}

		/// <summary>
		/// 유형보조코드
		/// </summary>
		public string TyCd {get; set;}

		/// <summary>
		/// 감액금액
		/// </summary>
		public int DcAmt {get; set;}

		/// <summary>
		/// 감액율
		/// </summary>
		public int DcRt {get; set;}

		/// <summary>
		/// 초재진구분 1:초진 2:재진 3:신환
		/// </summary>
		public string FstMedGb {get; set;}

		/// <summary>
		/// 진료상태 A:진료중 B:보류 C:진료완료 N:미진료
		/// </summary>
		public string MedSt {get; set;}

		/// <summary>
		/// 진료시작일시
		/// </summary>
		public string MedSdt {get; set;}

		/// <summary>
		/// 진료종료일시
		/// </summary>
		public string MedEdt {get; set;}

		/// <summary>
		/// 면제접수구분  1:처방누락 2:처방변경 3:기타
		/// </summary>
		public string ExemptGb {get; set;}

		/// <summary>
		/// 진료비수납여부
		/// </summary>
		public string RcpYn {get; set;}

		/// <summary>
		/// 수납일자
		/// </summary>
		public string RcpYmd {get; set;}

		/// <summary>
		/// 취소일시
		/// </summary>
		public string CanclDt {get; set;}

		/// <summary>
		/// 취소사유코드
		/// </summary>
		public string CanclCd {get; set;}

		/// <summary>
		/// 계산구분
		/// </summary>
		public string CalGb {get; set;}

		/// <summary>
		/// 계약기관코드
		/// </summary>
		public string CntrctCd {get; set;}

		/// <summary>
		/// 의약분업예외코드
		/// </summary>
		public string EcptCd {get; set;}

		/// <summary>
		/// 환자명
		/// </summary>
		public string PtntNm {get; set;}

		/// <summary>
		/// 영문명
		/// </summary>
		public string EngNm {get; set;}

		/// <summary>
		/// 주민등록번호1
		/// </summary>
		public string ResRegNo1 {get; set;}

		/// <summary>
		/// 주민등록번호2
		/// </summary>
		public string ResRegNo2 {get; set;}

		/// <summary>
		/// 우편번호
		/// </summary>
		public string ZipNo {get; set;}

		/// <summary>
		/// 주소
		/// </summary>
		public string Addr {get; set;}

		/// <summary>
		/// 주소상세
		/// </summary>
		public string Addr2 {get; set;}

		/// <summary>
		/// 휴대전화번호
		/// </summary>
		public string MobNo {get; set;}

		/// <summary>
		/// 개인정보동의여부
		/// </summary>
		public string IndvdlinfoAgreYn {get; set;}

		/// <summary>
		/// 만성질환관리여부
		/// </summary>
		public string ChdsesMngYn {get; set;}

		/// <summary>
		/// 임산부여부
		/// </summary>
		public string PrgncYn {get; set;}

		/// <summary>
		/// SMS수신여부
		/// </summary>
		public string SmsRcvYn {get; set;}

		/// <summary>
		/// Email
		/// </summary>
		public string Email {get; set;}

		/// <summary>
		/// 혈액형_ABO
		/// </summary>
		public string AboTy {get; set;}

		/// <summary>
		/// 혈액형_RH
		/// </summary>
		public string Rh {get; set;}

		/// <summary>
		/// VIP여부
		/// </summary>
		public string VipYn {get; set;}

		/// <summary>
		/// VIP메모
		/// </summary>
		public string VipMemo {get; set;}

		/// <summary>
		/// 알레르기메모
		/// </summary>
		public string AlrgMemo {get; set;}

		/// <summary>
		/// 메모
		/// </summary>
		public string Memo {get; set;}

		/// <summary>
		/// 특정기호
		/// </summary>
		public string SpecSymbl {get; set;}

		/// <summary>
		/// CRM메모
		/// </summary>
		public string CrmMemo {get; set;}

		/// <summary>
		/// 총진료시간
		/// </summary>
		public string TotHhmmss {get; set;}

		/// <summary>
		/// 진료결과 1:계속 2:이송 3:회송 4:사망 5:기타 9:종결
		/// </summary>
		public string MedRslt {get; set;}

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
		/// 진료실코드
		/// </summary>
		public string MedOfcCd {get; set;}

		/// <summary>
		/// 청구메모
		/// </summary>
		public string ReqMemo {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string MsgNo {get; set;}

		/// <summary>
		/// 비고
		/// </summary>
		public string Rmk {get; set;}

	 }
}
