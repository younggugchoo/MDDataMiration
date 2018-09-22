namespace MD_DataMigration.Service.MDPARK.model
{
	public class TAcPtnt
	 {
		/// <summary>
		/// 환자 id (Primary Key(Auto Increment))
		/// </summary>
        /// 
        [KeyAttribute]
		public int PtntId {get; set;}

        /// <summary>
        /// 병원 코드
        /// </summary>
        [KeyAttribute]
        public string HosCd {get; set;}

        /// <summary>
        /// 시스템 conversion 용도로 예전 병원에서 가지고 있던 환자번호
        /// </summary>

        [KeyAttribute]
        public string PtntCd {get; set;}

        /// <summary>
        /// 환자 이름
        /// </summary>
        /// 
        [KeyAttribute]
        public string PtntNm {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string PtntNmAls {get; set;}

		/// <summary>
		/// 주민번호 1
		/// </summary>
		public string Jumin1 {get; set;}

		/// <summary>
		/// 주민번호2
		/// </summary>
		public string Jumin2 {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string BirthDy {get; set;}

		/// <summary>
		/// 성별
		/// </summary>
		public string Sex {get; set;}

		/// <summary>
		/// 우편 번호
		/// </summary>
		public string ZipCd {get; set;}

		/// <summary>
		/// 주소1
		/// </summary>
		public string Addr1 {get; set;}

		/// <summary>
		/// 주소2
		/// </summary>
		public string Addr2 {get; set;}

		/// <summary>
		/// 휴대 전화 번호
		/// </summary>
		public string MobileNo {get; set;}

		/// <summary>
		/// 전화번호 1
		/// </summary>
		public string TelNo1 {get; set;}

		/// <summary>
		/// 전화번호 1 명칭
		/// </summary>
		public string Tel1Alias {get; set;}

		/// <summary>
		/// 전화번호 2
		/// </summary>
		public string TelNo2 {get; set;}

		/// <summary>
		/// 전화번호 2 명칭
		/// </summary>
		public string Tel2Alias {get; set;}

		/// <summary>
		/// 전화번호 3
		/// </summary>
		public string TelNo3 {get; set;}

		/// <summary>
		/// 전화번호 3 명칭
		/// </summary>
		public string Tel3Alias {get; set;}

		/// <summary>
		/// VIP 여부(Y/N)
		/// </summary>
		public string VipYn {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string VipRsn {get; set;}

		/// <summary>
		/// 임신부여부(Y/N)
		/// </summary>
		public string PregYn {get; set;}

		/// <summary>
		/// 만성질환 관리여부(Y/N)
		/// </summary>
		public string ChronicYn {get; set;}

		/// <summary>
		/// app 설치 여부(Y/N)
		/// </summary>
		public string AppInstYn {get; set;}

		/// <summary>
		/// SMS 수신여부(Y/N)
		/// </summary>
		public string SmsYn {get; set;}

		/// <summary>
		/// 개인정보 사용동의여부(Y/N)
		/// </summary>
		public string PrivInfoYn {get; set;}

		/// <summary>
		/// 메모
		/// </summary>
		public string PtntMemo {get; set;}

		/// <summary>
		/// 이메일
		/// </summary>
		public string PtntEmail {get; set;}

		/// <summary>
		/// 개인사진 등록여부(Y/N)
		/// </summary>
		public string PicRegYn {get; set;}

		/// <summary>
		/// 개인사진 등록시 연관 첨부파일 ID
		/// </summary>
		public int FileId {get; set;}

		/// <summary>
		/// ABO식 혈액형
		/// </summary>
		public string BloodAbo {get; set;}

		/// <summary>
		/// RH식 혈액형
		/// </summary>
		public string BloodRh {get; set;}

		/// <summary>
		/// 건강보험증 번호
		/// </summary>
		public string InsuNo {get; set;}

		/// <summary>
		/// 보훈등록번호
		/// </summary>
		public string PvaRegNo {get; set;}

		/// <summary>
		/// 장애등급
		/// </summary>
		public string HdpGrd {get; set;}

		/// <summary>
		/// 장애등록번호
		/// </summary>
		public string HdpRegNo {get; set;}

		/// <summary>
		/// 사용여부
		/// </summary>
		public string UseYn {get; set;}

		/// <summary>
		/// data 생성자 id
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
		/// 
		/// </summary>
		public string InsuredNm {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string RcvMmo {get; set;}

	 }
}
