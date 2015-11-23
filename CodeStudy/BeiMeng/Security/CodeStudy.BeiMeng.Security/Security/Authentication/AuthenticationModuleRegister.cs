using System.Web;
using CodeStudy.BeiMeng.Security.Security.Authentication;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

//启动注册
[assembly: PreApplicationStartMethod(typeof(AuthenticationModuleRegister), "Initialize")]
namespace CodeStudy.BeiMeng.Security.Security.Authentication
{
    public class AuthenticationModuleRegister
    {
        public static void Initialize()
        {
            DynamicModuleUtility.RegisterModule(typeof(BeiDreamAuthenticationModule));
        }
    }
}