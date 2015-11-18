using System;

namespace CodeStudy.Misc.Log4Nets
{
    public class Log4Helper
    {
        public static readonly log4net.ILog Loginfo = log4net.LogManager.GetLogger("Loginfo");
        public static readonly log4net.ILog Logerror = log4net.LogManager.GetLogger("Logerror");

        public static void WriteLog(string info)
        {
            if (Loginfo.IsInfoEnabled)
            {
                Loginfo.Info(info);
            }
        }

        public static void WriteLog(string info, Exception ex)
        {
            if (Logerror.IsErrorEnabled)
            {
                Logerror.Error(info, ex);
            }
        }
    }
}
