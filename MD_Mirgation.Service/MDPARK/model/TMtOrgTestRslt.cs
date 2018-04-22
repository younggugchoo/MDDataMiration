namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMtOrgTestRslt
	 {
		/// <summary>
		/// 요양기관기호 t_op_hos.hos_no
		/// </summary>
		public string Hosnum {get; set;}

		/// <summary>
		/// 검사처방일
		/// </summary>
		public string Extrdd {get; set;}

		/// <summary>
		/// 연속검사번호
		/// </summary>
		public string Contestnum {get; set;}

		/// <summary>
		/// 환자_ID
		/// </summary>
		public string Chartno {get; set;}

		/// <summary>
		/// 거래처 검사코드
		/// </summary>
		public string Examcd {get; set;}

		/// <summary>
		/// 수탁검사코드
		/// </summary>
		public string Testcd {get; set;}

		/// <summary>
		/// 수탁접수일
		/// </summary>
		public string Acptdd {get; set;}

		/// <summary>
		/// 수탁접수번호
		/// </summary>
		public string Acptno {get; set;}

		/// <summary>
		/// 결과 서술형,수치형 통합
		/// </summary>
		public string Rslt {get; set;}

		/// <summary>
		/// 결과타입 1:수치형 2:서술형
		/// </summary>
		public string Rslttype {get; set;}

		/// <summary>
		/// 판정 H,L,P,D등
		/// </summary>
		public string Judg {get; set;}

		/// <summary>
		/// 참고치
		/// </summary>
		public string Rval {get; set;}

		/// <summary>
		/// 단위
		/// </summary>
		public string Unit {get; set;}

		/// <summary>
		/// 수탁등록일 특수기호없이
		/// </summary>
		public string Regdt {get; set;}

		/// <summary>
		/// 수탁등록여부 Y:등록 NULL:미등록
		/// </summary>
		public string Regyn {get; set;}

		/// <summary>
		/// 수탁결과등록일 특수기호없이
		/// </summary>
		public string Cnfmdt {get; set;}

		/// <summary>
		/// 수탁결과등록자
		/// </summary>
		public string Cnfmstr {get; set;}

		/// <summary>
		/// 결과수신일시 특수기호없이
		/// </summary>
		public string Resultdt {get; set;}

		/// <summary>
		/// 송신일시 EMR->신원 업데이트일시
		/// </summary>
		public string Senddt {get; set;}

		/// <summary>
		/// 연동구분 10:의뢰 20:접수 30:결과입력 40:결과받기
		/// </summary>
		public string Teststatus {get; set;}

		/// <summary>
		/// 비고
		/// </summary>
		public string Rmk {get; set;}

		/// <summary>
		/// 묶음코드
		/// </summary>
		public string Slipcode {get; set;}

		/// <summary>
		/// 취소여부 Y:취소
		/// </summary>
		public string Cancelflag {get; set;}

		/// <summary>
		/// 취소일시
		/// </summary>
		public string Canceldt {get; set;}

	 }
}
