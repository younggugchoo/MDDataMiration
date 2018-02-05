using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Logger
{
    public static class Logger
    {
        private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void INFO()
        {
            log.Info("dfafdf");
        }

        public static void INFO(string strlog)
        {
            log.Info(strlog);
        }
    }
}
