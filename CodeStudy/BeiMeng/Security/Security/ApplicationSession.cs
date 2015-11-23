using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using WebDemo.Security.Security.Authentication.Core;

namespace WebDemo.Security.Security
{
    public class ApplicationSession
    {
        /// <summary>
        /// 是否认证(登录)
        /// </summary>
        public bool IsAuthenticated { get; set; }
        /// <summary>
        /// 角色编号列表
        /// </summary>
        public string[] RoleIds { get; set; }

        /// <summary>
        /// 当前用户安全主体
        /// </summary>
        public static BeiDreamPrincipal User
        {
            get
            {
                IPrincipal principal = HttpContext.Current == null ? System.Threading.Thread.CurrentPrincipal : HttpContext.Current.User;
                return principal as BeiDreamPrincipal ?? new BeiDreamPrincipal(new BeiDreamIdentity());
            }
            set
            {
                if (HttpContext.Current == null)
                {
                    System.Threading.Thread.CurrentPrincipal = value;
                    return;
                }
                HttpContext.Current.User = value;
            }
        }
        /// <summary>
        /// 当前用户身份标识
        /// </summary>
        public static BeiDreamIdentity Identity
        {
            get { return User.Identity as BeiDreamIdentity; }
        }
        /// <summary>
        /// 获取当前应用程序上下文
        /// </summary>
        public static ApplicationSession Current
        {
            get { return Identity.ApplicationSession; }
        }
    }
}