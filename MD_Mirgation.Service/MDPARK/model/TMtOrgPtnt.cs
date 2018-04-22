namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMtOrgPtnt
	 {
		/// <summary>
		/// 요양기관기호 t_op_hos.hos_no
		/// </summary>
		public string Hosnum {get; set;}

		/// <summary>
		/// 검사처방일
		/// </summary>
		public string Extrdd {get; set;}

		/// <summary>
		/// 연속검사번호 동일환자가 같은 날 검사를 중복처방한 경우 사용
		/// </summary>
		public string Contestnum {get; set;}

		/// <summary>
		/// 환자_ID
		/// </summary>
		public string Chartno {get; set;}

		/// <summary>
		/// 환자명
		/// </summary>
		public string Nm {get; set;}

		/// <summary>
		/// 생년월일성별 -제외(성별까지만 연동)
		/// </summary>
		public string Rgstno {get; set;}

		/// <summary>
		/// 나이
		/// </summary>
		public string Age {get; set;}

		/// <summary>
		/// 성별
		/// </summary>
		public string Sex {get; set;}

		/// <summary>
		/// 진료과명
		/// </summary>
		public string Dept {get; set;}

		/// <summary>
		/// 의사명
		/// </summary>
		public string Docter {get; set;}

		/// <summary>
		/// 병동
		/// </summary>
		public string Bed {get; set;}

	 }
}
