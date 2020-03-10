using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ArticlePublishing.Models.Entities;
using ArticlePublishing.Models.ViewModels;
using ArticlePublishing.Models.Entities.Manager;
using Microsoft.EntityFrameworkCore;

namespace ArticlePublishing.Controllers
{
    public class AdminController : Controller
    {
        DatabaseContext db;
        public AdminController(DatabaseContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            int? sId=HttpContext.Session.GetInt32("ID");
            if (sId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            AdminList adm = new AdminList();
            adm = db.AdminList.Where(x => x.UserID == sId).FirstOrDefault();//suanki user superadmin mi ? 
            AdminViewModel model = new AdminViewModel();
            model.userList = db.Users.ToList();
            if (adm.AuthDegree == 1)//superadminse eğer diğer adminleri görebilmeli
            {
                model.useradminList = new List<Users>();
                List<AdminList> admins = new List<AdminList>();
                admins = db.AdminList.ToList();
                foreach (var user in model.userList)
                {
                    foreach (var admin in admins)
                    {
                        if (user.ID == admin.UserID)
                        {
                            model.useradminList.Add(user);//adminleri bulduk.
                        }
                    }
                }
                model.superadmin = true;
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult BanArticle(int? articleID, int? cid)
        {
            int? sId = HttpContext.Session.GetInt32("ID");
            if (sId == null)
            {
                return RedirectToAction("index", "Home");
            }
            ArticleViewModel articles = new ArticleViewModel();
            articles.article = db.Articles.Where(x => x.ID == articleID).FirstOrDefault();
            if (cid == null)
            {
                TempData["msg"] = "<script>alert('To ban this article,you have to came from a report button!!!');</script>";
                return RedirectToAction("ReadArticle", "Article", new { id = articleID });
            }
            articles.complaints = db.Complaints.Where(x => x.ID == cid).FirstOrDefault();
            articles.bannedArticles = new BannedArticles();
            return View(articles);
        }

        [HttpPost]
        public IActionResult BanArticle(ArticleViewModel model)
        {
            int? sId = HttpContext.Session.GetInt32("ID");
            if (sId== null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (model != null)
            {
                BannedArticles bannedarticle = new BannedArticles();
                bannedarticle.ArticleID = model.article.ID;
                bannedarticle.ComplaintID = model.complaints.ID;
                bannedarticle.Reason = model.bannedArticles.Reason;
                bannedarticle.BannedLimit = model.bannedArticles.BannedLimit;
                bannedarticle.BannedDate = DateTime.Now;
                bannedarticle.AdminListID = sId;
                db.BannedArticles.Add(bannedarticle);
                db.SaveChanges();

                Articles article = new Articles();
                article = db.Articles.Where(x => x.ID == bannedarticle.ArticleID).FirstOrDefault();
                article.BannedStatus = true;
                article.ArticleStatus = true;
                db.SaveChanges();
                ViewBag.Warning = "You banned article.";
                ViewBag.Status = "success";
                return View(model);
            }

            return View(model);
        }

        public IActionResult Complaints()
        {
            int? sId = HttpContext.Session.GetInt32("ID");
            if (sId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            AdminList adm = new AdminList();
            adm = db.AdminList.Where(x => x.UserID == sId).FirstOrDefault();
            AdminViewModel model = new AdminViewModel();
            if (adm != null)
            {
                model.Complaints = db.Complaints.ToList();
            }
            return View(model);
        }
        public JsonResult CheckComplaints(int? id)
        {
            Complaints complaints = db.Complaints.Where(x => x.ID == id).FirstOrDefault();
            bool IsDeleted;
            try
            {
                complaints.Checked = true;
                db.SaveChanges();
                IsDeleted = true;
            }
            catch (Exception)
            {
                IsDeleted = false;
            }
            return Json(IsDeleted);
        }
        public JsonResult AddAdmin(string username)
        {
            bool data = false;

            try
            {
                Users user = new Users();
                user = db.Users.Where(x => x.UserName == username).FirstOrDefault();
                if (user != null)
                {
                    AdminList adminlist = new AdminList();
                    adminlist = db.AdminList.Where(x => x.UserID == user.ID).FirstOrDefault();

                    if (adminlist == null)
                    {
                        adminlist = new AdminList();
                        adminlist.UserID = user.ID;
                        adminlist.AuthDegree = 2;
                        adminlist.AuthName = "Admin";
                        db.AdminList.Add(adminlist);
                        db.SaveChanges();
                        data = true;
                    }
                    else
                    {
                        data = false;
                    }
                }
            }
            catch (Exception)
            {
                data = false;
            }
            return Json(data);
        }
        public JsonResult DeleteAdmin(string username)
        {
            bool IsDeleted = false;

            Users user = new Users();
            user = db.Users.Where(x => x.UserName == username).FirstOrDefault();
            if (user != null)
            {
                AdminList adminlist = new AdminList();
                adminlist = db.AdminList.Where(x => x.UserID == user.ID).FirstOrDefault();

                try
                {
                    db.Entry(adminlist).State = EntityState.Deleted;
                    db.SaveChanges();
                    IsDeleted = true;
                }
                catch (Exception)
                {
                    IsDeleted = false;
                }
            }
            return Json(IsDeleted);
        }


        public JsonResult BanUser(string username)
        {
            bool data = false;
            try
            {
                Users user = new Users();
                user = db.Users.Where(x => x.UserName == username).FirstOrDefault();
                if (user != null)
                {
                    user.BannedStatus = true;
                    db.SaveChanges();
                    data = true;
                }
            }
            catch (Exception)
            {
                data = false;
            }
            return Json(data);
        }

        public JsonResult UnbanUser(string username)
        {
            bool data = false;
            try
            {
                Users user = new Users();
                user = db.Users.Where(x => x.UserName == username).FirstOrDefault();
                if (user != null)
                {
                    user.BannedStatus = false;
                    db.SaveChanges();
                    data = true;
                }
            }
            catch (Exception)
            {
                data = false;
            }
            return Json(data);
        }


    }
}