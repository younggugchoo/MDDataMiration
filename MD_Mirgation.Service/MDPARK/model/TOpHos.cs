namespace MD_DataMigration.Service.MDPARK.model
{
	public class TOpHos
	 {
		/// <summary>
		/// 병원코드
		/// </summary>
		public string COMCD {get; set;}

		/// <summary>
		/// 사업자등록번호
		/// </summary>
		public string ENTREGNO {get; set;}

		/// <summary>
		/// 회사대표명칭
		/// </summary>
		public string COMNM {get; set;}

		/// <summary>
		/// 기타명칭
		/// </summary>
		public string ETCNM {get; set;}

		/// <summary>
		/// 영문명칭
		/// </summary>
		public string ENGNM {get; set;}

		/// <summary>
		/// 사용여부(0,1)
		/// </summary>
		public string USEYN {get; set;}

		/// <summary>
		/// 대표자성명(한글)
		/// </summary>
		public string BOSSKORNM {get; set;}

		/// <summary>
		/// 대표자성명(영문)
		/// </summary>
		public string BOSSENGNM {get; set;}

		/// <summary>
		/// 법인등록번호
		/// </summary>
		public string CORPREGNO {get; set;}

		/// <summary>
		/// 업태
		/// </summary>
		public string BUSISTATUS {get; set;}

		/// <summary>
		/// 종목
		/// </summary>
		public string BUSITYPE {get; set;}

		/// <summary>
		/// 사업장구분(BA01)
		/// </summary>
		public string CORPTYPE {get; set;}

		/// <summary>
		/// 요양기관번호
		/// </summary>
		public string HOSNO {get; set;}

		/// <summary>
		/// 우편번호
		/// </summary>
		public string ZIPNO {get; set;}

		/// <summary>
		/// 사업장주소
		/// </summary>
		public string ADDR {get; set;}

		/// <summary>
		/// 대표전화번호
		/// </summary>
		public string TELNO {get; set;}

		/// <summary>
		/// 건강보험 사업장 번호
		/// </summary>
		public string MEDINSURENO {get; set;}

		/// <summary>
		/// 국민연금 사업장 번호
		/// </summary>
		public string NTLPENSIONNO {get; set;}

		/// <summary>
		/// 인사담당자 성명
		/// </summary>
		public string HRMGRNM {get; set;}

		/// <summary>
		/// 인사담당자 연락처
		/// </summary>
		public string HRMGRTELNO {get; set;}

		/// <summary>
		/// 회계일자(From)
		/// </summary>
		public string ACNTFYMD {get; set;}

		/// <summary>
		/// 회계일자(To)
		/// </summary>
		public string ACNTTYMD {get; set;}

		/// <summary>
		/// 연차산정기준(0: 입사일자 기준,  1: 회계년도 기준)
		/// </summary>
		public string YLTYPE {get; set;}

		/// <summary>
		/// 급여이체은행코드1
		/// </summary>
		public string BANKCD1 {get; set;}

		/// <summary>
		/// 급여이체은행 이메일주소1
		/// </summary>
		public string BANKEMAIL1 {get; set;}

		/// <summary>
		/// 병원이메일 주소
		/// </summary>
		public string HOSEMAIL {get; set;}

		/// <summary>
		/// 접속 URL
		/// </summary>
		public string URL {get; set;}

		/// <summary>
		/// 비고
		/// </summary>
		public string ETCITEM {get; set;}

		/// <summary>
		/// 접속IP대역(From)
		/// </summary>
		public string FROMIP {get; set;}

		/// <summary>
		/// 접속IP대역(To)
		/// </summary>
		public string TOIP {get; set;}

		/// <summary>
		/// 출현순서
		/// </summary>
		public int DISPORDER {get; set;}

		/// <summary>
		/// X좌표
		/// </summary>
		public string XCNTS {get; set;}

		/// <summary>
		/// Y좌표
		/// </summary>
		public string YCNTS {get; set;}

		/// <summary>
		/// 오시는길 - 대중교통
		/// </summary>
		public string PBTRNSP {get; set;}

		/// <summary>
		/// 오시는길 - 자가용
		/// </summary>
		public string PVTCAR {get; set;}

		/// <summary>
		/// 팩스번호
		/// </summary>
		public string FAXNO {get; set;}

		/// <summary>
		/// 입원실여부
		/// </summary>
		public string WardYn {get; set;}

	 }
}
