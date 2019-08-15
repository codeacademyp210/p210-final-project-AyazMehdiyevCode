using _56_Xeber.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _56_Xeber.Areas.Admin.Controllers
{
    [Acsess]
    public class WorkController : Controller
    {
        // GET: Admin/Work
        public ActionResult Index()
        {
                return View();
        }
        public ActionResult Exit()
        {
            Session["AdminAcsess"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}