using System.Security.Principal;

namespace Util.Security
{
    public class Principal : IPrincipal
    {

        public Principal(Identity identity)
        {
            Identity = identity;
        }

        public Principal()
            : this(new UnauthenticatedIdentity())
        {
            
        }

        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            throw new System.NotImplementedException();
        }

        public static UnauthenticatedPrincipal Unauthenticated()
        {
            return new UnauthenticatedPrincipal();
        }
    }
}