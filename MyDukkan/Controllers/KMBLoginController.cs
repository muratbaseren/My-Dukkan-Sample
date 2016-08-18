using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDukkan.Controllers
{
    public class KMBLoginController : Controller
    {
        [HttpPost]
        public ActionResult SignIn(string login_username, string login_password, bool login_rememberme)
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string register_username, string register_email, string register_password)
        {
            return View();
        }

        [HttpPost]
        public ActionResult LostPassword(string lost_email)
        {
            return View();
        }

        public ActionResult SignOut()
        {
            return View();
        }

        public ActionResult UserProfile()
        {
            return View();
        }
    }
}