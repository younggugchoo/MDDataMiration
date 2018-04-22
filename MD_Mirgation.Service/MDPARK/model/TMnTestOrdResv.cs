namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMnTestOrdResv
	 {
		/// <summary>
		/// 병원코드
		/// </summary>
		public string HosCd {get; set;}

		/// <summary>
		/// 예약번호
		/// </summary>
		public string ResvNo {get; set;}

		/// <summary>
		/// 예약처방일련번호
		/// </summary>
		public int ResvOrdSeq {get; set;}

		/// <summary>
		/// 처방일
		/// </summary>
		public string OrdYmd {get; set;}

		/// <summary>
		/// 진료예약일
		/// </summary>
		public string MedYmd {get; set;}

		/// <summary>
		/// 진료과
		/// </summary>
		public string MedDeptCd {get; set;}

		/// <summary>
		/// 계산구분 D:통원수술 E:응급 I:입원 O:외래
		/// </summary>
		public string CalGb {get; set;}

		/// <summary>
		/// 처방종류 grp_cd:ORDK
		/// </summary>
		public string OrdKindCd {get; set;}

		/// <summary>
		/// 처방코드
		/// </summary>
		public string OrdCd {get; set;}

		/// <summary>
		/// 처방의사ID
		/// </summary>
		public string OrdDrId {get; set;}

		/// <summary>
		/// 특기사항
		/// </summary>
		public string Rmk {get; set;}

		/// <summary>
		/// D/C여부
		/// </summary>
		public string DcYn {get; set;}

		/// <summary>
		/// D/C처방의사ID
		/// </summary>
		public string DcOrdDrId {get; set;}

		/// <summary>
		/// D/C처방일시
		/// </summary>
		public string DcOrdDt {get; set;}

		/// <summary>
		/// D/C원처방일
		/// </summary>
		public string DcOrdYmd {get; set;}

		/// <summary>
		/// D/C원처방일련번호
		/// </summary>
		public int DcOrdSeq {get; set;}

		/// <summary>
		/// 용량
		/// </summary>
		public int Qty {get; set;}

		/// <summary>
		/// 단위
		/// </summary>
		public string Unit {get; set;}

		/// <summary>
		/// 일투
		/// </summary>
		public int DayTimes {get; set;}

		/// <summary>
		/// 일수
		/// </summary>
		public int DayCnt {get; set;}

		/// <summary>
		/// 용법코드 grp_cd:DUSE
		/// </summary>
		public string UsageCd {get; set;}

		/// <summary>
		/// 예약경로 1:접수실처방 2:진료실처방
		/// </summary>
		public string ResvPath {get; set;}

		/// <summary>
		/// 예약상태 1:예약완료 2:대기 0:예약취소
		/// </summary>
		public string ResvSt {get; set;}

		/// <summary>
		/// 등록자ID
		/// </summary>
		public string InsId {get; set;}

		/// <summary>
		/// 등록일시
		/// </summary>
		public string InsDt {get; set;}

		/// <summary>
		/// 수정자ID
		/// </summary>
		public string UpdId {get; set;}

		/// <summary>
		/// 수정일시
		/// </summary>
		public string UpdDt {get; set;}

	 }
}
