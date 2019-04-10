using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD_DataMigration.Service.MDPARK;

namespace MD_DataMigration.Service.BYEONGCOM
{



    public class ConvertDefaultData
    {

        
        private const string fileName = "sql-byeongcom.xml";

        public event LogEventHandler WorkingInfo;

        private MDPARKService mdParkService;
        public ConvertDefaultData(MDPARKService mDPARKService)
        {
            this.mdParkService = mDPARKService;
        }

        public void Convert()
        {

        }


    }
}
