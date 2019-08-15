using _56_Xeber.Class;
using _56_Xeber.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;


namespace _56_Xeber.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Category
        public ActionResult Index()
        {
            return RedirectToAction("LatestNews");
        }
        public ActionResult ChangeLang(string lang)
        {
            new LanguageM().SetLanguage(lang);
            return RedirectToAction("Index");
        }
        public ActionResult LatestNews()
        {
            bool langueee = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == "az"? true :false;
            ViewBag.Title = Resource.NewsLent;
            ViewBag.Category = Resource.NewsLent;
            return View("ViewByCategory");
        }
        public ActionResult Politics()
        {
            ViewBag.Title = Resource.Politics;
            ViewBag.Category = Resource.Politics;
            return View("ViewByCategory");
        }
        public ActionResult Economy()
        {
            ViewBag.Title = Resource.Economy;
            ViewBag.Category = Resource.Economy;
            return View("ViewByCategory");
        }
        public ActionResult Sport()
        {
            ViewBag.Title = Resource.Sport;
            ViewBag.Category = Resource.Sport;
            return View("ViewByCategory");
        }
        public ActionResult Culture()
        {
            ViewBag.Title = Resource.Culturee;
            ViewBag.Category = Resource.Culturee;
            return View("ViewByCategory");
        }
        public ActionResult World()
        {
            ViewBag.Title = Resource.World;
            ViewBag.Category = Resource.World;
            return View("ViewByCategory");
        }
        public ActionResult Analytics()
        {
            ViewBag.Title = Resource.Analytics;
            ViewBag.Category = Resource.Analytics;
            return View("ViewByCategory");
        }
    }
}