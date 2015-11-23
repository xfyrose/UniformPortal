using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeiDream.AutoMapper;
using BeiDream.AutoMapper.Reflection;

namespace BeiDream.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoMapperBootstrapper autoMapperBootstrapper=new AutoMapperBootstrapper();
            autoMapperBootstrapper.Initialize();

            User user = new User() { Id = 1, Name = "AA", UserName2 = "UserName-02" };
            var target = user.MapTo<UserDto>();
            Console.WriteLine(target.Name);
            Console.ReadKey();
        }
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName2 { get; set; }
    }
    [AutoMapFrom(typeof(User))]
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserDtoName2 { get; set; }
    }
}
