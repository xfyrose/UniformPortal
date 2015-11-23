using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeStudy.UI.ProMvc5.Startup))]
namespace CodeStudy.UI.ProMvc5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
