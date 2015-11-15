using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeStudy.UI.EasyUI.Startup))]
namespace CodeStudy.UI.EasyUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
