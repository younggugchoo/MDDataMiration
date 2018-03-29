using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_DataMigration.Service
{

    public delegate void LogEventHandler(  CommonStatic.WORK_RESULT workResult ,  string message);

    public interface IConvert
    {

        event LogEventHandler WorkingInfo;
        event EventHandler Convert_Completed;

        void StartConvert(BaseInfo baseInfo);
        

    }   
}
