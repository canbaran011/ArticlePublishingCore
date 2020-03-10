using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticlePublishing.Models.Entities.Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ArticlePublishing.Models.ViewModels;
using ArticlePublishing.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace ArticlePublishing.Controllers
{
    public class ArticleController : Controller
    {
        DatabaseContext db;
        private readonly IHostingEnvironment hostingEnvironment;
        public ArticleController(DatabaseContext context, IHostingEnvironment environment)
        {
            db = context;
            hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserArticle()
        {
            int? sId = HttpContext.Session.GetInt32("ID");
            if (sId != null)
            {
                ArticleViewModel article = new ArticleViewModel();
                article.articlesList = db.Articles.Where(x => x.UserID == sId && x.ArticleStatus == true).ToList();
                return View(article);

            }
            return RedirectToAction("index", "Home");
        }
        public IActionResult ArticleCategories(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            int? sId = HttpContext.Session.GetInt32("ID");
            Categories categori = db.Categories.Where(x => x.ID == id).FirstOrDefault();
            ArticleViewModel model = new ArticleViewModel();

            model.articlesList = db.Articles.Where(x => x.CategoryID == categori.ID && x.ArticleStatus == true && x.BannedStatus == false).ToList();//categori ye ait makaleler
            foreach (var item in model.articlesList)
            {
                item.User = db.Users.FirstOrDefault(x => x.ID == item.UserID);
                item.Comments = db.Comments.Where(x => x.ArticleID == item.ID).ToList();
                item.FavouriteArticles = db.FavouriteArticles.Where(x => x.ArticleID == item.ID && x.UserID == (sId)).ToList();
            }

            ViewBag.CategoriName = categori.CategoriName;

            return View(model);
        }
        public IActionResult AddArticle()
        {
            int? sId = HttpContext.Session.GetInt32("ID");
            if (sId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ArticleViewModel articleModel = new ArticleViewModel();
            var list = db.Categories.ToList();
            articleModel.categoriSelectList = new SelectList(list, "ID", "CategoriName");
            return View(articleModel);
        }
        [HttpPost]
        public IActionResult AddArticle(ArticleViewModel model, IFormFile file)
        {
            int? sId = HttpContext.Session.GetInt32("ID");
            if (sId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //var fileName = Path.GetFileName(file.FileName);
            //var path = Path.Combine(Server.MapPath("~/Images"), fileName);
            //file.SaveAs(path);



            Articles article = new Articles();
            if (file != null && article != null)
            {
                var uniqueFileName = GetUniqueFileName(file.FileName);//benzersiz dosya ismi olusturuldu.
                var images = Path.Combine(hostingEnvironment.WebRootPath, "Images");//wwwroot klasorune kadarki yol alınıp images ile birleştirildi
                var filePath = Path.Combine(images, uniqueFileName);//dosya yolu ve adı birşetirildi.
                file.CopyTo(new FileStream(filePath, FileMode.Create));

                article.Title = model.article.Title;
                article.Text = model.article.Text;
                article.CategoryID = model.article.CategoryID;
                article.DefaultImage = uniqueFileName;
                article.UserID = sId;
                article.AddDate = DateTime.Now;
                article.ArticleStatus = true;
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("UserArticle", "Article");
            }
            else
            {
                ViewBag.Warning = "Article is not added.";
                ViewBag.Status = "danger";
            }
            var list = db.Categories.ToList();
            model.categoriSelectList = new SelectList(list, "ID", "CategoriName");

            return View(model);
        }
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
        [HttpGet]
        public IActionResult ReadArticle(int? id, int? cid)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            int? userID = HttpContext.Session.GetInt32("ID");
            ArticleViewModel model = new ArticleViewModel();
            model.article = db.Articles.FirstOrDefault(x => x.ID == id && x.ArticleStatus==true);
            if (model.article==null)
            {
                return RedirectToAction("Index", "Home");
            }
            model.article.Comments = db.Comments.Where(x => x.ArticleID == id).ToList();
            foreach (var item in model.article.Comments)
            {
                item.User = db.Users.FirstOrDefault(x=> x.ID==item.UserID);
            }
            model.article.User = db.Users.FirstOrDefault(x => x.ID == model.article.UserID);
            model.article.Category = db.Categories.FirstOrDefault(x => x.ID == model.article.CategoryID);
            model.favouriteArticles = db.FavouriteArticles.FirstOrDefault(x => x.ArticleID == id && x.UserID == userID);
            if (model != null)
            {
                //model.article.Text = model.article.Text.Replace(Environment.NewLine, @"<br />");                
                if (model.favouriteArticles == null) //fav null ise article kişinin favorilerinde değildir.
                {
                    model.favouriteArticles = new FavouriteArticles();
                    model.favouriteArticles.Favourite = false;
                    model.favouriteArticles.Liked = false;
                }
            }
            else
            {
                return RedirectToAction("ArticleCategories", "Article");
            }
            AdminList admin = new AdminList();
            admin = db.AdminList.Where(x => x.UserID == userID).FirstOrDefault();
            if (admin == null)
            {
                model.admin = false;
            }
            else
            {
                model.admin = true;
            }
            if (cid != null)
            {
                model.complaintID = cid;
            }
            return View(model);
        }

        [HttpPost]
        public JsonResult AddComment(int? articleID, string articleText)
        {
            int? userID = HttpContext.Session.GetInt32("ID");
            if (userID == null)
            {
                return Json(new { success = false, text = "To add comment please log in / or register" });
            }
            Comments comment = new Comments();
            if (!string.IsNullOrEmpty(articleText))
            {
                comment.ArticleID = articleID;
                comment.UserID = userID;
                comment.Text = articleText;
                comment.CommentDate = DateTime.Now;
                db.Comments.Add(comment);
                db.SaveChanges();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, text = "Please add a comment before send!" });
            }
        }

        public JsonResult DeleteComment(int? id)
        {
            Comments comment = db.Comments.Where(x => x.ID == id).FirstOrDefault();
            Articles article = db.Articles.Where(x => x.ID == comment.ArticleID).FirstOrDefault();//yonleneceği yer için
            bool IsDeleted;
            try
            {
                db.Entry(comment).State = EntityState.Deleted;
                db.SaveChanges();
                IsDeleted = true;
            }
            catch (Exception)
            {
                IsDeleted = false;
            }
            return Json(IsDeleted);
        }

        public JsonResult AddFavourite(int? articleID)
        {
            int? sId = HttpContext.Session.GetInt32("ID");
            if (sId == null)
            {
                return Json(new { success = false, text = "To add Favourite please log in / or register" });
            }
            if (articleID != null)
            {
                int userID = Convert.ToInt32(sId);
                FavouriteArticles like = new FavouriteArticles();
                like = db.FavouriteArticles.Where(x => x.ArticleID == articleID && x.UserID == userID).FirstOrDefault();
                if (like == null)//articleid ve userid aynı anda ekli değilse ekler
                {
                    like = new FavouriteArticles();
                    like.UserID = userID;
                    like.ArticleID = articleID;
                    like.Favourite = true;
                    like.Liked = false;
                    db.FavouriteArticles.Add(like);
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                else
                {
                    if (like.Favourite == false)
                    {
                        like.Favourite = true;
                        db.SaveChanges();
                        return Json(new { success = true });
                    }
                    else
                    {
                        return Json(new { success = false, text = "You already add the article to favourite." });
                    }
                }
            }
            else
            {
                return Json(new { success = false, text = "Article might be delete." });//herhangi bir kullanıcı articlea bakarken article silindiyse 
            }
        }

        public JsonResult RemoveFavourite(int? articleID)
        {
            int? sId = HttpContext.Session.GetInt32("ID");
            if (sId == null)
            {
                return Json(new { success = false, text = "To add comment please log in / or register" });
            }
            if (articleID != null)
            {
                FavouriteArticles like = new FavouriteArticles();
                like = db.FavouriteArticles.Where(x => x.ArticleID == articleID && x.UserID == sId).FirstOrDefault();
                if (like != null)//sorgu sonucu bi data geldiyse
                {
                    if (like.Favourite == true && like.Liked == true)//burada fav true ise false yapacağız.
                    {//liked true olma durumunu kontrol etme sebebi eğer false gelirse, 2 durumda false olacağı için kaydı kaldıracağız. veritabanında yer kaplamaması için
                        like.Favourite = false;
                        db.SaveChanges();
                        return Json(new { success = true });
                    }
                    else
                    {
                        db.Entry(like).State = EntityState.Deleted;
                        db.SaveChanges();
                        return Json(new { success = true });
                    }
                }
                else
                {
                    return Json(new { success = false, text = "You already remove the article from your favourite list." });
                }
            }
            else
            {
                return Json(new { success = false, text = "The article might be deleted." }); //herhangi bir kullanıcı articlea bakarken article silindiyse 
            }
        }

        public JsonResult IncreaseLike(int? articleID)
        {
            int? sId = HttpContext.Session.GetInt32("ID");
            if (sId == null)
            {
                return Json(new { success = false, text = "To Like a article please log in / or register" });
            }
            if (articleID != null)
            {
                FavouriteArticles like = new FavouriteArticles();
                like = db.FavouriteArticles.Where(x => x.ArticleID == articleID && x.UserID == sId).FirstOrDefault();
                if (like == null)//articleid ve userid aynı anda ekli değilse ekler
                {//kullanıcı yok ise
                    like = new FavouriteArticles();
                    like.UserID = sId;
                    like.ArticleID = articleID;
                    like.Favourite = false;
                    like.Liked = true;
                    db.FavouriteArticles.Add(like);

                    Articles article = db.Articles.Where(x => x.ID == articleID).FirstOrDefault();
                    article.NumOfLikes++;
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                else//zaten kullanıcı varsa ve daha önce favourite eklemiş fakat beğenmemişse bu alan çalışacak
                {
                    if (like.Liked == false)
                    {
                        like.Liked = true;
                        Articles article = db.Articles.Where(x => x.ID == articleID).FirstOrDefault();
                        article.NumOfLikes++;
                        db.SaveChanges();
                        return Json(new { success = true });
                    }
                    else
                    {
                        return Json(new { success = false, text = "You already Like the article." });
                    }
                }
            }
            else
            {
                return Json(new { success = false, text = "The article might be deleted." }); //herhangi bir kullanıcı articlea bakarken article silindiyse 
            }
        }

        public JsonResult DecreaseLike(int? articleID)
        {
            int? sId = HttpContext.Session.GetInt32("ID");
            if (sId == null)
            {
                return Json(new { success = false, text = "To Like a article please log in / or register" });
            }
            if (articleID != null)
            {
                FavouriteArticles like = new FavouriteArticles();
                like = db.FavouriteArticles.Where(x => x.ArticleID == articleID && x.UserID == sId).FirstOrDefault();
                if (like != null)//sorgu sonucu bi data geldiyse
                {
                    //like.Liked sadece True iken burası çalışacağı için Liked'ın false olma durumunu kontrol etmedim.Buradaki kontrolün asıl amacı eğer favourite de false ise veritabanında yer kaplamasını engellemek.yani eğer fav false gelirse, 2 durumda false olacağı için kaydı kaldıracağız. 
                    if (like.Liked == true && like.Favourite == true)//burada liked veritabanında true ise false yapacağız.
                    {
                        like.Liked = false;
                        Articles article = db.Articles.Where(x => x.ID == articleID).FirstOrDefault();
                        article.NumOfLikes--;
                        db.SaveChanges();
                        return Json(new { success = true });
                    }
                    else
                    {
                        db.Entry(like).State = EntityState.Deleted;
                        Articles article = db.Articles.Where(x => x.ID == articleID).FirstOrDefault();
                        article.NumOfLikes--;
                        db.SaveChanges();
                        return Json(new { success = true });
                    }
                }
                else
                {
                    return Json(new { success = false, text = "You already remove your Like from the article." });
                }
            }
            else
            {

                return Json(new { success = false, text = "The article might be deleted." }); //herhangi bir kullanıcı articlea bakarken article silindiyse 
            }
        }

        public IActionResult FavouriteArticles()
        {
            int? sId = HttpContext.Session.GetInt32("ID");
            if (sId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            List<Articles> articlesList = new List<Articles>();
            List<FavouriteArticles> liked = db.FavouriteArticles.Where(x => x.UserID == sId).ToList();
            foreach (FavouriteArticles item in liked)
            {
                Articles b = new Articles();
                b = db.Articles.Where(x => x.ID == item.ArticleID).FirstOrDefault();
                articlesList.Add(b);
            }
            ArticleViewModel model = new ArticleViewModel();
            model.articlesList = articlesList;
            return View(model);
        }
        [HttpGet]
        public IActionResult ReportArticle(int? articleID)
        {
            int? sId = HttpContext.Session.GetInt32("ID");
            if (sId == null || sId == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            ArticleViewModel model = new ArticleViewModel();
            model.article = db.Articles.Where(x => x.ID == articleID).FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public IActionResult ReportArticle(ArticleViewModel model)
        {
            int? sId = HttpContext.Session.GetInt32("ID");
            if (sId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                Complaints report = new Complaints();
                report = db.Complaints.Where(x => x.UserID == sId && x.ArticleID == model.article.ID).FirstOrDefault();
                if (report != null)
                {
                    ViewBag.Status = "danger";
                    ViewBag.Warning = "You have already report this article.We will respond to you as soon as possible.";
                    return View(model);
                }
                report = new Complaints();
                report.Subject = model.complaints.Subject;
                report.Text = model.complaints.Text;
                report.UserID = sId;
                report.ArticleID = model.article.ID;
                report.Checked = false;
                db.Complaints.Add(report);
                db.SaveChanges();
                ViewBag.Status = "success";
                ViewBag.Warning = "Your report sent successfully.We will responsd as soon as possible.";
            }
            return View(model);
        }

        public IActionResult DeleteArticle(int? articleID)
        {
            Articles article = new Articles();
            article = db.Articles.Where(x => x.ID == articleID).FirstOrDefault();
            article.ArticleStatus = false;
            db.SaveChanges();
            //return Json(new { success = true });
            return RedirectToAction("UserArticles", "Article");
        }
    }
}