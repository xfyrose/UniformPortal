using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeStudy.Misc.Atrributes
{
    [TestClass]
    public class UnitTestAttribute
    {
        [TestMethod]
        public void TestMethod_Attribute()
        {
            CustomizeORM customizeOrm = new CustomizeORM();
            User user = new User() { UserId = 1, UserName = "Wilber", Age = 28 };
            customizeOrm.Insert(user);
        }
    }
}
