namespace Util.Security
{
    public class UnauthenticatedIdentity : Identity
    {
        public UnauthenticatedIdentity()
            : base(false, string.Empty)
        {
            
        }
    }
}