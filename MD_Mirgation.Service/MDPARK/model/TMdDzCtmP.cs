namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdDzCtmP
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int DzMpId {get; set;}

		/// <summary>
		/// 병원 코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 상병코드
		/// </summary>
		public string DzCd {get; set;}

		/// <summary>
		/// 진료과목 ( HIRA_MD_FLD )
		/// </summary>
		public string MdDpt {get; set;}

		/// <summary>
		/// 초진산정기간
		/// </summary>
		public int FstMdPrd {get; set;}

		/// <summary>
		/// 처방코드
		/// </summary>
		public string UsrDefCd {get; set;}

		/// <summary>
		/// 즐겨찾기 여부
		/// </summary>
		public string FvtYn {get; set;}

		/// <summary>
		/// 비고
		/// </summary>
		public string Remark {get; set;}

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
