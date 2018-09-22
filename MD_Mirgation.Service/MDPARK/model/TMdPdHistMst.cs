namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdPdHistMst
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int PdHistId {get; set;}

		/// <summary>
		/// 접수 id
		/// </summary>
		public int RcvId {get; set;}

		/// <summary>
		/// 환자 id
		/// </summary>
		public int PtntId {get; set;}

		/// <summary>
		/// 처방전 번호
		/// </summary>
		public string PdNo {get; set;}

		/// <summary>
		/// 처방전 발행일시
		/// </summary>
		public string PdPrtDt {get; set;}

		/// <summary>
		/// 처방 추가 사항
		/// </summary>
		public string PsbRemark {get; set;}

		/// <summary>
		/// 상병기호출력여부 checkbox에 checked 여부
		/// </summary>
		public string DzCdViewYn {get; set;}

		/// <summary>
		/// 처방전 발행여부 : 단순저장시에는 N이며 처방전발행시에 Y로 처리한다.
		/// </summary>
		public string PdPrtYn {get; set;}

		/// <summary>
		/// 처방전 발행자 id
		/// </summary>
		public string UserId {get; set;}

		/// <summary>
		/// 전자처방전 여부
		/// </summary>
		public string ElecPdYn {get; set;}

		/// <summary>
		/// 처방전 사용기간
		/// </summary>
		public int PdUsgDy {get; set;}

		/// <summary>
		/// 환자보관용 출력여부
		/// </summary>
		public string PtntSaveYn {get; set;}

		/// <summary>
		/// 복용법 일괄적용여부
		/// </summary>
		public string UsgBundleYn {get; set;}

		/// <summary>
		/// 복용법 일괄적용 내용
		/// </summary>
		public string UsgBundleCtt {get; set;}

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
