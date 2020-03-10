using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticlePublishing.Models.Entities.Manager;
using ArticlePublishing.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArticlePublishing.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db;
        public HomeController(DatabaseContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            ArticleViewModel model = new ArticleViewModel();
            model.articlesList = db.Articles.Where(a => a.BannedStatus == false && a.ArticleStatus == true).OrderByDescending(x => x.NumOfLikes).Take(10).ToList();
            return View(model);
        }
    }
}