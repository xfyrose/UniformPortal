using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeiDream.WebDemo.Startup))]
namespace BeiDream.WebDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
