namespace Util.Security
{
    public class UnAuthenticatedIdentity : Identity
    {
        public UnAuthenticatedIdentity()
            : base(false, string.Empty)
        {
            
        }
    }
}