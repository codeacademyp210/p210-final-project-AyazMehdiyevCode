using _56_Xeber.Areas.Admin.Models;
using _56_Xeber.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _56_Xeber.Controllers
{
    public class NewsController : BaseController
    {
        private XeberContext db = new XeberContext();

        // GET: News
        public ActionResult Index(int id)
        {
            News news = db.News.Find(id);
            news.Images = db.Images.Where(x => x.NewsId == id).ToList();
            news.Category = db.Categories.Where(x => x.Id == news.CategoryId).FirstOrDefault();
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