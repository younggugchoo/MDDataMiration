using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Logger
{

    public delegate void LogEventHandler(string message);

    public  class Logger
    {
       

        public static event LogEventHandler LogMessage;

        private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void INFO(string strlog)
        {
            log.Info(strlog);
        }

        public static void DEBUG(string debug, Exception ex)
        {
            log.Debug(debug);
            log.Debug(ex.Message);
            log.Debug(ex.StackTrace);
            log.Debug(ex.InnerException);
        }

        public static void DEBUG(string debug)
        {
            log.Debug(debug);

            LogMessage?.Invoke(debug);
        }

        public static void WARN(string warn)
        {
            log.Warn(warn);
        }

        public static void ERROR(string error)
        {
            log.Error(error);
        }
        public static void ERROR(string error, Exception ex)
        {
            log.Error(error);            
            log.Error(ex.Message);
            log.Error(ex.StackTrace);
            log.Error(ex.InnerException);
        }



    }
}
