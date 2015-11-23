using System.Web.Mvc;
using CodeStudy.BeiMeng.Security.Models;
using CodeStudy.BeiMeng.Security.Security.Authentication.Core;
using CodeStudy.BeiMeng.Security.Security.Authorization;

namespace CodeStudy.BeiMeng.Security.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [RoleAuthorize]
        public ActionResult Test()
        {
            return View();
        }
        [RoleAuthorize]
        public ActionResult Test2()
        {
            return View();
        }
        public ActionResult LogIn(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        public ActionResult LogInValidation(User user, string returnUrl)
        {
            if(user.Name=="admin" && user.Password==123)
                BeiDreamSignInManager.SignIn(user.Name,user.RememberMe);
            if (user.Name == "aaa" && user.Password == 123)
                BeiDreamSignInManager.SignIn(user.Name, user.RememberMe);
            return RedirectToLocal(returnUrl);
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult LogInOut()
        {
            BeiDreamSignInManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}