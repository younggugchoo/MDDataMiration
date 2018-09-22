namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdRxHos
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int RxHosId {get; set;}

		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 방사선 소 카테고리 id : 부위명이 입력시 소 카테고리 id와 매핑된다.
		/// </summary>
		public int RxSId {get; set;}

		/// <summary>
		/// 필름 규격 id
		/// </summary>
		public int FilmSpecId {get; set;}

		/// <summary>
		/// 처방코드
		/// </summary>
		public string McCd {get; set;}

		/// <summary>
		/// 촬영부위의 Lt/Rt checkbox
		/// </summary>
		public string PicPart1 {get; set;}

		/// <summary>
		/// Both checkbox
		/// </summary>
		public string PicPart2 {get; set;}

		/// <summary>
		/// Both(개별수가)  checkbox
		/// </summary>
		public string PicPart3 {get; set;}

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
