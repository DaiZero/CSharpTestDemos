using MVCTestDemo.BusinessLayer;
using MVCTestDemo.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCTestDemo.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost] //只为 Post 请求开启
        public ActionResult DoLogin(UserDetailsModels u)
        {
            StudentBusinessLayer sbl = new StudentBusinessLayer();
            if (sbl.IsValidUser(u))
            {
                //创建一个认证的 Cookie
                FormsAuthentication.SetAuthCookie(u.UserName, false);
                return RedirectToAction("Index", "Student");
            }
            else
            {
                ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                return View("Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}