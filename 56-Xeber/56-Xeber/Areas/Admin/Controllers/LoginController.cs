using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using _56_Xeber.Areas.Admin.Models;
using System.Threading;

namespace _56_Xeber.Areas.Admin.Controllers
{
    public class LoginController : LanguageForAdminController
    {
        private readonly XeberContext db;

        public LoginController()
        {
            db = new XeberContext();
        }

        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["AdminAcsess"] != null && (bool)Session["AdminAcsess"] == true)
            {
                return RedirectToAction("Index", "CRUD");
            }
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(User user)
        {
            bool AdminAcsess = false;

            if (string.IsNullOrEmpty(user.Login) || string.IsNullOrEmpty(user.Password))
            {
                return View("Index", user);
            }

            User dbuser = db.Users.FirstOrDefault(x => x.Login == user.Login);

            if (dbuser != null)
            {
                AdminAcsess = Crypto.VerifyHashedPassword(dbuser.Password, user.Password);

                if (AdminAcsess)
                {
                    Session["AdminAcsess"] = true;
                    return RedirectToAction("Index","CRUD");
                }
            }
                return View("Index", user);
        }

        //public ActionResult GeneratePass()
        //{
        //    string pass = "lisbeth";
        //    string genpass = Crypto.HashPassword(pass);

        //    return Content(genpass);
        //}
    }
}