using System.Security.Principal;

namespace CodeStudy.BeiMeng.Security.Security.Authentication.Core
{
    public class BeiDreamIdentity : IIdentity
    {
        /// <summary>
        /// 认证类型
        /// </summary>
        public string AuthenticationType { get; set; }

        /// <summary>
        /// 是否认证(登录)
        /// </summary>
        public bool IsAuthenticated { get;  set; }

        /// <summary>
        /// 用户标识
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 当前会话Session
        /// </summary>
        public ApplicationSession ApplicationSession { get; set; }
    }
}