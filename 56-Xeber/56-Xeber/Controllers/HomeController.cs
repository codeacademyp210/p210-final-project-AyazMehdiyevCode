using _56_Xeber.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _56_Xeber.Areas.Admin.Models;
using System.Data.Entity;

namespace _56_Xeber.Controllers
{
    public class HomeController : BaseController
    {
        private XeberContext db = new XeberContext();

        public ActionResult Index()
        {
            List<News> news = db.News.Include(x => x.Images).Include(x => x.Category).ToList();
            return View(news);
        }


        public ActionResult ChangeLang(string lang)
        {
            new LanguageM().SetLanguage(lang);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}