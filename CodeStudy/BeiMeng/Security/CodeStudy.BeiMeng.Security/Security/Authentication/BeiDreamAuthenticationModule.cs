using WebDemo.Security.Security.Authentication.Core;

namespace WebDemo.Security.Security.Authentication
{
    public class BeiDreamAuthenticationModule : AuthenticationModuleBase
    {
        protected override ApplicationSession CreateApplicationSession(string name)
        {
            ApplicationSession applicationSession=new ApplicationSession();
            applicationSession.IsAuthenticated = true;
            if (name == "admin")
                applicationSession.RoleIds = new[] {"R1", "R2"};
            if (name == "aaa")
                applicationSession.RoleIds = new[] { "R3", "R4" };
            return applicationSession;
        }
    }
}