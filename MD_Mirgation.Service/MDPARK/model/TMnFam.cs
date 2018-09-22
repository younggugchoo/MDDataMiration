namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMnFam
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int FamRldtId {get; set;}

		/// <summary>
		/// 환자 id
		/// </summary>
		public int PtntId {get; set;}

		/// <summary>
		/// 가족의 환자 id
		/// </summary>
		public int FamPtntId {get; set;}

		/// <summary>
		/// 가족 관계(부/모/자/녀/..)
		/// </summary>
		public string Relation {get; set;}

		/// <summary>
		/// 비고
		/// </summary>
		public string FamRemark {get; set;}

		/// <summary>
		/// 사용 여부(Y/N)
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
		/// data  생성자 ip
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
