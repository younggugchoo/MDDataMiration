using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_DataMigration.Service
{

    public delegate void LogEventHandler(string message);

    public interface IConvert
    {

        event LogEventHandler WorkingInfo;
        void StartConvert(BaseInfo baseInfo);

    }   
}
