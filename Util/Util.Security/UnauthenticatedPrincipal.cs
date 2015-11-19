namespace Util.Security
{
    public class UnauthenticatedPrincipal : Principal
    {
        public UnauthenticatedPrincipal()
            : base(new UnauthenticatedIdentity())
        {
            
        }
    }
}