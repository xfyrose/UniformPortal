using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using WebDemo.Security.Security.Authentication;
using WebDemo.Security.Security.Authentication.Core;

//启动注册
[assembly: PreApplicationStartMethod(typeof(AuthenticationModuleRegister), "Initialize")]
namespace WebDemo.Security.Security.Authentication
{
    public class AuthenticationModuleRegister
    {
        public static void Initialize()
        {
            DynamicModuleUtility.RegisterModule(typeof(BeiDreamAuthenticationModule));
        }
    }
}