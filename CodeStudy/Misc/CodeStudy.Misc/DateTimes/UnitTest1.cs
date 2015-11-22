using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeStudy.Misc.DateTimes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_TimeSpan()
        {
            DateTime dt1 = new DateTime(2015, 9, 22, 10, 10, 10);
            DateTime dt2 = new DateTime(2015, 9, 20, 9, 0, 0);

            TimeSpan ts1 = dt1.Subtract(dt2);
            TimeSpan ts2 = dt2.Subtract(dt1);

            Console.WriteLine(ts1.ToString());
            Console.WriteLine(ts2.ToString());

            Console.WriteLine(ts1.Days);
            Console.WriteLine(ts1.TotalDays);
        }

        [TestMethod]
        public void TestMethod_ToString()
        {
            Console.WriteLine("DateTime.Now.ToString(): {0}", DateTime.Now.ToString());
        }
    }
}
