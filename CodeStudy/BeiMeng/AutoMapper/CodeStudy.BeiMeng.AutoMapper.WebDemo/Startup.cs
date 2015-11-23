using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeStudy.BeiMeng.AutoMapper.WebDemo.Startup))]
namespace CodeStudy.BeiMeng.AutoMapper.WebDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
