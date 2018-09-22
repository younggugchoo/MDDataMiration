namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdSxDtl
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int SxId {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public int SxCatId {get; set;}

		/// <summary>
		/// 증상내용
		/// </summary>
		public string SxCnt {get; set;}

		/// <summary>
		/// 가장셈
		/// </summary>
		public string Fst {get; set;}

		/// <summary>
		/// 중간
		/// </summary>
		public string Snd {get; set;}

		/// <summary>
		/// 약함
		/// </summary>
		public string Trd {get; set;}

		/// <summary>
		/// 아주약함
		/// </summary>
		public string Fth {get; set;}

		/// <summary>
		/// 현 Row의 사용 여부(Y/N)사용중이면 Y,  삭제되어 사용하지 않는다면 N으로 표기함.
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

	 }
}
