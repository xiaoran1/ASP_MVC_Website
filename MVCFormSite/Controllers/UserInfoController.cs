using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFormSite.Controllers
{
    public class UserInfoController : Controller
    {
        //
        // GET: /UserInfo/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult RegisterRazor()
        {
            return View();
        }

        public ActionResult ValidateRazor(FormCollection collection)
        {
            if (collection["username"] == "wscqkevin@gmail.com")
            {
                return RedirectToAction("RegisterRazor", new { registererror = "Username already been used!" });
            }
            if (collection["email"] == "wscqkevin@gmail.com")
            {
                return RedirectToAction("RegisterRazor", new { registererror = "Email address already been used!" });
            }
            return Content("register success!");
        }

        public ActionResult Validate(FormCollection collection)
        {
            if (collection["password"] != collection["rptpassword"])
            {
                return RedirectToAction("Register", new { registererror = "Please check your password!" });
            }
            if (collection["username"] == "hxr")
            {
                return RedirectToAction("Register", new { registererror = "Username already been used!" });
            }
            if (collection["email"] == "hxr@")
            {
                return RedirectToAction("Register", new { registererror = "Email address already been used!" });
            }
            return Content("register success!");
        }

    }
}
