using ArticlePublishing.Models.Entities;
using ArticlePublishing.Models.Entities.Manager;
using ArticlePublishing.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticlePublishing.Models.ViewComponents
{
    public class ProfileViewComponent : ViewComponent
    {
        DatabaseContext db;
        public ProfileViewComponent(DatabaseContext context)
        {
            db = context;
        }
        public IViewComponentResult Invoke()
        {
            VComponentViewModels model = new VComponentViewModels();
            int? id = Convert.ToInt32(HttpContext.Request.Query["id"]);
            int? sId = HttpContext.Session.GetInt32("ID");
            if (id == sId)//login olmuş birisi kendi ismine tıklarsa, kendi profiline gitsin
            {
                model.User = db.Users.Where(x => x.ID == sId).FirstOrDefault();
                model.IsPrivate = true;
            }
            else if (sId == null)//kesinlikle login olmayan birisi, bir profile bakmak istiyordur
            {
                model.User = db.Users.Where(x => x.ID == id).FirstOrDefault();
                model.IsPrivate = false;
            }
            else if (id == 0)
            {
                model.User = db.Users.Where(x => x.ID == sId).FirstOrDefault();
                model.IsPrivate = true;
            }
            else if (id != sId && sId != null && id != 0)//login olan birisi, bir baskasının profiline bakıyordur
            {
                model.User = db.Users.Where(x => x.ID == id).FirstOrDefault();
                model.IsPrivate = false;
            }
            return View(model);
        }
    }
}
