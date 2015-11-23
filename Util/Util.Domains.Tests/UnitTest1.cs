using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Domains.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Console.WriteLine("null is object: {0}", null is object);
            //Console.WriteLine("null is EntityBase: {0}", null is EntityBase);
            Console.WriteLine("(EntityBase)null == null: {0}", (EntityBase)null == null);
        }
    }
}
