using System.Security.Principal;
using System.Threading;
using System.Web;

namespace Util.Security
{
    public  class SecurityContext
    {
        public static Principal User
        {
            get
            {
                IPrincipal currentPrincipal = HttpContext.Current == null ? Thread.CurrentPrincipal : HttpContext.Current.User;
                Principal result = currentPrincipal as Principal;

                return result ?? Principal.Unauthenticated();
            }

            set
            {
                if (HttpContext.Current == null)
                {
                    Thread.CurrentPrincipal = value;
                }
                else
                {
                    HttpContext.Current.User = value;
                }
            }
        }

        public static Identity Identity
        {
            get
            {
                Identity result = User.Identity as Identity;

                return result ?? Identity.Unauthenticated();
            }
        }
    }
}