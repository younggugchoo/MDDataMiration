namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdRFilmSpec
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int FilmSpecId {get; set;}

		/// <summary>
		/// 필름 회사 id
		/// </summary>
		public int FilmComId {get; set;}

		/// <summary>
		/// 규격 코드 ( R_FILM_SPEC ) 에서 default로 가져오지만 사용자가 추가할 수 있다.
		/// </summary>
		public string SpecNm {get; set;}

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
