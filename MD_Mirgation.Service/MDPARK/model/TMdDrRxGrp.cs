namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdDrRxGrp
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int RxGrpId {get; set;}

		/// <summary>
		/// 조회 카테고리 코드( INQ_CATE ) : 처방그룹의 상위 카테고리임.
		/// </summary>
		public string InqCate {get; set;}

		/// <summary>
		/// 처방명
		/// </summary>
		public string RxGrpNm {get; set;}

		/// <summary>
		/// 사용자 id (Login 의사 id)
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 조회 순서
		/// </summary>
		public int Seq {get; set;}

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
