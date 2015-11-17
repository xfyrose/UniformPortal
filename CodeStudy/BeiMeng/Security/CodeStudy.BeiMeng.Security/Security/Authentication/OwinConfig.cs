﻿using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using WebDemo.Security.Security.Authentication;

//注册
[assembly: OwinStartup( typeof( OwinConfig ) )]

namespace WebDemo.Security.Security.Authentication {
    /// <summary>
    /// Owin配置
    /// </summary>
    public class OwinConfig {
        /// <summary>
        /// 配置
        /// </summary>
        public void Configuration( IAppBuilder app ) {
            //使用cookie存储安全信息
            app.UseCookieAuthentication( new CookieAuthenticationOptions {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/LogIn")
            } );
        }
    }
}
