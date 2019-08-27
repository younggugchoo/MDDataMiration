namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMnRcv
	 {
		/// <summary>
		/// Prikary Key(Auto Increment)
		/// </summary>
        /// 
        [KeyAttribute]
		public int RcvId {get; set;}

        /// <summary>
        /// 환자 id
        /// </summary>
        /// 
        [KeyAttribute]
        public int PtntId {get; set;}

        /// <summary>
        /// 병원 코드
        /// </summary>
        /// 
        [KeyAttribute]
        public string HosCd {get; set;}

        /// <summary>
        /// 
        /// </summary>
        //public int DeptId {get; set;}

        public int DeptCd { get; set; }

        /// <summary>
        /// 진료 의사 id
        /// </summary>
        public string UserId {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public int OffId {get; set;}

		/// <summary>
		/// 접수일시
		/// </summary>
		public string RcvDt {get; set;}

		/// <summary>
		/// 진료구분 (진료/검진/검사/물리)
		/// </summary>
		public string DiagType {get; set;}

		/// <summary>
		/// 의약 분업 예외 코드
		/// </summary>
		public string ExpCd {get; set;}

		/// <summary>
		/// 감면 코드
		/// </summary>
		public string ReductCd {get; set;}

		/// <summary>
		/// 진료시작일시
		/// </summary>
		public string MedStartDt {get; set;}

		/// <summary>
		/// 진료종료일시-. 다음 환자를 click시에 update 실시하며 이때 진료 총시간도 같이 update 한다.
		/// </summary>
		public string MedEndDt {get; set;}

		/// <summary>
		/// 진료총시간(second로 관리함)-. 중간에 보류등이 있으므로 진료시간 update 시에는   기존 진료시간을 화면에 출력하여 새롭게 시작한 시간에서 다시계산한다.
		/// </summary>
		public int MediSec {get; set;}

		/// <summary>
		/// 수납 시간
		/// </summary>
		public string PayDt {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string FstMedGb {get; set;}

		/// <summary>
		/// 진료비 수납 여부 YN
		/// </summary>
		public string MedPayYn {get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string RcvStat {get; set;}

		/// <summary>
		/// 시스템 conversion 용도로 예전 병원에서 가지고 있던 진료번호(to-be에서는 사용하지 않음)
		/// </summary>
		public string OldRcvNo {get; set;}

		/// <summary>
		/// 사용 여부(Y/N)
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

		/// <summary>
		/// 
		/// </summary>
		public string PacsId {get; set;}

		/// <summary>
		/// 
		/// </summary>
		//public string OldRcvNo {get; set;}

		/// <summary>
		/// 보험구분 : 의료보험, 건강보험, 본인
		/// </summary>
		public string InsGb { get; set;}

		/// <summary>
		/// 
		/// </summary>
		public string OrderDt {get; set;}

	 }
}
