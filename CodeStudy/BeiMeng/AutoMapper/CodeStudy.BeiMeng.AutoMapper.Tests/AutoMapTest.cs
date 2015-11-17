using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeiDream.AutoMapper.Tests
{
    [TestClass]
    public class AutoMapTest
    {
        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            AutoMapperHelper.CreateMap(typeof(UserDto));
        }
        [TestMethod]
        public void TestMethod1()
        {
            User user=new User(){Id=1,Name="AA"};
            var target = user.MapTo<UserDto>();
            Assert.AreEqual("AA", target.Name);
            Console.WriteLine(target.Name);
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    [AutoMapFrom(typeof(User))]
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
