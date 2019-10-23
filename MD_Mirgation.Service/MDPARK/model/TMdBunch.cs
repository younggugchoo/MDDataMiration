namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdBunch
	 {
        [Key]
        public int BunchId { get; set; }

        [Key]
        public int CateBunchId { get; set; }

        [Key]
        public string BunchNm { get; set; }

        [Key]
        public string BunchCd { get; set; }

        public string UseYn { get; set; }

        public string InsId { get; set; }

        public string InsDt { get; set; }

        public string InsIp { get; set; }

        public string UpdId { get; set; }

        public string UpdDt { get; set; }

        public string UpdIp { get; set; }

        public int BunchSeq { get; set; }

    }
}
