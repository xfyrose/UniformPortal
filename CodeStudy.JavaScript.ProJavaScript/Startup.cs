using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Code.Study.ProJavaScript.Startup))]
namespace Code.Study.ProJavaScript
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
