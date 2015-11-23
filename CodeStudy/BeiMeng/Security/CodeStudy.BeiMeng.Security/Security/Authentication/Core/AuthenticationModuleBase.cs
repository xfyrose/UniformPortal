using System.Security.Principal;
using System.Web;
using Microsoft.AspNet.Identity;

namespace CodeStudy.BeiMeng.Security.Security.Authentication.Core
{
    /// <summary>
    /// 身份验证模块
    /// </summary>
    public abstract class AuthenticationModuleBase : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.PostAuthenticateRequest += Authenticate;
        }
        /// <summary>
        /// 身份验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Authenticate(object sender, System.EventArgs e)
        {
            var application = sender as HttpApplication;
            if (application == null)
                return;
            if (IsResource(application))
                return;
            if (!IsAuthenticated(application))
            {
                HttpContext.Current.User = new BeiDreamPrincipal(new BeiDreamIdentity()); //UnauthenticatedPrincipal.Instance;
                return;
            }
            HttpContext.Current.User = GetPrincipal(application);
        }
        /// <summary>
        /// 是否静态资源
        /// </summary>
        private bool IsResource(HttpApplication application)
        {
            string extension = application.Request.CurrentExecutionFilePathExtension;
            if (extension == null)
                return false;
            switch (extension.ToLower())
            {
                case ".js":
                    return true;
                case ".css":
                    return true;
                case ".png":
                    return true;
                case ".gif":
                    return true;
                case ".jpg":
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 是否登录
        /// </summary>
        private bool IsAuthenticated(HttpApplication application)
        {
            if (application.User == null)
                return false;
            if (!application.User.Identity.IsAuthenticated)
                return false;
            return true;
        }

        /// <summary>
        /// 获取安全主体
        /// </summary>
        private IPrincipal GetPrincipal(HttpApplication application)
        {
            var identity = application.User.Identity;
            //return new Principal(new Identity(true, userId, CreateApplicationContext(userId)));
            BeiDreamIdentity beiDreamIdentity = new BeiDreamIdentity();
            beiDreamIdentity.AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie;
            beiDreamIdentity.IsAuthenticated = true;
            beiDreamIdentity.Name = identity.Name;
            beiDreamIdentity.ApplicationSession = CreateApplicationSession(identity.Name);
            return new BeiDreamPrincipal(beiDreamIdentity);
        }
        /// <summary>
        /// 创建应用程序Session(替代传统session方案)
        /// </summary>
        /// <param name="name">用户</param>
        protected abstract ApplicationSession CreateApplicationSession(string name);
        public void Dispose()
        {
        }
    }
}