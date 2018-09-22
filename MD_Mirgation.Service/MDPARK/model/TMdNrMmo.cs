namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdNrMmo
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int NrMmoId {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public int RcvId {get; set;}

		/// <summary>
		/// 처방코드
		/// </summary>
		public string PsbCd {get; set;}

		/// <summary>
		/// 처방명
		/// </summary>
		public string PsbNm {get; set;}

		/// <summary>
		/// 심평원 약가 혹은 수가 어느쪽에서 가져오는지 구분함.(M:수가,  D;약가   Z:재료) 
		/// </summary>
		public string PsbGb {get; set;}

		/// <summary>
		/// 처방 그룹 : 과거차트에서 그룹별로 보여주는 용도로 사용함.( 주사:I, 검사:C, 내복:M) 
		/// </summary>
		public string ViewGr {get; set;}

		/// <summary>
		/// 단가
		/// </summary>
		public string UnitPrice {get; set;}

		/// <summary>
		/// 용량
		/// </summary>
		public string Dose {get; set;}

		/// <summary>
		/// 일일 투여횟수 
		/// </summary>
		public string DayCnt {get; set;}

		/// <summary>
		/// 투여일수
		/// </summary>
		public string Duration {get; set;}

		/// <summary>
		/// 원내 원외 구분 (IN_OUT_GB )
		/// </summary>
		public string InOutGb {get; set;}

		/// <summary>
		/// 급여구분 ( SAL_GB )
		/// </summary>
		public string SalGb {get; set;}

		/// <summary>
		/// 항번호  01: 진찰료 02: 입원료 03: 투약료 04: 주사료
		/// </summary>
		public string HangNo {get; set;}

		/// <summary>
		/// 18개 항의 소분류 단위로 부여된 번호 기재
		/// </summary>
		public string MoNo {get; set;}

		/// <summary>
		/// 1: 수가(상대가치점수표에 수록된 코드) : 사용안할 것 같음
		/// </summary>
		public string CdGb {get; set;}

		/// <summary>
		/// 약의 spec : 몇개 단위인지 표현 
		/// </summary>
		public string DrgSpec {get; set;}

		/// <summary>
		///  약의 단위 : 정,  mL/병 등. 
		/// </summary>
		public string DrugUnit {get; set;}

		/// <summary>
		/// 현 Row의 사용 여부(Y/N)사용중이면 Y,  삭제되어 사용하지 않는다면 N으로 표기함.
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

	 }
}
