namespace Util.Security
{
    public class UnAuthenticatedPrincipal : Principal
    {
        public UnAuthenticatedPrincipal()
            : base(new UnAuthenticatedIdentity())
        {
            
        }
    }
}