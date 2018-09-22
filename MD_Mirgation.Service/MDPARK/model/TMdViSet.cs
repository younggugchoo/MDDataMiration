namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdViSet
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int ViSetId {get; set;}

		/// <summary>
		/// L : 좌측 R: 우측 A:우/좌
		/// </summary>
		public string ViGb {get; set;}

		/// <summary>
		/// naved vision 나안 시력
		/// </summary>
		public string NvYn {get; set;}

		/// <summary>
		/// corrected vision
		/// </summary>
		public string CrYn {get; set;}

		/// <summary>
		/// SPH
		/// </summary>
		public string SphYn {get; set;}

		/// <summary>
		/// CYL
		/// </summary>
		public string CylYn {get; set;}

		/// <summary>
		/// AXIS
		/// </summary>
		public string AxisYn {get; set;}

		/// <summary>
		/// V/A
		/// </summary>
		public string VAYn {get; set;}

		/// <summary>
		/// ADD
		/// </summary>
		public string AddYn {get; set;}

		/// <summary>
		/// PD
		/// </summary>
		public string PdYn {get; set;}

		/// <summary>
		/// IOP
		/// </summary>
		public string IopYn {get; set;}

		/// <summary>
		/// K1
		/// </summary>
		public string K1Yn {get; set;}

		/// <summary>
		/// K2
		/// </summary>
		public string K2Yn {get; set;}

		/// <summary>
		/// PACHYMETER
		/// </summary>
		public string PahyYn {get; set;}

		/// <summary>
		/// IOL
		/// </summary>
		public string IolYn {get; set;}

		/// <summary>
		/// PAM
		/// </summary>
		public string PamYn {get; set;}

		/// <summary>
		/// TOPO
		/// </summary>
		public string TopoYn {get; set;}

		/// <summary>
		/// attr1
		/// </summary>
		public string Attr1Yn {get; set;}

		/// <summary>
		/// attr2
		/// </summary>
		public string Attr2Yn {get; set;}

		/// <summary>
		/// attr3
		/// </summary>
		public string Attr3Yn {get; set;}

		/// <summary>
		/// attr1_nm
		/// </summary>
		public string Attr1Nm {get; set;}

		/// <summary>
		/// attr2_nm
		/// </summary>
		public string Attr2Nm {get; set;}

		/// <summary>
		/// attr3_nm
		/// </summary>
		public string Attr3Nm {get; set;}

		/// <summary>
		/// 사용자 id
		/// </summary>
		public string UserId {get; set;}

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
