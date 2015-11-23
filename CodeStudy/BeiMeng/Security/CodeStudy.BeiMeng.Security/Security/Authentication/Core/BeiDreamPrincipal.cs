using System.Security.Principal;

namespace CodeStudy.BeiMeng.Security.Security.Authentication.Core
{
    /// <summary>
    /// 安全主体
    /// </summary>
    public class BeiDreamPrincipal : IPrincipal
    {
                /// <summary>
        /// 初始化安全主体
        /// </summary>
        public BeiDreamPrincipal(IIdentity identity)
        {
            Identity = identity;
        }

        /// <summary>
        /// 身份标识
        /// </summary>
        public IIdentity Identity { get; private set; }

        /// <summary>
        /// 获取身份标识
        /// </summary>
        public BeiDreamIdentity GetIdentity() {
            return Identity as BeiDreamIdentity;
        }
        public bool IsInRole(string role)
        {
            throw new System.NotImplementedException();
        }

    }
}