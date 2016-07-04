using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFormSite.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Validate(FormCollection collection)
        {
            if (collection["username"] != "hxr")
            {
                return RedirectToAction("Index", new { loginerror = "Wrong user name or password" });
            }
            return Content("loginsuccess");
        }
    }
}
