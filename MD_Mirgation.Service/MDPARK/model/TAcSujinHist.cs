namespace MD_DataMigration.Service.MDPARK.model
{
	public class TAcSujinHist
	 {
		/// <summary>
		/// 
		/// </summary>
		public int SujinId {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public int RcvId {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 현 Row의 사용 여부(Y/N)   사용중이면 Y,  삭제되어 사용하지 않는다면 N으로 표기함.
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

		/// <summary>
		/// 수진자 주민 등록번호
		/// </summary>
		public string SujinjaJuminNo {get; set;}

		/// <summary>
		/// 수진자 성명
		/// </summary>
		public string SujinjaJuminNm {get; set;}

		/// <summary>
		/// 의료 급여 기관기호
		/// </summary>
		public string Ykiho {get; set;}

		/// <summary>
		/// 자격여부 (SAL_QLT_TYPE)  EX:지역가입자,지역세대원..
		/// </summary>
		public string QlfType {get; set;}

		/// <summary>
		/// 자격취득일
		/// </summary>
		public string QlfChwidukDt {get; set;}

		/// <summary>
		/// 세대주 성명
		/// </summary>
		public string SedaejuNm {get; set;}

		/// <summary>
		/// 보장기관기호(사업장기호)
		/// </summary>
		public string ProtAdminSym {get; set;}

		/// <summary>
		/// 시설기호(증번호)
		/// </summary>
		public string AsylmSym {get; set;}

		/// <summary>
		/// 급여제한일자(건강보험 상실일자)
		/// </summary>
		public string PayRestricDt {get; set;}

		/// <summary>
		/// 본인부담여부 ( SELF_BURDEN_TYPE ) EX M001...
		/// </summary>
		public string SbrdnType {get; set;}

		/// <summary>
		/// 건강생활유지비 잔액
		/// </summary>
		public string CfhcRem {get; set;}

		/// <summary>
		/// 선택기관기호1(관할지사코드)
		/// </summary>
		public string Ykiho1 {get; set;}

		/// <summary>
		/// 선택기관기호2
		/// </summary>
		public string Ykiho2 {get; set;}

		/// <summary>
		/// 선택기관기호3
		/// </summary>
		public string Ykiho3 {get; set;}

		/// <summary>
		/// 선택기관기호4
		/// </summary>
		public string Ykiho4 {get; set;}

		/// <summary>
		/// 선택기관 이름1(관할지사명)
		/// </summary>
		public string YoyangNm1 {get; set;}

		/// <summary>
		/// 선택기관 이름2
		/// </summary>
		public string YoyangNm2 {get; set;}

		/// <summary>
		/// 선택기관 이름3
		/// </summary>
		public string YoyangNm3 {get; set;}

		/// <summary>
		/// 선택기관 이름4
		/// </summary>
		public string YoyangNm4 {get; set;}

		/// <summary>
		/// 출국자 여부 ( LEAVE_YN ) 
		/// </summary>
		public string DprtYn {get; set;}

		/// <summary>
		/// 장애인등록일자 YYYYMMDD
		/// </summary>
		public string ObstRegDt {get; set;}

		/// <summary>
		/// 희귀난치대상자   특정기호(4)+승인일(8)+종료일(8)
		/// </summary>
		public string DisRegPrson1 {get; set;}

		/// <summary>
		/// 산정특례(희귀)등록대상자 특정기호(4)+등록번호(15)+등록 일(8)+종료일(8) +상병코드(10)+ 상병일련번호(2)
		/// </summary>
		public string DisRegPrson2 {get; set;}

		/// <summary>
		/// 차상위대상자 특정기호(4)+시작일(8)+종료일(8)+구분(1)  ;구분   '1':차상위1종 ,  '2':차상위2종
		/// </summary>
		public string DisRegPrson3 {get; set;}

		/// <summary>
		/// 산정특례(암)등록대상자1 특정기호(4)+등록번호(15)+등록일(8)+종료일(8)+상병기호(10)+상병일련번호(2)+등록구분(1)
		/// </summary>
		public string DisRegPrson4 {get; set;}

		/// <summary>
		/// 약국환자 정보(약국전용) 교부요양기관기호(8) + 처방전교부번호(13) + 상병코드(5) + 본인부담구분코드(4)
		/// </summary>
		public string ReqPatInfo {get; set;}

		/// <summary>
		/// 의료급여 산전 지원금 잔액
		/// </summary>
		public string PregRemAmt {get; set;}

		/// <summary>
		/// 산정특례(화상)등록대상자    특정기호(4)+등록번호(15)+등록일(8)+종료일(8)
		/// </summary>
		public string DisRegPrson5 {get; set;}

		/// <summary>
		/// 당뇨병 요양비 대상자 등록일
		/// </summary>
		public string DisRegPrson6 {get; set;}

		/// <summary>
		/// 동일성분 의약품 제한자   등록일(8)+종료일(8)
		/// </summary>
		public string DisRegPrson7 {get; set;}

		/// <summary>
		/// 노인틀니 대상자(상악)     등록번호(15) + 등록요양기관기호(8) + 틀니장착일(8) + 무상사후기간 종료일(8) + 시작일(8) + 종료일(8)
		/// </summary>
		public string DentTop {get; set;}

		/// <summary>
		/// 노인틀니 대상자(하악)    등록번호(15) + 등록요양기관기호(8) + 틀니장착일(8) + 무상사후기간 종료일(8) + 시작일(8) + 종료일(8)
		/// </summary>
		public string DentBottom {get; set;}

		/// <summary>
		/// 건강보험 수진자의 자격상실처리일자    
		/// </summary>
		public string SangsilProcDt {get; set;}

		/// <summary>
		/// 자가도뇨 카테타 대상자     등록일(8)
		/// </summary>
		public string DisRegPrson8 {get; set;}

		/// <summary>
		/// 급여제한 여부 (SAL_RESTRICT_GB)  무자격자, 보험료체납 급여제한자
		/// </summary>
		public string QlfRestrictCd {get; set;}

		/// <summary>
		/// 임플란트 대상자정보 1     등록번호(18)+등록요양기관기호(8)   +최종단계시술일(8)+사후점검종료일(8)+시작유효일(8)+상실유효일(8)
		/// </summary>
		public string DentImpl1 {get; set;}

		/// <summary>
		/// 임플란트 대상자정보 2     등록번호(18)+등록요양기관기호(8)+최종단계시술일(8)+사후점검종료일(8)+시작유효일(8)+상실유효일(8)
		/// </summary>
		public string DentImpl2 {get; set;}

		/// <summary>
		/// 산정특례(결핵)등록대상자     특정기호(4)+등록번호(15)+등록일(8)+종료일(8)
		/// </summary>
		public string DisRegPrson9 {get; set;}

		/// <summary>
		/// 장애여부 (DISABLED_YN ) 장애/비장애
		/// </summary>
		public string ObstYn {get; set;}

		/// <summary>
		/// 당뇨병 요양비 대상자 유형    01 : DM TYPE 1      02 : DM TYPE 2
		/// </summary>
		public string DiabetesCd {get; set;}

		/// <summary>
		/// 산정특례(극희귀)등록대상자     특정기호(4)+등록번호(15)+등록일(8)+종료일(8)+상병코드(10)+ 상병일련번호(2)
		/// </summary>
		public string DisRegPrson10 {get; set;}

		/// <summary>
		/// 산정특례(상세불명희귀)등록대상자     특정기호(4)+등록번호(15)+등록일(8)+종료일(8)+상병코드(10)+ 상병일련번호(2)
		/// </summary>
		public string DisRegPrson11 {get; set;}

		/// <summary>
		/// 조산아 및 저체중출생아 등록대상자     등록번호(10)+시작유효일자(8)+종료유효일자(8)
		/// </summary>
		public string PreInfant {get; set;}

		/// <summary>
		/// 요양기관별 산정특례(결핵)등록대상자     특정기호(4)+산정특례등록번호(10)+치료시작일자(8)+치료종료일자(8)+의사면허번호(10)+의사성명(40)+종료요양기관기호(8)
		/// </summary>
		public string DisRegPrson12 {get; set;}

		/// <summary>
		/// 산정특례(중복암)등록대상자2     특정기호(4)+등록번호(15)+등록일(8)+종료일(8)+상병기호(10)+상병일련번호(2)+등록구분(1)
		/// </summary>
		public string DisRegPrson13 {get; set;}

		/// <summary>
		/// 산정특례(중복암)등록대상자3     특정기호(4)+등록번호(15)+등록일(8)+종료일(8)+상병기호(10)+상병일련번호(2)+등록구분(1)
		/// </summary>
		public string DisRegPrson14 {get; set;}

		/// <summary>
		/// 산정특례(중복암)등록대상자4    특정기호(4)+등록번호(15)+등록일(8)+종료일(8)+상병기호(10)+상병일련번호(2)+등록구분(1)
		/// </summary>
		public string DisRegPrson15 {get; set;}

		/// <summary>
		/// 산정특례(중복암)등록대상자5    특정기호(4)+등록번호(15)+등록일(8)+종료일(8)+상병기호(10)+상병일련번호(2)+등록구분(1)
		/// </summary>
		public string DisRegPrson16 {get; set;}

		/// <summary>
		/// 산정특례(중증치매)등록대상자  특정기호(4)+상병코드(10)+상병일련번호(2)+ 등록번호(15)+시작(유효)일(8)+상실(유효)일(8)+차수시작일(8)+차수종료일(8)+연장전사전승인일수(3)+연장후사전승인일수(3)
		/// </summary>
		public string DisRegPrson17 {get; set;}

		/// <summary>
		/// 데이터 입력 일자( 년월일-시분초)    M1 의 데이터 입력 일자    :YYYYMMDD-HHmmSS
		/// </summary>
		public string Date {get; set;}

		/// <summary>
		/// 서버로부터의 메시지 Code 
		/// </summary>
		public string MessageCode {get; set;}

		/// <summary>
		/// 서버로부터의 메시지
		/// </summary>
		public string Message {get; set;}

		/// <summary>
		/// 메시지 타입(M2)
		/// </summary>
		public string MsgType {get; set;}

		/// <summary>
		/// 화면 클라이언트의 개별 고유 값
		/// </summary>
		public string ClientInfo {get; set;}

		/// <summary>
		/// 담당자주민등록번호
		/// </summary>
		public string OperatorJuminNo {get; set;}

		/// <summary>
		/// 프로그램 구분    M1 의 프로그램 구분 값     1:Broker, 2:DLL, 3:WSDL
		/// </summary>
		public string PgmType {get; set;}

		/// <summary>
		/// DLL 버전    M1의 DLL버전값
		/// </summary>
		public string Version {get; set;}

	 }
}
