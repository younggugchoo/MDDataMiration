namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdVi
	 {
		/// <summary>
		/// Primary Key(Auto Increment)
		/// </summary>
		public int ViId {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public int PtntId {get; set;}

		/// <summary>
		/// L : 좌측 R: 우측
		/// </summary>
		public string ViGb {get; set;}

		/// <summary>
		/// naved vision 나안 시력
		/// </summary>
		public string Nv {get; set;}

		/// <summary>
		/// corrected vision
		/// </summary>
		public string Cr {get; set;}

		/// <summary>
		/// SPH
		/// </summary>
		public string Sph {get; set;}

		/// <summary>
		/// CYL
		/// </summary>
		public string Cyl {get; set;}

		/// <summary>
		/// AXIS
		/// </summary>
		public string Axis {get; set;}

		/// <summary>
		/// V/A
		/// </summary>
		public string VA {get; set;}

		/// <summary>
		/// ADD
		/// </summary>
		public string Addd {get; set;}

		/// <summary>
		/// PD
		/// </summary>
		public string Pd {get; set;}

		/// <summary>
		/// IOP
		/// </summary>
		public string Iop {get; set;}

		/// <summary>
		/// K1
		/// </summary>
		public string K1 {get; set;}

		/// <summary>
		/// K2
		/// </summary>
		public string K2 {get; set;}

		/// <summary>
		/// PACHYMETER
		/// </summary>
		public string Pahy {get; set;}

		/// <summary>
		/// IOL
		/// </summary>
		public string Iol {get; set;}

		/// <summary>
		/// PAM
		/// </summary>
		public string Pam {get; set;}

		/// <summary>
		/// TOPO
		/// </summary>
		public string Topo {get; set;}

		/// <summary>
		/// attr1
		/// </summary>
		public string Attr1 {get; set;}

		/// <summary>
		/// attr2
		/// </summary>
		public string Attr2 {get; set;}

		/// <summary>
		/// attr3
		/// </summary>
		public string Attr3 {get; set;}

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
