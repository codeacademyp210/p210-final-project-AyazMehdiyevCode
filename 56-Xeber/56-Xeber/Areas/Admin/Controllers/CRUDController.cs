using _56_Xeber.Areas.Admin.Models;
using _56_Xeber.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _56_Xeber.Areas.Admin.Controllers
{
    [Acsess]
    public class CRUDController : Controller
    {
        private XeberContext db = new XeberContext();


        // GET: Admin/CRUD
        public ActionResult Index()
        {

            List<News> news = db.News.Include(x=> x.Images).Include(x=> x.Category).ToList();
            
            return View(news);
        }


        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title_az,Text_az,Title_ru,Text_ru,CategoryId,Hot,Video")] News news, IEnumerable<HttpPostedFileBase> files)
        {
            news.PubDate = DateTime.Now;
            news.Status = true;
            news.ReadCount = 0;
            db.News.Add(news);
            int checkSave = db.SaveChanges();
            if (!(checkSave>0))
            {
                ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", news.CategoryId);
                return RedirectToAction("Create", news);
            }
            if (!(files.FirstOrDefault() == null))
            {
                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(DateTime.Now.ToString("ddmmyyyyhhmmssfff") + file.FileName);
                    string path = Path.Combine(Server.MapPath("~/Public/Uploads"), fileName);
                    file.SaveAs(path);
                    Image image = new Image();
                    image.NewsId = news.Id;
                    image.Url = fileName;
                    db.Images.Add(image);
                    db.SaveChanges();

                }
                    return RedirectToAction("Index");

            }
            return RedirectToAction("Create", news);

        }

        public ActionResult Read(int? id)
        {
            if (id==null)
            {
                return RedirectToAction("Index");
            }
            News news = db.News.Find(id);
            if (news==null)
            {
                return RedirectToAction("Index");
            }
            news.Images = db.Images.Where(x => x.NewsId == news.Id).ToList();
            news.Category = db.Categories.Find(news.CategoryId);
            return View(news);
        }

        public ActionResult Update(int? id)
        {
            if (id==null)
            {
                return RedirectToAction("Index");
            }
            News news = db.News.Find(id);
            if (news==null)
            {
                return RedirectToAction("Index");
            }
            news.Images = db.Images.Where(x => x.NewsId == news.Id).ToList();
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", news.CategoryId);
            return View(news);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "Id,PubDate,ReadCount,Title_az,Text_az,Title_ru,Text_ru,CategoryId,Hot,Video")] News news, IEnumerable<HttpPostedFileBase> files)
        {

            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();

            }

            if (!(files.FirstOrDefault() == null))
            {
                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(DateTime.Now.ToString("ddmmyyyyhhmmssfff") + file.FileName);
                    string path = Path.Combine(Server.MapPath("~/Public/Uploads"), fileName);
                    file.SaveAs(path);
                    Image image = new Image();
                    image.NewsId = news.Id;
                    image.Url = fileName;
                    db.Images.Add(image);
                    db.SaveChanges();

                }
                return RedirectToAction("Index");

            }
            news.Images = db.Images.Where(x => x.NewsId == news.Id).ToList();
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", news.CategoryId);
            return View("Update",news);

        }
        public ActionResult RemoveImg(int? id)
        {
            
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Image image = db.Images.Find(id);
            News news = db.News.Find(image.NewsId);

            if (image == null)
            {
                return RedirectToAction("Index");
            }
            db.Images.Remove(image);
            
            if ((db.SaveChanges())>=1)
            {
                string path = Path.Combine(Server.MapPath("~/Public/Uploads"),image.Url);
                FileInfo file = new FileInfo(path);
                file.Delete();
            };


            news.Images = db.Images.Where(x => x.NewsId == news.Id).ToList();
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", news.CategoryId);


            return View("Update", news);

        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return RedirectToAction("Index");
            }
            news.Images = db.Images.Where(x => x.NewsId == news.Id).ToList();
            news.Category = db.Categories.Find(news.CategoryId);
            return View(news);
        }

        // POST: Admin/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            List<Image> images = db.Images.Where(x => x.NewsId == id).ToList();

            db.News.Remove(news);
            db.SaveChanges();

            if (images.FirstOrDefault() != null)
            {
                foreach (var image in images)
                {
                    string path = Path.Combine(Server.MapPath("~/Public/Uploads"), image.Url);
                    FileInfo file = new FileInfo(path);
                    file.Delete();

                }

            }

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