namespace MD_DataMigration.Service.MDPARK.model
{
	public class TMdBunchCate
	 {
        [Key]
        public int CateBunchId { get; set; }

        [Key]
        public string UserId { get; set; }

        [Key]
        public string CateBunchNm { get; set; }

        public string UseYn { get; set; }

        public string InsId { get; set; }

        public string InsDt { get; set; }

        public string InsIp { get; set; }

        public string UpdId { get; set; }

        public string UpdDt { get; set; }

        public string UpdIp { get; set; }

        public int CateSeq { get; set; }

        public string CateGb { get; set; }

    }
}
