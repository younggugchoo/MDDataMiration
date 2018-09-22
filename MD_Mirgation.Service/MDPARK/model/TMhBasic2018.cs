namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMhBasic2018
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int HInfoId {get; set;}

		/// <summary>
		/// 건강검진 인적사항 id
		/// </summary>
		public int HPersId {get; set;}

		/// <summary>
		/// 일반검진
		/// </summary>
		public string GeneralChk {get; set;}

		/// <summary>
		/// 구강검진
		/// </summary>
		public string MouthChk {get; set;}

		/// <summary>
		/// 이상지질혈증
		/// </summary>
		public string AgeChk1 {get; set;}

		/// <summary>
		/// B형간염
		/// </summary>
		public string AgeChk2 {get; set;}

		/// <summary>
		/// C형간염
		/// </summary>
		public string AgeChk3 {get; set;}

		/// <summary>
		/// 골밀도
		/// </summary>
		public string AgeChk4 {get; set;}

		/// <summary>
		/// 인지기능장애
		/// </summary>
		public string AgeChk5 {get; set;}

		/// <summary>
		/// 정신건강검사
		/// </summary>
		public string AgeChk6 {get; set;}

		/// <summary>
		/// 생활습관평가
		/// </summary>
		public string AgeChk7 {get; set;}

		/// <summary>
		/// 노인신체기능
		/// </summary>
		public string AgeChk8 {get; set;}

		/// <summary>
		/// 치면세균막
		/// </summary>
		public string AgeChk9 {get; set;}

		/// <summary>
		/// 위암 대상
		/// </summary>
		public string CancerGb1 {get; set;}

		/// <summary>
		/// 위암 치료비지원
		/// </summary>
		public string CancerGb2 {get; set;}

		/// <summary>
		/// 대장암 대상
		/// </summary>
		public string CancerGb3 {get; set;}

		/// <summary>
		/// 대장임 치료비지원
		/// </summary>
		public string CancerGb4 {get; set;}

		/// <summary>
		/// 유방암 대상
		/// </summary>
		public string CancerGb5 {get; set;}

		/// <summary>
		/// 유방암 치료비지원
		/// </summary>
		public string CancerGb6 {get; set;}

		/// <summary>
		/// 간암상반기 대상
		/// </summary>
		public string CancerGb7 {get; set;}

		/// <summary>
		/// 간암상반기 치료비지원
		/// </summary>
		public string CancerGb8 {get; set;}

		/// <summary>
		/// 간암 하반기 대상
		/// </summary>
		public string CancerGb9 {get; set;}

		/// <summary>
		/// 간암 하반기 치료비지원
		/// </summary>
		public string CancerGb10 {get; set;}

		/// <summary>
		/// 자궁경부암 대상
		/// </summary>
		public string CancerGb11 {get; set;}

		/// <summary>
		/// 자궁경부암 치료비지원
		/// </summary>
		public string CancerGb12 {get; set;}

		/// <summary>
		/// 일반검진 검진일자
		/// </summary>
		public string ChkDy1 {get; set;}

		/// <summary>
		/// 구강검사 검진일자
		/// </summary>
		public string ChkDy2 {get; set;}

		/// <summary>
		/// 위암 검진일자
		/// </summary>
		public string ChkDy3 {get; set;}

		/// <summary>
		/// 대장암 검진일자
		/// </summary>
		public string ChkDy4 {get; set;}

		/// <summary>
		/// 간암 상반기
		/// </summary>
		public string ChkDy5 {get; set;}

		/// <summary>
		/// 간암 하반기 검진일자
		/// </summary>
		public string ChkDy6 {get; set;}

		/// <summary>
		/// 유방암 검진일자
		/// </summary>
		public string ChkDy7 {get; set;}

		/// <summary>
		/// 자궁 경부암 검진일자
		/// </summary>
		public string ChkDy8 {get; set;}

		/// <summary>
		/// 일반검진 출장검진
		/// </summary>
		public string ChkYn1 {get; set;}

		/// <summary>
		/// 구강검사 출장검진여부
		/// </summary>
		public string ChkYn2 {get; set;}

		/// <summary>
		/// 위암 출장검진여부
		/// </summary>
		public string ChkYn3 {get; set;}

		/// <summary>
		/// 대장암 출장검진 여부
		/// </summary>
		public string ChkYn4 {get; set;}

		/// <summary>
		/// 간암 상반기 출장검진 여부
		/// </summary>
		public string ChkYn5 {get; set;}

		/// <summary>
		/// 간암 하반기 출장검진 여부
		/// </summary>
		public string ChkYn6 {get; set;}

		/// <summary>
		/// 유방암 출장검진 여부
		/// </summary>
		public string ChkYn7 {get; set;}

		/// <summary>
		/// 자궁경부암 출장검진 여부
		/// </summary>
		public string ChkYn8 {get; set;}

		/// <summary>
		/// 현 Row의 사용 여부(Y/N)사용중이면 Y,  삭제되어 사용하지 않는다면 N으로 표기함.
		/// </summary>
		public string UseYn {get; set;}

		/// <summary>
		/// data 생성자 id
		/// </summary>
		public string InsId {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string InsDt {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string InsIp {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string UpdId {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string UpdDt {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string UpdIp {get; set;}

	 }
}
