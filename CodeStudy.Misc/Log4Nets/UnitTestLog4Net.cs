using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeStudy.Misc.Log4Nets
{
    [TestClass]
    public class UnitTestLog4Net
    {
        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);

            log4net.ILog log = log4net.LogManager.GetLogger(typeof(UnitTestLog4Net));
            if (log.IsDebugEnabled)
            {
                log.Debug("hello");
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            Log4Helper.WriteLog(string.Format("当前的时间{0}", DateTime.Now));
        }

        [TestMethod]
        public void TestMethod3()
        {
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(UnitTestLog4Net));

            log4net.Config.BasicConfigurator.Configure();
            log.Info("Start");
            log.Info("Stop");

            log4net.Config.XmlConfigurator.Configure(new FileInfo("log4net.config"));
            log.Info("Start02");
            log.Info("Stop02");
        }
    }
}
