using MD_DataMigration.Service.MDPARK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_DataMigration.Service.BYEONGCOM
{

    
    public class ConvertAdditionalData
    {
        private const string TARGET_DB = "MariaDbMDPark";
        private const string fileName = "sql-byeongcom.xml";

        public event LogEventHandler WorkingInfo;

        private MDPARKService mdParkService;
        public ConvertAdditionalData(MDPARKService mDPARKService)
        {
            this.mdParkService = mDPARKService;
        }

        public void Convert()
        {

        }

    }
}
